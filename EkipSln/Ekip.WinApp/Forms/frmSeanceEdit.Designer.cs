namespace Ekip.WinApp.Forms
{
    partial class frmSeanceEdit
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
            this.txtSeanceDate = new DevExpress.XtraEditors.DateEdit();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnAccept = new DevExpress.XtraEditors.SimpleButton();
            this.cblReasonList = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.txtSeanceTime = new DevExpress.XtraEditors.TimeSpanEdit();
            this.lkAdvisor = new Win.Framework.DevEx.Editors.DxLookUpEdit();
            this.lkSeanceStatus = new Win.Framework.DevEx.Editors.DxLookUpEdit();
            this.txtNot = new DevExpress.XtraEditors.MemoEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
            this.simpleSeparator2 = new DevExpress.XtraLayout.SimpleSeparator();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleSeparator3 = new DevExpress.XtraLayout.SimpleSeparator();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeanceDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeanceDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cblReasonList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeanceTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkAdvisor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkSeanceStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNot.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSeanceDate
            // 
            this.txtSeanceDate.EditValue = new System.DateTime(2013, 4, 15, 0, 0, 0, 0);
            this.txtSeanceDate.EnterMoveNextControl = true;
            this.txtSeanceDate.Location = new System.Drawing.Point(119, 16);
            this.txtSeanceDate.Name = "txtSeanceDate";
            this.txtSeanceDate.Properties.AllowMouseWheel = false;
            this.txtSeanceDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtSeanceDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtSeanceDate.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.TouchUI;
            this.txtSeanceDate.Properties.Mask.EditMask = "dd.MM.yyyy";
            this.txtSeanceDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtSeanceDate.Properties.ValidateOnEnterKey = true;
            this.txtSeanceDate.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.txtSeanceDate.Size = new System.Drawing.Size(601, 22);
            this.txtSeanceDate.StyleController = this.layoutControl1;
            this.txtSeanceDate.TabIndex = 1;
            this.txtSeanceDate.Tag = "SeanceDate";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutControl1.Controls.Add(this.btnCancel);
            this.layoutControl1.Controls.Add(this.btnAccept);
            this.layoutControl1.Controls.Add(this.cblReasonList);
            this.layoutControl1.Controls.Add(this.txtSeanceDate);
            this.layoutControl1.Controls.Add(this.txtSeanceTime);
            this.layoutControl1.Controls.Add(this.lkAdvisor);
            this.layoutControl1.Controls.Add(this.lkSeanceStatus);
            this.layoutControl1.Controls.Add(this.txtNot);
            this.layoutControl1.Location = new System.Drawing.Point(10, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.AllowHandleDeleteKey = false;
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(718, 278, 562, 519);
            this.layoutControl1.OptionsCustomizationForm.SnapMode = DevExpress.Utils.Controls.SnapMode.None;
            this.layoutControl1.OptionsView.DrawItemBorders = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(736, 734);
            this.layoutControl1.TabIndex = 17;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(611, 691);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 27);
            this.btnCancel.StyleController = this.layoutControl1;
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "&Vazgeç";
            this.btnCancel.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAccept.Location = new System.Drawing.Point(493, 691);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(102, 27);
            this.btnAccept.StyleController = this.layoutControl1;
            this.btnAccept.TabIndex = 4;
            this.btnAccept.Text = "&Uygula";
            // 
            // cblReasonList
            // 
            this.cblReasonList.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cblReasonList.Appearance.Options.UseFont = true;
            this.cblReasonList.Appearance.Options.UseTextOptions = true;
            this.cblReasonList.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.cblReasonList.CheckOnClick = true;
            this.cblReasonList.ColumnWidth = 500;
            this.cblReasonList.Cursor = System.Windows.Forms.Cursors.Default;
            this.cblReasonList.HorizontalScrollbar = true;
            this.cblReasonList.HotTrackItems = true;
            this.cblReasonList.IncrementalSearch = true;
            this.cblReasonList.ItemAutoHeight = true;
            this.cblReasonList.Location = new System.Drawing.Point(16, 161);
            this.cblReasonList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cblReasonList.MultiColumn = true;
            this.cblReasonList.Name = "cblReasonList";
            this.cblReasonList.Size = new System.Drawing.Size(704, 221);
            this.cblReasonList.StyleController = this.layoutControl1;
            this.cblReasonList.TabIndex = 5;
            this.cblReasonList.Tag = "ReasonId";
            // 
            // txtSeanceTime
            // 
            this.txtSeanceTime.EditValue = System.TimeSpan.Parse("734970.00:00:00");
            this.txtSeanceTime.EnterMoveNextControl = true;
            this.txtSeanceTime.Location = new System.Drawing.Point(119, 44);
            this.txtSeanceTime.Name = "txtSeanceTime";
            this.txtSeanceTime.Properties.AllowEditDays = false;
            this.txtSeanceTime.Properties.AllowEditSeconds = false;
            this.txtSeanceTime.Properties.AllowMouseWheel = false;
            this.txtSeanceTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtSeanceTime.Properties.Mask.EditMask = "\\d?\\d:\\d\\d";
            this.txtSeanceTime.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular;
            this.txtSeanceTime.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtSeanceTime.Properties.ValidateOnEnterKey = true;
            this.txtSeanceTime.Size = new System.Drawing.Size(601, 22);
            this.txtSeanceTime.StyleController = this.layoutControl1;
            this.txtSeanceTime.TabIndex = 2;
            this.txtSeanceTime.Tag = "SeanceTime";
            // 
            // lkAdvisor
            // 
            this.lkAdvisor.EnterMoveNextControl = true;
            this.lkAdvisor.Location = new System.Drawing.Point(119, 72);
            this.lkAdvisor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lkAdvisor.Name = "lkAdvisor";
            this.lkAdvisor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkAdvisor.Properties.ListDescription = "";
            this.lkAdvisor.Properties.ListType = "";
            this.lkAdvisor.Properties.ValidateOnEnterKey = true;
            this.lkAdvisor.Size = new System.Drawing.Size(601, 22);
            this.lkAdvisor.StyleController = this.layoutControl1;
            this.lkAdvisor.TabIndex = 3;
            this.lkAdvisor.Tag = "AdvisorId";
            // 
            // lkSeanceStatus
            // 
            this.lkSeanceStatus.EnterMoveNextControl = true;
            this.lkSeanceStatus.Location = new System.Drawing.Point(119, 100);
            this.lkSeanceStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lkSeanceStatus.Name = "lkSeanceStatus";
            this.lkSeanceStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkSeanceStatus.Properties.ListDescription = "";
            this.lkSeanceStatus.Properties.ListType = "";
            this.lkSeanceStatus.Properties.ValidateOnEnterKey = true;
            this.lkSeanceStatus.Size = new System.Drawing.Size(601, 22);
            this.lkSeanceStatus.StyleController = this.layoutControl1;
            this.lkSeanceStatus.TabIndex = 4;
            this.lkSeanceStatus.Tag = "SeanceStatusId";
            // 
            // txtNot
            // 
            this.txtNot.Location = new System.Drawing.Point(21, 426);
            this.txtNot.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNot.Name = "txtNot";
            this.txtNot.Properties.ValidateOnEnterKey = true;
            this.txtNot.Size = new System.Drawing.Size(694, 231);
            this.txtNot.StyleController = this.layoutControl1;
            this.txtNot.TabIndex = 6;
            this.txtNot.Tag = "SeanceNotes";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.simpleSeparator2,
            this.emptySpaceItem3,
            this.emptySpaceItem2,
            this.emptySpaceItem1,
            this.layoutControlItem9,
            this.layoutControlItem8,
            this.simpleSeparator3,
            this.simpleSeparator1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup1.Size = new System.Drawing.Size(736, 734);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem1.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem1.Control = this.txtSeanceDate;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(710, 28);
            this.layoutControlItem1.Text = "Seans Tarihi:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(99, 16);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem2.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem2.Control = this.txtSeanceTime;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 28);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(710, 28);
            this.layoutControlItem2.Text = "Seans Saati:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(99, 16);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem3.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem3.Control = this.lkAdvisor;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 56);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(710, 28);
            this.layoutControlItem3.Text = "Danışman:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(99, 16);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem4.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem4.Control = this.lkSeanceStatus;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 84);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(710, 28);
            this.layoutControlItem4.Text = "Seans Durumu:";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(99, 16);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtNot;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 385);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(710, 267);
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem5.Text = "Seans Notları:";
            this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(99, 16);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.cblReasonList;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 125);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(710, 247);
            this.layoutControlItem6.Text = "Gelme Nedenleri:";
            this.layoutControlItem6.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(99, 16);
            // 
            // simpleSeparator1
            // 
            this.simpleSeparator1.AllowHotTrack = false;
            this.simpleSeparator1.Location = new System.Drawing.Point(0, 112);
            this.simpleSeparator1.Name = "simpleSeparator1";
            this.simpleSeparator1.Size = new System.Drawing.Size(710, 13);
            this.simpleSeparator1.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            // 
            // simpleSeparator2
            // 
            this.simpleSeparator2.AllowHotTrack = false;
            this.simpleSeparator2.Location = new System.Drawing.Point(0, 372);
            this.simpleSeparator2.Name = "simpleSeparator2";
            this.simpleSeparator2.Size = new System.Drawing.Size(710, 13);
            this.simpleSeparator2.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem3.Location = new System.Drawing.Point(700, 675);
            this.emptySpaceItem3.MaxSize = new System.Drawing.Size(10, 27);
            this.emptySpaceItem3.MinSize = new System.Drawing.Size(10, 27);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.emptySpaceItem3.Size = new System.Drawing.Size(10, 33);
            this.emptySpaceItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem3.Text = "emptySpaceItem1";
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(585, 675);
            this.emptySpaceItem2.MaxSize = new System.Drawing.Size(10, 27);
            this.emptySpaceItem2.MinSize = new System.Drawing.Size(10, 27);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.emptySpaceItem2.Size = new System.Drawing.Size(10, 33);
            this.emptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 675);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.emptySpaceItem1.Size = new System.Drawing.Size(477, 33);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.btnAccept;
            this.layoutControlItem9.Location = new System.Drawing.Point(477, 675);
            this.layoutControlItem9.MaxSize = new System.Drawing.Size(108, 33);
            this.layoutControlItem9.MinSize = new System.Drawing.Size(108, 33);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(108, 33);
            this.layoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnCancel;
            this.layoutControlItem8.Location = new System.Drawing.Point(595, 675);
            this.layoutControlItem8.MaxSize = new System.Drawing.Size(105, 33);
            this.layoutControlItem8.MinSize = new System.Drawing.Size(105, 33);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(105, 33);
            this.layoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // simpleSeparator3
            // 
            this.simpleSeparator3.AllowHotTrack = false;
            this.simpleSeparator3.Location = new System.Drawing.Point(0, 652);
            this.simpleSeparator3.Name = "simpleSeparator3";
            this.simpleSeparator3.Size = new System.Drawing.Size(710, 23);
            this.simpleSeparator3.Spacing = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnAccept;
            this.layoutControlItem7.Location = new System.Drawing.Point(1231, 584);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(10, 14);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // frmSeanceEdit
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(747, 736);
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSeanceEdit";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seans Bilgileri";
            ((System.ComponentModel.ISupportInitialize)(this.txtSeanceDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeanceDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cblReasonList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeanceTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkAdvisor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkSeanceStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNot.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.DateEdit txtSeanceDate;
        private Ekip.Win.Framework.DevEx.Editors.DxLookUpEdit lkAdvisor;
        private DevExpress.XtraEditors.MemoEdit txtNot;
        private Ekip.Win.Framework.DevEx.Editors.DxLookUpEdit lkSeanceStatus;
        private DevExpress.XtraEditors.CheckedListBoxControl cblReasonList;
        private DevExpress.XtraEditors.TimeSpanEdit txtSeanceTime;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator1;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator2;
        private DevExpress.XtraEditors.SimpleButton btnAccept;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
    }
}