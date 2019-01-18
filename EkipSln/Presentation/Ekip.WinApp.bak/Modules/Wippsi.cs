using System;
using System.Windows.Forms;
using AppFramework;
using Ekip.Framework.Entities;
using Ekip.Framework.Services;
using Ekip.WinApp.Forms;
using DevExpress.XtraEditors.Controls;
using Ekip.Framework.Core;
using Ekip.Win.Framework.Forms;
using Ekip.Win.Framework;
using Ekip.Framework.Data;

namespace Ekip.WinApp.Modules
{
    public partial class Wippsi : BaseModule
    {
        #region Override ToolBar
        protected override bool HasFind { get { return true; } }
        protected override bool HasRefresh { get { return true; } }
        #endregion

        private Seance currentSeance = null;

        public Wippsi()
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
                if (gwWippsi.FocusedRowHandle >= 0)
                {
                    WippsiView wippsiRow = (WippsiView)gwWippsi.GetRow(gwWippsi.FocusedRowHandle);

                    if (wippsiRow != null)
                    {
                        currentSeance = DataRepository.SeanceProvider.GetBySeanceId(wippsiRow.SeanceId);

                        if (currentSeance.WippsiId.HasValue)
                        {
                            currentSeance.WippsiIdSource = DataRepository.WippsiProvider.GetByWippsiId(currentSeance.WippsiId.Value);
                            currentSeance.WippsiIdSource.UpdateDate = DateTime.Now;
                        }
                        else
                        {
                            currentSeance.WippsiIdSource = new Framework.Entities.Wippsi();
                            currentSeance.WippsiIdSource.UserId = Program.CurrentUser.SessionId;
                            currentSeance.WippsiIdSource.CreateDate = DateTime.Now;
                        }

                        frmWippsiEdit dlg = new frmWippsiEdit(currentSeance.WippsiIdSource);

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
                        if (currentSeance.WippsiIdSource.IsNew)
                        {
                            //DataRepository.WippsiProvider.Save(tm, currentSeance.WippsiIdSource);

                            DataRepository.WippsiProvider.Insert(tm, currentSeance.WippsiIdSource);
                            currentSeance.WippsiId = currentSeance.WippsiIdSource.WippsiId;
                            DataRepository.SeanceProvider.Update(tm, currentSeance);

                            currentSeance.AcceptChanges();
                            currentSeance.WippsiIdSource.AcceptChanges();
                        }
                        else
                        {
                            DataRepository.WippsiProvider.Update(tm, currentSeance.WippsiIdSource);

                            currentSeance.AcceptChanges();
                            currentSeance.WippsiIdSource.AcceptChanges();
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
            using (new WaitCursor())
            {
                //VList<WippsiView> list = DataRepository.WippsiViewProvider.GetByClientID(Program.CurrentClient.ClientId);
                //gcWippsi.DataSource = list;
            }
        }
    }
}
