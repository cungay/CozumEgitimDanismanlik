using System;

namespace Ekip.Win.Framework.ExceptionDialog
{
    public partial class ExDialog : DevExpress.XtraEditors.XtraForm
    {
        public ExDialog()
        {
            InitializeComponent();

            System.Media.SystemSounds.Exclamation.Play();
        }

        public string ExceptionName
        {
            get 
            {
                return this.lblErrorName.Text; 
            }
            
            set 
            {
                this.lblErrorName.Text = value; 
            }
        }

        private string exceptionMessage = null;
        public string ExceptionMessage
        {
            get 
            {
                return exceptionMessage; 
            }
            
            set 
            {
                exceptionMessage = value; 
            }
        }

        private string innerException = string.Empty;

        public string InnerException
        {
            get { return innerException; }
            set { innerException = value; }
        }

        private void lnkDetails_Click(object sender, EventArgs e)
        {
            ExDetails dlg = new ExDetails();
            dlg.ExceptionMessage = ExceptionMessage;
            dlg.ExceptionName = ExceptionName;
            dlg.InnerException = InnerException;
            dlg.ShowDialog();
        }
    }
}