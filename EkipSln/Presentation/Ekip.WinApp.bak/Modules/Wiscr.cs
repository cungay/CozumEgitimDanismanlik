using System;
using System.Windows.Forms;
using AppFramework;
using Ekip.Framework.Entities;
using Ekip.Framework.Services;
using DevExpress.XtraEditors.Controls;
using Ekip.WinApp.Forms;
using Ekip.Framework.Core;
using Ekip.Win.Framework.Forms;
using Ekip.Win.Framework;
using Ekip.Framework.Data;

namespace Ekip.WinApp.Modules
{
    public partial class Wiscr : BaseModule
    {
        #region Override ToolBar
        protected override bool HasFind { get { return true; } }
        protected override bool HasRefresh { get { return true; } }
        #endregion

        private Seance currentSeance = null;

        public Wiscr()
        {
            InitializeComponent();           
        }

        public override void InitForm()
        {
            InitData();
        }

        public override void UpdateActions()
        {
            base.UpdateActions();
            Actions[ActionKeys.New].Visible = false;
            Actions[ActionKeys.Save].Visible = false;
        }

        private void InitData()
        {
            this.txtFullName.EditValue = Program.CurrentClient.FullName;
            this.txtFileNumber.EditValue = Program.CurrentClient.FileNumber;
            DateTime birthDate = Program.CurrentClient.BirthDate.Value;
            this.txtBirthDate.EditValue = birthDate.ToShortDateString();
            this.txtAge.EditValue = DateTime.Now.Year - birthDate.Year;
            this.txtFather.EditValue = Program.CurrentClient.FatherIdSource.FullName;
            this.txtMother.EditValue = Program.CurrentClient.MotherIdSource.FullName;
            this.txtGender.EditValue = ((Gender)Program.CurrentClient.Gender).GetDescription();
            //if (Program.CurrentClient.SchoolIdSource != null)
            //{
            //    this.txtClassRoom.EditValue = ((ClassRoom)Program.CurrentClient.SchoolIdSource.ClassRoom).GetDescription();
            //    this.txtSchool.EditValue = Program.CurrentClient.SchoolIdSource.SchoolName;
            //}

            DoRefresh();
        }

        private void btnSelect_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            using (new WaitCursor())
            {
                if (gwWiscr.FocusedRowHandle >= 0)
                {
                    WiscrView wiscrRow = (WiscrView)gwWiscr.GetRow(gwWiscr.FocusedRowHandle);

                    if (wiscrRow != null)
                    {
                        currentSeance = DataRepository.SeanceProvider.GetBySeanceId(wiscrRow.SeanceId);

                        if (currentSeance.WiscrId.HasValue)
                        {
                            currentSeance.WiscrIdSource = DataRepository.WiscrProvider.GetByWiscrId(currentSeance.WiscrId.Value);
                            currentSeance.WiscrIdSource.UpdateDate = DateTime.Now;
                        }
                        else
                        {
                            currentSeance.WiscrIdSource = new Framework.Entities.Wiscr();
                            currentSeance.WiscrIdSource.UserId = Program.CurrentUser.SessionId;
                            currentSeance.WiscrIdSource.CreateDate = DateTime.Now;
                        }

                        frmWiscrEdit dlg = new frmWiscrEdit(currentSeance.WiscrIdSource);

                        if (dlg.ShowDialog() == DialogResult.OK)
                        {
                            DoSave();
                        }
                    }
                }
            }
        }

        protected override void DoSave()
        {
            TransactionManager tm = null;

            try
            {
                if (currentSeance.IsValid)
                {
                    bool isBorrowedTransaction = ConnectionScope.Current.HasTransaction;
                    tm = ConnectionScope.ValidateOrCreateTransaction(true);

                    if (!isBorrowedTransaction && tm != null && tm.IsOpen)
                    {
                        if (currentSeance.WiscrIdSource.IsNew)
                        {
                            DataRepository.WiscrProvider.Save(tm, currentSeance.WiscrIdSource);
                            currentSeance.WiscrId = currentSeance.WiscrIdSource.WiscrId;
                            DataRepository.SeanceProvider.Update(tm, currentSeance);
                        }
                        else
                        {
                            DataRepository.WiscrProvider.Update(tm, currentSeance.WiscrIdSource);
                        }
                        tm.Commit();
                    }

                   //UserDialog.InformationMessage(this, "Kaydet", "Dosya Kaydedildi.");

                    DoRefresh();
                }
            }
            catch (Exception ex)
            {
                UserDialog.ErrorMessage(this, "Kaydet", ex.Message);
            }
        }

        protected override void DoRefresh()
        {
            //VList<WiscrView> list = DataRepository.WiscrViewProvider.GetByClientID(Program.CurrentClient.ClientId);
            //gcWiscr.DataSource = list;
        }
    }
}
