using DevExpress.Utils.Drawing.Helpers;
using DevExpress.XtraEditors;
using Ekip.Framework.Core.ErrorHandling;
using System.Drawing;
using System.Windows.Forms;

namespace Ekip.Win.Framework.Forms
{
    public static class TaskDialog
    {
        public static DialogResult ValidateException(ValidateException exception)
        {
            XtraMessageBoxArgs args = new XtraMessageBoxArgs();
            args.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            args.MessageBeepSound = MessageBeepSound.Warning;
            args.Icon = StockIconHelper.GetStockIcon(StockIconHelper.StockIconId.Error);
            args.Caption = exception.Caption;
            args.Text = exception.Message;
            if (exception.ValidationErrors.Count > 0) {
                args.Text += "\n";
                exception.ValidationErrors.ForEach(delegate (ValidationError error) {
                    if (!string.IsNullOrWhiteSpace(error.ErrorMessage))
                        args.Text += string.Format("\n<b>(*) {0}</b>", error.ErrorMessage);
                });
            }
            args.Buttons = new DialogResult[] { DialogResult.OK, DialogResult.Ignore };
            args.Showing += ValidateExceptionOnShowing;
            DialogResult result = XtraMessageBox.Show(args);
            return result;
        }

        private static void ValidateExceptionOnShowing(object sender, XtraMessageShowingArgs e)
        {
            //e.Form.Appearance.Font = new Font(e.Form.Appearance.Font, FontStyle.Bold);
            MessageButtonCollection buttons = e.Buttons as MessageButtonCollection;
            SimpleButton btnOk = buttons[DialogResult.OK] as SimpleButton;
            SimpleButton btnIgnore = buttons[DialogResult.Ignore] as SimpleButton;
            btnOk.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.True;
            btnIgnore.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.True;
            if (btnOk != null)
            {
                btnOk.Text = "<u>H</u>atayı Düzelt";
                btnOk.Width += 10;
            }
            if (btnIgnore != null)
            {
                btnIgnore.Text = "<u>G</u>eri Al";
                btnIgnore.Width += 10;
            }
        }
    }
}
