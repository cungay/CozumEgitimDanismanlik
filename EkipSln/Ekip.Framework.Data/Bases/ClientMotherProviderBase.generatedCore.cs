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
	/// This class is the base class for any <see cref="ClientMotherProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ClientMotherProviderBaseCore : EntityProviderBase<Ekip.Framework.Entities.ClientMother, Ekip.Framework.Entities.ClientMotherKey>
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
		public override bool Delete(TransactionManager transactionManager, Ekip.Framework.Entities.ClientMotherKey key)
		{
			return Delete(transactionManager, key.MotherId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_motherId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _motherId)
		{
			return Delete(null, _motherId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_motherId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _motherId);		
		
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
		public override Ekip.Framework.Entities.ClientMother Get(TransactionManager transactionManager, Ekip.Framework.Entities.ClientMotherKey key, int start, int pageLength)
		{
			return GetByMotherId(transactionManager, key.MotherId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Mother index.
		/// </summary>
		/// <param name="_motherId"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ClientMother"/> class.</returns>
		public Ekip.Framework.Entities.ClientMother GetByMotherId(System.Int32 _motherId)
		{
			int count = -1;
			return GetByMotherId(null,_motherId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Mother index.
		/// </summary>
		/// <param name="_motherId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ClientMother"/> class.</returns>
		public Ekip.Framework.Entities.ClientMother GetByMotherId(System.Int32 _motherId, int start, int pageLength)
		{
			int count = -1;
			return GetByMotherId(null, _motherId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Mother index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_motherId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ClientMother"/> class.</returns>
		public Ekip.Framework.Entities.ClientMother GetByMotherId(TransactionManager transactionManager, System.Int32 _motherId)
		{
			int count = -1;
			return GetByMotherId(transactionManager, _motherId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Mother index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_motherId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ClientMother"/> class.</returns>
		public Ekip.Framework.Entities.ClientMother GetByMotherId(TransactionManager transactionManager, System.Int32 _motherId, int start, int pageLength)
		{
			int count = -1;
			return GetByMotherId(transactionManager, _motherId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Mother index.
		/// </summary>
		/// <param name="_motherId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ClientMother"/> class.</returns>
		public Ekip.Framework.Entities.ClientMother GetByMotherId(System.Int32 _motherId, int start, int pageLength, out int count)
		{
			return GetByMotherId(null, _motherId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Mother index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_motherId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ClientMother"/> class.</returns>
		public abstract Ekip.Framework.Entities.ClientMother GetByMotherId(TransactionManager transactionManager, System.Int32 _motherId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;ClientMother&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;ClientMother&gt;"/></returns>
		public static TList<ClientMother> Fill(IDataReader reader, TList<ClientMother> rows, int start, int pageLength)
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
				
				Ekip.Framework.Entities.ClientMother c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ClientMother")
					.Append("|").Append((System.Int32)reader[((int)ClientMotherColumn.MotherId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<ClientMother>(
					key.ToString(), // EntityTrackingKey
					"ClientMother",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Ekip.Framework.Entities.ClientMother();
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
					c.MotherId = (System.Int32)reader[((int)ClientMotherColumn.MotherId - 1)];
					c.FullName = (reader.IsDBNull(((int)ClientMotherColumn.FullName - 1)))?null:(System.String)reader[((int)ClientMotherColumn.FullName - 1)];
					c.Title = (reader.IsDBNull(((int)ClientMotherColumn.Title - 1)))?null:(System.String)reader[((int)ClientMotherColumn.Title - 1)];
					c.Email = (reader.IsDBNull(((int)ClientMotherColumn.Email - 1)))?null:(System.String)reader[((int)ClientMotherColumn.Email - 1)];
					c.Fax = (reader.IsDBNull(((int)ClientMotherColumn.Fax - 1)))?null:(System.String)reader[((int)ClientMotherColumn.Fax - 1)];
					c.HomePhone = (reader.IsDBNull(((int)ClientMotherColumn.HomePhone - 1)))?null:(System.String)reader[((int)ClientMotherColumn.HomePhone - 1)];
					c.BusinessPhone = (reader.IsDBNull(((int)ClientMotherColumn.BusinessPhone - 1)))?null:(System.String)reader[((int)ClientMotherColumn.BusinessPhone - 1)];
					c.MobilePhone = (reader.IsDBNull(((int)ClientMotherColumn.MobilePhone - 1)))?null:(System.String)reader[((int)ClientMotherColumn.MobilePhone - 1)];
					c.JobId = (reader.IsDBNull(((int)ClientMotherColumn.JobId - 1)))?null:(System.Int32?)reader[((int)ClientMotherColumn.JobId - 1)];
					c.StatusId = (System.Int32)reader[((int)ClientMotherColumn.StatusId - 1)];
					c.Notes = (reader.IsDBNull(((int)ClientMotherColumn.Notes - 1)))?null:(System.String)reader[((int)ClientMotherColumn.Notes - 1)];
					c.CreateOn = (System.DateTime)reader[((int)ClientMotherColumn.CreateOn - 1)];
					c.UpdateOn = (reader.IsDBNull(((int)ClientMotherColumn.UpdateOn - 1)))?null:(System.DateTime?)reader[((int)ClientMotherColumn.UpdateOn - 1)];
					c.UserId = (System.Int32)reader[((int)ClientMotherColumn.UserId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.ClientMother"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.ClientMother"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Ekip.Framework.Entities.ClientMother entity)
		{
			if (!reader.Read()) return;
			
			entity.MotherId = (System.Int32)reader[((int)ClientMotherColumn.MotherId - 1)];
			entity.FullName = (reader.IsDBNull(((int)ClientMotherColumn.FullName - 1)))?null:(System.String)reader[((int)ClientMotherColumn.FullName - 1)];
			entity.Title = (reader.IsDBNull(((int)ClientMotherColumn.Title - 1)))?null:(System.String)reader[((int)ClientMotherColumn.Title - 1)];
			entity.Email = (reader.IsDBNull(((int)ClientMotherColumn.Email - 1)))?null:(System.String)reader[((int)ClientMotherColumn.Email - 1)];
			entity.Fax = (reader.IsDBNull(((int)ClientMotherColumn.Fax - 1)))?null:(System.String)reader[((int)ClientMotherColumn.Fax - 1)];
			entity.HomePhone = (reader.IsDBNull(((int)ClientMotherColumn.HomePhone - 1)))?null:(System.String)reader[((int)ClientMotherColumn.HomePhone - 1)];
			entity.BusinessPhone = (reader.IsDBNull(((int)ClientMotherColumn.BusinessPhone - 1)))?null:(System.String)reader[((int)ClientMotherColumn.BusinessPhone - 1)];
			entity.MobilePhone = (reader.IsDBNull(((int)ClientMotherColumn.MobilePhone - 1)))?null:(System.String)reader[((int)ClientMotherColumn.MobilePhone - 1)];
			entity.JobId = (reader.IsDBNull(((int)ClientMotherColumn.JobId - 1)))?null:(System.Int32?)reader[((int)ClientMotherColumn.JobId - 1)];
			entity.StatusId = (System.Int32)reader[((int)ClientMotherColumn.StatusId - 1)];
			entity.Notes = (reader.IsDBNull(((int)ClientMotherColumn.Notes - 1)))?null:(System.String)reader[((int)ClientMotherColumn.Notes - 1)];
			entity.CreateOn = (System.DateTime)reader[((int)ClientMotherColumn.CreateOn - 1)];
			entity.UpdateOn = (reader.IsDBNull(((int)ClientMotherColumn.UpdateOn - 1)))?null:(System.DateTime?)reader[((int)ClientMotherColumn.UpdateOn - 1)];
			entity.UserId = (System.Int32)reader[((int)ClientMotherColumn.UserId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.ClientMother"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.ClientMother"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Ekip.Framework.Entities.ClientMother entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.MotherId = (System.Int32)dataRow["MotherID"];
			entity.FullName = Convert.IsDBNull(dataRow["FullName"]) ? null : (System.String)dataRow["FullName"];
			entity.Title = Convert.IsDBNull(dataRow["Title"]) ? null : (System.String)dataRow["Title"];
			entity.Email = Convert.IsDBNull(dataRow["Email"]) ? null : (System.String)dataRow["Email"];
			entity.Fax = Convert.IsDBNull(dataRow["Fax"]) ? null : (System.String)dataRow["Fax"];
			entity.HomePhone = Convert.IsDBNull(dataRow["HomePhone"]) ? null : (System.String)dataRow["HomePhone"];
			entity.BusinessPhone = Convert.IsDBNull(dataRow["BusinessPhone"]) ? null : (System.String)dataRow["BusinessPhone"];
			entity.MobilePhone = Convert.IsDBNull(dataRow["MobilePhone"]) ? null : (System.String)dataRow["MobilePhone"];
			entity.JobId = Convert.IsDBNull(dataRow["JobId"]) ? null : (System.Int32?)dataRow["JobId"];
			entity.StatusId = (System.Int32)dataRow["StatusId"];
			entity.Notes = Convert.IsDBNull(dataRow["Notes"]) ? null : (System.String)dataRow["Notes"];
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
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.ClientMother"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.ClientMother Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Ekip.Framework.Entities.ClientMother entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByMotherId methods when available
			
			#region ClientCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Client>|ClientCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ClientCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ClientCollection = DataRepository.ClientProvider.GetByMotherId(transactionManager, entity.MotherId);

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
		/// Deep Save the entire object graph of the Ekip.Framework.Entities.ClientMother object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Ekip.Framework.Entities.ClientMother instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.ClientMother Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Ekip.Framework.Entities.ClientMother entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
						if(child.MotherIdSource != null)
						{
							child.MotherId = child.MotherIdSource.MotherId;
						}
						else
						{
							child.MotherId = entity.MotherId;
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
	
	#region ClientMotherChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Ekip.Framework.Entities.ClientMother</c>
	///</summary>
	public enum ClientMotherChildEntityTypes
	{

		///<summary>
		/// Collection of <c>ClientMother</c> as OneToMany for ClientCollection
		///</summary>
		[ChildEntityType(typeof(TList<Client>))]
		ClientCollection,
	}
	
	#endregion ClientMotherChildEntityTypes
	
	#region ClientMotherFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ClientMotherColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClientMother"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClientMotherFilterBuilder : SqlFilterBuilder<ClientMotherColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClientMotherFilterBuilder class.
		/// </summary>
		public ClientMotherFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ClientMotherFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ClientMotherFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ClientMotherFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ClientMotherFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ClientMotherFilterBuilder
	
	#region ClientMotherParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ClientMotherColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClientMother"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClientMotherParameterBuilder : ParameterizedSqlFilterBuilder<ClientMotherColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClientMotherParameterBuilder class.
		/// </summary>
		public ClientMotherParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ClientMotherParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ClientMotherParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ClientMotherParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ClientMotherParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ClientMotherParameterBuilder
	
	#region ClientMotherSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ClientMotherColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClientMother"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ClientMotherSortBuilder : SqlSortBuilder<ClientMotherColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClientMotherSqlSortBuilder class.
		/// </summary>
		public ClientMotherSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ClientMotherSortBuilder
	
} // end namespace
