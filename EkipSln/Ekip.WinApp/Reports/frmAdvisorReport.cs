using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Ekip.Framework.Data;
using Ekip.Framework.Entities;
using Ekip.Win.Framework;
using Ekip.Win.Framework.Forms;

namespace Ekip.WinApp.Reports
{
    public partial class frmAdvisorReport : BaseForm
    {
        public frmAdvisorReport()
        {
            InitializeComponent();
            Load += frmReasonReport_Load;
            btnPrintPreview.ItemClick += BtnPrintPreview_ItemClick;
        }

        private void BtnPrintPreview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gwResult.ShowRibbonPrintPreview();
        }

        public DataTable Results
        {
            get { return gcResult.DataSource as DataTable; }
            set { gcResult.DataSource = value; }
        }

        void frmReasonReport_Load(object sender, EventArgs e)
        {
            //TList<Advisor> advisorList = CacheManager.GetListAdvisorFromCache();
            //lbAdvisors.DataSource = advisorList;
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
                                //foreach (var item in searchResult)
                                //{
                                //    if (!string.IsNullOrWhiteSpace(item.FatherEmail))
                                //        tw.WriteLine(item.FatherEmail);
                                //    if (!string.IsNullOrWhiteSpace(item.MotherEmail))
                                //        tw.WriteLine(item.MotherEmail);
                                //}
                                tw.Close();
                                UserDialog.InfoMessage(this, "Farklı Kaydet", string.Format("{0} dosyası oluşturuldu.", exportFilePath));
                                break;
                        }
                    }
                }
            }
        }

        private void btnSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            using (new WaitCursor(this)) {
                Results = new DataTable();
                string advisorIds = string.Empty;
                int selectedCount = 0;
                foreach (var item in lbAdvisors.CheckedItems) {
                    Advisor advisor = item as Advisor;
                    advisorIds += string.Format("{0},", advisor.AdvisorId);
                    selectedCount += 1;
                }
                if (selectedCount > 0)
                {
                    advisorIds = advisorIds.Remove(advisorIds.Length - 1, 1);
                    IDataReader reader = DataRepository.ClientProvider.AdvisorReport(advisorIds);
                    Results.Load(reader);
                }
                lblResult.Text = string.Format("Toplam Danışan Sayısı: {0} Adet", Results.Rows.Count);
            }
        }
    }
}
