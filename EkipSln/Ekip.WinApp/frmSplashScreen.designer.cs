namespace Ekip.WinApp
{
    partial class frmSplashScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSplashScreen));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl1.Location = new System.Drawing.Point(49, 264);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(133, 15);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "Copyright 2012-2013";
            // 
            // progressBarControl1
            // 
            this.progressBarControl1.EditValue = "50";
            this.progressBarControl1.Location = new System.Drawing.Point(49, 160);
            this.progressBarControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progressBarControl1.Name = "progressBarControl1";
            this.progressBarControl1.Properties.LookAndFeel.SkinName = "Whiteprint";
            this.progressBarControl1.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.progressBarControl1.Size = new System.Drawing.Size(356, 20);
            this.progressBarControl1.TabIndex = 10;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(170, 124);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(141, 28);
            this.labelControl4.TabIndex = 25;
            this.labelControl4.Text = "Yükleniyor ...";
            // 
            // frmSplashScreen
            // 
            this.AllowControlsInImageMode = true;
            this.AutoFitImage = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(633, 311);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.progressBarControl1);
            this.Controls.Add(this.labelControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmSplashScreen";
            this.ShowMode = DevExpress.XtraSplashScreen.ShowMode.Image;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.SplashImage = ((System.Drawing.Image)(resources.GetObject("$this.SplashImage")));
            this.Text = "frmSplashScreen";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ProgressBarControl progressBarControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}