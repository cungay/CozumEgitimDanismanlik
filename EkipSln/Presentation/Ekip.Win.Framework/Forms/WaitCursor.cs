using System;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;

namespace Ekip.Framework.UI.Forms
{
    public class WaitCursor : IDisposable
    {
        private bool useWaitForm = false;

        public WaitCursor(Form parentForm = null)
        {
            if (parentForm != null)
            {
                SplashScreenManager.ShowForm(parentForm, typeof(WaitForm), true, true, false);

                useWaitForm = true;
            }

            Cursor.Current = Cursors.WaitCursor;
        }
        public void Dispose()
        {
            if (useWaitForm)
            {
                SplashScreenManager.CloseForm(false);
            }

            Cursor.Current = Cursors.Default;
        }
    }
}
