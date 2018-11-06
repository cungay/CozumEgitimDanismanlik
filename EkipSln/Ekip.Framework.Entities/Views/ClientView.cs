#region Using directives

using System;

#endregion

namespace Ekip.Framework.Entities
{	
	///<summary>
	/// An object representation of the 'ClientView' view. [No description found in the database]	
	///</summary>
	/// <remarks>
	/// This file is generated once and will never be overwritten.
	/// </remarks>	
	[Serializable]
	[CLSCompliant(true)]
	public partial class ClientView : ClientViewBase
	{
		#region Constructors

		///<summary>
		/// Creates a new <see cref="ClientView"/> instance.
		///</summary>
		public ClientView():base(){}	
		
		#endregion

        public DateTime? BirthDate1 { get; set; }
        public DateTime? BirthDate2 { get; set; }

        public int? Age1 { get; set; }
        public int? Age2 { get; set; }

        public DateTime? FirstDate1 { get; set; }
        public DateTime? FirstDate2 { get; set; }

        public string AdvisorIdList { get; set; }
	}
}
