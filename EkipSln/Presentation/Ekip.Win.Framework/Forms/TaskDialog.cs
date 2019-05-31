using DevExpress.Utils.Drawing.Helpers;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Ekip.Framework.Core.ErrorHandling;
using Ekip.Framework.Core.Resources;
using System.Drawing;
using System.Windows.Forms;

namespace Ekip.Win.Framework.Forms
{
    public static class TaskDialog
    {
        #region Validate Exception Dialog

        public static DialogResult ValidateException(ValidateException exception)
        {
            XtraMessageBoxArgs args = new XtraMessageBoxArgs();
            args.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            args.MessageBeepSound = MessageBeepSound.Warning;
            args.Icon = StockIconHelper.GetStockIcon(StockIconHelper.StockIconId.Error);
            args.Caption = exception.Caption;
            args.Text = exception.Message;
            if (exception.ValidationErrors.Count > 0)
            {
                args.Text += "\n";
                exception.ValidationErrors.ForEach(delegate (ValidationError error)
                {
                    if (!string.IsNullOrWhiteSpace(error.ErrorMessage))
                        args.Text += string.Format("\n<b>(*) {0}</b>", error.ErrorMessage);
                });
            }
            args.Buttons = new DialogResult[] { DialogResult.OK, DialogResult.Ignore };
            args.Showing += ValidateExceptionOnShowing;
            SplashScreenManager.CloseDefaultWaitForm();
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

        #endregion

        #region File Change Detection

        public static DialogResult FileChangeDetection(int fileNumber)
        {
            XtraMessageBoxArgs args = new XtraMessageBoxArgs();
            args.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            args.MessageBeepSound = MessageBeepSound.Information;
            args.Icon = StockIconHelper.GetStockIcon(StockIconHelper.StockIconId.Information);
            args.Caption = string.Format(SystemMessages.FileChanged_Caption, fileNumber);
            args.Text = string.Format(SystemMessages.FileChanged_Content, fileNumber);
            args.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No, DialogResult.Cancel };
            args.Showing += OnFileChangeDetection;
            SplashScreenManager.CloseDefaultWaitForm();
            DialogResult result = XtraMessageBox.Show(args);
            return result;
        }

        private static void OnFileChangeDetection(object sender, XtraMessageShowingArgs e)
        {
            MessageButtonCollection buttons = e.Buttons as MessageButtonCollection;
            SimpleButton btnYes = buttons[DialogResult.Yes] as SimpleButton;
            SimpleButton btnNo = buttons[DialogResult.No] as SimpleButton;
            SimpleButton btnCancel = buttons[DialogResult.Cancel] as SimpleButton;
            btnYes.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.True;
            btnNo.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.True;
            btnCancel.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.True;
            if (btnYes != null)
            {
                btnYes.Text = "<b>Değişiklikleri Kaydet</b>";
                btnYes.Width += 50;
            }
            if (btnNo != null)
            {
                btnNo.Text = "<b>Kaydetmeden Devam Et</b>";
                btnNo.Width += 70;
            }
            if (btnCancel != null)
            {
                btnCancel.Text = "İptal";
                btnCancel.Width += 30;
            }
        }

        #endregion
    }
}
