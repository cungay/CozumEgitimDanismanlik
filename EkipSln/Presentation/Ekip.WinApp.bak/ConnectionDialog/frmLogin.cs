using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using Ekip.Framework.Entities;
using Microsoft.Data.ConnectionUI;
using DevExpress.XtraSplashScreen;
using Ekip.Framework.Services;

namespace Ekip.WinApp.ConnectionDialog
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public string Password { get { return txtPwd.Text; } }
        public string UserName { get { return txtUid.Text; } }

        private readonly SessionService sessionService = null;

        public frmLogin()
        {
            InitializeComponent();
            sessionService = new SessionService();

            txtUid.Focus();
            txtUid.Select();
        }

        private void InputValidate()
        {
            if (txtUid.Text.Trim().Length == 0)
            {
                txtUid.Focus();
                throw new Exception("Kullanıcı adınızı giriniz.");
            }
            if (txtPwd.Text.Trim().Length == 0)
            {
                txtPwd.Focus();
                throw new Exception("Parolanızı giriniz.");
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DataConnectionConfiguration dcs = new DataConnectionConfiguration(null);
            dcs.InitializeProvider();
            Program.DataConfig = dcs;

            InputValidate();
            Session user = sessionService.GetByUserName(txtUid.Text);
            Program.CurrentUser = user ?? throw new Exception("Giriş başarısız.\nKullanıcı adı ve şifrenizi kontrol ediniz.");
            this.Hide();
            SplashScreenManager.ShowForm(this, typeof(frmSplashScreen), true, true, false);

            // The splash screen will be opened in a separate thread. To interact with it, use the SendCommand method.
            for (int i = 1; i <= 100; i++)
            {
                SplashScreenManager.Default.SendCommand(frmSplashScreen.SplashScreenCommand.SetProgress, i);
                //To process commands, override the SplashScreen.ProcessCommand method.
                System.Threading.Thread.Sleep(25);
            }

            SplashScreenManager.CloseForm(false);
            frmMain mainForm = new frmMain();
            mainForm.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void On_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOk_Click(null, null);
            }
        }

        private void btnServer_Click(object sender, EventArgs e)
        {
            DataConnectionDialog dcd = new DataConnectionDialog();
            dcd.SaveSelection = true;

            DataConnectionConfiguration dcs = new DataConnectionConfiguration(null);
            dcs.LoadConfiguration(dcd);

            if (DataConnectionDialog.Show(dcd) == DialogResult.OK)
            {
                SqlConnection cn = null;

                try
                {
                    using (cn = new SqlConnection(dcd.ConnectionString))
                    {
                        cn.Open();
                        cn.Close();
                    }

                    dcs.SaveConfiguration(dcd);
                }
                finally
                {
                    if (cn != null)
                    {
                        if (cn.State != System.Data.ConnectionState.Closed)
                        {
                            cn.Close();
                        }

                        cn.Dispose();
                    }
                }
            }
        }
    }
}