using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace Ekip.Win.Framework
{
    public static class TextBoxExtensions
    {
        public static void Clear(this BaseEdit edit)
        {
            edit.Text = string.Empty;
            edit.EditValue = null;
        }

        public static void Clear(this TextBox textbox)
        {
            textbox.Text = string.Empty;
        }

        public static void SetNull(this BaseEdit edit)
        {
            edit.DataBindings.Clear();
            edit.EditValue = null;
            edit.Text = null;
        }

        public static void SetNull(this TextBox textbox)
        {
            textbox.Text = null;
        }
    }
}
