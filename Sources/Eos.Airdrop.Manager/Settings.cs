namespace Eos.Airdrop.Manager
{
    public class Settings
    {
        public decimal FilterBalanceFrom { get; set; } = 0;

        public decimal FilterBalanceTo { get; set; } = decimal.MaxValue;

        public Asset AirdropTokenCount { get; set; } = new Asset("2000000.0000 VIM");
    }
}