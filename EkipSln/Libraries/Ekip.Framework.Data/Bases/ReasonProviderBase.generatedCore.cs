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
	/// This class is the base class for any <see cref="ReasonProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ReasonProviderBaseCore : EntityProviderBase<Ekip.Framework.Entities.Reason, Ekip.Framework.Entities.ReasonKey>
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
		public override bool Delete(TransactionManager transactionManager, Ekip.Framework.Entities.ReasonKey key)
		{
			return Delete(transactionManager, key.ReasonId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_reasonId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _reasonId)
		{
			return Delete(null, _reasonId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_reasonId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _reasonId);		
		
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
		public override Ekip.Framework.Entities.Reason Get(TransactionManager transactionManager, Ekip.Framework.Entities.ReasonKey key, int start, int pageLength)
		{
			return GetByReasonId(transactionManager, key.ReasonId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Reason index.
		/// </summary>
		/// <param name="_reasonKey"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Reason"/> class.</returns>
		public Ekip.Framework.Entities.Reason GetByReasonKey(System.Int32? _reasonKey)
		{
			int count = -1;
			return GetByReasonKey(null,_reasonKey, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Reason index.
		/// </summary>
		/// <param name="_reasonKey"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Reason"/> class.</returns>
		public Ekip.Framework.Entities.Reason GetByReasonKey(System.Int32? _reasonKey, int start, int pageLength)
		{
			int count = -1;
			return GetByReasonKey(null, _reasonKey, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Reason index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_reasonKey"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Reason"/> class.</returns>
		public Ekip.Framework.Entities.Reason GetByReasonKey(TransactionManager transactionManager, System.Int32? _reasonKey)
		{
			int count = -1;
			return GetByReasonKey(transactionManager, _reasonKey, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Reason index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_reasonKey"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Reason"/> class.</returns>
		public Ekip.Framework.Entities.Reason GetByReasonKey(TransactionManager transactionManager, System.Int32? _reasonKey, int start, int pageLength)
		{
			int count = -1;
			return GetByReasonKey(transactionManager, _reasonKey, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Reason index.
		/// </summary>
		/// <param name="_reasonKey"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Reason"/> class.</returns>
		public Ekip.Framework.Entities.Reason GetByReasonKey(System.Int32? _reasonKey, int start, int pageLength, out int count)
		{
			return GetByReasonKey(null, _reasonKey, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Reason index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_reasonKey"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Reason"/> class.</returns>
		public abstract Ekip.Framework.Entities.Reason GetByReasonKey(TransactionManager transactionManager, System.Int32? _reasonKey, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Reason_1 index.
		/// </summary>
		/// <param name="_reasonId"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Reason"/> class.</returns>
		public Ekip.Framework.Entities.Reason GetByReasonId(System.Int32 _reasonId)
		{
			int count = -1;
			return GetByReasonId(null,_reasonId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Reason_1 index.
		/// </summary>
		/// <param name="_reasonId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Reason"/> class.</returns>
		public Ekip.Framework.Entities.Reason GetByReasonId(System.Int32 _reasonId, int start, int pageLength)
		{
			int count = -1;
			return GetByReasonId(null, _reasonId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Reason_1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_reasonId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Reason"/> class.</returns>
		public Ekip.Framework.Entities.Reason GetByReasonId(TransactionManager transactionManager, System.Int32 _reasonId)
		{
			int count = -1;
			return GetByReasonId(transactionManager, _reasonId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Reason_1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_reasonId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Reason"/> class.</returns>
		public Ekip.Framework.Entities.Reason GetByReasonId(TransactionManager transactionManager, System.Int32 _reasonId, int start, int pageLength)
		{
			int count = -1;
			return GetByReasonId(transactionManager, _reasonId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Reason_1 index.
		/// </summary>
		/// <param name="_reasonId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Reason"/> class.</returns>
		public Ekip.Framework.Entities.Reason GetByReasonId(System.Int32 _reasonId, int start, int pageLength, out int count)
		{
			return GetByReasonId(null, _reasonId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Reason_1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_reasonId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Reason"/> class.</returns>
		public abstract Ekip.Framework.Entities.Reason GetByReasonId(TransactionManager transactionManager, System.Int32 _reasonId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Reason&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Reason&gt;"/></returns>
		public static TList<Reason> Fill(IDataReader reader, TList<Reason> rows, int start, int pageLength)
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
				
				Ekip.Framework.Entities.Reason c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Reason")
					.Append("|").Append((System.Int32)reader[((int)ReasonColumn.ReasonId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Reason>(
					key.ToString(), // EntityTrackingKey
					"Reason",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Ekip.Framework.Entities.Reason();
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
					c.ReasonId = (System.Int32)reader[((int)ReasonColumn.ReasonId - 1)];
					c.ReasonKey = (reader.IsDBNull(((int)ReasonColumn.ReasonKey - 1)))?null:(System.Int32?)reader[((int)ReasonColumn.ReasonKey - 1)];
					c.ReasonValue = (System.String)reader[((int)ReasonColumn.ReasonValue - 1)];
					c.CreateDate = (System.DateTime)reader[((int)ReasonColumn.CreateDate - 1)];
					c.UpdateDate = (reader.IsDBNull(((int)ReasonColumn.UpdateDate - 1)))?null:(System.DateTime?)reader[((int)ReasonColumn.UpdateDate - 1)];
					c.CreateUserId = (System.Int32)reader[((int)ReasonColumn.CreateUserId - 1)];
					c.UpdateUserId = (reader.IsDBNull(((int)ReasonColumn.UpdateUserId - 1)))?null:(System.Int32?)reader[((int)ReasonColumn.UpdateUserId - 1)];
					c.Active = (System.Boolean)reader[((int)ReasonColumn.Active - 1)];
					c.Deleted = (System.Boolean)reader[((int)ReasonColumn.Deleted - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.Reason"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Reason"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Ekip.Framework.Entities.Reason entity)
		{
			if (!reader.Read()) return;
			
			entity.ReasonId = (System.Int32)reader[((int)ReasonColumn.ReasonId - 1)];
			entity.ReasonKey = (reader.IsDBNull(((int)ReasonColumn.ReasonKey - 1)))?null:(System.Int32?)reader[((int)ReasonColumn.ReasonKey - 1)];
			entity.ReasonValue = (System.String)reader[((int)ReasonColumn.ReasonValue - 1)];
			entity.CreateDate = (System.DateTime)reader[((int)ReasonColumn.CreateDate - 1)];
			entity.UpdateDate = (reader.IsDBNull(((int)ReasonColumn.UpdateDate - 1)))?null:(System.DateTime?)reader[((int)ReasonColumn.UpdateDate - 1)];
			entity.CreateUserId = (System.Int32)reader[((int)ReasonColumn.CreateUserId - 1)];
			entity.UpdateUserId = (reader.IsDBNull(((int)ReasonColumn.UpdateUserId - 1)))?null:(System.Int32?)reader[((int)ReasonColumn.UpdateUserId - 1)];
			entity.Active = (System.Boolean)reader[((int)ReasonColumn.Active - 1)];
			entity.Deleted = (System.Boolean)reader[((int)ReasonColumn.Deleted - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.Reason"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Reason"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Ekip.Framework.Entities.Reason entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ReasonId = (System.Int32)dataRow["ReasonId"];
			entity.ReasonKey = Convert.IsDBNull(dataRow["ReasonKey"]) ? null : (System.Int32?)dataRow["ReasonKey"];
			entity.ReasonValue = (System.String)dataRow["ReasonValue"];
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
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Reason"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.Reason Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Ekip.Framework.Entities.Reason entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByReasonId methods when available
			
			#region SeanceReasonCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SeanceReason>|SeanceReasonCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SeanceReasonCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SeanceReasonCollection = DataRepository.SeanceReasonProvider.GetByReasonId(transactionManager, entity.ReasonId);

				if (deep && entity.SeanceReasonCollection.Count > 0)
				{
					deepHandles.Add("SeanceReasonCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SeanceReason>) DataRepository.SeanceReasonProvider.DeepLoad,
						new object[] { transactionManager, entity.SeanceReasonCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Ekip.Framework.Entities.Reason object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Ekip.Framework.Entities.Reason instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.Reason Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Ekip.Framework.Entities.Reason entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<SeanceReason>
				if (CanDeepSave(entity.SeanceReasonCollection, "List<SeanceReason>|SeanceReasonCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SeanceReason child in entity.SeanceReasonCollection)
					{
						if(child.ReasonIdSource != null)
						{
							child.ReasonId = child.ReasonIdSource.ReasonId;
						}
						else
						{
							child.ReasonId = entity.ReasonId;
						}

					}

					if (entity.SeanceReasonCollection.Count > 0 || entity.SeanceReasonCollection.DeletedItems.Count > 0)
					{
						//DataRepository.SeanceReasonProvider.Save(transactionManager, entity.SeanceReasonCollection);
						
						deepHandles.Add("SeanceReasonCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SeanceReason >) DataRepository.SeanceReasonProvider.DeepSave,
							new object[] { transactionManager, entity.SeanceReasonCollection, deepSaveType, childTypes, innerList }
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
	
	#region ReasonChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Ekip.Framework.Entities.Reason</c>
	///</summary>
	public enum ReasonChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Reason</c> as OneToMany for SeanceReasonCollection
		///</summary>
		[ChildEntityType(typeof(TList<SeanceReason>))]
		SeanceReasonCollection,
	}
	
	#endregion ReasonChildEntityTypes
	
	#region ReasonFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ReasonColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Reason"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ReasonFilterBuilder : SqlFilterBuilder<ReasonColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ReasonFilterBuilder class.
		/// </summary>
		public ReasonFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ReasonFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ReasonFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ReasonFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ReasonFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ReasonFilterBuilder
	
	#region ReasonParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ReasonColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Reason"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ReasonParameterBuilder : ParameterizedSqlFilterBuilder<ReasonColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ReasonParameterBuilder class.
		/// </summary>
		public ReasonParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ReasonParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ReasonParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ReasonParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ReasonParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ReasonParameterBuilder
	
	#region ReasonSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ReasonColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Reason"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ReasonSortBuilder : SqlSortBuilder<ReasonColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ReasonSqlSortBuilder class.
		/// </summary>
		public ReasonSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ReasonSortBuilder
	
} // end namespace
