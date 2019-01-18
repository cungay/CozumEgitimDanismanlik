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
	/// This class is the base class for any <see cref="NeighborhoodProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class NeighborhoodProviderBaseCore : EntityProviderBase<Ekip.Framework.Entities.Neighborhood, Ekip.Framework.Entities.NeighborhoodKey>
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
		public override bool Delete(TransactionManager transactionManager, Ekip.Framework.Entities.NeighborhoodKey key)
		{
			return Delete(transactionManager, key.NeighborhoodId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_neighborhoodId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _neighborhoodId)
		{
			return Delete(null, _neighborhoodId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_neighborhoodId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _neighborhoodId);		
		
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
		public override Ekip.Framework.Entities.Neighborhood Get(TransactionManager transactionManager, Ekip.Framework.Entities.NeighborhoodKey key, int start, int pageLength)
		{
			return GetByNeighborhoodId(transactionManager, key.NeighborhoodId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Neighborhood index.
		/// </summary>
		/// <param name="_townId"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Neighborhood&gt;"/> class.</returns>
		public TList<Neighborhood> GetByTownId(System.Int32 _townId)
		{
			int count = -1;
			return GetByTownId(null,_townId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Neighborhood index.
		/// </summary>
		/// <param name="_townId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Neighborhood&gt;"/> class.</returns>
		public TList<Neighborhood> GetByTownId(System.Int32 _townId, int start, int pageLength)
		{
			int count = -1;
			return GetByTownId(null, _townId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Neighborhood index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_townId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Neighborhood&gt;"/> class.</returns>
		public TList<Neighborhood> GetByTownId(TransactionManager transactionManager, System.Int32 _townId)
		{
			int count = -1;
			return GetByTownId(transactionManager, _townId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Neighborhood index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_townId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Neighborhood&gt;"/> class.</returns>
		public TList<Neighborhood> GetByTownId(TransactionManager transactionManager, System.Int32 _townId, int start, int pageLength)
		{
			int count = -1;
			return GetByTownId(transactionManager, _townId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Neighborhood index.
		/// </summary>
		/// <param name="_townId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Neighborhood&gt;"/> class.</returns>
		public TList<Neighborhood> GetByTownId(System.Int32 _townId, int start, int pageLength, out int count)
		{
			return GetByTownId(null, _townId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Neighborhood index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_townId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Neighborhood&gt;"/> class.</returns>
		public abstract TList<Neighborhood> GetByTownId(TransactionManager transactionManager, System.Int32 _townId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Neighborhood index.
		/// </summary>
		/// <param name="_neighborhoodId"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Neighborhood"/> class.</returns>
		public Ekip.Framework.Entities.Neighborhood GetByNeighborhoodId(System.Int32 _neighborhoodId)
		{
			int count = -1;
			return GetByNeighborhoodId(null,_neighborhoodId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Neighborhood index.
		/// </summary>
		/// <param name="_neighborhoodId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Neighborhood"/> class.</returns>
		public Ekip.Framework.Entities.Neighborhood GetByNeighborhoodId(System.Int32 _neighborhoodId, int start, int pageLength)
		{
			int count = -1;
			return GetByNeighborhoodId(null, _neighborhoodId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Neighborhood index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_neighborhoodId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Neighborhood"/> class.</returns>
		public Ekip.Framework.Entities.Neighborhood GetByNeighborhoodId(TransactionManager transactionManager, System.Int32 _neighborhoodId)
		{
			int count = -1;
			return GetByNeighborhoodId(transactionManager, _neighborhoodId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Neighborhood index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_neighborhoodId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Neighborhood"/> class.</returns>
		public Ekip.Framework.Entities.Neighborhood GetByNeighborhoodId(TransactionManager transactionManager, System.Int32 _neighborhoodId, int start, int pageLength)
		{
			int count = -1;
			return GetByNeighborhoodId(transactionManager, _neighborhoodId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Neighborhood index.
		/// </summary>
		/// <param name="_neighborhoodId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Neighborhood"/> class.</returns>
		public Ekip.Framework.Entities.Neighborhood GetByNeighborhoodId(System.Int32 _neighborhoodId, int start, int pageLength, out int count)
		{
			return GetByNeighborhoodId(null, _neighborhoodId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Neighborhood index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_neighborhoodId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Neighborhood"/> class.</returns>
		public abstract Ekip.Framework.Entities.Neighborhood GetByNeighborhoodId(TransactionManager transactionManager, System.Int32 _neighborhoodId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Neighborhood&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Neighborhood&gt;"/></returns>
		public static TList<Neighborhood> Fill(IDataReader reader, TList<Neighborhood> rows, int start, int pageLength)
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
				
				Ekip.Framework.Entities.Neighborhood c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Neighborhood")
					.Append("|").Append((System.Int32)reader[((int)NeighborhoodColumn.NeighborhoodId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Neighborhood>(
					key.ToString(), // EntityTrackingKey
					"Neighborhood",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Ekip.Framework.Entities.Neighborhood();
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
					c.NeighborhoodId = (System.Int32)reader[((int)NeighborhoodColumn.NeighborhoodId - 1)];
					c.AdminId = (System.Int64)reader[((int)NeighborhoodColumn.AdminId - 1)];
					c.ObjectId = (System.Int64)reader[((int)NeighborhoodColumn.ObjectId - 1)];
					c.ParentId = (System.Int64)reader[((int)NeighborhoodColumn.ParentId - 1)];
					c.RowNumber = (System.Int32)reader[((int)NeighborhoodColumn.RowNumber - 1)];
					c.TownId = (System.Int32)reader[((int)NeighborhoodColumn.TownId - 1)];
					c.NeighborhoodName = (System.String)reader[((int)NeighborhoodColumn.NeighborhoodName - 1)];
					c.Longitude = (System.String)reader[((int)NeighborhoodColumn.Longitude - 1)];
					c.Latitude = (System.String)reader[((int)NeighborhoodColumn.Latitude - 1)];
					c.Type = (System.Int32)reader[((int)NeighborhoodColumn.Type - 1)];
					c.CreateDate = (System.DateTime)reader[((int)NeighborhoodColumn.CreateDate - 1)];
					c.CreateTime = (System.TimeSpan)reader[((int)NeighborhoodColumn.CreateTime - 1)];
					c.UpdateDate = (reader.IsDBNull(((int)NeighborhoodColumn.UpdateDate - 1)))?null:(System.DateTime?)reader[((int)NeighborhoodColumn.UpdateDate - 1)];
					c.UpdateTime = (reader.IsDBNull(((int)NeighborhoodColumn.UpdateTime - 1)))?null:(System.TimeSpan?)reader[((int)NeighborhoodColumn.UpdateTime - 1)];
					c.CreateUserId = (System.Int32)reader[((int)NeighborhoodColumn.CreateUserId - 1)];
					c.UpdateUserId = (reader.IsDBNull(((int)NeighborhoodColumn.UpdateUserId - 1)))?null:(System.Int32?)reader[((int)NeighborhoodColumn.UpdateUserId - 1)];
					c.Active = (System.Boolean)reader[((int)NeighborhoodColumn.Active - 1)];
					c.Deleted = (System.Boolean)reader[((int)NeighborhoodColumn.Deleted - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.Neighborhood"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Neighborhood"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Ekip.Framework.Entities.Neighborhood entity)
		{
			if (!reader.Read()) return;
			
			entity.NeighborhoodId = (System.Int32)reader[((int)NeighborhoodColumn.NeighborhoodId - 1)];
			entity.AdminId = (System.Int64)reader[((int)NeighborhoodColumn.AdminId - 1)];
			entity.ObjectId = (System.Int64)reader[((int)NeighborhoodColumn.ObjectId - 1)];
			entity.ParentId = (System.Int64)reader[((int)NeighborhoodColumn.ParentId - 1)];
			entity.RowNumber = (System.Int32)reader[((int)NeighborhoodColumn.RowNumber - 1)];
			entity.TownId = (System.Int32)reader[((int)NeighborhoodColumn.TownId - 1)];
			entity.NeighborhoodName = (System.String)reader[((int)NeighborhoodColumn.NeighborhoodName - 1)];
			entity.Longitude = (System.String)reader[((int)NeighborhoodColumn.Longitude - 1)];
			entity.Latitude = (System.String)reader[((int)NeighborhoodColumn.Latitude - 1)];
			entity.Type = (System.Int32)reader[((int)NeighborhoodColumn.Type - 1)];
			entity.CreateDate = (System.DateTime)reader[((int)NeighborhoodColumn.CreateDate - 1)];
			entity.CreateTime = (System.TimeSpan)reader[((int)NeighborhoodColumn.CreateTime - 1)];
			entity.UpdateDate = (reader.IsDBNull(((int)NeighborhoodColumn.UpdateDate - 1)))?null:(System.DateTime?)reader[((int)NeighborhoodColumn.UpdateDate - 1)];
			entity.UpdateTime = (reader.IsDBNull(((int)NeighborhoodColumn.UpdateTime - 1)))?null:(System.TimeSpan?)reader[((int)NeighborhoodColumn.UpdateTime - 1)];
			entity.CreateUserId = (System.Int32)reader[((int)NeighborhoodColumn.CreateUserId - 1)];
			entity.UpdateUserId = (reader.IsDBNull(((int)NeighborhoodColumn.UpdateUserId - 1)))?null:(System.Int32?)reader[((int)NeighborhoodColumn.UpdateUserId - 1)];
			entity.Active = (System.Boolean)reader[((int)NeighborhoodColumn.Active - 1)];
			entity.Deleted = (System.Boolean)reader[((int)NeighborhoodColumn.Deleted - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.Neighborhood"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Neighborhood"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Ekip.Framework.Entities.Neighborhood entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.NeighborhoodId = (System.Int32)dataRow["NeighborhoodId"];
			entity.AdminId = (System.Int64)dataRow["AdminId"];
			entity.ObjectId = (System.Int64)dataRow["ObjectId"];
			entity.ParentId = (System.Int64)dataRow["ParentId"];
			entity.RowNumber = (System.Int32)dataRow["RowNumber"];
			entity.TownId = (System.Int32)dataRow["TownId"];
			entity.NeighborhoodName = (System.String)dataRow["NeighborhoodName"];
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
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Neighborhood"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.Neighborhood Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Ekip.Framework.Entities.Neighborhood entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region TownIdSource	
			if (CanDeepLoad(entity, "Town|TownIdSource", deepLoadType, innerList) 
				&& entity.TownIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.TownId;
				Town tmpEntity = EntityManager.LocateEntity<Town>(EntityLocator.ConstructKeyFromPkItems(typeof(Town), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.TownIdSource = tmpEntity;
				else
					entity.TownIdSource = DataRepository.TownProvider.GetByTownId(transactionManager, entity.TownId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'TownIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.TownIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.TownProvider.DeepLoad(transactionManager, entity.TownIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion TownIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByNeighborhoodId methods when available
			
			#region StreetCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Street>|StreetCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'StreetCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.StreetCollection = DataRepository.StreetProvider.GetByNeighborhoodId(transactionManager, entity.NeighborhoodId);

				if (deep && entity.StreetCollection.Count > 0)
				{
					deepHandles.Add("StreetCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Street>) DataRepository.StreetProvider.DeepLoad,
						new object[] { transactionManager, entity.StreetCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Ekip.Framework.Entities.Neighborhood object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Ekip.Framework.Entities.Neighborhood instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.Neighborhood Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Ekip.Framework.Entities.Neighborhood entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region TownIdSource
			if (CanDeepSave(entity, "Town|TownIdSource", deepSaveType, innerList) 
				&& entity.TownIdSource != null)
			{
				DataRepository.TownProvider.Save(transactionManager, entity.TownIdSource);
				entity.TownId = entity.TownIdSource.TownId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<Street>
				if (CanDeepSave(entity.StreetCollection, "List<Street>|StreetCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Street child in entity.StreetCollection)
					{
						if(child.NeighborhoodIdSource != null)
						{
							child.NeighborhoodId = child.NeighborhoodIdSource.NeighborhoodId;
						}
						else
						{
							child.NeighborhoodId = entity.NeighborhoodId;
						}

					}

					if (entity.StreetCollection.Count > 0 || entity.StreetCollection.DeletedItems.Count > 0)
					{
						//DataRepository.StreetProvider.Save(transactionManager, entity.StreetCollection);
						
						deepHandles.Add("StreetCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Street >) DataRepository.StreetProvider.DeepSave,
							new object[] { transactionManager, entity.StreetCollection, deepSaveType, childTypes, innerList }
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
	
	#region NeighborhoodChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Ekip.Framework.Entities.Neighborhood</c>
	///</summary>
	public enum NeighborhoodChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Town</c> at TownIdSource
		///</summary>
		[ChildEntityType(typeof(Town))]
		Town,
	
		///<summary>
		/// Collection of <c>Neighborhood</c> as OneToMany for StreetCollection
		///</summary>
		[ChildEntityType(typeof(TList<Street>))]
		StreetCollection,
	}
	
	#endregion NeighborhoodChildEntityTypes
	
	#region NeighborhoodFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;NeighborhoodColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Neighborhood"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class NeighborhoodFilterBuilder : SqlFilterBuilder<NeighborhoodColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NeighborhoodFilterBuilder class.
		/// </summary>
		public NeighborhoodFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the NeighborhoodFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public NeighborhoodFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the NeighborhoodFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public NeighborhoodFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion NeighborhoodFilterBuilder
	
	#region NeighborhoodParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;NeighborhoodColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Neighborhood"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class NeighborhoodParameterBuilder : ParameterizedSqlFilterBuilder<NeighborhoodColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NeighborhoodParameterBuilder class.
		/// </summary>
		public NeighborhoodParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the NeighborhoodParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public NeighborhoodParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the NeighborhoodParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public NeighborhoodParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion NeighborhoodParameterBuilder
	
	#region NeighborhoodSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;NeighborhoodColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Neighborhood"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class NeighborhoodSortBuilder : SqlSortBuilder<NeighborhoodColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NeighborhoodSqlSortBuilder class.
		/// </summary>
		public NeighborhoodSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion NeighborhoodSortBuilder
	
} // end namespace
