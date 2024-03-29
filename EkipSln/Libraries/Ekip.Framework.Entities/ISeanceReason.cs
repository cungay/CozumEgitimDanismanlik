﻿using System;
using System.ComponentModel;

namespace Ekip.Framework.Entities
{
	/// <summary>
	///		The data structure representation of the 'SeanceReason' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface ISeanceReason 
	{
		/// <summary>			
		/// RowId : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "SeanceReason"</remarks>
		System.Int32 RowId { get; set; }
				
		
		
		/// <summary>
		/// SeanceId : 
		/// </summary>
		System.Int32?  SeanceId  { get; set; }
		
		/// <summary>
		/// ReasonId : 
		/// </summary>
		System.Int32?  ReasonId  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties

		#endregion Data Properties

	}
}


