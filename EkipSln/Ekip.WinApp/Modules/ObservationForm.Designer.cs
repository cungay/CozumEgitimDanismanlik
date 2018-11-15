namespace Ekip.WinApp.Modules
{
    partial class ObservationForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.dxGridControl1 = new Win.Framework.DevEx.Grid.DxGridControl();
            this.dxGridView1 = new Win.Framework.DevEx.Grid.DxGridView();
            this.colFileNumber = new Ekip.Win.Framework.DevEx.Grid.DxGridColumn();
            this.colFirstContactDate = new Ekip.Win.Framework.DevEx.Grid.DxGridColumn();
            this.colFullName = new Ekip.Win.Framework.DevEx.Grid.DxGridColumn();
            this.colIdCard = new Ekip.Win.Framework.DevEx.Grid.DxGridColumn();
            this.colGender = new Ekip.Win.Framework.DevEx.Grid.DxGridColumn();
            this.colBirthDate = new Ekip.Win.Framework.DevEx.Grid.DxGridColumn();
            this.colAge = new Ekip.Win.Framework.DevEx.Grid.DxGridColumn();
            this.webEditor = new System.Windows.Forms.WebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dxGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.LookAndFeel.SkinName = "Office 2010 Black";
            this.splitContainerControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.dxGridControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.webEditor);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(909, 487);
            this.splitContainerControl1.SplitterPosition = 179;
            this.splitContainerControl1.TabIndex = 10;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // dxGridControl1
            // 
            this.dxGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dxGridControl1.Location = new System.Drawing.Point(0, 0);
            this.dxGridControl1.MainView = this.dxGridView1;
            this.dxGridControl1.Name = "dxGridControl1";
            this.dxGridControl1.ShowOnlyPredefinedDetails = true;
            this.dxGridControl1.Size = new System.Drawing.Size(909, 179);
            this.dxGridControl1.TabIndex = 2;
            this.dxGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dxGridView1});
            // 
            // dxGridView1
            // 
            this.dxGridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFileNumber,
            this.colFirstContactDate,
            this.colFullName,
            this.colIdCard,
            this.colGender,
            this.colBirthDate,
            this.colAge});
            this.dxGridView1.GridControl = this.dxGridControl1;
            this.dxGridView1.IndicatorWidth = 40;
            this.dxGridView1.Name = "dxGridView1";
            this.dxGridView1.OptionsBehavior.AllowIncrementalSearch = true;
            this.dxGridView1.OptionsBehavior.Editable = false;
            this.dxGridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.dxGridView1.OptionsSelection.UseIndicatorForSelection = false;
            this.dxGridView1.OptionsView.ShowAutoFilterRow = true;
            this.dxGridView1.OptionsView.ShowGroupPanel = false;
            this.dxGridView1.OptionsView.ShowIndicator = false;
            this.dxGridView1.OptionsView.ShowViewCaption = true;
            this.dxGridView1.ViewCaption = "Danışan Listesinden Seçim Yapınız";
            // 
            // colFileNumber
            // 
            this.colFileNumber.Caption = "Dosya No";
            this.colFileNumber.FieldName = "FileNumber";
            this.colFileNumber.ListDescription = "";
            this.colFileNumber.ListType = "";
            this.colFileNumber.Name = "colFileNumber";
            this.colFileNumber.Visible = true;
            this.colFileNumber.VisibleIndex = 0;
            this.colFileNumber.Width = 114;
            // 
            // colFirstContactDate
            // 
            this.colFirstContactDate.Caption = "İlk Geliş Tarihi";
            this.colFirstContactDate.FieldName = "FirstContactDate";
            this.colFirstContactDate.ListDescription = "";
            this.colFirstContactDate.ListType = "";
            this.colFirstContactDate.Name = "colFirstContactDate";
            this.colFirstContactDate.Visible = true;
            this.colFirstContactDate.VisibleIndex = 1;
            this.colFirstContactDate.Width = 87;
            // 
            // colFullName
            // 
            this.colFullName.Caption = "Danışan";
            this.colFullName.FieldName = "FullName";
            this.colFullName.ListDescription = "";
            this.colFullName.ListType = "";
            this.colFullName.Name = "colFullName";
            this.colFullName.Visible = true;
            this.colFullName.VisibleIndex = 2;
            this.colFullName.Width = 250;
            // 
            // colIdCard
            // 
            this.colIdCard.Caption = "TC Kimlik";
            this.colIdCard.FieldName = "IdCard";
            this.colIdCard.ListDescription = "";
            this.colIdCard.ListType = "";
            this.colIdCard.Name = "colIdCard";
            this.colIdCard.Visible = true;
            this.colIdCard.VisibleIndex = 3;
            this.colIdCard.Width = 100;
            // 
            // colGender
            // 
            this.colGender.Caption = "Cinsiyet";
            this.colGender.FieldName = "Gender";
            this.colGender.ListDescription = "";
            this.colGender.ListType = "";
            this.colGender.Name = "colGender";
            this.colGender.Visible = true;
            this.colGender.VisibleIndex = 4;
            this.colGender.Width = 60;
            // 
            // colBirthDate
            // 
            this.colBirthDate.Caption = "Doğum Tarihi";
            this.colBirthDate.FieldName = "BirthDate";
            this.colBirthDate.ListDescription = "";
            this.colBirthDate.ListType = "";
            this.colBirthDate.Name = "colBirthDate";
            this.colBirthDate.Visible = true;
            this.colBirthDate.VisibleIndex = 5;
            this.colBirthDate.Width = 133;
            // 
            // colAge
            // 
            this.colAge.Caption = "Yaş";
            this.colAge.FieldName = "Age";
            this.colAge.ListDescription = "";
            this.colAge.ListType = "";
            this.colAge.Name = "colAge";
            this.colAge.Visible = true;
            this.colAge.VisibleIndex = 6;
            this.colAge.Width = 61;
            // 
            // webEditor
            // 
            this.webEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webEditor.Location = new System.Drawing.Point(0, 0);
            this.webEditor.MinimumSize = new System.Drawing.Size(20, 20);
            this.webEditor.Name = "webEditor";
            this.webEditor.Size = new System.Drawing.Size(909, 302);
            this.webEditor.TabIndex = 14;
            // 
            // ObservationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "ObservationForm";
            this.Size = new System.Drawing.Size(909, 487);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dxGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private Ekip.Win.Framework.DevEx.Grid.DxGridControl dxGridControl1;
        private Ekip.Win.Framework.DevEx.Grid.DxGridView dxGridView1;
        private Ekip.Win.Framework.DevEx.Grid.DxGridColumn colFileNumber;
        private Ekip.Win.Framework.DevEx.Grid.DxGridColumn colFirstContactDate;
        private Ekip.Win.Framework.DevEx.Grid.DxGridColumn colFullName;
        private Ekip.Win.Framework.DevEx.Grid.DxGridColumn colIdCard;
        private Ekip.Win.Framework.DevEx.Grid.DxGridColumn colGender;
        private Ekip.Win.Framework.DevEx.Grid.DxGridColumn colBirthDate;
        private Ekip.Win.Framework.DevEx.Grid.DxGridColumn colAge;
        private System.Windows.Forms.WebBrowser webEditor;

    }
}
