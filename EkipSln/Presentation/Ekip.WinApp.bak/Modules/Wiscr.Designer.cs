namespace Ekip.WinApp.Modules
{
    partial class Wiscr
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.gcWiscr = new Win.Framework.DevEx.Grid.DxGridControl();
            this.gwWiscr = new Win.Framework.DevEx.Grid.DxGridView();
            this.colSeanceDate = new Ekip.Win.Framework.DevEx.Grid.DxGridColumn();
            this.colSeanceTime = new Ekip.Win.Framework.DevEx.Grid.DxGridColumn();
            this.colSeanceAdvisorName = new Ekip.Win.Framework.DevEx.Grid.DxGridColumn();
            this.colTestDate = new Ekip.Win.Framework.DevEx.Grid.DxGridColumn();
            this.colTestAdvisorName = new Ekip.Win.Framework.DevEx.Grid.DxGridColumn();
            this.colTotalVerbalScore = new Ekip.Win.Framework.DevEx.Grid.DxGridColumn();
            this.colTotalPerformanceScore = new Ekip.Win.Framework.DevEx.Grid.DxGridColumn();
            this.colTotalScore = new Ekip.Win.Framework.DevEx.Grid.DxGridColumn();
            this.colSelect = new Ekip.Win.Framework.DevEx.Grid.DxGridColumn();
            this.btnSelect = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.labelControl19 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl20 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl21 = new DevExpress.XtraEditors.LabelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.grpClientSummary = new System.Windows.Forms.GroupBox();
            this.xtraScrollableControl2 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.txtClassRoom = new DevExpress.XtraEditors.TextEdit();
            this.lblSchool = new DevExpress.XtraEditors.LabelControl();
            this.lblClassRoom = new DevExpress.XtraEditors.LabelControl();
            this.txtFullName = new DevExpress.XtraEditors.TextEdit();
            this.txtBirthDate = new DevExpress.XtraEditors.TextEdit();
            this.txtSchool = new DevExpress.XtraEditors.TextEdit();
            this.lblAge = new DevExpress.XtraEditors.LabelControl();
            this.lblGender = new DevExpress.XtraEditors.LabelControl();
            this.lblBirthDate = new DevExpress.XtraEditors.LabelControl();
            this.txtAge = new DevExpress.XtraEditors.TextEdit();
            this.lblFileNumber = new DevExpress.XtraEditors.LabelControl();
            this.lblFullName = new DevExpress.XtraEditors.LabelControl();
            this.txtFileNumber = new DevExpress.XtraEditors.TextEdit();
            this.txtGender = new DevExpress.XtraEditors.TextEdit();
            this.lblMother = new DevExpress.XtraEditors.LabelControl();
            this.txtMother = new DevExpress.XtraEditors.TextEdit();
            this.lblFather = new DevExpress.XtraEditors.LabelControl();
            this.txtFather = new DevExpress.XtraEditors.TextEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.xtraScrollableControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcWiscr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwWiscr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSelect)).BeginInit();
            this.grpClientSummary.SuspendLayout();
            this.xtraScrollableControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtClassRoom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFullName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBirthDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSchool.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAge.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGender.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMother.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFather.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // xtraScrollableControl1
            // 
            this.xtraScrollableControl1.Controls.Add(this.gcWiscr);
            this.xtraScrollableControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraScrollableControl1.Location = new System.Drawing.Point(0, 123);
            this.xtraScrollableControl1.Name = "xtraScrollableControl1";
            this.xtraScrollableControl1.Size = new System.Drawing.Size(1059, 383);
            this.xtraScrollableControl1.TabIndex = 10;
            // 
            // gcWiscr
            // 
            this.gcWiscr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcWiscr.EmbeddedNavigator.Buttons.Append.Hint = "Yeni Ekle";
            this.gcWiscr.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcWiscr.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcWiscr.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcWiscr.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcWiscr.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcWiscr.Location = new System.Drawing.Point(0, 0);
            this.gcWiscr.MainView = this.gwWiscr;
            this.gcWiscr.Name = "gcWiscr";
            this.gcWiscr.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnSelect});
            this.gcWiscr.Size = new System.Drawing.Size(1059, 383);
            this.gcWiscr.TabIndex = 1;
            this.gcWiscr.UseEmbeddedNavigator = true;
            this.gcWiscr.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gwWiscr});
            // 
            // gwWiscr
            // 
            this.gwWiscr.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSeanceDate,
            this.colSeanceTime,
            this.colSeanceAdvisorName,
            this.colTestDate,
            this.colTestAdvisorName,
            this.colTotalVerbalScore,
            this.colTotalPerformanceScore,
            this.colTotalScore,
            this.colSelect});
            this.gwWiscr.EmptyDataMessage = "";
            this.gwWiscr.GridControl = this.gcWiscr;
            this.gwWiscr.IndicatorWidth = 25;
            this.gwWiscr.Name = "gwWiscr";
            this.gwWiscr.OptionsView.ShowGroupPanel = false;
            this.gwWiscr.OptionsView.ShowViewCaption = true;
            this.gwWiscr.ViewCaption = "Wiscr Testleri";
            // 
            // colSeanceDate
            // 
            this.colSeanceDate.Caption = "Seans Tarihi";
            this.colSeanceDate.FieldName = "SeanceDate";
            this.colSeanceDate.ListDescription = "";
            this.colSeanceDate.ListType = "";
            this.colSeanceDate.Name = "colSeanceDate";
            this.colSeanceDate.OptionsColumn.AllowEdit = false;
            this.colSeanceDate.Visible = true;
            this.colSeanceDate.VisibleIndex = 0;
            this.colSeanceDate.Width = 94;
            // 
            // colSeanceTime
            // 
            this.colSeanceTime.Caption = "Seans Saati";
            this.colSeanceTime.FieldName = "SeanceTime";
            this.colSeanceTime.ListDescription = "";
            this.colSeanceTime.ListType = "";
            this.colSeanceTime.Name = "colSeanceTime";
            this.colSeanceTime.OptionsColumn.AllowEdit = false;
            this.colSeanceTime.Visible = true;
            this.colSeanceTime.VisibleIndex = 1;
            this.colSeanceTime.Width = 77;
            // 
            // colSeanceAdvisorName
            // 
            this.colSeanceAdvisorName.Caption = "Uzman";
            this.colSeanceAdvisorName.FieldName = "SeanceAdvisorName";
            this.colSeanceAdvisorName.ListDescription = "";
            this.colSeanceAdvisorName.ListType = "";
            this.colSeanceAdvisorName.Name = "colSeanceAdvisorName";
            this.colSeanceAdvisorName.OptionsColumn.AllowEdit = false;
            this.colSeanceAdvisorName.Visible = true;
            this.colSeanceAdvisorName.VisibleIndex = 2;
            this.colSeanceAdvisorName.Width = 247;
            // 
            // colTestDate
            // 
            this.colTestDate.Caption = "Wiscr Tarihi";
            this.colTestDate.FieldName = "TestDate";
            this.colTestDate.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.colTestDate.ListDescription = "";
            this.colTestDate.ListType = "";
            this.colTestDate.Name = "colTestDate";
            this.colTestDate.OptionsColumn.AllowEdit = false;
            this.colTestDate.Visible = true;
            this.colTestDate.VisibleIndex = 3;
            this.colTestDate.Width = 89;
            // 
            // colTestAdvisorName
            // 
            this.colTestAdvisorName.Caption = "Testi Uygulayan";
            this.colTestAdvisorName.FieldName = "TestAdvisorName";
            this.colTestAdvisorName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.colTestAdvisorName.ListDescription = "";
            this.colTestAdvisorName.ListType = "";
            this.colTestAdvisorName.Name = "colTestAdvisorName";
            this.colTestAdvisorName.OptionsColumn.AllowEdit = false;
            this.colTestAdvisorName.Visible = true;
            this.colTestAdvisorName.VisibleIndex = 4;
            this.colTestAdvisorName.Width = 111;
            // 
            // colTotalVerbalScore
            // 
            this.colTotalVerbalScore.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.colTotalVerbalScore.AppearanceCell.Options.UseFont = true;
            this.colTotalVerbalScore.Caption = "Sözel Puanı";
            this.colTotalVerbalScore.FieldName = "TotalVerbalScore";
            this.colTotalVerbalScore.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.colTotalVerbalScore.ListDescription = "";
            this.colTotalVerbalScore.ListType = "";
            this.colTotalVerbalScore.Name = "colTotalVerbalScore";
            this.colTotalVerbalScore.OptionsColumn.AllowEdit = false;
            this.colTotalVerbalScore.Visible = true;
            this.colTotalVerbalScore.VisibleIndex = 6;
            this.colTotalVerbalScore.Width = 77;
            // 
            // colTotalPerformanceScore
            // 
            this.colTotalPerformanceScore.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.colTotalPerformanceScore.AppearanceCell.Options.UseFont = true;
            this.colTotalPerformanceScore.Caption = "Performans Puanı";
            this.colTotalPerformanceScore.FieldName = "TotalPerformanceScore";
            this.colTotalPerformanceScore.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.colTotalPerformanceScore.ListDescription = "";
            this.colTotalPerformanceScore.ListType = "";
            this.colTotalPerformanceScore.Name = "colTotalPerformanceScore";
            this.colTotalPerformanceScore.OptionsColumn.AllowEdit = false;
            this.colTotalPerformanceScore.Visible = true;
            this.colTotalPerformanceScore.VisibleIndex = 5;
            this.colTotalPerformanceScore.Width = 115;
            // 
            // colTotalScore
            // 
            this.colTotalScore.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.colTotalScore.AppearanceCell.Options.UseFont = true;
            this.colTotalScore.Caption = "Toplam Puan";
            this.colTotalScore.FieldName = "TotalScore";
            this.colTotalScore.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.colTotalScore.ListDescription = "";
            this.colTotalScore.ListType = "";
            this.colTotalScore.Name = "colTotalScore";
            this.colTotalScore.OptionsColumn.AllowEdit = false;
            this.colTotalScore.Visible = true;
            this.colTotalScore.VisibleIndex = 7;
            this.colTotalScore.Width = 105;
            // 
            // colSelect
            // 
            this.colSelect.ColumnEdit = this.btnSelect;
            this.colSelect.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.colSelect.ListDescription = "";
            this.colSelect.ListType = "";
            this.colSelect.Name = "colSelect";
            this.colSelect.Visible = true;
            this.colSelect.VisibleIndex = 8;
            this.colSelect.Width = 115;
            // 
            // btnSelect
            // 
            this.btnSelect.AutoHeight = false;
            this.btnSelect.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "&Görüntüle/&Düzenle", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.Default, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.btnSelect.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnSelect.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnSelect_ButtonClick);
            // 
            // labelControl19
            // 
            this.labelControl19.Appearance.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl19.Location = new System.Drawing.Point(18, 53);
            this.labelControl19.Name = "labelControl19";
            this.labelControl19.Size = new System.Drawing.Size(127, 14);
            this.labelControl19.TabIndex = 15;
            this.labelControl19.Text = "WECHSLER ÇOCUKLAR";
            // 
            // labelControl20
            // 
            this.labelControl20.Appearance.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl20.Location = new System.Drawing.Point(31, 69);
            this.labelControl20.Name = "labelControl20";
            this.labelControl20.Size = new System.Drawing.Size(100, 14);
            this.labelControl20.TabIndex = 15;
            this.labelControl20.Text = "İÇİN ZEKA ÖLÇEĞİ";
            // 
            // labelControl21
            // 
            this.labelControl21.Appearance.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl21.Location = new System.Drawing.Point(36, 86);
            this.labelControl21.Name = "labelControl21";
            this.labelControl21.Size = new System.Drawing.Size(79, 14);
            this.labelControl21.TabIndex = 15;
            this.labelControl21.Text = "KAYIT FORMU";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara", 29.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "WÇZÖ-R";
            // 
            // grpClientSummary
            // 
            this.grpClientSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.grpClientSummary.Controls.Add(this.xtraScrollableControl2);
            this.grpClientSummary.Location = new System.Drawing.Point(167, 8);
            this.grpClientSummary.Name = "grpClientSummary";
            this.grpClientSummary.Size = new System.Drawing.Size(889, 109);
            this.grpClientSummary.TabIndex = 6;
            this.grpClientSummary.TabStop = false;
            // 
            // xtraScrollableControl2
            // 
            this.xtraScrollableControl2.Controls.Add(this.txtFather);
            this.xtraScrollableControl2.Controls.Add(this.lblFather);
            this.xtraScrollableControl2.Controls.Add(this.txtMother);
            this.xtraScrollableControl2.Controls.Add(this.lblMother);
            this.xtraScrollableControl2.Controls.Add(this.txtGender);
            this.xtraScrollableControl2.Controls.Add(this.txtFileNumber);
            this.xtraScrollableControl2.Controls.Add(this.lblFullName);
            this.xtraScrollableControl2.Controls.Add(this.lblFileNumber);
            this.xtraScrollableControl2.Controls.Add(this.txtAge);
            this.xtraScrollableControl2.Controls.Add(this.lblBirthDate);
            this.xtraScrollableControl2.Controls.Add(this.lblGender);
            this.xtraScrollableControl2.Controls.Add(this.lblAge);
            this.xtraScrollableControl2.Controls.Add(this.txtSchool);
            this.xtraScrollableControl2.Controls.Add(this.txtBirthDate);
            this.xtraScrollableControl2.Controls.Add(this.txtFullName);
            this.xtraScrollableControl2.Controls.Add(this.lblClassRoom);
            this.xtraScrollableControl2.Controls.Add(this.lblSchool);
            this.xtraScrollableControl2.Controls.Add(this.txtClassRoom);
            this.xtraScrollableControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraScrollableControl2.Location = new System.Drawing.Point(3, 17);
            this.xtraScrollableControl2.Name = "xtraScrollableControl2";
            this.xtraScrollableControl2.Size = new System.Drawing.Size(883, 89);
            this.xtraScrollableControl2.TabIndex = 0;
            // 
            // txtClassRoom
            // 
            this.txtClassRoom.EnterMoveNextControl = true;
            this.txtClassRoom.Location = new System.Drawing.Point(307, 6);
            this.txtClassRoom.Name = "txtClassRoom";
            this.txtClassRoom.Properties.AllowFocused = false;
            this.txtClassRoom.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtClassRoom.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.txtClassRoom.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtClassRoom.Properties.ReadOnly = true;
            this.txtClassRoom.Properties.ValidateOnEnterKey = true;
            this.txtClassRoom.Size = new System.Drawing.Size(184, 20);
            this.txtClassRoom.TabIndex = 42;
            // 
            // lblSchool
            // 
            this.lblSchool.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSchool.Location = new System.Drawing.Point(273, 33);
            this.lblSchool.Name = "lblSchool";
            this.lblSchool.Size = new System.Drawing.Size(28, 13);
            this.lblSchool.TabIndex = 50;
            this.lblSchool.Text = "Okul:";
            // 
            // lblClassRoom
            // 
            this.lblClassRoom.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblClassRoom.Location = new System.Drawing.Point(274, 10);
            this.lblClassRoom.Name = "lblClassRoom";
            this.lblClassRoom.Size = new System.Drawing.Size(27, 13);
            this.lblClassRoom.TabIndex = 54;
            this.lblClassRoom.Text = "Sınıf:";
            // 
            // txtFullName
            // 
            this.txtFullName.EnterMoveNextControl = true;
            this.txtFullName.Location = new System.Drawing.Point(73, 29);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Properties.AllowFocused = false;
            this.txtFullName.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtFullName.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.txtFullName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtFullName.Properties.ReadOnly = true;
            this.txtFullName.Properties.ValidateOnEnterKey = true;
            this.txtFullName.Size = new System.Drawing.Size(183, 20);
            this.txtFullName.TabIndex = 40;
            // 
            // txtBirthDate
            // 
            this.txtBirthDate.EnterMoveNextControl = true;
            this.txtBirthDate.Location = new System.Drawing.Point(596, 7);
            this.txtBirthDate.Name = "txtBirthDate";
            this.txtBirthDate.Properties.AllowFocused = false;
            this.txtBirthDate.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtBirthDate.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.txtBirthDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtBirthDate.Properties.ReadOnly = true;
            this.txtBirthDate.Properties.ValidateOnEnterKey = true;
            this.txtBirthDate.Size = new System.Drawing.Size(164, 20);
            this.txtBirthDate.TabIndex = 45;
            // 
            // txtSchool
            // 
            this.txtSchool.EnterMoveNextControl = true;
            this.txtSchool.Location = new System.Drawing.Point(307, 28);
            this.txtSchool.Name = "txtSchool";
            this.txtSchool.Properties.AllowFocused = false;
            this.txtSchool.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSchool.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.txtSchool.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtSchool.Properties.ReadOnly = true;
            this.txtSchool.Properties.ValidateOnEnterKey = true;
            this.txtSchool.Size = new System.Drawing.Size(184, 20);
            this.txtSchool.TabIndex = 43;
            // 
            // lblAge
            // 
            this.lblAge.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAge.Location = new System.Drawing.Point(562, 32);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(23, 13);
            this.lblAge.TabIndex = 53;
            this.lblAge.Text = "Yaş:";
            // 
            // lblGender
            // 
            this.lblGender.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblGender.Location = new System.Drawing.Point(536, 55);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(48, 13);
            this.lblGender.TabIndex = 52;
            this.lblGender.Text = "Cinsiyet:";
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBirthDate.Location = new System.Drawing.Point(507, 10);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(78, 13);
            this.lblBirthDate.TabIndex = 51;
            this.lblBirthDate.Text = "Doğum Tarihi:";
            // 
            // txtAge
            // 
            this.txtAge.EnterMoveNextControl = true;
            this.txtAge.Location = new System.Drawing.Point(596, 29);
            this.txtAge.Name = "txtAge";
            this.txtAge.Properties.AllowFocused = false;
            this.txtAge.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAge.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.txtAge.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtAge.Properties.ReadOnly = true;
            this.txtAge.Properties.ValidateOnEnterKey = true;
            this.txtAge.Size = new System.Drawing.Size(164, 20);
            this.txtAge.TabIndex = 46;
            // 
            // lblFileNumber
            // 
            this.lblFileNumber.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblFileNumber.Location = new System.Drawing.Point(10, 10);
            this.lblFileNumber.Name = "lblFileNumber";
            this.lblFileNumber.Size = new System.Drawing.Size(55, 13);
            this.lblFileNumber.TabIndex = 49;
            this.lblFileNumber.Text = "Dosya No:";
            // 
            // lblFullName
            // 
            this.lblFullName.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblFullName.Location = new System.Drawing.Point(10, 32);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(56, 13);
            this.lblFullName.TabIndex = 48;
            this.lblFullName.Text = "Ad Soyad:";
            // 
            // txtFileNumber
            // 
            this.txtFileNumber.EnterMoveNextControl = true;
            this.txtFileNumber.Location = new System.Drawing.Point(73, 7);
            this.txtFileNumber.Name = "txtFileNumber";
            this.txtFileNumber.Properties.AllowFocused = false;
            this.txtFileNumber.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtFileNumber.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.txtFileNumber.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtFileNumber.Properties.ReadOnly = true;
            this.txtFileNumber.Properties.ValidateOnEnterKey = true;
            this.txtFileNumber.Size = new System.Drawing.Size(183, 20);
            this.txtFileNumber.TabIndex = 39;
            // 
            // txtGender
            // 
            this.txtGender.EnterMoveNextControl = true;
            this.txtGender.Location = new System.Drawing.Point(596, 51);
            this.txtGender.Name = "txtGender";
            this.txtGender.Properties.AllowFocused = false;
            this.txtGender.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtGender.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.txtGender.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtGender.Properties.ReadOnly = true;
            this.txtGender.Properties.ValidateOnEnterKey = true;
            this.txtGender.Size = new System.Drawing.Size(164, 20);
            this.txtGender.TabIndex = 47;
            // 
            // lblMother
            // 
            this.lblMother.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMother.Location = new System.Drawing.Point(34, 54);
            this.lblMother.Name = "lblMother";
            this.lblMother.Size = new System.Drawing.Size(32, 13);
            this.lblMother.TabIndex = 55;
            this.lblMother.Text = "Anne:";
            // 
            // txtMother
            // 
            this.txtMother.EnterMoveNextControl = true;
            this.txtMother.Location = new System.Drawing.Point(73, 51);
            this.txtMother.Name = "txtMother";
            this.txtMother.Properties.AllowFocused = false;
            this.txtMother.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtMother.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.txtMother.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtMother.Properties.ReadOnly = true;
            this.txtMother.Properties.ValidateOnEnterKey = true;
            this.txtMother.Size = new System.Drawing.Size(183, 20);
            this.txtMother.TabIndex = 41;
            // 
            // lblFather
            // 
            this.lblFather.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblFather.Location = new System.Drawing.Point(270, 54);
            this.lblFather.Name = "lblFather";
            this.lblFather.Size = new System.Drawing.Size(31, 13);
            this.lblFather.TabIndex = 56;
            this.lblFather.Text = "Baba:";
            // 
            // txtFather
            // 
            this.txtFather.EnterMoveNextControl = true;
            this.txtFather.Location = new System.Drawing.Point(307, 51);
            this.txtFather.Name = "txtFather";
            this.txtFather.Properties.AllowFocused = false;
            this.txtFather.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtFather.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.txtFather.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtFather.Properties.ReadOnly = true;
            this.txtFather.Properties.ValidateOnEnterKey = true;
            this.txtFather.Size = new System.Drawing.Size(184, 20);
            this.txtFather.TabIndex = 44;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grpClientSummary);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.labelControl21);
            this.panel1.Controls.Add(this.labelControl20);
            this.panel1.Controls.Add(this.labelControl19);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1059, 123);
            this.panel1.TabIndex = 5;
            // 
            // Wiscr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xtraScrollableControl1);
            this.Controls.Add(this.panel1);
            this.Name = "Wiscr";
            this.Size = new System.Drawing.Size(1059, 506);
            this.xtraScrollableControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcWiscr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwWiscr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSelect)).EndInit();
            this.grpClientSummary.ResumeLayout(false);
            this.xtraScrollableControl2.ResumeLayout(false);
            this.xtraScrollableControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtClassRoom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFullName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBirthDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSchool.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAge.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGender.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMother.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFather.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
        private Ekip.Win.Framework.DevEx.Grid.DxGridControl gcWiscr;
        private Ekip.Win.Framework.DevEx.Grid.DxGridView gwWiscr;
        private Ekip.Win.Framework.DevEx.Grid.DxGridColumn colSeanceDate;
        private Ekip.Win.Framework.DevEx.Grid.DxGridColumn colSeanceTime;
        private Ekip.Win.Framework.DevEx.Grid.DxGridColumn colSeanceAdvisorName;
        private Ekip.Win.Framework.DevEx.Grid.DxGridColumn colTestDate;
        private Ekip.Win.Framework.DevEx.Grid.DxGridColumn colTestAdvisorName;
        private Ekip.Win.Framework.DevEx.Grid.DxGridColumn colTotalVerbalScore;
        private Ekip.Win.Framework.DevEx.Grid.DxGridColumn colTotalPerformanceScore;
        private Ekip.Win.Framework.DevEx.Grid.DxGridColumn colTotalScore;
        private Ekip.Win.Framework.DevEx.Grid.DxGridColumn colSelect;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnSelect;
        private DevExpress.XtraEditors.LabelControl labelControl19;
        private DevExpress.XtraEditors.LabelControl labelControl20;
        private DevExpress.XtraEditors.LabelControl labelControl21;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpClientSummary;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl2;
        private DevExpress.XtraEditors.TextEdit txtFather;
        private DevExpress.XtraEditors.LabelControl lblFather;
        private DevExpress.XtraEditors.TextEdit txtMother;
        private DevExpress.XtraEditors.LabelControl lblMother;
        private DevExpress.XtraEditors.TextEdit txtGender;
        private DevExpress.XtraEditors.TextEdit txtFileNumber;
        private DevExpress.XtraEditors.LabelControl lblFullName;
        private DevExpress.XtraEditors.LabelControl lblFileNumber;
        private DevExpress.XtraEditors.TextEdit txtAge;
        private DevExpress.XtraEditors.LabelControl lblBirthDate;
        private DevExpress.XtraEditors.LabelControl lblGender;
        private DevExpress.XtraEditors.LabelControl lblAge;
        private DevExpress.XtraEditors.TextEdit txtSchool;
        private DevExpress.XtraEditors.TextEdit txtBirthDate;
        private DevExpress.XtraEditors.TextEdit txtFullName;
        private DevExpress.XtraEditors.LabelControl lblClassRoom;
        private DevExpress.XtraEditors.LabelControl lblSchool;
        private DevExpress.XtraEditors.TextEdit txtClassRoom;
        private System.Windows.Forms.Panel panel1;
    }
}
