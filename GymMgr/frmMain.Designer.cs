namespace GymMgr
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblConnected = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLastLogin = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.logintoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cardReaderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBoxConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.baudToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbBaud = new System.Windows.Forms.ToolStripComboBox();
            this.portToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbPort = new System.Windows.Forms.ToolStripComboBox();
            this.tsmConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnObligors = new System.Windows.Forms.Button();
            this.btnSet = new System.Windows.Forms.Button();
            this.btnSubs = new System.Windows.Forms.Button();
            this.btnProgram = new System.Windows.Forms.Button();
            this.btnClients = new System.Windows.Forms.Button();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.restoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblConnected,
            this.toolStripStatusLabel1,
            this.lblLastLogin});
            this.statusStrip1.Location = new System.Drawing.Point(0, 557);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(896, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblConnected
            // 
            this.lblConnected.Image = global::GymMgr.Properties.Resources.link;
            this.lblConnected.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblConnected.Name = "lblConnected";
            this.lblConnected.Size = new System.Drawing.Size(134, 17);
            this.lblConnected.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(43, 17);
            this.toolStripStatusLabel1.Text = "            ";
            // 
            // lblLastLogin
            // 
            this.lblLastLogin.Name = "lblLastLogin";
            this.lblLastLogin.Size = new System.Drawing.Size(0, 17);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(896, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator,
            this.logintoolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(103, 6);
            // 
            // logintoolStripMenuItem
            // 
            this.logintoolStripMenuItem.Image = global::GymMgr.Properties.Resources.door_in;
            this.logintoolStripMenuItem.Name = "logintoolStripMenuItem";
            this.logintoolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.logintoolStripMenuItem.Text = "כניסה";
            this.logintoolStripMenuItem.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Image = global::GymMgr.Properties.Resources.door_out;
            this.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.printPreviewToolStripMenuItem.Text = "יציאה";
            this.printPreviewToolStripMenuItem.Click += new System.EventHandler(this.printPreviewToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(103, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.exitToolStripMenuItem.Text = "סגור";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cardReaderToolStripMenuItem,
            this.usersToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // cardReaderToolStripMenuItem
            // 
            this.cardReaderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkBoxConnect,
            this.baudToolStripMenuItem,
            this.portToolStripMenuItem,
            this.tsmConnect});
            this.cardReaderToolStripMenuItem.Image = global::GymMgr.Properties.Resources.cog;
            this.cardReaderToolStripMenuItem.Name = "cardReaderToolStripMenuItem";
            this.cardReaderToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.cardReaderToolStripMenuItem.Text = "Card Reader";
            // 
            // checkBoxConnect
            // 
            this.checkBoxConnect.Checked = true;
            this.checkBoxConnect.CheckOnClick = true;
            this.checkBoxConnect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxConnect.Name = "checkBoxConnect";
            this.checkBoxConnect.Size = new System.Drawing.Size(163, 22);
            this.checkBoxConnect.Text = "Connect on Start";
            this.checkBoxConnect.Click += new System.EventHandler(this.checkBoxConnect_Click);
            // 
            // baudToolStripMenuItem
            // 
            this.baudToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbBaud});
            this.baudToolStripMenuItem.Name = "baudToolStripMenuItem";
            this.baudToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.baudToolStripMenuItem.Text = "BaudRate";
            // 
            // cbBaud
            // 
            this.cbBaud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBaud.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbBaud.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cbBaud.Name = "cbBaud";
            this.cbBaud.Size = new System.Drawing.Size(121, 23);
            this.cbBaud.SelectedIndexChanged += new System.EventHandler(this.cbBaud_SelectedIndexChanged);
            // 
            // portToolStripMenuItem
            // 
            this.portToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbPort});
            this.portToolStripMenuItem.Name = "portToolStripMenuItem";
            this.portToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.portToolStripMenuItem.Text = "Port";
            // 
            // cbPort
            // 
            this.cbPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPort.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbPort.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbPort.Name = "cbPort";
            this.cbPort.Size = new System.Drawing.Size(121, 23);
            this.cbPort.SelectedIndexChanged += new System.EventHandler(this.cbPort_SelectedIndexChanged);
            // 
            // tsmConnect
            // 
            this.tsmConnect.Name = "tsmConnect";
            this.tsmConnect.Size = new System.Drawing.Size(163, 22);
            this.tsmConnect.Text = "Connect";
            this.tsmConnect.Click += new System.EventHandler(this.tsmConnect_Click);
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Image = global::GymMgr.Properties.Resources.user_edit;
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.usersToolStripMenuItem.Text = "Users";
            this.usersToolStripMenuItem.Visible = false;
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnObligors);
            this.splitContainer1.Panel1.Controls.Add(this.btnSet);
            this.splitContainer1.Panel1.Controls.Add(this.btnSubs);
            this.splitContainer1.Panel1.Controls.Add(this.btnProgram);
            this.splitContainer1.Panel1.Controls.Add(this.btnClients);
            this.splitContainer1.Panel1.Enabled = false;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackgroundImage = global::GymMgr.Properties.Resources.gym;
            this.splitContainer1.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.splitContainer1.Panel2.Controls.Add(this.btnLogIn);
            this.splitContainer1.Size = new System.Drawing.Size(896, 533);
            this.splitContainer1.SplitterDistance = 101;
            this.splitContainer1.TabIndex = 2;
            // 
            // btnObligors
            // 
            this.btnObligors.Image = global::GymMgr.Properties.Resources.money;
            this.btnObligors.Location = new System.Drawing.Point(3, 183);
            this.btnObligors.Name = "btnObligors";
            this.btnObligors.Size = new System.Drawing.Size(95, 54);
            this.btnObligors.TabIndex = 5;
            this.btnObligors.Text = "דו\'\'ח חייבים";
            this.btnObligors.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnObligors.UseVisualStyleBackColor = true;
            this.btnObligors.Visible = false;
            this.btnObligors.Click += new System.EventHandler(this.btnObligors_Click);
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(3, 123);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(95, 54);
            this.btnSet.TabIndex = 4;
            this.btnSet.Text = "תרגילים";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // btnSubs
            // 
            this.btnSubs.Location = new System.Drawing.Point(3, 464);
            this.btnSubs.Name = "btnSubs";
            this.btnSubs.Size = new System.Drawing.Size(95, 54);
            this.btnSubs.TabIndex = 2;
            this.btnSubs.Text = "מנויים";
            this.btnSubs.UseVisualStyleBackColor = true;
            this.btnSubs.Visible = false;
            this.btnSubs.Click += new System.EventHandler(this.btnSubs_Click);
            // 
            // btnProgram
            // 
            this.btnProgram.Location = new System.Drawing.Point(3, 63);
            this.btnProgram.Name = "btnProgram";
            this.btnProgram.Size = new System.Drawing.Size(95, 54);
            this.btnProgram.TabIndex = 3;
            this.btnProgram.Text = "אימונים";
            this.btnProgram.UseVisualStyleBackColor = true;
            this.btnProgram.Click += new System.EventHandler(this.btnProgram_Click);
            // 
            // btnClients
            // 
            this.btnClients.Image = global::GymMgr.Properties.Resources.folder_user;
            this.btnClients.Location = new System.Drawing.Point(3, 3);
            this.btnClients.Name = "btnClients";
            this.btnClients.Size = new System.Drawing.Size(95, 54);
            this.btnClients.TabIndex = 0;
            this.btnClients.Text = "ניהול לקוחות";
            this.btnClients.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnClients.UseVisualStyleBackColor = true;
            this.btnClients.Click += new System.EventHandler(this.btnClients_Click);
            // 
            // btnLogIn
            // 
            this.btnLogIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLogIn.Image = global::GymMgr.Properties.Resources.door_in;
            this.btnLogIn.Location = new System.Drawing.Point(667, 3);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(121, 87);
            this.btnLogIn.TabIndex = 0;
            this.btnLogIn.Text = "כניסה";
            this.btnLogIn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLogIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLogIn.UseVisualStyleBackColor = true;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restoreToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(114, 48);
            // 
            // restoreToolStripMenuItem
            // 
            this.restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
            this.restoreToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.restoreToolStripMenuItem.Text = "Restore";
            this.restoreToolStripMenuItem.Click += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(113, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // frmMain
            // 
            this.ClientSize = new System.Drawing.Size(896, 579);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnSubs;
        private System.Windows.Forms.Button btnProgram;
        private System.Windows.Forms.Button btnClients;
        private System.Windows.Forms.Button btnSet;
     
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem restoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel lblConnected;
        private System.Windows.Forms.ToolStripMenuItem cardReaderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem baudToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox cbBaud;
        private System.Windows.Forms.ToolStripMenuItem portToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox cbPort;
        private System.Windows.Forms.ToolStripMenuItem checkBoxConnect;
        private System.Windows.Forms.ToolStripMenuItem tsmConnect;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.ToolStripMenuItem logintoolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblLastLogin;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.Button btnObligors;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
   
     //   private WControls.WNotifyIcon wNotifyIcon1;

     
    }
}