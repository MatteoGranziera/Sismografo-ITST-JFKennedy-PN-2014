namespace Sismolib
{
    partial class frmLoading
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
            this.prbLoading = new System.Windows.Forms.ProgressBar();
            this.lblLoadingState = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // prbLoading
            // 
            this.prbLoading.Location = new System.Drawing.Point(13, 13);
            this.prbLoading.Name = "prbLoading";
            this.prbLoading.Size = new System.Drawing.Size(694, 40);
            this.prbLoading.TabIndex = 0;
            // 
            // lblLoadingState
            // 
            this.lblLoadingState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLoadingState.AutoSize = true;
            this.lblLoadingState.Location = new System.Drawing.Point(10, 59);
            this.lblLoadingState.Name = "lblLoadingState";
            this.lblLoadingState.Size = new System.Drawing.Size(54, 17);
            this.lblLoadingState.TabIndex = 1;
            this.lblLoadingState.Text = "Avvio...";
            // 
            // frmLoading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 85);
            this.Controls.Add(this.lblLoadingState);
            this.Controls.Add(this.prbLoading);
            this.Name = "frmLoading";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Avvio";
            this.Load += new System.EventHandler(this.frmLoading_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar prbLoading;
        private System.Windows.Forms.Label lblLoadingState;
    }
}