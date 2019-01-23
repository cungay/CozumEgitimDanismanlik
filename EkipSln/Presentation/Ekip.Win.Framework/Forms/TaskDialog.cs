using DevExpress.Utils;
using DevExpress.XtraEditors;
using System.Drawing;
using System.Windows.Forms;

namespace Ekip.Win.Framework.Forms
{
    public partial class TaskDialog : XtraForm
    {
        public TaskDialog()
        {
            InitializeComponent();
            this.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.HtmlText = Ekip.Framework.Core.Resources.Messages.Default_Title;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Rectangle rect = Screen.GetWorkingArea(this);
            this.Location = new Point(rect.Width / 2 - this.Width / 2, rect.Height / 2 - this.Height / 2);
        }

        protected override DevExpress.Skins.XtraForm.FormPainter CreateFormBorderPainter()
        {
            HorzAlignment formCaptionAlignment = HorzAlignment.Center;
            return new TaskDialogPainter(this, LookAndFeel, formCaptionAlignment);
        }

        private void pictureEdit1_EditValueChanged(object sender, System.EventArgs e)
        {

        }
    }
}
