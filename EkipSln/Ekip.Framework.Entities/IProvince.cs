﻿using System;
using System.ComponentModel;

namespace Ekip.Framework.Entities
{
	/// <summary>
	///		The data structure representation of the 'Province' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IProvince 
	{
		/// <summary>			
		/// Id : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "Province"</remarks>
		System.Int32 Id { get; set; }
				
		
		
		/// <summary>
		/// RowNumber : 
		/// </summary>
		System.Int32  RowNumber  { get; set; }
		
		/// <summary>
		/// AdminId : 
		/// </summary>
		System.Int64  AdminId  { get; set; }
		
		/// <summary>
		/// ObjectId : 
		/// </summary>
		System.Int64  ObjectId  { get; set; }
		
		/// <summary>
		/// ParentId : 
		/// </summary>
		System.Int64  ParentId  { get; set; }
		
		/// <summary>
		/// PlateCode : 
		/// </summary>
		System.String  PlateCode  { get; set; }
		
		/// <summary>
		/// AreaId : 
		/// </summary>
		System.Int32  AreaId  { get; set; }
		
		/// <summary>
		/// PhoneCode : 
		/// </summary>
		System.String  PhoneCode  { get; set; }
		
		/// <summary>
		/// ProvinceName : 
		/// </summary>
		System.String  ProvinceName  { get; set; }
		
		/// <summary>
		/// Longitude : 
		/// </summary>
		System.String  Longitude  { get; set; }
		
		/// <summary>
		/// Latitude : 
		/// </summary>
		System.String  Latitude  { get; set; }
		
		/// <summary>
		/// Type : 
		/// </summary>
		System.Int32  Type  { get; set; }
		
		/// <summary>
		/// CreateDate : 
		/// </summary>
		System.DateTime  CreateDate  { get; set; }
		
		/// <summary>
		/// CreateTime : 
		/// </summary>
		System.TimeSpan  CreateTime  { get; set; }
		
		/// <summary>
		/// UpdateDate : 
		/// </summary>
		System.DateTime?  UpdateDate  { get; set; }
		
		/// <summary>
		/// UpdateTime : 
		/// </summary>
		System.TimeSpan?  UpdateTime  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _townProvinceId
		/// </summary>	
		TList<Town> TownCollection {  get;  set;}	

		#endregion Data Properties

	}
}


