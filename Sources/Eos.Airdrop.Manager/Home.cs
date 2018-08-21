using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ditch.Core;
using Ditch.EOS;
using System.Windows.Forms;
using Ditch.EOS.Models;
using Eos.Airdrop.Manager.Contract.EosioToken.Actions;
using Eos.Airdrop.Manager.Contract.EosioToken.Structs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Base58 = Ditch.Core.Base58;

namespace Eos.Airdrop.Manager
{
    public partial class Home : Form
    {
        private CancellationTokenSource cts;
        private readonly HashSet<string> _exclude = new HashSet<string> { "eosio.stake" };
        private Encoding Encoding = Encoding.UTF8;
        protected RepeatHttpClient HttpClient;
        protected static OperationManager Api;
        private readonly string _login;
        private readonly List<byte[]> _privateKeys;
        private bool IsCanChangeStates = true;
        private bool IsTestnet = false;


        protected List<AccountDump> AccountDumps;
        private Settings _settings;

        private const string StateFileName = "TaskState.json";
        private const string SettingsFileName = "Settings.json";
        private const string TaskLogFileName = "TaskLog.json";
        private const string TestNetAccountsFileName = "TestnetAcc.txt";

        public Home()
        {
            InitializeComponent();

            var f = Directory.GetFiles(".", "*.csv");
            if (f.Any())
                tbPathToDump.Text = f[0];

            IsTestnet = bool.Parse(ConfigurationManager.AppSettings["IsTestnet"]);
            _login = ConfigurationManager.AppSettings["Login"];
            _privateKeys = new List<byte[]>
            {
                Base58.DecodePrivateWif(ConfigurationManager.AppSettings["PrivateActiveWif"])
            };

            HttpClient = new RepeatHttpClient();
            Api = new OperationManager(HttpClient)
            {
                ChainUrl = ConfigurationManager.AppSettings["ChainUrl"], // path to EOS node
                WalletUrl = ConfigurationManager.AppSettings["WalletUrl"] // path to EOS Wallet (if needed)
            };

            Load += Home_Load;
            FormClosing += Home_FormClosing;
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            cts?.Cancel();
        }

        private async void Home_Load(object sender, EventArgs e)
        {
            LoadSettings();
            LoadState();

            InitSettings();

            BalanceFilterChanged(null, null);
        }

        private void LoadState()
        {
            if (File.Exists(StateFileName))
            {
                var json = File.ReadAllText(StateFileName);
                AccountDumps = JsonConvert.DeserializeObject<List<AccountDump>>(json);
                IsCanChangeStates = false;
            }
        }

        private void LoadSettings()
        {
            if (File.Exists(SettingsFileName))
            {
                var json = File.ReadAllText(SettingsFileName);
                _settings = JsonConvert.DeserializeObject<Settings>(json);
            }
            else
            {
                _settings = new Settings();
                var json = JsonConvert.SerializeObject(_settings);
                File.WriteAllText(SettingsFileName, json);
            }
        }

        private void InitSettings()
        {
            tbFilterBalanceFrom.Text = _settings.FilterBalanceFrom.ToString(CultureInfo.InvariantCulture);
            if (_settings.FilterBalanceTo != decimal.MaxValue)
                tbFilterBalanceTo.Text = _settings.FilterBalanceTo.ToString(CultureInfo.InvariantCulture);

            tbAirdropTokenCount.Text = _settings.AirdropTokenCount.ToString();

            tbFilterBalanceFrom.TextChanged += BalanceFilterChanged;
            tbFilterBalanceTo.TextChanged += BalanceFilterChanged;
            tbAirdropTokenCount.TextChanged += BalanceFilterChanged;
        }

