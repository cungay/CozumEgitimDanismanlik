#region Using directives

using System;

#endregion

namespace Ekip.Framework.Entities
{	
	///<summary>
	/// An object representation of the 'NeighborhoodView' view. [No description found in the database]	
	///</summary>
	/// <remarks>
	/// This file is generated once and will never be overwritten.
	/// </remarks>	
	[Serializable]
	[CLSCompliant(true)]
	public partial class NeighborhoodView : NeighborhoodViewBase
	{
		#region Constructors

		///<summary>
		/// Creates a new <see cref="NeighborhoodView"/> instance.
		///</summary>
		public NeighborhoodView():base(){}

        #endregion

        public override string ToString()
        {
            return NeighborhoodName;
        }
    }
}
