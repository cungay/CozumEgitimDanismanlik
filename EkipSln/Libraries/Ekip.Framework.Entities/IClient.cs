﻿using System;
using System.ComponentModel;

namespace Ekip.Framework.Entities
{
	/// <summary>
	///		The data structure representation of the 'Client' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IClient 
	{
		/// <summary>			
		/// ClientId : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "Client"</remarks>
		System.Int32 ClientId { get; set; }
				
		
		
		/// <summary>
		/// FileNumber : 
		/// </summary>
		System.Int32  FileNumber  { get; set; }
		
		/// <summary>
		/// FirstContactDate : 
		/// </summary>
		System.DateTime  FirstContactDate  { get; set; }
		
		/// <summary>
		/// FirstContactAge : 
		/// </summary>
		System.Int32  FirstContactAge  { get; set; }
		
		/// <summary>
		/// CurrentAge : 
		/// </summary>
		System.Int32  CurrentAge  { get; set; }
		
		/// <summary>
		/// BirthDate : 
		/// </summary>
		System.DateTime  BirthDate  { get; set; }
		
		/// <summary>
		/// CalendarAgeId : 
		/// </summary>
		System.Int32  CalendarAgeId  { get; set; }
		
		/// <summary>
		/// FullName : 
		/// </summary>
		System.String  FullName  { get; set; }
		
		/// <summary>
		/// MiddleName : 
		/// </summary>
		System.String  MiddleName  { get; set; }
		
		/// <summary>
		/// Reference : 
		/// </summary>
		System.String  Reference  { get; set; }
		
		/// <summary>
		/// MotherId : 
		/// </summary>
		System.Int32  MotherId  { get; set; }
		
		/// <summary>
		/// FatherId : 
		/// </summary>
		System.Int32  FatherId  { get; set; }
		
		/// <summary>
		/// AddressId : 
		/// </summary>
		System.Int32?  AddressId  { get; set; }
		
		/// <summary>
		/// IdCard : 
		/// </summary>
		System.String  IdCard  { get; set; }
		
		/// <summary>
		/// Gender : 
		/// </summary>
		System.Byte?  Gender  { get; set; }
		
		/// <summary>
		/// Blood : 
		/// </summary>
		System.Byte?  Blood  { get; set; }
		
		/// <summary>
		/// Pediatrician : 
		/// </summary>
		System.String  Pediatrician  { get; set; }
		
		/// <summary>
		/// CountOfChild : 
		/// </summary>
		System.Int32  CountOfChild  { get; set; }
		
		/// <summary>
		/// FamilyStatus : 
		/// </summary>
		System.Byte?  FamilyStatus  { get; set; }
		
		/// <summary>
		/// Notes : 
		/// </summary>
		System.String  Notes  { get; set; }
		
		/// <summary>
		/// CreateDate : 
		/// </summary>
		System.DateTime  CreateDate  { get; set; }
		
		/// <summary>
		/// UpdateDate : 
		/// </summary>
		System.DateTime?  UpdateDate  { get; set; }
		
		/// <summary>
		/// CreateUserId : 
		/// </summary>
		System.Int32  CreateUserId  { get; set; }
		
		/// <summary>
		/// UpdateUserId : 
		/// </summary>
		System.Int32?  UpdateUserId  { get; set; }
		
		/// <summary>
		/// Active : 
		/// </summary>
		System.Boolean  Active  { get; set; }
		
		/// <summary>
		/// Deleted : 
		/// </summary>
		System.Boolean  Deleted  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _observationFormAnswerClientId
		/// </summary>	
		TList<ObservationFormAnswer> ObservationFormAnswerCollection {  get;  set;}	


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _siblingClientId
		/// </summary>	
		TList<Sibling> SiblingCollection {  get;  set;}	


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _seanceClientId
		/// </summary>	
		TList<Seance> SeanceCollection {  get;  set;}	


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _questionFormAnswerClientId
		/// </summary>	
		TList<QuestionFormAnswer> QuestionFormAnswerCollection {  get;  set;}	


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _seanceQuestionAnswerClientId
		/// </summary>	
		TList<SeanceQuestionAnswer> SeanceQuestionAnswerCollection {  get;  set;}	


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _clientEducationClientId
		/// </summary>	
		TList<ClientEducation> ClientEducationCollection {  get;  set;}	

		#endregion Data Properties

	}
}


