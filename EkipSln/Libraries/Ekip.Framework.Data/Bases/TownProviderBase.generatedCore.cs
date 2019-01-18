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
	/// This class is the base class for any <see cref="TownProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class TownProviderBaseCore : EntityProviderBase<Ekip.Framework.Entities.Town, Ekip.Framework.Entities.TownKey>
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
		public override bool Delete(TransactionManager transactionManager, Ekip.Framework.Entities.TownKey key)
		{
			return Delete(transactionManager, key.TownId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_townId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _townId)
		{
			return Delete(null, _townId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_townId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _townId);		
		
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
		public override Ekip.Framework.Entities.Town Get(TransactionManager transactionManager, Ekip.Framework.Entities.TownKey key, int start, int pageLength)
		{
			return GetByTownId(transactionManager, key.TownId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Town_ProvinceId index.
		/// </summary>
		/// <param name="_provinceId"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Town&gt;"/> class.</returns>
		public TList<Town> GetByProvinceId(System.Int32 _provinceId)
		{
			int count = -1;
			return GetByProvinceId(null,_provinceId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Town_ProvinceId index.
		/// </summary>
		/// <param name="_provinceId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Town&gt;"/> class.</returns>
		public TList<Town> GetByProvinceId(System.Int32 _provinceId, int start, int pageLength)
		{
			int count = -1;
			return GetByProvinceId(null, _provinceId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Town_ProvinceId index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_provinceId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Town&gt;"/> class.</returns>
		public TList<Town> GetByProvinceId(TransactionManager transactionManager, System.Int32 _provinceId)
		{
			int count = -1;
			return GetByProvinceId(transactionManager, _provinceId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Town_ProvinceId index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_provinceId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Town&gt;"/> class.</returns>
		public TList<Town> GetByProvinceId(TransactionManager transactionManager, System.Int32 _provinceId, int start, int pageLength)
		{
			int count = -1;
			return GetByProvinceId(transactionManager, _provinceId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Town_ProvinceId index.
		/// </summary>
		/// <param name="_provinceId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Town&gt;"/> class.</returns>
		public TList<Town> GetByProvinceId(System.Int32 _provinceId, int start, int pageLength, out int count)
		{
			return GetByProvinceId(null, _provinceId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Town_ProvinceId index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_provinceId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Town&gt;"/> class.</returns>
		public abstract TList<Town> GetByProvinceId(TransactionManager transactionManager, System.Int32 _provinceId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Town index.
		/// </summary>
		/// <param name="_townId"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Town"/> class.</returns>
		public Ekip.Framework.Entities.Town GetByTownId(System.Int32 _townId)
		{
			int count = -1;
			return GetByTownId(null,_townId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Town index.
		/// </summary>
		/// <param name="_townId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Town"/> class.</returns>
		public Ekip.Framework.Entities.Town GetByTownId(System.Int32 _townId, int start, int pageLength)
		{
			int count = -1;
			return GetByTownId(null, _townId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Town index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_townId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Town"/> class.</returns>
		public Ekip.Framework.Entities.Town GetByTownId(TransactionManager transactionManager, System.Int32 _townId)
		{
			int count = -1;
			return GetByTownId(transactionManager, _townId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Town index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_townId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Town"/> class.</returns>
		public Ekip.Framework.Entities.Town GetByTownId(TransactionManager transactionManager, System.Int32 _townId, int start, int pageLength)
		{
			int count = -1;
			return GetByTownId(transactionManager, _townId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Town index.
		/// </summary>
		/// <param name="_townId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Town"/> class.</returns>
		public Ekip.Framework.Entities.Town GetByTownId(System.Int32 _townId, int start, int pageLength, out int count)
		{
			return GetByTownId(null, _townId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Town index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_townId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Town"/> class.</returns>
		public abstract Ekip.Framework.Entities.Town GetByTownId(TransactionManager transactionManager, System.Int32 _townId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region Town_GetByProvinceId 
		
		/// <summary>
		///	This method wrap the 'Town_GetByProvinceId' stored procedure. 
		/// </summary>
		/// <param name="provinceId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Town&gt;"/> instance.</returns>
		public TList<Town> GetByProvinceId(System.Int32? provinceId)
		{
			return GetByProvinceId(null, 0, int.MaxValue , provinceId);
		}
		
		/// <summary>
		///	This method wrap the 'Town_GetByProvinceId' stored procedure. 
		/// </summary>
		/// <param name="provinceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Town&gt;"/> instance.</returns>
		public TList<Town> GetByProvinceId(int start, int pageLength, System.Int32? provinceId)
		{
			return GetByProvinceId(null, start, pageLength , provinceId);
		}
				
		/// <summary>
		///	This method wrap the 'Town_GetByProvinceId' stored procedure. 
		/// </summary>
		/// <param name="provinceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Town&gt;"/> instance.</returns>
		public TList<Town> GetByProvinceId(TransactionManager transactionManager, System.Int32? provinceId)
		{
			return GetByProvinceId(transactionManager, 0, int.MaxValue , provinceId);
		}
		
		/// <summary>
		///	This method wrap the 'Town_GetByProvinceId' stored procedure. 
		/// </summary>
		/// <param name="provinceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Town&gt;"/> instance.</returns>
		public abstract TList<Town> GetByProvinceId(TransactionManager transactionManager, int start, int pageLength , System.Int32? provinceId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Town&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Town&gt;"/></returns>
		public static TList<Town> Fill(IDataReader reader, TList<Town> rows, int start, int pageLength)
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
				
				Ekip.Framework.Entities.Town c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Town")
					.Append("|").Append((System.Int32)reader[((int)TownColumn.TownId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Town>(
					key.ToString(), // EntityTrackingKey
					"Town",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Ekip.Framework.Entities.Town();
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
					c.TownId = (System.Int32)reader[((int)TownColumn.TownId - 1)];
					c.RowNumber = (System.Int32)reader[((int)TownColumn.RowNumber - 1)];
					c.AdminId = (System.Int64)reader[((int)TownColumn.AdminId - 1)];
					c.ObjectId = (System.Int64)reader[((int)TownColumn.ObjectId - 1)];
					c.ParentId = (System.Int64)reader[((int)TownColumn.ParentId - 1)];
					c.ProvinceId = (System.Int32)reader[((int)TownColumn.ProvinceId - 1)];
					c.TownName = (System.String)reader[((int)TownColumn.TownName - 1)];
					c.Longitude = (System.String)reader[((int)TownColumn.Longitude - 1)];
					c.Latitude = (System.String)reader[((int)TownColumn.Latitude - 1)];
					c.Type = (System.Int32)reader[((int)TownColumn.Type - 1)];
					c.CreateDate = (System.DateTime)reader[((int)TownColumn.CreateDate - 1)];
					c.CreateTime = (System.TimeSpan)reader[((int)TownColumn.CreateTime - 1)];
					c.UpdateDate = (reader.IsDBNull(((int)TownColumn.UpdateDate - 1)))?null:(System.DateTime?)reader[((int)TownColumn.UpdateDate - 1)];
					c.UpdateTime = (reader.IsDBNull(((int)TownColumn.UpdateTime - 1)))?null:(System.TimeSpan?)reader[((int)TownColumn.UpdateTime - 1)];
					c.CreateUserId = (System.Int32)reader[((int)TownColumn.CreateUserId - 1)];
					c.UpdateUserId = (reader.IsDBNull(((int)TownColumn.UpdateUserId - 1)))?null:(System.Int32?)reader[((int)TownColumn.UpdateUserId - 1)];
					c.Active = (System.Boolean)reader[((int)TownColumn.Active - 1)];
					c.Deleted = (System.Boolean)reader[((int)TownColumn.Deleted - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.Town"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Town"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Ekip.Framework.Entities.Town entity)
		{
			if (!reader.Read()) return;
			
			entity.TownId = (System.Int32)reader[((int)TownColumn.TownId - 1)];
			entity.RowNumber = (System.Int32)reader[((int)TownColumn.RowNumber - 1)];
			entity.AdminId = (System.Int64)reader[((int)TownColumn.AdminId - 1)];
			entity.ObjectId = (System.Int64)reader[((int)TownColumn.ObjectId - 1)];
			entity.ParentId = (System.Int64)reader[((int)TownColumn.ParentId - 1)];
			entity.ProvinceId = (System.Int32)reader[((int)TownColumn.ProvinceId - 1)];
			entity.TownName = (System.String)reader[((int)TownColumn.TownName - 1)];
			entity.Longitude = (System.String)reader[((int)TownColumn.Longitude - 1)];
			entity.Latitude = (System.String)reader[((int)TownColumn.Latitude - 1)];
			entity.Type = (System.Int32)reader[((int)TownColumn.Type - 1)];
			entity.CreateDate = (System.DateTime)reader[((int)TownColumn.CreateDate - 1)];
			entity.CreateTime = (System.TimeSpan)reader[((int)TownColumn.CreateTime - 1)];
			entity.UpdateDate = (reader.IsDBNull(((int)TownColumn.UpdateDate - 1)))?null:(System.DateTime?)reader[((int)TownColumn.UpdateDate - 1)];
			entity.UpdateTime = (reader.IsDBNull(((int)TownColumn.UpdateTime - 1)))?null:(System.TimeSpan?)reader[((int)TownColumn.UpdateTime - 1)];
			entity.CreateUserId = (System.Int32)reader[((int)TownColumn.CreateUserId - 1)];
			entity.UpdateUserId = (reader.IsDBNull(((int)TownColumn.UpdateUserId - 1)))?null:(System.Int32?)reader[((int)TownColumn.UpdateUserId - 1)];
			entity.Active = (System.Boolean)reader[((int)TownColumn.Active - 1)];
			entity.Deleted = (System.Boolean)reader[((int)TownColumn.Deleted - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.Town"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Town"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Ekip.Framework.Entities.Town entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.TownId = (System.Int32)dataRow["TownId"];
			entity.RowNumber = (System.Int32)dataRow["RowNumber"];
			entity.AdminId = (System.Int64)dataRow["AdminId"];
			entity.ObjectId = (System.Int64)dataRow["ObjectId"];
			entity.ParentId = (System.Int64)dataRow["ParentId"];
			entity.ProvinceId = (System.Int32)dataRow["ProvinceId"];
			entity.TownName = (System.String)dataRow["TownName"];
			entity.Longitude = (System.String)dataRow["Longitude"];
			entity.Latitude = (System.String)dataRow["Latitude"];
			entity.Type = (System.Int32)dataRow["Type"];
			entity.CreateDate = (System.DateTime)dataRow["CreateDate"];
			entity.CreateTime = (System.TimeSpan)dataRow["CreateTime"];
			entity.UpdateDate = Convert.IsDBNull(dataRow["UpdateDate"]) ? null : (System.DateTime?)dataRow["UpdateDate"];
			entity.UpdateTime = Convert.IsDBNull(dataRow["UpdateTime"]) ? null : (System.TimeSpan?)dataRow["UpdateTime"];
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
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Town"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.Town Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Ekip.Framework.Entities.Town entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region ProvinceIdSource	
			if (CanDeepLoad(entity, "Province|ProvinceIdSource", deepLoadType, innerList) 
				&& entity.ProvinceIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ProvinceId;
				Province tmpEntity = EntityManager.LocateEntity<Province>(EntityLocator.ConstructKeyFromPkItems(typeof(Province), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ProvinceIdSource = tmpEntity;
				else
					entity.ProvinceIdSource = DataRepository.ProvinceProvider.GetByProvinceId(transactionManager, entity.ProvinceId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProvinceIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ProvinceIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ProvinceProvider.DeepLoad(transactionManager, entity.ProvinceIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ProvinceIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByTownId methods when available
			
			#region NeighborhoodCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Neighborhood>|NeighborhoodCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'NeighborhoodCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.NeighborhoodCollection = DataRepository.NeighborhoodProvider.GetByTownId(transactionManager, entity.TownId);

				if (deep && entity.NeighborhoodCollection.Count > 0)
				{
					deepHandles.Add("NeighborhoodCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Neighborhood>) DataRepository.NeighborhoodProvider.DeepLoad,
						new object[] { transactionManager, entity.NeighborhoodCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Ekip.Framework.Entities.Town object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Ekip.Framework.Entities.Town instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.Town Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Ekip.Framework.Entities.Town entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region ProvinceIdSource
			if (CanDeepSave(entity, "Province|ProvinceIdSource", deepSaveType, innerList) 
				&& entity.ProvinceIdSource != null)
			{
				DataRepository.ProvinceProvider.Save(transactionManager, entity.ProvinceIdSource);
				entity.ProvinceId = entity.ProvinceIdSource.ProvinceId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<Neighborhood>
				if (CanDeepSave(entity.NeighborhoodCollection, "List<Neighborhood>|NeighborhoodCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Neighborhood child in entity.NeighborhoodCollection)
					{
						if(child.TownIdSource != null)
						{
							child.TownId = child.TownIdSource.TownId;
						}
						else
						{
							child.TownId = entity.TownId;
						}

					}

					if (entity.NeighborhoodCollection.Count > 0 || entity.NeighborhoodCollection.DeletedItems.Count > 0)
					{
						//DataRepository.NeighborhoodProvider.Save(transactionManager, entity.NeighborhoodCollection);
						
						deepHandles.Add("NeighborhoodCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Neighborhood >) DataRepository.NeighborhoodProvider.DeepSave,
							new object[] { transactionManager, entity.NeighborhoodCollection, deepSaveType, childTypes, innerList }
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
	
	#region TownChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Ekip.Framework.Entities.Town</c>
	///</summary>
	public enum TownChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Province</c> at ProvinceIdSource
		///</summary>
		[ChildEntityType(typeof(Province))]
		Province,
	
		///<summary>
		/// Collection of <c>Town</c> as OneToMany for NeighborhoodCollection
		///</summary>
		[ChildEntityType(typeof(TList<Neighborhood>))]
		NeighborhoodCollection,
	}
	
	#endregion TownChildEntityTypes
	
	#region TownFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;TownColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Town"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TownFilterBuilder : SqlFilterBuilder<TownColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TownFilterBuilder class.
		/// </summary>
		public TownFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TownFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TownFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TownFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TownFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TownFilterBuilder
	
	#region TownParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;TownColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Town"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TownParameterBuilder : ParameterizedSqlFilterBuilder<TownColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TownParameterBuilder class.
		/// </summary>
		public TownParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TownParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TownParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TownParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TownParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TownParameterBuilder
	
	#region TownSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;TownColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Town"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class TownSortBuilder : SqlSortBuilder<TownColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TownSqlSortBuilder class.
		/// </summary>
		public TownSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion TownSortBuilder
	
} // end namespace
