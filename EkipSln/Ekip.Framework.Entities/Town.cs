﻿#region Using directives

using System;

#endregion

namespace Ekip.Framework.Entities
{	
	///<summary>
	/// An object representation of the 'Town' table. [No description found the database]	
	///</summary>
	/// <remarks>
	/// This file is generated once and will never be overwritten.
	/// </remarks>	
	[Serializable]
	[CLSCompliant(true)]
	public partial class Town : TownBase
	{		
		#region Constructors

		///<summary>
		/// Creates a new <see cref="Town"/> instance.
		///</summary>
		public Town():base(){}

        #endregion

        public override string ToString()
        {
            return TownName;
        }
    }
}
