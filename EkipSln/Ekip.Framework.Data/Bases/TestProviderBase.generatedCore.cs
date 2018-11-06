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
	/// This class is the base class for any <see cref="TestProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class TestProviderBaseCore : EntityProviderBase<Ekip.Framework.Entities.Test, Ekip.Framework.Entities.TestKey>
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
		public override bool Delete(TransactionManager transactionManager, Ekip.Framework.Entities.TestKey key)
		{
			return Delete(transactionManager, key.TestId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_testId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _testId)
		{
			return Delete(null, _testId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_testId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _testId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
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
		public override Ekip.Framework.Entities.Test Get(TransactionManager transactionManager, Ekip.Framework.Entities.TestKey key, int start, int pageLength)
		{
			return GetByTestId(transactionManager, key.TestId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Test index.
		/// </summary>
		/// <param name="_testId"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Test"/> class.</returns>
		public Ekip.Framework.Entities.Test GetByTestId(System.Int32 _testId)
		{
			int count = -1;
			return GetByTestId(null,_testId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Test index.
		/// </summary>
		/// <param name="_testId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Test"/> class.</returns>
		public Ekip.Framework.Entities.Test GetByTestId(System.Int32 _testId, int start, int pageLength)
		{
			int count = -1;
			return GetByTestId(null, _testId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Test index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_testId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Test"/> class.</returns>
		public Ekip.Framework.Entities.Test GetByTestId(TransactionManager transactionManager, System.Int32 _testId)
		{
			int count = -1;
			return GetByTestId(transactionManager, _testId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Test index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_testId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Test"/> class.</returns>
		public Ekip.Framework.Entities.Test GetByTestId(TransactionManager transactionManager, System.Int32 _testId, int start, int pageLength)
		{
			int count = -1;
			return GetByTestId(transactionManager, _testId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Test index.
		/// </summary>
		/// <param name="_testId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Test"/> class.</returns>
		public Ekip.Framework.Entities.Test GetByTestId(System.Int32 _testId, int start, int pageLength, out int count)
		{
			return GetByTestId(null, _testId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Test index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_testId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Test"/> class.</returns>
		public abstract Ekip.Framework.Entities.Test GetByTestId(TransactionManager transactionManager, System.Int32 _testId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Test&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Test&gt;"/></returns>
		public static TList<Test> Fill(IDataReader reader, TList<Test> rows, int start, int pageLength)
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
				
				Ekip.Framework.Entities.Test c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Test")
					.Append("|").Append((System.Int32)reader[((int)TestColumn.TestId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Test>(
					key.ToString(), // EntityTrackingKey
					"Test",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Ekip.Framework.Entities.Test();
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
					c.TestId = (System.Int32)reader[((int)TestColumn.TestId - 1)];
					c.TestRef = (reader.IsDBNull(((int)TestColumn.TestRef - 1)))?null:(System.String)reader[((int)TestColumn.TestRef - 1)];
					c.TestName = (System.String)reader[((int)TestColumn.TestName - 1)];
					c.Description = (System.String)reader[((int)TestColumn.Description - 1)];
					c.Status = (System.Boolean)reader[((int)TestColumn.Status - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.Test"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Test"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Ekip.Framework.Entities.Test entity)
		{
			if (!reader.Read()) return;
			
			entity.TestId = (System.Int32)reader[((int)TestColumn.TestId - 1)];
			entity.TestRef = (reader.IsDBNull(((int)TestColumn.TestRef - 1)))?null:(System.String)reader[((int)TestColumn.TestRef - 1)];
			entity.TestName = (System.String)reader[((int)TestColumn.TestName - 1)];
			entity.Description = (System.String)reader[((int)TestColumn.Description - 1)];
			entity.Status = (System.Boolean)reader[((int)TestColumn.Status - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.Test"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Test"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Ekip.Framework.Entities.Test entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.TestId = (System.Int32)dataRow["TestID"];
			entity.TestRef = Convert.IsDBNull(dataRow["TestRef"]) ? null : (System.String)dataRow["TestRef"];
			entity.TestName = (System.String)dataRow["TestName"];
			entity.Description = (System.String)dataRow["Description"];
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
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Test"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.Test Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Ekip.Framework.Entities.Test entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByTestId methods when available
			
			#region TestResultCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<TestResult>|TestResultCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'TestResultCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.TestResultCollection = DataRepository.TestResultProvider.GetByTestId(transactionManager, entity.TestId);

				if (deep && entity.TestResultCollection.Count > 0)
				{
					deepHandles.Add("TestResultCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<TestResult>) DataRepository.TestResultProvider.DeepLoad,
						new object[] { transactionManager, entity.TestResultCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region QuestionCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Question>|QuestionCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'QuestionCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.QuestionCollection = DataRepository.QuestionProvider.GetByTestId(transactionManager, entity.TestId);

				if (deep && entity.QuestionCollection.Count > 0)
				{
					deepHandles.Add("QuestionCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Question>) DataRepository.QuestionProvider.DeepLoad,
						new object[] { transactionManager, entity.QuestionCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region ClientTestCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ClientTest>|ClientTestCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ClientTestCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ClientTestCollection = DataRepository.ClientTestProvider.GetByTestId(transactionManager, entity.TestId);

				if (deep && entity.ClientTestCollection.Count > 0)
				{
					deepHandles.Add("ClientTestCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<ClientTest>) DataRepository.ClientTestProvider.DeepLoad,
						new object[] { transactionManager, entity.ClientTestCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region QuestionGroupCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<QuestionGroup>|QuestionGroupCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'QuestionGroupCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.QuestionGroupCollection = DataRepository.QuestionGroupProvider.GetByTestId(transactionManager, entity.TestId);

				if (deep && entity.QuestionGroupCollection.Count > 0)
				{
					deepHandles.Add("QuestionGroupCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<QuestionGroup>) DataRepository.QuestionGroupProvider.DeepLoad,
						new object[] { transactionManager, entity.QuestionGroupCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Ekip.Framework.Entities.Test object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Ekip.Framework.Entities.Test instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.Test Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Ekip.Framework.Entities.Test entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
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
						if(child.TestIdSource != null)
						{
							child.TestId = child.TestIdSource.TestId;
						}
						else
						{
							child.TestId = entity.TestId;
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
				
	
			#region List<Question>
				if (CanDeepSave(entity.QuestionCollection, "List<Question>|QuestionCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Question child in entity.QuestionCollection)
					{
						if(child.TestIdSource != null)
						{
							child.TestId = child.TestIdSource.TestId;
						}
						else
						{
							child.TestId = entity.TestId;
						}

					}

					if (entity.QuestionCollection.Count > 0 || entity.QuestionCollection.DeletedItems.Count > 0)
					{
						//DataRepository.QuestionProvider.Save(transactionManager, entity.QuestionCollection);
						
						deepHandles.Add("QuestionCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Question >) DataRepository.QuestionProvider.DeepSave,
							new object[] { transactionManager, entity.QuestionCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<ClientTest>
				if (CanDeepSave(entity.ClientTestCollection, "List<ClientTest>|ClientTestCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ClientTest child in entity.ClientTestCollection)
					{
						if(child.TestIdSource != null)
						{
							child.TestId = child.TestIdSource.TestId;
						}
						else
						{
							child.TestId = entity.TestId;
						}

					}

					if (entity.ClientTestCollection.Count > 0 || entity.ClientTestCollection.DeletedItems.Count > 0)
					{
						//DataRepository.ClientTestProvider.Save(transactionManager, entity.ClientTestCollection);
						
						deepHandles.Add("ClientTestCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< ClientTest >) DataRepository.ClientTestProvider.DeepSave,
							new object[] { transactionManager, entity.ClientTestCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<QuestionGroup>
				if (CanDeepSave(entity.QuestionGroupCollection, "List<QuestionGroup>|QuestionGroupCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(QuestionGroup child in entity.QuestionGroupCollection)
					{
						if(child.TestIdSource != null)
						{
							child.TestId = child.TestIdSource.TestId;
						}
						else
						{
							child.TestId = entity.TestId;
						}

					}

					if (entity.QuestionGroupCollection.Count > 0 || entity.QuestionGroupCollection.DeletedItems.Count > 0)
					{
						//DataRepository.QuestionGroupProvider.Save(transactionManager, entity.QuestionGroupCollection);
						
						deepHandles.Add("QuestionGroupCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< QuestionGroup >) DataRepository.QuestionGroupProvider.DeepSave,
							new object[] { transactionManager, entity.QuestionGroupCollection, deepSaveType, childTypes, innerList }
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
	
	#region TestChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Ekip.Framework.Entities.Test</c>
	///</summary>
	public enum TestChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Test</c> as OneToMany for TestResultCollection
		///</summary>
		[ChildEntityType(typeof(TList<TestResult>))]
		TestResultCollection,

		///<summary>
		/// Collection of <c>Test</c> as OneToMany for QuestionCollection
		///</summary>
		[ChildEntityType(typeof(TList<Question>))]
		QuestionCollection,

		///<summary>
		/// Collection of <c>Test</c> as OneToMany for ClientTestCollection
		///</summary>
		[ChildEntityType(typeof(TList<ClientTest>))]
		ClientTestCollection,

		///<summary>
		/// Collection of <c>Test</c> as OneToMany for QuestionGroupCollection
		///</summary>
		[ChildEntityType(typeof(TList<QuestionGroup>))]
		QuestionGroupCollection,
	}
	
	#endregion TestChildEntityTypes
	
	#region TestFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;TestColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Test"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TestFilterBuilder : SqlFilterBuilder<TestColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TestFilterBuilder class.
		/// </summary>
		public TestFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TestFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TestFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TestFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TestFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TestFilterBuilder
	
	#region TestParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;TestColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Test"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TestParameterBuilder : ParameterizedSqlFilterBuilder<TestColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TestParameterBuilder class.
		/// </summary>
		public TestParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TestParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TestParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TestParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TestParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TestParameterBuilder
	
	#region TestSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;TestColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Test"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class TestSortBuilder : SqlSortBuilder<TestColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TestSqlSortBuilder class.
		/// </summary>
		public TestSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion TestSortBuilder
	
} // end namespace
