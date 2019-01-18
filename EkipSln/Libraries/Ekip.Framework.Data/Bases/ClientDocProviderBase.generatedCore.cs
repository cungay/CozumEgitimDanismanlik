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
	/// This class is the base class for any <see cref="ClientDocProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ClientDocProviderBaseCore : EntityProviderBase<Ekip.Framework.Entities.ClientDoc, Ekip.Framework.Entities.ClientDocKey>
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
		public override bool Delete(TransactionManager transactionManager, Ekip.Framework.Entities.ClientDocKey key)
		{
			return Delete(transactionManager, key.ClientDocId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_clientDocId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _clientDocId)
		{
			return Delete(null, _clientDocId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_clientDocId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _clientDocId);		
		
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
		public override Ekip.Framework.Entities.ClientDoc Get(TransactionManager transactionManager, Ekip.Framework.Entities.ClientDocKey key, int start, int pageLength)
		{
			return GetByClientDocId(transactionManager, key.ClientDocId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_ClientDoc_ClientId index.
		/// </summary>
		/// <param name="_clientId"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;ClientDoc&gt;"/> class.</returns>
		public TList<ClientDoc> GetByClientId(System.Int32 _clientId)
		{
			int count = -1;
			return GetByClientId(null,_clientId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ClientDoc_ClientId index.
		/// </summary>
		/// <param name="_clientId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;ClientDoc&gt;"/> class.</returns>
		public TList<ClientDoc> GetByClientId(System.Int32 _clientId, int start, int pageLength)
		{
			int count = -1;
			return GetByClientId(null, _clientId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ClientDoc_ClientId index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_clientId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;ClientDoc&gt;"/> class.</returns>
		public TList<ClientDoc> GetByClientId(TransactionManager transactionManager, System.Int32 _clientId)
		{
			int count = -1;
			return GetByClientId(transactionManager, _clientId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ClientDoc_ClientId index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_clientId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;ClientDoc&gt;"/> class.</returns>
		public TList<ClientDoc> GetByClientId(TransactionManager transactionManager, System.Int32 _clientId, int start, int pageLength)
		{
			int count = -1;
			return GetByClientId(transactionManager, _clientId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ClientDoc_ClientId index.
		/// </summary>
		/// <param name="_clientId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;ClientDoc&gt;"/> class.</returns>
		public TList<ClientDoc> GetByClientId(System.Int32 _clientId, int start, int pageLength, out int count)
		{
			return GetByClientId(null, _clientId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ClientDoc_ClientId index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_clientId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;ClientDoc&gt;"/> class.</returns>
		public abstract TList<ClientDoc> GetByClientId(TransactionManager transactionManager, System.Int32 _clientId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ClientDoc index.
		/// </summary>
		/// <param name="_clientDocId"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ClientDoc"/> class.</returns>
		public Ekip.Framework.Entities.ClientDoc GetByClientDocId(System.Int32 _clientDocId)
		{
			int count = -1;
			return GetByClientDocId(null,_clientDocId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ClientDoc index.
		/// </summary>
		/// <param name="_clientDocId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ClientDoc"/> class.</returns>
		public Ekip.Framework.Entities.ClientDoc GetByClientDocId(System.Int32 _clientDocId, int start, int pageLength)
		{
			int count = -1;
			return GetByClientDocId(null, _clientDocId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ClientDoc index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_clientDocId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ClientDoc"/> class.</returns>
		public Ekip.Framework.Entities.ClientDoc GetByClientDocId(TransactionManager transactionManager, System.Int32 _clientDocId)
		{
			int count = -1;
			return GetByClientDocId(transactionManager, _clientDocId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ClientDoc index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_clientDocId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ClientDoc"/> class.</returns>
		public Ekip.Framework.Entities.ClientDoc GetByClientDocId(TransactionManager transactionManager, System.Int32 _clientDocId, int start, int pageLength)
		{
			int count = -1;
			return GetByClientDocId(transactionManager, _clientDocId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ClientDoc index.
		/// </summary>
		/// <param name="_clientDocId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ClientDoc"/> class.</returns>
		public Ekip.Framework.Entities.ClientDoc GetByClientDocId(System.Int32 _clientDocId, int start, int pageLength, out int count)
		{
			return GetByClientDocId(null, _clientDocId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ClientDoc index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_clientDocId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ClientDoc"/> class.</returns>
		public abstract Ekip.Framework.Entities.ClientDoc GetByClientDocId(TransactionManager transactionManager, System.Int32 _clientDocId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;ClientDoc&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;ClientDoc&gt;"/></returns>
		public static TList<ClientDoc> Fill(IDataReader reader, TList<ClientDoc> rows, int start, int pageLength)
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
				
				Ekip.Framework.Entities.ClientDoc c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ClientDoc")
					.Append("|").Append((System.Int32)reader[((int)ClientDocColumn.ClientDocId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<ClientDoc>(
					key.ToString(), // EntityTrackingKey
					"ClientDoc",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Ekip.Framework.Entities.ClientDoc();
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
					c.ClientDocId = (System.Int32)reader[((int)ClientDocColumn.ClientDocId - 1)];
					c.OriginalClientDocId = c.ClientDocId;
					c.ClientId = (System.Int32)reader[((int)ClientDocColumn.ClientId - 1)];
					c.FileName = (System.String)reader[((int)ClientDocColumn.FileName - 1)];
					c.FullName = (System.String)reader[((int)ClientDocColumn.FullName - 1)];
					c.FilePath = (System.String)reader[((int)ClientDocColumn.FilePath - 1)];
					c.CreationDate = (System.DateTime)reader[((int)ClientDocColumn.CreationDate - 1)];
					c.CreationTime = (System.TimeSpan)reader[((int)ClientDocColumn.CreationTime - 1)];
					c.FileExtension = (System.String)reader[((int)ClientDocColumn.FileExtension - 1)];
					c.FileSize = (System.Double)reader[((int)ClientDocColumn.FileSize - 1)];
					c.FileContent = (System.Byte[])reader[((int)ClientDocColumn.FileContent - 1)];
					c.Notes = (reader.IsDBNull(((int)ClientDocColumn.Notes - 1)))?null:(System.String)reader[((int)ClientDocColumn.Notes - 1)];
					c.CreateDate = (System.DateTime)reader[((int)ClientDocColumn.CreateDate - 1)];
					c.UpdateDate = (reader.IsDBNull(((int)ClientDocColumn.UpdateDate - 1)))?null:(System.DateTime?)reader[((int)ClientDocColumn.UpdateDate - 1)];
					c.CreateUserId = (System.Int32)reader[((int)ClientDocColumn.CreateUserId - 1)];
					c.UpdateUserId = (reader.IsDBNull(((int)ClientDocColumn.UpdateUserId - 1)))?null:(System.Int32?)reader[((int)ClientDocColumn.UpdateUserId - 1)];
					c.Active = (System.Boolean)reader[((int)ClientDocColumn.Active - 1)];
					c.Deleted = (System.Boolean)reader[((int)ClientDocColumn.Deleted - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.ClientDoc"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.ClientDoc"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Ekip.Framework.Entities.ClientDoc entity)
		{
			if (!reader.Read()) return;
			
			entity.ClientDocId = (System.Int32)reader[((int)ClientDocColumn.ClientDocId - 1)];
			entity.OriginalClientDocId = (System.Int32)reader["ClientDocId"];
			entity.ClientId = (System.Int32)reader[((int)ClientDocColumn.ClientId - 1)];
			entity.FileName = (System.String)reader[((int)ClientDocColumn.FileName - 1)];
			entity.FullName = (System.String)reader[((int)ClientDocColumn.FullName - 1)];
			entity.FilePath = (System.String)reader[((int)ClientDocColumn.FilePath - 1)];
			entity.CreationDate = (System.DateTime)reader[((int)ClientDocColumn.CreationDate - 1)];
			entity.CreationTime = (System.TimeSpan)reader[((int)ClientDocColumn.CreationTime - 1)];
			entity.FileExtension = (System.String)reader[((int)ClientDocColumn.FileExtension - 1)];
			entity.FileSize = (System.Double)reader[((int)ClientDocColumn.FileSize - 1)];
			entity.FileContent = (System.Byte[])reader[((int)ClientDocColumn.FileContent - 1)];
			entity.Notes = (reader.IsDBNull(((int)ClientDocColumn.Notes - 1)))?null:(System.String)reader[((int)ClientDocColumn.Notes - 1)];
			entity.CreateDate = (System.DateTime)reader[((int)ClientDocColumn.CreateDate - 1)];
			entity.UpdateDate = (reader.IsDBNull(((int)ClientDocColumn.UpdateDate - 1)))?null:(System.DateTime?)reader[((int)ClientDocColumn.UpdateDate - 1)];
			entity.CreateUserId = (System.Int32)reader[((int)ClientDocColumn.CreateUserId - 1)];
			entity.UpdateUserId = (reader.IsDBNull(((int)ClientDocColumn.UpdateUserId - 1)))?null:(System.Int32?)reader[((int)ClientDocColumn.UpdateUserId - 1)];
			entity.Active = (System.Boolean)reader[((int)ClientDocColumn.Active - 1)];
			entity.Deleted = (System.Boolean)reader[((int)ClientDocColumn.Deleted - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.ClientDoc"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.ClientDoc"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Ekip.Framework.Entities.ClientDoc entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ClientDocId = (System.Int32)dataRow["ClientDocId"];
			entity.OriginalClientDocId = (System.Int32)dataRow["ClientDocId"];
			entity.ClientId = (System.Int32)dataRow["ClientId"];
			entity.FileName = (System.String)dataRow["FileName"];
			entity.FullName = (System.String)dataRow["FullName"];
			entity.FilePath = (System.String)dataRow["FilePath"];
			entity.CreationDate = (System.DateTime)dataRow["CreationDate"];
			entity.CreationTime = (System.TimeSpan)dataRow["CreationTime"];
			entity.FileExtension = (System.String)dataRow["FileExtension"];
			entity.FileSize = (System.Double)dataRow["FileSize"];
			entity.FileContent = (System.Byte[])dataRow["FileContent"];
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
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.ClientDoc"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.ClientDoc Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Ekip.Framework.Entities.ClientDoc entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
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
		/// Deep Save the entire object graph of the Ekip.Framework.Entities.ClientDoc object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Ekip.Framework.Entities.ClientDoc instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.ClientDoc Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Ekip.Framework.Entities.ClientDoc entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region ClientDocChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Ekip.Framework.Entities.ClientDoc</c>
	///</summary>
	public enum ClientDocChildEntityTypes
	{
	}
	
	#endregion ClientDocChildEntityTypes
	
	#region ClientDocFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ClientDocColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClientDoc"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClientDocFilterBuilder : SqlFilterBuilder<ClientDocColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClientDocFilterBuilder class.
		/// </summary>
		public ClientDocFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ClientDocFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ClientDocFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ClientDocFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ClientDocFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ClientDocFilterBuilder
	
	#region ClientDocParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ClientDocColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClientDoc"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClientDocParameterBuilder : ParameterizedSqlFilterBuilder<ClientDocColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClientDocParameterBuilder class.
		/// </summary>
		public ClientDocParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ClientDocParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ClientDocParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ClientDocParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ClientDocParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ClientDocParameterBuilder
	
	#region ClientDocSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ClientDocColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClientDoc"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ClientDocSortBuilder : SqlSortBuilder<ClientDocColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClientDocSqlSortBuilder class.
		/// </summary>
		public ClientDocSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ClientDocSortBuilder
	
} // end namespace
