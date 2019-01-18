using System;
using DevExpress.XtraEditors;

namespace Ekip.Framework.UI.XAF
{
    //public enum ExportType { Html, Xml, Xls, Txt, Pdf };

    public partial class BaseModule : XtraUserControl
    {
        private Actions actions;

        public BaseModule()
        {
            InitializeComponent();
            this.actions = new Actions();
            Actions.OnPerformModuleAction += new ActionModuleHandler(DoActionModuleHandler);
            RegisterActions();
        }

        public Actions Actions { get { return actions; } }

        public virtual void UpdateActions()
        {
            //Actions[ActionKeys.Export_HTML].Visible = IsExportTypeSupported(ExportType.Html);
            //Actions[ActionKeys.Export_XML].Enabled = IsExportTypeSupported(ExportType.Xml);
            //Actions[ActionKeys.Export_XLS].Enabled = IsExportTypeSupported(ExportType.Xls);
            //Actions[ActionKeys.Export_Text].Visible = IsExportTypeSupported(ExportType.Txt);
            //Actions[ActionKeys.Export_Pdf].Visible = IsExportTypeSupported(ExportType.Pdf);

            Actions[ActionKeys.Print].Enabled = HasPrinting;
            Actions[ActionKeys.Preview].Enabled = HasPrinting;
            Actions[ActionKeys.Save].Enabled = HasSave;
            Actions[ActionKeys.New].Enabled = HasNew;
            Actions[ActionKeys.Refresh].Enabled = HasRefresh;
            Actions[ActionKeys.Find].Enabled = HasFind;
            Actions[ActionKeys.NextFile].Enabled = HasNavigation;
            Actions[ActionKeys.PrevFile].Enabled = HasNavigation;
            Actions[ActionKeys.LastFile].Enabled = HasNavigation;
            Actions[ActionKeys.FirstFile].Enabled = HasNavigation;
            Actions[ActionKeys.Search].Visible = HasSearch;
            Actions[ActionKeys.Import].Enabled = HasImport;

            //Actions[ActionKeys.ShowClientList].Visible = HasShowClientList;
        }

        protected virtual void RegisterActions()
        {
            Actions.AddSupportedAction(ActionKeys.Export_HTML, new ActionModuleHandler(DoExport));
            Actions.AddSupportedAction(ActionKeys.Export_XML, new ActionModuleHandler(DoExport));
            Actions.AddSupportedAction(ActionKeys.Export_XLS, new ActionModuleHandler(DoExport));
            Actions.AddSupportedAction(ActionKeys.Export_Text, new ActionModuleHandler(DoExport));
            Actions.AddSupportedAction(ActionKeys.Export_Pdf, new ActionModuleHandler(DoExport));

            Actions.AddSupportedAction(ActionKeys.Print, new ActionModuleHandler(DoPrint));
            Actions.AddSupportedAction(ActionKeys.Preview, new ActionModuleHandler(DoPreview));
            Actions.AddSupportedAction(ActionKeys.Save, new ActionModuleHandler(DoSave));
            Actions.AddSupportedAction(ActionKeys.New, new ActionModuleHandler(DoNew));
            Actions.AddSupportedAction(ActionKeys.Refresh, new ActionModuleHandler(DoRefresh));
            Actions.AddSupportedAction(ActionKeys.Find, new ActionModuleHandler(DoFind));
            Actions.AddSupportedAction(ActionKeys.NextFile, new ActionModuleHandler(DoNext));
            Actions.AddSupportedAction(ActionKeys.PrevFile, new ActionModuleHandler(DoPrev));

            Actions.AddSupportedAction(ActionKeys.LastFile, new ActionModuleHandler(DoLast));
            Actions.AddSupportedAction(ActionKeys.FirstFile, new ActionModuleHandler(DoFirst));
            Actions.AddSupportedAction(ActionKeys.Search, new ActionModuleHandler(DoSearch));
            Actions.AddSupportedAction(ActionKeys.Import, new ActionModuleHandler(DoImport));

            //Actions.AddSupportedAction(ActionKeys.ShowClientList, new ActionModuleHandler(DoShowClientList));
        }

        public virtual void InitForm() { }

        protected virtual void DoActionModuleHandler(object key, object sender, EventArgs e) { }

        //protected virtual bool IsExportTypeSupported(ExportType exportType) { return false; }
        //protected virtual void DoExport(ExportType exportType, string AFileName) { }
        protected virtual bool HasPrinting { get { return false; } }

