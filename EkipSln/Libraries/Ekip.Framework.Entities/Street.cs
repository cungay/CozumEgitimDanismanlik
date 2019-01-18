#region Using directives

using System;

#endregion

namespace Ekip.Framework.Entities
{	
	///<summary>
	/// An object representation of the 'Street' table. [No description found the database]	
	///</summary>
	/// <remarks>
	/// This file is generated once and will never be overwritten.
	/// </remarks>	
	[Serializable]
	[CLSCompliant(true)]
	public partial class Street : StreetBase
	{		
		#region Constructors

		///<summary>
		/// Creates a new <see cref="Street"/> instance.
		///</summary>
		public Street():base(){}

        #endregion

        #region  Override ToString

        public override string ToString()
        {
            return string.Format("{0} | {1}", StreetName, ZipCode);
        }

        #endregion
    }
}
