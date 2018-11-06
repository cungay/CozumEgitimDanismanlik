﻿using System;
using System.ComponentModel;

namespace Ekip.Framework.Entities
{
	/// <summary>
	///		The data structure representation of the 'City' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface ICity 
	{
		/// <summary>			
		/// CityId : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "City"</remarks>
		System.Int32 CityId { get; set; }
				
		
		
		/// <summary>
		/// CityName : 
		/// </summary>
		System.String  CityName  { get; set; }
		
		/// <summary>
		/// RowNumber : 
		/// </summary>
		System.Int32?  RowNumber  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _districtCityId
		/// </summary>	
		TList<District> DistrictCollection {  get;  set;}	

		#endregion Data Properties

	}
}


