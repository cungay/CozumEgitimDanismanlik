using System;
using Ekip.Framework.Entities;
using Ekip.Framework.Services;
using Ekip.Framework.Core;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using Ekip.Framework.Data;
using Ekip.Framework.UI.Forms;
using Ekip.Framework.UI.DevEx.Grid;
using Ekip.Framework.UI;
using Ekip.Framework.UI.Extensions;

namespace Ekip.Win.UI.UserControls
{
    public partial class ucClientTab : XtraUserControl
    {
        #region Fields

        private readonly ClientService clientService = null;
        private readonly SeanceService seanceService = null;
        private readonly ReasonService reasonService = null;

        #endregion

        #region Ctor

        public ucClientTab()
        {
            InitializeComponent();

            this.clientService = new ClientService();
            this.seanceService = new SeanceService();
            this.reasonService = new ReasonService();
        }

        #endregion

        #region Load

        private void ucClientTab_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                rlkClassRoom.BindEnum(typeof(ClassRoom), string.Empty);
                //lkClassRoom.BindEnum(typeof(ClassRoom), string.Empty);
                //rlkBranch.BindEnum(typeof(TeacherBranch), string.Empty);
                rlkGender.BindEnum(typeof(Gender), string.Empty);

                //TList<City> cityList = DataRepository.CityProvider.GetAll();
                //lkSchoolCity.Bind(cityList, "CityName", "CityId", "Şehir Listesi");

