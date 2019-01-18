using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Ekip.Framework.Data;
using Ekip.Framework.Entities;
using Ekip.Framework.Services;
using Ekip.Win.Framework;
using Ekip.Win.Framework.Forms;

namespace Ekip.WinApp.Reports
{
    public partial class frmReasonsReport : BaseForm
    {
        #region Fields

        private readonly ClientService clientService = null;
        private readonly ReasonService reasonService = null;

        #endregion

        public frmReasonsReport()
        {
            clientService = new ClientService();
            reasonService = new ReasonService();

            InitializeComponent();
            Load += frmReasonReport_Load;
        }

        public DataTable Results
        {
            get { return gcResult.DataSource as DataTable; }
            set { gcResult.DataSource = value; }
        }

        private void frmReasonReport_Load(object sender, EventArgs e)
        {
            Results = new DataTable();
            cblReasonList.DataSource = reasonService.GetAll();
            cblFirstYears.DataSource = clientService.GetAllClientFirstContactYears();
            cblBirthYears.DataSource = clientService.GetAllClientBirthDateYears();
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

        private void btnSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (new WaitCursor(this))
            {
                string selectedReasons = string.Empty;
                string selectedFirstYears = string.Empty;
                string selectedBirthDates = string.Empty;
                string whereClause = "(1 = 1)";
                foreach (var item in cblReasonList.CheckedItems) {
                    Reason obj = item as Reason;
                    selectedReasons += string.Format("'{0}',", obj.ReasonId);
                }
                foreach (var item in cblFirstYears.CheckedItems)
                    selectedFirstYears += string.Format("'{0}',", item.ToString());

                foreach (var item in cblBirthYears.CheckedItems)
                    selectedBirthDates += string.Format("'{0}',", item.ToString());
                if (selectedReasons.Length > 0) {
                    selectedReasons = selectedReasons.Remove(selectedReasons.Length - 1, 1);
                    whereClause += string.Format(" AND (SELECT dbo.fn_ReasonIDList(Seance.SeanceID)) IN ({0})", selectedReasons);
                }
                if (selectedFirstYears.Length > 0) {
                    selectedFirstYears = selectedFirstYears.Remove(selectedFirstYears.Length - 1, 1);
                    whereClause += string.Format(" AND YEAR(FirstContactDate) IN ({0})", selectedFirstYears);
                }
                if (selectedBirthDates.Length > 0) {
                    selectedBirthDates = selectedBirthDates.Remove(selectedBirthDates.Length - 1, 1);
                    whereClause += string.Format(" AND YEAR(BirthDate) IN ({0})", selectedBirthDates);
                }
                if (whereClause.Replace("(1 = 1)", "").Length > 0)
                {
                    DataSet ds = DataRepository.Provider.ExecuteDataSet("[dbo].[_Seance_ClientReasonReport]", new object[] { whereClause, null });

                    if (ds.Tables.Count > 0)
                    {
                        Results = ds.Tables[0];
                    }
                }
            }
        }
    }
}
