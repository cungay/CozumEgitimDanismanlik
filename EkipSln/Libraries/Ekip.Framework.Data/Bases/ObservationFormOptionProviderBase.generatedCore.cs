﻿#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using Ekip.Framework.Entities;
using Ekip.Framework.Data;

#endregion

namespace Ekip.Framework.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="ObservationFormOptionProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ObservationFormOptionProviderBaseCore : EntityProviderBase<Ekip.Framework.Entities.ObservationFormOption, Ekip.Framework.Entities.ObservationFormOptionKey>
	{		
		#region Get from Many To Many Relationship Functions
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, Ekip.Framework.Entities.ObservationFormOptionKey key)
		{
			return Delete(transactionManager, key.OptionId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_optionId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _optionId)
		{
			return Delete(null, _optionId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_optionId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _optionId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ObservationForm_Option_ObservationForm key.
		///		FK_ObservationForm_Option_ObservationForm Description: 
		/// </summary>
		/// <param name="_questionId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ObservationFormOption objects.</returns>
		public TList<ObservationFormOption> GetByQuestionId(System.Int32 _questionId)
		{
			int count = -1;
			return GetByQuestionId(_questionId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ObservationForm_Option_ObservationForm key.
		///		FK_ObservationForm_Option_ObservationForm Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_questionId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ObservationFormOption objects.</returns>
		/// <remarks></remarks>
		public TList<ObservationFormOption> GetByQuestionId(TransactionManager transactionManager, System.Int32 _questionId)
		{
			int count = -1;
			return GetByQuestionId(transactionManager, _questionId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ObservationForm_Option_ObservationForm key.
		///		FK_ObservationForm_Option_ObservationForm Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_questionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ObservationFormOption objects.</returns>
		public TList<ObservationFormOption> GetByQuestionId(TransactionManager transactionManager, System.Int32 _questionId, int start, int pageLength)
		{
			int count = -1;
			return GetByQuestionId(transactionManager, _questionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ObservationForm_Option_ObservationForm key.
		///		fkObservationFormOptionObservationForm Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_questionId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ObservationFormOption objects.</returns>
		public TList<ObservationFormOption> GetByQuestionId(System.Int32 _questionId, int start, int pageLength)
		{
			int count =  -1;
			return GetByQuestionId(null, _questionId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ObservationForm_Option_ObservationForm key.
		///		fkObservationFormOptionObservationForm Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_questionId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ObservationFormOption objects.</returns>
		public TList<ObservationFormOption> GetByQuestionId(System.Int32 _questionId, int start, int pageLength,out int count)
		{
			return GetByQuestionId(null, _questionId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ObservationForm_Option_ObservationForm key.
		///		FK_ObservationForm_Option_ObservationForm Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_questionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ObservationFormOption objects.</returns>
		public abstract TList<ObservationFormOption> GetByQuestionId(TransactionManager transactionManager, System.Int32 _questionId, int start, int pageLength, out int count);
		
		#endregion

		#region Get By Index Functions
		
		/// <summary>
		/// 	Gets a row from the DataSource based on its primary key.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to retrieve.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <returns>Returns an instance of the Entity class.</returns>
		public override Ekip.Framework.Entities.ObservationFormOption Get(TransactionManager transactionManager, Ekip.Framework.Entities.ObservationFormOptionKey key, int start, int pageLength)
		{
			return GetByOptionId(transactionManager, key.OptionId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ObservationForm_Option index.
		/// </summary>
		/// <param name="_optionId"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ObservationFormOption"/> class.</returns>
		public Ekip.Framework.Entities.ObservationFormOption GetByOptionId(System.Int32 _optionId)
		{
			int count = -1;
			return GetByOptionId(null,_optionId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ObservationForm_Option index.
		/// </summary>
		/// <param name="_optionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ObservationFormOption"/> class.</returns>
		public Ekip.Framework.Entities.ObservationFormOption GetByOptionId(System.Int32 _optionId, int start, int pageLength)
		{
			int count = -1;
			return GetByOptionId(null, _optionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ObservationForm_Option index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_optionId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ObservationFormOption"/> class.</returns>
		public Ekip.Framework.Entities.ObservationFormOption GetByOptionId(TransactionManager transactionManager, System.Int32 _optionId)
		{
			int count = -1;
			return GetByOptionId(transactionManager, _optionId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ObservationForm_Option index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_optionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ObservationFormOption"/> class.</returns>
		public Ekip.Framework.Entities.ObservationFormOption GetByOptionId(TransactionManager transactionManager, System.Int32 _optionId, int start, int pageLength)
		{
			int count = -1;
			return GetByOptionId(transactionManager, _optionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ObservationForm_Option index.
		/// </summary>
		/// <param name="_optionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ObservationFormOption"/> class.</returns>
		public Ekip.Framework.Entities.ObservationFormOption GetByOptionId(System.Int32 _optionId, int start, int pageLength, out int count)
		{
			return GetByOptionId(null, _optionId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ObservationForm_Option index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_optionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ObservationFormOption"/> class.</returns>
		public abstract Ekip.Framework.Entities.ObservationFormOption GetByOptionId(TransactionManager transactionManager, System.Int32 _optionId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;ObservationFormOption&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;ObservationFormOption&gt;"/></returns>
		public static TList<ObservationFormOption> Fill(IDataReader reader, TList<ObservationFormOption> rows, int start, int pageLength)
		{
			NetTiersProvider currentProvider = DataRepository.Provider;
            bool useEntityFactory = currentProvider.UseEntityFactory;
            bool enableEntityTracking = currentProvider.EnableEntityTracking;
            LoadPolicy currentLoadPolicy = currentProvider.CurrentLoadPolicy;
			Type entityCreationFactoryType = currentProvider.EntityCreationalFactoryType;
			
			// advance to the starting row
			for (int i = 0; i < start; i++)
			{
				if (!reader.Read())
				return rows; // not enough rows, just return
			}
			for (int i = 0; i < pageLength; i++)
			{
				if (!reader.Read())
					break; // we are done
					
				string key = null;
				
				Ekip.Framework.Entities.ObservationFormOption c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ObservationFormOption")
					.Append("|").Append((System.Int32)reader[((int)ObservationFormOptionColumn.OptionId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<ObservationFormOption>(
					key.ToString(), // EntityTrackingKey
					"ObservationFormOption",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Ekip.Framework.Entities.ObservationFormOption();
				}
				
				if (!enableEntityTracking ||
					c.EntityState == EntityState.Added ||
					(enableEntityTracking &&
					
						(
							(currentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
							(currentLoadPolicy == LoadPolicy.DiscardChanges && c.EntityState != EntityState.Unchanged)
						)
					))
				{
					c.SuppressEntityEvents = true;
					c.OptionId = (System.Int32)reader[((int)ObservationFormOptionColumn.OptionId - 1)];
					c.QuestionId = (System.Int32)reader[((int)ObservationFormOptionColumn.QuestionId - 1)];
					c.OptionName = (System.String)reader[((int)ObservationFormOptionColumn.OptionName - 1)];
					c.CreateDate = (System.DateTime)reader[((int)ObservationFormOptionColumn.CreateDate - 1)];
					c.UpdateDate = (reader.IsDBNull(((int)ObservationFormOptionColumn.UpdateDate - 1)))?null:(System.DateTime?)reader[((int)ObservationFormOptionColumn.UpdateDate - 1)];
					c.CreateUserId = (System.Int32)reader[((int)ObservationFormOptionColumn.CreateUserId - 1)];
					c.UpdateUserId = (reader.IsDBNull(((int)ObservationFormOptionColumn.UpdateUserId - 1)))?null:(System.Int32?)reader[((int)ObservationFormOptionColumn.UpdateUserId - 1)];
					c.Active = (System.Boolean)reader[((int)ObservationFormOptionColumn.Active - 1)];
					c.Deleted = (System.Boolean)reader[((int)ObservationFormOptionColumn.Deleted - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.ObservationFormOption"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.ObservationFormOption"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Ekip.Framework.Entities.ObservationFormOption entity)
		{
			if (!reader.Read()) return;
			
			entity.OptionId = (System.Int32)reader[((int)ObservationFormOptionColumn.OptionId - 1)];
			entity.QuestionId = (System.Int32)reader[((int)ObservationFormOptionColumn.QuestionId - 1)];
			entity.OptionName = (System.String)reader[((int)ObservationFormOptionColumn.OptionName - 1)];
			entity.CreateDate = (System.DateTime)reader[((int)ObservationFormOptionColumn.CreateDate - 1)];
			entity.UpdateDate = (reader.IsDBNull(((int)ObservationFormOptionColumn.UpdateDate - 1)))?null:(System.DateTime?)reader[((int)ObservationFormOptionColumn.UpdateDate - 1)];
			entity.CreateUserId = (System.Int32)reader[((int)ObservationFormOptionColumn.CreateUserId - 1)];
			entity.UpdateUserId = (reader.IsDBNull(((int)ObservationFormOptionColumn.UpdateUserId - 1)))?null:(System.Int32?)reader[((int)ObservationFormOptionColumn.UpdateUserId - 1)];
			entity.Active = (System.Boolean)reader[((int)ObservationFormOptionColumn.Active - 1)];
			entity.Deleted = (System.Boolean)reader[((int)ObservationFormOptionColumn.Deleted - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.ObservationFormOption"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.ObservationFormOption"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Ekip.Framework.Entities.ObservationFormOption entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.OptionId = (System.Int32)dataRow["OptionId"];
			entity.QuestionId = (System.Int32)dataRow["QuestionId"];
			entity.OptionName = (System.String)dataRow["OptionName"];
			entity.CreateDate = (System.DateTime)dataRow["CreateDate"];
			entity.UpdateDate = Convert.IsDBNull(dataRow["UpdateDate"]) ? null : (System.DateTime?)dataRow["UpdateDate"];
			entity.CreateUserId = (System.Int32)dataRow["CreateUserId"];
			entity.UpdateUserId = Convert.IsDBNull(dataRow["UpdateUserId"]) ? null : (System.Int32?)dataRow["UpdateUserId"];
			entity.Active = (System.Boolean)dataRow["Active"];
			entity.Deleted = (System.Boolean)dataRow["Deleted"];
			entity.AcceptChanges();
		}
		#endregion 
		
		#region DeepLoad Methods
		/// <summary>
		/// Deep Loads the <see cref="IEntity"/> object with criteria based of the child 
		/// property collections only N Levels Deep based on the <see cref="DeepLoadType"/>.
		/// </summary>
		/// <remarks>
		/// Use this method with caution as it is possible to DeepLoad with Recursion and traverse an entire object graph.
		/// </remarks>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.ObservationFormOption"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.ObservationFormOption Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Ekip.Framework.Entities.ObservationFormOption entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region QuestionIdSource	
			if (CanDeepLoad(entity, "ObservationForm|QuestionIdSource", deepLoadType, innerList) 
				&& entity.QuestionIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.QuestionId;
				ObservationForm tmpEntity = EntityManager.LocateEntity<ObservationForm>(EntityLocator.ConstructKeyFromPkItems(typeof(ObservationForm), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.QuestionIdSource = tmpEntity;
				else
					entity.QuestionIdSource = DataRepository.ObservationFormProvider.GetByQuestionId(transactionManager, entity.QuestionId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'QuestionIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.QuestionIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ObservationFormProvider.DeepLoad(transactionManager, entity.QuestionIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion QuestionIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByOptionId methods when available
			
			#region ObservationFormAnswerCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ObservationFormAnswer>|ObservationFormAnswerCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ObservationFormAnswerCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ObservationFormAnswerCollection = DataRepository.ObservationFormAnswerProvider.GetByOptionId(transactionManager, entity.OptionId);

				if (deep && entity.ObservationFormAnswerCollection.Count > 0)
				{
					deepHandles.Add("ObservationFormAnswerCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<ObservationFormAnswer>) DataRepository.ObservationFormAnswerProvider.DeepLoad,
						new object[] { transactionManager, entity.ObservationFormAnswerCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			//Fire all DeepLoad Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles.Values)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			deepHandles = null;
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the Ekip.Framework.Entities.ObservationFormOption object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Ekip.Framework.Entities.ObservationFormOption instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.ObservationFormOption Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Ekip.Framework.Entities.ObservationFormOption entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region QuestionIdSource
			if (CanDeepSave(entity, "ObservationForm|QuestionIdSource", deepSaveType, innerList) 
				&& entity.QuestionIdSource != null)
			{
				DataRepository.ObservationFormProvider.Save(transactionManager, entity.QuestionIdSource);
				entity.QuestionId = entity.QuestionIdSource.QuestionId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<ObservationFormAnswer>
				if (CanDeepSave(entity.ObservationFormAnswerCollection, "List<ObservationFormAnswer>|ObservationFormAnswerCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ObservationFormAnswer child in entity.ObservationFormAnswerCollection)
					{
						if(child.OptionIdSource != null)
						{
							child.OptionId = child.OptionIdSource.OptionId;
						}
						else
						{
							child.OptionId = entity.OptionId;
						}

					}

					if (entity.ObservationFormAnswerCollection.Count > 0 || entity.ObservationFormAnswerCollection.DeletedItems.Count > 0)
					{
						//DataRepository.ObservationFormAnswerProvider.Save(transactionManager, entity.ObservationFormAnswerCollection);
						
						deepHandles.Add("ObservationFormAnswerCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< ObservationFormAnswer >) DataRepository.ObservationFormAnswerProvider.DeepSave,
							new object[] { transactionManager, entity.ObservationFormAnswerCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
			//Fire all DeepSave Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles.Values)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			
			// Save Root Entity through Provider, if not already saved in delete mode
			if (entity.IsDeleted)
				this.Save(transactionManager, entity);
				

			deepHandles = null;
						
			return true;
		}
		#endregion
	} // end class
	
	#region ObservationFormOptionChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Ekip.Framework.Entities.ObservationFormOption</c>
	///</summary>
	public enum ObservationFormOptionChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>ObservationForm</c> at QuestionIdSource
		///</summary>
		[ChildEntityType(typeof(ObservationForm))]
		ObservationForm,
	
		///<summary>
		/// Collection of <c>ObservationFormOption</c> as OneToMany for ObservationFormAnswerCollection
		///</summary>
		[ChildEntityType(typeof(TList<ObservationFormAnswer>))]
		ObservationFormAnswerCollection,
	}
	
	#endregion ObservationFormOptionChildEntityTypes
	
	#region ObservationFormOptionFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ObservationFormOptionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ObservationFormOption"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ObservationFormOptionFilterBuilder : SqlFilterBuilder<ObservationFormOptionColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ObservationFormOptionFilterBuilder class.
		/// </summary>
		public ObservationFormOptionFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ObservationFormOptionFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ObservationFormOptionFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ObservationFormOptionFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ObservationFormOptionFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ObservationFormOptionFilterBuilder
	
	#region ObservationFormOptionParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ObservationFormOptionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ObservationFormOption"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ObservationFormOptionParameterBuilder : ParameterizedSqlFilterBuilder<ObservationFormOptionColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ObservationFormOptionParameterBuilder class.
		/// </summary>
		public ObservationFormOptionParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ObservationFormOptionParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ObservationFormOptionParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ObservationFormOptionParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ObservationFormOptionParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ObservationFormOptionParameterBuilder
	
	#region ObservationFormOptionSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ObservationFormOptionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ObservationFormOption"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ObservationFormOptionSortBuilder : SqlSortBuilder<ObservationFormOptionColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ObservationFormOptionSqlSortBuilder class.
		/// </summary>
		public ObservationFormOptionSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ObservationFormOptionSortBuilder
	
} // end namespace