        private void LoadDump(object sender, EventArgs e)
        {
            btnLoadDump.Enabled = false;
            try
            {
                var pathtoDump = tbPathToDump.Text;
                if (File.Exists(pathtoDump))
                {
                    var data = File.ReadAllLines(pathtoDump);
                    AccountDumps = new List<AccountDump>(data.Length - 1);
                    for (int i = 1; i < data.Length; i++)
                    {
                        var line = data[i];
                        var cols = line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        if (cols.Length != 3)
                            throw new InvalidCastException(line);

                        var accountDump = new AccountDump
                        {
                            CreationTime = DateTime.Parse(cols[0]),
                            AccountName = cols[1],
                            TotalEos = new Asset($"{cols[2]} EOS")
                        };
                        AccountDumps.Add(accountDump);
                    }

                    lbldumpAccountCount.Text = AccountDumps.Count.ToString();
                    BalanceFilterChanged(sender, e);
                }
                else
                {
                    lbldumpAccountCount.Text = "Invalid path!";
                }
            }
            catch (Exception exception)
            {
                lbldumpAccountCount.Text = exception.Message;
            }

            btnLoadDump.Enabled = true;
        }


        private void BalanceFilterChanged(object sender, EventArgs e)
        {
            try
            {
                if (AccountDumps == null || !AccountDumps.Any() || string.IsNullOrEmpty(tbAirdropTokenCount.Text))
                    return;

                if (!decimal.TryParse(tbFilterBalanceFrom.Text,
                        NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture,
                        out var @from) && sender == tbFilterBalanceFrom)
                    return;

                if (!decimal.TryParse(tbFilterBalanceTo.Text,
                    NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture,
                    out var to))
                {
                    if (sender == tbFilterBalanceTo && !string.IsNullOrEmpty(tbFilterBalanceTo.Text))
                        return;

                    to = decimal.MaxValue;
                }

                var asset = new Asset(tbAirdropTokenCount.Text);

                _settings.AirdropTokenCount = asset;
                _settings.FilterBalanceFrom = from;
                _settings.FilterBalanceTo = to;

                if (IsCanChangeStates || (sender != null && e != null &&
                                          MessageBox.Show("!!! Current state will be cleaned", "State manager",
                                              MessageBoxButtons.OKCancel) == DialogResult.OK))
                {
                    IsCanChangeStates = true;
                    SetStats();
                }

                var selected = AccountDumps.Where(d => d.AirdropState.HasFlag(AirdropState.Selected)).ToArray();
                var sumEos = Asset.Sum(selected.Select(a => a.TotalEos).ToArray());
                var delta = asset.ValueDouble / sumEos.ValueDouble;

                lblFilteredAccCount.Text =
                    $"{selected.Length} accounts gets {Asset.Sum(AccountDumps.Where(a => a.AirdropState.HasFlag(AirdropState.Selected)).Select(a => a.Airdrop).ToArray())}";

                var dec = (decimal)Math.Pow(10, asset.Decimals);
                var airTokenvalue = (long)(from * delta * dec);
                if (airTokenvalue < 1)
                    lblFilteredAccCount.Text +=
                        $" !!! Min balance = {from * delta}. Set 'from' to {1 / (delta * dec)} or increase decimals in asset.";


                UpdateTaskState();
                UpdateAnalitics();
            }
            catch (Exception exception)
            {
                lblFilteredAccCount.Text = exception.Message;
            }
        }

