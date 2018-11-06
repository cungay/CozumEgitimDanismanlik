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
	/// This class is the base class for any <see cref="ObservationFormProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ObservationFormProviderBaseCore : EntityProviderBase<Ekip.Framework.Entities.ObservationForm, Ekip.Framework.Entities.ObservationFormKey>
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
		public override bool Delete(TransactionManager transactionManager, Ekip.Framework.Entities.ObservationFormKey key)
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
		/// 	Gets rows from the datasource based on the FK_ObservationForm_ObservationForm_Group key.
		///		FK_ObservationForm_ObservationForm_Group Description: 
		/// </summary>
		/// <param name="_groupId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ObservationForm objects.</returns>
		public TList<ObservationForm> GetByGroupId(System.Int32? _groupId)
		{
			int count = -1;
			return GetByGroupId(_groupId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ObservationForm_ObservationForm_Group key.
		///		FK_ObservationForm_ObservationForm_Group Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_groupId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ObservationForm objects.</returns>
		/// <remarks></remarks>
		public TList<ObservationForm> GetByGroupId(TransactionManager transactionManager, System.Int32? _groupId)
		{
			int count = -1;
			return GetByGroupId(transactionManager, _groupId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ObservationForm_ObservationForm_Group key.
		///		FK_ObservationForm_ObservationForm_Group Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_groupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ObservationForm objects.</returns>
		public TList<ObservationForm> GetByGroupId(TransactionManager transactionManager, System.Int32? _groupId, int start, int pageLength)
		{
			int count = -1;
			return GetByGroupId(transactionManager, _groupId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ObservationForm_ObservationForm_Group key.
		///		fkObservationFormObservationFormGroup Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_groupId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ObservationForm objects.</returns>
		public TList<ObservationForm> GetByGroupId(System.Int32? _groupId, int start, int pageLength)
		{
			int count =  -1;
			return GetByGroupId(null, _groupId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ObservationForm_ObservationForm_Group key.
		///		fkObservationFormObservationFormGroup Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_groupId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ObservationForm objects.</returns>
		public TList<ObservationForm> GetByGroupId(System.Int32? _groupId, int start, int pageLength,out int count)
		{
			return GetByGroupId(null, _groupId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ObservationForm_ObservationForm_Group key.
		///		FK_ObservationForm_ObservationForm_Group Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_groupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ObservationForm objects.</returns>
		public abstract TList<ObservationForm> GetByGroupId(TransactionManager transactionManager, System.Int32? _groupId, int start, int pageLength, out int count);
		
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
		public override Ekip.Framework.Entities.ObservationForm Get(TransactionManager transactionManager, Ekip.Framework.Entities.ObservationFormKey key, int start, int pageLength)
		{
			return GetByQuestionId(transactionManager, key.QuestionId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ObservationForm index.
		/// </summary>
		/// <param name="_questionId"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ObservationForm"/> class.</returns>
		public Ekip.Framework.Entities.ObservationForm GetByQuestionId(System.Int32 _questionId)
		{
			int count = -1;
			return GetByQuestionId(null,_questionId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ObservationForm index.
		/// </summary>
		/// <param name="_questionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ObservationForm"/> class.</returns>
		public Ekip.Framework.Entities.ObservationForm GetByQuestionId(System.Int32 _questionId, int start, int pageLength)
		{
			int count = -1;
			return GetByQuestionId(null, _questionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ObservationForm index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_questionId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ObservationForm"/> class.</returns>
		public Ekip.Framework.Entities.ObservationForm GetByQuestionId(TransactionManager transactionManager, System.Int32 _questionId)
		{
			int count = -1;
			return GetByQuestionId(transactionManager, _questionId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ObservationForm index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_questionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ObservationForm"/> class.</returns>
		public Ekip.Framework.Entities.ObservationForm GetByQuestionId(TransactionManager transactionManager, System.Int32 _questionId, int start, int pageLength)
		{
			int count = -1;
			return GetByQuestionId(transactionManager, _questionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ObservationForm index.
		/// </summary>
		/// <param name="_questionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ObservationForm"/> class.</returns>
		public Ekip.Framework.Entities.ObservationForm GetByQuestionId(System.Int32 _questionId, int start, int pageLength, out int count)
		{
			return GetByQuestionId(null, _questionId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ObservationForm index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_questionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ObservationForm"/> class.</returns>
		public abstract Ekip.Framework.Entities.ObservationForm GetByQuestionId(TransactionManager transactionManager, System.Int32 _questionId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;ObservationForm&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;ObservationForm&gt;"/></returns>
		public static TList<ObservationForm> Fill(IDataReader reader, TList<ObservationForm> rows, int start, int pageLength)
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
				
				Ekip.Framework.Entities.ObservationForm c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ObservationForm")
					.Append("|").Append((System.Int32)reader[((int)ObservationFormColumn.QuestionId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<ObservationForm>(
					key.ToString(), // EntityTrackingKey
					"ObservationForm",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Ekip.Framework.Entities.ObservationForm();
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
					c.QuestionId = (System.Int32)reader[((int)ObservationFormColumn.QuestionId - 1)];
					c.GroupId = (reader.IsDBNull(((int)ObservationFormColumn.GroupId - 1)))?null:(System.Int32?)reader[((int)ObservationFormColumn.GroupId - 1)];
					c.QuestionRef = (reader.IsDBNull(((int)ObservationFormColumn.QuestionRef - 1)))?null:(System.String)reader[((int)ObservationFormColumn.QuestionRef - 1)];
					c.QuestionName = (System.String)reader[((int)ObservationFormColumn.QuestionName - 1)];
					c.LineNumber = (System.Int32)reader[((int)ObservationFormColumn.LineNumber - 1)];
					c.Status = (System.Boolean)reader[((int)ObservationFormColumn.Status - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.ObservationForm"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.ObservationForm"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Ekip.Framework.Entities.ObservationForm entity)
		{
			if (!reader.Read()) return;
			
			entity.QuestionId = (System.Int32)reader[((int)ObservationFormColumn.QuestionId - 1)];
			entity.GroupId = (reader.IsDBNull(((int)ObservationFormColumn.GroupId - 1)))?null:(System.Int32?)reader[((int)ObservationFormColumn.GroupId - 1)];
			entity.QuestionRef = (reader.IsDBNull(((int)ObservationFormColumn.QuestionRef - 1)))?null:(System.String)reader[((int)ObservationFormColumn.QuestionRef - 1)];
			entity.QuestionName = (System.String)reader[((int)ObservationFormColumn.QuestionName - 1)];
			entity.LineNumber = (System.Int32)reader[((int)ObservationFormColumn.LineNumber - 1)];
			entity.Status = (System.Boolean)reader[((int)ObservationFormColumn.Status - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.ObservationForm"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.ObservationForm"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Ekip.Framework.Entities.ObservationForm entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.QuestionId = (System.Int32)dataRow["QuestionID"];
			entity.GroupId = Convert.IsDBNull(dataRow["GroupID"]) ? null : (System.Int32?)dataRow["GroupID"];
			entity.QuestionRef = Convert.IsDBNull(dataRow["QuestionRef"]) ? null : (System.String)dataRow["QuestionRef"];
			entity.QuestionName = (System.String)dataRow["QuestionName"];
			entity.LineNumber = (System.Int32)dataRow["LineNumber"];
			entity.Status = (System.Boolean)dataRow["Status"];
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
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.ObservationForm"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.ObservationForm Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Ekip.Framework.Entities.ObservationForm entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region GroupIdSource	
			if (CanDeepLoad(entity, "ObservationFormGroup|GroupIdSource", deepLoadType, innerList) 
				&& entity.GroupIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.GroupId ?? (int)0);
				ObservationFormGroup tmpEntity = EntityManager.LocateEntity<ObservationFormGroup>(EntityLocator.ConstructKeyFromPkItems(typeof(ObservationFormGroup), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.GroupIdSource = tmpEntity;
				else
					entity.GroupIdSource = DataRepository.ObservationFormGroupProvider.GetByGroupId(transactionManager, (entity.GroupId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'GroupIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.GroupIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ObservationFormGroupProvider.DeepLoad(transactionManager, entity.GroupIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion GroupIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByQuestionId methods when available
			
			#region ObservationFormAnswerCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ObservationFormAnswer>|ObservationFormAnswerCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ObservationFormAnswerCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ObservationFormAnswerCollection = DataRepository.ObservationFormAnswerProvider.GetByQuestionId(transactionManager, entity.QuestionId);

				if (deep && entity.ObservationFormAnswerCollection.Count > 0)
				{
					deepHandles.Add("ObservationFormAnswerCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<ObservationFormAnswer>) DataRepository.ObservationFormAnswerProvider.DeepLoad,
						new object[] { transactionManager, entity.ObservationFormAnswerCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region ObservationFormOptionCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ObservationFormOption>|ObservationFormOptionCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ObservationFormOptionCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ObservationFormOptionCollection = DataRepository.ObservationFormOptionProvider.GetByQuestionId(transactionManager, entity.QuestionId);

				if (deep && entity.ObservationFormOptionCollection.Count > 0)
				{
					deepHandles.Add("ObservationFormOptionCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<ObservationFormOption>) DataRepository.ObservationFormOptionProvider.DeepLoad,
						new object[] { transactionManager, entity.ObservationFormOptionCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Ekip.Framework.Entities.ObservationForm object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Ekip.Framework.Entities.ObservationForm instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.ObservationForm Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Ekip.Framework.Entities.ObservationForm entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region GroupIdSource
			if (CanDeepSave(entity, "ObservationFormGroup|GroupIdSource", deepSaveType, innerList) 
				&& entity.GroupIdSource != null)
			{
				DataRepository.ObservationFormGroupProvider.Save(transactionManager, entity.GroupIdSource);
				entity.GroupId = entity.GroupIdSource.GroupId;
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
						if(child.QuestionIdSource != null)
						{
							child.QuestionId = child.QuestionIdSource.QuestionId;
						}
						else
						{
							child.QuestionId = entity.QuestionId;
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
				
	
			#region List<ObservationFormOption>
				if (CanDeepSave(entity.ObservationFormOptionCollection, "List<ObservationFormOption>|ObservationFormOptionCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ObservationFormOption child in entity.ObservationFormOptionCollection)
					{
						if(child.QuestionIdSource != null)
						{
							child.QuestionId = child.QuestionIdSource.QuestionId;
						}
						else
						{
							child.QuestionId = entity.QuestionId;
						}

					}

					if (entity.ObservationFormOptionCollection.Count > 0 || entity.ObservationFormOptionCollection.DeletedItems.Count > 0)
					{
						//DataRepository.ObservationFormOptionProvider.Save(transactionManager, entity.ObservationFormOptionCollection);
						
						deepHandles.Add("ObservationFormOptionCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< ObservationFormOption >) DataRepository.ObservationFormOptionProvider.DeepSave,
							new object[] { transactionManager, entity.ObservationFormOptionCollection, deepSaveType, childTypes, innerList }
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
	
	#region ObservationFormChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Ekip.Framework.Entities.ObservationForm</c>
	///</summary>
	public enum ObservationFormChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>ObservationFormGroup</c> at GroupIdSource
		///</summary>
		[ChildEntityType(typeof(ObservationFormGroup))]
		ObservationFormGroup,
	
		///<summary>
		/// Collection of <c>ObservationForm</c> as OneToMany for ObservationFormAnswerCollection
		///</summary>
		[ChildEntityType(typeof(TList<ObservationFormAnswer>))]
		ObservationFormAnswerCollection,

		///<summary>
		/// Collection of <c>ObservationForm</c> as OneToMany for ObservationFormOptionCollection
		///</summary>
		[ChildEntityType(typeof(TList<ObservationFormOption>))]
		ObservationFormOptionCollection,
	}
	
	#endregion ObservationFormChildEntityTypes
	
	#region ObservationFormFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ObservationFormColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ObservationForm"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ObservationFormFilterBuilder : SqlFilterBuilder<ObservationFormColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ObservationFormFilterBuilder class.
		/// </summary>
		public ObservationFormFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ObservationFormFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ObservationFormFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ObservationFormFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ObservationFormFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ObservationFormFilterBuilder
	
	#region ObservationFormParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ObservationFormColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ObservationForm"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ObservationFormParameterBuilder : ParameterizedSqlFilterBuilder<ObservationFormColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ObservationFormParameterBuilder class.
		/// </summary>
		public ObservationFormParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ObservationFormParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ObservationFormParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ObservationFormParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ObservationFormParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ObservationFormParameterBuilder
	
	#region ObservationFormSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ObservationFormColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ObservationForm"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ObservationFormSortBuilder : SqlSortBuilder<ObservationFormColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ObservationFormSqlSortBuilder class.
		/// </summary>
		public ObservationFormSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ObservationFormSortBuilder
	
} // end namespace
