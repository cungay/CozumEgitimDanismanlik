using System;
using System.Threading;
using System.Diagnostics;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace Ekip.Win.Framework.ExceptionDialog
{
    public class ExceptionHandler
    {
        public ExceptionHandler()
        {

        }

        public void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            HandleUnhandledException(sender, e.ExceptionObject);
        }

        private void HandleUnhandledException(object sender, object exception)
        {
            Exception ex = null;
            string msg = null;
            string exName = null;
            try
            {
                ex = (Exception)exception;
                msg = "Type: \n\t" + ex.GetType().ToString() + "\n" +
                                    "Source: \n\t" + ex.Source + "\n" +
                                    "Message: \n\t" + ex.Message + "\n" +
                                    "Trace: \n\t" + ex.StackTrace + "\n" +
                                    "InnerException: \n\t" + ex.InnerException == null ? "" : ex.InnerException + "\n";
                if (msg== "\n")
                {
                    msg = ex.GetaAllMessages();
                }
                exName = ex.GetType().ToString();
                ExDialog dlg = new ExDialog();
                dlg.ExceptionName = exName;
                dlg.ExceptionMessage = msg;
                dlg.InnerException = ex.InnerException == null ? "" : ex.InnerException.Message;
                dlg.ShowDialog();
                try
                {
                    EventLog ev = new EventLog("Application");
                    ev.Source = "EkipSln";
                    if (!EventLog.SourceExists("EkipSln"))
                        EventLog.CreateEventSource(ev.Source, "Application");
                    ev.WriteEntry(msg);
                    ev.Close();
                }
                catch { }
            }
            catch (Exception)
            {
                try
                {
                    XtraMessageBox.Show("Tanımlanamayan hata", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                finally
                {
                    Environment.Exit(1);
                }
            }
        }

        public void OnThreadException(object sender, ThreadExceptionEventArgs e)
        {
            HandleUnhandledException(sender, e.Exception);
        }
    }
}
