#region Using directives

using System;

#endregion

namespace Ekip.Framework.Entities
{	
	///<summary>
	/// An object representation of the 'Neighborhood' table. [No description found the database]	
	///</summary>
	/// <remarks>
	/// This file is generated once and will never be overwritten.
	/// </remarks>	
	[Serializable]
	[CLSCompliant(true)]
	public partial class Neighborhood : NeighborhoodBase
	{		
		#region Constructors

		///<summary>
		/// Creates a new <see cref="Neighborhood"/> instance.
		///</summary>
		public Neighborhood():base(){}

        #endregion

        #region  Override ToString

        public override string ToString()
        {
            return NeighborhoodName;
        }

        #endregion
    }
}
