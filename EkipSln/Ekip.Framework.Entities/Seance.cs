#region Using directives

using Ekip.Framework.Entities.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

#endregion

namespace Ekip.Framework.Entities
{
    ///<summary>
    /// An object representation of the 'Seance' table. [No description found the database]	
    ///</summary>
    /// <remarks>
    /// This file is generated once and will never be overwritten.
    /// </remarks>	
    [Serializable]
    [CLSCompliant(true)]
    public partial class Seance : SeanceBase
    {
        #region Constructors

        ///<summary>
        /// Creates a new <see cref="Seance"/> instance.
        ///</summary>
        public Seance() : base() { }

        #endregion

        #region Properties

        public SeanceStatus SeanceStatus
        {
            get
            {
                return (SeanceStatus)SeanceStatusId;
            }
            set
            {
                SeanceStatusId = (byte)value;
            }
        }

        #endregion

        #region ValidationRules

        protected override void AddValidationRules()
        {
            ValidationRules.AddRule(CommonRules.LessThanOrEqualToValue<int>, new CommonRules.CompareValueRuleArgs<int>("AdvisorId", 0));
        }

        #endregion
    }

    [DefaultValue(0)]
    public enum SeanceStatus
    {
        [Description("Belirtilmedi")]
        None = 0,
        [Description("Randevu Alındı")]
        Received = 1,
        [Description("Randevu İptal")]
        Cancel = 2,
        [Description("Randevuya Gelmedi")]
        NotCome = 3,
        [Description("Randevu Ertelendi")]
        PostPoned = 4,
        [Description("Tamamlandı")]
        Ok = 5
    }
}
