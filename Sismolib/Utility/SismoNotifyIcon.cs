using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Sismolib
{
    public static class SismoNotifyIcon
    {
        private static System.Windows.Forms.NotifyIcon SismonNotifyIcon;
        private static System.Windows.Forms.ContextMenu SismoContextMenu;

        private static System.Windows.Forms.MenuItem SismoMIConfiguration;
        private static System.Windows.Forms.MenuItem SismoMIClose;

        private static System.ComponentModel.IContainer components;

        public static void CreateNotifyicon()
        {
            components = new System.ComponentModel.Container();
            SismoContextMenu = new System.Windows.Forms.ContextMenu();
            SismoMIClose = new System.Windows.Forms.MenuItem();
            SismoMIConfiguration = new System.Windows.Forms.MenuItem();

            SismoMIConfiguration.Index = 0;
            SismoMIConfiguration.Text = "Configurazione";
            SismoMIConfiguration.Click += new System.EventHandler(SismoMIConfiguration_Click);

            SismoMIClose.Index = 1;
            SismoMIClose.Text = "Chiudi";
            SismoMIClose.Click += new System.EventHandler(SismoMIClose_Click);

            SismoContextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { SismoMIConfiguration, SismoMIClose });

            SismonNotifyIcon = new System.Windows.Forms.NotifyIcon(components);

            SismonNotifyIcon.Icon = new Icon(AppDomain.CurrentDomain.BaseDirectory+"/icon.ico");

            SismonNotifyIcon.ContextMenu = SismoContextMenu;

            SismonNotifyIcon.Text = "Sismolib Attiva";

            SismonNotifyIcon.Visible = Properties.Settings.Default.NotificationIcon;

            SismonNotifyIcon.Click += new System.EventHandler(SismonNotifyIcon_Click);

        }

        public static void Hide()
        {
            SismonNotifyIcon.Visible = false;
        }

        public static void Show()
        {
            SismonNotifyIcon.Visible = true;
        }

        private static void SismoMIConfiguration_Click(object sender, EventArgs e)
        {
                Config frm = new Config();
                frm.Show();
        }

        private static void SismoMIClose_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Sicuro di voler chiudere l'applicazione?\r\nAttenzione: Tutti i processi termineranno!", "Conferma chiusura",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private static void SismonNotifyIcon_Click(object sender, EventArgs e)
        {

        }
       
    }
}
