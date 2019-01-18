namespace Ekip.WinApp.Forms
{
    partial class frmTeacherEdit
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label fullNameLabel;
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.txtTeacherEmail = new DevExpress.XtraEditors.TextEdit();
            this.txtTeacherPhone = new DevExpress.XtraEditors.TextEdit();
            this.txtNote = new DevExpress.XtraEditors.MemoEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnAccept = new DevExpress.XtraEditors.SimpleButton();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.txtTeacherName = new DevExpress.XtraEditors.TextEdit();
            this.lkBranch = new DevExpress.XtraEditors.LookUpEdit();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            fullNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtTeacherEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTeacherPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTeacherName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkBranch.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(2, 59);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(81, 13);
            label1.TabIndex = 8;
            label1.Text = "E-Posta Adresi:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(36, 84);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(47, 13);
            label2.TabIndex = 8;
            label2.Text = "Telefon:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(19, 108);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(64, 13);
            label4.TabIndex = 8;
            label4.Text = "Açıklamalar:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(45, 32);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(38, 13);
            label3.TabIndex = 9;
            label3.Text = "Branş:";
            // 
            // fullNameLabel
            // 
            fullNameLabel.AutoSize = true;
            fullNameLabel.Location = new System.Drawing.Point(22, 7);
            fullNameLabel.Name = "fullNameLabel";
            fullNameLabel.Size = new System.Drawing.Size(61, 13);
            fullNameLabel.TabIndex = 12;
            fullNameLabel.Text = "Adı Soyadı:";
            // 
            // txtTeacherEmail
            // 
            this.txtTeacherEmail.EnterMoveNextControl = true;
            this.txtTeacherEmail.Location = new System.Drawing.Point(89, 56);
            this.txtTeacherEmail.Name = "txtTeacherEmail";
            this.txtTeacherEmail.Size = new System.Drawing.Size(267, 20);
            this.txtTeacherEmail.TabIndex = 3;
            this.txtTeacherEmail.Tag = "TeacherEmail";
            // 
            // txtTeacherPhone
            // 
            this.txtTeacherPhone.EditValue = "lo";
            this.txtTeacherPhone.EnterMoveNextControl = true;
            this.txtTeacherPhone.Location = new System.Drawing.Point(89, 81);
            this.txtTeacherPhone.Name = "txtTeacherPhone";
            this.txtTeacherPhone.Properties.Mask.EditMask = "(\\d?\\d?\\d?)\\d\\d\\d-\\d\\d\\d\\d";
            this.txtTeacherPhone.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular;
            this.txtTeacherPhone.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTeacherPhone.Size = new System.Drawing.Size(267, 20);
            this.txtTeacherPhone.TabIndex = 4;
            this.txtTeacherPhone.Tag = "TeacherPhone";
            // 
            // txtNote
            // 
            this.txtNote.EnterMoveNextControl = true;
            this.txtNote.Location = new System.Drawing.Point(89, 106);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(267, 77);
            this.txtNote.TabIndex = 5;
            this.txtNote.Tag = "Note";
            // 
            // btnCancel
            // 
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(281, 189);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&Vazgeç";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(201, 189);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 5;
            this.btnAccept.Text = "&Tamam";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // dxValidationProvider1
            // 
            this.dxValidationProvider1.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Auto;
            // 
            // txtTeacherName
            // 
            this.txtTeacherName.EnterMoveNextControl = true;
            this.txtTeacherName.Location = new System.Drawing.Point(89, 4);
            this.txtTeacherName.Name = "txtTeacherName";
            this.txtTeacherName.Size = new System.Drawing.Size(267, 20);
            this.txtTeacherName.TabIndex = 1;
            this.txtTeacherName.Tag = "TeacherName";
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "Öğretmenin adı soyadı boş geçilemez.";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information;
            this.dxValidationProvider1.SetValidationRule(this.txtTeacherName, conditionValidationRule2);
            // 
            // lkBranch
            // 
            this.lkBranch.EnterMoveNextControl = true;
            this.lkBranch.Location = new System.Drawing.Point(90, 30);
            this.lkBranch.Name = "lkBranch";
            this.lkBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkBranch.Size = new System.Drawing.Size(266, 20);
            this.lkBranch.TabIndex = 2;
            this.lkBranch.Tag = "BranchId";
            // 
            // frmTeacherEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 215);
            this.Controls.Add(this.lkBranch);
            this.Controls.Add(this.txtTeacherName);
            this.Controls.Add(fullNameLabel);
            this.Controls.Add(label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtTeacherPhone);
            this.Controls.Add(this.txtTeacherEmail);
            this.Controls.Add(label4);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.Controls.Add(this.txtNote);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTeacherEdit";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Öğretmen Bilgileri";
            ((System.ComponentModel.ISupportInitialize)(this.txtTeacherEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTeacherPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTeacherName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkBranch.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtTeacherEmail;
        private DevExpress.XtraEditors.TextEdit txtTeacherPhone;
        private DevExpress.XtraEditors.MemoEdit txtNote;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnAccept;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraEditors.TextEdit txtTeacherName;
        private DevExpress.XtraEditors.LookUpEdit lkBranch;
    }
}