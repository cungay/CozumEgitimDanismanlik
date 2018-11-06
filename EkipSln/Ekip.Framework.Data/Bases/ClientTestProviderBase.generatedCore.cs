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
	/// This class is the base class for any <see cref="ClientTestProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ClientTestProviderBaseCore : EntityProviderBase<Ekip.Framework.Entities.ClientTest, Ekip.Framework.Entities.ClientTestKey>
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
		public override bool Delete(TransactionManager transactionManager, Ekip.Framework.Entities.ClientTestKey key)
		{
			return Delete(transactionManager, key.ClientId, key.TestId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_clientId">. Primary Key.</param>
		/// <param name="_testId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _clientId, System.Int32 _testId)
		{
			return Delete(null, _clientId, _testId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_clientId">. Primary Key.</param>
		/// <param name="_testId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _clientId, System.Int32 _testId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClientTest_Test key.
		///		FK_ClientTest_Test Description: 
		/// </summary>
		/// <param name="_testId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ClientTest objects.</returns>
		public TList<ClientTest> GetByTestId(System.Int32 _testId)
		{
			int count = -1;
			return GetByTestId(_testId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClientTest_Test key.
		///		FK_ClientTest_Test Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_testId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ClientTest objects.</returns>
		/// <remarks></remarks>
		public TList<ClientTest> GetByTestId(TransactionManager transactionManager, System.Int32 _testId)
		{
			int count = -1;
			return GetByTestId(transactionManager, _testId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClientTest_Test key.
		///		FK_ClientTest_Test Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_testId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ClientTest objects.</returns>
		public TList<ClientTest> GetByTestId(TransactionManager transactionManager, System.Int32 _testId, int start, int pageLength)
		{
			int count = -1;
			return GetByTestId(transactionManager, _testId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClientTest_Test key.
		///		fkClientTestTest Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_testId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ClientTest objects.</returns>
		public TList<ClientTest> GetByTestId(System.Int32 _testId, int start, int pageLength)
		{
			int count =  -1;
			return GetByTestId(null, _testId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClientTest_Test key.
		///		fkClientTestTest Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_testId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ClientTest objects.</returns>
		public TList<ClientTest> GetByTestId(System.Int32 _testId, int start, int pageLength,out int count)
		{
			return GetByTestId(null, _testId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClientTest_Test key.
		///		FK_ClientTest_Test Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_testId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ClientTest objects.</returns>
		public abstract TList<ClientTest> GetByTestId(TransactionManager transactionManager, System.Int32 _testId, int start, int pageLength, out int count);
		
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
		public override Ekip.Framework.Entities.ClientTest Get(TransactionManager transactionManager, Ekip.Framework.Entities.ClientTestKey key, int start, int pageLength)
		{
			return GetByClientIdTestId(transactionManager, key.ClientId, key.TestId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Client_Test index.
		/// </summary>
		/// <param name="_clientId"></param>
		/// <param name="_testId"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ClientTest"/> class.</returns>
		public Ekip.Framework.Entities.ClientTest GetByClientIdTestId(System.Int32 _clientId, System.Int32 _testId)
		{
			int count = -1;
			return GetByClientIdTestId(null,_clientId, _testId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Client_Test index.
		/// </summary>
		/// <param name="_clientId"></param>
		/// <param name="_testId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ClientTest"/> class.</returns>
		public Ekip.Framework.Entities.ClientTest GetByClientIdTestId(System.Int32 _clientId, System.Int32 _testId, int start, int pageLength)
		{
			int count = -1;
			return GetByClientIdTestId(null, _clientId, _testId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Client_Test index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_clientId"></param>
		/// <param name="_testId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ClientTest"/> class.</returns>
		public Ekip.Framework.Entities.ClientTest GetByClientIdTestId(TransactionManager transactionManager, System.Int32 _clientId, System.Int32 _testId)
		{
			int count = -1;
			return GetByClientIdTestId(transactionManager, _clientId, _testId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Client_Test index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_clientId"></param>
		/// <param name="_testId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ClientTest"/> class.</returns>
		public Ekip.Framework.Entities.ClientTest GetByClientIdTestId(TransactionManager transactionManager, System.Int32 _clientId, System.Int32 _testId, int start, int pageLength)
		{
			int count = -1;
			return GetByClientIdTestId(transactionManager, _clientId, _testId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Client_Test index.
		/// </summary>
		/// <param name="_clientId"></param>
		/// <param name="_testId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ClientTest"/> class.</returns>
		public Ekip.Framework.Entities.ClientTest GetByClientIdTestId(System.Int32 _clientId, System.Int32 _testId, int start, int pageLength, out int count)
		{
			return GetByClientIdTestId(null, _clientId, _testId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Client_Test index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_clientId"></param>
		/// <param name="_testId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ClientTest"/> class.</returns>
		public abstract Ekip.Framework.Entities.ClientTest GetByClientIdTestId(TransactionManager transactionManager, System.Int32 _clientId, System.Int32 _testId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;ClientTest&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;ClientTest&gt;"/></returns>
		public static TList<ClientTest> Fill(IDataReader reader, TList<ClientTest> rows, int start, int pageLength)
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
				
				Ekip.Framework.Entities.ClientTest c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ClientTest")
					.Append("|").Append((System.Int32)reader[((int)ClientTestColumn.ClientId - 1)])
					.Append("|").Append((System.Int32)reader[((int)ClientTestColumn.TestId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<ClientTest>(
					key.ToString(), // EntityTrackingKey
					"ClientTest",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Ekip.Framework.Entities.ClientTest();
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
					c.ClientId = (System.Int32)reader[((int)ClientTestColumn.ClientId - 1)];
					c.OriginalClientId = c.ClientId;
					c.TestId = (System.Int32)reader[((int)ClientTestColumn.TestId - 1)];
					c.OriginalTestId = c.TestId;
					c.CreateOn = (System.DateTime)reader[((int)ClientTestColumn.CreateOn - 1)];
					c.UpdateOn = (reader.IsDBNull(((int)ClientTestColumn.UpdateOn - 1)))?null:(System.DateTime?)reader[((int)ClientTestColumn.UpdateOn - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.ClientTest"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.ClientTest"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Ekip.Framework.Entities.ClientTest entity)
		{
			if (!reader.Read()) return;
			
			entity.ClientId = (System.Int32)reader[((int)ClientTestColumn.ClientId - 1)];
			entity.OriginalClientId = (System.Int32)reader["ClientID"];
			entity.TestId = (System.Int32)reader[((int)ClientTestColumn.TestId - 1)];
			entity.OriginalTestId = (System.Int32)reader["TestID"];
			entity.CreateOn = (System.DateTime)reader[((int)ClientTestColumn.CreateOn - 1)];
			entity.UpdateOn = (reader.IsDBNull(((int)ClientTestColumn.UpdateOn - 1)))?null:(System.DateTime?)reader[((int)ClientTestColumn.UpdateOn - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.ClientTest"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.ClientTest"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Ekip.Framework.Entities.ClientTest entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ClientId = (System.Int32)dataRow["ClientID"];
			entity.OriginalClientId = (System.Int32)dataRow["ClientID"];
			entity.TestId = (System.Int32)dataRow["TestID"];
			entity.OriginalTestId = (System.Int32)dataRow["TestID"];
			entity.CreateOn = (System.DateTime)dataRow["CreateOn"];
			entity.UpdateOn = Convert.IsDBNull(dataRow["UpdateOn"]) ? null : (System.DateTime?)dataRow["UpdateOn"];
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
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.ClientTest"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.ClientTest Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Ekip.Framework.Entities.ClientTest entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

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
		/// Deep Save the entire object graph of the Ekip.Framework.Entities.ClientTest object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Ekip.Framework.Entities.ClientTest instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.ClientTest Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Ekip.Framework.Entities.ClientTest entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
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
	
	#region ClientTestChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Ekip.Framework.Entities.ClientTest</c>
	///</summary>
	public enum ClientTestChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Test</c> at TestIdSource
		///</summary>
		[ChildEntityType(typeof(Test))]
		Test,
		}
	
	#endregion ClientTestChildEntityTypes
	
	#region ClientTestFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ClientTestColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClientTest"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClientTestFilterBuilder : SqlFilterBuilder<ClientTestColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClientTestFilterBuilder class.
		/// </summary>
		public ClientTestFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ClientTestFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ClientTestFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ClientTestFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ClientTestFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ClientTestFilterBuilder
	
	#region ClientTestParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ClientTestColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClientTest"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClientTestParameterBuilder : ParameterizedSqlFilterBuilder<ClientTestColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClientTestParameterBuilder class.
		/// </summary>
		public ClientTestParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ClientTestParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ClientTestParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ClientTestParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ClientTestParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ClientTestParameterBuilder
	
	#region ClientTestSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ClientTestColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClientTest"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ClientTestSortBuilder : SqlSortBuilder<ClientTestColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClientTestSqlSortBuilder class.
		/// </summary>
		public ClientTestSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ClientTestSortBuilder
	
} // end namespace
