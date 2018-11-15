using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ekip.Win.Framework;

namespace Ekip.WinApp.Forms
{
    public partial class frmWiscrEdit : XtraForm
    {
        private Ekip.Framework.Entities.Wiscr dataSource = null;

        public frmWiscrEdit()
        {
            InitializeComponent();

            //lkAdvisor.Bind<Advisor>(CacheManager.GetListAdvisorFromCache(), "FullName", "AdvisorId");
        }

        public frmWiscrEdit(Ekip.Framework.Entities.Wiscr dataSource)
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
    }
}
