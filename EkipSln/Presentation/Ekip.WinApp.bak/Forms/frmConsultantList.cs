using System;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ekip.Framework.Data;
using Ekip.Framework.Entities;
using Ekip.Framework.Services;
using Ekip.Win.Framework;

namespace Ekip.WinApp.Forms
{
    public partial class frmConsultantList : XtraForm
    {
        public frmConsultantList()
        {
            InitializeComponent();
            this.GeometryFromString(Ekip.WinApp.Properties.Settings.Default.ClientReasonGeometry);

            DataBind();
        }

        public TList<Advisor> List
        {
            get
            {
                return dataGridView1.DataSource as TList<Advisor>;
            }
            set
            {
                value.AddingNew += AddNewAdvisor;

                dataGridView1.DataSource = value;
            }
        }

        void AddNewAdvisor(object sender, AddingNewEventArgs e)
        {
            try
            {
                int lastKey = List[List.Count - 1].AdvisorId;
                lastKey += 1;
                Advisor item = new Advisor();
                item.AdvisorId = lastKey;
                e.NewObject = item;
            }
            catch (Exception)
            {

            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Ekip.WinApp.Properties.Settings.Default.ClientReasonGeometry = this.GeometryToString();
            Ekip.WinApp.Properties.Settings.Default.Save();
        }

        private void frmConsultantList_Load(object sender, EventArgs e)
        {
            DataBind();
        }

        private void DataBind()
        {
            List = DataRepository.AdvisorProvider.Find(new SqlFilterParameterCollection(), "AdvisorID ASC");
        }

        private void frmConsultantList_FormClosing(object sender, FormClosingEventArgs e)
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
                        DataRepository.AdvisorProvider.Save(tm, List);
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
