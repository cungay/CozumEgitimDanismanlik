﻿using System;
using System.ComponentModel;

namespace Ekip.Framework.Entities
{
	/// <summary>
	///		The data structure representation of the 'District' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IDistrict 
	{
		/// <summary>			
		/// DistrictId : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "District"</remarks>
		System.Int32 DistrictId { get; set; }
				
		
		
		/// <summary>
		/// CityId : 
		/// </summary>
		System.Int32  CityId  { get; set; }
		
		/// <summary>
		/// DistrictName : 
		/// </summary>
		System.String  DistrictName  { get; set; }
		
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
		///	which are related to this object through the relation _regionDistrictId
		/// </summary>	
		TList<Region> RegionCollection {  get;  set;}	

		#endregion Data Properties

	}
}

