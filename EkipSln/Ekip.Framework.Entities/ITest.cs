﻿using System;
using System.ComponentModel;

namespace Ekip.Framework.Entities
{
	/// <summary>
	///		The data structure representation of the 'Test' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface ITest 
	{
		/// <summary>			
		/// TestID : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "Test"</remarks>
		System.Int32 TestId { get; set; }
				
		
		
		/// <summary>
		/// TestRef : 
		/// </summary>
		System.String  TestRef  { get; set; }
		
		/// <summary>
		/// TestName : 
		/// </summary>
		System.String  TestName  { get; set; }
		
		/// <summary>
		/// Description : 
		/// </summary>
		System.String  Description  { get; set; }
		
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
		///	which are related to this object through the relation _testResultTestId
		/// </summary>	
		TList<TestResult> TestResultCollection {  get;  set;}	


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _questionTestId
		/// </summary>	
		TList<Question> QuestionCollection {  get;  set;}	


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _clientTestTestId
		/// </summary>	
		TList<ClientTest> ClientTestCollection {  get;  set;}	


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _questionGroupTestId
		/// </summary>	
		TList<QuestionGroup> QuestionGroupCollection {  get;  set;}	

		#endregion Data Properties

	}
}