        protected virtual bool HasSave { get { return false; } }

        protected virtual bool HasNew { get { return false; } }

        protected virtual bool HasRefresh { get { return false; } }

        protected virtual bool HasFind { get { return false; } }

        protected virtual bool HasNavigation { get { return false; } }

        protected virtual bool HasSearch { get { return false; } }

        protected virtual bool HasImport { get { return false; } }

        protected virtual bool HasOpenFile { get { return false; } }
        //protected virtual bool HasShowClientList { get { return false; } }

        protected virtual void DoPrint() { }

        protected virtual void DoPreview() { }

        protected virtual void DoSave() { }

        protected virtual void DoNew() { }

        protected virtual void DoRefresh() { }

        protected virtual void DoFind() { }

        protected virtual void DoNext() { }

        protected virtual void DoPrev() { }

        protected virtual void DoFirst() { }

        protected virtual void DoLast() { }

        protected virtual void DoSearch() { }

        protected virtual void DoImport() { }

        //protected virtual void DoShowClientList() { }

        //protected ExportType GetExportTypeByAction(object key)
        //{
        //    if (ActionKeys.Export_XML.Equals(key))
        //        return ExportType.Xml;
        //    if (ActionKeys.Export_XLS.Equals(key))
        //        return ExportType.Xls;
        //    if (ActionKeys.Export_Text.Equals(key))
        //        return ExportType.Txt;
        //    return ExportType.Html;
        //}
        void DoExport(object key, object sender, EventArgs e)
        {
            //ExportType exportType = GetExportTypeByAction(key);
            //SaveFileDialog saveDialog = new SaveFileDialog();
            //saveDialog.DefaultExt = GetExportDefaultExtenstions(exportType);
            //saveDialog.Filter = GetExportFilters(exportType);
            //saveDialog.FileName = "export." + saveDialog.DefaultExt;
            //if (DialogResult.OK == saveDialog.ShowDialog())
            //    DoExport(exportType, saveDialog.FileName);
        }
        void DoPrint(object key, object sender, EventArgs e)
        {
            DoPrint();
        }
        void DoPreview(object key, object sender, EventArgs e) { DoPreview(); }

        //string GetExportDefaultExtenstions(ExportType exportType)
        //{
        //    switch (exportType)
        //    {
        //        case ExportType.Html: return "html";
        //        case ExportType.Xml: return "xml";
        //        case ExportType.Xls: return "xls";
        //        case ExportType.Txt: return "txt";
        //        case ExportType.Pdf: return "pdf";
        //    }
        //    return "";
        //}
        //string GetExportFilters(ExportType exportType)
        //{
        //    switch (exportType)
        //    {
        //        case ExportType.Html: return "HTML File (*.html)|*.html";
        //        case ExportType.Xml: return "XML File (*.xml)|*.xml";
        //        case ExportType.Xls: return "Microsoft Excel 4.0 Worksheet (*.xls)|*.xls";
        //        case ExportType.Txt: return "Text file (*.txt)|*.txt";
        //        case ExportType.Pdf: return "Pdf File (*.pdf)|*.pfd";
        //    }
        //    return "";
        //}

        void DoSave(object key, object sender, EventArgs e) { DoSave(); }

        void DoNew(object key, object sender, EventArgs e) { DoNew(); }

        void DoRefresh(object key, object sender, EventArgs e)
        {
            DoRefresh();
        }

        void DoFind(object key, object sender, EventArgs e) { DoFind(); }

        void DoNext(object key, object sender, EventArgs e) { DoNext(); }

        void DoPrev(object key, object sender, EventArgs e) { DoPrev(); }

        void DoFirst(object key, object sender, EventArgs e) { DoFirst(); }

        void DoLast(object key, object sender, EventArgs e) { DoLast(); }

        void DoSearch(object key, object sender, EventArgs e) { DoSearch(); }

        void DoImport(object key, object sender, EventArgs e) { DoImport(); }

        #region Custom Functions

        //private Image GetImageFromStream(string fileName)
        //{
        //    Image image = null;
        //    Stream stream = StreamExtensions.GetManifestResourceStream(
        //        string.Format("{0}.{1}", "Images", fileName), Assembly.Load("Ekip.WinApp"));
        //    if (stream != null)
        //    {
        //        image = Image.FromStream(stream);
        //    }
        //    return image;
        //}


        public virtual void OnModuleChange() { }

        #endregion
    }
}
