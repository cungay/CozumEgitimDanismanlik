namespace Ekip.WinApp.Modules
{
    partial class QuestionForm
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
            this.gcSeanse = new Ekip.Win.Framework.DevEx.Grid.DxGridControl();
            this.gwSeance = new Ekip.Win.Framework.DevEx.Grid.DxGridView();
            this.colSeanceDate = new Ekip.Win.Framework.DevEx.Grid.DxGridColumn();
            this.colSeanceTime = new Ekip.Win.Framework.DevEx.Grid.DxGridColumn();
            this.colSenaceNote = new Ekip.Win.Framework.DevEx.Grid.DxGridColumn();
            this.colSeanceStatus = new Ekip.Win.Framework.DevEx.Grid.DxGridColumn();
            this.colAdvisorName = new Ekip.Win.Framework.DevEx.Grid.DxGridColumn();
            this.rlkAdvisor = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colReason = new Ekip.Win.Framework.DevEx.Grid.DxGridColumn();
            this.webEditor = new System.Windows.Forms.WebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcSeanse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwSeance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkAdvisor)).BeginInit();
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
            this.splitContainerControl1.Panel1.Controls.Add(this.gcSeanse);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.webEditor);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(807, 626);
            this.splitContainerControl1.SplitterPosition = 137;
            this.splitContainerControl1.TabIndex = 8;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gcSeanse
            // 
            this.gcSeanse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSeanse.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcSeanse.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcSeanse.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcSeanse.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcSeanse.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcSeanse.Location = new System.Drawing.Point(0, 0);
            this.gcSeanse.MainView = this.gwSeance;
            this.gcSeanse.Name = "gcSeanse";
            this.gcSeanse.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlkAdvisor});
            this.gcSeanse.Size = new System.Drawing.Size(807, 137);
            this.gcSeanse.TabIndex = 9;
            this.gcSeanse.UseEmbeddedNavigator = true;
            this.gcSeanse.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gwSeance});
            // 
            // gwSeance
            // 
            this.gwSeance.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSeanceDate,
            this.colSeanceTime,
            this.colSenaceNote,
            this.colSeanceStatus,
            this.colAdvisorName,
            this.colReason});
            this.gwSeance.EmptyDataMessage = "";
            this.gwSeance.GridControl = this.gcSeanse;
            this.gwSeance.IndicatorWidth = 30;
            this.gwSeance.Name = "gwSeance";
            this.gwSeance.OptionsBehavior.Editable = false;
            this.gwSeance.OptionsNavigation.AutoFocusNewRow = true;
            this.gwSeance.OptionsNavigation.EnterMoveNextColumn = true;
            this.gwSeance.OptionsView.ShowGroupPanel = false;
            this.gwSeance.OptionsView.ShowPreview = true;
            this.gwSeance.OptionsView.ShowPreviewRowLines = DevExpress.Utils.DefaultBoolean.True;
            this.gwSeance.OptionsView.ShowViewCaption = true;
            this.gwSeance.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel;
            this.gwSeance.PreviewFieldName = "ReasonValueList";
            this.gwSeance.PreviewIndent = 1;
            this.gwSeance.PreviewLineCount = 1;
            this.gwSeance.ViewCaption = "Seans Bilgileri";
            // 
            // colSeanceDate
            // 
            this.colSeanceDate.Caption = "Seans Tarihi";
            this.colSeanceDate.FieldName = "SeanceDate";
            this.colSeanceDate.ListDescription = "";
            this.colSeanceDate.ListType = "";
            this.colSeanceDate.Name = "colSeanceDate";
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
            this.colSeanceTime.Visible = true;
            this.colSeanceTime.VisibleIndex = 1;
            this.colSeanceTime.Width = 95;
            // 
            // colSenaceNote
            // 
            this.colSenaceNote.Caption = "Notlar";
            this.colSenaceNote.FieldName = "Note";
            this.colSenaceNote.ListDescription = "";
            this.colSenaceNote.ListType = "";
            this.colSenaceNote.Name = "colSenaceNote";
            this.colSenaceNote.Visible = true;
            this.colSenaceNote.VisibleIndex = 4;
            this.colSenaceNote.Width = 157;
            // 
            // colSeanceStatus
            // 
            this.colSeanceStatus.Caption = "Seans Durumu";
            this.colSeanceStatus.FieldName = "Status";
            this.colSeanceStatus.ListDescription = "";
            this.colSeanceStatus.ListType = "SeanceStatus";
            this.colSeanceStatus.Name = "colSeanceStatus";
            this.colSeanceStatus.Visible = true;
            this.colSeanceStatus.VisibleIndex = 2;
            this.colSeanceStatus.Width = 109;
            // 
            // colAdvisorName
            // 
            this.colAdvisorName.Caption = "Uzman";
            this.colAdvisorName.ColumnEdit = this.rlkAdvisor;
            this.colAdvisorName.FieldName = "AdvisorId";
            this.colAdvisorName.ListDescription = "";
            this.colAdvisorName.ListType = "";
            this.colAdvisorName.Name = "colAdvisorName";
            this.colAdvisorName.Visible = true;
            this.colAdvisorName.VisibleIndex = 3;
            this.colAdvisorName.Width = 145;
            // 
            // rlkAdvisor
            // 
            this.rlkAdvisor.AutoHeight = false;
            this.rlkAdvisor.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlkAdvisor.Name = "rlkAdvisor";
            // 
            // colReason
            // 
            this.colReason.Caption = "Gelme Nedeni";
            this.colReason.FieldName = "ReasonValueList";
            this.colReason.ListDescription = "";
            this.colReason.ListType = "";
            this.colReason.Name = "colReason";
            this.colReason.Visible = true;
            this.colReason.VisibleIndex = 5;
            this.colReason.Width = 218;
            // 
            // webEditor
            // 
            this.webEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webEditor.Location = new System.Drawing.Point(0, 0);
            this.webEditor.MinimumSize = new System.Drawing.Size(20, 20);
            this.webEditor.Name = "webEditor";
            this.webEditor.Size = new System.Drawing.Size(807, 483);
            this.webEditor.TabIndex = 13;
            // 
            // QuestionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "QuestionForm";
            this.Size = new System.Drawing.Size(807, 626);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcSeanse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwSeance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkAdvisor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private System.Windows.Forms.WebBrowser webEditor;
        private Ekip.Win.Framework.DevEx.Grid.DxGridControl gcSeanse;
        private Ekip.Win.Framework.DevEx.Grid.DxGridView gwSeance;
        private Ekip.Win.Framework.DevEx.Grid.DxGridColumn colSeanceDate;
        private Ekip.Win.Framework.DevEx.Grid.DxGridColumn colSeanceTime;
        private Ekip.Win.Framework.DevEx.Grid.DxGridColumn colSenaceNote;
        private Ekip.Win.Framework.DevEx.Grid.DxGridColumn colSeanceStatus;
        private Ekip.Win.Framework.DevEx.Grid.DxGridColumn colAdvisorName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlkAdvisor;
        private Ekip.Win.Framework.DevEx.Grid.DxGridColumn colReason;
       

    }
}
