using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using DevExpress.XtraGrid.Views.Base;
using System.Collections;
using System.Reflection;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Configuration;
using Ekip.Framework.Core;

namespace Ekip.Win.UI.UserControls
{
    public partial class ucFileExplorer : XtraUserControl
    {
        private DataTable currentTable = null;
        private Hashtable images = new Hashtable();

        public ucFileExplorer()
        {
            InitializeComponent();
            currentTable = CreateTable();
            gridControl1.DataSource = currentTable; 
            gridView1.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(gridView1_CustomUnboundColumnData);
            gridControl1.DoubleClick += new EventHandler(gridControl1_DoubleClick);
            gridControl1.MouseDown += new MouseEventHandler(gridControl1_MouseDown);
            gridView1.CustomDrawEmptyForeground += new CustomDrawEventHandler(gridView1_CustomDrawEmptyForeground);
        }

        void gridView1_CustomDrawEmptyForeground(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
        {
            Font f = new Font("Tahoma", 10, FontStyle.Underline);
            Rectangle r = new Rectangle(e.Bounds.Left + 50, e.Bounds.Top + 45, e.Bounds.Width - 5, e.Bounds.Height - 5);
            e.Graphics.DrawString("Ekli dosya bulunamadı.", f, Brushes.Black, r);
        }

        GridHitInfo hitInfo = null;
        protected void gridControl1_MouseDown(object sender, MouseEventArgs e)
        {
            hitInfo = gridView1.CalcHitInfo(e.X, e.Y);
        }

        protected void gridControl1_DoubleClick(object sender, EventArgs e) {
            if (hitInfo.InRow) {
                try
                {
                    DataRow row = gridView1.GetDataRow(hitInfo.RowHandle);
                    string filePath = row["FilePath"].ToString();
                    if (filePath.Trim().Length > 0)
                    {
                        /*
                        int result = UserDialog.QuestionMessage(this, string.Format("{0} dosyasını açmak istiyor musunuz ?", Path.GetFileName(filePath)), "Dosya Aç");

                        if (result == 1) return;
                        */
                        System.Diagnostics.Process.Start(filePath);
                    }
                }
                catch (Exception ex)
                {
                    //UserDialog.ErrorMessage(this, "Dosya Hatası", ex.Message);
                    //Log.Write(ex.Message, true);
                }
            }
        }

        protected Image GetImage(string fileExtension)
        {
            switch (fileExtension)
            {
                case".zip":
                case ".rar":
                    fileExtension = "rar";
                    break;
                case".docx":
                case".doc":
                    fileExtension = "doc";
                    break;
                case".jpg":
                case ".png":
                case ".gif":
                case ".bmp":
                    fileExtension = "jpg";
                    break;
                case".xls":
                case ".xlsx":
                    fileExtension="xls";
                    break;
                case".pdf":
                    fileExtension = ".pdf";
                    break;
                default:
                    fileExtension = "txt";
                    break;
            }

            string file = string.Format("UserControls.images.{0}.png", fileExtension.Replace(".", ""));
            Stream stream = StreamExtensions.GetManifestResourceStream(file, Assembly.GetExecutingAssembly());
            if (stream != null)
            {
                return Image.FromStream(stream);
            }
            return null;
        }

        protected void gridView1_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "extension")
            {
                if (e.IsGetData)
                {
                    DataRowView drw = e.Row as DataRowView;
                    DataRow dr = drw.Row;
                    if (dr != null)
                    {
                        string ex = dr["FileExtension"].ToString();
                        if (!images.ContainsKey(ex))
                        {
                            Image img = GetImage(ex);
                            if (img != null)
                            {
                                images.Add(ex, img);
                            }
                        }
                        e.Value = images[ex];
                    }
                }
            }
        }

        private DataTable CreateTable()
        {
            DataTable table = new DataTable();
            table.Columns.AddRange(new DataColumn[] 
            {
                new DataColumn("FileExtension",typeof(string)),
                new DataColumn("FileName",typeof(string)),
                new DataColumn("CreateDate",typeof(DateTime)),
                new DataColumn("FilePath",typeof(string))
            });
            return table;
        }

        public void GetFiles(int FileNumber) {
            currentTable.Clear();
            DirectoryInfo baseDir = new DirectoryInfo(ConfigurationManager.AppSettings["ClientFiles"]);
            if (baseDir.Exists){
                string clientDirPath = string.Format(@"{0}\{1}", baseDir.FullName, FileNumber);
                DirectoryInfo clientDir = new DirectoryInfo(clientDirPath);
                if (clientDir.Exists) {
                    FileInfo[] clientFiles = clientDir.GetFiles();
                    currentTable.BeginLoadData();
                    foreach (FileInfo file in clientFiles) {
                        currentTable.Rows.Add(new object[] 
                        {
                            file.Extension,file.Name,file.CreationTime.ToShortDateString(),file.FullName
                        });
                    }
                    currentTable.EndLoadData();
                    currentTable.AcceptChanges();
                    gridControl1.DataSource = currentTable;
                }
            }
            gridControl1.RefreshDataSource();
        }
    }
}
