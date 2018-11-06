﻿using System;
using System.ComponentModel;

namespace Ekip.Framework.Entities
{
	/// <summary>
	///		The data structure representation of the 'ClientForm' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IClientForm 
	{
		/// <summary>			
		/// FormID : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "ClientForm"</remarks>
		System.Int32 FormId { get; set; }
				
		
		
		/// <summary>
		/// FormCode : 
		/// </summary>
		System.String  FormCode  { get; set; }
		
		/// <summary>
		/// Name : 
		/// </summary>
		System.String  Name  { get; set; }
		
		/// <summary>
		/// Title : 
		/// </summary>
		System.String  Title  { get; set; }
		
		/// <summary>
		/// Description : 
		/// </summary>
		System.String  Description  { get; set; }
		
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


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _formQuestionFormId
		/// </summary>	
		TList<FormQuestion> FormQuestionCollection {  get;  set;}	

		#endregion Data Properties

	}
}

