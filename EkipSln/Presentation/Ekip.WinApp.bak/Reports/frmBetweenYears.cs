using System;
using System.IO;
using System.Windows.Forms;
using Ekip.Framework.Data;
using Ekip.Framework.Entities;
using Ekip.Framework.Services;
using Ekip.Win.Framework;
using Ekip.Win.Framework.Forms;

namespace Ekip.WinApp.Reports
{
    public partial class frmBetweenYears : BaseForm
    {
        #region Fields

        private readonly ClientService clientService = null;

        #endregion

        public frmBetweenYears()
        {
            clientService = new ClientService();

            InitializeComponent();
            Load += frmBetweenYears_Load;
            this.btnPrintPreview.ItemClick += BtnPrintPreview_ItemClick;
        }

        private void BtnPrintPreview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gwResult.ShowRibbonPrintPreview();
        }

        public TList<Client> Results
        {
            get
            {
                return gcResult.DataSource as TList<Client>;
            }
            set
            {
                gcResult.DataSource = value;
            }
        }

        private void frmBetweenYears_Load(object sender, EventArgs e)
        {
            Results = new TList<Client>();

            lbYears.DataSource = clientService.GetAllClientFirstContactYears();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (new WaitCursor(this))
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

        private void btnSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (new WaitCursor(this))
            {
                string years = string.Empty;
                int selectedYearsCount = 0;

                foreach (var item in lbYears.CheckedItems)
                {
                    years += string.Format("{0},", item.ToString());
                    selectedYearsCount += 1;
                }

                Results = new TList<Client>();

                if (years.Length > 0)
                {
                    years = years.Remove(years.Length - 1, 1);

                    Results = DataRepository.ClientProvider.GetByFirstContactYears(years);
                }

                lblResult.Text = string.Format("Toplam Başvuru Sayısı: {0} Adet", Results.Count);
            }
        }
    }
}
