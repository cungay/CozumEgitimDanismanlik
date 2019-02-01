#region Using directives

using System;

#endregion

namespace Ekip.Framework.Entities
{	
	///<summary>
	/// An object representation of the 'CalendarAge' table. [No description found the database]	
	///</summary>
	/// <remarks>
	/// This file is generated once and will never be overwritten.
	/// </remarks>	
	[Serializable]
	[CLSCompliant(true)]
	public partial class CalendarAge : CalendarAgeBase
	{		
		#region Constructors

		///<summary>
		/// Creates a new <see cref="CalendarAge"/> instance.
		///</summary>
		public CalendarAge():base(){}

        #endregion

        #region Properties

        public int Years { get; set; }

        public int Months { get; set; }

        public int Days { get; set; }

        #endregion
    }
}
