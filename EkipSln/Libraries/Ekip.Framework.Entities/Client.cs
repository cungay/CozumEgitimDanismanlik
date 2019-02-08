#region Using directives

using System;
using System.ComponentModel;

#endregion

namespace Ekip.Framework.Entities
{
    ///<summary>
    /// An object representation of the 'Client' table. [No description found the database]	
    ///</summary>
    /// <remarks>
    /// This file is generated once and will never be overwritten.
    /// </remarks>	
    [Serializable]
    [CLSCompliant(true)]
    public partial class Client : ClientBase
    {
        #region Constructors

        ///<summary>
        /// Creates a new <see cref="Client"/> instance.
        ///</summary>
        public Client() : base() { }

        #endregion

        #region Custom Functions
        
        #endregion

        //protected override void AddValidationRules()
        //{
        //    base.AddValidationRules();

        //    ValidationRules.AddRule(Validation.CommonRules.StringRequired, new Validation.ValidationRuleArgs("FullName", "Full Name"));
        //}
    }

    [DefaultValue(0)]
    [Description("Cinsiyet")]
    public enum Gender
    {
        //[Description("Belirtilmedi")]
        //None = 0,
        [Description("Erkek")]
        Male = 1,
        [Description("Kız")]
        Famale = 2
    }

    [DefaultValue(0)]
    [Description("Özlük Durumu")]
    public enum Blood
    {
        //[Description("Belirtilmedi")]
        //None = 0,
        [Description("Öz")]
        Self = 1,
        [Description("Evlatlık")]
        FosterChild = 2,
        [Description("Üvey")]
        StepChild = 3
    }

    [DefaultValue(0)]
    [Description("Anne - Baba Durumu")]
    public enum FamilyStatus
    {
        //[Description("Belirtilmedi")]
        //None = 0,
        [Description("Evli")]
        Married = 1,
        [Description("Ayrı")]
        Leave = 2,
        [Description("Evlilik Tekrarı")]
        Remarried = 3,
        [Description("Boşanma")]
        Dicorved = 4
    }
}
