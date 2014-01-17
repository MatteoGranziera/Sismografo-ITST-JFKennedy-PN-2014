using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sismolib
{
    public partial class frmLoading : Form
    {
        public delegate void SetValueCallback(string text);
        public SetValueCallback ValueCallback;

        public delegate void CloseCallback();
        public CloseCallback CloseFrmCallback;

        public int numOfStat;
        private int dimStat;

        public frmLoading(int numStat)
        {
            InitializeComponent();

            prbLoading.Minimum = 0;
            prbLoading.Maximum = 100;
            numOfStat = numStat;
            dimStat = prbLoading.Maximum/numStat;
            prbLoading.Value = prbLoading.Minimum;

            ValueCallback = new SetValueCallback(SetValueCall);
            CloseFrmCallback = new CloseCallback(CloseFrmCall);
        }

        public void SetValue(string text)
        {
            this.Invoke(ValueCallback, new object[] { text }); 
        }

        private void SetValueCall(string text)
        {
            prbLoading.Value += dimStat;
            lblLoadingState.Text = text;
        }

        public void CloseFrm()
        {
            this.Invoke(CloseFrmCallback, null);
        }

        private void CloseFrmCall()
        {
            Close();
        }

        private void frmLoading_Load(object sender, EventArgs e)
        {

        }

    }
}
