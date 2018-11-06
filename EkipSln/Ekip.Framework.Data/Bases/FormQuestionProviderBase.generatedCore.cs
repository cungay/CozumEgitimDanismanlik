#region Using directives

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
	/// This class is the base class for any <see cref="FormQuestionProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class FormQuestionProviderBaseCore : EntityProviderBase<Ekip.Framework.Entities.FormQuestion, Ekip.Framework.Entities.FormQuestionKey>
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
		public override bool Delete(TransactionManager transactionManager, Ekip.Framework.Entities.FormQuestionKey key)
		{
			return Delete(transactionManager, key.QuestionId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_questionId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _questionId)
		{
			return Delete(null, _questionId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_questionId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _questionId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_FormQuestion_ClientForm key.
		///		FK_FormQuestion_ClientForm Description: 
		/// </summary>
		/// <param name="_formId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.FormQuestion objects.</returns>
		public TList<FormQuestion> GetByFormId(System.Int32 _formId)
		{
			int count = -1;
			return GetByFormId(_formId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_FormQuestion_ClientForm key.
		///		FK_FormQuestion_ClientForm Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_formId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.FormQuestion objects.</returns>
		/// <remarks></remarks>
		public TList<FormQuestion> GetByFormId(TransactionManager transactionManager, System.Int32 _formId)
		{
			int count = -1;
			return GetByFormId(transactionManager, _formId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_FormQuestion_ClientForm key.
		///		FK_FormQuestion_ClientForm Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_formId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.FormQuestion objects.</returns>
		public TList<FormQuestion> GetByFormId(TransactionManager transactionManager, System.Int32 _formId, int start, int pageLength)
		{
			int count = -1;
			return GetByFormId(transactionManager, _formId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_FormQuestion_ClientForm key.
		///		fkFormQuestionClientForm Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_formId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.FormQuestion objects.</returns>
		public TList<FormQuestion> GetByFormId(System.Int32 _formId, int start, int pageLength)
		{
			int count =  -1;
			return GetByFormId(null, _formId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_FormQuestion_ClientForm key.
		///		fkFormQuestionClientForm Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_formId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.FormQuestion objects.</returns>
		public TList<FormQuestion> GetByFormId(System.Int32 _formId, int start, int pageLength,out int count)
		{
			return GetByFormId(null, _formId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_FormQuestion_ClientForm key.
		///		FK_FormQuestion_ClientForm Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_formId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.FormQuestion objects.</returns>
		public abstract TList<FormQuestion> GetByFormId(TransactionManager transactionManager, System.Int32 _formId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_FormQuestion_QuestionGroup key.
		///		FK_FormQuestion_QuestionGroup Description: 
		/// </summary>
		/// <param name="_groupId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.FormQuestion objects.</returns>
		public TList<FormQuestion> GetByGroupId(System.Int32? _groupId)
		{
			int count = -1;
			return GetByGroupId(_groupId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_FormQuestion_QuestionGroup key.
		///		FK_FormQuestion_QuestionGroup Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_groupId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.FormQuestion objects.</returns>
		/// <remarks></remarks>
		public TList<FormQuestion> GetByGroupId(TransactionManager transactionManager, System.Int32? _groupId)
		{
			int count = -1;
			return GetByGroupId(transactionManager, _groupId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_FormQuestion_QuestionGroup key.
		///		FK_FormQuestion_QuestionGroup Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_groupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.FormQuestion objects.</returns>
		public TList<FormQuestion> GetByGroupId(TransactionManager transactionManager, System.Int32? _groupId, int start, int pageLength)
		{
			int count = -1;
			return GetByGroupId(transactionManager, _groupId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_FormQuestion_QuestionGroup key.
		///		fkFormQuestionQuestionGroup Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_groupId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.FormQuestion objects.</returns>
		public TList<FormQuestion> GetByGroupId(System.Int32? _groupId, int start, int pageLength)
		{
			int count =  -1;
			return GetByGroupId(null, _groupId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_FormQuestion_QuestionGroup key.
		///		fkFormQuestionQuestionGroup Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_groupId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.FormQuestion objects.</returns>
		public TList<FormQuestion> GetByGroupId(System.Int32? _groupId, int start, int pageLength,out int count)
		{
			return GetByGroupId(null, _groupId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_FormQuestion_QuestionGroup key.
		///		FK_FormQuestion_QuestionGroup Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_groupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.FormQuestion objects.</returns>
		public abstract TList<FormQuestion> GetByGroupId(TransactionManager transactionManager, System.Int32? _groupId, int start, int pageLength, out int count);
		
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
		public override Ekip.Framework.Entities.FormQuestion Get(TransactionManager transactionManager, Ekip.Framework.Entities.FormQuestionKey key, int start, int pageLength)
		{
			return GetByQuestionId(transactionManager, key.QuestionId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_FormQuestion index.
		/// </summary>
		/// <param name="_questionId"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.FormQuestion"/> class.</returns>
		public Ekip.Framework.Entities.FormQuestion GetByQuestionId(System.Int32 _questionId)
		{
			int count = -1;
			return GetByQuestionId(null,_questionId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_FormQuestion index.
		/// </summary>
		/// <param name="_questionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.FormQuestion"/> class.</returns>
		public Ekip.Framework.Entities.FormQuestion GetByQuestionId(System.Int32 _questionId, int start, int pageLength)
		{
			int count = -1;
			return GetByQuestionId(null, _questionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_FormQuestion index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_questionId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.FormQuestion"/> class.</returns>
		public Ekip.Framework.Entities.FormQuestion GetByQuestionId(TransactionManager transactionManager, System.Int32 _questionId)
		{
			int count = -1;
			return GetByQuestionId(transactionManager, _questionId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_FormQuestion index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_questionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.FormQuestion"/> class.</returns>
		public Ekip.Framework.Entities.FormQuestion GetByQuestionId(TransactionManager transactionManager, System.Int32 _questionId, int start, int pageLength)
		{
			int count = -1;
			return GetByQuestionId(transactionManager, _questionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_FormQuestion index.
		/// </summary>
		/// <param name="_questionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.FormQuestion"/> class.</returns>
		public Ekip.Framework.Entities.FormQuestion GetByQuestionId(System.Int32 _questionId, int start, int pageLength, out int count)
		{
			return GetByQuestionId(null, _questionId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_FormQuestion index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_questionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.FormQuestion"/> class.</returns>
		public abstract Ekip.Framework.Entities.FormQuestion GetByQuestionId(TransactionManager transactionManager, System.Int32 _questionId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;FormQuestion&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;FormQuestion&gt;"/></returns>
		public static TList<FormQuestion> Fill(IDataReader reader, TList<FormQuestion> rows, int start, int pageLength)
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
				
				Ekip.Framework.Entities.FormQuestion c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("FormQuestion")
					.Append("|").Append((System.Int32)reader[((int)FormQuestionColumn.QuestionId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<FormQuestion>(
					key.ToString(), // EntityTrackingKey
					"FormQuestion",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Ekip.Framework.Entities.FormQuestion();
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
					c.QuestionId = (System.Int32)reader[((int)FormQuestionColumn.QuestionId - 1)];
					c.FormId = (System.Int32)reader[((int)FormQuestionColumn.FormId - 1)];
					c.GroupId = (reader.IsDBNull(((int)FormQuestionColumn.GroupId - 1)))?null:(System.Int32?)reader[((int)FormQuestionColumn.GroupId - 1)];
					c.RowNumber = (System.Int32)reader[((int)FormQuestionColumn.RowNumber - 1)];
					c.Question = (System.String)reader[((int)FormQuestionColumn.Question - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.FormQuestion"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.FormQuestion"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Ekip.Framework.Entities.FormQuestion entity)
		{
			if (!reader.Read()) return;
			
			entity.QuestionId = (System.Int32)reader[((int)FormQuestionColumn.QuestionId - 1)];
			entity.FormId = (System.Int32)reader[((int)FormQuestionColumn.FormId - 1)];
			entity.GroupId = (reader.IsDBNull(((int)FormQuestionColumn.GroupId - 1)))?null:(System.Int32?)reader[((int)FormQuestionColumn.GroupId - 1)];
			entity.RowNumber = (System.Int32)reader[((int)FormQuestionColumn.RowNumber - 1)];
			entity.Question = (System.String)reader[((int)FormQuestionColumn.Question - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.FormQuestion"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.FormQuestion"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Ekip.Framework.Entities.FormQuestion entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.QuestionId = (System.Int32)dataRow["QuestionID"];
			entity.FormId = (System.Int32)dataRow["FormID"];
			entity.GroupId = Convert.IsDBNull(dataRow["GroupID"]) ? null : (System.Int32?)dataRow["GroupID"];
			entity.RowNumber = (System.Int32)dataRow["RowNumber"];
			entity.Question = (System.String)dataRow["Question"];
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
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.FormQuestion"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.FormQuestion Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Ekip.Framework.Entities.FormQuestion entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region FormIdSource	
			if (CanDeepLoad(entity, "ClientForm|FormIdSource", deepLoadType, innerList) 
				&& entity.FormIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.FormId;
				ClientForm tmpEntity = EntityManager.LocateEntity<ClientForm>(EntityLocator.ConstructKeyFromPkItems(typeof(ClientForm), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.FormIdSource = tmpEntity;
				else
					entity.FormIdSource = DataRepository.ClientFormProvider.GetByFormId(transactionManager, entity.FormId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'FormIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.FormIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ClientFormProvider.DeepLoad(transactionManager, entity.FormIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion FormIdSource

			#region GroupIdSource	
			if (CanDeepLoad(entity, "QuestionGroup|GroupIdSource", deepLoadType, innerList) 
				&& entity.GroupIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.GroupId ?? (int)0);
				QuestionGroup tmpEntity = EntityManager.LocateEntity<QuestionGroup>(EntityLocator.ConstructKeyFromPkItems(typeof(QuestionGroup), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.GroupIdSource = tmpEntity;
				else
					entity.GroupIdSource = DataRepository.QuestionGroupProvider.GetByGroupId(transactionManager, (entity.GroupId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'GroupIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.GroupIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.QuestionGroupProvider.DeepLoad(transactionManager, entity.GroupIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion GroupIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			
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
		/// Deep Save the entire object graph of the Ekip.Framework.Entities.FormQuestion object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Ekip.Framework.Entities.FormQuestion instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.FormQuestion Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Ekip.Framework.Entities.FormQuestion entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region FormIdSource
			if (CanDeepSave(entity, "ClientForm|FormIdSource", deepSaveType, innerList) 
				&& entity.FormIdSource != null)
			{
				DataRepository.ClientFormProvider.Save(transactionManager, entity.FormIdSource);
				entity.FormId = entity.FormIdSource.FormId;
			}
			#endregion 
			
			#region GroupIdSource
			if (CanDeepSave(entity, "QuestionGroup|GroupIdSource", deepSaveType, innerList) 
				&& entity.GroupIdSource != null)
			{
				DataRepository.QuestionGroupProvider.Save(transactionManager, entity.GroupIdSource);
				entity.GroupId = entity.GroupIdSource.GroupId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
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
	
	#region FormQuestionChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Ekip.Framework.Entities.FormQuestion</c>
	///</summary>
	public enum FormQuestionChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>ClientForm</c> at FormIdSource
		///</summary>
		[ChildEntityType(typeof(ClientForm))]
		ClientForm,
			
		///<summary>
		/// Composite Property for <c>QuestionGroup</c> at GroupIdSource
		///</summary>
		[ChildEntityType(typeof(QuestionGroup))]
		QuestionGroup,
		}
	
	#endregion FormQuestionChildEntityTypes
	
	#region FormQuestionFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;FormQuestionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="FormQuestion"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FormQuestionFilterBuilder : SqlFilterBuilder<FormQuestionColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FormQuestionFilterBuilder class.
		/// </summary>
		public FormQuestionFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the FormQuestionFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public FormQuestionFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the FormQuestionFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public FormQuestionFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion FormQuestionFilterBuilder
	
	#region FormQuestionParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;FormQuestionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="FormQuestion"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FormQuestionParameterBuilder : ParameterizedSqlFilterBuilder<FormQuestionColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FormQuestionParameterBuilder class.
		/// </summary>
		public FormQuestionParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the FormQuestionParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public FormQuestionParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the FormQuestionParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public FormQuestionParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion FormQuestionParameterBuilder
	
	#region FormQuestionSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;FormQuestionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="FormQuestion"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class FormQuestionSortBuilder : SqlSortBuilder<FormQuestionColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FormQuestionSqlSortBuilder class.
		/// </summary>
		public FormQuestionSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion FormQuestionSortBuilder
	
} // end namespace
