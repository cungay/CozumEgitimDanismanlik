#region Using directives

using System;
using System.ComponentModel;

#endregion

namespace Ekip.Framework.Entities
{	
	///<summary>
	/// An object representation of the 'ClientFather' table. [No description found the database]	
	///</summary>
	/// <remarks>
	/// This file is generated once and will never be overwritten.
	/// </remarks>	
	[Serializable]
	[CLSCompliant(true)]
	public partial class ClientFather : ClientFatherBase
	{		
		#region Constructors

		///<summary>
		/// Creates a new <see cref="ClientFather"/> instance.
		///</summary>
		public ClientFather():base(){}	
		
		#endregion
	}

    [DefaultValue(0)]
    [Description("Durum")]
    public enum ParentStatus
    {
        [Description("Yaşıyor")]
        Alive = 1,
        [Description("Vefat")]
        Died = 2
    }
}
