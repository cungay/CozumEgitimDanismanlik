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
	/// This class is the base class for any <see cref="ClientAddressProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ClientAddressProviderBaseCore : EntityProviderBase<Ekip.Framework.Entities.ClientAddress, Ekip.Framework.Entities.ClientAddressKey>
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
		public override bool Delete(TransactionManager transactionManager, Ekip.Framework.Entities.ClientAddressKey key)
		{
			return Delete(transactionManager, key.AddressId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_addressId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _addressId)
		{
			return Delete(null, _addressId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_addressId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _addressId);		
		
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
		public override Ekip.Framework.Entities.ClientAddress Get(TransactionManager transactionManager, Ekip.Framework.Entities.ClientAddressKey key, int start, int pageLength)
		{
			return GetByAddressId(transactionManager, key.AddressId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Users_Address index.
		/// </summary>
		/// <param name="_addressId"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ClientAddress"/> class.</returns>
		public Ekip.Framework.Entities.ClientAddress GetByAddressId(System.Int32 _addressId)
		{
			int count = -1;
			return GetByAddressId(null,_addressId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Users_Address index.
		/// </summary>
		/// <param name="_addressId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ClientAddress"/> class.</returns>
		public Ekip.Framework.Entities.ClientAddress GetByAddressId(System.Int32 _addressId, int start, int pageLength)
		{
			int count = -1;
			return GetByAddressId(null, _addressId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Users_Address index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_addressId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ClientAddress"/> class.</returns>
		public Ekip.Framework.Entities.ClientAddress GetByAddressId(TransactionManager transactionManager, System.Int32 _addressId)
		{
			int count = -1;
			return GetByAddressId(transactionManager, _addressId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Users_Address index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_addressId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ClientAddress"/> class.</returns>
		public Ekip.Framework.Entities.ClientAddress GetByAddressId(TransactionManager transactionManager, System.Int32 _addressId, int start, int pageLength)
		{
			int count = -1;
			return GetByAddressId(transactionManager, _addressId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Users_Address index.
		/// </summary>
		/// <param name="_addressId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ClientAddress"/> class.</returns>
		public Ekip.Framework.Entities.ClientAddress GetByAddressId(System.Int32 _addressId, int start, int pageLength, out int count)
		{
			return GetByAddressId(null, _addressId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Users_Address index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_addressId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ClientAddress"/> class.</returns>
		public abstract Ekip.Framework.Entities.ClientAddress GetByAddressId(TransactionManager transactionManager, System.Int32 _addressId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region ClientAddress_GetCurrentAddress 
		
		/// <summary>
		///	This method wrap the 'ClientAddress_GetCurrentAddress' stored procedure. 
		/// </summary>
		/// <param name="clientId"> A <c>System.Int32</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void GetCurrentAddress(System.Int32 clientId)
		{
			 GetCurrentAddress(null, 0, int.MaxValue , clientId);
		}
		
		/// <summary>
		///	This method wrap the 'ClientAddress_GetCurrentAddress' stored procedure. 
		/// </summary>
		/// <param name="clientId"> A <c>System.Int32</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void GetCurrentAddress(int start, int pageLength, System.Int32 clientId)
		{
			 GetCurrentAddress(null, start, pageLength , clientId);
		}
				
		/// <summary>
		///	This method wrap the 'ClientAddress_GetCurrentAddress' stored procedure. 
		/// </summary>
		/// <param name="clientId"> A <c>System.Int32</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void GetCurrentAddress(TransactionManager transactionManager, System.Int32 clientId)
		{
			 GetCurrentAddress(transactionManager, 0, int.MaxValue , clientId);
		}
		
		/// <summary>
		///	This method wrap the 'ClientAddress_GetCurrentAddress' stored procedure. 
		/// </summary>
		/// <param name="clientId"> A <c>System.Int32</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void GetCurrentAddress(TransactionManager transactionManager, int start, int pageLength , System.Int32 clientId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;ClientAddress&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;ClientAddress&gt;"/></returns>
		public static TList<ClientAddress> Fill(IDataReader reader, TList<ClientAddress> rows, int start, int pageLength)
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
				
				Ekip.Framework.Entities.ClientAddress c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ClientAddress")
					.Append("|").Append((System.Int32)reader[((int)ClientAddressColumn.AddressId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<ClientAddress>(
					key.ToString(), // EntityTrackingKey
					"ClientAddress",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Ekip.Framework.Entities.ClientAddress();
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
					c.AddressId = (System.Int32)reader[((int)ClientAddressColumn.AddressId - 1)];
					c.TitleId = (System.Byte)reader[((int)ClientAddressColumn.TitleId - 1)];
					c.AddressLine = (reader.IsDBNull(((int)ClientAddressColumn.AddressLine - 1)))?null:(System.String)reader[((int)ClientAddressColumn.AddressLine - 1)];
					c.ProvinceId = (reader.IsDBNull(((int)ClientAddressColumn.ProvinceId - 1)))?null:(System.Int32?)reader[((int)ClientAddressColumn.ProvinceId - 1)];
					c.TownId = (reader.IsDBNull(((int)ClientAddressColumn.TownId - 1)))?null:(System.Int32?)reader[((int)ClientAddressColumn.TownId - 1)];
					c.NeighborhoodId = (reader.IsDBNull(((int)ClientAddressColumn.NeighborhoodId - 1)))?null:(System.Int32?)reader[((int)ClientAddressColumn.NeighborhoodId - 1)];
					c.StreetId = (reader.IsDBNull(((int)ClientAddressColumn.StreetId - 1)))?null:(System.Int32?)reader[((int)ClientAddressColumn.StreetId - 1)];
					c.Phone1 = (reader.IsDBNull(((int)ClientAddressColumn.Phone1 - 1)))?null:(System.String)reader[((int)ClientAddressColumn.Phone1 - 1)];
					c.Phone2 = (reader.IsDBNull(((int)ClientAddressColumn.Phone2 - 1)))?null:(System.String)reader[((int)ClientAddressColumn.Phone2 - 1)];
					c.Mobile = (reader.IsDBNull(((int)ClientAddressColumn.Mobile - 1)))?null:(System.String)reader[((int)ClientAddressColumn.Mobile - 1)];
					c.IsUsed = (System.Boolean)reader[((int)ClientAddressColumn.IsUsed - 1)];
					c.CreateOn = (System.DateTime)reader[((int)ClientAddressColumn.CreateOn - 1)];
					c.UpdateOn = (reader.IsDBNull(((int)ClientAddressColumn.UpdateOn - 1)))?null:(System.DateTime?)reader[((int)ClientAddressColumn.UpdateOn - 1)];
					c.UserId = (System.Int32)reader[((int)ClientAddressColumn.UserId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.ClientAddress"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.ClientAddress"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Ekip.Framework.Entities.ClientAddress entity)
		{
			if (!reader.Read()) return;
			
			entity.AddressId = (System.Int32)reader[((int)ClientAddressColumn.AddressId - 1)];
			entity.TitleId = (System.Byte)reader[((int)ClientAddressColumn.TitleId - 1)];
			entity.AddressLine = (reader.IsDBNull(((int)ClientAddressColumn.AddressLine - 1)))?null:(System.String)reader[((int)ClientAddressColumn.AddressLine - 1)];
			entity.ProvinceId = (reader.IsDBNull(((int)ClientAddressColumn.ProvinceId - 1)))?null:(System.Int32?)reader[((int)ClientAddressColumn.ProvinceId - 1)];
			entity.TownId = (reader.IsDBNull(((int)ClientAddressColumn.TownId - 1)))?null:(System.Int32?)reader[((int)ClientAddressColumn.TownId - 1)];
			entity.NeighborhoodId = (reader.IsDBNull(((int)ClientAddressColumn.NeighborhoodId - 1)))?null:(System.Int32?)reader[((int)ClientAddressColumn.NeighborhoodId - 1)];
			entity.StreetId = (reader.IsDBNull(((int)ClientAddressColumn.StreetId - 1)))?null:(System.Int32?)reader[((int)ClientAddressColumn.StreetId - 1)];
			entity.Phone1 = (reader.IsDBNull(((int)ClientAddressColumn.Phone1 - 1)))?null:(System.String)reader[((int)ClientAddressColumn.Phone1 - 1)];
			entity.Phone2 = (reader.IsDBNull(((int)ClientAddressColumn.Phone2 - 1)))?null:(System.String)reader[((int)ClientAddressColumn.Phone2 - 1)];
			entity.Mobile = (reader.IsDBNull(((int)ClientAddressColumn.Mobile - 1)))?null:(System.String)reader[((int)ClientAddressColumn.Mobile - 1)];
			entity.IsUsed = (System.Boolean)reader[((int)ClientAddressColumn.IsUsed - 1)];
			entity.CreateOn = (System.DateTime)reader[((int)ClientAddressColumn.CreateOn - 1)];
			entity.UpdateOn = (reader.IsDBNull(((int)ClientAddressColumn.UpdateOn - 1)))?null:(System.DateTime?)reader[((int)ClientAddressColumn.UpdateOn - 1)];
			entity.UserId = (System.Int32)reader[((int)ClientAddressColumn.UserId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.ClientAddress"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.ClientAddress"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Ekip.Framework.Entities.ClientAddress entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.AddressId = (System.Int32)dataRow["AddressId"];
			entity.TitleId = (System.Byte)dataRow["TitleId"];
			entity.AddressLine = Convert.IsDBNull(dataRow["AddressLine"]) ? null : (System.String)dataRow["AddressLine"];
			entity.ProvinceId = Convert.IsDBNull(dataRow["ProvinceId"]) ? null : (System.Int32?)dataRow["ProvinceId"];
			entity.TownId = Convert.IsDBNull(dataRow["TownId"]) ? null : (System.Int32?)dataRow["TownId"];
			entity.NeighborhoodId = Convert.IsDBNull(dataRow["NeighborhoodId"]) ? null : (System.Int32?)dataRow["NeighborhoodId"];
			entity.StreetId = Convert.IsDBNull(dataRow["StreetId"]) ? null : (System.Int32?)dataRow["StreetId"];
			entity.Phone1 = Convert.IsDBNull(dataRow["Phone1"]) ? null : (System.String)dataRow["Phone1"];
			entity.Phone2 = Convert.IsDBNull(dataRow["Phone2"]) ? null : (System.String)dataRow["Phone2"];
			entity.Mobile = Convert.IsDBNull(dataRow["Mobile"]) ? null : (System.String)dataRow["Mobile"];
			entity.IsUsed = (System.Boolean)dataRow["IsUsed"];
			entity.CreateOn = (System.DateTime)dataRow["CreateOn"];
			entity.UpdateOn = Convert.IsDBNull(dataRow["UpdateOn"]) ? null : (System.DateTime?)dataRow["UpdateOn"];
			entity.UserId = (System.Int32)dataRow["UserId"];
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
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.ClientAddress"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.ClientAddress Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Ekip.Framework.Entities.ClientAddress entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByAddressId methods when available
			
			#region ClientCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Client>|ClientCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ClientCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ClientCollection = DataRepository.ClientProvider.GetByAddressId(transactionManager, entity.AddressId);

				if (deep && entity.ClientCollection.Count > 0)
				{
					deepHandles.Add("ClientCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Client>) DataRepository.ClientProvider.DeepLoad,
						new object[] { transactionManager, entity.ClientCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Ekip.Framework.Entities.ClientAddress object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Ekip.Framework.Entities.ClientAddress instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.ClientAddress Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Ekip.Framework.Entities.ClientAddress entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<Client>
				if (CanDeepSave(entity.ClientCollection, "List<Client>|ClientCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Client child in entity.ClientCollection)
					{
						if(child.AddressIdSource != null)
						{
							child.AddressId = child.AddressIdSource.AddressId;
						}
						else
						{
							child.AddressId = entity.AddressId;
						}

					}

					if (entity.ClientCollection.Count > 0 || entity.ClientCollection.DeletedItems.Count > 0)
					{
						//DataRepository.ClientProvider.Save(transactionManager, entity.ClientCollection);
						
						deepHandles.Add("ClientCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Client >) DataRepository.ClientProvider.DeepSave,
							new object[] { transactionManager, entity.ClientCollection, deepSaveType, childTypes, innerList }
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
	
	#region ClientAddressChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Ekip.Framework.Entities.ClientAddress</c>
	///</summary>
	public enum ClientAddressChildEntityTypes
	{

		///<summary>
		/// Collection of <c>ClientAddress</c> as OneToMany for ClientCollection
		///</summary>
		[ChildEntityType(typeof(TList<Client>))]
		ClientCollection,
	}
	
	#endregion ClientAddressChildEntityTypes
	
	#region ClientAddressFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ClientAddressColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClientAddress"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClientAddressFilterBuilder : SqlFilterBuilder<ClientAddressColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClientAddressFilterBuilder class.
		/// </summary>
		public ClientAddressFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ClientAddressFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ClientAddressFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ClientAddressFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ClientAddressFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ClientAddressFilterBuilder
	
	#region ClientAddressParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ClientAddressColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClientAddress"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClientAddressParameterBuilder : ParameterizedSqlFilterBuilder<ClientAddressColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClientAddressParameterBuilder class.
		/// </summary>
		public ClientAddressParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ClientAddressParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ClientAddressParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ClientAddressParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ClientAddressParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ClientAddressParameterBuilder
	
	#region ClientAddressSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ClientAddressColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClientAddress"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ClientAddressSortBuilder : SqlSortBuilder<ClientAddressColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClientAddressSqlSortBuilder class.
		/// </summary>
		public ClientAddressSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ClientAddressSortBuilder
	
} // end namespace
