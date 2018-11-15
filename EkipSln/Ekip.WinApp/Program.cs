using System;
using System.Windows.Forms;
using Ekip.Framework.Entities;
using Ekip.WinApp.ConnectionDialog;

namespace Ekip.WinApp
{
    static class Program
    {
        public static Session CurrentUser { get; set; }

        public static DataConnectionConfiguration DataConfig { get; set; }

        public static Client CurrentClient { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CreateSpecificCulture("tr-TR");
            System.Threading.Thread.CurrentThread.CurrentUICulture = culture;
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture = culture;
            System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = culture;

            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.Skins.SkinManager.EnableMdiFormSkins();
            DevExpress.LookAndFeel.LookAndFeelHelper.ForceDefaultLookAndFeelChanged();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "Whiteprint";

            Ekip.Win.Framework.ExceptionDialog.ExceptionHandler handler = new Win.Framework.ExceptionDialog.ExceptionHandler();
            AppDomain.CurrentDomain.UnhandledException += handler.OnUnhandledException;
            Application.ThreadException += handler.OnThreadException;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ModulesRegistration.Register();
            Application.Run(new Ekip.WinApp.ConnectionDialog.frmLogin());
        }
    }
}
