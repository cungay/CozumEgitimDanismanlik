using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Ekip.Framework.UI.ExceptionDialog
{
    public partial class ExDetails : DevExpress.XtraEditors.XtraForm
    {
        public ExDetails()
        {
            InitializeComponent();
        }

        public string ExceptionName
        {
            get 
            {
                return this.Text; 
            }
            
            set 
            {
                this.Text = value; 
            }
        }

        public string ExceptionMessage
        {
            get 
            {
                return txtExMessage.Text; 
            }
            
            set 
            {
                txtExMessage.Text = value; 
            }
        }

        private string innerException = string.Empty;

        public string InnerException
        {
            get { return innerException; }
            set { innerException = value; }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            txtExMessage.Copy();
            XtraMessageBox.Show("Hata mesajı kopyalandı.", "Kopyala", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Utility.MailManager mailManager = null;
        private void btnSendMail_Click(object sender, EventArgs e)
        {
            //mailManager = new Utility.MailManager();
            //using (new WaitCursor())
            //{
            //    Application.DoEvents();
            //    mailManager.SendMail("ihsancungay@hotmail.com", "EkipSln:Error", InnerException, null);
            //    mailManager.OnCompleted += new Utility.MailManager.SendingCompleteEventHandler(mailManager_OnCompleted);
            //}
        }

        //void mailManager_OnCompleted(object sender, Utility.SendingEventArgs e)
        //{
        //    XtraMessageBox.Show("Hata mesajı gönderildi.", "Gönder", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //}

        private void btnPrint_Click(object sender, EventArgs e)
        {
            
        }
    }
}