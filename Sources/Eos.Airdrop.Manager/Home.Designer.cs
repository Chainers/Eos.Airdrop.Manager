namespace Eos.Airdrop.Manager
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnLoadDump = new System.Windows.Forms.Button();
            this.lbldumpAccountCount = new System.Windows.Forms.Label();
            this.tbPathToDump = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnTaskStop = new System.Windows.Forms.Button();
            this.lblTaskErrorCount = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblTaskSkipedCount = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            this.lblTaskFinished = new System.Windows.Forms.Label();
            this.lblTaskCount = new System.Windows.Forms.Label();
            this.btnStartTask = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblMinBalance = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dgvAccauntBalance = new System.Windows.Forms.DataGridView();
            this.BalanceGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accPrc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.avdacc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AirAcc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AirdropSum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AirdropAcc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSumBalanse = new System.Windows.Forms.Label();
            this.lblMaxBalance = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbAirdropTokenCount = new System.Windows.Forms.TextBox();
            this.btnSaveSetting = new System.Windows.Forms.Button();
            this.lblFilteredAccCount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbFilterBalanceTo = new System.Windows.Forms.TextBox();
            this.tbFilterBalanceFrom = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAbiToModel = new System.Windows.Forms.Button();
            this.btnGetAccounts = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccauntBalance)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoadDump
            // 
            this.btnLoadDump.Location = new System.Drawing.Point(599, 30);
            this.btnLoadDump.Name = "btnLoadDump";
            this.btnLoadDump.Size = new System.Drawing.Size(171, 69);
            this.btnLoadDump.TabIndex = 0;
            this.btnLoadDump.Text = "Load dump";
            this.btnLoadDump.UseVisualStyleBackColor = true;
            this.btnLoadDump.Click += new System.EventHandler(this.LoadDump);
            // 
            // lbldumpAccountCount
            // 
            this.lbldumpAccountCount.AutoSize = true;
            this.lbldumpAccountCount.Location = new System.Drawing.Point(184, 74);
            this.lbldumpAccountCount.Name = "lbldumpAccountCount";
            this.lbldumpAccountCount.Size = new System.Drawing.Size(24, 25);
            this.lbldumpAccountCount.TabIndex = 1;
            this.lbldumpAccountCount.Text = "0";
            // 
            // tbPathToDump
            // 
            this.tbPathToDump.Location = new System.Drawing.Point(17, 30);
            this.tbPathToDump.Name = "tbPathToDump";
            this.tbPathToDump.Size = new System.Drawing.Size(576, 31);
            this.tbPathToDump.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnLoadDump);
            this.groupBox1.Controls.Add(this.tbPathToDump);
            this.groupBox1.Controls.Add(this.lbldumpAccountCount);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(895, 136);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dump loader";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(166, 25);
            this.label6.TabIndex = 3;
            this.label6.Text = "Account counts:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnTaskStop);
            this.groupBox2.Controls.Add(this.lblTaskErrorCount);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.lblTaskSkipedCount);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.lblTimer);
            this.groupBox2.Controls.Add(this.lblTaskFinished);
            this.groupBox2.Controls.Add(this.lblTaskCount);
            this.groupBox2.Controls.Add(this.btnStartTask);
            this.groupBox2.Location = new System.Drawing.Point(12, 763);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1133, 225);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Task state";
            // 
            // btnTaskStop
            // 
            this.btnTaskStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTaskStop.Location = new System.Drawing.Point(956, 108);
            this.btnTaskStop.Name = "btnTaskStop";
            this.btnTaskStop.Size = new System.Drawing.Size(171, 72);
            this.btnTaskStop.TabIndex = 10;
            this.btnTaskStop.Text = "Stop";
            this.btnTaskStop.UseVisualStyleBackColor = true;
            this.btnTaskStop.Click += new System.EventHandler(this.TaskStop);
            // 
            // lblTaskErrorCount
            // 
            this.lblTaskErrorCount.AutoSize = true;
            this.lblTaskErrorCount.Location = new System.Drawing.Point(137, 119);
            this.lblTaskErrorCount.Name = "lblTaskErrorCount";
            this.lblTaskErrorCount.Size = new System.Drawing.Size(24, 25);
            this.lblTaskErrorCount.TabIndex = 9;
            this.lblTaskErrorCount.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 119);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 25);
            this.label11.TabIndex = 8;
            this.label11.Text = "Error:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 25);
            this.label10.TabIndex = 7;
            this.label10.Text = "Skiped:";
            // 
            // lblTaskSkipedCount
            // 
            this.lblTaskSkipedCount.AutoSize = true;
            this.lblTaskSkipedCount.Location = new System.Drawing.Point(137, 90);
            this.lblTaskSkipedCount.Name = "lblTaskSkipedCount";
            this.lblTaskSkipedCount.Size = new System.Drawing.Size(24, 25);
            this.lblTaskSkipedCount.TabIndex = 6;
            this.lblTaskSkipedCount.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 25);
            this.label8.TabIndex = 5;
            this.label8.Text = "Ready:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 25);
            this.label7.TabIndex = 4;
            this.label7.Text = "Total count:";
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Location = new System.Drawing.Point(6, 197);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(70, 25);
            this.lblTimer.TabIndex = 3;
            this.lblTimer.Text = "label1";
            // 
            // lblTaskFinished
            // 
            this.lblTaskFinished.AutoSize = true;
            this.lblTaskFinished.Location = new System.Drawing.Point(137, 65);
            this.lblTaskFinished.Name = "lblTaskFinished";
            this.lblTaskFinished.Size = new System.Drawing.Size(24, 25);
            this.lblTaskFinished.TabIndex = 2;
            this.lblTaskFinished.Text = "0";
            // 
            // lblTaskCount
            // 
            this.lblTaskCount.AutoSize = true;
            this.lblTaskCount.Location = new System.Drawing.Point(137, 40);
            this.lblTaskCount.Name = "lblTaskCount";
            this.lblTaskCount.Size = new System.Drawing.Size(24, 25);
            this.lblTaskCount.TabIndex = 1;
            this.lblTaskCount.Text = "0";
            // 
            // btnStartTask
            // 
            this.btnStartTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartTask.Location = new System.Drawing.Point(956, 30);
            this.btnStartTask.Name = "btnStartTask";
            this.btnStartTask.Size = new System.Drawing.Size(171, 72);
            this.btnStartTask.TabIndex = 0;
            this.btnStartTask.Text = "Run";
            this.btnStartTask.UseVisualStyleBackColor = true;
            this.btnStartTask.Click += new System.EventHandler(this.Airdrop);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.lblMinBalance);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.dgvAccauntBalance);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.lblSumBalanse);
            this.groupBox3.Controls.Add(this.lblMaxBalance);
            this.groupBox3.Location = new System.Drawing.Point(12, 164);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1139, 386);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Statistic *without eosio.stake";
            // 
            // lblMinBalance
            // 
            this.lblMinBalance.AutoSize = true;
            this.lblMinBalance.Location = new System.Drawing.Point(575, 52);
            this.lblMinBalance.Name = "lblMinBalance";
            this.lblMinBalance.Size = new System.Drawing.Size(320, 25);
            this.lblMinBalance.TabIndex = 25;
            this.lblMinBalance.Text = "XXXXXXXXXXXX.XXXXXX EOS";
            this.lblMinBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(434, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(135, 25);
            this.label9.TabIndex = 24;
            this.label9.Text = "Min balance:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvAccauntBalance
            // 
            this.dgvAccauntBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAccauntBalance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvAccauntBalance.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvAccauntBalance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccauntBalance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BalanceGroup,
            this.AccountCount,
            this.accPrc,
            this.Balance,
            this.prc,
            this.avdacc,
            this.AirAcc,
            this.AirdropSum,
            this.AirdropAcc});
            this.dgvAccauntBalance.Location = new System.Drawing.Point(17, 98);
            this.dgvAccauntBalance.Name = "dgvAccauntBalance";
            this.dgvAccauntBalance.RowHeadersWidth = 50;
            this.dgvAccauntBalance.RowTemplate.Height = 33;
            this.dgvAccauntBalance.Size = new System.Drawing.Size(1116, 282);
            this.dgvAccauntBalance.TabIndex = 23;
            // 
            // BalanceGroup
            // 
            this.BalanceGroup.HeaderText = "Group";
            this.BalanceGroup.Name = "BalanceGroup";
            this.BalanceGroup.ReadOnly = true;
            this.BalanceGroup.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.BalanceGroup.Width = 116;
            // 
            // AccountCount
            // 
            this.AccountCount.HeaderText = "Acc";
            this.AccountCount.Name = "AccountCount";
            this.AccountCount.ReadOnly = true;
            this.AccountCount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.AccountCount.Width = 93;
            // 
            // accPrc
            // 
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.accPrc.DefaultCellStyle = dataGridViewCellStyle1;
            this.accPrc.HeaderText = "Acc, %";
            this.accPrc.Name = "accPrc";
            this.accPrc.ReadOnly = true;
            this.accPrc.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.accPrc.Width = 124;
            // 
            // Balance
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N6";
            dataGridViewCellStyle2.NullValue = null;
            this.Balance.DefaultCellStyle = dataGridViewCellStyle2;
            this.Balance.HeaderText = "EOS";
            this.Balance.MinimumWidth = 120;
            this.Balance.Name = "Balance";
            this.Balance.ReadOnly = true;
            this.Balance.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Balance.Width = 120;
            // 
            // prc
            // 
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.prc.DefaultCellStyle = dataGridViewCellStyle3;
            this.prc.HeaderText = "EOS,% ";
            this.prc.Name = "prc";
            this.prc.ReadOnly = true;
            this.prc.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.prc.Width = 132;
            // 
            // avdacc
            // 
            dataGridViewCellStyle4.Format = "N6";
            dataGridViewCellStyle4.NullValue = null;
            this.avdacc.DefaultCellStyle = dataGridViewCellStyle4;
            this.avdacc.HeaderText = "EOS/Acc";
            this.avdacc.Name = "avdacc";
            this.avdacc.ReadOnly = true;
            this.avdacc.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.avdacc.Width = 143;
            // 
            // AirAcc
            // 
            this.AirAcc.HeaderText = "AirAcc";
            this.AirAcc.Name = "AirAcc";
            this.AirAcc.Width = 119;
            // 
            // AirdropSum
            // 
            this.AirdropSum.HeaderText = "Airdrop";
            this.AirdropSum.Name = "AirdropSum";
            this.AirdropSum.Width = 126;
            // 
            // AirdropAcc
            // 
            this.AirdropAcc.HeaderText = "Airdrop/Acc";
            this.AirdropAcc.Name = "AirdropAcc";
            this.AirdropAcc.Width = 168;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Max balance:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sum balance:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSumBalanse
            // 
            this.lblSumBalanse.Location = new System.Drawing.Point(147, 27);
            this.lblSumBalanse.Name = "lblSumBalanse";
            this.lblSumBalanse.Size = new System.Drawing.Size(281, 25);
            this.lblSumBalanse.TabIndex = 1;
            this.lblSumBalanse.Text = "XXXXXXXXXX.XXXX EOS";
            this.lblSumBalanse.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMaxBalance
            // 
            this.lblMaxBalance.Location = new System.Drawing.Point(147, 52);
            this.lblMaxBalance.Name = "lblMaxBalance";
            this.lblMaxBalance.Size = new System.Drawing.Size(281, 25);
            this.lblMaxBalance.TabIndex = 0;
            this.lblMaxBalance.Text = "XXXXXXXXXX.XXXX EOS";
            this.lblMaxBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.tbAirdropTokenCount);
            this.groupBox4.Controls.Add(this.btnSaveSetting);
            this.groupBox4.Controls.Add(this.lblFilteredAccCount);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.tbFilterBalanceTo);
            this.groupBox4.Controls.Add(this.tbFilterBalanceFrom);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Location = new System.Drawing.Point(12, 556);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1146, 201);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Settings";
            // 
            // tbAirdropTokenCount
            // 
            this.tbAirdropTokenCount.Location = new System.Drawing.Point(17, 71);
            this.tbAirdropTokenCount.Name = "tbAirdropTokenCount";
            this.tbAirdropTokenCount.Size = new System.Drawing.Size(278, 31);
            this.tbAirdropTokenCount.TabIndex = 25;
            // 
            // btnSaveSetting
            // 
            this.btnSaveSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveSetting.Location = new System.Drawing.Point(991, 24);
            this.btnSaveSetting.Name = "btnSaveSetting";
            this.btnSaveSetting.Size = new System.Drawing.Size(142, 78);
            this.btnSaveSetting.TabIndex = 24;
            this.btnSaveSetting.Text = "Save";
            this.btnSaveSetting.UseVisualStyleBackColor = true;
            this.btnSaveSetting.Click += new System.EventHandler(this.SaveSettings);
            // 
            // lblFilteredAccCount
            // 
            this.lblFilteredAccCount.AutoSize = true;
            this.lblFilteredAccCount.Location = new System.Drawing.Point(242, 113);
            this.lblFilteredAccCount.Name = "lblFilteredAccCount";
            this.lblFilteredAccCount.Size = new System.Drawing.Size(70, 25);
            this.lblFilteredAccCount.TabIndex = 4;
            this.lblFilteredAccCount.Text = "label6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(224, 25);
            this.label5.TabIndex = 3;
            this.label5.Text = "Airdrop to (acc count):";
            // 
            // tbFilterBalanceTo
            // 
            this.tbFilterBalanceTo.Location = new System.Drawing.Point(424, 24);
            this.tbFilterBalanceTo.Name = "tbFilterBalanceTo";
            this.tbFilterBalanceTo.Size = new System.Drawing.Size(100, 31);
            this.tbFilterBalanceTo.TabIndex = 2;
            // 
            // tbFilterBalanceFrom
            // 
            this.tbFilterBalanceFrom.Location = new System.Drawing.Point(301, 24);
            this.tbFilterBalanceFrom.Name = "tbFilterBalanceFrom";
            this.tbFilterBalanceFrom.Size = new System.Drawing.Size(100, 31);
            this.tbFilterBalanceFrom.TabIndex = 1;
            this.tbFilterBalanceFrom.Text = "0.01";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(229, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Balance filter (from/to):";
            // 
            // btnAbiToModel
            // 
            this.btnAbiToModel.Location = new System.Drawing.Point(987, 23);
            this.btnAbiToModel.Name = "btnAbiToModel";
            this.btnAbiToModel.Size = new System.Drawing.Size(171, 69);
            this.btnAbiToModel.TabIndex = 4;
            this.btnAbiToModel.Text = "AbiToModel generate";
            this.btnAbiToModel.UseVisualStyleBackColor = true;
            this.btnAbiToModel.Click += new System.EventHandler(this.GenerateModelFromAbi);
            // 
            // btnGetAccounts
            // 
            this.btnGetAccounts.Location = new System.Drawing.Point(987, 98);
            this.btnGetAccounts.Name = "btnGetAccounts";
            this.btnGetAccounts.Size = new System.Drawing.Size(171, 69);
            this.btnGetAccounts.TabIndex = 5;
            this.btnGetAccounts.Text = "Testnet getAccounts";
            this.btnGetAccounts.UseVisualStyleBackColor = true;
            this.btnGetAccounts.Click += new System.EventHandler(this.btnGetAccounts_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 1125);
            this.Controls.Add(this.btnGetAccounts);
            this.Controls.Add(this.btnAbiToModel);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Home";
            this.Text = "Airdrop Manager";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccauntBalance)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoadDump;
        private System.Windows.Forms.Label lbldumpAccountCount;
        private System.Windows.Forms.TextBox tbPathToDump;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnStartTask;
        private System.Windows.Forms.Label lblTaskFinished;
        private System.Windows.Forms.Label lblTaskCount;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblMaxBalance;
        private System.Windows.Forms.Label lblSumBalanse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvAccauntBalance;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblFilteredAccCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbFilterBalanceTo;
        private System.Windows.Forms.TextBox tbFilterBalanceFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSaveSetting;
        private System.Windows.Forms.TextBox tbAirdropTokenCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn BalanceGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn accPrc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn prc;
        private System.Windows.Forms.DataGridViewTextBoxColumn avdacc;
        private System.Windows.Forms.DataGridViewTextBoxColumn AirAcc;
        private System.Windows.Forms.DataGridViewTextBoxColumn AirdropSum;
        private System.Windows.Forms.DataGridViewTextBoxColumn AirdropAcc;
        private System.Windows.Forms.Label lblMinBalance;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnAbiToModel;
        private System.Windows.Forms.Label lblTaskErrorCount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblTaskSkipedCount;
        private System.Windows.Forms.Button btnTaskStop;
        private System.Windows.Forms.Button btnGetAccounts;
    }
}

