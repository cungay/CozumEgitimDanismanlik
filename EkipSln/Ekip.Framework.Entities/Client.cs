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
		public Client():base(){}	
		
		#endregion

        #region Custom Functions

        public int? CalcAge()
        {
            int? result = null;

            if (BirthDate > DateTime.MinValue)
            {
                int year = BirthDate.Value.Year;
                int today = DateTime.Now.Year;
                //this.Age = today - year;
                result = today - year;
            }

            return result;
        }

        #endregion

        protected override void AddValidationRules()
        {
            base.AddValidationRules();

            ValidationRules.AddRule(Validation.CommonRules.StringRequired, new Validation.ValidationRuleArgs("FullName", "Full Name"));
        }
    }

    [DefaultValue(0)]
    public enum Gender
    {
        [Description("BELİRTİLMEDİ")]
        None = 0,
        [Description("ERKEK")]
        Male = 1,
        [Description("KIZ")]
        Famale = 2
    }

    [DefaultValue(0)]
    public enum Blood
    {
        [Description("BELİRTİLMEDİ")]
        None = 0,
        [Description("ÖZ")]
        Self = 1,
        [Description("EVLAT EDİNME")]
        FosterChild = 2,
        [Description("ÜVEY")]
        StepChild = 3
    }

    [DefaultValue(0)]
    public enum FamilyStatus
    {
        [Description("BELİRTİLMEDİ")]
        None = 0,
        [Description("EVLİ")]
        Married = 1,
        [Description("AYRI")]
        Leave = 2,
        [Description("2. EVLİLİK(Tekrar)")]
        Remarried = 3,
        [Description("BOŞANMA")]
        Dicorved = 4
    }
}
