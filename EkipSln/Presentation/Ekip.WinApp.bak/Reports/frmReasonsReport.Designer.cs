namespace Ekip.WinApp.Reports
{
    partial class frmReasonsReport
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions3 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReasonsReport));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnSearch = new DevExpress.XtraBars.BarButtonItem();
            this.btnExport = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrintPreview = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblYear = new System.Windows.Forms.Label();
            this.gcResult = new Win.Framework.DevEx.Grid.DxGridControl();
            this.gwResult = new Win.Framework.DevEx.Grid.DxGridView();
            this.colRowNumber = new Win.Framework.DevEx.Grid.DxGridColumn();
            this.colFileNumber = new Ekip.Win.Framework.DevEx.Grid.DxGridColumn();
            this.colFirstContactDate = new Ekip.Win.Framework.DevEx.Grid.DxGridColumn();
            this.colClientName = new Ekip.Win.Framework.DevEx.Grid.DxGridColumn();
            this.colGender = new Ekip.Win.Framework.DevEx.Grid.DxGridColumn();
            this.colBirthDate = new Ekip.Win.Framework.DevEx.Grid.DxGridColumn();
            this.colPediatrician = new Ekip.Win.Framework.DevEx.Grid.DxGridColumn();
            this.colSeanceNote = new Ekip.Win.Framework.DevEx.Grid.DxGridColumn();
            this.colSeanceDate = new Ekip.Win.Framework.DevEx.Grid.DxGridColumn();
            this.colSeanceTime = new Ekip.Win.Framework.DevEx.Grid.DxGridColumn();
            this.colAdvisor = new Ekip.Win.Framework.DevEx.Grid.DxGridColumn();
            this.colFather = new Ekip.Win.Framework.DevEx.Grid.DxGridColumn();
            this.colMother = new Ekip.Win.Framework.DevEx.Grid.DxGridColumn();
            this.colReasonValueList = new Ekip.Win.Framework.DevEx.Grid.DxGridColumn();
            this.colFatherHome = new Ekip.Win.Framework.DevEx.Grid.DxGridColumn();
            this.colFatherMobile = new Ekip.Win.Framework.DevEx.Grid.DxGridColumn();
            this.colFatherBusiness = new Ekip.Win.Framework.DevEx.Grid.DxGridColumn();
            this.colFatherEmail = new Ekip.Win.Framework.DevEx.Grid.DxGridColumn();
            this.colMotherHome = new Ekip.Win.Framework.DevEx.Grid.DxGridColumn();
            this.colMotherMobile = new Ekip.Win.Framework.DevEx.Grid.DxGridColumn();
            this.colMotherBusiness = new Ekip.Win.Framework.DevEx.Grid.DxGridColumn();
            this.colMotherEmail = new Ekip.Win.Framework.DevEx.Grid.DxGridColumn();
            this.lkGender = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.btnSelect = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.cblReasonList = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cblFirstYears = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.cblBirthYears = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.separatorControl1 = new DevExpress.XtraEditors.SeparatorControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkGender)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cblReasonList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cblFirstYears)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cblBirthYears)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.AllowMoveBarOnToolbar = false;
            this.barManager1.AllowQuickCustomization = false;
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnSearch,
            this.btnClose,
            this.btnExport,
            this.btnPrintPreview});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 4;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSearch, DevExpress.XtraBars.BarItemPaintStyle.Standard),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExport),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPrintPreview),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnClose, true)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnSearch
            // 
            this.btnSearch.Border = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.btnSearch.Caption = "Aramayı Başlat";
            this.btnSearch.Hint = "Aramayı Başlat";
            this.btnSearch.Id = 0;
            this.btnSearch.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.ImageOptions.Image")));
            this.btnSearch.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F1);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSearch_ItemClick);
            // 
            // btnExport
            // 
            this.btnExport.Border = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.btnExport.Caption = "Farklı Kaydet";
            this.btnExport.Hint = "Farklı Kaydet";
            this.btnExport.Id = 2;
            this.btnExport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.ImageOptions.Image")));
            this.btnExport.Name = "btnExport";
            this.btnExport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExport_ItemClick);
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Caption = "Baskı Önizleme";
            this.btnPrintPreview.Id = 3;
            this.btnPrintPreview.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPrintPreview.ImageOptions.SvgImage")));
            this.btnPrintPreview.Name = "btnPrintPreview";
            // 
            // btnClose
            // 
            this.btnClose.Border = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.btnClose.Caption = "Kapat";
            this.btnClose.Hint = "Kapat";
            this.btnClose.Id = 1;
            this.btnClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.ImageOptions.Image")));
            this.btnClose.Name = "btnClose";
            this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClose_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlTop.Size = new System.Drawing.Size(1349, 50);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 719);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlBottom.Size = new System.Drawing.Size(1349, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 50);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 669);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1349, 50);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 669);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 697);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1349, 22);
            this.statusStrip1.TabIndex = 77;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblYear.Location = new System.Drawing.Point(8, 79);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(200, 21);
            this.lblYear.TabIndex = 79;
            this.lblYear.Text = "Gelme Nedeni Seçiniz:";
            // 
            // gcResult
            // 
            this.gcResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcResult.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcResult.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcResult.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcResult.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcResult.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcResult.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcResult.Location = new System.Drawing.Point(12, 321);
            this.gcResult.MainView = this.gwResult;
            this.gcResult.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcResult.Name = "gcResult";
            this.gcResult.Padding = new System.Windows.Forms.Padding(5);
            this.gcResult.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lkGender,
            this.btnSelect});
            this.gcResult.Size = new System.Drawing.Size(1325, 367);
            this.gcResult.TabIndex = 84;
            this.gcResult.UseEmbeddedNavigator = true;
            this.gcResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gwResult});
            // 
            // gwResult
            // 
            this.gwResult.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gwResult.Appearance.Row.Options.UseFont = true;
            this.gwResult.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colRowNumber,
            this.colFileNumber,
            this.colFirstContactDate,
            this.colClientName,
            this.colGender,
            this.colBirthDate,
            this.colPediatrician,
            this.colSeanceNote,
            this.colSeanceDate,
            this.colSeanceTime,
            this.colAdvisor,
            this.colFather,
            this.colMother,
            this.colReasonValueList,
            this.colFatherHome,
            this.colFatherMobile,
            this.colFatherBusiness,
            this.colFatherEmail,
            this.colMotherHome,
            this.colMotherMobile,
            this.colMotherBusiness,
            this.colMotherEmail});
            this.gwResult.EmptyDataMessage = "";
            this.gwResult.GridControl = this.gcResult;
            this.gwResult.GroupPanelText = "Gruplamak için sürükle bırak";
            this.gwResult.IndicatorWidth = 25;
            this.gwResult.Name = "gwResult";
            this.gwResult.OptionsPrint.AutoWidth = false;
            this.gwResult.OptionsPrint.ExpandAllDetails = true;
            this.gwResult.OptionsPrint.PrintFooter = false;
            this.gwResult.OptionsView.ShowAutoFilterRow = true;
            this.gwResult.OptionsView.ShowDetailButtons = false;
            this.gwResult.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gwResult.OptionsView.ShowIndicator = false;
            this.gwResult.OptionsView.ShowPreview = true;
            this.gwResult.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gwResult.OptionsView.ShowViewCaption = true;
            this.gwResult.PreviewFieldName = "ReasonValueList";
            this.gwResult.PreviewLineCount = 2;
            this.gwResult.RowHeight = 15;
            this.gwResult.ViewCaption = "Arama Sonuçları";
            // 
            // colRowNumber
            // 
            this.colRowNumber.Caption = "No";
            this.colRowNumber.FieldName = "RowNumber";
            this.colRowNumber.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colRowNumber.ListDescription = "";
            this.colRowNumber.ListType = "";
            this.colRowNumber.Name = "colRowNumber";
            this.colRowNumber.OptionsColumn.AllowEdit = false;
            this.colRowNumber.OptionsColumn.ReadOnly = true;
            this.colRowNumber.Width = 37;
            // 
            // colFileNumber
            // 
            this.colFileNumber.Caption = "Dosya No";
            this.colFileNumber.FieldName = "FileNumber";
            this.colFileNumber.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colFileNumber.ListDescription = "";
            this.colFileNumber.ListType = "";
            this.colFileNumber.Name = "colFileNumber";
            this.colFileNumber.OptionsColumn.AllowEdit = false;
            this.colFileNumber.OptionsColumn.FixedWidth = true;
            this.colFileNumber.OptionsColumn.ReadOnly = true;
            this.colFileNumber.Visible = true;
            this.colFileNumber.VisibleIndex = 0;
            this.colFileNumber.Width = 85;
            // 
            // colFirstContactDate
            // 
            this.colFirstContactDate.Caption = "İlk Geliş T.";
            this.colFirstContactDate.DisplayFormat.FormatString = "dd.MM.yyyy";
            this.colFirstContactDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colFirstContactDate.FieldName = "FirstContactDate";
            this.colFirstContactDate.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colFirstContactDate.ListDescription = "";
            this.colFirstContactDate.ListType = "";
            this.colFirstContactDate.Name = "colFirstContactDate";
            this.colFirstContactDate.OptionsColumn.AllowEdit = false;
            this.colFirstContactDate.OptionsColumn.FixedWidth = true;
            this.colFirstContactDate.OptionsColumn.ReadOnly = true;
            this.colFirstContactDate.Visible = true;
            this.colFirstContactDate.VisibleIndex = 4;
            this.colFirstContactDate.Width = 85;
            // 
            // colClientName
            // 
            this.colClientName.Caption = "Danışan";
            this.colClientName.FieldName = "ClientName";
            this.colClientName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colClientName.ListDescription = "";
            this.colClientName.ListType = "";
            this.colClientName.Name = "colClientName";
            this.colClientName.OptionsColumn.AllowEdit = false;
            this.colClientName.OptionsColumn.FixedWidth = true;
            this.colClientName.OptionsColumn.ReadOnly = true;
            this.colClientName.Visible = true;
            this.colClientName.VisibleIndex = 1;
            this.colClientName.Width = 85;
            // 
            // colGender
            // 
            this.colGender.Caption = "Cinsiyet";
            this.colGender.FieldName = "Gender";
            this.colGender.ListDescription = "";
            this.colGender.ListType = "";
            this.colGender.Name = "colGender";
            this.colGender.OptionsColumn.AllowEdit = false;
            this.colGender.OptionsColumn.FixedWidth = true;
            this.colGender.OptionsColumn.ReadOnly = true;
            this.colGender.Visible = true;
            this.colGender.VisibleIndex = 5;
            this.colGender.Width = 85;
            // 
            // colBirthDate
            // 
            this.colBirthDate.Caption = "Doğum T.";
            this.colBirthDate.DisplayFormat.FormatString = "dd.MM.yyyy";
            this.colBirthDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colBirthDate.FieldName = "BirthDate";
            this.colBirthDate.ListDescription = "";
            this.colBirthDate.ListType = "";
            this.colBirthDate.Name = "colBirthDate";
            this.colBirthDate.OptionsColumn.AllowEdit = false;
            this.colBirthDate.OptionsColumn.FixedWidth = true;
            this.colBirthDate.OptionsColumn.ReadOnly = true;
            this.colBirthDate.Visible = true;
            this.colBirthDate.VisibleIndex = 6;
            this.colBirthDate.Width = 85;
            // 
            // colPediatrician
            // 
            this.colPediatrician.Caption = "Doktoru";
            this.colPediatrician.FieldName = "Pediatrician";
            this.colPediatrician.ListDescription = "";
            this.colPediatrician.ListType = "";
            this.colPediatrician.Name = "colPediatrician";
            this.colPediatrician.OptionsColumn.AllowEdit = false;
            this.colPediatrician.OptionsColumn.FixedWidth = true;
            this.colPediatrician.OptionsColumn.ReadOnly = true;
            this.colPediatrician.Visible = true;
            this.colPediatrician.VisibleIndex = 9;
            this.colPediatrician.Width = 85;
            // 
            // colSeanceNote
            // 
            this.colSeanceNote.Caption = "Seans Notu";
            this.colSeanceNote.FieldName = "SeanceNote";
            this.colSeanceNote.ListDescription = "";
            this.colSeanceNote.ListType = "";
            this.colSeanceNote.Name = "colSeanceNote";
            this.colSeanceNote.OptionsColumn.AllowEdit = false;
            this.colSeanceNote.OptionsColumn.FixedWidth = true;
            this.colSeanceNote.OptionsColumn.ReadOnly = true;
            this.colSeanceNote.Visible = true;
            this.colSeanceNote.VisibleIndex = 8;
            this.colSeanceNote.Width = 85;
            // 
            // colSeanceDate
            // 
            this.colSeanceDate.Caption = "Seans T.";
            this.colSeanceDate.DisplayFormat.FormatString = "dd.MM.yyyy";
            this.colSeanceDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colSeanceDate.FieldName = "SeanceDate";
            this.colSeanceDate.ListDescription = "";
            this.colSeanceDate.ListType = "";
            this.colSeanceDate.Name = "colSeanceDate";
            this.colSeanceDate.OptionsColumn.AllowEdit = false;
            this.colSeanceDate.OptionsColumn.FixedWidth = true;
            this.colSeanceDate.OptionsColumn.ReadOnly = true;
            this.colSeanceDate.Visible = true;
            this.colSeanceDate.VisibleIndex = 7;
            this.colSeanceDate.Width = 85;
            // 
            // colSeanceTime
            // 
            this.colSeanceTime.Caption = "Seans Saati";
            this.colSeanceTime.FieldName = "SeanceTime";
            this.colSeanceTime.ListDescription = "";
            this.colSeanceTime.ListType = "";
            this.colSeanceTime.Name = "colSeanceTime";
            this.colSeanceTime.OptionsColumn.AllowEdit = false;
            this.colSeanceTime.OptionsColumn.ReadOnly = true;
            this.colSeanceTime.Width = 85;
            // 
            // colAdvisor
            // 
            this.colAdvisor.Caption = "Danışman";
            this.colAdvisor.FieldName = "Advisor";
            this.colAdvisor.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colAdvisor.ListDescription = "";
            this.colAdvisor.ListType = "";
            this.colAdvisor.Name = "colAdvisor";
            this.colAdvisor.OptionsColumn.AllowEdit = false;
            this.colAdvisor.OptionsColumn.FixedWidth = true;
            this.colAdvisor.OptionsColumn.ReadOnly = true;
            this.colAdvisor.Visible = true;
            this.colAdvisor.VisibleIndex = 2;
            this.colAdvisor.Width = 85;
            // 
            // colFather
            // 
            this.colFather.Caption = "Baba";
            this.colFather.FieldName = "Father";
            this.colFather.ListDescription = "";
            this.colFather.ListType = "";
            this.colFather.Name = "colFather";
            this.colFather.OptionsColumn.AllowEdit = false;
            this.colFather.OptionsColumn.FixedWidth = true;
            this.colFather.OptionsColumn.ReadOnly = true;
            this.colFather.Visible = true;
            this.colFather.VisibleIndex = 10;
            this.colFather.Width = 85;
            // 
            // colMother
            // 
            this.colMother.Caption = "Anne";
            this.colMother.FieldName = "Mother";
            this.colMother.ListDescription = "";
            this.colMother.ListType = "";
            this.colMother.Name = "colMother";
            this.colMother.OptionsColumn.AllowEdit = false;
            this.colMother.OptionsColumn.FixedWidth = true;
            this.colMother.OptionsColumn.ReadOnly = true;
            this.colMother.Visible = true;
            this.colMother.VisibleIndex = 11;
            this.colMother.Width = 85;
            // 
            // colReasonValueList
            // 
            this.colReasonValueList.Caption = "Gelme Nedenleri";
            this.colReasonValueList.FieldName = "ReasonValueList";
            this.colReasonValueList.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colReasonValueList.ListDescription = "";
            this.colReasonValueList.ListType = "";
            this.colReasonValueList.Name = "colReasonValueList";
            this.colReasonValueList.OptionsColumn.AllowEdit = false;
            this.colReasonValueList.OptionsColumn.FixedWidth = true;
            this.colReasonValueList.OptionsColumn.ReadOnly = true;
            this.colReasonValueList.Visible = true;
            this.colReasonValueList.VisibleIndex = 3;
            this.colReasonValueList.Width = 91;
            // 
            // colFatherHome
            // 
            this.colFatherHome.Caption = "Baba Ev";
            this.colFatherHome.FieldName = "FatherHome";
            this.colFatherHome.ListDescription = "";
            this.colFatherHome.ListType = "";
            this.colFatherHome.Name = "colFatherHome";
            this.colFatherHome.OptionsColumn.FixedWidth = true;
            this.colFatherHome.Visible = true;
            this.colFatherHome.VisibleIndex = 12;
            // 
            // colFatherMobile
            // 
            this.colFatherMobile.Caption = "Baba Cep";
            this.colFatherMobile.FieldName = "FatherMobile";
            this.colFatherMobile.ListDescription = "";
            this.colFatherMobile.ListType = "";
            this.colFatherMobile.Name = "colFatherMobile";
            this.colFatherMobile.OptionsColumn.FixedWidth = true;
            this.colFatherMobile.Visible = true;
            this.colFatherMobile.VisibleIndex = 13;
            // 
            // colFatherBusiness
            // 
            this.colFatherBusiness.Caption = "Baba İş";
            this.colFatherBusiness.FieldName = "FatherBusiness";
            this.colFatherBusiness.ListDescription = "";
            this.colFatherBusiness.ListType = "";
            this.colFatherBusiness.Name = "colFatherBusiness";
            this.colFatherBusiness.OptionsColumn.FixedWidth = true;
            this.colFatherBusiness.Visible = true;
            this.colFatherBusiness.VisibleIndex = 14;
            // 
            // colFatherEmail
            // 
            this.colFatherEmail.Caption = "Baba Email";
            this.colFatherEmail.FieldName = "FatherEmail";
            this.colFatherEmail.ListDescription = "";
            this.colFatherEmail.ListType = "";
            this.colFatherEmail.Name = "colFatherEmail";
            this.colFatherEmail.OptionsColumn.FixedWidth = true;
            this.colFatherEmail.Visible = true;
            this.colFatherEmail.VisibleIndex = 15;
            // 
            // colMotherHome
            // 
            this.colMotherHome.Caption = "Anne Ev";
            this.colMotherHome.FieldName = "MotherHome";
            this.colMotherHome.ListDescription = "";
            this.colMotherHome.ListType = "";
            this.colMotherHome.Name = "colMotherHome";
            this.colMotherHome.OptionsColumn.FixedWidth = true;
            this.colMotherHome.Visible = true;
            this.colMotherHome.VisibleIndex = 16;
            // 
            // colMotherMobile
            // 
            this.colMotherMobile.Caption = "Anne Cep";
            this.colMotherMobile.FieldName = "MotherMobile";
            this.colMotherMobile.ListDescription = "";
            this.colMotherMobile.ListType = "";
            this.colMotherMobile.Name = "colMotherMobile";
            this.colMotherMobile.OptionsColumn.FixedWidth = true;
            this.colMotherMobile.Visible = true;
            this.colMotherMobile.VisibleIndex = 17;
            // 
            // colMotherBusiness
            // 
            this.colMotherBusiness.Caption = "Anne İş";
            this.colMotherBusiness.FieldName = "MotherBusiness";
            this.colMotherBusiness.ListDescription = "";
            this.colMotherBusiness.ListType = "";
            this.colMotherBusiness.Name = "colMotherBusiness";
            this.colMotherBusiness.OptionsColumn.FixedWidth = true;
            this.colMotherBusiness.Visible = true;
            this.colMotherBusiness.VisibleIndex = 18;
            // 
            // colMotherEmail
            // 
            this.colMotherEmail.Caption = "Anne Email";
            this.colMotherEmail.FieldName = "MotherEmail";
            this.colMotherEmail.ListDescription = "";
            this.colMotherEmail.ListType = "";
            this.colMotherEmail.Name = "colMotherEmail";
            this.colMotherEmail.OptionsColumn.FixedWidth = true;
            this.colMotherEmail.Visible = true;
            this.colMotherEmail.VisibleIndex = 19;
            // 
            // lkGender
            // 
            this.lkGender.AutoHeight = false;
            this.lkGender.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkGender.Name = "lkGender";
            // 
            // btnSelect
            // 
            this.btnSelect.AutoHeight = false;
            editorButtonImageOptions3.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions3.Image")));
            editorButtonImageOptions3.Location = DevExpress.XtraEditors.ImageLocation.Default;
            toolTipItem3.Text = "Seç";
            superToolTip3.Items.Add(toolTipItem3);
            this.btnSelect.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "&Detay", -1, true, true, true, editorButtonImageOptions3, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "Seç", null, superToolTip3)});
            this.btnSelect.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // cblReasonList
            // 
            this.cblReasonList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cblReasonList.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cblReasonList.Appearance.Options.UseFont = true;
            this.cblReasonList.Appearance.Options.UseTextOptions = true;
            this.cblReasonList.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.cblReasonList.CheckOnClick = true;
            this.cblReasonList.Cursor = System.Windows.Forms.Cursors.Default;
            this.cblReasonList.HorizontalScrollbar = true;
            this.cblReasonList.HotTrackItems = true;
            this.cblReasonList.IncrementalSearch = true;
            this.cblReasonList.ItemAutoHeight = true;
            this.cblReasonList.Location = new System.Drawing.Point(12, 104);
            this.cblReasonList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cblReasonList.MultiColumn = true;
            this.cblReasonList.Name = "cblReasonList";
            this.cblReasonList.Padding = new System.Windows.Forms.Padding(25);
            this.cblReasonList.Size = new System.Drawing.Size(753, 194);
            this.cblReasonList.TabIndex = 94;
            this.cblReasonList.Tag = "ReasonId";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(1078, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 21);
            this.label1.TabIndex = 112;
            this.label1.Text = "Doğum Yılı Seçiniz:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(795, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 21);
            this.label2.TabIndex = 114;
            this.label2.Text = "Başvuru Yılı Seçiniz:";
            // 
            // cblFirstYears
            // 
            this.cblFirstYears.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cblFirstYears.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cblFirstYears.Appearance.Options.UseFont = true;
            this.cblFirstYears.Appearance.Options.UseTextOptions = true;
            this.cblFirstYears.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.cblFirstYears.CheckOnClick = true;
            this.cblFirstYears.Cursor = System.Windows.Forms.Cursors.Default;
            this.cblFirstYears.HorizontalScrollbar = true;
            this.cblFirstYears.HotTrackItems = true;
            this.cblFirstYears.IncrementalSearch = true;
            this.cblFirstYears.ItemAutoHeight = true;
            this.cblFirstYears.Location = new System.Drawing.Point(771, 104);
            this.cblFirstYears.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cblFirstYears.Name = "cblFirstYears";
            this.cblFirstYears.Padding = new System.Windows.Forms.Padding(5);
            this.cblFirstYears.Size = new System.Drawing.Size(305, 194);
            this.cblFirstYears.TabIndex = 94;
            this.cblFirstYears.Tag = "ReasonId";
            // 
            // cblBirthYears
            // 
            this.cblBirthYears.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cblBirthYears.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cblBirthYears.Appearance.Options.UseFont = true;
            this.cblBirthYears.Appearance.Options.UseTextOptions = true;
            this.cblBirthYears.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.cblBirthYears.CheckOnClick = true;
            this.cblBirthYears.Cursor = System.Windows.Forms.Cursors.Default;
            this.cblBirthYears.HorizontalScrollbar = true;
            this.cblBirthYears.HotTrackItems = true;
            this.cblBirthYears.IncrementalSearch = true;
            this.cblBirthYears.ItemAutoHeight = true;
            this.cblBirthYears.Location = new System.Drawing.Point(1082, 104);
            this.cblBirthYears.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cblBirthYears.Name = "cblBirthYears";
            this.cblBirthYears.Padding = new System.Windows.Forms.Padding(5);
            this.cblBirthYears.Size = new System.Drawing.Size(261, 194);
            this.cblBirthYears.TabIndex = 119;
            this.cblBirthYears.Tag = "ReasonId";
            // 
            // separatorControl1
            // 
            this.separatorControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.separatorControl1.Location = new System.Drawing.Point(12, 52);
            this.separatorControl1.Name = "separatorControl1";
            this.separatorControl1.Size = new System.Drawing.Size(1331, 21);
            this.separatorControl1.TabIndex = 124;
            // 
            // frmReasonsReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1349, 719);
            this.Controls.Add(this.separatorControl1);
            this.Controls.Add(this.cblBirthYears);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cblFirstYears);
            this.Controls.Add(this.cblReasonList);
            this.Controls.Add(this.gcResult);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmReasonsReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gelme Nedenlerine Göre Raporlama ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkGender)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cblReasonList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cblFirstYears)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cblBirthYears)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnSearch;
        private DevExpress.XtraBars.BarButtonItem btnExport;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label lblYear;
        private Ekip.Win.Framework.DevEx.Grid.DxGridControl gcResult;
        private Ekip.Win.Framework.DevEx.Grid.DxGridView gwResult;
        private Ekip.Win.Framework.DevEx.Grid.DxGridColumn colRowNumber;
        private Ekip.Win.Framework.DevEx.Grid.DxGridColumn colFileNumber;
        private Ekip.Win.Framework.DevEx.Grid.DxGridColumn colFirstContactDate;
        private Ekip.Win.Framework.DevEx.Grid.DxGridColumn colClientName;
        private Ekip.Win.Framework.DevEx.Grid.DxGridColumn colGender;
        private Ekip.Win.Framework.DevEx.Grid.DxGridColumn colBirthDate;
        private Ekip.Win.Framework.DevEx.Grid.DxGridColumn colPediatrician;
        private Ekip.Win.Framework.DevEx.Grid.DxGridColumn colSeanceNote;
        private Ekip.Win.Framework.DevEx.Grid.DxGridColumn colSeanceDate;
        private Ekip.Win.Framework.DevEx.Grid.DxGridColumn colSeanceTime;
        private Ekip.Win.Framework.DevEx.Grid.DxGridColumn colAdvisor;
        private Ekip.Win.Framework.DevEx.Grid.DxGridColumn colFather;
        private Ekip.Win.Framework.DevEx.Grid.DxGridColumn colMother;
        private Ekip.Win.Framework.DevEx.Grid.DxGridColumn colReasonValueList;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lkGender;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnSelect;
        private DevExpress.XtraEditors.CheckedListBoxControl cblReasonList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Ekip.Win.Framework.DevEx.Grid.DxGridColumn colFatherHome;
        private Ekip.Win.Framework.DevEx.Grid.DxGridColumn colFatherMobile;
        private Ekip.Win.Framework.DevEx.Grid.DxGridColumn colFatherBusiness;
        private Ekip.Win.Framework.DevEx.Grid.DxGridColumn colFatherEmail;
        private Ekip.Win.Framework.DevEx.Grid.DxGridColumn colMotherHome;
        private Ekip.Win.Framework.DevEx.Grid.DxGridColumn colMotherMobile;
        private Ekip.Win.Framework.DevEx.Grid.DxGridColumn colMotherBusiness;
        private Ekip.Win.Framework.DevEx.Grid.DxGridColumn colMotherEmail;
        private DevExpress.XtraEditors.CheckedListBoxControl cblFirstYears;
        private DevExpress.XtraBars.BarButtonItem btnPrintPreview;
        private DevExpress.XtraEditors.CheckedListBoxControl cblBirthYears;
        private DevExpress.XtraEditors.SeparatorControl separatorControl1;
    }
}