using DevExpress.XtraBars;
using DevExpress.XtraNavBar;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using AppFramework;
using Ekip.WinApp.Reports;
using Ekip.Win.Framework.Forms;
using Ekip.Win.Framework.DevEx.Editors;

namespace Ekip.WinApp
{
    public partial class frmMain : XtraForm
    {
        public frmMain()
        {
            InitializeComponent();

            biUserInfo.Caption = Program.CurrentUser.UserName;
            biServerInfo.Caption = Program.DataConfig.GetSelectedDataSource();

            //LoadSkins();
            RegisterModules();
            RegisterActions();
            navBar.LinkClicked += navBar_LinkClicked;
            ModuleInfoCollection.ShowModule(ModuleInfoCollection.Instance[0], pnlWorkingArea);
        }

        #region Register Modules

        private void RegisterModules()
        {
            navBar.Groups.Clear();
            navBar.Items.Clear();
            foreach (CategoryInfo cInfo in CategoriesInfo.Instance)
            {
                NavBarGroup group = navBar.Groups.Add();
                group.Caption = cInfo.Name;
                group.LargeImageIndex = cInfo.ImageIndex;
                group.GroupStyle = NavBarGroupStyle.SmallIconsText;
                group.Expanded = true;
            }
            foreach (ModuleInfo mInfo in ModuleInfoCollection.Instance)
            {
                NavBarItem item = navBar.Items.Add();
                item.Caption = mInfo.Name;
                item.SmallImageIndex = mInfo.ImageIndex;
                item.Tag = mInfo;
                navBar.Groups[mInfo.Category.Index].ItemLinks.Add(item);
                //this.barListItemModules.Strings.Add(mInfo.Name);
            }
        }

        #endregion

        #region Load Skins
        private void LoadSkins()
        {
            GalleryDropDown skins = new GalleryDropDown();
            skins.Ribbon = this.ribbon;
            DevExpress.XtraBars.Helpers.SkinHelper.InitSkinGalleryDropDown(skins);
            iPaintStyle.DropDownControl = skins;
        }
        #endregion

        #region Register Actions

        private void RegisterActions()
        {
            Actions.RegisterAction(ActionKeys.New, new BarItemAction(this.idNew));
            Actions.RegisterAction(ActionKeys.Save, new BarItemAction(this.idSave));
            Actions.RegisterAction(ActionKeys.Refresh, new BarItemAction(this.idRefresh));
            Actions.RegisterAction(ActionKeys.Find, new BarItemAction(this.idFind));
            Actions.RegisterAction(ActionKeys.NextFile, new BarItemAction(this.idNext));
            Actions.RegisterAction(ActionKeys.PrevFile, new BarItemAction(this.idPrev));
            Actions.RegisterAction(ActionKeys.LastFile, new BarItemAction(this.idLast));
            Actions.RegisterAction(ActionKeys.FirstFile, new BarItemAction(this.idFirst));
            // Export Actions
            //Actions.RegisterAction(ActionKeys.Export_HTML, new Win.Framework.DevEx.Editors.BarItemAction(this.idExportHTML));
            //Actions.RegisterAction(ActionKeys.Export_XML, new Win.Framework.DevEx.Editors.BarItemAction(this.idExportXML));
            //Actions.RegisterAction(ActionKeys.Export_XLS, new Win.Framework.DevEx.Editors.BarItemAction(this.idExportXLS));
            //Actions.RegisterAction(ActionKeys.Export_Text, new Win.Framework.DevEx.Editors.BarItemAction(this.idExportTEXT));
            //Actions.RegisterAction(ActionKeys.Export_Pdf, new Win.Framework.DevEx.Editors.BarItemAction(this.idExportPDF));
            // Printing Actions
            Actions.RegisterAction(ActionKeys.Print, new BarItemAction(this.idPrint));
            Actions.RegisterAction(ActionKeys.Preview, new BarItemAction(this.idPreview));
            //Search Actions
            Actions.RegisterAction(ActionKeys.Search, new TextItemAction(this.idSearchBox));
            Actions.RegisterAction(ActionKeys.Import, new BarItemAction(this.idAddFile));

            //Actions.RegisterAction(ActionKeys.ShowClientList, new BarItemAction(this.idShowClientList));
        }

        #endregion

        private void navBar_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            using (new WaitCursor(this))
            {
                BaseModule currentModule = ModuleInfoCollection.CurrentModuleInfo.Module as BaseModule;
                currentModule.OnModuleChange();
                ModuleInfoCollection.ShowModule(e.Link.Item.Tag as ModuleInfo, pnlWorkingArea);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            Application.ExitThread();
            Application.Exit();
        }

        private void btnReasonList_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (Forms.frmReasonList frm = new Forms.frmReasonList())
            {
                frm.ShowDialog(this);
            }
        }

        private void btnConsultantList_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (Forms.frmConsultantList frm = new Forms.frmConsultantList())
            {
                frm.ShowDialog(this);
            }
        }

        private void btnBetweenYears_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (frmBetweenYears frm = new frmBetweenYears())
            {
                frm.ShowDialog(this);
            }
        }

        private void btnAdvisorsReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (frmAdvisorReport frm = new frmAdvisorReport())
            {
                frm.ShowDialog(this);
            }
        }

        private void btnReasonsReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (Reports.frmReasonsReport frm = new Reports.frmReasonsReport())
            {
                frm.ShowDialog(this);
            }
        }

        #region Application Close

        private void idClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //TaskDialog taskDialog = new TaskDialog();
            //taskDialog.MainIcon = TaskDialogIcon.Warning;
            //taskDialog.FooterIcon = TaskDialogIcon.Information;
            //taskDialog.WindowTitle = this.Text;
            //taskDialog.MainInstruction = "Uygulama kapatılacak\nDevam etmek istiyor musunuz ?";
            //taskDialog.Content = "Bir veya birden fazla dosya üzerinde değişiklik yaptıysanız, bilgileri kaydettiğinizden emin olun.";
            //taskDialog.CanBeMinimized = false;
            //taskDialog.AllowDialogCancellation = false;
            //TaskDialogButton btnClose = new TaskDialogButton();
            //btnClose.ButtonId = 101;
            //btnClose.ButtonText = "Kapat";
            //TaskDialogButton btnCancel = new TaskDialogButton();
            //btnCancel.ButtonId = 102;
            //btnCancel.ButtonText = "Vazgeç";
            //taskDialog.Buttons = new TaskDialogButton[] { btnClose, btnCancel };
            //int result = taskDialog.Show(this);
            //e.Cancel = (result != btnClose.ButtonId);
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
            this.Dispose();
            System.GC.SuppressFinalize(this);
            Application.Exit();
        }

        #endregion
    }
}