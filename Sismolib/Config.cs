using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NationalInstruments;
using NationalInstruments.DAQmx;

namespace Sismolib
{

    public partial class Config : Form
    {
        private bool start;
        public Config()
        {
            Form exist = null;
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Name == "Config")
                    exist = frm;
            }

            if (exist != null)
            {
                start = false;
            }
            else
            {
                start = true;
            }
            InitializeComponent();

        }

        private void DeviceUpdate()
        {
            string[] channels = DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.AI, PhysicalChannelAccess.All);
            cmbChannelNameX.Items.AddRange(channels);
            cmbChannelNameY.Items.AddRange(channels);
            cmbChannelNameZ.Items.AddRange(channels);
            
        }

        private void btnUpdateDevices_Click(object sender, EventArgs e)
        {
            DeviceUpdate();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoadDefaultSettings()
        { 
            string text = Properties.Settings.Default.ChannelNameX;
            cmbChannelNameX.Text = text;

            text = Properties.Settings.Default.ChannelNameY;
            cmbChannelNameY.Text = text;

            text = Properties.Settings.Default.ChannelNameZ;
            cmbChannelNameZ.Text = text;

            nudRate.Value = Properties.Settings.Default.Rate;
            nudSampleXChannel.Value = Properties.Settings.Default.SampleXChannel;
        }

        private void LoadDefaultDBSettings()
        {
            txtServerAddress.Text = Properties.Settings.Default.DBServerAddress;
            txtDatabaseName.Text = Properties.Settings.Default.DBName;
            txtUserID.Text = Properties.Settings.Default.DBUserID;
            txtPassword.Text = Properties.Settings.Default.DBPassword;

            ckbDBConnection.Checked = Properties.Settings.Default.DBConnectionEnabled;
            grbDatabaseConfig.Enabled = Properties.Settings.Default.DBConnectionEnabled;

            ckbPooling.Checked = Properties.Settings.Default.DBPooling;
            ckbTrustedConnection.Checked = Properties.Settings.Default.DBTrustedConnection;
            nudTimeout.Value = Convert.ToInt32(Properties.Settings.Default.DBTimeout);

            switch (Properties.Settings.Default.DBType)
            {
                case (int)SismoDBC.SismoDBType.mySQL:
                    {
                        rdbMySQL.Checked = true;
                    }break;
                case (int)SismoDBC.SismoDBType.SQLServer: 
                    {
                        rdbSQLServer.Checked = true;
                    }break;
            }

        }

        private void LoadGeneralSettings()
        {
            ckbNotifyIcon.Checked = Properties.Settings.Default.NotificationIcon;
        }

        private void SaveDefaultDBSettigs()
        {
            Properties.Settings.Default.DBConnectionEnabled = ckbDBConnection.Checked;

            if (ckbDBConnection.Checked)
            {
                Properties.Settings.Default.DBServerAddress = txtServerAddress.Text;
                Properties.Settings.Default.DBName = txtDatabaseName.Text;
                Properties.Settings.Default.DBUserID = txtUserID.Text;
                Properties.Settings.Default.DBPassword = txtPassword.Text;

                if (rdbMySQL.Checked)
                {
                    Properties.Settings.Default.DBType = (int)SismoDBC.SismoDBType.mySQL;
                }
                else if (rdbSQLServer.Checked)
                {
                    Properties.Settings.Default.DBType = (int)SismoDBC.SismoDBType.SQLServer;
                }

            }

            Properties.Settings.Default.Save();
        }

        private void Config_Load(object sender, EventArgs e)
        {
            if (!start)
            {
                this.Close();
            }
            else
            {
                LoadDefaultSettings();
                LoadDefaultDBSettings();
            }
        }

        private void ckbDBConnection_CheckedChanged(object sender, EventArgs e)
        {
            grbDatabaseConfig.Enabled = ckbDBConnection.Checked;
        }

        private void ChangeDBType()
        {
            pnlSpecMySQL.Visible = rdbMySQL.Checked;
            pnlSpecSQLServer.Visible = rdbSQLServer.Checked;
        }

        private void rdbMySQL_CheckedChanged(object sender, EventArgs e)
        {
            ChangeDBType();
        }

        private void rdbSQLServer_CheckedChanged(object sender, EventArgs e)
        {
            ChangeDBType();
        }

        private void btnSaveDBConfig_Click(object sender, EventArgs e)
        {
            SaveDefaultDBSettigs();
        }

        private void btnLastDBConfig_Click(object sender, EventArgs e)
        {
            LoadDefaultDBSettings();
        }

        private void btnLastConfig_Click(object sender, EventArgs e)
        {
            SismoNotifyIcon.CreateNotifyicon();
        }

        private void ckbNotifyIcon_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Config_Activated(object sender, EventArgs e)
        {
            if (!start)
            {
                this.Close();
            }
        }

    }
}
