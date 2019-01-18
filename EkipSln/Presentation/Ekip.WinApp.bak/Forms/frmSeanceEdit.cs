using System;
using System.Windows.Forms;
using Ekip.Framework.Entities;
using Ekip.Framework.Services;
using Ekip.Win.Framework;
using Ekip.Win.Framework.Forms;

namespace Ekip.WinApp.Forms
{
    public partial class frmSeanceEdit : BaseForm
    {
        #region Fields

        private Seance seance = null;
        private readonly ReasonService reasonService = null;
        private readonly AdvisorService advisorService = null;
        private readonly SeanceService seanceService = null;

        #endregion

        #region Ctor

        public frmSeanceEdit(Seance seance = null)
        {
            this.seance = seance;
            seanceService = new SeanceService();
            reasonService = new ReasonService();
            advisorService = new AdvisorService();

            InitializeComponent();

            txtSeanceDate.Select();
            txtSeanceDate.Focus();
            btnAccept.Click += AcceptChanges;

            txtSeanceTime.Properties.Mask.EditMask = "HH:mm";
            txtSeanceTime.Properties.Mask.UseMaskAsDisplayFormat = true;

            lkAdvisor.Bind(advisorService.GetAll(true), "FullName", "AdvisorId", "Danışman Listesi");
            lkSeanceStatus.BindEnum(typeof(SeanceStatus), "Durum");
            cblReasonList.DataSource = reasonService.GetAll();
        }

        #endregion

        #region OnShown

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (seance == null)
            {
                seance = seanceService.CreateSeance(Program.CurrentClient.ClientId, Program.CurrentUser.SessionId);
            }

            //txtFileNumber.EditValue = Program.CurrentClient.FileNumber.ToString();
            //txtFullName.EditValue = Program.CurrentClient.FullName;

            this.DataBind(seance);

            CheckReasonList();

            seance.AcceptChanges();
        }

        #endregion

        #region SeanceReason

        private void CheckReasonList()
        {
            if (seance.SeanceReasonCollection.Count > 0)
            {
                int[] indexes = new int[seance.SeanceReasonCollection.Count];

                for (int i = 0; i < seance.SeanceReasonCollection.Count; i++)
                {
                    var item = seance.SeanceReasonCollection[i];

                    if (item.ReasonId.HasValue && item.ReasonId.Value > 0)
                    {
                        if (item.ReasonIdSource != null)
                        {
                            var reason = item.ReasonIdSource;

                            int rowIndex = (cblReasonList.DataSource as TList<Reason>).FindIndex(x => x.ReasonKey == reason.ReasonKey);

                            if (rowIndex >= 0)
                            {
                                this.cblReasonList.SetItemChecked(rowIndex, true);
                                indexes[i] = rowIndex;
                            }
                        }
                    }
                }

                cblReasonList.TopIndex = indexes[0];
            }

            cblReasonList.ItemCheck += OnItemCheck;
        }

        private void OnItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            var item = cblReasonList.GetItem(e.Index);

            if (item != null)
            {
                var reason = (item as Reason);

                if (e.State == CheckState.Checked)
                {
                    AddReason(reason);
                }
                else if (e.State == CheckState.Unchecked)
                {
                    RemoveReason(reason.ReasonId);
                }
            }
        }

        private void AddReason(Reason reason)
        {
            var sr = new SeanceReason();
            sr.SeanceId = seance.SeanceId;
            sr.ReasonId = reason.ReasonId;
            var reasonSource = reasonService.GetByReasonId(reason.ReasonId);
            if (reasonSource != null)
                sr.ReasonIdSource = reasonSource;
            seance.SeanceReasonCollection.Add(sr);
        }

        private void RemoveReason(int reasonId)
        {
            if (seance.SeanceReasonCollection.Count > 0)
            {
                var reason = seance.SeanceReasonCollection.Find(p => p.ReasonId == reasonId);

                if (reason != null)
                {
                    seance.SeanceReasonCollection.Remove(reason);
                }
            }
        }

        #endregion

        #region FormClosing

        private void AcceptChanges(object sender, EventArgs e)
        {
            seance.Validate();

            foreach (Framework.Entities.Validation.BrokenRule rule in seance.BrokenRulesList)
            {

            }

            seance.AcceptChanges();
            seance.SeanceReasonCollection.AcceptChanges();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Cancel)
            {
                if (seance.HasDataChanged() || seance.SeanceReasonCollection.AllChangesCount > 0)
                {
                    var result = UserDialog.Confirm(this, "Değişiklikler kaydedilmedi.\nDevam etmek istiyor musunuz ?");

                    if (result == DialogResult.Yes)
                    {
                        seance.CancelChanges();
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
                return;
            }

            base.OnFormClosing(e);
        }

        #endregion

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }
    }
}
