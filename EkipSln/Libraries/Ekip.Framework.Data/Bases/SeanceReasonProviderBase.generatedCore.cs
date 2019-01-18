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
	/// This class is the base class for any <see cref="SeanceReasonProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SeanceReasonProviderBaseCore : EntityProviderBase<Ekip.Framework.Entities.SeanceReason, Ekip.Framework.Entities.SeanceReasonKey>
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
		public override bool Delete(TransactionManager transactionManager, Ekip.Framework.Entities.SeanceReasonKey key)
		{
			return Delete(transactionManager, key.RowId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_rowId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _rowId)
		{
			return Delete(null, _rowId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _rowId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Seance_Reason_Reason key.
		///		FK_Seance_Reason_Reason Description: 
		/// </summary>
		/// <param name="_reasonId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.SeanceReason objects.</returns>
		public TList<SeanceReason> GetByReasonId(System.Int32? _reasonId)
		{
			int count = -1;
			return GetByReasonId(_reasonId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Seance_Reason_Reason key.
		///		FK_Seance_Reason_Reason Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_reasonId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.SeanceReason objects.</returns>
		/// <remarks></remarks>
		public TList<SeanceReason> GetByReasonId(TransactionManager transactionManager, System.Int32? _reasonId)
		{
			int count = -1;
			return GetByReasonId(transactionManager, _reasonId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Seance_Reason_Reason key.
		///		FK_Seance_Reason_Reason Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_reasonId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.SeanceReason objects.</returns>
		public TList<SeanceReason> GetByReasonId(TransactionManager transactionManager, System.Int32? _reasonId, int start, int pageLength)
		{
			int count = -1;
			return GetByReasonId(transactionManager, _reasonId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Seance_Reason_Reason key.
		///		fkSeanceReasonReason Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_reasonId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.SeanceReason objects.</returns>
		public TList<SeanceReason> GetByReasonId(System.Int32? _reasonId, int start, int pageLength)
		{
			int count =  -1;
			return GetByReasonId(null, _reasonId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Seance_Reason_Reason key.
		///		fkSeanceReasonReason Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_reasonId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.SeanceReason objects.</returns>
		public TList<SeanceReason> GetByReasonId(System.Int32? _reasonId, int start, int pageLength,out int count)
		{
			return GetByReasonId(null, _reasonId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Seance_Reason_Reason key.
		///		FK_Seance_Reason_Reason Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_reasonId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.SeanceReason objects.</returns>
		public abstract TList<SeanceReason> GetByReasonId(TransactionManager transactionManager, System.Int32? _reasonId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Seance_Reason_Seance key.
		///		FK_Seance_Reason_Seance Description: 
		/// </summary>
		/// <param name="_seanceId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.SeanceReason objects.</returns>
		public TList<SeanceReason> GetBySeanceId(System.Int32? _seanceId)
		{
			int count = -1;
			return GetBySeanceId(_seanceId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Seance_Reason_Seance key.
		///		FK_Seance_Reason_Seance Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_seanceId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.SeanceReason objects.</returns>
		/// <remarks></remarks>
		public TList<SeanceReason> GetBySeanceId(TransactionManager transactionManager, System.Int32? _seanceId)
		{
			int count = -1;
			return GetBySeanceId(transactionManager, _seanceId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Seance_Reason_Seance key.
		///		FK_Seance_Reason_Seance Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_seanceId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.SeanceReason objects.</returns>
		public TList<SeanceReason> GetBySeanceId(TransactionManager transactionManager, System.Int32? _seanceId, int start, int pageLength)
		{
			int count = -1;
			return GetBySeanceId(transactionManager, _seanceId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Seance_Reason_Seance key.
		///		fkSeanceReasonSeance Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_seanceId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.SeanceReason objects.</returns>
		public TList<SeanceReason> GetBySeanceId(System.Int32? _seanceId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySeanceId(null, _seanceId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Seance_Reason_Seance key.
		///		fkSeanceReasonSeance Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_seanceId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.SeanceReason objects.</returns>
		public TList<SeanceReason> GetBySeanceId(System.Int32? _seanceId, int start, int pageLength,out int count)
		{
			return GetBySeanceId(null, _seanceId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Seance_Reason_Seance key.
		///		FK_Seance_Reason_Seance Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_seanceId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.SeanceReason objects.</returns>
		public abstract TList<SeanceReason> GetBySeanceId(TransactionManager transactionManager, System.Int32? _seanceId, int start, int pageLength, out int count);
		
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
		public override Ekip.Framework.Entities.SeanceReason Get(TransactionManager transactionManager, Ekip.Framework.Entities.SeanceReasonKey key, int start, int pageLength)
		{
			return GetByRowId(transactionManager, key.RowId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Seance_Reason index.
		/// </summary>
		/// <param name="_rowId"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.SeanceReason"/> class.</returns>
		public Ekip.Framework.Entities.SeanceReason GetByRowId(System.Int32 _rowId)
		{
			int count = -1;
			return GetByRowId(null,_rowId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Seance_Reason index.
		/// </summary>
		/// <param name="_rowId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.SeanceReason"/> class.</returns>
		public Ekip.Framework.Entities.SeanceReason GetByRowId(System.Int32 _rowId, int start, int pageLength)
		{
			int count = -1;
			return GetByRowId(null, _rowId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Seance_Reason index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.SeanceReason"/> class.</returns>
		public Ekip.Framework.Entities.SeanceReason GetByRowId(TransactionManager transactionManager, System.Int32 _rowId)
		{
			int count = -1;
			return GetByRowId(transactionManager, _rowId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Seance_Reason index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.SeanceReason"/> class.</returns>
		public Ekip.Framework.Entities.SeanceReason GetByRowId(TransactionManager transactionManager, System.Int32 _rowId, int start, int pageLength)
		{
			int count = -1;
			return GetByRowId(transactionManager, _rowId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Seance_Reason index.
		/// </summary>
		/// <param name="_rowId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.SeanceReason"/> class.</returns>
		public Ekip.Framework.Entities.SeanceReason GetByRowId(System.Int32 _rowId, int start, int pageLength, out int count)
		{
			return GetByRowId(null, _rowId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Seance_Reason index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.SeanceReason"/> class.</returns>
		public abstract Ekip.Framework.Entities.SeanceReason GetByRowId(TransactionManager transactionManager, System.Int32 _rowId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;SeanceReason&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;SeanceReason&gt;"/></returns>
		public static TList<SeanceReason> Fill(IDataReader reader, TList<SeanceReason> rows, int start, int pageLength)
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
				
				Ekip.Framework.Entities.SeanceReason c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("SeanceReason")
					.Append("|").Append((System.Int32)reader[((int)SeanceReasonColumn.RowId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<SeanceReason>(
					key.ToString(), // EntityTrackingKey
					"SeanceReason",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Ekip.Framework.Entities.SeanceReason();
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
					c.RowId = (System.Int32)reader[((int)SeanceReasonColumn.RowId - 1)];
					c.SeanceId = (reader.IsDBNull(((int)SeanceReasonColumn.SeanceId - 1)))?null:(System.Int32?)reader[((int)SeanceReasonColumn.SeanceId - 1)];
					c.ReasonId = (reader.IsDBNull(((int)SeanceReasonColumn.ReasonId - 1)))?null:(System.Int32?)reader[((int)SeanceReasonColumn.ReasonId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.SeanceReason"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.SeanceReason"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Ekip.Framework.Entities.SeanceReason entity)
		{
			if (!reader.Read()) return;
			
			entity.RowId = (System.Int32)reader[((int)SeanceReasonColumn.RowId - 1)];
			entity.SeanceId = (reader.IsDBNull(((int)SeanceReasonColumn.SeanceId - 1)))?null:(System.Int32?)reader[((int)SeanceReasonColumn.SeanceId - 1)];
			entity.ReasonId = (reader.IsDBNull(((int)SeanceReasonColumn.ReasonId - 1)))?null:(System.Int32?)reader[((int)SeanceReasonColumn.ReasonId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.SeanceReason"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.SeanceReason"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Ekip.Framework.Entities.SeanceReason entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.RowId = (System.Int32)dataRow["RowId"];
			entity.SeanceId = Convert.IsDBNull(dataRow["SeanceId"]) ? null : (System.Int32?)dataRow["SeanceId"];
			entity.ReasonId = Convert.IsDBNull(dataRow["ReasonId"]) ? null : (System.Int32?)dataRow["ReasonId"];
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
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.SeanceReason"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.SeanceReason Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Ekip.Framework.Entities.SeanceReason entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region ReasonIdSource	
			if (CanDeepLoad(entity, "Reason|ReasonIdSource", deepLoadType, innerList) 
				&& entity.ReasonIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.ReasonId ?? (int)0);
				Reason tmpEntity = EntityManager.LocateEntity<Reason>(EntityLocator.ConstructKeyFromPkItems(typeof(Reason), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ReasonIdSource = tmpEntity;
				else
					entity.ReasonIdSource = DataRepository.ReasonProvider.GetByReasonId(transactionManager, (entity.ReasonId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ReasonIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ReasonIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ReasonProvider.DeepLoad(transactionManager, entity.ReasonIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ReasonIdSource

			#region SeanceIdSource	
			if (CanDeepLoad(entity, "Seance|SeanceIdSource", deepLoadType, innerList) 
				&& entity.SeanceIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.SeanceId ?? (int)0);
				Seance tmpEntity = EntityManager.LocateEntity<Seance>(EntityLocator.ConstructKeyFromPkItems(typeof(Seance), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.SeanceIdSource = tmpEntity;
				else
					entity.SeanceIdSource = DataRepository.SeanceProvider.GetBySeanceId(transactionManager, (entity.SeanceId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SeanceIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.SeanceIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.SeanceProvider.DeepLoad(transactionManager, entity.SeanceIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion SeanceIdSource
			
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
		/// Deep Save the entire object graph of the Ekip.Framework.Entities.SeanceReason object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Ekip.Framework.Entities.SeanceReason instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.SeanceReason Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Ekip.Framework.Entities.SeanceReason entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region ReasonIdSource
			if (CanDeepSave(entity, "Reason|ReasonIdSource", deepSaveType, innerList) 
				&& entity.ReasonIdSource != null)
			{
				DataRepository.ReasonProvider.Save(transactionManager, entity.ReasonIdSource);
				entity.ReasonId = entity.ReasonIdSource.ReasonId;
			}
			#endregion 
			
			#region SeanceIdSource
			if (CanDeepSave(entity, "Seance|SeanceIdSource", deepSaveType, innerList) 
				&& entity.SeanceIdSource != null)
			{
				DataRepository.SeanceProvider.Save(transactionManager, entity.SeanceIdSource);
				entity.SeanceId = entity.SeanceIdSource.SeanceId;
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
	
	#region SeanceReasonChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Ekip.Framework.Entities.SeanceReason</c>
	///</summary>
	public enum SeanceReasonChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Reason</c> at ReasonIdSource
		///</summary>
		[ChildEntityType(typeof(Reason))]
		Reason,
			
		///<summary>
		/// Composite Property for <c>Seance</c> at SeanceIdSource
		///</summary>
		[ChildEntityType(typeof(Seance))]
		Seance,
		}
	
	#endregion SeanceReasonChildEntityTypes
	
	#region SeanceReasonFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;SeanceReasonColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SeanceReason"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SeanceReasonFilterBuilder : SqlFilterBuilder<SeanceReasonColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SeanceReasonFilterBuilder class.
		/// </summary>
		public SeanceReasonFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SeanceReasonFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SeanceReasonFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SeanceReasonFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SeanceReasonFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SeanceReasonFilterBuilder
	
	#region SeanceReasonParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;SeanceReasonColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SeanceReason"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SeanceReasonParameterBuilder : ParameterizedSqlFilterBuilder<SeanceReasonColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SeanceReasonParameterBuilder class.
		/// </summary>
		public SeanceReasonParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SeanceReasonParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SeanceReasonParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SeanceReasonParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SeanceReasonParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SeanceReasonParameterBuilder
	
	#region SeanceReasonSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;SeanceReasonColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SeanceReason"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class SeanceReasonSortBuilder : SqlSortBuilder<SeanceReasonColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SeanceReasonSqlSortBuilder class.
		/// </summary>
		public SeanceReasonSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion SeanceReasonSortBuilder
	
} // end namespace
