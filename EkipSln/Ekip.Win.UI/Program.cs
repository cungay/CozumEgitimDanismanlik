using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Ekip.Framework.Entities;

namespace Ekip.Win.UI
{
    static class Program
    {
        //public static DataConnectionConfiguration DataConfig { get; set; }

        public static Client CurrentClient { get; set; }

        public static CultureInfo CurrentCulture
        {
            get
            {
                return CultureInfo.CreateSpecificCulture("tr-TR");
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Thread.CurrentThread.CurrentUICulture = CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CurrentCulture;
            CultureInfo.DefaultThreadCurrentCulture = CurrentCulture;
            CultureInfo.DefaultThreadCurrentUICulture = CurrentCulture;

            CurrentCulture.DateTimeFormat.DateSeparator = "/";
            CurrentCulture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";

            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.Skins.SkinManager.EnableMdiFormSkins();
            DevExpress.LookAndFeel.LookAndFeelHelper.ForceDefaultLookAndFeelChanged();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "Whiteprint";

            //Ekip.Win.Framework.ExceptionDialog.ExceptionHandler handler = new Win.Framework.ExceptionDialog.ExceptionHandler();
            //AppDomain.CurrentDomain.UnhandledException += handler.OnUnhandledException;
            //Application.ThreadException += handler.OnThreadException;

            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
            Application.ThreadException += OnThreadException;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ModulesRegistration.Register();
            Application.Run(new Forms.frmLogin());
        }

        private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            
            Debug.WriteLine((e.ExceptionObject as Exception).Message);
            //throw new NotImplementedException();
        }

        private static void OnThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Debug.WriteLine(e.Exception.Message);
            throw new NotImplementedException();
        }
    }
}