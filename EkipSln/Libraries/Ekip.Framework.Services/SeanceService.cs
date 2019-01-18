#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Data;

using Ekip.Framework.Entities;
using Ekip.Framework.Entities.Validation;

using Ekip.Framework.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;

#endregion

namespace Ekip.Framework.Services
{
    /// <summary>
    /// An component type implementation of the 'Seance' table.
    /// </summary>
    /// <remarks>
    /// All custom implementations should be done here.
    /// </remarks>
    [CLSCompliant(true)]
    public partial class SeanceService : Ekip.Framework.Services.SeanceServiceBase
    {
        #region Fields

        private readonly ReasonService reasonService = null;

        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the SeanceService class.
        /// </summary>
        public SeanceService() : base()
        {
            this.reasonService = new ReasonService();
        }
        #endregion Constructors

        #region Methods

        public TList<Seance> GetAllSeances(int clientId)
        {
            var list = this.GetByClientId(clientId);
            for (int i = 0; i < list.Count; i++)
            {
                var seance = list[i];
                this.DeepLoadBySeanceId(seance.SeanceId, false, DeepLoadType.IncludeChildren, typeof(TList<SeanceReason>));
                for (int k = 0; k < seance.SeanceReasonCollection.Count; k++)
                {
                    var reason = seance.SeanceReasonCollection[k];
                    if (reason.ReasonId.HasValue && reason.ReasonId.Value > 0)
                    {
                        reason.ReasonIdSource = reasonService.GetByReasonId(reason.ReasonId.Value);
                    }
                }
            }
            return list;
        }

        public Seance CreateSeance(int clientId, int userId)
        {
            var seance = new Seance();
            seance.ClientId = clientId;
            seance.AdvisorId = 0;
            seance.SeanceDate = DateTime.Now;
            seance.SeanceTime = DateTime.Now.TimeOfDay;
            seance.SeanceStatus = SeanceStatus.None;
            seance.Active = true;
            seance.Deleted = false;
            seance.CreateDate = DateTime.Now;
            seance.CreatedUserId = userId;
            return seance;
        }

        #endregion

    }//End Class

} // end namespace
