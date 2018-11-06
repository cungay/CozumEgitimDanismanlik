﻿#region Using directives

using System;

#endregion

namespace Ekip.Framework.Entities
{	
	///<summary>
	/// An object representation of the 'Reason' table. [No description found the database]	
	///</summary>
	/// <remarks>
	/// This file is generated once and will never be overwritten.
	/// </remarks>	
	[Serializable]
	[CLSCompliant(true)]
	public partial class Reason : ReasonBase
	{		
		#region Constructors

		///<summary>
		/// Creates a new <see cref="Reason"/> instance.
		///</summary>
		public Reason():base(){}	
		
		#endregion

        private bool isExists = false;
        public bool IsExists
        {
            get { return isExists; }
            set { isExists = value; }
        }

        public override string ToString()
        {
            return string.Format("{0}- {1};", this.ReasonKey, this.ReasonValue);
        }
	}
}
