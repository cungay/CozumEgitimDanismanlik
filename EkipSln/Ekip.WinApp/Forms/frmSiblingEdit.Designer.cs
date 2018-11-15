namespace Ekip.WinApp.Forms
{
    partial class frmSiblingEdit
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
            System.Windows.Forms.Label birthDateLabel;
            System.Windows.Forms.Label fullNameLabel;
            System.Windows.Forms.Label noteLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            System.Windows.Forms.Label label2;
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.deBirthDate = new DevExpress.XtraEditors.DateEdit();
            this.txtFullName = new DevExpress.XtraEditors.TextEdit();
            this.txtNote = new DevExpress.XtraEditors.MemoEdit();
            this.txtAge = new DevExpress.XtraEditors.TextEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnAccept = new DevExpress.XtraEditors.SimpleButton();
            this.txtSchoolName = new DevExpress.XtraEditors.TextEdit();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.lkGender = new Win.Framework.DevEx.Editors.DxLookUpEdit();
            this.lkClassRoom = new Win.Framework.DevEx.Editors.DxLookUpEdit();
            birthDateLabel = new System.Windows.Forms.Label();
            fullNameLabel = new System.Windows.Forms.Label();
            noteLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.deBirthDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deBirthDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFullName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAge.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSchoolName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkGender.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkClassRoom.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // birthDateLabel
            // 
            birthDateLabel.AutoSize = true;
            birthDateLabel.Location = new System.Drawing.Point(6, 35);
            birthDateLabel.Name = "birthDateLabel";
            birthDateLabel.Size = new System.Drawing.Size(73, 13);
            birthDateLabel.TabIndex = 1;
            birthDateLabel.Text = "Doğum Tarihi:";
            // 
            // fullNameLabel
            // 
            fullNameLabel.AutoSize = true;
            fullNameLabel.Location = new System.Drawing.Point(18, 9);
            fullNameLabel.Name = "fullNameLabel";
            fullNameLabel.Size = new System.Drawing.Size(61, 13);
            fullNameLabel.TabIndex = 7;
            fullNameLabel.Text = "Adı Soyadı:";
            // 
            // noteLabel
            // 
            noteLabel.AutoSize = true;
            noteLabel.Location = new System.Drawing.Point(10, 146);
            noteLabel.Name = "noteLabel";
            noteLabel.Size = new System.Drawing.Size(69, 13);
            noteLabel.TabIndex = 13;
            noteLabel.Text = "Diğer Bilgiler:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(210, 36);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(28, 13);
            label1.TabIndex = 7;
            label1.Text = "Yaş:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(41, 89);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(38, 13);
            label3.TabIndex = 21;
            label3.Text = "Okulu:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(46, 116);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(33, 13);
            label4.TabIndex = 21;
            label4.Text = "Sınıfı:";
            // 
            // deBirthDate
            // 
            this.deBirthDate.EditValue = null;
            this.deBirthDate.EnterMoveNextControl = true;
            this.deBirthDate.Location = new System.Drawing.Point(80, 33);
            this.deBirthDate.Name = "deBirthDate";
            this.deBirthDate.Properties.AllowMouseWheel = false;
            this.deBirthDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deBirthDate.Properties.EditValueChangedDelay = 1000;
            this.deBirthDate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.deBirthDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.deBirthDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deBirthDate.Size = new System.Drawing.Size(124, 20);
            this.deBirthDate.TabIndex = 1;
            this.deBirthDate.Tag = "BirthDate";
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "Doğum boş geçilemez.";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information;
            this.dxValidationProvider1.SetValidationRule(this.deBirthDate, conditionValidationRule1);
            // 
            // txtFullName
            // 
            this.txtFullName.EnterMoveNextControl = true;
            this.txtFullName.Location = new System.Drawing.Point(80, 7);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Properties.ValidateOnEnterKey = true;
            this.txtFullName.Size = new System.Drawing.Size(353, 20);
            this.txtFullName.TabIndex = 0;
            this.txtFullName.Tag = "FullName";
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "Adı soyadı boş geçilemez.";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information;
            this.dxValidationProvider1.SetValidationRule(this.txtFullName, conditionValidationRule2);
            // 
            // txtNote
            // 
            this.txtNote.EnterMoveNextControl = true;
            this.txtNote.Location = new System.Drawing.Point(80, 141);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(353, 77);
            this.txtNote.TabIndex = 6;
            this.txtNote.Tag = "Note";
            // 
            // txtAge
            // 
            this.txtAge.EnterMoveNextControl = true;
            this.txtAge.Location = new System.Drawing.Point(244, 33);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(58, 20);
            this.txtAge.TabIndex = 2;
            this.txtAge.Tag = "Age";
            // 
            // btnCancel
            // 
            this.btnCancel.AllowFocus = false;
            this.btnCancel.CausesValidation = false;
            this.btnCancel.Location = new System.Drawing.Point(358, 224);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "&Vazgeç";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(277, 224);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 7;
            this.btnAccept.Text = "&Tamam";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // txtSchoolName
            // 
            this.txtSchoolName.EnterMoveNextControl = true;
            this.txtSchoolName.Location = new System.Drawing.Point(80, 86);
            this.txtSchoolName.Name = "txtSchoolName";
            this.txtSchoolName.Size = new System.Drawing.Size(353, 20);
            this.txtSchoolName.TabIndex = 4;
            this.txtSchoolName.Tag = "School";
            // 
            // dxValidationProvider1
            // 
            this.dxValidationProvider1.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Auto;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(29, 62);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(49, 13);
            label2.TabIndex = 23;
            label2.Text = "Cinsiyet:";
            // 
            // lkGender
            // 
            this.lkGender.EnterMoveNextControl = true;
            this.lkGender.Location = new System.Drawing.Point(80, 60);
            this.lkGender.Name = "lkGender";
            this.lkGender.Properties.AllowMouseWheel = false;
            this.lkGender.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lkGender.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkGender.Properties.ListDescription = "";
            this.lkGender.Properties.ListType = "";
            this.lkGender.Size = new System.Drawing.Size(124, 20);
            this.lkGender.TabIndex = 3;
            this.lkGender.Tag = "Gender";
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.NotEquals;
            conditionValidationRule3.ErrorText = "Cinsiyet boş geçilemez.";
            conditionValidationRule3.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information;
            conditionValidationRule3.Value1 = 0;
            this.dxValidationProvider1.SetValidationRule(this.lkGender, conditionValidationRule3);
            // 
            // lkClassRoom
            // 
            this.lkClassRoom.EnterMoveNextControl = true;
            this.lkClassRoom.Location = new System.Drawing.Point(80, 113);
            this.lkClassRoom.Name = "lkClassRoom";
            this.lkClassRoom.Properties.AllowMouseWheel = false;
            this.lkClassRoom.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lkClassRoom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkClassRoom.Properties.ListDescription = "";
            this.lkClassRoom.Properties.ListType = "";
            this.lkClassRoom.Size = new System.Drawing.Size(222, 20);
            this.lkClassRoom.TabIndex = 5;
            this.lkClassRoom.Tag = "ClassRoom";
            // 
            // frmSiblingEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 254);
            this.Controls.Add(this.lkGender);
            this.Controls.Add(label2);
            this.Controls.Add(label4);
            this.Controls.Add(label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtSchoolName);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.lkClassRoom);
            this.Controls.Add(noteLabel);
            this.Controls.Add(label1);
            this.Controls.Add(fullNameLabel);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(birthDateLabel);
            this.Controls.Add(this.deBirthDate);
            this.Controls.Add(this.txtNote);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSiblingEdit";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kardeş Bilgileri";
            ((System.ComponentModel.ISupportInitialize)(this.deBirthDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deBirthDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFullName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAge.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSchoolName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkGender.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkClassRoom.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit deBirthDate;
        private DevExpress.XtraEditors.TextEdit txtFullName;
        private DevExpress.XtraEditors.MemoEdit txtNote;
        private DevExpress.XtraEditors.TextEdit txtAge;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnAccept;
        private DevExpress.XtraEditors.TextEdit txtSchoolName;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private Ekip.Win.Framework.DevEx.Editors.DxLookUpEdit lkClassRoom;
        private Ekip.Win.Framework.DevEx.Editors.DxLookUpEdit lkGender;
    }
}