                //rlkAdvisor.Bind(CacheManager.GetListAdvisorFromCache(), "FullName", "AdvisorId");
                gwSeance.BindLookUpColumns();
            }
        }

        #endregion

        #region Seance

        public void LoadSeance()
        {
            var list = seanceService.GetAllSeances(Program.CurrentClient.ClientId);
            gcSeanse.DataSource = list;
            dxSeanceNav.DataSource = list;
            gwSeance.CalcPreviewText += GwSeance_CalcPreviewText;
        }

        private string CalculatePreviewText(int rowHandle)
        {
            string result = string.Empty;
            var seance = (Seance)gwSeance.GetRow(rowHandle);
            if (seance != null)
            {
                for (int i = 0; i < seance.SeanceReasonCollection.Count; i++)
                {
                    if (seance.SeanceReasonCollection[i].ReasonIdSource != null)
                        result += seance.SeanceReasonCollection[i].ReasonIdSource.ToString().Replace(";", "\n");
                }
            }
            return result;
        }

        private void OnEditSeance(Seance seance)
        {
            //using (frmSeanceEdit editDlg = new frmSeanceEdit(seance))
            //{
            //    editDlg.Text = (seance == null ? "* Yeni Seans Kaydet" : "Seans Güncelle");
            //    var dialogResult = editDlg.ShowDialog(this);
            //    if (dialogResult == DialogResult.OK)
            //    {
            //        gwSeance.RefreshRow(gwSeance.FocusedRowHandle);
            //        gwSeance.RefreshData();
            //    }
            //}
        }

        private void GcSeanse_OnRowClick(object sender, DxRowClickArgs e)
        {
            var row = gwSeance.GetRow<Seance>();

            if (row != null)
            {
                OnEditSeance(row);
            }
        }

        private void GcSeanse_OnRowDelete(object sender, DxRowClickArgs e)
        {
            Seance row = e.CurrentRow as Seance;

            if (row.SeanceId > 0)
            {
                seanceService.DeleteBySeanceID(row.SeanceId);
                gwSeance.RefreshData();
            }
        }

        private void GwSeance_CalcPreviewText(object sender, CalcPreviewTextEventArgs e)
        {
            e.PreviewText = CalculatePreviewText(e.RowHandle);
        }

        private void DxSeanceNav_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == NavigatorButtonType.Append)
            {
                e.Handled = true;

                OnEditSeance(null);
            }
        }

        #endregion

        public void DataBind(Client client)
        {
            //this.client = client;

            #region Seance

            //var view = DataRepository.SeanceViewProvider.GetByClientId(client.ClientId);

            var seanceCollection = DataRepository.SeanceProvider.GetByClientId(client.ClientId);

            //foreach (var item in seanceCollection)
            //{
            //    //DataRepository.SeanceProvider.DeepLoad(item, true, DeepLoadType.IncludeChildren,
            //    //    typeof(List<SeanceReason>),
            //    //    typeof(Reason));

            //    //item.AcceptChanges();
            //}
            //seanceCollection.ForEach(delegate (Seance seance) { });

            //client.SeanceCollection = seanceCollection;
            //gcSeanse.DataSource = client.SeanceCollection;
            //dxSeanceNav.DataSource = client.SeanceCollection;

            #endregion

            #region DeepLoad

            //DataRepository.ClientProvider.DeepLoad(client, false, DeepLoadType.IncludeChildren, typeof(List<Sibling>), typeof(List<Teacher>));

            #endregion

            #region School Bind

            //client.SchoolIdSource = new School();

            //if (client.SchoolId.HasValue)
            //    client.SchoolIdSource = DataRepository.SchoolProvider.GetBySchoolId(client.SchoolId.Value);

            ////client.SchoolIdSource.AcceptChanges();
            //grpSchool.DataBind(client.SchoolIdSource);
            //grpAddress.DataBind(client.SchoolIdSource);

            #endregion

            //gcSibling.DataSource = client.SiblingCollection;
            //gcTeacher.DataSource = client.TeacherCollection;

            //client.SeanceViewCollection = DataRepository.SeanceViewProvider.GetByClientId(client.ClientId);

            //var seanceList = client.SeanceViewCollection;
            //DataRepository.SeanceViewProvider.GetByClientId(client.ClientId);

            //client.SeanceViewCollection;
        }

        public bool HasDataChanged()
        {
            if (Program.CurrentClient == null)
                return false;

            //return Program.CurrentClient.TeacherCollection.AllChangesCount > 0
            //    || Program.CurrentClient.SiblingCollection.AllChangesCount > 0;
            return false;
        }

        private void OnEditClientSub(object row)
        {
            //frmSiblingEdit editDlg = null;

            //if (row == null)
            //{
            //    editDlg = new frmSiblingEdit(Program.CurrentClient.SiblingCollection, -1);
            //    editDlg.Text = "Yeni Ekle";
            //}
            //else
            //{
            //    int rowHandle = gwSibling.FocusedRowHandle;
            //    editDlg = new frmSiblingEdit(Program.CurrentClient.SiblingCollection, rowHandle);
            //    editDlg.Text = Program.CurrentClient.SiblingCollection[0].FullName;
            //}
            //editDlg.ShowDialog(this);
            //gcSibling.RefreshDataSource();
            //gwSibling.RefreshData();
        }

        private void OnEditEducation(object row)
        {
            //frmTeacherEdit editDlg = null;

            //if (row == null)
            //{
            //    editDlg = new frmTeacherEdit(Program.CurrentClient.TeacherCollection, -1);
            //    editDlg.Text = "Yeni Ekle";
            //}
            //else
            //{
            //    int rowHandle = gwTeacher.FocusedRowHandle;
            //    editDlg = new frmTeacherEdit(Program.CurrentClient.TeacherCollection, rowHandle);
            //    editDlg.Text = Program.CurrentClient.TeacherCollection[0].TeacherName;
            //}
            //editDlg.ShowDialog(this);
            //gcTeacher.RefreshDataSource();
            //gwTeacher.RefreshData();
        }

        private void gcClientSub_OnRowClick(object sender, DxRowClickArgs e)
        {
            using (new WaitCursor())
            {
                OnEditClientSub(e.CurrentRow);
            }
        }

        private void gcEducation_OnRowClick(object sender, DxRowClickArgs e)
        {
            using (new WaitCursor())
            {
                OnEditEducation(e.CurrentRow);
            }
        }

        private void lkCity_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit edit = sender as LookUpEdit;
            int cityId = edit.EditValue.ToInt32();
            if (cityId > 0)
            {
                //TList<District> districtList = DataRepository.DistrictProvider.GetByCityId(cityId);
                //lkSchoolDistrict.Bind(districtList, "DistrictName", "DistrictId", "İlçe Listesi");
            }
        }

        private void lkDistrict_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit edit = sender as LookUpEdit;
            int districtId = edit.EditValue.ToInt32();
            if (districtId > 0)
            {
                //TList<Ekip.Framework.Entities.Region> regionList = DataRepository.RegionProvider.GetByDistrictId(districtId);
                //lkSchoolRegion.Bind(regionList, "Region", "RegionId", "Semt Listesi");
            }
        }

        #region DxNavigator
        
        #endregion
    }
}