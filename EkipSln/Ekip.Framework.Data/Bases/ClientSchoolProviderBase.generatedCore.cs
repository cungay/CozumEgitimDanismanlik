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
	/// This class is the base class for any <see cref="ClientSchoolProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ClientSchoolProviderBaseCore : EntityProviderBase<Ekip.Framework.Entities.ClientSchool, Ekip.Framework.Entities.ClientSchoolKey>
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
		public override bool Delete(TransactionManager transactionManager, Ekip.Framework.Entities.ClientSchoolKey key)
		{
			return Delete(transactionManager, key.Id);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_ıd">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _ıd)
		{
			return Delete(null, _ıd);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_ıd">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _ıd);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClientSchool_Client key.
		///		FK_ClientSchool_Client Description: 
		/// </summary>
		/// <param name="_clientId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ClientSchool objects.</returns>
		public TList<ClientSchool> GetByClientId(System.Int32 _clientId)
		{
			int count = -1;
			return GetByClientId(_clientId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClientSchool_Client key.
		///		FK_ClientSchool_Client Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_clientId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ClientSchool objects.</returns>
		/// <remarks></remarks>
		public TList<ClientSchool> GetByClientId(TransactionManager transactionManager, System.Int32 _clientId)
		{
			int count = -1;
			return GetByClientId(transactionManager, _clientId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClientSchool_Client key.
		///		FK_ClientSchool_Client Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_clientId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ClientSchool objects.</returns>
		public TList<ClientSchool> GetByClientId(TransactionManager transactionManager, System.Int32 _clientId, int start, int pageLength)
		{
			int count = -1;
			return GetByClientId(transactionManager, _clientId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClientSchool_Client key.
		///		fkClientSchoolClient Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_clientId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ClientSchool objects.</returns>
		public TList<ClientSchool> GetByClientId(System.Int32 _clientId, int start, int pageLength)
		{
			int count =  -1;
			return GetByClientId(null, _clientId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClientSchool_Client key.
		///		fkClientSchoolClient Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_clientId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ClientSchool objects.</returns>
		public TList<ClientSchool> GetByClientId(System.Int32 _clientId, int start, int pageLength,out int count)
		{
			return GetByClientId(null, _clientId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClientSchool_Client key.
		///		FK_ClientSchool_Client Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_clientId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ClientSchool objects.</returns>
		public abstract TList<ClientSchool> GetByClientId(TransactionManager transactionManager, System.Int32 _clientId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClientSchool_School key.
		///		FK_ClientSchool_School Description: 
		/// </summary>
		/// <param name="_schoolId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ClientSchool objects.</returns>
		public TList<ClientSchool> GetBySchoolId(System.Int32 _schoolId)
		{
			int count = -1;
			return GetBySchoolId(_schoolId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClientSchool_School key.
		///		FK_ClientSchool_School Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_schoolId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ClientSchool objects.</returns>
		/// <remarks></remarks>
		public TList<ClientSchool> GetBySchoolId(TransactionManager transactionManager, System.Int32 _schoolId)
		{
			int count = -1;
			return GetBySchoolId(transactionManager, _schoolId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClientSchool_School key.
		///		FK_ClientSchool_School Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_schoolId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ClientSchool objects.</returns>
		public TList<ClientSchool> GetBySchoolId(TransactionManager transactionManager, System.Int32 _schoolId, int start, int pageLength)
		{
			int count = -1;
			return GetBySchoolId(transactionManager, _schoolId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClientSchool_School key.
		///		fkClientSchoolSchool Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_schoolId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ClientSchool objects.</returns>
		public TList<ClientSchool> GetBySchoolId(System.Int32 _schoolId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySchoolId(null, _schoolId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClientSchool_School key.
		///		fkClientSchoolSchool Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_schoolId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ClientSchool objects.</returns>
		public TList<ClientSchool> GetBySchoolId(System.Int32 _schoolId, int start, int pageLength,out int count)
		{
			return GetBySchoolId(null, _schoolId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClientSchool_School key.
		///		FK_ClientSchool_School Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_schoolId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ClientSchool objects.</returns>
		public abstract TList<ClientSchool> GetBySchoolId(TransactionManager transactionManager, System.Int32 _schoolId, int start, int pageLength, out int count);
		
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
		public override Ekip.Framework.Entities.ClientSchool Get(TransactionManager transactionManager, Ekip.Framework.Entities.ClientSchoolKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ClientSchool index.
		/// </summary>
		/// <param name="_ıd"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ClientSchool"/> class.</returns>
		public Ekip.Framework.Entities.ClientSchool GetById(System.Int32 _ıd)
		{
			int count = -1;
			return GetById(null,_ıd, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ClientSchool index.
		/// </summary>
		/// <param name="_ıd"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ClientSchool"/> class.</returns>
		public Ekip.Framework.Entities.ClientSchool GetById(System.Int32 _ıd, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _ıd, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ClientSchool index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_ıd"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ClientSchool"/> class.</returns>
		public Ekip.Framework.Entities.ClientSchool GetById(TransactionManager transactionManager, System.Int32 _ıd)
		{
			int count = -1;
			return GetById(transactionManager, _ıd, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ClientSchool index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_ıd"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ClientSchool"/> class.</returns>
		public Ekip.Framework.Entities.ClientSchool GetById(TransactionManager transactionManager, System.Int32 _ıd, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _ıd, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ClientSchool index.
		/// </summary>
		/// <param name="_ıd"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ClientSchool"/> class.</returns>
		public Ekip.Framework.Entities.ClientSchool GetById(System.Int32 _ıd, int start, int pageLength, out int count)
		{
			return GetById(null, _ıd, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ClientSchool index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_ıd"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ClientSchool"/> class.</returns>
		public abstract Ekip.Framework.Entities.ClientSchool GetById(TransactionManager transactionManager, System.Int32 _ıd, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;ClientSchool&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;ClientSchool&gt;"/></returns>
		public static TList<ClientSchool> Fill(IDataReader reader, TList<ClientSchool> rows, int start, int pageLength)
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
				
				Ekip.Framework.Entities.ClientSchool c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ClientSchool")
					.Append("|").Append((System.Int32)reader[((int)ClientSchoolColumn.Id - 1)]).ToString();
					c = EntityManager.LocateOrCreate<ClientSchool>(
					key.ToString(), // EntityTrackingKey
					"ClientSchool",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Ekip.Framework.Entities.ClientSchool();
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
					c.Id = (System.Int32)reader[((int)ClientSchoolColumn.Id - 1)];
					c.ClientId = (System.Int32)reader[((int)ClientSchoolColumn.ClientId - 1)];
					c.SchoolId = (System.Int32)reader[((int)ClientSchoolColumn.SchoolId - 1)];
					c.ClassRoomId = (System.Byte)reader[((int)ClientSchoolColumn.ClassRoomId - 1)];
					c.Notes = (reader.IsDBNull(((int)ClientSchoolColumn.Notes - 1)))?null:(System.String)reader[((int)ClientSchoolColumn.Notes - 1)];
					c.CreateOn = (System.DateTime)reader[((int)ClientSchoolColumn.CreateOn - 1)];
					c.UpdateOn = (reader.IsDBNull(((int)ClientSchoolColumn.UpdateOn - 1)))?null:(System.DateTime?)reader[((int)ClientSchoolColumn.UpdateOn - 1)];
					c.CreateUserId = (System.Int32)reader[((int)ClientSchoolColumn.CreateUserId - 1)];
					c.UpdateUserId = (reader.IsDBNull(((int)ClientSchoolColumn.UpdateUserId - 1)))?null:(System.Int32?)reader[((int)ClientSchoolColumn.UpdateUserId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.ClientSchool"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.ClientSchool"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Ekip.Framework.Entities.ClientSchool entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)ClientSchoolColumn.Id - 1)];
			entity.ClientId = (System.Int32)reader[((int)ClientSchoolColumn.ClientId - 1)];
			entity.SchoolId = (System.Int32)reader[((int)ClientSchoolColumn.SchoolId - 1)];
			entity.ClassRoomId = (System.Byte)reader[((int)ClientSchoolColumn.ClassRoomId - 1)];
			entity.Notes = (reader.IsDBNull(((int)ClientSchoolColumn.Notes - 1)))?null:(System.String)reader[((int)ClientSchoolColumn.Notes - 1)];
			entity.CreateOn = (System.DateTime)reader[((int)ClientSchoolColumn.CreateOn - 1)];
			entity.UpdateOn = (reader.IsDBNull(((int)ClientSchoolColumn.UpdateOn - 1)))?null:(System.DateTime?)reader[((int)ClientSchoolColumn.UpdateOn - 1)];
			entity.CreateUserId = (System.Int32)reader[((int)ClientSchoolColumn.CreateUserId - 1)];
			entity.UpdateUserId = (reader.IsDBNull(((int)ClientSchoolColumn.UpdateUserId - 1)))?null:(System.Int32?)reader[((int)ClientSchoolColumn.UpdateUserId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.ClientSchool"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.ClientSchool"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Ekip.Framework.Entities.ClientSchool entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["Id"];
			entity.ClientId = (System.Int32)dataRow["ClientId"];
			entity.SchoolId = (System.Int32)dataRow["SchoolId"];
			entity.ClassRoomId = (System.Byte)dataRow["ClassRoomId"];
			entity.Notes = Convert.IsDBNull(dataRow["Notes"]) ? null : (System.String)dataRow["Notes"];
			entity.CreateOn = (System.DateTime)dataRow["CreateOn"];
			entity.UpdateOn = Convert.IsDBNull(dataRow["UpdateOn"]) ? null : (System.DateTime?)dataRow["UpdateOn"];
			entity.CreateUserId = (System.Int32)dataRow["CreateUserId"];
			entity.UpdateUserId = Convert.IsDBNull(dataRow["UpdateUserId"]) ? null : (System.Int32?)dataRow["UpdateUserId"];
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
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.ClientSchool"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.ClientSchool Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Ekip.Framework.Entities.ClientSchool entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region ClientIdSource	
			if (CanDeepLoad(entity, "Client|ClientIdSource", deepLoadType, innerList) 
				&& entity.ClientIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ClientId;
				Client tmpEntity = EntityManager.LocateEntity<Client>(EntityLocator.ConstructKeyFromPkItems(typeof(Client), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ClientIdSource = tmpEntity;
				else
					entity.ClientIdSource = DataRepository.ClientProvider.GetByClientId(transactionManager, entity.ClientId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ClientIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ClientIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ClientProvider.DeepLoad(transactionManager, entity.ClientIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ClientIdSource

			#region SchoolIdSource	
			if (CanDeepLoad(entity, "School|SchoolIdSource", deepLoadType, innerList) 
				&& entity.SchoolIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.SchoolId;
				School tmpEntity = EntityManager.LocateEntity<School>(EntityLocator.ConstructKeyFromPkItems(typeof(School), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.SchoolIdSource = tmpEntity;
				else
					entity.SchoolIdSource = DataRepository.SchoolProvider.GetBySchoolId(transactionManager, entity.SchoolId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SchoolIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.SchoolIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.SchoolProvider.DeepLoad(transactionManager, entity.SchoolIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion SchoolIdSource
			
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
		/// Deep Save the entire object graph of the Ekip.Framework.Entities.ClientSchool object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Ekip.Framework.Entities.ClientSchool instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.ClientSchool Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Ekip.Framework.Entities.ClientSchool entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region ClientIdSource
			if (CanDeepSave(entity, "Client|ClientIdSource", deepSaveType, innerList) 
				&& entity.ClientIdSource != null)
			{
				DataRepository.ClientProvider.Save(transactionManager, entity.ClientIdSource);
				entity.ClientId = entity.ClientIdSource.ClientId;
			}
			#endregion 
			
			#region SchoolIdSource
			if (CanDeepSave(entity, "School|SchoolIdSource", deepSaveType, innerList) 
				&& entity.SchoolIdSource != null)
			{
				DataRepository.SchoolProvider.Save(transactionManager, entity.SchoolIdSource);
				entity.SchoolId = entity.SchoolIdSource.SchoolId;
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
	
	#region ClientSchoolChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Ekip.Framework.Entities.ClientSchool</c>
	///</summary>
	public enum ClientSchoolChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Client</c> at ClientIdSource
		///</summary>
		[ChildEntityType(typeof(Client))]
		Client,
			
		///<summary>
		/// Composite Property for <c>School</c> at SchoolIdSource
		///</summary>
		[ChildEntityType(typeof(School))]
		School,
		}
	
	#endregion ClientSchoolChildEntityTypes
	
	#region ClientSchoolFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ClientSchoolColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClientSchool"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClientSchoolFilterBuilder : SqlFilterBuilder<ClientSchoolColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClientSchoolFilterBuilder class.
		/// </summary>
		public ClientSchoolFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ClientSchoolFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ClientSchoolFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ClientSchoolFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ClientSchoolFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ClientSchoolFilterBuilder
	
	#region ClientSchoolParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ClientSchoolColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClientSchool"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClientSchoolParameterBuilder : ParameterizedSqlFilterBuilder<ClientSchoolColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClientSchoolParameterBuilder class.
		/// </summary>
		public ClientSchoolParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ClientSchoolParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ClientSchoolParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ClientSchoolParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ClientSchoolParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ClientSchoolParameterBuilder
	
	#region ClientSchoolSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ClientSchoolColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClientSchool"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ClientSchoolSortBuilder : SqlSortBuilder<ClientSchoolColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClientSchoolSqlSortBuilder class.
		/// </summary>
		public ClientSchoolSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ClientSchoolSortBuilder
	
} // end namespace
