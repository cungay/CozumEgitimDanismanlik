using System;
using System.ComponentModel;
using System.Windows.Forms;
using Ekip.Framework.Entities;
using DevExpress.XtraEditors;
using Ekip.Win.Framework;

namespace Ekip.WinApp.Forms
{
    public partial class frmSiblingEdit : XtraForm
    {
        private TList<Sibling> dataSource = null;
        private Sibling sub = null;
        private Sibling originalEntity = null;

        private int rowHandle = -1;
        private bool update = false;

        public frmSiblingEdit()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            txtFullName.Select();
            txtFullName.Focus();
            lkGender.BindEnum(typeof(Gender), string.Empty);
            lkClassRoom.BindEnum(typeof(ClassRoom), string.Empty);

            if (rowHandle >= 0)
            {
                sub = dataSource[rowHandle];
                update = true;
            }

            else
            {
                sub = new Sibling();
            }

            this.DataBind(sub);

            originalEntity = sub.Clone() as Sibling;
            sub.PropertyChanged += currentObject_PropertyChanged;
        }

        void currentObject_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "BirthDate")
            {
                if (sub.BirthDate.HasValue && sub.BirthDate > DateTime.MinValue)
                {
                    int year = sub.BirthDate.Value.Year;
                    int today = DateTime.Now.Year;
                    sub.Age = today - year;
                    txtAge.DataBindings["EditValue"].ReadValue();
                }
            }
        }

        public frmSiblingEdit(TList<Sibling> dataSource, int rowHandle)
            : this()
        {
            this.dataSource = dataSource;
            this.rowHandle = rowHandle;
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (update)
            {
                dataSource[rowHandle] = originalEntity;
               // dataSource[rowHandle].AcceptChanges();
            }
            
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate())
            {
                if (!update)
                {
                    dataSource.Add(sub);
                    //dataSource.AcceptChanges();
                }

                this.Close();
            }
        }
    }
}
