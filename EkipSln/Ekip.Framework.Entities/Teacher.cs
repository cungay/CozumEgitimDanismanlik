#region Using directives

using System;
using System.ComponentModel;

#endregion

namespace Ekip.Framework.Entities
{	
	///<summary>
	/// An object representation of the 'Teacher' table. [No description found the database]	
	///</summary>
	/// <remarks>
	/// This file is generated once and will never be overwritten.
	/// </remarks>	
	[Serializable]
	[CLSCompliant(true)]
	public partial class Teacher : TeacherBase
	{		
		#region Constructors

		///<summary>
		/// Creates a new <see cref="Teacher"/> instance.
		///</summary>
		public Teacher():base()
        {
            //this.BranchId = 2;
        }	
		
		#endregion
	}

    [DefaultValue(0)]
    public enum TeacherBranch
    {
        [Description("Belirtilmedi")]
        None = 0,
        [Description("Sınıf Öğretmeni")]
        ClassRoom = 1,
        [Description("Rehber Öğretmen")]
        Guide = 2,
        [Description("Diğer")]
        Other = 3
    }
}