        private void SetStats()
        {
            var selected = AccountDumps
                .Where(g => !_exclude.Contains(g.AccountName) && g.TotalEos >= _settings.FilterBalanceFrom && g.TotalEos <= _settings.FilterBalanceTo)
                .ToArray();

            for (int i = 0; i < AccountDumps.Count; i++)
            {
                var acc = AccountDumps[i];
                acc.Exception = null;
                acc.Airdrop = null;
                acc.AirdropState = AirdropState.None;
            }

            if (IsTestnet && File.Exists(TestNetAccountsFileName))
            {
                var testAccs = File.ReadAllLines(TestNetAccountsFileName);
                var hs = new HashSet<string>(testAccs);

                for (int i = 0; i < AccountDumps.Count; i++)
                {
                    var acc = AccountDumps[i];
                    if (!hs.Contains(acc.AccountName))
                    {
                        acc.AirdropState = AirdropState.Skeeped | AirdropState.Error;
                        acc.Exception = "Not exist in testnet";
                    }
                }
            }

            var sumEos = Asset.Sum(selected.Select(a => a.TotalEos).ToArray());
            var toLong = (decimal)Math.Pow(10, _settings.AirdropTokenCount.Decimals);

            for (int i = 0; i < selected.Length; i++)
            {
                var acc = selected[i];
                if (acc.AirdropState.HasFlag(AirdropState.Skeeped))
                    continue;

                if (acc.TotalEos.Amount == 0)
                {
                    acc.AirdropState = AirdropState.Skeeped | AirdropState.Error;
                    acc.Exception = "Min value";
                    continue;
                }

                var airToken = acc.TotalEos.ValueDouble * _settings.AirdropTokenCount.ValueDouble / sumEos.ValueDouble;
                var airTokenvalue = (long)(airToken * toLong);
                if (airTokenvalue > 0)
                {
                    acc.AirdropState = AirdropState.Selected;
                    acc.Airdrop = new Asset(airTokenvalue, _settings.AirdropTokenCount.Decimals,
                        _settings.AirdropTokenCount.Currency);
                }
                else
                {
                    acc.AirdropState = AirdropState.Skeeped | AirdropState.Error;
                    acc.Exception = "Min value";
                }
            }
        }

        private void UpdateTaskState()
        {
            var selected = AccountDumps
                .Where(g => g.AirdropState.HasFlag(AirdropState.Selected))
                .ToArray();

            lblTaskCount.Text = selected.Length.ToString();
            lblTaskFinished.Text = AccountDumps.Count(g => g.AirdropState.HasFlag(AirdropState.Ready)).ToString();
            lblTaskSkipedCount.Text = AccountDumps.Count(g => g.AirdropState.HasFlag(AirdropState.Skeeped)).ToString();
            lblTaskErrorCount.Text = AccountDumps.Count(g => g.AirdropState.HasFlag(AirdropState.Error)).ToString();
        }

        private void UpdateAnalitics()
        {
            dgvAccauntBalance.Rows.Clear();

            var accountDumpsFiltered = AccountDumps.Where(g => !_exclude.Contains(g.AccountName)).ToArray();

            var sum = Asset.Sum(accountDumpsFiltered.Select(i => i.TotalEos).ToArray());
            var max = accountDumpsFiltered.Max(i => i.TotalEos);
            var min = accountDumpsFiltered.Where(i => i.TotalEos > 0).Min(i => i.TotalEos);

            lblSumBalanse.Text = sum.ToString();
            lblMaxBalance.Text = max.ToString();
            lblMinBalance.Text = min.ToString();

            int maxCount = 1000000000;
            for (long c = -1; c < maxCount;)
            {
                string grpName;
                AccountDump[] grp;

                if (c == -1)
                {
                    c = 0;
                    if (_settings.FilterBalanceFrom == 0)
                        continue;

                    grpName = $"[0, {_settings.FilterBalanceFrom})";
                    grp = accountDumpsFiltered.Where(i => i.TotalEos < _settings.FilterBalanceFrom).ToArray();
                }
                else if (c == 0)
                {
                    if (_settings.FilterBalanceFrom == 0)
                    {
                        grpName = $"[0, {1})";
                        grp = accountDumpsFiltered.Where(i => i.TotalEos < 1).ToArray();
                        c = 1;
                    }
                    else
                    {
                        c = (int)Math.Ceiling(_settings.FilterBalanceFrom);
                        grpName = $"[{_settings.FilterBalanceFrom}, {c})";
                        grp = accountDumpsFiltered
                            .Where(i => i.TotalEos >= _settings.FilterBalanceFrom && i.TotalEos < c * 10).ToArray();
                        c *= 10;
                    }
                }
                else if (c * 10 > maxCount)
                {
                    grpName = $">= {maxCount}";
                    grp = accountDumpsFiltered.Where(i => i.TotalEos >= c).ToArray();
                    c *= 10;
                }
                else
                {
                    grpName = $"[{c},{c * 10})";
                    grp = accountDumpsFiltered.Where(i => i.TotalEos >= c && i.TotalEos < c * 10).ToArray();
                    c *= 10;
                }

                if (!grp.Any())
                    continue;

                var eosSum = Asset.Sum(grp.Select(i => i.TotalEos).ToArray()).ToDecimal();
                var airdrop = grp.Where(g => g.AirdropState.HasFlag(AirdropState.Selected)).Select(a => a.Airdrop)
                    .ToArray();
                var airdropSum = airdrop.Any() ? Asset.Sum(airdrop).ToDecimal() : 0;


                var accPrc = accountDumpsFiltered.Length > 0 ? grp.Length * 100.0 / accountDumpsFiltered.Length : 0;
                var eosPrc = eosSum * 100 / sum.ToDecimal();
                var eosByAcc = grp.Length > 0 ? eosSum / grp.Length : 0;
                var airByAcc = airdrop.Length > 0 ? airdropSum / airdrop.Length : 0;

                dgvAccauntBalance.Rows.Add(grpName, grp.Length, accPrc, eosSum, eosPrc, eosByAcc, airdrop.Length,
                    airdropSum, airByAcc);
            }
        }


