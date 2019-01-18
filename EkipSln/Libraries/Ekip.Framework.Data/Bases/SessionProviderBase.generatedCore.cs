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
	/// This class is the base class for any <see cref="SessionProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SessionProviderBaseCore : EntityProviderBase<Ekip.Framework.Entities.Session, Ekip.Framework.Entities.SessionKey>
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
		public override bool Delete(TransactionManager transactionManager, Ekip.Framework.Entities.SessionKey key)
		{
			return Delete(transactionManager, key.SessionId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_sessionId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _sessionId)
		{
			return Delete(null, _sessionId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_sessionId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _sessionId);		
		
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
		public override Ekip.Framework.Entities.Session Get(TransactionManager transactionManager, Ekip.Framework.Entities.SessionKey key, int start, int pageLength)
		{
			return GetBySessionId(transactionManager, key.SessionId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Session_Password index.
		/// </summary>
		/// <param name="_password"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Session"/> class.</returns>
		public Ekip.Framework.Entities.Session GetByPassword(System.String _password)
		{
			int count = -1;
			return GetByPassword(null,_password, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Session_Password index.
		/// </summary>
		/// <param name="_password"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Session"/> class.</returns>
		public Ekip.Framework.Entities.Session GetByPassword(System.String _password, int start, int pageLength)
		{
			int count = -1;
			return GetByPassword(null, _password, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Session_Password index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_password"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Session"/> class.</returns>
		public Ekip.Framework.Entities.Session GetByPassword(TransactionManager transactionManager, System.String _password)
		{
			int count = -1;
			return GetByPassword(transactionManager, _password, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Session_Password index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_password"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Session"/> class.</returns>
		public Ekip.Framework.Entities.Session GetByPassword(TransactionManager transactionManager, System.String _password, int start, int pageLength)
		{
			int count = -1;
			return GetByPassword(transactionManager, _password, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Session_Password index.
		/// </summary>
		/// <param name="_password"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Session"/> class.</returns>
		public Ekip.Framework.Entities.Session GetByPassword(System.String _password, int start, int pageLength, out int count)
		{
			return GetByPassword(null, _password, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Session_Password index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_password"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Session"/> class.</returns>
		public abstract Ekip.Framework.Entities.Session GetByPassword(TransactionManager transactionManager, System.String _password, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Session_UserName index.
		/// </summary>
		/// <param name="_userName"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Session"/> class.</returns>
		public Ekip.Framework.Entities.Session GetByUserName(System.String _userName)
		{
			int count = -1;
			return GetByUserName(null,_userName, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Session_UserName index.
		/// </summary>
		/// <param name="_userName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Session"/> class.</returns>
		public Ekip.Framework.Entities.Session GetByUserName(System.String _userName, int start, int pageLength)
		{
			int count = -1;
			return GetByUserName(null, _userName, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Session_UserName index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userName"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Session"/> class.</returns>
		public Ekip.Framework.Entities.Session GetByUserName(TransactionManager transactionManager, System.String _userName)
		{
			int count = -1;
			return GetByUserName(transactionManager, _userName, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Session_UserName index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Session"/> class.</returns>
		public Ekip.Framework.Entities.Session GetByUserName(TransactionManager transactionManager, System.String _userName, int start, int pageLength)
		{
			int count = -1;
			return GetByUserName(transactionManager, _userName, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Session_UserName index.
		/// </summary>
		/// <param name="_userName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Session"/> class.</returns>
		public Ekip.Framework.Entities.Session GetByUserName(System.String _userName, int start, int pageLength, out int count)
		{
			return GetByUserName(null, _userName, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Session_UserName index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Session"/> class.</returns>
		public abstract Ekip.Framework.Entities.Session GetByUserName(TransactionManager transactionManager, System.String _userName, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Session index.
		/// </summary>
		/// <param name="_sessionId"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Session"/> class.</returns>
		public Ekip.Framework.Entities.Session GetBySessionId(System.Int32 _sessionId)
		{
			int count = -1;
			return GetBySessionId(null,_sessionId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Session index.
		/// </summary>
		/// <param name="_sessionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Session"/> class.</returns>
		public Ekip.Framework.Entities.Session GetBySessionId(System.Int32 _sessionId, int start, int pageLength)
		{
			int count = -1;
			return GetBySessionId(null, _sessionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Session index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_sessionId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Session"/> class.</returns>
		public Ekip.Framework.Entities.Session GetBySessionId(TransactionManager transactionManager, System.Int32 _sessionId)
		{
			int count = -1;
			return GetBySessionId(transactionManager, _sessionId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Session index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_sessionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Session"/> class.</returns>
		public Ekip.Framework.Entities.Session GetBySessionId(TransactionManager transactionManager, System.Int32 _sessionId, int start, int pageLength)
		{
			int count = -1;
			return GetBySessionId(transactionManager, _sessionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Session index.
		/// </summary>
		/// <param name="_sessionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Session"/> class.</returns>
		public Ekip.Framework.Entities.Session GetBySessionId(System.Int32 _sessionId, int start, int pageLength, out int count)
		{
			return GetBySessionId(null, _sessionId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Session index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_sessionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Session"/> class.</returns>
		public abstract Ekip.Framework.Entities.Session GetBySessionId(TransactionManager transactionManager, System.Int32 _sessionId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region Session_Get 
		
		/// <summary>
		///	This method wrap the 'Session_Get' stored procedure. 
		/// </summary>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="password"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Session&gt;"/> instance.</returns>
		public TList<Session> Get(System.String userName, System.String password)
		{
			return Get(null, 0, int.MaxValue , userName, password);
		}
		
		/// <summary>
		///	This method wrap the 'Session_Get' stored procedure. 
		/// </summary>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="password"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Session&gt;"/> instance.</returns>
		public TList<Session> Get(int start, int pageLength, System.String userName, System.String password)
		{
			return Get(null, start, pageLength , userName, password);
		}
				
		/// <summary>
		///	This method wrap the 'Session_Get' stored procedure. 
		/// </summary>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="password"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Session&gt;"/> instance.</returns>
		public TList<Session> Get(TransactionManager transactionManager, System.String userName, System.String password)
		{
			return Get(transactionManager, 0, int.MaxValue , userName, password);
		}
		
		/// <summary>
		///	This method wrap the 'Session_Get' stored procedure. 
		/// </summary>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="password"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Session&gt;"/> instance.</returns>
		public abstract TList<Session> Get(TransactionManager transactionManager, int start, int pageLength , System.String userName, System.String password);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Session&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Session&gt;"/></returns>
		public static TList<Session> Fill(IDataReader reader, TList<Session> rows, int start, int pageLength)
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
				
				Ekip.Framework.Entities.Session c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Session")
					.Append("|").Append((System.Int32)reader[((int)SessionColumn.SessionId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Session>(
					key.ToString(), // EntityTrackingKey
					"Session",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Ekip.Framework.Entities.Session();
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
					c.SessionId = (System.Int32)reader[((int)SessionColumn.SessionId - 1)];
					c.UserName = (reader.IsDBNull(((int)SessionColumn.UserName - 1)))?null:(System.String)reader[((int)SessionColumn.UserName - 1)];
					c.Password = (reader.IsDBNull(((int)SessionColumn.Password - 1)))?null:(System.String)reader[((int)SessionColumn.Password - 1)];
					c.CreateOn = (System.DateTime)reader[((int)SessionColumn.CreateOn - 1)];
					c.UpdateOn = (reader.IsDBNull(((int)SessionColumn.UpdateOn - 1)))?null:(System.DateTime?)reader[((int)SessionColumn.UpdateOn - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.Session"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Session"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Ekip.Framework.Entities.Session entity)
		{
			if (!reader.Read()) return;
			
			entity.SessionId = (System.Int32)reader[((int)SessionColumn.SessionId - 1)];
			entity.UserName = (reader.IsDBNull(((int)SessionColumn.UserName - 1)))?null:(System.String)reader[((int)SessionColumn.UserName - 1)];
			entity.Password = (reader.IsDBNull(((int)SessionColumn.Password - 1)))?null:(System.String)reader[((int)SessionColumn.Password - 1)];
			entity.CreateOn = (System.DateTime)reader[((int)SessionColumn.CreateOn - 1)];
			entity.UpdateOn = (reader.IsDBNull(((int)SessionColumn.UpdateOn - 1)))?null:(System.DateTime?)reader[((int)SessionColumn.UpdateOn - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.Session"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Session"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Ekip.Framework.Entities.Session entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.SessionId = (System.Int32)dataRow["SessionID"];
			entity.UserName = Convert.IsDBNull(dataRow["UserName"]) ? null : (System.String)dataRow["UserName"];
			entity.Password = Convert.IsDBNull(dataRow["Password"]) ? null : (System.String)dataRow["Password"];
			entity.CreateOn = (System.DateTime)dataRow["CreateOn"];
			entity.UpdateOn = Convert.IsDBNull(dataRow["UpdateOn"]) ? null : (System.DateTime?)dataRow["UpdateOn"];
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
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Session"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.Session Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Ekip.Framework.Entities.Session entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the Ekip.Framework.Entities.Session object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Ekip.Framework.Entities.Session instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.Session Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Ekip.Framework.Entities.Session entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region SessionChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Ekip.Framework.Entities.Session</c>
	///</summary>
	public enum SessionChildEntityTypes
	{
	}
	
	#endregion SessionChildEntityTypes
	
	#region SessionFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;SessionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Session"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SessionFilterBuilder : SqlFilterBuilder<SessionColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SessionFilterBuilder class.
		/// </summary>
		public SessionFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SessionFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SessionFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SessionFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SessionFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SessionFilterBuilder
	
	#region SessionParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;SessionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Session"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SessionParameterBuilder : ParameterizedSqlFilterBuilder<SessionColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SessionParameterBuilder class.
		/// </summary>
		public SessionParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SessionParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SessionParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SessionParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SessionParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SessionParameterBuilder
	
	#region SessionSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;SessionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Session"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class SessionSortBuilder : SqlSortBuilder<SessionColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SessionSqlSortBuilder class.
		/// </summary>
		public SessionSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion SessionSortBuilder
	
} // end namespace
