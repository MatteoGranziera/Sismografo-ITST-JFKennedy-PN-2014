namespace Sismolib
{
    partial class Config
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbpAcquisition = new System.Windows.Forms.TabPage();
            this.btnLastConfig = new System.Windows.Forms.Button();
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.lblDeviceZ = new System.Windows.Forms.Label();
            this.cmbChannelNameZ = new System.Windows.Forms.ComboBox();
            this.lblDeviceY = new System.Windows.Forms.Label();
            this.cmbChannelNameY = new System.Windows.Forms.ComboBox();
            this.lblDeviceX = new System.Windows.Forms.Label();
            this.lblNameChannel = new System.Windows.Forms.Label();
            this.cmbChannelNameX = new System.Windows.Forms.ComboBox();
            this.nudSampleXChannel = new System.Windows.Forms.NumericUpDown();
            this.lblSampleXChannel = new System.Windows.Forms.Label();
            this.lblRate = new System.Windows.Forms.Label();
            this.nudRate = new System.Windows.Forms.NumericUpDown();
            this.btnUpdateDevices = new System.Windows.Forms.Button();
            this.tbpDatabase = new System.Windows.Forms.TabPage();
            this.btnLastDBConfig = new System.Windows.Forms.Button();
            this.grbDatabaseConfig = new System.Windows.Forms.GroupBox();
            this.flpSpecific = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlSpecMySQL = new System.Windows.Forms.Panel();
            this.ckbPooling = new System.Windows.Forms.CheckBox();
            this.pnlSpecSQLServer = new System.Windows.Forms.Panel();
            this.nudTimeout = new System.Windows.Forms.NumericUpDown();
            this.lblTimeout = new System.Windows.Forms.Label();
            this.ckbTrustedConnection = new System.Windows.Forms.CheckBox();
            this.btnTestConnectionDB = new System.Windows.Forms.Button();
            this.lblSpecificConfig = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblUserID = new System.Windows.Forms.Label();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.grbDatabaseType = new System.Windows.Forms.GroupBox();
            this.rdbSQLServer = new System.Windows.Forms.RadioButton();
            this.rdbMySQL = new System.Windows.Forms.RadioButton();
            this.lblDatabaseName = new System.Windows.Forms.Label();
            this.txtDatabaseName = new System.Windows.Forms.TextBox();
            this.lblServerAddress = new System.Windows.Forms.Label();
            this.txtServerAddress = new System.Windows.Forms.TextBox();
            this.btnSaveDBConfig = new System.Windows.Forms.Button();
            this.ckbDBConnection = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.ckbNotifyIcon = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tbpAcquisition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSampleXChannel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRate)).BeginInit();
            this.tbpDatabase.SuspendLayout();
            this.grbDatabaseConfig.SuspendLayout();
            this.flpSpecific.SuspendLayout();
            this.pnlSpecMySQL.SuspendLayout();
            this.pnlSpecSQLServer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeout)).BeginInit();
            this.grbDatabaseType.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tbpAcquisition);
            this.tabControl1.Controls.Add(this.tbpDatabase);
            this.tabControl1.Controls.Add(this.tbpGeneral);
            this.tabControl1.Location = new System.Drawing.Point(12, 34);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(515, 556);
            this.tabControl1.TabIndex = 0;
            // 
            // tbpAcquisition
            // 
            this.tbpAcquisition.Controls.Add(this.btnLastConfig);
            this.tbpAcquisition.Controls.Add(this.btnSaveConfig);
            this.tbpAcquisition.Controls.Add(this.lblDeviceZ);
            this.tbpAcquisition.Controls.Add(this.cmbChannelNameZ);
            this.tbpAcquisition.Controls.Add(this.lblDeviceY);
            this.tbpAcquisition.Controls.Add(this.cmbChannelNameY);
            this.tbpAcquisition.Controls.Add(this.lblDeviceX);
            this.tbpAcquisition.Controls.Add(this.lblNameChannel);
            this.tbpAcquisition.Controls.Add(this.cmbChannelNameX);
            this.tbpAcquisition.Controls.Add(this.nudSampleXChannel);
            this.tbpAcquisition.Controls.Add(this.lblSampleXChannel);
            this.tbpAcquisition.Controls.Add(this.lblRate);
            this.tbpAcquisition.Controls.Add(this.nudRate);
            this.tbpAcquisition.Controls.Add(this.btnUpdateDevices);
            this.tbpAcquisition.Location = new System.Drawing.Point(4, 25);
            this.tbpAcquisition.Name = "tbpAcquisition";
            this.tbpAcquisition.Padding = new System.Windows.Forms.Padding(3);
            this.tbpAcquisition.Size = new System.Drawing.Size(507, 527);
            this.tbpAcquisition.TabIndex = 0;
            this.tbpAcquisition.Text = "Acquisizione Dati";
            this.tbpAcquisition.UseVisualStyleBackColor = true;
            // 
            // btnLastConfig
            // 
            this.btnLastConfig.Location = new System.Drawing.Point(267, 378);
            this.btnLastConfig.Name = "btnLastConfig";
            this.btnLastConfig.Size = new System.Drawing.Size(179, 39);
            this.btnLastConfig.TabIndex = 23;
            this.btnLastConfig.Text = "Ultima Configurazione";
            this.btnLastConfig.UseVisualStyleBackColor = true;
            this.btnLastConfig.Click += new System.EventHandler(this.btnLastConfig_Click);
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Location = new System.Drawing.Point(24, 378);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(179, 39);
            this.btnSaveConfig.TabIndex = 22;
            this.btnSaveConfig.Text = "Salva Configurazione";
            this.btnSaveConfig.UseVisualStyleBackColor = true;
            // 
            // lblDeviceZ
            // 
            this.lblDeviceZ.AutoSize = true;
            this.lblDeviceZ.Location = new System.Drawing.Point(21, 179);
            this.lblDeviceZ.Name = "lblDeviceZ";
            this.lblDeviceZ.Size = new System.Drawing.Size(56, 17);
            this.lblDeviceZ.TabIndex = 21;
            this.lblDeviceZ.Text = "Asse Z:";
            // 
            // cmbChannelNameZ
            // 
            this.cmbChannelNameZ.FormattingEnabled = true;
            this.cmbChannelNameZ.Location = new System.Drawing.Point(265, 178);
            this.cmbChannelNameZ.Name = "cmbChannelNameZ";
            this.cmbChannelNameZ.Size = new System.Drawing.Size(202, 24);
            this.cmbChannelNameZ.TabIndex = 19;
            // 
            // lblDeviceY
            // 
            this.lblDeviceY.AutoSize = true;
            this.lblDeviceY.Location = new System.Drawing.Point(21, 122);
            this.lblDeviceY.Name = "lblDeviceY";
            this.lblDeviceY.Size = new System.Drawing.Size(56, 17);
            this.lblDeviceY.TabIndex = 16;
            this.lblDeviceY.Text = "Asse Y:";
            // 
            // cmbChannelNameY
            // 
            this.cmbChannelNameY.FormattingEnabled = true;
            this.cmbChannelNameY.Location = new System.Drawing.Point(265, 121);
            this.cmbChannelNameY.Name = "cmbChannelNameY";
            this.cmbChannelNameY.Size = new System.Drawing.Size(202, 24);
            this.cmbChannelNameY.TabIndex = 14;
            // 
            // lblDeviceX
            // 
            this.lblDeviceX.AutoSize = true;
            this.lblDeviceX.Location = new System.Drawing.Point(21, 64);
            this.lblDeviceX.Name = "lblDeviceX";
            this.lblDeviceX.Size = new System.Drawing.Size(56, 17);
            this.lblDeviceX.TabIndex = 11;
            this.lblDeviceX.Text = "Asse X:";
            // 
            // lblNameChannel
            // 
            this.lblNameChannel.AutoSize = true;
            this.lblNameChannel.Location = new System.Drawing.Point(262, 33);
            this.lblNameChannel.Name = "lblNameChannel";
            this.lblNameChannel.Size = new System.Drawing.Size(103, 17);
            this.lblNameChannel.TabIndex = 10;
            this.lblNameChannel.Text = "Nome channel:";
            // 
            // cmbChannelNameX
            // 
            this.cmbChannelNameX.FormattingEnabled = true;
            this.cmbChannelNameX.Location = new System.Drawing.Point(265, 63);
            this.cmbChannelNameX.Name = "cmbChannelNameX";
            this.cmbChannelNameX.Size = new System.Drawing.Size(202, 24);
            this.cmbChannelNameX.TabIndex = 9;
            // 
            // nudSampleXChannel
            // 
            this.nudSampleXChannel.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudSampleXChannel.Location = new System.Drawing.Point(267, 323);
            this.nudSampleXChannel.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.nudSampleXChannel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudSampleXChannel.Name = "nudSampleXChannel";
            this.nudSampleXChannel.Size = new System.Drawing.Size(136, 22);
            this.nudSampleXChannel.TabIndex = 8;
            this.nudSampleXChannel.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // lblSampleXChannel
            // 
            this.lblSampleXChannel.AutoSize = true;
            this.lblSampleXChannel.Location = new System.Drawing.Point(21, 323);
            this.lblSampleXChannel.Name = "lblSampleXChannel";
            this.lblSampleXChannel.Size = new System.Drawing.Size(141, 17);
            this.lblSampleXChannel.TabIndex = 7;
            this.lblSampleXChannel.Text = "Campioni per canale:";
            // 
            // lblRate
            // 
            this.lblRate.AutoSize = true;
            this.lblRate.Location = new System.Drawing.Point(18, 274);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(42, 17);
            this.lblRate.TabIndex = 6;
            this.lblRate.Text = "Rate:";
            // 
            // nudRate
            // 
            this.nudRate.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudRate.Location = new System.Drawing.Point(267, 274);
            this.nudRate.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudRate.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudRate.Name = "nudRate";
            this.nudRate.Size = new System.Drawing.Size(136, 22);
            this.nudRate.TabIndex = 5;
            this.nudRate.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // btnUpdateDevices
            // 
            this.btnUpdateDevices.Location = new System.Drawing.Point(265, 219);
            this.btnUpdateDevices.Name = "btnUpdateDevices";
            this.btnUpdateDevices.Size = new System.Drawing.Size(202, 31);
            this.btnUpdateDevices.TabIndex = 2;
            this.btnUpdateDevices.Text = "Aggiorna Devices";
            this.btnUpdateDevices.UseVisualStyleBackColor = true;
            this.btnUpdateDevices.Click += new System.EventHandler(this.btnUpdateDevices_Click);
            // 
            // tbpDatabase
            // 
            this.tbpDatabase.Controls.Add(this.btnLastDBConfig);
            this.tbpDatabase.Controls.Add(this.grbDatabaseConfig);
            this.tbpDatabase.Controls.Add(this.btnSaveDBConfig);
            this.tbpDatabase.Controls.Add(this.ckbDBConnection);
            this.tbpDatabase.Location = new System.Drawing.Point(4, 25);
            this.tbpDatabase.Name = "tbpDatabase";
            this.tbpDatabase.Padding = new System.Windows.Forms.Padding(3);
            this.tbpDatabase.Size = new System.Drawing.Size(507, 527);
            this.tbpDatabase.TabIndex = 1;
            this.tbpDatabase.Text = "Database";
            this.tbpDatabase.UseVisualStyleBackColor = true;
            // 
            // btnLastDBConfig
            // 
            this.btnLastDBConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLastDBConfig.Location = new System.Drawing.Point(271, 481);
            this.btnLastDBConfig.Name = "btnLastDBConfig";
            this.btnLastDBConfig.Size = new System.Drawing.Size(161, 43);
            this.btnLastDBConfig.TabIndex = 14;
            this.btnLastDBConfig.Text = "Ultima Configurazione";
            this.btnLastDBConfig.UseVisualStyleBackColor = true;
            this.btnLastDBConfig.Click += new System.EventHandler(this.btnLastDBConfig_Click);
            // 
            // grbDatabaseConfig
            // 
            this.grbDatabaseConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbDatabaseConfig.Controls.Add(this.flpSpecific);
            this.grbDatabaseConfig.Controls.Add(this.lblSpecificConfig);
            this.grbDatabaseConfig.Controls.Add(this.lblPassword);
            this.grbDatabaseConfig.Controls.Add(this.txtPassword);
            this.grbDatabaseConfig.Controls.Add(this.lblUserID);
            this.grbDatabaseConfig.Controls.Add(this.txtUserID);
            this.grbDatabaseConfig.Controls.Add(this.grbDatabaseType);
            this.grbDatabaseConfig.Controls.Add(this.lblDatabaseName);
            this.grbDatabaseConfig.Controls.Add(this.txtDatabaseName);
            this.grbDatabaseConfig.Controls.Add(this.lblServerAddress);
            this.grbDatabaseConfig.Controls.Add(this.txtServerAddress);
            this.grbDatabaseConfig.Location = new System.Drawing.Point(26, 46);
            this.grbDatabaseConfig.Name = "grbDatabaseConfig";
            this.grbDatabaseConfig.Size = new System.Drawing.Size(462, 410);
            this.grbDatabaseConfig.TabIndex = 10;
            this.grbDatabaseConfig.TabStop = false;
            this.grbDatabaseConfig.Text = "Configurazione Database";
            // 
            // flpSpecific
            // 
            this.flpSpecific.Controls.Add(this.pnlSpecMySQL);
            this.flpSpecific.Controls.Add(this.pnlSpecSQLServer);
            this.flpSpecific.Controls.Add(this.btnTestConnectionDB);
            this.flpSpecific.Location = new System.Drawing.Point(17, 247);
            this.flpSpecific.Name = "flpSpecific";
            this.flpSpecific.Size = new System.Drawing.Size(389, 157);
            this.flpSpecific.TabIndex = 12;
            // 
            // pnlSpecMySQL
            // 
            this.pnlSpecMySQL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSpecMySQL.Controls.Add(this.ckbPooling);
            this.pnlSpecMySQL.Location = new System.Drawing.Point(3, 3);
            this.pnlSpecMySQL.Name = "pnlSpecMySQL";
            this.pnlSpecMySQL.Size = new System.Drawing.Size(360, 49);
            this.pnlSpecMySQL.TabIndex = 0;
            // 
            // ckbPooling
            // 
            this.ckbPooling.AutoSize = true;
            this.ckbPooling.Location = new System.Drawing.Point(10, 12);
            this.ckbPooling.Name = "ckbPooling";
            this.ckbPooling.Size = new System.Drawing.Size(77, 21);
            this.ckbPooling.TabIndex = 0;
            this.ckbPooling.Text = "Pooling";
            this.ckbPooling.UseVisualStyleBackColor = true;
            // 
            // pnlSpecSQLServer
            // 
            this.pnlSpecSQLServer.Controls.Add(this.nudTimeout);
            this.pnlSpecSQLServer.Controls.Add(this.lblTimeout);
            this.pnlSpecSQLServer.Controls.Add(this.ckbTrustedConnection);
            this.pnlSpecSQLServer.Location = new System.Drawing.Point(3, 58);
            this.pnlSpecSQLServer.Name = "pnlSpecSQLServer";
            this.pnlSpecSQLServer.Size = new System.Drawing.Size(360, 76);
            this.pnlSpecSQLServer.TabIndex = 1;
            // 
            // nudTimeout
            // 
            this.nudTimeout.Location = new System.Drawing.Point(205, 38);
            this.nudTimeout.Name = "nudTimeout";
            this.nudTimeout.Size = new System.Drawing.Size(74, 22);
            this.nudTimeout.TabIndex = 2;
            // 
            // lblTimeout
            // 
            this.lblTimeout.AutoSize = true;
            this.lblTimeout.Location = new System.Drawing.Point(202, 18);
            this.lblTimeout.Name = "lblTimeout";
            this.lblTimeout.Size = new System.Drawing.Size(63, 17);
            this.lblTimeout.TabIndex = 1;
            this.lblTimeout.Text = "Timeout:";
            // 
            // ckbTrustedConnection
            // 
            this.ckbTrustedConnection.AutoSize = true;
            this.ckbTrustedConnection.Location = new System.Drawing.Point(10, 38);
            this.ckbTrustedConnection.Name = "ckbTrustedConnection";
            this.ckbTrustedConnection.Size = new System.Drawing.Size(154, 21);
            this.ckbTrustedConnection.TabIndex = 0;
            this.ckbTrustedConnection.Text = "Trusted Connection";
            this.ckbTrustedConnection.UseVisualStyleBackColor = true;
            // 
            // btnTestConnectionDB
            // 
            this.btnTestConnectionDB.Location = new System.Drawing.Point(3, 140);
            this.btnTestConnectionDB.Name = "btnTestConnectionDB";
            this.btnTestConnectionDB.Size = new System.Drawing.Size(146, 35);
            this.btnTestConnectionDB.TabIndex = 10;
            this.btnTestConnectionDB.Text = "Test Connessione";
            this.btnTestConnectionDB.UseVisualStyleBackColor = true;
            // 
            // lblSpecificConfig
            // 
            this.lblSpecificConfig.AutoSize = true;
            this.lblSpecificConfig.Location = new System.Drawing.Point(14, 226);
            this.lblSpecificConfig.Name = "lblSpecificConfig";
            this.lblSpecificConfig.Size = new System.Drawing.Size(201, 17);
            this.lblSpecificConfig.TabIndex = 11;
            this.lblSpecificConfig.Text = "Specifiche per la connessione:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(241, 170);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(73, 17);
            this.lblPassword.TabIndex = 8;
            this.lblPassword.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(244, 190);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(162, 22);
            this.txtPassword.TabIndex = 7;
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Location = new System.Drawing.Point(14, 170);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(93, 17);
            this.lblUserID.TabIndex = 6;
            this.lblUserID.Text = "Nome utente:";
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(17, 190);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(162, 22);
            this.txtUserID.TabIndex = 5;
            // 
            // grbDatabaseType
            // 
            this.grbDatabaseType.Controls.Add(this.rdbSQLServer);
            this.grbDatabaseType.Controls.Add(this.rdbMySQL);
            this.grbDatabaseType.Location = new System.Drawing.Point(244, 33);
            this.grbDatabaseType.Name = "grbDatabaseType";
            this.grbDatabaseType.Size = new System.Drawing.Size(162, 117);
            this.grbDatabaseType.TabIndex = 4;
            this.grbDatabaseType.TabStop = false;
            this.grbDatabaseType.Text = "Tipo di Database";
            // 
            // rdbSQLServer
            // 
            this.rdbSQLServer.AutoSize = true;
            this.rdbSQLServer.Location = new System.Drawing.Point(16, 62);
            this.rdbSQLServer.Name = "rdbSQLServer";
            this.rdbSQLServer.Size = new System.Drawing.Size(127, 38);
            this.rdbSQLServer.TabIndex = 1;
            this.rdbSQLServer.TabStop = true;
            this.rdbSQLServer.Text = "SQL Server\r\n(Testato: 2012)";
            this.rdbSQLServer.UseVisualStyleBackColor = true;
            this.rdbSQLServer.CheckedChanged += new System.EventHandler(this.rdbSQLServer_CheckedChanged);
            // 
            // rdbMySQL
            // 
            this.rdbMySQL.AutoSize = true;
            this.rdbMySQL.Location = new System.Drawing.Point(16, 31);
            this.rdbMySQL.Name = "rdbMySQL";
            this.rdbMySQL.Size = new System.Drawing.Size(75, 21);
            this.rdbMySQL.TabIndex = 0;
            this.rdbMySQL.TabStop = true;
            this.rdbMySQL.Text = "MySQL";
            this.rdbMySQL.UseVisualStyleBackColor = true;
            this.rdbMySQL.CheckedChanged += new System.EventHandler(this.rdbMySQL_CheckedChanged);
            // 
            // lblDatabaseName
            // 
            this.lblDatabaseName.AutoSize = true;
            this.lblDatabaseName.Location = new System.Drawing.Point(14, 92);
            this.lblDatabaseName.Name = "lblDatabaseName";
            this.lblDatabaseName.Size = new System.Drawing.Size(114, 17);
            this.lblDatabaseName.TabIndex = 3;
            this.lblDatabaseName.Text = "Nome Database:";
            // 
            // txtDatabaseName
            // 
            this.txtDatabaseName.Location = new System.Drawing.Point(17, 112);
            this.txtDatabaseName.Name = "txtDatabaseName";
            this.txtDatabaseName.Size = new System.Drawing.Size(162, 22);
            this.txtDatabaseName.TabIndex = 2;
            // 
            // lblServerAddress
            // 
            this.lblServerAddress.AutoSize = true;
            this.lblServerAddress.Location = new System.Drawing.Point(14, 33);
            this.lblServerAddress.Name = "lblServerAddress";
            this.lblServerAddress.Size = new System.Drawing.Size(136, 17);
            this.lblServerAddress.TabIndex = 1;
            this.lblServerAddress.Text = "Indirirzzo del server:";
            // 
            // txtServerAddress
            // 
            this.txtServerAddress.Location = new System.Drawing.Point(17, 53);
            this.txtServerAddress.Name = "txtServerAddress";
            this.txtServerAddress.Size = new System.Drawing.Size(162, 22);
            this.txtServerAddress.TabIndex = 0;
            // 
            // btnSaveDBConfig
            // 
            this.btnSaveDBConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveDBConfig.Location = new System.Drawing.Point(43, 481);
            this.btnSaveDBConfig.Name = "btnSaveDBConfig";
            this.btnSaveDBConfig.Size = new System.Drawing.Size(185, 43);
            this.btnSaveDBConfig.TabIndex = 13;
            this.btnSaveDBConfig.Text = "Salva Configurazione";
            this.btnSaveDBConfig.UseVisualStyleBackColor = true;
            this.btnSaveDBConfig.Click += new System.EventHandler(this.btnSaveDBConfig_Click);
            // 
            // ckbDBConnection
            // 
            this.ckbDBConnection.AutoSize = true;
            this.ckbDBConnection.Location = new System.Drawing.Point(26, 19);
            this.ckbDBConnection.Name = "ckbDBConnection";
            this.ckbDBConnection.Size = new System.Drawing.Size(224, 21);
            this.ckbDBConnection.TabIndex = 9;
            this.ckbDBConnection.Text = "Attiva connessione a database";
            this.ckbDBConnection.UseVisualStyleBackColor = true;
            this.ckbDBConnection.CheckedChanged += new System.EventHandler(this.ckbDBConnection_CheckedChanged);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(344, 596);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(186, 37);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Chiudi";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.ckbNotifyIcon);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 25);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tbpGeneral.Size = new System.Drawing.Size(507, 527);
            this.tbpGeneral.TabIndex = 2;
            this.tbpGeneral.Text = "Generali";
            this.tbpGeneral.UseVisualStyleBackColor = true;
            // 
            // ckbNotifyIcon
            // 
            this.ckbNotifyIcon.AutoSize = true;
            this.ckbNotifyIcon.Location = new System.Drawing.Point(64, 48);
            this.ckbNotifyIcon.Name = "ckbNotifyIcon";
            this.ckbNotifyIcon.Size = new System.Drawing.Size(239, 21);
            this.ckbNotifyIcon.TabIndex = 0;
            this.ckbNotifyIcon.Text = "Attiva icona nella barra di notifica";
            this.ckbNotifyIcon.UseVisualStyleBackColor = true;
            this.ckbNotifyIcon.CheckedChanged += new System.EventHandler(this.ckbNotifyIcon_CheckedChanged);
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 645);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabControl1);
            this.Name = "Config";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurazione Sismolib";
            this.Activated += new System.EventHandler(this.Config_Activated);
            this.Load += new System.EventHandler(this.Config_Load);
            this.tabControl1.ResumeLayout(false);
            this.tbpAcquisition.ResumeLayout(false);
            this.tbpAcquisition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSampleXChannel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRate)).EndInit();
            this.tbpDatabase.ResumeLayout(false);
            this.tbpDatabase.PerformLayout();
            this.grbDatabaseConfig.ResumeLayout(false);
            this.grbDatabaseConfig.PerformLayout();
            this.flpSpecific.ResumeLayout(false);
            this.pnlSpecMySQL.ResumeLayout(false);
            this.pnlSpecMySQL.PerformLayout();
            this.pnlSpecSQLServer.ResumeLayout(false);
            this.pnlSpecSQLServer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeout)).EndInit();
            this.grbDatabaseType.ResumeLayout(false);
            this.grbDatabaseType.PerformLayout();
            this.tbpGeneral.ResumeLayout(false);
            this.tbpGeneral.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbpAcquisition;
        private System.Windows.Forms.TabPage tbpDatabase;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnUpdateDevices;
        private System.Windows.Forms.NumericUpDown nudSampleXChannel;
        private System.Windows.Forms.Label lblSampleXChannel;
        private System.Windows.Forms.Label lblRate;
        private System.Windows.Forms.NumericUpDown nudRate;
        private System.Windows.Forms.Label lblNameChannel;
        private System.Windows.Forms.ComboBox cmbChannelNameX;
        private System.Windows.Forms.Label lblDeviceZ;
        private System.Windows.Forms.ComboBox cmbChannelNameZ;
        private System.Windows.Forms.Label lblDeviceY;
        private System.Windows.Forms.ComboBox cmbChannelNameY;
        private System.Windows.Forms.Label lblDeviceX;
        private System.Windows.Forms.GroupBox grbDatabaseConfig;
        private System.Windows.Forms.Label lblSpecificConfig;
        private System.Windows.Forms.Button btnTestConnectionDB;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.GroupBox grbDatabaseType;
        private System.Windows.Forms.RadioButton rdbSQLServer;
        private System.Windows.Forms.RadioButton rdbMySQL;
        private System.Windows.Forms.Label lblDatabaseName;
        private System.Windows.Forms.TextBox txtDatabaseName;
        private System.Windows.Forms.Label lblServerAddress;
        private System.Windows.Forms.TextBox txtServerAddress;
        private System.Windows.Forms.CheckBox ckbDBConnection;
        private System.Windows.Forms.FlowLayoutPanel flpSpecific;
        private System.Windows.Forms.Panel pnlSpecMySQL;
        private System.Windows.Forms.CheckBox ckbPooling;
        private System.Windows.Forms.Panel pnlSpecSQLServer;
        private System.Windows.Forms.NumericUpDown nudTimeout;
        private System.Windows.Forms.Label lblTimeout;
        private System.Windows.Forms.CheckBox ckbTrustedConnection;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnSaveDBConfig;
        private System.Windows.Forms.Button btnLastDBConfig;
        private System.Windows.Forms.Button btnLastConfig;
        private System.Windows.Forms.Button btnSaveConfig;
        private System.Windows.Forms.TabPage tbpGeneral;
        private System.Windows.Forms.CheckBox ckbNotifyIcon;
    }
}