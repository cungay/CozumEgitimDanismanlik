
#region Using directives

using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Configuration.Provider;

using Ekip.Framework.Entities;

#endregion

namespace Ekip.Framework.Data.Bases
{	
	///<summary>
	/// The base class to implements to create a .NetTiers provider.
	///</summary>
	public abstract class NetTiersProvider : NetTiersProviderBase
	{
		
		///<summary>
		/// Current AdvisorProviderBase instance.
		///</summary>
		public virtual AdvisorProviderBase AdvisorProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SeanceQuestionProviderBase instance.
		///</summary>
		public virtual SeanceQuestionProviderBase SeanceQuestionProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SeanceProviderBase instance.
		///</summary>
		public virtual SeanceProviderBase SeanceProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SchoolProviderBase instance.
		///</summary>
		public virtual SchoolProviderBase SchoolProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ReasonProviderBase instance.
		///</summary>
		public virtual ReasonProviderBase ReasonProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current QuestionFormGroupProviderBase instance.
		///</summary>
		public virtual QuestionFormGroupProviderBase QuestionFormGroupProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SeanceQuestionOptionProviderBase instance.
		///</summary>
		public virtual SeanceQuestionOptionProviderBase SeanceQuestionOptionProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current TownProviderBase instance.
		///</summary>
		public virtual TownProviderBase TownProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SeanceReasonProviderBase instance.
		///</summary>
		public virtual SeanceReasonProviderBase SeanceReasonProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current TeacherProviderBase instance.
		///</summary>
		public virtual TeacherProviderBase TeacherProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current WippsiProviderBase instance.
		///</summary>
		public virtual WippsiProviderBase WippsiProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SeanceQuestionAnswerProviderBase instance.
		///</summary>
		public virtual SeanceQuestionAnswerProviderBase SeanceQuestionAnswerProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current StreetProviderBase instance.
		///</summary>
		public virtual StreetProviderBase StreetProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current QuestionFormProviderBase instance.
		///</summary>
		public virtual QuestionFormProviderBase QuestionFormProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SiblingProviderBase instance.
		///</summary>
		public virtual SiblingProviderBase SiblingProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ClientFatherProviderBase instance.
		///</summary>
		public virtual ClientFatherProviderBase ClientFatherProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ClientMotherProviderBase instance.
		///</summary>
		public virtual ClientMotherProviderBase ClientMotherProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ClientAddressProviderBase instance.
		///</summary>
		public virtual ClientAddressProviderBase ClientAddressProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ProvinceProviderBase instance.
		///</summary>
		public virtual ProvinceProviderBase ProvinceProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CalendarAgeProviderBase instance.
		///</summary>
		public virtual CalendarAgeProviderBase CalendarAgeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ClientProviderBase instance.
		///</summary>
		public virtual ClientProviderBase ClientProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ClientEducationProviderBase instance.
		///</summary>
		public virtual ClientEducationProviderBase ClientEducationProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AreaProviderBase instance.
		///</summary>
		public virtual AreaProviderBase AreaProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current JobProviderBase instance.
		///</summary>
		public virtual JobProviderBase JobProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current NeighborhoodProviderBase instance.
		///</summary>
		public virtual NeighborhoodProviderBase NeighborhoodProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current QuestionFormOptionProviderBase instance.
		///</summary>
		public virtual QuestionFormOptionProviderBase QuestionFormOptionProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current QuestionFormAnswerProviderBase instance.
		///</summary>
		public virtual QuestionFormAnswerProviderBase QuestionFormAnswerProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ObservationFormGroupProviderBase instance.
		///</summary>
		public virtual ObservationFormGroupProviderBase ObservationFormGroupProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ObservationFormProviderBase instance.
		///</summary>
		public virtual ObservationFormProviderBase ObservationFormProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ObservationFormOptionProviderBase instance.
		///</summary>
		public virtual ObservationFormOptionProviderBase ObservationFormOptionProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ObservationFormAnswerProviderBase instance.
		///</summary>
		public virtual ObservationFormAnswerProviderBase ObservationFormAnswerProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current WiscrProviderBase instance.
		///</summary>
		public virtual WiscrProviderBase WiscrProvider{get {throw new NotImplementedException();}}
		
		
		///<summary>
		/// Current ProvinceViewProviderBase instance.
		///</summary>
		public virtual ProvinceViewProviderBase ProvinceViewProvider{get {throw new NotImplementedException();}}
		
	}
}
