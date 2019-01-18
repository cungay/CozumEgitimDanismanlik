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
	/// This class is the base class for any <see cref="ClientEducationProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ClientEducationProviderBaseCore : EntityProviderBase<Ekip.Framework.Entities.ClientEducation, Ekip.Framework.Entities.ClientEducationKey>
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
		public override bool Delete(TransactionManager transactionManager, Ekip.Framework.Entities.ClientEducationKey key)
		{
			return Delete(transactionManager, key.EducationId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_educationId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _educationId)
		{
			return Delete(null, _educationId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_educationId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _educationId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClientEducation_Client key.
		///		FK_ClientEducation_Client Description: 
		/// </summary>
		/// <param name="_clientId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ClientEducation objects.</returns>
		public TList<ClientEducation> GetByClientId(System.Int32 _clientId)
		{
			int count = -1;
			return GetByClientId(_clientId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClientEducation_Client key.
		///		FK_ClientEducation_Client Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_clientId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ClientEducation objects.</returns>
		/// <remarks></remarks>
		public TList<ClientEducation> GetByClientId(TransactionManager transactionManager, System.Int32 _clientId)
		{
			int count = -1;
			return GetByClientId(transactionManager, _clientId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClientEducation_Client key.
		///		FK_ClientEducation_Client Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_clientId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ClientEducation objects.</returns>
		public TList<ClientEducation> GetByClientId(TransactionManager transactionManager, System.Int32 _clientId, int start, int pageLength)
		{
			int count = -1;
			return GetByClientId(transactionManager, _clientId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClientEducation_Client key.
		///		fkClientEducationClient Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_clientId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ClientEducation objects.</returns>
		public TList<ClientEducation> GetByClientId(System.Int32 _clientId, int start, int pageLength)
		{
			int count =  -1;
			return GetByClientId(null, _clientId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClientEducation_Client key.
		///		fkClientEducationClient Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_clientId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ClientEducation objects.</returns>
		public TList<ClientEducation> GetByClientId(System.Int32 _clientId, int start, int pageLength,out int count)
		{
			return GetByClientId(null, _clientId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClientEducation_Client key.
		///		FK_ClientEducation_Client Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_clientId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ClientEducation objects.</returns>
		public abstract TList<ClientEducation> GetByClientId(TransactionManager transactionManager, System.Int32 _clientId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClientEducation_School key.
		///		FK_ClientEducation_School Description: 
		/// </summary>
		/// <param name="_schoolId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ClientEducation objects.</returns>
		public TList<ClientEducation> GetBySchoolId(System.Int32 _schoolId)
		{
			int count = -1;
			return GetBySchoolId(_schoolId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClientEducation_School key.
		///		FK_ClientEducation_School Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_schoolId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ClientEducation objects.</returns>
		/// <remarks></remarks>
		public TList<ClientEducation> GetBySchoolId(TransactionManager transactionManager, System.Int32 _schoolId)
		{
			int count = -1;
			return GetBySchoolId(transactionManager, _schoolId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClientEducation_School key.
		///		FK_ClientEducation_School Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_schoolId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ClientEducation objects.</returns>
		public TList<ClientEducation> GetBySchoolId(TransactionManager transactionManager, System.Int32 _schoolId, int start, int pageLength)
		{
			int count = -1;
			return GetBySchoolId(transactionManager, _schoolId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClientEducation_School key.
		///		fkClientEducationSchool Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_schoolId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ClientEducation objects.</returns>
		public TList<ClientEducation> GetBySchoolId(System.Int32 _schoolId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySchoolId(null, _schoolId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClientEducation_School key.
		///		fkClientEducationSchool Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_schoolId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ClientEducation objects.</returns>
		public TList<ClientEducation> GetBySchoolId(System.Int32 _schoolId, int start, int pageLength,out int count)
		{
			return GetBySchoolId(null, _schoolId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClientEducation_School key.
		///		FK_ClientEducation_School Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_schoolId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ClientEducation objects.</returns>
		public abstract TList<ClientEducation> GetBySchoolId(TransactionManager transactionManager, System.Int32 _schoolId, int start, int pageLength, out int count);
		
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
		public override Ekip.Framework.Entities.ClientEducation Get(TransactionManager transactionManager, Ekip.Framework.Entities.ClientEducationKey key, int start, int pageLength)
		{
			return GetByEducationId(transactionManager, key.EducationId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ClientEducation index.
		/// </summary>
		/// <param name="_educationId"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ClientEducation"/> class.</returns>
		public Ekip.Framework.Entities.ClientEducation GetByEducationId(System.Int32 _educationId)
		{
			int count = -1;
			return GetByEducationId(null,_educationId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ClientEducation index.
		/// </summary>
		/// <param name="_educationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ClientEducation"/> class.</returns>
		public Ekip.Framework.Entities.ClientEducation GetByEducationId(System.Int32 _educationId, int start, int pageLength)
		{
			int count = -1;
			return GetByEducationId(null, _educationId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ClientEducation index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_educationId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ClientEducation"/> class.</returns>
		public Ekip.Framework.Entities.ClientEducation GetByEducationId(TransactionManager transactionManager, System.Int32 _educationId)
		{
			int count = -1;
			return GetByEducationId(transactionManager, _educationId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ClientEducation index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_educationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ClientEducation"/> class.</returns>
		public Ekip.Framework.Entities.ClientEducation GetByEducationId(TransactionManager transactionManager, System.Int32 _educationId, int start, int pageLength)
		{
			int count = -1;
			return GetByEducationId(transactionManager, _educationId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ClientEducation index.
		/// </summary>
		/// <param name="_educationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ClientEducation"/> class.</returns>
		public Ekip.Framework.Entities.ClientEducation GetByEducationId(System.Int32 _educationId, int start, int pageLength, out int count)
		{
			return GetByEducationId(null, _educationId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ClientEducation index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_educationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ClientEducation"/> class.</returns>
		public abstract Ekip.Framework.Entities.ClientEducation GetByEducationId(TransactionManager transactionManager, System.Int32 _educationId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;ClientEducation&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;ClientEducation&gt;"/></returns>
		public static TList<ClientEducation> Fill(IDataReader reader, TList<ClientEducation> rows, int start, int pageLength)
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
				
				Ekip.Framework.Entities.ClientEducation c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ClientEducation")
					.Append("|").Append((System.Int32)reader[((int)ClientEducationColumn.EducationId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<ClientEducation>(
					key.ToString(), // EntityTrackingKey
					"ClientEducation",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Ekip.Framework.Entities.ClientEducation();
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
					c.EducationId = (System.Int32)reader[((int)ClientEducationColumn.EducationId - 1)];
					c.ClientId = (System.Int32)reader[((int)ClientEducationColumn.ClientId - 1)];
					c.SchoolId = (System.Int32)reader[((int)ClientEducationColumn.SchoolId - 1)];
					c.ClassRoom = (System.String)reader[((int)ClientEducationColumn.ClassRoom - 1)];
					c.TeacherId = (reader.IsDBNull(((int)ClientEducationColumn.TeacherId - 1)))?null:(System.Int32?)reader[((int)ClientEducationColumn.TeacherId - 1)];
					c.Notes = (reader.IsDBNull(((int)ClientEducationColumn.Notes - 1)))?null:(System.String)reader[((int)ClientEducationColumn.Notes - 1)];
					c.CreateDate = (System.DateTime)reader[((int)ClientEducationColumn.CreateDate - 1)];
					c.UpdateDate = (reader.IsDBNull(((int)ClientEducationColumn.UpdateDate - 1)))?null:(System.DateTime?)reader[((int)ClientEducationColumn.UpdateDate - 1)];
					c.CreateUserId = (System.Int32)reader[((int)ClientEducationColumn.CreateUserId - 1)];
					c.UpdateUserId = (reader.IsDBNull(((int)ClientEducationColumn.UpdateUserId - 1)))?null:(System.Int32?)reader[((int)ClientEducationColumn.UpdateUserId - 1)];
					c.Active = (System.Boolean)reader[((int)ClientEducationColumn.Active - 1)];
					c.Deleted = (System.Boolean)reader[((int)ClientEducationColumn.Deleted - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.ClientEducation"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.ClientEducation"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Ekip.Framework.Entities.ClientEducation entity)
		{
			if (!reader.Read()) return;
			
			entity.EducationId = (System.Int32)reader[((int)ClientEducationColumn.EducationId - 1)];
			entity.ClientId = (System.Int32)reader[((int)ClientEducationColumn.ClientId - 1)];
			entity.SchoolId = (System.Int32)reader[((int)ClientEducationColumn.SchoolId - 1)];
			entity.ClassRoom = (System.String)reader[((int)ClientEducationColumn.ClassRoom - 1)];
			entity.TeacherId = (reader.IsDBNull(((int)ClientEducationColumn.TeacherId - 1)))?null:(System.Int32?)reader[((int)ClientEducationColumn.TeacherId - 1)];
			entity.Notes = (reader.IsDBNull(((int)ClientEducationColumn.Notes - 1)))?null:(System.String)reader[((int)ClientEducationColumn.Notes - 1)];
			entity.CreateDate = (System.DateTime)reader[((int)ClientEducationColumn.CreateDate - 1)];
			entity.UpdateDate = (reader.IsDBNull(((int)ClientEducationColumn.UpdateDate - 1)))?null:(System.DateTime?)reader[((int)ClientEducationColumn.UpdateDate - 1)];
			entity.CreateUserId = (System.Int32)reader[((int)ClientEducationColumn.CreateUserId - 1)];
			entity.UpdateUserId = (reader.IsDBNull(((int)ClientEducationColumn.UpdateUserId - 1)))?null:(System.Int32?)reader[((int)ClientEducationColumn.UpdateUserId - 1)];
			entity.Active = (System.Boolean)reader[((int)ClientEducationColumn.Active - 1)];
			entity.Deleted = (System.Boolean)reader[((int)ClientEducationColumn.Deleted - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.ClientEducation"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.ClientEducation"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Ekip.Framework.Entities.ClientEducation entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.EducationId = (System.Int32)dataRow["EducationId"];
			entity.ClientId = (System.Int32)dataRow["ClientId"];
			entity.SchoolId = (System.Int32)dataRow["SchoolId"];
			entity.ClassRoom = (System.String)dataRow["ClassRoom"];
			entity.TeacherId = Convert.IsDBNull(dataRow["TeacherId"]) ? null : (System.Int32?)dataRow["TeacherId"];
			entity.Notes = Convert.IsDBNull(dataRow["Notes"]) ? null : (System.String)dataRow["Notes"];
			entity.CreateDate = (System.DateTime)dataRow["CreateDate"];
			entity.UpdateDate = Convert.IsDBNull(dataRow["UpdateDate"]) ? null : (System.DateTime?)dataRow["UpdateDate"];
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
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.ClientEducation"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.ClientEducation Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Ekip.Framework.Entities.ClientEducation entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the Ekip.Framework.Entities.ClientEducation object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Ekip.Framework.Entities.ClientEducation instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.ClientEducation Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Ekip.Framework.Entities.ClientEducation entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region ClientEducationChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Ekip.Framework.Entities.ClientEducation</c>
	///</summary>
	public enum ClientEducationChildEntityTypes
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
	
	#endregion ClientEducationChildEntityTypes
	
	#region ClientEducationFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ClientEducationColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClientEducation"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClientEducationFilterBuilder : SqlFilterBuilder<ClientEducationColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClientEducationFilterBuilder class.
		/// </summary>
		public ClientEducationFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ClientEducationFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ClientEducationFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ClientEducationFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ClientEducationFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ClientEducationFilterBuilder
	
	#region ClientEducationParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ClientEducationColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClientEducation"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClientEducationParameterBuilder : ParameterizedSqlFilterBuilder<ClientEducationColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClientEducationParameterBuilder class.
		/// </summary>
		public ClientEducationParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ClientEducationParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ClientEducationParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ClientEducationParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ClientEducationParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ClientEducationParameterBuilder
	
	#region ClientEducationSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ClientEducationColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClientEducation"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ClientEducationSortBuilder : SqlSortBuilder<ClientEducationColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClientEducationSqlSortBuilder class.
		/// </summary>
		public ClientEducationSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ClientEducationSortBuilder
	
} // end namespace