        private void SaveSettings(object sender, EventArgs e)
        {
            btnSaveSetting.Enabled = false;

            var json = JsonConvert.SerializeObject(_settings);
            File.WriteAllText(SettingsFileName, json);

            var state = JsonConvert.SerializeObject(AccountDumps);
            File.WriteAllText(StateFileName, state, Encoding);

            btnSaveSetting.Enabled = true;
        }

        private async void Airdrop(object sender, EventArgs e)
        {
            btnStartTask.Enabled = false;
            cts = new CancellationTokenSource();
            var token = cts.Token;
            IsCanChangeStates = false;

            var selected = AccountDumps
                .Where(g => g.AirdropState.HasFlag(AirdropState.Selected) && !g.AirdropState.HasFlag(AirdropState.Ready))
                .OrderBy(a => a.CreationTime)
                .ToArray();

            await LoopAirdrop(selected, 5, token);

            btnStartTask.Enabled = true;
        }

        private async Task LoopAirdrop(AccountDump[] selected, int maxActionInTransaction, CancellationToken token)
        {
            try
            {
                var dts = DateTime.Now;
                var skip = 0;

                await LogAccountState();
                do
                {
                    if (token.IsCancellationRequested)
                        break;

                    var accounts = selected.Skip(skip).Take(maxActionInTransaction).ToArray();

                    foreach (var account in accounts)
                        account.AirdropState = AirdropState.Selected | AirdropState.Started;
                    AddTaskLogLine(accounts);
                    await BulkAirdrop(accounts, token);
                    AddTaskLogLine(accounts);

                    skip += maxActionInTransaction;

                    lblTaskCount.Text = AccountDumps.Count(g => g.AirdropState.HasFlag(AirdropState.Selected))
                        .ToString();
                    lblTaskFinished.Text =
                        AccountDumps.Count(g => g.AirdropState.HasFlag(AirdropState.Ready)).ToString();
                    lblTaskSkipedCount.Text =
                        AccountDumps.Count(g => g.AirdropState.HasFlag(AirdropState.Skeeped)).ToString();
                    lblTaskErrorCount.Text =
                        AccountDumps.Count(g => g.AirdropState.HasFlag(AirdropState.Error)).ToString();

                    var elapsedTime = DateTime.Now - dts;
                    var completionTime = TimeSpan.FromSeconds(elapsedTime.TotalSeconds * selected.Length / (skip + 1));

                    lblTimer.Text = $"{elapsedTime.ToString().Remove(8)} | {completionTime.ToString().Remove(8)}";
                } while (skip < selected.Length);

            }
            finally
            {
                SaveSettings(null, null);
            }
        }


