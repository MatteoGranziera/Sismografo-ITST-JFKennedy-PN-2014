using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections.ObjectModel;

namespace Sismolib
{
    
    public partial class Monitor : Form
    {
        public delegate void SetLabel();
        public SetLabel SetLabelCallback;

        public List<Thread> ConverterProcesses = new List<Thread>();

        public Monitor()
        {
            InitializeComponent();
            SetLabelCallback = new SetLabel(SetLabelCall);
        }

        private void SetLabelCall()
        {
            lblNumThread.Text = ConverterProcesses.Count.ToString();
        }


        private void Monitor_Load(object sender, EventArgs e)
        {
            bkwUpdate.RunWorkerAsync();
        }

        private void bkwUpdate_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                Thread.Sleep(10);
                int num = ConverterProcesses.Count;
                for (int i = 0; i < num; i++)
                {
                    if (ConverterProcesses[0].IsAlive == false)
                    {
                        ConverterProcesses.Remove(ConverterProcesses[0]);
                    }
                }
                //this.Invoke(SetLabelCallback, null);
            }
        }

    }
}
