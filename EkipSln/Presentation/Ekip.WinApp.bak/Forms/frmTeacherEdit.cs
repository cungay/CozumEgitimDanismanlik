using System;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ekip.Framework.Entities;
using Ekip.Win.Framework;

namespace Ekip.WinApp.Forms
{
    public partial class frmTeacherEdit : XtraForm
    {
        //private TList<Teacher> dataSource = null;
        //private Teacher teacher = null;
        //private Teacher originalEntity = null;

        private int rowHandle = -1;
        private bool update = false;

        public frmTeacherEdit()
        {
            InitializeComponent();
            //lkBranch.BindEnum(typeof(TeacherBranch), string.Empty);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            txtTeacherName.Select();
            txtTeacherName.Focus();

            if (rowHandle >= 0)
            {
                //teacher = dataSource[rowHandle];
                update = true;
            }

            else
            {
                //teacher = new Teacher();
            }

            //this.DataBind(teacher);

            //originalEntity = teacher.Clone() as Teacher;
            //teacher.PropertyChanged += teacher_PropertyChanged;

        }

        void teacher_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        //public frmTeacherEdit(TList<Teacher> dataSource, int rowHandle)
        //    : this()
        //{
        //    this.dataSource = dataSource;
        //    this.rowHandle = rowHandle;
        //    this.StartPosition = FormStartPosition.CenterParent;
        //}

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (update)
            {
                //dataSource[rowHandle] = originalEntity;
                //dataSource[rowHandle].CancelChanges();
            }

            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (!update)
            {
                //dataSource.Add(teacher);
                //teacher.AcceptChanges();
            }

            this.Close();
        }
    }
}
