﻿using System;
using System.ComponentModel;

namespace Ekip.Framework.Entities
{
	/// <summary>
	///		The data structure representation of the 'Appointment' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IAppointment 
	{
		/// <summary>			
		/// AppointmentID : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "Appointment"</remarks>
		System.Int32 AppointmentId { get; set; }
				
		
		
		/// <summary>
		/// ClientID : 
		/// </summary>
		System.Int32  ClientId  { get; set; }
		
		/// <summary>
		/// DoctorID : 
		/// </summary>
		System.Int32?  DoctorId  { get; set; }
		
		/// <summary>
		/// CalenderAgeID : 
		/// </summary>
		System.Int32?  CalenderAgeId  { get; set; }
		
		/// <summary>
		/// ReasonID : 
		/// </summary>
		System.Int32?  ReasonId  { get; set; }
		
		/// <summary>
		/// Symptom : 
		/// </summary>
		System.String  Symptom  { get; set; }
		
		/// <summary>
		/// Complaint : 
		/// </summary>
		System.String  Complaint  { get; set; }
		
		/// <summary>
		/// Finding : 
		/// </summary>
		System.String  Finding  { get; set; }
		
		/// <summary>
		/// AppointmentDate : 
		/// </summary>
		System.DateTime?  AppointmentDate  { get; set; }
		
		/// <summary>
		/// AppointmentNote : 
		/// </summary>
		System.String  AppointmentNote  { get; set; }
		
		/// <summary>
		/// Status : 
		/// </summary>
		System.Int32?  Status  { get; set; }
		
		/// <summary>
		/// CreateOn : 
		/// </summary>
		System.DateTime  CreateOn  { get; set; }
		
		/// <summary>
		/// UpdateOn : 
		/// </summary>
		System.DateTime?  UpdateOn  { get; set; }
		
		/// <summary>
		/// UserID : 
		/// </summary>
		System.Int32  UserId  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties

		#endregion Data Properties

	}
}


