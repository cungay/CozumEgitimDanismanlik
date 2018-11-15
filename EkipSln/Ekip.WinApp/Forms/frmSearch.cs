using System;
using System.Windows.Forms;
using System.IO;
using Ekip.Framework.Data;
using Ekip.Framework.Entities;
using Ekip.Framework.Core;
using Ekip.Win.Framework.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Ekip.Win.Framework;
using Ekip.Win.Framework.DevEx.Grid;

namespace Ekip.WinApp.Forms
{
    public partial class frmSearch : BaseForm
    {
        public frmSearch()
        {
            InitializeComponent();
        }

        private ClientView searchParams = null;
        private VList<ClientView> searchResult = null;
        public ClientView findedObj { get; set; }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            cbGender.BindEnum(typeof(Gender), false);
            lkGender.BindEnum(typeof(Gender), null, false);
            rgBlood.BindEnum(typeof(Blood));
            //rgFamilyStatus.BindEnum(typeof(FamilyStatus));

            //TList<City> cityList = DataRepository.CityProvider.GetAll();
            //cityList.Insert(0, new City() { CityId = 0, CityName = "Belirtilmedi" });
            //lkCity.Bind(cityList, "CityName", "CityId", "Şehir Listesi");

            //TList<Reason> reasonList = DataEx.GetListReasonFromCache();
            //cblReasonList.DataSource = reasonList;
            //cblReasonList.ItemCheck += cblReasonList_ItemCheck;

            //TList<Advisor> advisorList = CacheManager.GetListAdvisorFromCache();
            //checkedListBoxControl1.DataSource = advisorList;
            //checkedListBoxControl1.DisplayMember = "FullName";
            //checkedListBoxControl1.ValueMember = "AdvisorId";

            searchParams = new ClientView();
            searchParams.Gender = 0;
            searchParams.Blood = 0;
            searchParams.CityId = 0;

            grpFamily.DataBind(searchParams);
            grpAddress.DataBind(searchParams);
            grpClient.DataBind(searchParams);

            lkCity.EditValueChanged += lkCity_EditValueChanged;
            lkDistrict.EditValueChanged += lkDistrict_EditValueChanged;
            gcResult.OnRowClick += gcResult_OnRowClick;
            deBirthDate1.ButtonClick += deBirthDate_ButtonClick;
            deBirthDate2.ButtonClick += deBirthDate_ButtonClick;
            //txtFirstDate.ButtonClick += txtFirstDate_ButtonClick;
            btnSelect.ButtonClick += btnSelect_ButtonClick;
        }

