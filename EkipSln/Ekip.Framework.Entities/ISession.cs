﻿using System;
using System.ComponentModel;

namespace Ekip.Framework.Entities
{
	/// <summary>
	///		The data structure representation of the 'Session' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface ISession 
	{
		/// <summary>			
		/// SessionID : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "Session"</remarks>
		System.Int32 SessionId { get; set; }
				
		
		
		/// <summary>
		/// UserName : 
		/// </summary>
		System.String  UserName  { get; set; }
		
		/// <summary>
		/// Password : 
		/// </summary>
		System.String  Password  { get; set; }
		
		/// <summary>
		/// CreateOn : 
		/// </summary>
		System.DateTime  CreateOn  { get; set; }
		
		/// <summary>
		/// UpdateOn : 
		/// </summary>
		System.DateTime?  UpdateOn  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties

		#endregion Data Properties

	}
}


