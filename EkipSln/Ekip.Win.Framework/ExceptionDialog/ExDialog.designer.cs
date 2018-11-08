namespace Ekip.Win.Framework.ExceptionDialog
{
    partial class ExDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExDialog));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblErrorName = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lnkDetails = new DevExpress.XtraEditors.HyperLinkEdit();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lnkDetails.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(14, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(47, 49);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // lblErrorName
            // 
            this.lblErrorName.AllowHtmlString = true;
            this.lblErrorName.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblErrorName.Appearance.Options.UseFont = true;
            this.lblErrorName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblErrorName.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.lblErrorName.Location = new System.Drawing.Point(96, 47);
            this.lblErrorName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblErrorName.Name = "lblErrorName";
            this.lblErrorName.Size = new System.Drawing.Size(350, 18);
            this.lblErrorName.TabIndex = 4;
            this.lblErrorName.Text = "errorMessage";
            // 
            // labelControl1
            // 
            this.labelControl1.AllowHtmlString = true;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl1.Location = new System.Drawing.Point(68, 20);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(319, 18);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Sistem beklenmeyen bir hata ile karşılaştı.";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(73, 49);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(21, 14);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // lnkDetails
            // 
            this.lnkDetails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkDetails.EditValue = "Hata Detayları";
            this.lnkDetails.Location = new System.Drawing.Point(16, 102);
            this.lnkDetails.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lnkDetails.Name = "lnkDetails";
            this.lnkDetails.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lnkDetails.Properties.Appearance.Options.UseBackColor = true;
            this.lnkDetails.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lnkDetails.Size = new System.Drawing.Size(89, 20);
            this.lnkDetails.TabIndex = 9;
            this.lnkDetails.Click += new System.EventHandler(this.lnkDetails_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(363, 98);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(87, 28);
            this.btnOk.TabIndex = 10;
            this.btnOk.Text = "Ok";
            // 
            // ExDialog
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 135);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lnkDetails);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lblErrorName);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tanımlanamayan Hata";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lnkDetails.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.LabelControl lblErrorName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private DevExpress.XtraEditors.HyperLinkEdit lnkDetails;
        private DevExpress.XtraEditors.SimpleButton btnOk;
    }
}