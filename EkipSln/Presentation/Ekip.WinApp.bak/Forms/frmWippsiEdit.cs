using DevExpress.XtraEditors;
using Ekip.Framework.Entities;
using Ekip.Win.Framework;
using System;
using System.Windows.Forms;

namespace Ekip.WinApp.Forms
{
    public partial class frmWippsiEdit : XtraForm
    {
        private Wippsi dataSource = null;

        public frmWippsiEdit()
        {
            InitializeComponent();

            //lkAdvisor.Bind<Advisor>(CacheManager.GetListAdvisorFromCache(), "FullName", "AdvisorId");
        }

        public frmWippsiEdit(Wippsi dataSource)
            : this()
        {
            this.dataSource = dataSource;
            if (dataSource.TestDate == DateTime.MinValue)
                dataSource.TestDate = DateTime.Now;

            this.StartPosition = FormStartPosition.CenterParent;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            grpPerform.DataBind(dataSource);
            grpTotal.DataBind(dataSource);
            grpVerbal.DataBind(dataSource);

            lkAdvisor.DataBindings.Clear();
            lkAdvisor.DataBindings.Add("EditValue", dataSource, "AdvisorId", true, DataSourceUpdateMode.OnPropertyChanged);
            lkAdvisor.DataBindings[0].ReadValue();

            txtTestDate.DataBindings.Clear();
            txtTestDate.DataBindings.Add("EditValue", dataSource, "TestDate", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTestDate.DataBindings[0].ReadValue();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dataSource.CancelChanges();
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grpVerbal_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
