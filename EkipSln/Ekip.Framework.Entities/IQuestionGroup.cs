﻿using System;
using System.ComponentModel;

namespace Ekip.Framework.Entities
{
	/// <summary>
	///		The data structure representation of the 'QuestionGroup' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IQuestionGroup 
	{
		/// <summary>			
		/// GroupID : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "QuestionGroup"</remarks>
		System.Int32 GroupId { get; set; }
				
		
		
		/// <summary>
		/// TestID : 
		/// </summary>
		System.Int32  TestId  { get; set; }
		
		/// <summary>
		/// GroupName : 
		/// </summary>
		System.String  GroupName  { get; set; }
		
		/// <summary>
		/// LineNumber : 
		/// </summary>
		System.Int32  LineNumber  { get; set; }
		
		/// <summary>
		/// Status : 
		/// </summary>
		System.Boolean  Status  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _questionGroupId
		/// </summary>	
		TList<Question> QuestionCollection {  get;  set;}	

		#endregion Data Properties

	}
}


