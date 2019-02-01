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
	/// This class is the base class for any <see cref="CalendarAgeProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CalendarAgeProviderBaseCore : EntityProviderBase<Ekip.Framework.Entities.CalendarAge, Ekip.Framework.Entities.CalendarAgeKey>
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
		public override bool Delete(TransactionManager transactionManager, Ekip.Framework.Entities.CalendarAgeKey key)
		{
			return Delete(transactionManager, key.CalendarAgeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_calendarAgeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _calendarAgeId)
		{
			return Delete(null, _calendarAgeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_calendarAgeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _calendarAgeId);		
		
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
		public override Ekip.Framework.Entities.CalendarAge Get(TransactionManager transactionManager, Ekip.Framework.Entities.CalendarAgeKey key, int start, int pageLength)
		{
			return GetByCalendarAgeId(transactionManager, key.CalendarAgeId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_CalendarAge index.
		/// </summary>
		/// <param name="_calendarAgeId"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.CalendarAge"/> class.</returns>
		public Ekip.Framework.Entities.CalendarAge GetByCalendarAgeId(System.Int32 _calendarAgeId)
		{
			int count = -1;
			return GetByCalendarAgeId(null,_calendarAgeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CalendarAge index.
		/// </summary>
		/// <param name="_calendarAgeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.CalendarAge"/> class.</returns>
		public Ekip.Framework.Entities.CalendarAge GetByCalendarAgeId(System.Int32 _calendarAgeId, int start, int pageLength)
		{
			int count = -1;
			return GetByCalendarAgeId(null, _calendarAgeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CalendarAge index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_calendarAgeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.CalendarAge"/> class.</returns>
		public Ekip.Framework.Entities.CalendarAge GetByCalendarAgeId(TransactionManager transactionManager, System.Int32 _calendarAgeId)
		{
			int count = -1;
			return GetByCalendarAgeId(transactionManager, _calendarAgeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CalendarAge index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_calendarAgeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.CalendarAge"/> class.</returns>
		public Ekip.Framework.Entities.CalendarAge GetByCalendarAgeId(TransactionManager transactionManager, System.Int32 _calendarAgeId, int start, int pageLength)
		{
			int count = -1;
			return GetByCalendarAgeId(transactionManager, _calendarAgeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CalendarAge index.
		/// </summary>
		/// <param name="_calendarAgeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.CalendarAge"/> class.</returns>
		public Ekip.Framework.Entities.CalendarAge GetByCalendarAgeId(System.Int32 _calendarAgeId, int start, int pageLength, out int count)
		{
			return GetByCalendarAgeId(null, _calendarAgeId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CalendarAge index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_calendarAgeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.CalendarAge"/> class.</returns>
		public abstract Ekip.Framework.Entities.CalendarAge GetByCalendarAgeId(TransactionManager transactionManager, System.Int32 _calendarAgeId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region CalendarAge_GetByYearAndMonth 
		
		/// <summary>
		///	This method wrap the 'CalendarAge_GetByYearAndMonth' stored procedure. 
		/// </summary>
		/// <param name="year"> A <c>System.Int32?</c> instance.</param>
		/// <param name="month"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;CalendarAge&gt;"/> instance.</returns>
		public TList<CalendarAge> GetByYearAndMonth(System.Int32? year, System.Int32? month)
		{
			return GetByYearAndMonth(null, 0, int.MaxValue , year, month);
		}
		
		/// <summary>
		///	This method wrap the 'CalendarAge_GetByYearAndMonth' stored procedure. 
		/// </summary>
		/// <param name="year"> A <c>System.Int32?</c> instance.</param>
		/// <param name="month"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;CalendarAge&gt;"/> instance.</returns>
		public TList<CalendarAge> GetByYearAndMonth(int start, int pageLength, System.Int32? year, System.Int32? month)
		{
			return GetByYearAndMonth(null, start, pageLength , year, month);
		}
				
		/// <summary>
		///	This method wrap the 'CalendarAge_GetByYearAndMonth' stored procedure. 
		/// </summary>
		/// <param name="year"> A <c>System.Int32?</c> instance.</param>
		/// <param name="month"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;CalendarAge&gt;"/> instance.</returns>
		public TList<CalendarAge> GetByYearAndMonth(TransactionManager transactionManager, System.Int32? year, System.Int32? month)
		{
			return GetByYearAndMonth(transactionManager, 0, int.MaxValue , year, month);
		}
		
		/// <summary>
		///	This method wrap the 'CalendarAge_GetByYearAndMonth' stored procedure. 
		/// </summary>
		/// <param name="year"> A <c>System.Int32?</c> instance.</param>
		/// <param name="month"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;CalendarAge&gt;"/> instance.</returns>
		public abstract TList<CalendarAge> GetByYearAndMonth(TransactionManager transactionManager, int start, int pageLength , System.Int32? year, System.Int32? month);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;CalendarAge&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;CalendarAge&gt;"/></returns>
		public static TList<CalendarAge> Fill(IDataReader reader, TList<CalendarAge> rows, int start, int pageLength)
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
				
				Ekip.Framework.Entities.CalendarAge c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("CalendarAge")
					.Append("|").Append((System.Int32)reader[((int)CalendarAgeColumn.CalendarAgeId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<CalendarAge>(
					key.ToString(), // EntityTrackingKey
					"CalendarAge",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Ekip.Framework.Entities.CalendarAge();
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
					c.CalendarAgeId = (System.Int32)reader[((int)CalendarAgeColumn.CalendarAgeId - 1)];
					c.AgeDescription = (System.String)reader[((int)CalendarAgeColumn.AgeDescription - 1)];
					c.MinValue = (reader.IsDBNull(((int)CalendarAgeColumn.MinValue - 1)))?null:(System.Int32?)reader[((int)CalendarAgeColumn.MinValue - 1)];
					c.MaxValue = (reader.IsDBNull(((int)CalendarAgeColumn.MaxValue - 1)))?null:(System.Int32?)reader[((int)CalendarAgeColumn.MaxValue - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.CalendarAge"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.CalendarAge"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Ekip.Framework.Entities.CalendarAge entity)
		{
			if (!reader.Read()) return;
			
			entity.CalendarAgeId = (System.Int32)reader[((int)CalendarAgeColumn.CalendarAgeId - 1)];
			entity.AgeDescription = (System.String)reader[((int)CalendarAgeColumn.AgeDescription - 1)];
			entity.MinValue = (reader.IsDBNull(((int)CalendarAgeColumn.MinValue - 1)))?null:(System.Int32?)reader[((int)CalendarAgeColumn.MinValue - 1)];
			entity.MaxValue = (reader.IsDBNull(((int)CalendarAgeColumn.MaxValue - 1)))?null:(System.Int32?)reader[((int)CalendarAgeColumn.MaxValue - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.CalendarAge"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.CalendarAge"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Ekip.Framework.Entities.CalendarAge entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.CalendarAgeId = (System.Int32)dataRow["CalendarAgeId"];
			entity.AgeDescription = (System.String)dataRow["AgeDescription"];
			entity.MinValue = Convert.IsDBNull(dataRow["MinValue"]) ? null : (System.Int32?)dataRow["MinValue"];
			entity.MaxValue = Convert.IsDBNull(dataRow["MaxValue"]) ? null : (System.Int32?)dataRow["MaxValue"];
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
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.CalendarAge"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.CalendarAge Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Ekip.Framework.Entities.CalendarAge entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the Ekip.Framework.Entities.CalendarAge object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Ekip.Framework.Entities.CalendarAge instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.CalendarAge Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Ekip.Framework.Entities.CalendarAge entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region CalendarAgeChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Ekip.Framework.Entities.CalendarAge</c>
	///</summary>
	public enum CalendarAgeChildEntityTypes
	{
	}
	
	#endregion CalendarAgeChildEntityTypes
	
	#region CalendarAgeFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;CalendarAgeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CalendarAge"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CalendarAgeFilterBuilder : SqlFilterBuilder<CalendarAgeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CalendarAgeFilterBuilder class.
		/// </summary>
		public CalendarAgeFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CalendarAgeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CalendarAgeFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CalendarAgeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CalendarAgeFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CalendarAgeFilterBuilder
	
	#region CalendarAgeParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;CalendarAgeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CalendarAge"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CalendarAgeParameterBuilder : ParameterizedSqlFilterBuilder<CalendarAgeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CalendarAgeParameterBuilder class.
		/// </summary>
		public CalendarAgeParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CalendarAgeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CalendarAgeParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CalendarAgeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CalendarAgeParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CalendarAgeParameterBuilder
	
	#region CalendarAgeSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;CalendarAgeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CalendarAge"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class CalendarAgeSortBuilder : SqlSortBuilder<CalendarAgeColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CalendarAgeSqlSortBuilder class.
		/// </summary>
		public CalendarAgeSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion CalendarAgeSortBuilder
	
} // end namespace
