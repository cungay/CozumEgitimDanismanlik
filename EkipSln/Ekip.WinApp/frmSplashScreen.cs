using DevExpress.XtraSplashScreen;
using Ekip.Framework.Data;
using Ekip.Framework.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ekip.WinApp
{
    public partial class frmSplashScreen : SplashScreen
    {
        public frmSplashScreen()
        {
            InitializeComponent();
            this.labelControl1.Text = string.Format("Copyright {0}-{1}", 
                DateTime.Now.Date.Year, 
                DateTime.Now.Date.AddYears(1).Year);
        }

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
            SplashScreenCommand command = (SplashScreenCommand)cmd;
            if (command == SplashScreenCommand.SetProgress)
            {
                int pos = (int)arg;
                progressBarControl1.Position = pos;
            }
        }

        public enum SplashScreenCommand
        {
            SetProgress
        }
    }
}
