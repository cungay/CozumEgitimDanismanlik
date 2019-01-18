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
	/// This class is the base class for any <see cref="SeanceProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SeanceProviderBaseCore : EntityProviderBase<Ekip.Framework.Entities.Seance, Ekip.Framework.Entities.SeanceKey>
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
		public override bool Delete(TransactionManager transactionManager, Ekip.Framework.Entities.SeanceKey key)
		{
			return Delete(transactionManager, key.SeanceId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_seanceId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _seanceId)
		{
			return Delete(null, _seanceId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_seanceId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _seanceId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Seance_Client key.
		///		FK_Seance_Client Description: 
		/// </summary>
		/// <param name="_clientId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Seance objects.</returns>
		public TList<Seance> GetByClientId(System.Int32 _clientId)
		{
			int count = -1;
			return GetByClientId(_clientId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Seance_Client key.
		///		FK_Seance_Client Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_clientId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Seance objects.</returns>
		/// <remarks></remarks>
		public TList<Seance> GetByClientId(TransactionManager transactionManager, System.Int32 _clientId)
		{
			int count = -1;
			return GetByClientId(transactionManager, _clientId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Seance_Client key.
		///		FK_Seance_Client Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_clientId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Seance objects.</returns>
		public TList<Seance> GetByClientId(TransactionManager transactionManager, System.Int32 _clientId, int start, int pageLength)
		{
			int count = -1;
			return GetByClientId(transactionManager, _clientId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Seance_Client key.
		///		fkSeanceClient Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_clientId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Seance objects.</returns>
		public TList<Seance> GetByClientId(System.Int32 _clientId, int start, int pageLength)
		{
			int count =  -1;
			return GetByClientId(null, _clientId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Seance_Client key.
		///		fkSeanceClient Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_clientId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Seance objects.</returns>
		public TList<Seance> GetByClientId(System.Int32 _clientId, int start, int pageLength,out int count)
		{
			return GetByClientId(null, _clientId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Seance_Client key.
		///		FK_Seance_Client Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_clientId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Seance objects.</returns>
		public abstract TList<Seance> GetByClientId(TransactionManager transactionManager, System.Int32 _clientId, int start, int pageLength, out int count);
		
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
		public override Ekip.Framework.Entities.Seance Get(TransactionManager transactionManager, Ekip.Framework.Entities.SeanceKey key, int start, int pageLength)
		{
			return GetBySeanceId(transactionManager, key.SeanceId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Seance index.
		/// </summary>
		/// <param name="_seanceId"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Seance"/> class.</returns>
		public Ekip.Framework.Entities.Seance GetBySeanceId(System.Int32 _seanceId)
		{
			int count = -1;
			return GetBySeanceId(null,_seanceId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Seance index.
		/// </summary>
		/// <param name="_seanceId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Seance"/> class.</returns>
		public Ekip.Framework.Entities.Seance GetBySeanceId(System.Int32 _seanceId, int start, int pageLength)
		{
			int count = -1;
			return GetBySeanceId(null, _seanceId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Seance index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_seanceId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Seance"/> class.</returns>
		public Ekip.Framework.Entities.Seance GetBySeanceId(TransactionManager transactionManager, System.Int32 _seanceId)
		{
			int count = -1;
			return GetBySeanceId(transactionManager, _seanceId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Seance index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_seanceId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Seance"/> class.</returns>
		public Ekip.Framework.Entities.Seance GetBySeanceId(TransactionManager transactionManager, System.Int32 _seanceId, int start, int pageLength)
		{
			int count = -1;
			return GetBySeanceId(transactionManager, _seanceId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Seance index.
		/// </summary>
		/// <param name="_seanceId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Seance"/> class.</returns>
		public Ekip.Framework.Entities.Seance GetBySeanceId(System.Int32 _seanceId, int start, int pageLength, out int count)
		{
			return GetBySeanceId(null, _seanceId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Seance index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_seanceId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Seance"/> class.</returns>
		public abstract Ekip.Framework.Entities.Seance GetBySeanceId(TransactionManager transactionManager, System.Int32 _seanceId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region Seance_DeleteBySeanceID 
		
		/// <summary>
		///	This method wrap the 'Seance_DeleteBySeanceID' stored procedure. 
		/// </summary>
		/// <param name="seanceId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void DeleteBySeanceID(System.Int32? seanceId)
		{
			 DeleteBySeanceID(null, 0, int.MaxValue , seanceId);
		}
		
		/// <summary>
		///	This method wrap the 'Seance_DeleteBySeanceID' stored procedure. 
		/// </summary>
		/// <param name="seanceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void DeleteBySeanceID(int start, int pageLength, System.Int32? seanceId)
		{
			 DeleteBySeanceID(null, start, pageLength , seanceId);
		}
				
		/// <summary>
		///	This method wrap the 'Seance_DeleteBySeanceID' stored procedure. 
		/// </summary>
		/// <param name="seanceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void DeleteBySeanceID(TransactionManager transactionManager, System.Int32? seanceId)
		{
			 DeleteBySeanceID(transactionManager, 0, int.MaxValue , seanceId);
		}
		
		/// <summary>
		///	This method wrap the 'Seance_DeleteBySeanceID' stored procedure. 
		/// </summary>
		/// <param name="seanceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void DeleteBySeanceID(TransactionManager transactionManager, int start, int pageLength , System.Int32? seanceId);
		
		#endregion
		
		#region Seance_DeleteByClientID 
		
		/// <summary>
		///	This method wrap the 'Seance_DeleteByClientID' stored procedure. 
		/// </summary>
		/// <param name="clientId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void DeleteByClientID(System.Int32? clientId)
		{
			 DeleteByClientID(null, 0, int.MaxValue , clientId);
		}
		
		/// <summary>
		///	This method wrap the 'Seance_DeleteByClientID' stored procedure. 
		/// </summary>
		/// <param name="clientId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void DeleteByClientID(int start, int pageLength, System.Int32? clientId)
		{
			 DeleteByClientID(null, start, pageLength , clientId);
		}
				
		/// <summary>
		///	This method wrap the 'Seance_DeleteByClientID' stored procedure. 
		/// </summary>
		/// <param name="clientId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void DeleteByClientID(TransactionManager transactionManager, System.Int32? clientId)
		{
			 DeleteByClientID(transactionManager, 0, int.MaxValue , clientId);
		}
		
		/// <summary>
		///	This method wrap the 'Seance_DeleteByClientID' stored procedure. 
		/// </summary>
		/// <param name="clientId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void DeleteByClientID(TransactionManager transactionManager, int start, int pageLength , System.Int32? clientId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Seance&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Seance&gt;"/></returns>
		public static TList<Seance> Fill(IDataReader reader, TList<Seance> rows, int start, int pageLength)
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
				
				Ekip.Framework.Entities.Seance c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Seance")
					.Append("|").Append((System.Int32)reader[((int)SeanceColumn.SeanceId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Seance>(
					key.ToString(), // EntityTrackingKey
					"Seance",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Ekip.Framework.Entities.Seance();
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
					c.SeanceId = (System.Int32)reader[((int)SeanceColumn.SeanceId - 1)];
					c.ClientId = (System.Int32)reader[((int)SeanceColumn.ClientId - 1)];
					c.AdvisorId = (System.Int32)reader[((int)SeanceColumn.AdvisorId - 1)];
					c.SeanceDate = (reader.IsDBNull(((int)SeanceColumn.SeanceDate - 1)))?null:(System.DateTime?)reader[((int)SeanceColumn.SeanceDate - 1)];
					c.SeanceTime = (reader.IsDBNull(((int)SeanceColumn.SeanceTime - 1)))?null:(System.TimeSpan?)reader[((int)SeanceColumn.SeanceTime - 1)];
					c.Notes = (reader.IsDBNull(((int)SeanceColumn.Notes - 1)))?null:(System.String)reader[((int)SeanceColumn.Notes - 1)];
					c.SeanceStatusId = (System.Byte)reader[((int)SeanceColumn.SeanceStatusId - 1)];
					c.CreateDate = (System.DateTime)reader[((int)SeanceColumn.CreateDate - 1)];
					c.UpdateDate = (reader.IsDBNull(((int)SeanceColumn.UpdateDate - 1)))?null:(System.DateTime?)reader[((int)SeanceColumn.UpdateDate - 1)];
					c.CreatedUserId = (reader.IsDBNull(((int)SeanceColumn.CreatedUserId - 1)))?null:(System.Int32?)reader[((int)SeanceColumn.CreatedUserId - 1)];
					c.UpdatedUserId = (reader.IsDBNull(((int)SeanceColumn.UpdatedUserId - 1)))?null:(System.Int32?)reader[((int)SeanceColumn.UpdatedUserId - 1)];
					c.Active = (System.Boolean)reader[((int)SeanceColumn.Active - 1)];
					c.Deleted = (System.Boolean)reader[((int)SeanceColumn.Deleted - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.Seance"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Seance"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Ekip.Framework.Entities.Seance entity)
		{
			if (!reader.Read()) return;
			
			entity.SeanceId = (System.Int32)reader[((int)SeanceColumn.SeanceId - 1)];
			entity.ClientId = (System.Int32)reader[((int)SeanceColumn.ClientId - 1)];
			entity.AdvisorId = (System.Int32)reader[((int)SeanceColumn.AdvisorId - 1)];
			entity.SeanceDate = (reader.IsDBNull(((int)SeanceColumn.SeanceDate - 1)))?null:(System.DateTime?)reader[((int)SeanceColumn.SeanceDate - 1)];
			entity.SeanceTime = (reader.IsDBNull(((int)SeanceColumn.SeanceTime - 1)))?null:(System.TimeSpan?)reader[((int)SeanceColumn.SeanceTime - 1)];
			entity.Notes = (reader.IsDBNull(((int)SeanceColumn.Notes - 1)))?null:(System.String)reader[((int)SeanceColumn.Notes - 1)];
			entity.SeanceStatusId = (System.Byte)reader[((int)SeanceColumn.SeanceStatusId - 1)];
			entity.CreateDate = (System.DateTime)reader[((int)SeanceColumn.CreateDate - 1)];
			entity.UpdateDate = (reader.IsDBNull(((int)SeanceColumn.UpdateDate - 1)))?null:(System.DateTime?)reader[((int)SeanceColumn.UpdateDate - 1)];
			entity.CreatedUserId = (reader.IsDBNull(((int)SeanceColumn.CreatedUserId - 1)))?null:(System.Int32?)reader[((int)SeanceColumn.CreatedUserId - 1)];
			entity.UpdatedUserId = (reader.IsDBNull(((int)SeanceColumn.UpdatedUserId - 1)))?null:(System.Int32?)reader[((int)SeanceColumn.UpdatedUserId - 1)];
			entity.Active = (System.Boolean)reader[((int)SeanceColumn.Active - 1)];
			entity.Deleted = (System.Boolean)reader[((int)SeanceColumn.Deleted - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.Seance"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Seance"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Ekip.Framework.Entities.Seance entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.SeanceId = (System.Int32)dataRow["SeanceId"];
			entity.ClientId = (System.Int32)dataRow["ClientId"];
			entity.AdvisorId = (System.Int32)dataRow["AdvisorId"];
			entity.SeanceDate = Convert.IsDBNull(dataRow["SeanceDate"]) ? null : (System.DateTime?)dataRow["SeanceDate"];
			entity.SeanceTime = Convert.IsDBNull(dataRow["SeanceTime"]) ? null : (System.TimeSpan?)dataRow["SeanceTime"];
			entity.Notes = Convert.IsDBNull(dataRow["Notes"]) ? null : (System.String)dataRow["Notes"];
			entity.SeanceStatusId = (System.Byte)dataRow["SeanceStatusId"];
			entity.CreateDate = (System.DateTime)dataRow["CreateDate"];
			entity.UpdateDate = Convert.IsDBNull(dataRow["UpdateDate"]) ? null : (System.DateTime?)dataRow["UpdateDate"];
			entity.CreatedUserId = Convert.IsDBNull(dataRow["CreatedUserId"]) ? null : (System.Int32?)dataRow["CreatedUserId"];
			entity.UpdatedUserId = Convert.IsDBNull(dataRow["UpdatedUserId"]) ? null : (System.Int32?)dataRow["UpdatedUserId"];
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
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Seance"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.Seance Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Ekip.Framework.Entities.Seance entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetBySeanceId methods when available
			
			#region SeanceReasonCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SeanceReason>|SeanceReasonCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SeanceReasonCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SeanceReasonCollection = DataRepository.SeanceReasonProvider.GetBySeanceId(transactionManager, entity.SeanceId);

				if (deep && entity.SeanceReasonCollection.Count > 0)
				{
					deepHandles.Add("SeanceReasonCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SeanceReason>) DataRepository.SeanceReasonProvider.DeepLoad,
						new object[] { transactionManager, entity.SeanceReasonCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Ekip.Framework.Entities.Seance object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Ekip.Framework.Entities.Seance instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.Seance Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Ekip.Framework.Entities.Seance entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<SeanceReason>
				if (CanDeepSave(entity.SeanceReasonCollection, "List<SeanceReason>|SeanceReasonCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SeanceReason child in entity.SeanceReasonCollection)
					{
						if(child.SeanceIdSource != null)
						{
							child.SeanceId = child.SeanceIdSource.SeanceId;
						}
						else
						{
							child.SeanceId = entity.SeanceId;
						}

					}

					if (entity.SeanceReasonCollection.Count > 0 || entity.SeanceReasonCollection.DeletedItems.Count > 0)
					{
						//DataRepository.SeanceReasonProvider.Save(transactionManager, entity.SeanceReasonCollection);
						
						deepHandles.Add("SeanceReasonCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SeanceReason >) DataRepository.SeanceReasonProvider.DeepSave,
							new object[] { transactionManager, entity.SeanceReasonCollection, deepSaveType, childTypes, innerList }
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
	
	#region SeanceChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Ekip.Framework.Entities.Seance</c>
	///</summary>
	public enum SeanceChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Client</c> at ClientIdSource
		///</summary>
		[ChildEntityType(typeof(Client))]
		Client,
	
		///<summary>
		/// Collection of <c>Seance</c> as OneToMany for SeanceReasonCollection
		///</summary>
		[ChildEntityType(typeof(TList<SeanceReason>))]
		SeanceReasonCollection,
	}
	
	#endregion SeanceChildEntityTypes
	
	#region SeanceFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;SeanceColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Seance"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SeanceFilterBuilder : SqlFilterBuilder<SeanceColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SeanceFilterBuilder class.
		/// </summary>
		public SeanceFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SeanceFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SeanceFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SeanceFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SeanceFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SeanceFilterBuilder
	
	#region SeanceParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;SeanceColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Seance"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SeanceParameterBuilder : ParameterizedSqlFilterBuilder<SeanceColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SeanceParameterBuilder class.
		/// </summary>
		public SeanceParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SeanceParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SeanceParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SeanceParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SeanceParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SeanceParameterBuilder
	
	#region SeanceSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;SeanceColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Seance"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class SeanceSortBuilder : SqlSortBuilder<SeanceColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SeanceSqlSortBuilder class.
		/// </summary>
		public SeanceSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion SeanceSortBuilder
	
} // end namespace
