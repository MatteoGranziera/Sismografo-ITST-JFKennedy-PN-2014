namespace Sismolib
{
     partial class Monitor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private  System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected  override void Dispose(bool disposing)
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
            this.lblNumThread = new System.Windows.Forms.Label();
            this.bkwUpdate = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // lblNumThread
            // 
            this.lblNumThread.AutoSize = true;
            this.lblNumThread.Location = new System.Drawing.Point(12, 9);
            this.lblNumThread.Name = "lblNumThread";
            this.lblNumThread.Size = new System.Drawing.Size(46, 17);
            this.lblNumThread.TabIndex = 0;
            this.lblNumThread.Text = "label1";
            // 
            // bkwUpdate
            // 
            this.bkwUpdate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bkwUpdate_DoWork);
            // 
            // Monitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 176);
            this.Controls.Add(this.lblNumThread);
            this.Name = "Monitor";
            this.Text = "Monitor";
            this.Load += new System.EventHandler(this.Monitor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNumThread;
        private System.ComponentModel.BackgroundWorker bkwUpdate;
    }
}