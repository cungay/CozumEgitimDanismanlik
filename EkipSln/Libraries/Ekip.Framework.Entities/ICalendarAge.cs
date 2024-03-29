﻿using System;
using System.ComponentModel;

namespace Ekip.Framework.Entities
{
	/// <summary>
	///		The data structure representation of the 'CalendarAge' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface ICalendarAge 
	{
		/// <summary>			
		/// CalendarAgeId : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "CalendarAge"</remarks>
		System.Int32 CalendarAgeId { get; set; }
				
		
		
		/// <summary>
		/// AgeDescription : 
		/// </summary>
		System.String  AgeDescription  { get; set; }
		
		/// <summary>
		/// MinValue : 
		/// </summary>
		System.Int32?  MinValue  { get; set; }
		
		/// <summary>
		/// MaxValue : 
		/// </summary>
		System.Int32?  MaxValue  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties

		#endregion Data Properties

	}
}


