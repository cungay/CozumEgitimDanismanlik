namespace Ekip.WinApp.Reports
{
    partial class frmAdvisorReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdvisorReport));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.ToolTipSeparatorItem toolTipSeparatorItem1 = new DevExpress.Utils.ToolTipSeparatorItem();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.ToolTipSeparatorItem toolTipSeparatorItem2 = new DevExpress.Utils.ToolTipSeparatorItem();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem4 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem7 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem4 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.ToolTipSeparatorItem toolTipSeparatorItem4 = new DevExpress.Utils.ToolTipSeparatorItem();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem8 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem5 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.ToolTipSeparatorItem toolTipSeparatorItem3 = new DevExpress.Utils.ToolTipSeparatorItem();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem6 = new DevExpress.Utils.ToolTipTitleItem();
            this.lblResult = new System.Windows.Forms.Label();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnSearch = new DevExpress.XtraBars.BarButtonItem();
            this.btnExport = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrintPreview = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblYear = new System.Windows.Forms.Label();
            this.gcResult = new Win.Framework.DevEx.Grid.DxGridControl();
            this.gwResult = new Win.Framework.DevEx.Grid.DxGridView();
            this.colRowNumber = new Ekip.Win.Framework.DevEx.Grid.DxGridColumn();
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
            this.repositoryItemMemoExEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.lbAdvisors = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.separatorControl1 = new DevExpress.XtraEditors.SeparatorControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbAdvisors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblResult
            // 
            this.lblResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Underline);
            this.lblResult.Location = new System.Drawing.Point(10, 321);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(283, 24);
            this.lblResult.TabIndex = 71;
            this.lblResult.Text = "Toplam Danışan Sayısı: 0 Adet";
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
            this.btnSearch.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.ImageOptions.LargeImage")));
            this.btnSearch.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F1);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.ShowItemShortcut = DevExpress.Utils.DefaultBoolean.True;
            toolTipTitleItem1.Text = "Ara";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "Aramayı başlatmak için tıklayın.";
            toolTipTitleItem2.LeftIndent = 6;
            toolTipTitleItem2.Text = "Kısayol: F1";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            superToolTip1.Items.Add(toolTipSeparatorItem1);
            superToolTip1.Items.Add(toolTipTitleItem2);
            this.btnSearch.SuperTip = superToolTip1;
            this.btnSearch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSearch_ItemClick);
            // 
            // btnExport
            // 
            this.btnExport.Border = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.btnExport.Caption = "Farklı Kaydet";
            this.btnExport.Hint = "Farklı Kaydet";
            this.btnExport.Id = 2;
            this.btnExport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.ImageOptions.Image")));
            this.btnExport.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            this.btnExport.Name = "btnExport";
            toolTipTitleItem3.Text = "Farklı Kaydet";
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = "Arama sonucunu kaydetmek için tıklayınız.";
            toolTipTitleItem4.LeftIndent = 6;
            toolTipTitleItem4.Text = "Kısayol: Ctrl + S";
            superToolTip2.Items.Add(toolTipTitleItem3);
            superToolTip2.Items.Add(toolTipItem2);
            superToolTip2.Items.Add(toolTipSeparatorItem2);
            superToolTip2.Items.Add(toolTipTitleItem4);
            this.btnExport.SuperTip = superToolTip2;
            this.btnExport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExport_ItemClick);
            // 
            // btnClose
            // 
            this.btnClose.Border = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.btnClose.Caption = "Kapat";
            this.btnClose.Hint = "Kapat";
            this.btnClose.Id = 1;
            this.btnClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.ImageOptions.Image")));
            this.btnClose.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F4));
            this.btnClose.Name = "btnClose";
            toolTipTitleItem7.Text = "Kapat";
            toolTipItem4.LeftIndent = 6;
            toolTipItem4.Text = "Ekranı kapatmak için tıklayınız.";
            toolTipTitleItem8.LeftIndent = 6;
            toolTipTitleItem8.Text = "Kısayol: Ctrl + F4";
            superToolTip4.Items.Add(toolTipTitleItem7);
            superToolTip4.Items.Add(toolTipItem4);
            superToolTip4.Items.Add(toolTipSeparatorItem4);
            superToolTip4.Items.Add(toolTipTitleItem8);
            this.btnClose.SuperTip = superToolTip4;
            this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClose_ItemClick);
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Caption = "Baskı Önizleme";
            this.btnPrintPreview.Id = 3;
            this.btnPrintPreview.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPrintPreview.ImageOptions.SvgImage")));
            this.btnPrintPreview.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P));
            this.btnPrintPreview.Name = "btnPrintPreview";
            toolTipTitleItem5.Text = "Baskı Önizleme";
            toolTipItem3.LeftIndent = 6;
            toolTipItem3.Text = "Baskı önizleme için tıklayınız.";
            toolTipTitleItem6.LeftIndent = 6;
            toolTipTitleItem6.Text = "Kısayol: Ctrl + P";
            superToolTip3.Items.Add(toolTipTitleItem5);
            superToolTip3.Items.Add(toolTipItem3);
            superToolTip3.Items.Add(toolTipSeparatorItem3);
            superToolTip3.Items.Add(toolTipTitleItem6);
            this.btnPrintPreview.SuperTip = superToolTip3;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlTop.Size = new System.Drawing.Size(1320, 50);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 711);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlBottom.Size = new System.Drawing.Size(1320, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 50);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 661);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1320, 50);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 661);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 689);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1320, 22);
            this.statusStrip1.TabIndex = 77;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblYear.Location = new System.Drawing.Point(8, 85);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(368, 21);
            this.lblYear.TabIndex = 79;
            this.lblYear.Text = "Aşağıdaki listeden danışan seçimi yapınız.";
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
            this.gcResult.Location = new System.Drawing.Point(14, 359);
            this.gcResult.MainView = this.gwResult;
            this.gcResult.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcResult.Name = "gcResult";
            this.gcResult.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoExEdit1});
            this.gcResult.Size = new System.Drawing.Size(1292, 321);
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
            this.colReasonValueList});
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
            this.gwResult.PreviewLineCount = 1;
            this.gwResult.RowHeight = 15;
            this.gwResult.RowSeparatorHeight = 5;
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
            this.colFileNumber.OptionsColumn.AllowFocus = false;
            this.colFileNumber.OptionsColumn.ReadOnly = true;
            this.colFileNumber.OptionsFilter.AllowFilter = false;
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
            this.colFirstContactDate.ListDescription = "";
            this.colFirstContactDate.ListType = "";
            this.colFirstContactDate.Name = "colFirstContactDate";
            this.colFirstContactDate.OptionsColumn.AllowEdit = false;
            this.colFirstContactDate.OptionsColumn.AllowFocus = false;
            this.colFirstContactDate.OptionsColumn.ReadOnly = true;
            this.colFirstContactDate.OptionsFilter.AllowFilter = false;
            this.colFirstContactDate.Visible = true;
            this.colFirstContactDate.VisibleIndex = 2;
            this.colFirstContactDate.Width = 85;
            // 
            // colClientName
            // 
            this.colClientName.Caption = "Danışan";
            this.colClientName.FieldName = "FullName";
            this.colClientName.ListDescription = "";
            this.colClientName.ListType = "";
            this.colClientName.Name = "colClientName";
            this.colClientName.OptionsColumn.AllowEdit = false;
            this.colClientName.OptionsColumn.AllowFocus = false;
            this.colClientName.OptionsColumn.ReadOnly = true;
            this.colClientName.OptionsFilter.AllowFilter = false;
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
            this.colGender.OptionsColumn.AllowFocus = false;
            this.colGender.OptionsColumn.ReadOnly = true;
            this.colGender.OptionsFilter.AllowFilter = false;
            this.colGender.Visible = true;
            this.colGender.VisibleIndex = 3;
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
            this.colBirthDate.OptionsColumn.AllowFocus = false;
            this.colBirthDate.OptionsColumn.ReadOnly = true;
            this.colBirthDate.OptionsFilter.AllowFilter = false;
            this.colBirthDate.Visible = true;
            this.colBirthDate.VisibleIndex = 4;
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
            this.colPediatrician.OptionsColumn.AllowFocus = false;
            this.colPediatrician.OptionsColumn.ReadOnly = true;
            this.colPediatrician.OptionsFilter.AllowFilter = false;
            this.colPediatrician.Visible = true;
            this.colPediatrician.VisibleIndex = 9;
            this.colPediatrician.Width = 85;
            // 
            // colSeanceNote
            // 
            this.colSeanceNote.Caption = "Seans Notu";
            this.colSeanceNote.FieldName = "Note";
            this.colSeanceNote.ListDescription = "";
            this.colSeanceNote.ListType = "";
            this.colSeanceNote.Name = "colSeanceNote";
            this.colSeanceNote.OptionsColumn.AllowEdit = false;
            this.colSeanceNote.OptionsColumn.AllowFocus = false;
            this.colSeanceNote.OptionsColumn.ReadOnly = true;
            this.colSeanceNote.OptionsFilter.AllowFilter = false;
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
            this.colSeanceDate.OptionsColumn.AllowFocus = false;
            this.colSeanceDate.OptionsColumn.ReadOnly = true;
            this.colSeanceDate.OptionsFilter.AllowFilter = false;
            this.colSeanceDate.Visible = true;
            this.colSeanceDate.VisibleIndex = 5;
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
            this.colSeanceTime.OptionsColumn.AllowFocus = false;
            this.colSeanceTime.OptionsColumn.ReadOnly = true;
            this.colSeanceTime.OptionsFilter.AllowFilter = false;
            this.colSeanceTime.Visible = true;
            this.colSeanceTime.VisibleIndex = 6;
            this.colSeanceTime.Width = 85;
            // 
            // colAdvisor
            // 
            this.colAdvisor.Caption = "Danışman";
            this.colAdvisor.FieldName = "Advisor";
            this.colAdvisor.ListDescription = "";
            this.colAdvisor.ListType = "";
            this.colAdvisor.Name = "colAdvisor";
            this.colAdvisor.OptionsColumn.AllowEdit = false;
            this.colAdvisor.OptionsColumn.AllowFocus = false;
            this.colAdvisor.OptionsColumn.ReadOnly = true;
            this.colAdvisor.OptionsFilter.AllowFilter = false;
            this.colAdvisor.Visible = true;
            this.colAdvisor.VisibleIndex = 7;
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
            this.colFather.OptionsColumn.AllowFocus = false;
            this.colFather.OptionsColumn.ReadOnly = true;
            this.colFather.OptionsFilter.AllowFilter = false;
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
            this.colMother.OptionsColumn.AllowFocus = false;
            this.colMother.OptionsColumn.ReadOnly = true;
            this.colMother.OptionsFilter.AllowFilter = false;
            this.colMother.Visible = true;
            this.colMother.VisibleIndex = 11;
            this.colMother.Width = 85;
            // 
            // colReasonValueList
            // 
            this.colReasonValueList.Caption = "Gelme Nedenleri";
            this.colReasonValueList.ColumnEdit = this.repositoryItemMemoExEdit1;
            this.colReasonValueList.FieldName = "ReasonValueList";
            this.colReasonValueList.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.colReasonValueList.ListDescription = "";
            this.colReasonValueList.ListType = "";
            this.colReasonValueList.Name = "colReasonValueList";
            this.colReasonValueList.OptionsFilter.AllowFilter = false;
            this.colReasonValueList.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.colReasonValueList.Visible = true;
            this.colReasonValueList.VisibleIndex = 12;
            this.colReasonValueList.Width = 91;
            // 
            // repositoryItemMemoExEdit1
            // 
            this.repositoryItemMemoExEdit1.AutoHeight = false;
            this.repositoryItemMemoExEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemMemoExEdit1.Name = "repositoryItemMemoExEdit1";
            // 
            // lbAdvisors
            // 
            this.lbAdvisors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAdvisors.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbAdvisors.Appearance.Options.UseFont = true;
            this.lbAdvisors.CheckOnClick = true;
            this.lbAdvisors.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbAdvisors.Location = new System.Drawing.Point(12, 119);
            this.lbAdvisors.MultiColumn = true;
            this.lbAdvisors.Name = "lbAdvisors";
            this.lbAdvisors.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbAdvisors.Size = new System.Drawing.Size(1294, 180);
            this.lbAdvisors.TabIndex = 104;
            // 
            // separatorControl1
            // 
            this.separatorControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.separatorControl1.Location = new System.Drawing.Point(2, 50);
            this.separatorControl1.Name = "separatorControl1";
            this.separatorControl1.Size = new System.Drawing.Size(1308, 21);
            this.separatorControl1.TabIndex = 109;
            // 
            // frmAdvisorReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1320, 711);
            this.Controls.Add(this.separatorControl1);
            this.Controls.Add(this.lbAdvisors);
            this.Controls.Add(this.gcResult);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmAdvisorReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danışmana Göre Raporlama ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbAdvisors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblResult;
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
        private DevExpress.XtraEditors.CheckedListBoxControl lbAdvisors;
        private DevExpress.XtraEditors.SeparatorControl separatorControl1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit1;
        private DevExpress.XtraBars.BarButtonItem btnPrintPreview;
    }
}