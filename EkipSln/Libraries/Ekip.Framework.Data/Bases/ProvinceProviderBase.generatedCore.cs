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
	/// This class is the base class for any <see cref="ProvinceProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ProvinceProviderBaseCore : EntityProviderBase<Ekip.Framework.Entities.Province, Ekip.Framework.Entities.ProvinceKey>
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
		public override bool Delete(TransactionManager transactionManager, Ekip.Framework.Entities.ProvinceKey key)
		{
			return Delete(transactionManager, key.ProvinceId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_provinceId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _provinceId)
		{
			return Delete(null, _provinceId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_provinceId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _provinceId);		
		
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
		public override Ekip.Framework.Entities.Province Get(TransactionManager transactionManager, Ekip.Framework.Entities.ProvinceKey key, int start, int pageLength)
		{
			return GetByProvinceId(transactionManager, key.ProvinceId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Province_ProvinceName index.
		/// </summary>
		/// <param name="_provinceName"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Province"/> class.</returns>
		public Ekip.Framework.Entities.Province GetByProvinceName(System.String _provinceName)
		{
			int count = -1;
			return GetByProvinceName(null,_provinceName, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Province_ProvinceName index.
		/// </summary>
		/// <param name="_provinceName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Province"/> class.</returns>
		public Ekip.Framework.Entities.Province GetByProvinceName(System.String _provinceName, int start, int pageLength)
		{
			int count = -1;
			return GetByProvinceName(null, _provinceName, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Province_ProvinceName index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_provinceName"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Province"/> class.</returns>
		public Ekip.Framework.Entities.Province GetByProvinceName(TransactionManager transactionManager, System.String _provinceName)
		{
			int count = -1;
			return GetByProvinceName(transactionManager, _provinceName, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Province_ProvinceName index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_provinceName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Province"/> class.</returns>
		public Ekip.Framework.Entities.Province GetByProvinceName(TransactionManager transactionManager, System.String _provinceName, int start, int pageLength)
		{
			int count = -1;
			return GetByProvinceName(transactionManager, _provinceName, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Province_ProvinceName index.
		/// </summary>
		/// <param name="_provinceName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Province"/> class.</returns>
		public Ekip.Framework.Entities.Province GetByProvinceName(System.String _provinceName, int start, int pageLength, out int count)
		{
			return GetByProvinceName(null, _provinceName, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Province_ProvinceName index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_provinceName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Province"/> class.</returns>
		public abstract Ekip.Framework.Entities.Province GetByProvinceName(TransactionManager transactionManager, System.String _provinceName, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Province index.
		/// </summary>
		/// <param name="_provinceId"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Province"/> class.</returns>
		public Ekip.Framework.Entities.Province GetByProvinceId(System.Int32 _provinceId)
		{
			int count = -1;
			return GetByProvinceId(null,_provinceId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Province index.
		/// </summary>
		/// <param name="_provinceId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Province"/> class.</returns>
		public Ekip.Framework.Entities.Province GetByProvinceId(System.Int32 _provinceId, int start, int pageLength)
		{
			int count = -1;
			return GetByProvinceId(null, _provinceId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Province index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_provinceId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Province"/> class.</returns>
		public Ekip.Framework.Entities.Province GetByProvinceId(TransactionManager transactionManager, System.Int32 _provinceId)
		{
			int count = -1;
			return GetByProvinceId(transactionManager, _provinceId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Province index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_provinceId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Province"/> class.</returns>
		public Ekip.Framework.Entities.Province GetByProvinceId(TransactionManager transactionManager, System.Int32 _provinceId, int start, int pageLength)
		{
			int count = -1;
			return GetByProvinceId(transactionManager, _provinceId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Province index.
		/// </summary>
		/// <param name="_provinceId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Province"/> class.</returns>
		public Ekip.Framework.Entities.Province GetByProvinceId(System.Int32 _provinceId, int start, int pageLength, out int count)
		{
			return GetByProvinceId(null, _provinceId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Province index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_provinceId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Province"/> class.</returns>
		public abstract Ekip.Framework.Entities.Province GetByProvinceId(TransactionManager transactionManager, System.Int32 _provinceId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Province&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Province&gt;"/></returns>
		public static TList<Province> Fill(IDataReader reader, TList<Province> rows, int start, int pageLength)
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
				
				Ekip.Framework.Entities.Province c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Province")
					.Append("|").Append((System.Int32)reader[((int)ProvinceColumn.ProvinceId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Province>(
					key.ToString(), // EntityTrackingKey
					"Province",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Ekip.Framework.Entities.Province();
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
					c.ProvinceId = (System.Int32)reader[((int)ProvinceColumn.ProvinceId - 1)];
					c.RowNumber = (System.Int32)reader[((int)ProvinceColumn.RowNumber - 1)];
					c.AdminId = (System.Int64)reader[((int)ProvinceColumn.AdminId - 1)];
					c.ObjectId = (System.Int64)reader[((int)ProvinceColumn.ObjectId - 1)];
					c.ParentId = (System.Int64)reader[((int)ProvinceColumn.ParentId - 1)];
					c.PlateCode = (System.String)reader[((int)ProvinceColumn.PlateCode - 1)];
					c.AreaId = (System.Int32)reader[((int)ProvinceColumn.AreaId - 1)];
					c.PhoneCode = (System.String)reader[((int)ProvinceColumn.PhoneCode - 1)];
					c.ProvinceName = (System.String)reader[((int)ProvinceColumn.ProvinceName - 1)];
					c.Longitude = (System.String)reader[((int)ProvinceColumn.Longitude - 1)];
					c.Latitude = (System.String)reader[((int)ProvinceColumn.Latitude - 1)];
					c.Type = (System.Int32)reader[((int)ProvinceColumn.Type - 1)];
					c.CreateDate = (System.DateTime)reader[((int)ProvinceColumn.CreateDate - 1)];
					c.CreateTime = (System.TimeSpan)reader[((int)ProvinceColumn.CreateTime - 1)];
					c.UpdateDate = (reader.IsDBNull(((int)ProvinceColumn.UpdateDate - 1)))?null:(System.DateTime?)reader[((int)ProvinceColumn.UpdateDate - 1)];
					c.UpdateTime = (reader.IsDBNull(((int)ProvinceColumn.UpdateTime - 1)))?null:(System.TimeSpan?)reader[((int)ProvinceColumn.UpdateTime - 1)];
					c.CreateUserId = (System.Int32)reader[((int)ProvinceColumn.CreateUserId - 1)];
					c.UpdateUserId = (reader.IsDBNull(((int)ProvinceColumn.UpdateUserId - 1)))?null:(System.Int32?)reader[((int)ProvinceColumn.UpdateUserId - 1)];
					c.Active = (System.Boolean)reader[((int)ProvinceColumn.Active - 1)];
					c.Deleted = (System.Boolean)reader[((int)ProvinceColumn.Deleted - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.Province"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Province"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Ekip.Framework.Entities.Province entity)
		{
			if (!reader.Read()) return;
			
			entity.ProvinceId = (System.Int32)reader[((int)ProvinceColumn.ProvinceId - 1)];
			entity.RowNumber = (System.Int32)reader[((int)ProvinceColumn.RowNumber - 1)];
			entity.AdminId = (System.Int64)reader[((int)ProvinceColumn.AdminId - 1)];
			entity.ObjectId = (System.Int64)reader[((int)ProvinceColumn.ObjectId - 1)];
			entity.ParentId = (System.Int64)reader[((int)ProvinceColumn.ParentId - 1)];
			entity.PlateCode = (System.String)reader[((int)ProvinceColumn.PlateCode - 1)];
			entity.AreaId = (System.Int32)reader[((int)ProvinceColumn.AreaId - 1)];
			entity.PhoneCode = (System.String)reader[((int)ProvinceColumn.PhoneCode - 1)];
			entity.ProvinceName = (System.String)reader[((int)ProvinceColumn.ProvinceName - 1)];
			entity.Longitude = (System.String)reader[((int)ProvinceColumn.Longitude - 1)];
			entity.Latitude = (System.String)reader[((int)ProvinceColumn.Latitude - 1)];
			entity.Type = (System.Int32)reader[((int)ProvinceColumn.Type - 1)];
			entity.CreateDate = (System.DateTime)reader[((int)ProvinceColumn.CreateDate - 1)];
			entity.CreateTime = (System.TimeSpan)reader[((int)ProvinceColumn.CreateTime - 1)];
			entity.UpdateDate = (reader.IsDBNull(((int)ProvinceColumn.UpdateDate - 1)))?null:(System.DateTime?)reader[((int)ProvinceColumn.UpdateDate - 1)];
			entity.UpdateTime = (reader.IsDBNull(((int)ProvinceColumn.UpdateTime - 1)))?null:(System.TimeSpan?)reader[((int)ProvinceColumn.UpdateTime - 1)];
			entity.CreateUserId = (System.Int32)reader[((int)ProvinceColumn.CreateUserId - 1)];
			entity.UpdateUserId = (reader.IsDBNull(((int)ProvinceColumn.UpdateUserId - 1)))?null:(System.Int32?)reader[((int)ProvinceColumn.UpdateUserId - 1)];
			entity.Active = (System.Boolean)reader[((int)ProvinceColumn.Active - 1)];
			entity.Deleted = (System.Boolean)reader[((int)ProvinceColumn.Deleted - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.Province"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Province"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Ekip.Framework.Entities.Province entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ProvinceId = (System.Int32)dataRow["ProvinceId"];
			entity.RowNumber = (System.Int32)dataRow["RowNumber"];
			entity.AdminId = (System.Int64)dataRow["AdminId"];
			entity.ObjectId = (System.Int64)dataRow["ObjectId"];
			entity.ParentId = (System.Int64)dataRow["ParentId"];
			entity.PlateCode = (System.String)dataRow["PlateCode"];
			entity.AreaId = (System.Int32)dataRow["AreaId"];
			entity.PhoneCode = (System.String)dataRow["PhoneCode"];
			entity.ProvinceName = (System.String)dataRow["ProvinceName"];
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
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Province"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.Province Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Ekip.Framework.Entities.Province entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByProvinceId methods when available
			
			#region TownCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Town>|TownCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'TownCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.TownCollection = DataRepository.TownProvider.GetByProvinceId(transactionManager, entity.ProvinceId);

				if (deep && entity.TownCollection.Count > 0)
				{
					deepHandles.Add("TownCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Town>) DataRepository.TownProvider.DeepLoad,
						new object[] { transactionManager, entity.TownCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Ekip.Framework.Entities.Province object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Ekip.Framework.Entities.Province instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.Province Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Ekip.Framework.Entities.Province entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<Town>
				if (CanDeepSave(entity.TownCollection, "List<Town>|TownCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Town child in entity.TownCollection)
					{
						if(child.ProvinceIdSource != null)
						{
							child.ProvinceId = child.ProvinceIdSource.ProvinceId;
						}
						else
						{
							child.ProvinceId = entity.ProvinceId;
						}

					}

					if (entity.TownCollection.Count > 0 || entity.TownCollection.DeletedItems.Count > 0)
					{
						//DataRepository.TownProvider.Save(transactionManager, entity.TownCollection);
						
						deepHandles.Add("TownCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Town >) DataRepository.TownProvider.DeepSave,
							new object[] { transactionManager, entity.TownCollection, deepSaveType, childTypes, innerList }
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
	
	#region ProvinceChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Ekip.Framework.Entities.Province</c>
	///</summary>
	public enum ProvinceChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Province</c> as OneToMany for TownCollection
		///</summary>
		[ChildEntityType(typeof(TList<Town>))]
		TownCollection,
	}
	
	#endregion ProvinceChildEntityTypes
	
	#region ProvinceFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ProvinceColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Province"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProvinceFilterBuilder : SqlFilterBuilder<ProvinceColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProvinceFilterBuilder class.
		/// </summary>
		public ProvinceFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProvinceFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProvinceFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProvinceFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProvinceFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProvinceFilterBuilder
	
	#region ProvinceParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ProvinceColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Province"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProvinceParameterBuilder : ParameterizedSqlFilterBuilder<ProvinceColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProvinceParameterBuilder class.
		/// </summary>
		public ProvinceParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProvinceParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProvinceParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProvinceParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProvinceParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProvinceParameterBuilder
	
	#region ProvinceSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ProvinceColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Province"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ProvinceSortBuilder : SqlSortBuilder<ProvinceColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProvinceSqlSortBuilder class.
		/// </summary>
		public ProvinceSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ProvinceSortBuilder
	
} // end namespace
