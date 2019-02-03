#region Using directives

using System;

#endregion

namespace Ekip.Framework.Entities
{	
	///<summary>
	/// An object representation of the 'TownView' view. [No description found in the database]	
	///</summary>
	/// <remarks>
	/// This file is generated once and will never be overwritten.
	/// </remarks>	
	[Serializable]
	[CLSCompliant(true)]
	public partial class TownView : TownViewBase
	{
		#region Constructors

		///<summary>
		/// Creates a new <see cref="TownView"/> instance.
		///</summary>
		public TownView():base(){}

        #endregion

        public override string ToString()
        {
            return TownName;
        }
    }
}
