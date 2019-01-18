namespace Ekip.Framework.UI.ExceptionDialog
{
    partial class ExDetails
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
            this.txtExMessage = new DevExpress.XtraEditors.MemoEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnSendMail = new DevExpress.XtraEditors.SimpleButton();
            this.btnCopy = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtExMessage.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtExMessage
            // 
            this.txtExMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExMessage.Location = new System.Drawing.Point(0, 1);
            this.txtExMessage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtExMessage.Name = "txtExMessage";
            this.txtExMessage.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtExMessage.Properties.Appearance.Options.UseBackColor = true;
            this.txtExMessage.Properties.ReadOnly = true;
            this.txtExMessage.Size = new System.Drawing.Size(648, 285);
            this.txtExMessage.TabIndex = 0;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.simpleButton1.Location = new System.Drawing.Point(544, 293);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(87, 28);
            this.simpleButton1.TabIndex = 18;
            this.simpleButton1.Text = "Kapat";
            // 
            // btnSendMail
            // 
            this.btnSendMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSendMail.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnSendMail.Cursor = System.Windows.Forms.Cursors.Hand;
            //this.btnSendMail.ImageOptions.Image = global::Ekip.WinApp.Properties.Resources.sendMail16;
            this.btnSendMail.Location = new System.Drawing.Point(41, 293);
            this.btnSendMail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSendMail.Name = "btnSendMail";
            this.btnSendMail.Size = new System.Drawing.Size(28, 28);
            this.btnSendMail.TabIndex = 19;
            this.btnSendMail.ToolTip = "Hata detaylarını e-posta olarak gönder";
            this.btnSendMail.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnSendMail.Click += new System.EventHandler(this.btnSendMail_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCopy.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnCopy.Cursor = System.Windows.Forms.Cursors.Hand;
            //this.btnCopy.ImageOptions.Image = global::Ekip.WinApp.Properties.Resources.copy16;
            this.btnCopy.Location = new System.Drawing.Point(6, 293);
            this.btnCopy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(28, 28);
            this.btnCopy.TabIndex = 19;
            this.btnCopy.ToolTip = "Hata detaylarını kopyala";
            this.btnCopy.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // ExDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 332);
            this.Controls.Add(this.btnSendMail);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.txtExMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExDetails";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Hata Detayları";
            ((System.ComponentModel.ISupportInitialize)(this.txtExMessage.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.MemoEdit txtExMessage;        
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton btnCopy;
        private DevExpress.XtraEditors.SimpleButton btnSendMail;

    }
}