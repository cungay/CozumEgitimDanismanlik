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
	/// This class is the base class for any <see cref="ClientFatherProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ClientFatherProviderBaseCore : EntityProviderBase<Ekip.Framework.Entities.ClientFather, Ekip.Framework.Entities.ClientFatherKey>
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
		public override bool Delete(TransactionManager transactionManager, Ekip.Framework.Entities.ClientFatherKey key)
		{
			return Delete(transactionManager, key.FatherId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_fatherId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _fatherId)
		{
			return Delete(null, _fatherId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_fatherId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _fatherId);		
		
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
		public override Ekip.Framework.Entities.ClientFather Get(TransactionManager transactionManager, Ekip.Framework.Entities.ClientFatherKey key, int start, int pageLength)
		{
			return GetByFatherId(transactionManager, key.FatherId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Father index.
		/// </summary>
		/// <param name="_fatherId"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ClientFather"/> class.</returns>
		public Ekip.Framework.Entities.ClientFather GetByFatherId(System.Int32 _fatherId)
		{
			int count = -1;
			return GetByFatherId(null,_fatherId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Father index.
		/// </summary>
		/// <param name="_fatherId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ClientFather"/> class.</returns>
		public Ekip.Framework.Entities.ClientFather GetByFatherId(System.Int32 _fatherId, int start, int pageLength)
		{
			int count = -1;
			return GetByFatherId(null, _fatherId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Father index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_fatherId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ClientFather"/> class.</returns>
		public Ekip.Framework.Entities.ClientFather GetByFatherId(TransactionManager transactionManager, System.Int32 _fatherId)
		{
			int count = -1;
			return GetByFatherId(transactionManager, _fatherId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Father index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_fatherId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ClientFather"/> class.</returns>
		public Ekip.Framework.Entities.ClientFather GetByFatherId(TransactionManager transactionManager, System.Int32 _fatherId, int start, int pageLength)
		{
			int count = -1;
			return GetByFatherId(transactionManager, _fatherId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Father index.
		/// </summary>
		/// <param name="_fatherId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ClientFather"/> class.</returns>
		public Ekip.Framework.Entities.ClientFather GetByFatherId(System.Int32 _fatherId, int start, int pageLength, out int count)
		{
			return GetByFatherId(null, _fatherId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Father index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_fatherId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ClientFather"/> class.</returns>
		public abstract Ekip.Framework.Entities.ClientFather GetByFatherId(TransactionManager transactionManager, System.Int32 _fatherId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;ClientFather&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;ClientFather&gt;"/></returns>
		public static TList<ClientFather> Fill(IDataReader reader, TList<ClientFather> rows, int start, int pageLength)
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
				
				Ekip.Framework.Entities.ClientFather c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ClientFather")
					.Append("|").Append((System.Int32)reader[((int)ClientFatherColumn.FatherId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<ClientFather>(
					key.ToString(), // EntityTrackingKey
					"ClientFather",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Ekip.Framework.Entities.ClientFather();
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
					c.FatherId = (System.Int32)reader[((int)ClientFatherColumn.FatherId - 1)];
					c.FullName = (reader.IsDBNull(((int)ClientFatherColumn.FullName - 1)))?null:(System.String)reader[((int)ClientFatherColumn.FullName - 1)];
					c.Title = (reader.IsDBNull(((int)ClientFatherColumn.Title - 1)))?null:(System.String)reader[((int)ClientFatherColumn.Title - 1)];
					c.Email = (reader.IsDBNull(((int)ClientFatherColumn.Email - 1)))?null:(System.String)reader[((int)ClientFatherColumn.Email - 1)];
					c.Fax = (reader.IsDBNull(((int)ClientFatherColumn.Fax - 1)))?null:(System.String)reader[((int)ClientFatherColumn.Fax - 1)];
					c.HomePhone = (reader.IsDBNull(((int)ClientFatherColumn.HomePhone - 1)))?null:(System.String)reader[((int)ClientFatherColumn.HomePhone - 1)];
					c.BusinessPhone = (reader.IsDBNull(((int)ClientFatherColumn.BusinessPhone - 1)))?null:(System.String)reader[((int)ClientFatherColumn.BusinessPhone - 1)];
					c.MobilePhone = (reader.IsDBNull(((int)ClientFatherColumn.MobilePhone - 1)))?null:(System.String)reader[((int)ClientFatherColumn.MobilePhone - 1)];
					c.OtherPhone = (reader.IsDBNull(((int)ClientFatherColumn.OtherPhone - 1)))?null:(System.String)reader[((int)ClientFatherColumn.OtherPhone - 1)];
					c.JobId = (reader.IsDBNull(((int)ClientFatherColumn.JobId - 1)))?null:(System.Int32?)reader[((int)ClientFatherColumn.JobId - 1)];
					c.Notes = (reader.IsDBNull(((int)ClientFatherColumn.Notes - 1)))?null:(System.String)reader[((int)ClientFatherColumn.Notes - 1)];
					c.FatherStatusId = (System.Byte)reader[((int)ClientFatherColumn.FatherStatusId - 1)];
					c.CreateDate = (System.DateTime)reader[((int)ClientFatherColumn.CreateDate - 1)];
					c.UpdateDate = (reader.IsDBNull(((int)ClientFatherColumn.UpdateDate - 1)))?null:(System.DateTime?)reader[((int)ClientFatherColumn.UpdateDate - 1)];
					c.CreateUserId = (System.Int32)reader[((int)ClientFatherColumn.CreateUserId - 1)];
					c.UpdateUserId = (reader.IsDBNull(((int)ClientFatherColumn.UpdateUserId - 1)))?null:(System.Int32?)reader[((int)ClientFatherColumn.UpdateUserId - 1)];
					c.Active = (System.Boolean)reader[((int)ClientFatherColumn.Active - 1)];
					c.Deleted = (System.Boolean)reader[((int)ClientFatherColumn.Deleted - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.ClientFather"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.ClientFather"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Ekip.Framework.Entities.ClientFather entity)
		{
			if (!reader.Read()) return;
			
			entity.FatherId = (System.Int32)reader[((int)ClientFatherColumn.FatherId - 1)];
			entity.FullName = (reader.IsDBNull(((int)ClientFatherColumn.FullName - 1)))?null:(System.String)reader[((int)ClientFatherColumn.FullName - 1)];
			entity.Title = (reader.IsDBNull(((int)ClientFatherColumn.Title - 1)))?null:(System.String)reader[((int)ClientFatherColumn.Title - 1)];
			entity.Email = (reader.IsDBNull(((int)ClientFatherColumn.Email - 1)))?null:(System.String)reader[((int)ClientFatherColumn.Email - 1)];
			entity.Fax = (reader.IsDBNull(((int)ClientFatherColumn.Fax - 1)))?null:(System.String)reader[((int)ClientFatherColumn.Fax - 1)];
			entity.HomePhone = (reader.IsDBNull(((int)ClientFatherColumn.HomePhone - 1)))?null:(System.String)reader[((int)ClientFatherColumn.HomePhone - 1)];
			entity.BusinessPhone = (reader.IsDBNull(((int)ClientFatherColumn.BusinessPhone - 1)))?null:(System.String)reader[((int)ClientFatherColumn.BusinessPhone - 1)];
			entity.MobilePhone = (reader.IsDBNull(((int)ClientFatherColumn.MobilePhone - 1)))?null:(System.String)reader[((int)ClientFatherColumn.MobilePhone - 1)];
			entity.OtherPhone = (reader.IsDBNull(((int)ClientFatherColumn.OtherPhone - 1)))?null:(System.String)reader[((int)ClientFatherColumn.OtherPhone - 1)];
			entity.JobId = (reader.IsDBNull(((int)ClientFatherColumn.JobId - 1)))?null:(System.Int32?)reader[((int)ClientFatherColumn.JobId - 1)];
			entity.Notes = (reader.IsDBNull(((int)ClientFatherColumn.Notes - 1)))?null:(System.String)reader[((int)ClientFatherColumn.Notes - 1)];
			entity.FatherStatusId = (System.Byte)reader[((int)ClientFatherColumn.FatherStatusId - 1)];
			entity.CreateDate = (System.DateTime)reader[((int)ClientFatherColumn.CreateDate - 1)];
			entity.UpdateDate = (reader.IsDBNull(((int)ClientFatherColumn.UpdateDate - 1)))?null:(System.DateTime?)reader[((int)ClientFatherColumn.UpdateDate - 1)];
			entity.CreateUserId = (System.Int32)reader[((int)ClientFatherColumn.CreateUserId - 1)];
			entity.UpdateUserId = (reader.IsDBNull(((int)ClientFatherColumn.UpdateUserId - 1)))?null:(System.Int32?)reader[((int)ClientFatherColumn.UpdateUserId - 1)];
			entity.Active = (System.Boolean)reader[((int)ClientFatherColumn.Active - 1)];
			entity.Deleted = (System.Boolean)reader[((int)ClientFatherColumn.Deleted - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.ClientFather"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.ClientFather"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Ekip.Framework.Entities.ClientFather entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.FatherId = (System.Int32)dataRow["FatherId"];
			entity.FullName = Convert.IsDBNull(dataRow["FullName"]) ? null : (System.String)dataRow["FullName"];
			entity.Title = Convert.IsDBNull(dataRow["Title"]) ? null : (System.String)dataRow["Title"];
			entity.Email = Convert.IsDBNull(dataRow["Email"]) ? null : (System.String)dataRow["Email"];
			entity.Fax = Convert.IsDBNull(dataRow["Fax"]) ? null : (System.String)dataRow["Fax"];
			entity.HomePhone = Convert.IsDBNull(dataRow["HomePhone"]) ? null : (System.String)dataRow["HomePhone"];
			entity.BusinessPhone = Convert.IsDBNull(dataRow["BusinessPhone"]) ? null : (System.String)dataRow["BusinessPhone"];
			entity.MobilePhone = Convert.IsDBNull(dataRow["MobilePhone"]) ? null : (System.String)dataRow["MobilePhone"];
			entity.OtherPhone = Convert.IsDBNull(dataRow["OtherPhone"]) ? null : (System.String)dataRow["OtherPhone"];
			entity.JobId = Convert.IsDBNull(dataRow["JobId"]) ? null : (System.Int32?)dataRow["JobId"];
			entity.Notes = Convert.IsDBNull(dataRow["Notes"]) ? null : (System.String)dataRow["Notes"];
			entity.FatherStatusId = (System.Byte)dataRow["FatherStatusId"];
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
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.ClientFather"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.ClientFather Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Ekip.Framework.Entities.ClientFather entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByFatherId methods when available
			
			#region ClientCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Client>|ClientCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ClientCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ClientCollection = DataRepository.ClientProvider.GetByFatherId(transactionManager, entity.FatherId);

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
		/// Deep Save the entire object graph of the Ekip.Framework.Entities.ClientFather object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Ekip.Framework.Entities.ClientFather instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.ClientFather Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Ekip.Framework.Entities.ClientFather entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
						if(child.FatherIdSource != null)
						{
							child.FatherId = child.FatherIdSource.FatherId;
						}
						else
						{
							child.FatherId = entity.FatherId;
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
	
	#region ClientFatherChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Ekip.Framework.Entities.ClientFather</c>
	///</summary>
	public enum ClientFatherChildEntityTypes
	{

		///<summary>
		/// Collection of <c>ClientFather</c> as OneToMany for ClientCollection
		///</summary>
		[ChildEntityType(typeof(TList<Client>))]
		ClientCollection,
	}
	
	#endregion ClientFatherChildEntityTypes
	
	#region ClientFatherFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ClientFatherColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClientFather"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClientFatherFilterBuilder : SqlFilterBuilder<ClientFatherColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClientFatherFilterBuilder class.
		/// </summary>
		public ClientFatherFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ClientFatherFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ClientFatherFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ClientFatherFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ClientFatherFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ClientFatherFilterBuilder
	
	#region ClientFatherParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ClientFatherColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClientFather"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClientFatherParameterBuilder : ParameterizedSqlFilterBuilder<ClientFatherColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClientFatherParameterBuilder class.
		/// </summary>
		public ClientFatherParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ClientFatherParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ClientFatherParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ClientFatherParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ClientFatherParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ClientFatherParameterBuilder
	
	#region ClientFatherSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ClientFatherColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClientFather"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ClientFatherSortBuilder : SqlSortBuilder<ClientFatherColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClientFatherSqlSortBuilder class.
		/// </summary>
		public ClientFatherSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ClientFatherSortBuilder
	
} // end namespace
