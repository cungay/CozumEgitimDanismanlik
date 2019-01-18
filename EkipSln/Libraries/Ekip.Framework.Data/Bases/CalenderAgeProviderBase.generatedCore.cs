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
	/// This class is the base class for any <see cref="CalenderAgeProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CalenderAgeProviderBaseCore : EntityProviderBase<Ekip.Framework.Entities.CalenderAge, Ekip.Framework.Entities.CalenderAgeKey>
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
		public override bool Delete(TransactionManager transactionManager, Ekip.Framework.Entities.CalenderAgeKey key)
		{
			return Delete(transactionManager, key.CalenderAgeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_calenderAgeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _calenderAgeId)
		{
			return Delete(null, _calenderAgeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_calenderAgeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _calenderAgeId);		
		
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
		public override Ekip.Framework.Entities.CalenderAge Get(TransactionManager transactionManager, Ekip.Framework.Entities.CalenderAgeKey key, int start, int pageLength)
		{
			return GetByCalenderAgeId(transactionManager, key.CalenderAgeId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_CalenderAge index.
		/// </summary>
		/// <param name="_calenderAgeId"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.CalenderAge"/> class.</returns>
		public Ekip.Framework.Entities.CalenderAge GetByCalenderAgeId(System.Int32 _calenderAgeId)
		{
			int count = -1;
			return GetByCalenderAgeId(null,_calenderAgeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CalenderAge index.
		/// </summary>
		/// <param name="_calenderAgeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.CalenderAge"/> class.</returns>
		public Ekip.Framework.Entities.CalenderAge GetByCalenderAgeId(System.Int32 _calenderAgeId, int start, int pageLength)
		{
			int count = -1;
			return GetByCalenderAgeId(null, _calenderAgeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CalenderAge index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_calenderAgeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.CalenderAge"/> class.</returns>
		public Ekip.Framework.Entities.CalenderAge GetByCalenderAgeId(TransactionManager transactionManager, System.Int32 _calenderAgeId)
		{
			int count = -1;
			return GetByCalenderAgeId(transactionManager, _calenderAgeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CalenderAge index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_calenderAgeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.CalenderAge"/> class.</returns>
		public Ekip.Framework.Entities.CalenderAge GetByCalenderAgeId(TransactionManager transactionManager, System.Int32 _calenderAgeId, int start, int pageLength)
		{
			int count = -1;
			return GetByCalenderAgeId(transactionManager, _calenderAgeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CalenderAge index.
		/// </summary>
		/// <param name="_calenderAgeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.CalenderAge"/> class.</returns>
		public Ekip.Framework.Entities.CalenderAge GetByCalenderAgeId(System.Int32 _calenderAgeId, int start, int pageLength, out int count)
		{
			return GetByCalenderAgeId(null, _calenderAgeId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CalenderAge index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_calenderAgeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.CalenderAge"/> class.</returns>
		public abstract Ekip.Framework.Entities.CalenderAge GetByCalenderAgeId(TransactionManager transactionManager, System.Int32 _calenderAgeId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;CalenderAge&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;CalenderAge&gt;"/></returns>
		public static TList<CalenderAge> Fill(IDataReader reader, TList<CalenderAge> rows, int start, int pageLength)
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
				
				Ekip.Framework.Entities.CalenderAge c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("CalenderAge")
					.Append("|").Append((System.Int32)reader[((int)CalenderAgeColumn.CalenderAgeId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<CalenderAge>(
					key.ToString(), // EntityTrackingKey
					"CalenderAge",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Ekip.Framework.Entities.CalenderAge();
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
					c.CalenderAgeId = (System.Int32)reader[((int)CalenderAgeColumn.CalenderAgeId - 1)];
					c.AgeValue = (System.String)reader[((int)CalenderAgeColumn.AgeValue - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.CalenderAge"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.CalenderAge"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Ekip.Framework.Entities.CalenderAge entity)
		{
			if (!reader.Read()) return;
			
			entity.CalenderAgeId = (System.Int32)reader[((int)CalenderAgeColumn.CalenderAgeId - 1)];
			entity.AgeValue = (System.String)reader[((int)CalenderAgeColumn.AgeValue - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.CalenderAge"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.CalenderAge"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Ekip.Framework.Entities.CalenderAge entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.CalenderAgeId = (System.Int32)dataRow["CalenderAgeId"];
			entity.AgeValue = (System.String)dataRow["AgeValue"];
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
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.CalenderAge"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.CalenderAge Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Ekip.Framework.Entities.CalenderAge entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
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
		/// Deep Save the entire object graph of the Ekip.Framework.Entities.CalenderAge object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Ekip.Framework.Entities.CalenderAge instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.CalenderAge Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Ekip.Framework.Entities.CalenderAge entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region CalenderAgeChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Ekip.Framework.Entities.CalenderAge</c>
	///</summary>
	public enum CalenderAgeChildEntityTypes
	{
	}
	
	#endregion CalenderAgeChildEntityTypes
	
	#region CalenderAgeFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;CalenderAgeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CalenderAge"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CalenderAgeFilterBuilder : SqlFilterBuilder<CalenderAgeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CalenderAgeFilterBuilder class.
		/// </summary>
		public CalenderAgeFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CalenderAgeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CalenderAgeFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CalenderAgeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CalenderAgeFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CalenderAgeFilterBuilder
	
	#region CalenderAgeParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;CalenderAgeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CalenderAge"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CalenderAgeParameterBuilder : ParameterizedSqlFilterBuilder<CalenderAgeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CalenderAgeParameterBuilder class.
		/// </summary>
		public CalenderAgeParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CalenderAgeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CalenderAgeParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CalenderAgeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CalenderAgeParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CalenderAgeParameterBuilder
	
	#region CalenderAgeSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;CalenderAgeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CalenderAge"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class CalenderAgeSortBuilder : SqlSortBuilder<CalenderAgeColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CalenderAgeSqlSortBuilder class.
		/// </summary>
		public CalenderAgeSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion CalenderAgeSortBuilder
	
} // end namespace
