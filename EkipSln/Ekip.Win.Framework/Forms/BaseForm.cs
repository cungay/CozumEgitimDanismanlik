using System;
using DevExpress.XtraEditors;

namespace Ekip.Win.Framework.Forms
{
    public partial class BaseForm : XtraForm
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            using (new WaitCursor(this))
            {
                base.OnLoad(e);
            }
        }
    }
}
