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
	/// This class is the base class for any <see cref="QuestionProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class QuestionProviderBaseCore : EntityProviderBase<Ekip.Framework.Entities.Question, Ekip.Framework.Entities.QuestionKey>
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
		public override bool Delete(TransactionManager transactionManager, Ekip.Framework.Entities.QuestionKey key)
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
		/// 	Gets rows from the datasource based on the FK_Question_QuestionGroup key.
		///		FK_Question_QuestionGroup Description: 
		/// </summary>
		/// <param name="_groupId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Question objects.</returns>
		public TList<Question> GetByGroupId(System.Int32? _groupId)
		{
			int count = -1;
			return GetByGroupId(_groupId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Question_QuestionGroup key.
		///		FK_Question_QuestionGroup Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_groupId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Question objects.</returns>
		/// <remarks></remarks>
		public TList<Question> GetByGroupId(TransactionManager transactionManager, System.Int32? _groupId)
		{
			int count = -1;
			return GetByGroupId(transactionManager, _groupId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Question_QuestionGroup key.
		///		FK_Question_QuestionGroup Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_groupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Question objects.</returns>
		public TList<Question> GetByGroupId(TransactionManager transactionManager, System.Int32? _groupId, int start, int pageLength)
		{
			int count = -1;
			return GetByGroupId(transactionManager, _groupId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Question_QuestionGroup key.
		///		fkQuestionQuestionGroup Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_groupId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Question objects.</returns>
		public TList<Question> GetByGroupId(System.Int32? _groupId, int start, int pageLength)
		{
			int count =  -1;
			return GetByGroupId(null, _groupId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Question_QuestionGroup key.
		///		fkQuestionQuestionGroup Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_groupId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Question objects.</returns>
		public TList<Question> GetByGroupId(System.Int32? _groupId, int start, int pageLength,out int count)
		{
			return GetByGroupId(null, _groupId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Question_QuestionGroup key.
		///		FK_Question_QuestionGroup Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_groupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Question objects.</returns>
		public abstract TList<Question> GetByGroupId(TransactionManager transactionManager, System.Int32? _groupId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Question_Test key.
		///		FK_Question_Test Description: 
		/// </summary>
		/// <param name="_testId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Question objects.</returns>
		public TList<Question> GetByTestId(System.Int32 _testId)
		{
			int count = -1;
			return GetByTestId(_testId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Question_Test key.
		///		FK_Question_Test Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_testId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Question objects.</returns>
		/// <remarks></remarks>
		public TList<Question> GetByTestId(TransactionManager transactionManager, System.Int32 _testId)
		{
			int count = -1;
			return GetByTestId(transactionManager, _testId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Question_Test key.
		///		FK_Question_Test Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_testId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Question objects.</returns>
		public TList<Question> GetByTestId(TransactionManager transactionManager, System.Int32 _testId, int start, int pageLength)
		{
			int count = -1;
			return GetByTestId(transactionManager, _testId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Question_Test key.
		///		fkQuestionTest Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_testId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Question objects.</returns>
		public TList<Question> GetByTestId(System.Int32 _testId, int start, int pageLength)
		{
			int count =  -1;
			return GetByTestId(null, _testId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Question_Test key.
		///		fkQuestionTest Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_testId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Question objects.</returns>
		public TList<Question> GetByTestId(System.Int32 _testId, int start, int pageLength,out int count)
		{
			return GetByTestId(null, _testId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Question_Test key.
		///		FK_Question_Test Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_testId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Question objects.</returns>
		public abstract TList<Question> GetByTestId(TransactionManager transactionManager, System.Int32 _testId, int start, int pageLength, out int count);
		
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
		public override Ekip.Framework.Entities.Question Get(TransactionManager transactionManager, Ekip.Framework.Entities.QuestionKey key, int start, int pageLength)
		{
			return GetByQuestionId(transactionManager, key.QuestionId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Question index.
		/// </summary>
		/// <param name="_questionId"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Question"/> class.</returns>
		public Ekip.Framework.Entities.Question GetByQuestionId(System.Int32 _questionId)
		{
			int count = -1;
			return GetByQuestionId(null,_questionId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Question index.
		/// </summary>
		/// <param name="_questionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Question"/> class.</returns>
		public Ekip.Framework.Entities.Question GetByQuestionId(System.Int32 _questionId, int start, int pageLength)
		{
			int count = -1;
			return GetByQuestionId(null, _questionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Question index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_questionId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Question"/> class.</returns>
		public Ekip.Framework.Entities.Question GetByQuestionId(TransactionManager transactionManager, System.Int32 _questionId)
		{
			int count = -1;
			return GetByQuestionId(transactionManager, _questionId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Question index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_questionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Question"/> class.</returns>
		public Ekip.Framework.Entities.Question GetByQuestionId(TransactionManager transactionManager, System.Int32 _questionId, int start, int pageLength)
		{
			int count = -1;
			return GetByQuestionId(transactionManager, _questionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Question index.
		/// </summary>
		/// <param name="_questionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Question"/> class.</returns>
		public Ekip.Framework.Entities.Question GetByQuestionId(System.Int32 _questionId, int start, int pageLength, out int count)
		{
			return GetByQuestionId(null, _questionId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Question index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_questionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Question"/> class.</returns>
		public abstract Ekip.Framework.Entities.Question GetByQuestionId(TransactionManager transactionManager, System.Int32 _questionId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Question&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Question&gt;"/></returns>
		public static TList<Question> Fill(IDataReader reader, TList<Question> rows, int start, int pageLength)
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
				
				Ekip.Framework.Entities.Question c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Question")
					.Append("|").Append((System.Int32)reader[((int)QuestionColumn.QuestionId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Question>(
					key.ToString(), // EntityTrackingKey
					"Question",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Ekip.Framework.Entities.Question();
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
					c.QuestionId = (System.Int32)reader[((int)QuestionColumn.QuestionId - 1)];
					c.TestId = (System.Int32)reader[((int)QuestionColumn.TestId - 1)];
					c.GroupId = (reader.IsDBNull(((int)QuestionColumn.GroupId - 1)))?null:(System.Int32?)reader[((int)QuestionColumn.GroupId - 1)];
					c.QuestionRef = (reader.IsDBNull(((int)QuestionColumn.QuestionRef - 1)))?null:(System.String)reader[((int)QuestionColumn.QuestionRef - 1)];
					c.QuestionName = (System.String)reader[((int)QuestionColumn.QuestionName - 1)];
					c.LineNumber = (System.Int32)reader[((int)QuestionColumn.LineNumber - 1)];
					c.Status = (System.Boolean)reader[((int)QuestionColumn.Status - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.Question"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Question"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Ekip.Framework.Entities.Question entity)
		{
			if (!reader.Read()) return;
			
			entity.QuestionId = (System.Int32)reader[((int)QuestionColumn.QuestionId - 1)];
			entity.TestId = (System.Int32)reader[((int)QuestionColumn.TestId - 1)];
			entity.GroupId = (reader.IsDBNull(((int)QuestionColumn.GroupId - 1)))?null:(System.Int32?)reader[((int)QuestionColumn.GroupId - 1)];
			entity.QuestionRef = (reader.IsDBNull(((int)QuestionColumn.QuestionRef - 1)))?null:(System.String)reader[((int)QuestionColumn.QuestionRef - 1)];
			entity.QuestionName = (System.String)reader[((int)QuestionColumn.QuestionName - 1)];
			entity.LineNumber = (System.Int32)reader[((int)QuestionColumn.LineNumber - 1)];
			entity.Status = (System.Boolean)reader[((int)QuestionColumn.Status - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.Question"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Question"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Ekip.Framework.Entities.Question entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.QuestionId = (System.Int32)dataRow["QuestionID"];
			entity.TestId = (System.Int32)dataRow["TestID"];
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
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Question"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.Question Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Ekip.Framework.Entities.Question entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

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

			#region TestIdSource	
			if (CanDeepLoad(entity, "Test|TestIdSource", deepLoadType, innerList) 
				&& entity.TestIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.TestId;
				Test tmpEntity = EntityManager.LocateEntity<Test>(EntityLocator.ConstructKeyFromPkItems(typeof(Test), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.TestIdSource = tmpEntity;
				else
					entity.TestIdSource = DataRepository.TestProvider.GetByTestId(transactionManager, entity.TestId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'TestIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.TestIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.TestProvider.DeepLoad(transactionManager, entity.TestIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion TestIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByQuestionId methods when available
			
			#region TestResultCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<TestResult>|TestResultCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'TestResultCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.TestResultCollection = DataRepository.TestResultProvider.GetByQuestionId(transactionManager, entity.QuestionId);

				if (deep && entity.TestResultCollection.Count > 0)
				{
					deepHandles.Add("TestResultCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<TestResult>) DataRepository.TestResultProvider.DeepLoad,
						new object[] { transactionManager, entity.TestResultCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region OptionCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Option>|OptionCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'OptionCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.OptionCollection = DataRepository.OptionProvider.GetByQuestionId(transactionManager, entity.QuestionId);

				if (deep && entity.OptionCollection.Count > 0)
				{
					deepHandles.Add("OptionCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Option>) DataRepository.OptionProvider.DeepLoad,
						new object[] { transactionManager, entity.OptionCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Ekip.Framework.Entities.Question object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Ekip.Framework.Entities.Question instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.Question Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Ekip.Framework.Entities.Question entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region GroupIdSource
			if (CanDeepSave(entity, "QuestionGroup|GroupIdSource", deepSaveType, innerList) 
				&& entity.GroupIdSource != null)
			{
				DataRepository.QuestionGroupProvider.Save(transactionManager, entity.GroupIdSource);
				entity.GroupId = entity.GroupIdSource.GroupId;
			}
			#endregion 
			
			#region TestIdSource
			if (CanDeepSave(entity, "Test|TestIdSource", deepSaveType, innerList) 
				&& entity.TestIdSource != null)
			{
				DataRepository.TestProvider.Save(transactionManager, entity.TestIdSource);
				entity.TestId = entity.TestIdSource.TestId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<TestResult>
				if (CanDeepSave(entity.TestResultCollection, "List<TestResult>|TestResultCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(TestResult child in entity.TestResultCollection)
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

					if (entity.TestResultCollection.Count > 0 || entity.TestResultCollection.DeletedItems.Count > 0)
					{
						//DataRepository.TestResultProvider.Save(transactionManager, entity.TestResultCollection);
						
						deepHandles.Add("TestResultCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< TestResult >) DataRepository.TestResultProvider.DeepSave,
							new object[] { transactionManager, entity.TestResultCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<Option>
				if (CanDeepSave(entity.OptionCollection, "List<Option>|OptionCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Option child in entity.OptionCollection)
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

					if (entity.OptionCollection.Count > 0 || entity.OptionCollection.DeletedItems.Count > 0)
					{
						//DataRepository.OptionProvider.Save(transactionManager, entity.OptionCollection);
						
						deepHandles.Add("OptionCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Option >) DataRepository.OptionProvider.DeepSave,
							new object[] { transactionManager, entity.OptionCollection, deepSaveType, childTypes, innerList }
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
	
	#region QuestionChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Ekip.Framework.Entities.Question</c>
	///</summary>
	public enum QuestionChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>QuestionGroup</c> at GroupIdSource
		///</summary>
		[ChildEntityType(typeof(QuestionGroup))]
		QuestionGroup,
			
		///<summary>
		/// Composite Property for <c>Test</c> at TestIdSource
		///</summary>
		[ChildEntityType(typeof(Test))]
		Test,
	
		///<summary>
		/// Collection of <c>Question</c> as OneToMany for TestResultCollection
		///</summary>
		[ChildEntityType(typeof(TList<TestResult>))]
		TestResultCollection,

		///<summary>
		/// Collection of <c>Question</c> as OneToMany for OptionCollection
		///</summary>
		[ChildEntityType(typeof(TList<Option>))]
		OptionCollection,
	}
	
	#endregion QuestionChildEntityTypes
	
	#region QuestionFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;QuestionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Question"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuestionFilterBuilder : SqlFilterBuilder<QuestionColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuestionFilterBuilder class.
		/// </summary>
		public QuestionFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the QuestionFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public QuestionFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the QuestionFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public QuestionFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion QuestionFilterBuilder
	
	#region QuestionParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;QuestionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Question"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuestionParameterBuilder : ParameterizedSqlFilterBuilder<QuestionColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuestionParameterBuilder class.
		/// </summary>
		public QuestionParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the QuestionParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public QuestionParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the QuestionParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public QuestionParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion QuestionParameterBuilder
	
	#region QuestionSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;QuestionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Question"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class QuestionSortBuilder : SqlSortBuilder<QuestionColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuestionSqlSortBuilder class.
		/// </summary>
		public QuestionSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion QuestionSortBuilder
	
} // end namespace
