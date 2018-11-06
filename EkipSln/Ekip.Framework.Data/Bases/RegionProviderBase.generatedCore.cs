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
	/// This class is the base class for any <see cref="RegionProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class RegionProviderBaseCore : EntityProviderBase<Ekip.Framework.Entities.Region, Ekip.Framework.Entities.RegionKey>
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
		public override bool Delete(TransactionManager transactionManager, Ekip.Framework.Entities.RegionKey key)
		{
			return Delete(transactionManager, key.RegionId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_regionId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _regionId)
		{
			return Delete(null, _regionId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_regionId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _regionId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Region_District key.
		///		FK_Region_District Description: 
		/// </summary>
		/// <param name="_districtId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Region objects.</returns>
		public TList<Region> GetByDistrictId(System.Int32 _districtId)
		{
			int count = -1;
			return GetByDistrictId(_districtId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Region_District key.
		///		FK_Region_District Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_districtId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Region objects.</returns>
		/// <remarks></remarks>
		public TList<Region> GetByDistrictId(TransactionManager transactionManager, System.Int32 _districtId)
		{
			int count = -1;
			return GetByDistrictId(transactionManager, _districtId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Region_District key.
		///		FK_Region_District Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_districtId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Region objects.</returns>
		public TList<Region> GetByDistrictId(TransactionManager transactionManager, System.Int32 _districtId, int start, int pageLength)
		{
			int count = -1;
			return GetByDistrictId(transactionManager, _districtId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Region_District key.
		///		fkRegionDistrict Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_districtId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Region objects.</returns>
		public TList<Region> GetByDistrictId(System.Int32 _districtId, int start, int pageLength)
		{
			int count =  -1;
			return GetByDistrictId(null, _districtId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Region_District key.
		///		fkRegionDistrict Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_districtId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Region objects.</returns>
		public TList<Region> GetByDistrictId(System.Int32 _districtId, int start, int pageLength,out int count)
		{
			return GetByDistrictId(null, _districtId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Region_District key.
		///		FK_Region_District Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_districtId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Region objects.</returns>
		public abstract TList<Region> GetByDistrictId(TransactionManager transactionManager, System.Int32 _districtId, int start, int pageLength, out int count);
		
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
		public override Ekip.Framework.Entities.Region Get(TransactionManager transactionManager, Ekip.Framework.Entities.RegionKey key, int start, int pageLength)
		{
			return GetByRegionId(transactionManager, key.RegionId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Region index.
		/// </summary>
		/// <param name="_regionId"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Region"/> class.</returns>
		public Ekip.Framework.Entities.Region GetByRegionId(System.Int32 _regionId)
		{
			int count = -1;
			return GetByRegionId(null,_regionId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Region index.
		/// </summary>
		/// <param name="_regionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Region"/> class.</returns>
		public Ekip.Framework.Entities.Region GetByRegionId(System.Int32 _regionId, int start, int pageLength)
		{
			int count = -1;
			return GetByRegionId(null, _regionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Region index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_regionId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Region"/> class.</returns>
		public Ekip.Framework.Entities.Region GetByRegionId(TransactionManager transactionManager, System.Int32 _regionId)
		{
			int count = -1;
			return GetByRegionId(transactionManager, _regionId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Region index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_regionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Region"/> class.</returns>
		public Ekip.Framework.Entities.Region GetByRegionId(TransactionManager transactionManager, System.Int32 _regionId, int start, int pageLength)
		{
			int count = -1;
			return GetByRegionId(transactionManager, _regionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Region index.
		/// </summary>
		/// <param name="_regionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Region"/> class.</returns>
		public Ekip.Framework.Entities.Region GetByRegionId(System.Int32 _regionId, int start, int pageLength, out int count)
		{
			return GetByRegionId(null, _regionId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Region index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_regionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Region"/> class.</returns>
		public abstract Ekip.Framework.Entities.Region GetByRegionId(TransactionManager transactionManager, System.Int32 _regionId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Region&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Region&gt;"/></returns>
		public static TList<Region> Fill(IDataReader reader, TList<Region> rows, int start, int pageLength)
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
				
				Ekip.Framework.Entities.Region c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Region")
					.Append("|").Append((System.Int32)reader[((int)RegionColumn.RegionId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Region>(
					key.ToString(), // EntityTrackingKey
					"Region",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Ekip.Framework.Entities.Region();
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
					c.RegionId = (System.Int32)reader[((int)RegionColumn.RegionId - 1)];
					c.DistrictId = (System.Int32)reader[((int)RegionColumn.DistrictId - 1)];
					c.Region = (System.String)reader[((int)RegionColumn.Region - 1)];
					c.RowNumber = (System.Int32)reader[((int)RegionColumn.RowNumber - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.Region"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Region"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Ekip.Framework.Entities.Region entity)
		{
			if (!reader.Read()) return;
			
			entity.RegionId = (System.Int32)reader[((int)RegionColumn.RegionId - 1)];
			entity.DistrictId = (System.Int32)reader[((int)RegionColumn.DistrictId - 1)];
			entity.Region = (System.String)reader[((int)RegionColumn.Region - 1)];
			entity.RowNumber = (System.Int32)reader[((int)RegionColumn.RowNumber - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.Region"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Region"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Ekip.Framework.Entities.Region entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.RegionId = (System.Int32)dataRow["RegionId"];
			entity.DistrictId = (System.Int32)dataRow["DistrictId"];
			entity.Region = (System.String)dataRow["Region"];
			entity.RowNumber = (System.Int32)dataRow["RowNumber"];
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
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Region"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.Region Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Ekip.Framework.Entities.Region entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region DistrictIdSource	
			if (CanDeepLoad(entity, "District|DistrictIdSource", deepLoadType, innerList) 
				&& entity.DistrictIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.DistrictId;
				District tmpEntity = EntityManager.LocateEntity<District>(EntityLocator.ConstructKeyFromPkItems(typeof(District), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.DistrictIdSource = tmpEntity;
				else
					entity.DistrictIdSource = DataRepository.DistrictProvider.GetByDistrictId(transactionManager, entity.DistrictId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DistrictIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.DistrictIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.DistrictProvider.DeepLoad(transactionManager, entity.DistrictIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion DistrictIdSource
			
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
		/// Deep Save the entire object graph of the Ekip.Framework.Entities.Region object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Ekip.Framework.Entities.Region instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.Region Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Ekip.Framework.Entities.Region entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region DistrictIdSource
			if (CanDeepSave(entity, "District|DistrictIdSource", deepSaveType, innerList) 
				&& entity.DistrictIdSource != null)
			{
				DataRepository.DistrictProvider.Save(transactionManager, entity.DistrictIdSource);
				entity.DistrictId = entity.DistrictIdSource.DistrictId;
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
	
	#region RegionChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Ekip.Framework.Entities.Region</c>
	///</summary>
	public enum RegionChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>District</c> at DistrictIdSource
		///</summary>
		[ChildEntityType(typeof(District))]
		District,
		}
	
	#endregion RegionChildEntityTypes
	
	#region RegionFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;RegionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Region"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RegionFilterBuilder : SqlFilterBuilder<RegionColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RegionFilterBuilder class.
		/// </summary>
		public RegionFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the RegionFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RegionFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RegionFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RegionFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RegionFilterBuilder
	
	#region RegionParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;RegionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Region"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RegionParameterBuilder : ParameterizedSqlFilterBuilder<RegionColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RegionParameterBuilder class.
		/// </summary>
		public RegionParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the RegionParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RegionParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RegionParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RegionParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RegionParameterBuilder
	
	#region RegionSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;RegionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Region"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class RegionSortBuilder : SqlSortBuilder<RegionColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RegionSqlSortBuilder class.
		/// </summary>
		public RegionSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion RegionSortBuilder
	
} // end namespace