        private void lkCity_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit edit = sender as LookUpEdit;
            int cityId = edit.EditValue.ToInt32();
            if (cityId > 0)
            {
                //TList<District> districtList = DataRepository.DistrictProvider.GetByCityId(cityId);
                //districtList.Insert(0, new District() { DistrictId = 0, DistrictName = "Belirtilmedi" });
                //lkDistrict.Bind(districtList, "DistrictName", "DistrictId", "İlçe Listesi");
            }
        }

        private void lkDistrict_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit edit = sender as LookUpEdit;
            int districtId = edit.EditValue.ToInt32();
            if (districtId > 0)
            {
                //TList<Ekip.Framework.Entities.Region> regionList = DataRepository.RegionProvider.GetByDistrictId(districtId);
                //regionList.Insert(0, new Ekip.Framework.Entities.Region() { RegionId = 0, Region = "Belirtilmedi" });
                //lkRegion.Bind(regionList, "Region", "RegionId", "Semt Listesi");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void gcResult_OnRowClick(object sender, DxRowClickArgs e)
        {
            findedObj = e.CurrentRow as ClientView;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void deBirthDate_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            DateEdit edit = sender as DateEdit;
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                edit.EditValue = null;
            }
        }
        
        private void btnSelect_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            var row = gwResult.GetRow(gwResult.FocusedRowHandle);

            gcResult_OnRowClick(sender, new DxRowClickArgs(row, gwResult.FocusedRowHandle, null));

        }
        
        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (new WaitCursor())
            {
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx |Pdf (.pdf)|*.pdf |Txt (.txt)|*.txt |Html (.html)|*.html";
                    if (saveDialog.ShowDialog() != DialogResult.Cancel)
                    {
                        string exportFilePath = saveDialog.FileName;
                        string fileExtenstion = new FileInfo(exportFilePath).Extension;
                        switch (fileExtenstion)
                        {
                            case ".xls":
                                gwResult.BestFitColumns();
                                gcResult.ExportToXls(exportFilePath);
                                UserDialog.InfoMessage(this, "Farklı Kaydet", string.Format("{0} dosyası oluşturuldu.", exportFilePath));
                                break;
                            case ".xlsx":
                                gwResult.BestFitColumns();
                                gcResult.ExportToXlsx(exportFilePath);
                                UserDialog.InfoMessage(this, "Farklı Kaydet", string.Format("{0} dosyası oluşturuldu.", exportFilePath));
                                break;
                            case ".pdf":
                                gcResult.ExportToPdf(exportFilePath);
                                UserDialog.InfoMessage(this, "Farklı Kaydet", string.Format("{0} dosyası oluşturuldu.", exportFilePath));
                                break;
                            case ".html":
                                gcResult.ExportToHtml(exportFilePath);
                                UserDialog.InfoMessage(this, "Farklı Kaydet", string.Format("{0} dosyası oluşturuldu.", exportFilePath));
                                break;
                            case ".txt":
                                TextWriter tw = new StreamWriter(exportFilePath);
                                foreach (var item in searchResult)
                                {
                                    if (!string.IsNullOrWhiteSpace(item.FatherEmail))
                                        tw.WriteLine(item.FatherEmail);
                                    if (!string.IsNullOrWhiteSpace(item.MotherEmail))
                                        tw.WriteLine(item.MotherEmail);
                                }
                                tw.Close();
                                UserDialog.InfoMessage(this, "Farklı Kaydet", string.Format("{0} dosyası oluşturuldu.", exportFilePath));
                                break;
                        }
                    }
                }
            }
        }

        private void btnSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string firstName = txtFirstName.Text.Trim().Length == 0 ? null : txtFirstName.Text;
            string lastName = txtLastName.Text.Trim().Length == 0 ? null : txtLastName.Text;

            using (new WaitCursor(this))
            {
                //Cursor.Current = Cursors.WaitCursor;

                //SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm), true, true, false);

                searchParams.AdvisorIdList = string.Empty;

                for (int i = 0; i < checkedListBoxControl1.CheckedItems.Count; i++)
                {
                    Advisor adv = (Advisor)checkedListBoxControl1.CheckedItems[i];

                    searchParams.AdvisorIdList += string.Format("{0},", adv.AdvisorId);
                }

                //searchResult = DataRepository.ClientViewProvider.Find(searchParams.FileNumber, firstName, lastName, searchParams.MiddleName, searchParams.Reference, searchParams.Pediatrician, searchParams.Blood, searchParams.BirthDate1, searchParams.BirthDate2, searchParams.FirstDate1, searchParams.FirstDate2, searchParams.Gender, searchParams.IdCard, searchParams.Age1, searchParams.Age2, searchParams.Mother, searchParams.MotherBusiness, searchParams.MotherMobile, searchParams.MotherEmail, searchParams.Father, searchParams.FatherBusiness, searchParams.FatherMobile, searchParams.FatherEmail, searchParams.AddressLine, searchParams.CityId, searchParams.DistrictId, searchParams.RegionId, searchParams.AdvisorIdList);

                //gcResult.DataSource = searchResult;

                if (searchResult.Count > 0)
                {
                    UserDialog.InfoMessage(this, "Arama Sonucu", string.Format("{0} kayıt bulundu.", searchResult.Count));

                    xtraTabControl1.SelectedTabPage = xtraTabPage2;
                }
                else
                {
                    UserDialog.InfoMessage(this, "Arama Sonucu", "Aranılan özelliklerde kayıt bulunamadı.");
                }
            }
        }
    }
}
