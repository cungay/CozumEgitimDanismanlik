using System;
using System.ComponentModel;
using System.Windows.Forms;
using Ekip.Framework.Data;
using Ekip.Framework.Entities;
using Ekip.Framework.Services;
using DevExpress.XtraEditors;
using Ekip.Win.Framework;

namespace Ekip.WinApp.Forms
{
    public partial class frmReasonList : XtraForm
    {
        public int ClientID { get; set; }
        // TList<Reason> list = null;

        public TList<Reason> List
        {
            get 
            {
                return dataGridView1.DataSource as TList<Reason>; 
            }
            set
            {
                value.AddingNew += AddNewReason;
                
                dataGridView1.DataSource = value;
            }
        }

        void AddNewReason(object sender, AddingNewEventArgs e)
        {
            try
            {
                int lastKey = List[List.Count - 1].ReasonKey.Value;
                lastKey += 1;
                Reason item = new Reason();
                item.ReasonKey = lastKey;
                e.NewObject = item;
            }
            catch (Exception)
            {

            }
        }

        public frmReasonList()
        {
            InitializeComponent();
            this.GeometryFromString(Properties.Settings.Default.ClientReasonGeometry);

            DataBind();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Properties.Settings.Default.ClientReasonGeometry = this.GeometryToString();
            Properties.Settings.Default.Save();
        }

        private void frmClientReason_Load(object sender, EventArgs e)
        {
            DataBind();
        }

        private void DataBind()
        {
            List = DataRepository.ReasonProvider.Find(new SqlFilterParameterCollection(), "ReasonKey ASC");

        }

        private void frmReasonList_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                bool result = SaveChanges();

                if (result)
                {
                    UserDialog.InfoMessage(this, "Kaydet", "Değişiklikler kaydedildi.");
                }
                else
                {
                    UserDialog.InfoMessage(this, "Kaydet", "Kaydetme işlemi iptal edildi\nSistem bir sorunla karşılaştı\nTekrar deneyin ya da sistem yöneticinize başvurun.");

                    e.Cancel = true;
                }
            }
        }

        bool SaveChanges()
        {
            TransactionManager tm = null;
            bool result = true;

            if (List.AllChangesCount > 0)
            {
                try
                {

                    bool isBorrowedTransaction = ConnectionScope.Current.HasTransaction;
                    tm = ConnectionScope.ValidateOrCreateTransaction(true);

                    if (!isBorrowedTransaction && tm != null && tm.IsOpen)
                    {
                        DataRepository.ReasonProvider.Save(tm, List);
                        tm.Commit();
                    }
                }
                catch (Exception ex)
                {
                    result = false;
                }
            }

            return result;
        }
    }
}
