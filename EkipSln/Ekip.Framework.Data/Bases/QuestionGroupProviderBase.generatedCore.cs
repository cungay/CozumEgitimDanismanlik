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
	/// This class is the base class for any <see cref="QuestionGroupProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class QuestionGroupProviderBaseCore : EntityProviderBase<Ekip.Framework.Entities.QuestionGroup, Ekip.Framework.Entities.QuestionGroupKey>
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
		public override bool Delete(TransactionManager transactionManager, Ekip.Framework.Entities.QuestionGroupKey key)
		{
			return Delete(transactionManager, key.GroupId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_groupId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _groupId)
		{
			return Delete(null, _groupId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_groupId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _groupId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QuestionGroup_Test key.
		///		FK_QuestionGroup_Test Description: 
		/// </summary>
		/// <param name="_testId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.QuestionGroup objects.</returns>
		public TList<QuestionGroup> GetByTestId(System.Int32 _testId)
		{
			int count = -1;
			return GetByTestId(_testId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QuestionGroup_Test key.
		///		FK_QuestionGroup_Test Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_testId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.QuestionGroup objects.</returns>
		/// <remarks></remarks>
		public TList<QuestionGroup> GetByTestId(TransactionManager transactionManager, System.Int32 _testId)
		{
			int count = -1;
			return GetByTestId(transactionManager, _testId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_QuestionGroup_Test key.
		///		FK_QuestionGroup_Test Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_testId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.QuestionGroup objects.</returns>
		public TList<QuestionGroup> GetByTestId(TransactionManager transactionManager, System.Int32 _testId, int start, int pageLength)
		{
			int count = -1;
			return GetByTestId(transactionManager, _testId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QuestionGroup_Test key.
		///		fkQuestionGroupTest Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_testId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.QuestionGroup objects.</returns>
		public TList<QuestionGroup> GetByTestId(System.Int32 _testId, int start, int pageLength)
		{
			int count =  -1;
			return GetByTestId(null, _testId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QuestionGroup_Test key.
		///		fkQuestionGroupTest Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_testId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.QuestionGroup objects.</returns>
		public TList<QuestionGroup> GetByTestId(System.Int32 _testId, int start, int pageLength,out int count)
		{
			return GetByTestId(null, _testId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QuestionGroup_Test key.
		///		FK_QuestionGroup_Test Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_testId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.QuestionGroup objects.</returns>
		public abstract TList<QuestionGroup> GetByTestId(TransactionManager transactionManager, System.Int32 _testId, int start, int pageLength, out int count);
		
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
		public override Ekip.Framework.Entities.QuestionGroup Get(TransactionManager transactionManager, Ekip.Framework.Entities.QuestionGroupKey key, int start, int pageLength)
		{
			return GetByGroupId(transactionManager, key.GroupId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_QuestionGroup index.
		/// </summary>
		/// <param name="_groupId"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.QuestionGroup"/> class.</returns>
		public Ekip.Framework.Entities.QuestionGroup GetByGroupId(System.Int32 _groupId)
		{
			int count = -1;
			return GetByGroupId(null,_groupId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_QuestionGroup index.
		/// </summary>
		/// <param name="_groupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.QuestionGroup"/> class.</returns>
		public Ekip.Framework.Entities.QuestionGroup GetByGroupId(System.Int32 _groupId, int start, int pageLength)
		{
			int count = -1;
			return GetByGroupId(null, _groupId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_QuestionGroup index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_groupId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.QuestionGroup"/> class.</returns>
		public Ekip.Framework.Entities.QuestionGroup GetByGroupId(TransactionManager transactionManager, System.Int32 _groupId)
		{
			int count = -1;
			return GetByGroupId(transactionManager, _groupId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_QuestionGroup index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_groupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.QuestionGroup"/> class.</returns>
		public Ekip.Framework.Entities.QuestionGroup GetByGroupId(TransactionManager transactionManager, System.Int32 _groupId, int start, int pageLength)
		{
			int count = -1;
			return GetByGroupId(transactionManager, _groupId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_QuestionGroup index.
		/// </summary>
		/// <param name="_groupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.QuestionGroup"/> class.</returns>
		public Ekip.Framework.Entities.QuestionGroup GetByGroupId(System.Int32 _groupId, int start, int pageLength, out int count)
		{
			return GetByGroupId(null, _groupId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_QuestionGroup index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_groupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.QuestionGroup"/> class.</returns>
		public abstract Ekip.Framework.Entities.QuestionGroup GetByGroupId(TransactionManager transactionManager, System.Int32 _groupId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;QuestionGroup&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;QuestionGroup&gt;"/></returns>
		public static TList<QuestionGroup> Fill(IDataReader reader, TList<QuestionGroup> rows, int start, int pageLength)
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
				
				Ekip.Framework.Entities.QuestionGroup c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("QuestionGroup")
					.Append("|").Append((System.Int32)reader[((int)QuestionGroupColumn.GroupId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<QuestionGroup>(
					key.ToString(), // EntityTrackingKey
					"QuestionGroup",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Ekip.Framework.Entities.QuestionGroup();
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
					c.GroupId = (System.Int32)reader[((int)QuestionGroupColumn.GroupId - 1)];
					c.TestId = (System.Int32)reader[((int)QuestionGroupColumn.TestId - 1)];
					c.GroupName = (System.String)reader[((int)QuestionGroupColumn.GroupName - 1)];
					c.LineNumber = (System.Int32)reader[((int)QuestionGroupColumn.LineNumber - 1)];
					c.Status = (System.Boolean)reader[((int)QuestionGroupColumn.Status - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.QuestionGroup"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.QuestionGroup"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Ekip.Framework.Entities.QuestionGroup entity)
		{
			if (!reader.Read()) return;
			
			entity.GroupId = (System.Int32)reader[((int)QuestionGroupColumn.GroupId - 1)];
			entity.TestId = (System.Int32)reader[((int)QuestionGroupColumn.TestId - 1)];
			entity.GroupName = (System.String)reader[((int)QuestionGroupColumn.GroupName - 1)];
			entity.LineNumber = (System.Int32)reader[((int)QuestionGroupColumn.LineNumber - 1)];
			entity.Status = (System.Boolean)reader[((int)QuestionGroupColumn.Status - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.QuestionGroup"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.QuestionGroup"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Ekip.Framework.Entities.QuestionGroup entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.GroupId = (System.Int32)dataRow["GroupID"];
			entity.TestId = (System.Int32)dataRow["TestID"];
			entity.GroupName = (System.String)dataRow["GroupName"];
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
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.QuestionGroup"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.QuestionGroup Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Ekip.Framework.Entities.QuestionGroup entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
			// Deep load child collections  - Call GetByGroupId methods when available
			
			#region QuestionCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Question>|QuestionCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'QuestionCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.QuestionCollection = DataRepository.QuestionProvider.GetByGroupId(transactionManager, entity.GroupId);

				if (deep && entity.QuestionCollection.Count > 0)
				{
					deepHandles.Add("QuestionCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Question>) DataRepository.QuestionProvider.DeepLoad,
						new object[] { transactionManager, entity.QuestionCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Ekip.Framework.Entities.QuestionGroup object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Ekip.Framework.Entities.QuestionGroup instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.QuestionGroup Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Ekip.Framework.Entities.QuestionGroup entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<Question>
				if (CanDeepSave(entity.QuestionCollection, "List<Question>|QuestionCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Question child in entity.QuestionCollection)
					{
						if(child.GroupIdSource != null)
						{
							child.GroupId = child.GroupIdSource.GroupId;
						}
						else
						{
							child.GroupId = entity.GroupId;
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
	
	#region QuestionGroupChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Ekip.Framework.Entities.QuestionGroup</c>
	///</summary>
	public enum QuestionGroupChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Test</c> at TestIdSource
		///</summary>
		[ChildEntityType(typeof(Test))]
		Test,
	
		///<summary>
		/// Collection of <c>QuestionGroup</c> as OneToMany for QuestionCollection
		///</summary>
		[ChildEntityType(typeof(TList<Question>))]
		QuestionCollection,
	}
	
	#endregion QuestionGroupChildEntityTypes
	
	#region QuestionGroupFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;QuestionGroupColumn&gt;"/> class
	/// that is used exclusively with a <see cref="QuestionGroup"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuestionGroupFilterBuilder : SqlFilterBuilder<QuestionGroupColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuestionGroupFilterBuilder class.
		/// </summary>
		public QuestionGroupFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the QuestionGroupFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public QuestionGroupFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the QuestionGroupFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public QuestionGroupFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion QuestionGroupFilterBuilder
	
	#region QuestionGroupParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;QuestionGroupColumn&gt;"/> class
	/// that is used exclusively with a <see cref="QuestionGroup"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuestionGroupParameterBuilder : ParameterizedSqlFilterBuilder<QuestionGroupColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuestionGroupParameterBuilder class.
		/// </summary>
		public QuestionGroupParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the QuestionGroupParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public QuestionGroupParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the QuestionGroupParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public QuestionGroupParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion QuestionGroupParameterBuilder
	
	#region QuestionGroupSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;QuestionGroupColumn&gt;"/> class
	/// that is used exclusively with a <see cref="QuestionGroup"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class QuestionGroupSortBuilder : SqlSortBuilder<QuestionGroupColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuestionGroupSqlSortBuilder class.
		/// </summary>
		public QuestionGroupSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion QuestionGroupSortBuilder
	
} // end namespace
