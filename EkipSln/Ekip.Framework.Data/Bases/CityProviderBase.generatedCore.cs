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
	/// This class is the base class for any <see cref="CityProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CityProviderBaseCore : EntityProviderBase<Ekip.Framework.Entities.City, Ekip.Framework.Entities.CityKey>
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
		public override bool Delete(TransactionManager transactionManager, Ekip.Framework.Entities.CityKey key)
		{
			return Delete(transactionManager, key.CityId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_cityId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _cityId)
		{
			return Delete(null, _cityId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_cityId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _cityId);		
		
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
		public override Ekip.Framework.Entities.City Get(TransactionManager transactionManager, Ekip.Framework.Entities.CityKey key, int start, int pageLength)
		{
			return GetByCityId(transactionManager, key.CityId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_City index.
		/// </summary>
		/// <param name="_cityId"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.City"/> class.</returns>
		public Ekip.Framework.Entities.City GetByCityId(System.Int32 _cityId)
		{
			int count = -1;
			return GetByCityId(null,_cityId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_City index.
		/// </summary>
		/// <param name="_cityId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.City"/> class.</returns>
		public Ekip.Framework.Entities.City GetByCityId(System.Int32 _cityId, int start, int pageLength)
		{
			int count = -1;
			return GetByCityId(null, _cityId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_City index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_cityId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.City"/> class.</returns>
		public Ekip.Framework.Entities.City GetByCityId(TransactionManager transactionManager, System.Int32 _cityId)
		{
			int count = -1;
			return GetByCityId(transactionManager, _cityId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_City index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_cityId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.City"/> class.</returns>
		public Ekip.Framework.Entities.City GetByCityId(TransactionManager transactionManager, System.Int32 _cityId, int start, int pageLength)
		{
			int count = -1;
			return GetByCityId(transactionManager, _cityId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_City index.
		/// </summary>
		/// <param name="_cityId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.City"/> class.</returns>
		public Ekip.Framework.Entities.City GetByCityId(System.Int32 _cityId, int start, int pageLength, out int count)
		{
			return GetByCityId(null, _cityId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_City index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_cityId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.City"/> class.</returns>
		public abstract Ekip.Framework.Entities.City GetByCityId(TransactionManager transactionManager, System.Int32 _cityId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;City&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;City&gt;"/></returns>
		public static TList<City> Fill(IDataReader reader, TList<City> rows, int start, int pageLength)
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
				
				Ekip.Framework.Entities.City c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("City")
					.Append("|").Append((System.Int32)reader[((int)CityColumn.CityId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<City>(
					key.ToString(), // EntityTrackingKey
					"City",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Ekip.Framework.Entities.City();
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
					c.CityId = (System.Int32)reader[((int)CityColumn.CityId - 1)];
					c.CityName = (System.String)reader[((int)CityColumn.CityName - 1)];
					c.RowNumber = (reader.IsDBNull(((int)CityColumn.RowNumber - 1)))?null:(System.Int32?)reader[((int)CityColumn.RowNumber - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.City"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.City"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Ekip.Framework.Entities.City entity)
		{
			if (!reader.Read()) return;
			
			entity.CityId = (System.Int32)reader[((int)CityColumn.CityId - 1)];
			entity.CityName = (System.String)reader[((int)CityColumn.CityName - 1)];
			entity.RowNumber = (reader.IsDBNull(((int)CityColumn.RowNumber - 1)))?null:(System.Int32?)reader[((int)CityColumn.RowNumber - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.City"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.City"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Ekip.Framework.Entities.City entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.CityId = (System.Int32)dataRow["CityId"];
			entity.CityName = (System.String)dataRow["CityName"];
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
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.City"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.City Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Ekip.Framework.Entities.City entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByCityId methods when available
			
			#region DistrictCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<District>|DistrictCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DistrictCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.DistrictCollection = DataRepository.DistrictProvider.GetByCityId(transactionManager, entity.CityId);

				if (deep && entity.DistrictCollection.Count > 0)
				{
					deepHandles.Add("DistrictCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<District>) DataRepository.DistrictProvider.DeepLoad,
						new object[] { transactionManager, entity.DistrictCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Ekip.Framework.Entities.City object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Ekip.Framework.Entities.City instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.City Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Ekip.Framework.Entities.City entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<District>
				if (CanDeepSave(entity.DistrictCollection, "List<District>|DistrictCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(District child in entity.DistrictCollection)
					{
						if(child.CityIdSource != null)
						{
							child.CityId = child.CityIdSource.CityId;
						}
						else
						{
							child.CityId = entity.CityId;
						}

					}

					if (entity.DistrictCollection.Count > 0 || entity.DistrictCollection.DeletedItems.Count > 0)
					{
						//DataRepository.DistrictProvider.Save(transactionManager, entity.DistrictCollection);
						
						deepHandles.Add("DistrictCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< District >) DataRepository.DistrictProvider.DeepSave,
							new object[] { transactionManager, entity.DistrictCollection, deepSaveType, childTypes, innerList }
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
	
	#region CityChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Ekip.Framework.Entities.City</c>
	///</summary>
	public enum CityChildEntityTypes
	{

		///<summary>
		/// Collection of <c>City</c> as OneToMany for DistrictCollection
		///</summary>
		[ChildEntityType(typeof(TList<District>))]
		DistrictCollection,
	}
	
	#endregion CityChildEntityTypes
	
	#region CityFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;CityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="City"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CityFilterBuilder : SqlFilterBuilder<CityColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CityFilterBuilder class.
		/// </summary>
		public CityFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CityFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CityFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CityFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CityFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CityFilterBuilder
	
	#region CityParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;CityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="City"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CityParameterBuilder : ParameterizedSqlFilterBuilder<CityColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CityParameterBuilder class.
		/// </summary>
		public CityParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CityParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CityParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CityParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CityParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CityParameterBuilder
	
	#region CitySortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;CityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="City"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class CitySortBuilder : SqlSortBuilder<CityColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CitySqlSortBuilder class.
		/// </summary>
		public CitySortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion CitySortBuilder
	
} // end namespace