        private async Task LogAccountState()
        {
            var args = new GetAccountParams(_login);
            var info = await Api.GetAccount(args, CancellationToken.None);

            var json = JsonConvert.SerializeObject(info);
            File.AppendAllLines(TaskLogFileName, new[] { json }, Encoding);
        }

        private async Task BulkAirdrop(AccountDump[] accounts, CancellationToken token)
        {
            var res = await BulkTransfer(accounts, token);
            if (res.IsError)
            {
                if (accounts.Length == 1)
                {
                    accounts[0].AirdropState = AirdropState.Selected | AirdropState.Error;
                    accounts[0].Exception = $"{res.Exception.Message} {res.Exception.StackTrace}";
                }
                else
                {
                    foreach (var account in accounts)
                        await BulkAirdrop(new[] { account }, token);
                }
            }
            else
            {
                foreach (var account in accounts)
                {
                    account.AirdropState = AirdropState.Selected | AirdropState.Ready;
                    account.Exception = string.Empty;
                }
            }
        }

        private async Task<OperationResult<PushTransactionResults>> BulkTransfer(AccountDump[] accounts, CancellationToken token)
        {
            var actions = new BaseAction[accounts.Length];
            for (int i = 0; i < accounts.Length; i++)
            {
                var account = accounts[i];
                actions[i] = new TransferAction
                {
                    Account = TransferAction.ContractName,
                    Args = new Transfer
                    {
                        From = _login,
                        To = account.AccountName,
                        Quantity = account.Airdrop,
                        Memo = string.Empty
                    },
                    Authorization = new[]
                    {
                        new PermissionLevel
                        {
                            Actor = _login,
                            Permission = "active"
                        }
                    }
                };
            }
            return await Api.BroadcastActions(actions, _privateKeys, token);
        }



        private void AddTaskLogLine(AccountDump[] accounts)
        {
            var lines = new string[accounts.Length];
            for (int i = 0; i < accounts.Length; i++)
            {
                var account = accounts[i];
                lines[i] = JsonConvert.SerializeObject(account);
            }

            File.AppendAllLines(TaskLogFileName, lines, Encoding);
        }


        private static async Task GenerateCode()
        {
            try
            {
                var generator = new ContractCodeGenerator();
                await generator.Generate(Api, "eosio.token", "Eos.Airdrop.Manager.Contract", "../../Contract/",
                    new HashSet<string> { "transfer" }, CancellationToken.None);
                MessageBox.Show("Contract classes was successfully generated!", "File generator", MessageBoxButtons.OK);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace, e.Message, MessageBoxButtons.OK);
            }
        }

        private async void GenerateModelFromAbi(object sender, EventArgs e)
        {
            btnAbiToModel.Enabled = false;

            await GenerateCode();

            btnAbiToModel.Enabled = true;
        }

        private void TaskStop(object sender, EventArgs e)
        {
            btnTaskStop.Enabled = false;
            cts?.Cancel();
            btnTaskStop.Enabled = true;
        }

        private async void btnGetAccounts_Click(object sender, EventArgs e)
        {
            btnGetAccounts.Enabled = false;
            var args = new GetTableRowsParams
            {
                Code = "eosio",
                Scope = "eosio",
                Table = "voters",
                Json = true,
                //LowerBound = "0",
                //UpperBound = "-1",
                Limit = 1000
            };

            int skip = 0;
            do
            {
                var resp = await Api.GetTableRows(args, CancellationToken.None);
                if (resp.IsError)
                {
                    throw resp.Exception;
                }

                var accs = resp.Result.Rows.Skip(skip).Select(r => ((JObject)r).Value<string>("owner")).ToArray();
                if (accs.Any())
                    File.AppendAllLines(TestNetAccountsFileName, accs);

                if (!resp.Result.More)
                    break;

                args.LowerBound = accs.Last();
                skip = 1;
            } while (true);

            btnGetAccounts.Enabled = true;
        }
    }
}
