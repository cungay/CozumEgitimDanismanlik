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
	/// This class is the base class for any <see cref="DistrictProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class DistrictProviderBaseCore : EntityProviderBase<Ekip.Framework.Entities.District, Ekip.Framework.Entities.DistrictKey>
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
		public override bool Delete(TransactionManager transactionManager, Ekip.Framework.Entities.DistrictKey key)
		{
			return Delete(transactionManager, key.DistrictId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_districtId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _districtId)
		{
			return Delete(null, _districtId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_districtId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _districtId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_District_City key.
		///		FK_District_City Description: 
		/// </summary>
		/// <param name="_cityId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.District objects.</returns>
		public TList<District> GetByCityId(System.Int32 _cityId)
		{
			int count = -1;
			return GetByCityId(_cityId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_District_City key.
		///		FK_District_City Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_cityId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.District objects.</returns>
		/// <remarks></remarks>
		public TList<District> GetByCityId(TransactionManager transactionManager, System.Int32 _cityId)
		{
			int count = -1;
			return GetByCityId(transactionManager, _cityId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_District_City key.
		///		FK_District_City Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_cityId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.District objects.</returns>
		public TList<District> GetByCityId(TransactionManager transactionManager, System.Int32 _cityId, int start, int pageLength)
		{
			int count = -1;
			return GetByCityId(transactionManager, _cityId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_District_City key.
		///		fkDistrictCity Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_cityId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.District objects.</returns>
		public TList<District> GetByCityId(System.Int32 _cityId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCityId(null, _cityId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_District_City key.
		///		fkDistrictCity Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_cityId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.District objects.</returns>
		public TList<District> GetByCityId(System.Int32 _cityId, int start, int pageLength,out int count)
		{
			return GetByCityId(null, _cityId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_District_City key.
		///		FK_District_City Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_cityId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.District objects.</returns>
		public abstract TList<District> GetByCityId(TransactionManager transactionManager, System.Int32 _cityId, int start, int pageLength, out int count);
		
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
		public override Ekip.Framework.Entities.District Get(TransactionManager transactionManager, Ekip.Framework.Entities.DistrictKey key, int start, int pageLength)
		{
			return GetByDistrictId(transactionManager, key.DistrictId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Country index.
		/// </summary>
		/// <param name="_districtId"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.District"/> class.</returns>
		public Ekip.Framework.Entities.District GetByDistrictId(System.Int32 _districtId)
		{
			int count = -1;
			return GetByDistrictId(null,_districtId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Country index.
		/// </summary>
		/// <param name="_districtId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.District"/> class.</returns>
		public Ekip.Framework.Entities.District GetByDistrictId(System.Int32 _districtId, int start, int pageLength)
		{
			int count = -1;
			return GetByDistrictId(null, _districtId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Country index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_districtId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.District"/> class.</returns>
		public Ekip.Framework.Entities.District GetByDistrictId(TransactionManager transactionManager, System.Int32 _districtId)
		{
			int count = -1;
			return GetByDistrictId(transactionManager, _districtId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Country index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_districtId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.District"/> class.</returns>
		public Ekip.Framework.Entities.District GetByDistrictId(TransactionManager transactionManager, System.Int32 _districtId, int start, int pageLength)
		{
			int count = -1;
			return GetByDistrictId(transactionManager, _districtId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Country index.
		/// </summary>
		/// <param name="_districtId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.District"/> class.</returns>
		public Ekip.Framework.Entities.District GetByDistrictId(System.Int32 _districtId, int start, int pageLength, out int count)
		{
			return GetByDistrictId(null, _districtId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Country index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_districtId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.District"/> class.</returns>
		public abstract Ekip.Framework.Entities.District GetByDistrictId(TransactionManager transactionManager, System.Int32 _districtId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;District&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;District&gt;"/></returns>
		public static TList<District> Fill(IDataReader reader, TList<District> rows, int start, int pageLength)
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
				
				Ekip.Framework.Entities.District c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("District")
					.Append("|").Append((System.Int32)reader[((int)DistrictColumn.DistrictId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<District>(
					key.ToString(), // EntityTrackingKey
					"District",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Ekip.Framework.Entities.District();
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
					c.DistrictId = (System.Int32)reader[((int)DistrictColumn.DistrictId - 1)];
					c.CityId = (System.Int32)reader[((int)DistrictColumn.CityId - 1)];
					c.DistrictName = (System.String)reader[((int)DistrictColumn.DistrictName - 1)];
					c.RowNumber = (reader.IsDBNull(((int)DistrictColumn.RowNumber - 1)))?null:(System.Int32?)reader[((int)DistrictColumn.RowNumber - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.District"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.District"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Ekip.Framework.Entities.District entity)
		{
			if (!reader.Read()) return;
			
			entity.DistrictId = (System.Int32)reader[((int)DistrictColumn.DistrictId - 1)];
			entity.CityId = (System.Int32)reader[((int)DistrictColumn.CityId - 1)];
			entity.DistrictName = (System.String)reader[((int)DistrictColumn.DistrictName - 1)];
			entity.RowNumber = (reader.IsDBNull(((int)DistrictColumn.RowNumber - 1)))?null:(System.Int32?)reader[((int)DistrictColumn.RowNumber - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.District"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.District"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Ekip.Framework.Entities.District entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.DistrictId = (System.Int32)dataRow["DistrictId"];
			entity.CityId = (System.Int32)dataRow["CityId"];
			entity.DistrictName = (System.String)dataRow["DistrictName"];
			entity.RowNumber = Convert.IsDBNull(dataRow["RowNumber"]) ? null : (System.Int32?)dataRow["RowNumber"];
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
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.District"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.District Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Ekip.Framework.Entities.District entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region CityIdSource	
			if (CanDeepLoad(entity, "City|CityIdSource", deepLoadType, innerList) 
				&& entity.CityIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.CityId;
				City tmpEntity = EntityManager.LocateEntity<City>(EntityLocator.ConstructKeyFromPkItems(typeof(City), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CityIdSource = tmpEntity;
				else
					entity.CityIdSource = DataRepository.CityProvider.GetByCityId(transactionManager, entity.CityId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CityIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CityIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CityProvider.DeepLoad(transactionManager, entity.CityIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion CityIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByDistrictId methods when available
			
			#region RegionCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Region>|RegionCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'RegionCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.RegionCollection = DataRepository.RegionProvider.GetByDistrictId(transactionManager, entity.DistrictId);

				if (deep && entity.RegionCollection.Count > 0)
				{
					deepHandles.Add("RegionCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Region>) DataRepository.RegionProvider.DeepLoad,
						new object[] { transactionManager, entity.RegionCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Ekip.Framework.Entities.District object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Ekip.Framework.Entities.District instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.District Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Ekip.Framework.Entities.District entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region CityIdSource
			if (CanDeepSave(entity, "City|CityIdSource", deepSaveType, innerList) 
				&& entity.CityIdSource != null)
			{
				DataRepository.CityProvider.Save(transactionManager, entity.CityIdSource);
				entity.CityId = entity.CityIdSource.CityId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<Region>
				if (CanDeepSave(entity.RegionCollection, "List<Region>|RegionCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Region child in entity.RegionCollection)
					{
						if(child.DistrictIdSource != null)
						{
							child.DistrictId = child.DistrictIdSource.DistrictId;
						}
						else
						{
							child.DistrictId = entity.DistrictId;
						}

					}

					if (entity.RegionCollection.Count > 0 || entity.RegionCollection.DeletedItems.Count > 0)
					{
						//DataRepository.RegionProvider.Save(transactionManager, entity.RegionCollection);
						
						deepHandles.Add("RegionCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Region >) DataRepository.RegionProvider.DeepSave,
							new object[] { transactionManager, entity.RegionCollection, deepSaveType, childTypes, innerList }
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
	
	#region DistrictChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Ekip.Framework.Entities.District</c>
	///</summary>
	public enum DistrictChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>City</c> at CityIdSource
		///</summary>
		[ChildEntityType(typeof(City))]
		City,
	
		///<summary>
		/// Collection of <c>District</c> as OneToMany for RegionCollection
		///</summary>
		[ChildEntityType(typeof(TList<Region>))]
		RegionCollection,
	}
	
	#endregion DistrictChildEntityTypes
	
	#region DistrictFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;DistrictColumn&gt;"/> class
	/// that is used exclusively with a <see cref="District"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DistrictFilterBuilder : SqlFilterBuilder<DistrictColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DistrictFilterBuilder class.
		/// </summary>
		public DistrictFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DistrictFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DistrictFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DistrictFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DistrictFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DistrictFilterBuilder
	
	#region DistrictParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;DistrictColumn&gt;"/> class
	/// that is used exclusively with a <see cref="District"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DistrictParameterBuilder : ParameterizedSqlFilterBuilder<DistrictColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DistrictParameterBuilder class.
		/// </summary>
		public DistrictParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DistrictParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DistrictParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DistrictParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DistrictParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DistrictParameterBuilder
	
	#region DistrictSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;DistrictColumn&gt;"/> class
	/// that is used exclusively with a <see cref="District"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class DistrictSortBuilder : SqlSortBuilder<DistrictColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DistrictSqlSortBuilder class.
		/// </summary>
		public DistrictSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion DistrictSortBuilder
	
} // end namespace
