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
	/// This class is the base class for any <see cref="QuestionFormProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class QuestionFormProviderBaseCore : EntityProviderBase<Ekip.Framework.Entities.QuestionForm, Ekip.Framework.Entities.QuestionFormKey>
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
		public override bool Delete(TransactionManager transactionManager, Ekip.Framework.Entities.QuestionFormKey key)
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
		/// 	Gets rows from the datasource based on the FK_QuestionForm_QuestionForm_Group key.
		///		FK_QuestionForm_QuestionForm_Group Description: 
		/// </summary>
		/// <param name="_groupId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.QuestionForm objects.</returns>
		public TList<QuestionForm> GetByGroupId(System.Int32? _groupId)
		{
			int count = -1;
			return GetByGroupId(_groupId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QuestionForm_QuestionForm_Group key.
		///		FK_QuestionForm_QuestionForm_Group Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_groupId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.QuestionForm objects.</returns>
		/// <remarks></remarks>
		public TList<QuestionForm> GetByGroupId(TransactionManager transactionManager, System.Int32? _groupId)
		{
			int count = -1;
			return GetByGroupId(transactionManager, _groupId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_QuestionForm_QuestionForm_Group key.
		///		FK_QuestionForm_QuestionForm_Group Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_groupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.QuestionForm objects.</returns>
		public TList<QuestionForm> GetByGroupId(TransactionManager transactionManager, System.Int32? _groupId, int start, int pageLength)
		{
			int count = -1;
			return GetByGroupId(transactionManager, _groupId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QuestionForm_QuestionForm_Group key.
		///		fkQuestionFormQuestionFormGroup Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_groupId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.QuestionForm objects.</returns>
		public TList<QuestionForm> GetByGroupId(System.Int32? _groupId, int start, int pageLength)
		{
			int count =  -1;
			return GetByGroupId(null, _groupId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QuestionForm_QuestionForm_Group key.
		///		fkQuestionFormQuestionFormGroup Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_groupId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.QuestionForm objects.</returns>
		public TList<QuestionForm> GetByGroupId(System.Int32? _groupId, int start, int pageLength,out int count)
		{
			return GetByGroupId(null, _groupId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QuestionForm_QuestionForm_Group key.
		///		FK_QuestionForm_QuestionForm_Group Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_groupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.QuestionForm objects.</returns>
		public abstract TList<QuestionForm> GetByGroupId(TransactionManager transactionManager, System.Int32? _groupId, int start, int pageLength, out int count);
		
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
		public override Ekip.Framework.Entities.QuestionForm Get(TransactionManager transactionManager, Ekip.Framework.Entities.QuestionFormKey key, int start, int pageLength)
		{
			return GetByQuestionId(transactionManager, key.QuestionId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_QuestionForm index.
		/// </summary>
		/// <param name="_questionId"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.QuestionForm"/> class.</returns>
		public Ekip.Framework.Entities.QuestionForm GetByQuestionId(System.Int32 _questionId)
		{
			int count = -1;
			return GetByQuestionId(null,_questionId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_QuestionForm index.
		/// </summary>
		/// <param name="_questionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.QuestionForm"/> class.</returns>
		public Ekip.Framework.Entities.QuestionForm GetByQuestionId(System.Int32 _questionId, int start, int pageLength)
		{
			int count = -1;
			return GetByQuestionId(null, _questionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_QuestionForm index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_questionId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.QuestionForm"/> class.</returns>
		public Ekip.Framework.Entities.QuestionForm GetByQuestionId(TransactionManager transactionManager, System.Int32 _questionId)
		{
			int count = -1;
			return GetByQuestionId(transactionManager, _questionId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_QuestionForm index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_questionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.QuestionForm"/> class.</returns>
		public Ekip.Framework.Entities.QuestionForm GetByQuestionId(TransactionManager transactionManager, System.Int32 _questionId, int start, int pageLength)
		{
			int count = -1;
			return GetByQuestionId(transactionManager, _questionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_QuestionForm index.
		/// </summary>
		/// <param name="_questionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.QuestionForm"/> class.</returns>
		public Ekip.Framework.Entities.QuestionForm GetByQuestionId(System.Int32 _questionId, int start, int pageLength, out int count)
		{
			return GetByQuestionId(null, _questionId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_QuestionForm index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_questionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.QuestionForm"/> class.</returns>
		public abstract Ekip.Framework.Entities.QuestionForm GetByQuestionId(TransactionManager transactionManager, System.Int32 _questionId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;QuestionForm&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;QuestionForm&gt;"/></returns>
		public static TList<QuestionForm> Fill(IDataReader reader, TList<QuestionForm> rows, int start, int pageLength)
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
				
				Ekip.Framework.Entities.QuestionForm c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("QuestionForm")
					.Append("|").Append((System.Int32)reader[((int)QuestionFormColumn.QuestionId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<QuestionForm>(
					key.ToString(), // EntityTrackingKey
					"QuestionForm",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Ekip.Framework.Entities.QuestionForm();
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
					c.QuestionId = (System.Int32)reader[((int)QuestionFormColumn.QuestionId - 1)];
					c.GroupId = (reader.IsDBNull(((int)QuestionFormColumn.GroupId - 1)))?null:(System.Int32?)reader[((int)QuestionFormColumn.GroupId - 1)];
					c.QuestionRef = (reader.IsDBNull(((int)QuestionFormColumn.QuestionRef - 1)))?null:(System.String)reader[((int)QuestionFormColumn.QuestionRef - 1)];
					c.QuestionName = (System.String)reader[((int)QuestionFormColumn.QuestionName - 1)];
					c.LineNumber = (System.Int32)reader[((int)QuestionFormColumn.LineNumber - 1)];
					c.Status = (System.Boolean)reader[((int)QuestionFormColumn.Status - 1)];
					c.CreateDate = (System.DateTime)reader[((int)QuestionFormColumn.CreateDate - 1)];
					c.UpdateDate = (reader.IsDBNull(((int)QuestionFormColumn.UpdateDate - 1)))?null:(System.DateTime?)reader[((int)QuestionFormColumn.UpdateDate - 1)];
					c.CreateUserId = (System.Int32)reader[((int)QuestionFormColumn.CreateUserId - 1)];
					c.UpdateUserId = (reader.IsDBNull(((int)QuestionFormColumn.UpdateUserId - 1)))?null:(System.Int32?)reader[((int)QuestionFormColumn.UpdateUserId - 1)];
					c.Active = (System.Boolean)reader[((int)QuestionFormColumn.Active - 1)];
					c.Deleted = (System.Boolean)reader[((int)QuestionFormColumn.Deleted - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.QuestionForm"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.QuestionForm"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Ekip.Framework.Entities.QuestionForm entity)
		{
			if (!reader.Read()) return;
			
			entity.QuestionId = (System.Int32)reader[((int)QuestionFormColumn.QuestionId - 1)];
			entity.GroupId = (reader.IsDBNull(((int)QuestionFormColumn.GroupId - 1)))?null:(System.Int32?)reader[((int)QuestionFormColumn.GroupId - 1)];
			entity.QuestionRef = (reader.IsDBNull(((int)QuestionFormColumn.QuestionRef - 1)))?null:(System.String)reader[((int)QuestionFormColumn.QuestionRef - 1)];
			entity.QuestionName = (System.String)reader[((int)QuestionFormColumn.QuestionName - 1)];
			entity.LineNumber = (System.Int32)reader[((int)QuestionFormColumn.LineNumber - 1)];
			entity.Status = (System.Boolean)reader[((int)QuestionFormColumn.Status - 1)];
			entity.CreateDate = (System.DateTime)reader[((int)QuestionFormColumn.CreateDate - 1)];
			entity.UpdateDate = (reader.IsDBNull(((int)QuestionFormColumn.UpdateDate - 1)))?null:(System.DateTime?)reader[((int)QuestionFormColumn.UpdateDate - 1)];
			entity.CreateUserId = (System.Int32)reader[((int)QuestionFormColumn.CreateUserId - 1)];
			entity.UpdateUserId = (reader.IsDBNull(((int)QuestionFormColumn.UpdateUserId - 1)))?null:(System.Int32?)reader[((int)QuestionFormColumn.UpdateUserId - 1)];
			entity.Active = (System.Boolean)reader[((int)QuestionFormColumn.Active - 1)];
			entity.Deleted = (System.Boolean)reader[((int)QuestionFormColumn.Deleted - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.QuestionForm"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.QuestionForm"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Ekip.Framework.Entities.QuestionForm entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.QuestionId = (System.Int32)dataRow["QuestionId"];
			entity.GroupId = Convert.IsDBNull(dataRow["GroupId"]) ? null : (System.Int32?)dataRow["GroupId"];
			entity.QuestionRef = Convert.IsDBNull(dataRow["QuestionRef"]) ? null : (System.String)dataRow["QuestionRef"];
			entity.QuestionName = (System.String)dataRow["QuestionName"];
			entity.LineNumber = (System.Int32)dataRow["LineNumber"];
			entity.Status = (System.Boolean)dataRow["Status"];
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
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.QuestionForm"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.QuestionForm Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Ekip.Framework.Entities.QuestionForm entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region GroupIdSource	
			if (CanDeepLoad(entity, "QuestionFormGroup|GroupIdSource", deepLoadType, innerList) 
				&& entity.GroupIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.GroupId ?? (int)0);
				QuestionFormGroup tmpEntity = EntityManager.LocateEntity<QuestionFormGroup>(EntityLocator.ConstructKeyFromPkItems(typeof(QuestionFormGroup), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.GroupIdSource = tmpEntity;
				else
					entity.GroupIdSource = DataRepository.QuestionFormGroupProvider.GetByGroupId(transactionManager, (entity.GroupId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'GroupIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.GroupIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.QuestionFormGroupProvider.DeepLoad(transactionManager, entity.GroupIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion GroupIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByQuestionId methods when available
			
			#region QuestionFormOptionCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<QuestionFormOption>|QuestionFormOptionCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'QuestionFormOptionCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.QuestionFormOptionCollection = DataRepository.QuestionFormOptionProvider.GetByQuestionId(transactionManager, entity.QuestionId);

				if (deep && entity.QuestionFormOptionCollection.Count > 0)
				{
					deepHandles.Add("QuestionFormOptionCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<QuestionFormOption>) DataRepository.QuestionFormOptionProvider.DeepLoad,
						new object[] { transactionManager, entity.QuestionFormOptionCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region QuestionFormAnswerCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<QuestionFormAnswer>|QuestionFormAnswerCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'QuestionFormAnswerCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.QuestionFormAnswerCollection = DataRepository.QuestionFormAnswerProvider.GetByQuestionId(transactionManager, entity.QuestionId);

				if (deep && entity.QuestionFormAnswerCollection.Count > 0)
				{
					deepHandles.Add("QuestionFormAnswerCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<QuestionFormAnswer>) DataRepository.QuestionFormAnswerProvider.DeepLoad,
						new object[] { transactionManager, entity.QuestionFormAnswerCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Ekip.Framework.Entities.QuestionForm object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Ekip.Framework.Entities.QuestionForm instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.QuestionForm Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Ekip.Framework.Entities.QuestionForm entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region GroupIdSource
			if (CanDeepSave(entity, "QuestionFormGroup|GroupIdSource", deepSaveType, innerList) 
				&& entity.GroupIdSource != null)
			{
				DataRepository.QuestionFormGroupProvider.Save(transactionManager, entity.GroupIdSource);
				entity.GroupId = entity.GroupIdSource.GroupId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<QuestionFormOption>
				if (CanDeepSave(entity.QuestionFormOptionCollection, "List<QuestionFormOption>|QuestionFormOptionCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(QuestionFormOption child in entity.QuestionFormOptionCollection)
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

					if (entity.QuestionFormOptionCollection.Count > 0 || entity.QuestionFormOptionCollection.DeletedItems.Count > 0)
					{
						//DataRepository.QuestionFormOptionProvider.Save(transactionManager, entity.QuestionFormOptionCollection);
						
						deepHandles.Add("QuestionFormOptionCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< QuestionFormOption >) DataRepository.QuestionFormOptionProvider.DeepSave,
							new object[] { transactionManager, entity.QuestionFormOptionCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<QuestionFormAnswer>
				if (CanDeepSave(entity.QuestionFormAnswerCollection, "List<QuestionFormAnswer>|QuestionFormAnswerCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(QuestionFormAnswer child in entity.QuestionFormAnswerCollection)
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

					if (entity.QuestionFormAnswerCollection.Count > 0 || entity.QuestionFormAnswerCollection.DeletedItems.Count > 0)
					{
						//DataRepository.QuestionFormAnswerProvider.Save(transactionManager, entity.QuestionFormAnswerCollection);
						
						deepHandles.Add("QuestionFormAnswerCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< QuestionFormAnswer >) DataRepository.QuestionFormAnswerProvider.DeepSave,
							new object[] { transactionManager, entity.QuestionFormAnswerCollection, deepSaveType, childTypes, innerList }
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
	
	#region QuestionFormChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Ekip.Framework.Entities.QuestionForm</c>
	///</summary>
	public enum QuestionFormChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>QuestionFormGroup</c> at GroupIdSource
		///</summary>
		[ChildEntityType(typeof(QuestionFormGroup))]
		QuestionFormGroup,
	
		///<summary>
		/// Collection of <c>QuestionForm</c> as OneToMany for QuestionFormOptionCollection
		///</summary>
		[ChildEntityType(typeof(TList<QuestionFormOption>))]
		QuestionFormOptionCollection,

		///<summary>
		/// Collection of <c>QuestionForm</c> as OneToMany for QuestionFormAnswerCollection
		///</summary>
		[ChildEntityType(typeof(TList<QuestionFormAnswer>))]
		QuestionFormAnswerCollection,
	}
	
	#endregion QuestionFormChildEntityTypes
	
	#region QuestionFormFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;QuestionFormColumn&gt;"/> class
	/// that is used exclusively with a <see cref="QuestionForm"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuestionFormFilterBuilder : SqlFilterBuilder<QuestionFormColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuestionFormFilterBuilder class.
		/// </summary>
		public QuestionFormFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the QuestionFormFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public QuestionFormFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the QuestionFormFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public QuestionFormFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion QuestionFormFilterBuilder
	
	#region QuestionFormParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;QuestionFormColumn&gt;"/> class
	/// that is used exclusively with a <see cref="QuestionForm"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuestionFormParameterBuilder : ParameterizedSqlFilterBuilder<QuestionFormColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuestionFormParameterBuilder class.
		/// </summary>
		public QuestionFormParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the QuestionFormParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public QuestionFormParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the QuestionFormParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public QuestionFormParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion QuestionFormParameterBuilder
	
	#region QuestionFormSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;QuestionFormColumn&gt;"/> class
	/// that is used exclusively with a <see cref="QuestionForm"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class QuestionFormSortBuilder : SqlSortBuilder<QuestionFormColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuestionFormSqlSortBuilder class.
		/// </summary>
		public QuestionFormSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion QuestionFormSortBuilder
	
} // end namespace
