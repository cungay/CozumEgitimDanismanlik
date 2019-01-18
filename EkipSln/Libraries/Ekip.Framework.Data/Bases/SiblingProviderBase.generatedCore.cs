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
	/// This class is the base class for any <see cref="SiblingProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SiblingProviderBaseCore : EntityProviderBase<Ekip.Framework.Entities.Sibling, Ekip.Framework.Entities.SiblingKey>
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
		public override bool Delete(TransactionManager transactionManager, Ekip.Framework.Entities.SiblingKey key)
		{
			return Delete(transactionManager, key.SiblingId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_siblingId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _siblingId)
		{
			return Delete(null, _siblingId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siblingId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _siblingId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Sibling_Client key.
		///		FK_Sibling_Client Description: 
		/// </summary>
		/// <param name="_clientId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Sibling objects.</returns>
		public TList<Sibling> GetByClientId(System.Int32 _clientId)
		{
			int count = -1;
			return GetByClientId(_clientId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Sibling_Client key.
		///		FK_Sibling_Client Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_clientId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Sibling objects.</returns>
		/// <remarks></remarks>
		public TList<Sibling> GetByClientId(TransactionManager transactionManager, System.Int32 _clientId)
		{
			int count = -1;
			return GetByClientId(transactionManager, _clientId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Sibling_Client key.
		///		FK_Sibling_Client Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_clientId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Sibling objects.</returns>
		public TList<Sibling> GetByClientId(TransactionManager transactionManager, System.Int32 _clientId, int start, int pageLength)
		{
			int count = -1;
			return GetByClientId(transactionManager, _clientId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Sibling_Client key.
		///		fkSiblingClient Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_clientId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Sibling objects.</returns>
		public TList<Sibling> GetByClientId(System.Int32 _clientId, int start, int pageLength)
		{
			int count =  -1;
			return GetByClientId(null, _clientId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Sibling_Client key.
		///		fkSiblingClient Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_clientId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Sibling objects.</returns>
		public TList<Sibling> GetByClientId(System.Int32 _clientId, int start, int pageLength,out int count)
		{
			return GetByClientId(null, _clientId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Sibling_Client key.
		///		FK_Sibling_Client Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_clientId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Sibling objects.</returns>
		public abstract TList<Sibling> GetByClientId(TransactionManager transactionManager, System.Int32 _clientId, int start, int pageLength, out int count);
		
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
		public override Ekip.Framework.Entities.Sibling Get(TransactionManager transactionManager, Ekip.Framework.Entities.SiblingKey key, int start, int pageLength)
		{
			return GetBySiblingId(transactionManager, key.SiblingId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Sibling index.
		/// </summary>
		/// <param name="_siblingId"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Sibling"/> class.</returns>
		public Ekip.Framework.Entities.Sibling GetBySiblingId(System.Int32 _siblingId)
		{
			int count = -1;
			return GetBySiblingId(null,_siblingId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Sibling index.
		/// </summary>
		/// <param name="_siblingId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Sibling"/> class.</returns>
		public Ekip.Framework.Entities.Sibling GetBySiblingId(System.Int32 _siblingId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiblingId(null, _siblingId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Sibling index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siblingId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Sibling"/> class.</returns>
		public Ekip.Framework.Entities.Sibling GetBySiblingId(TransactionManager transactionManager, System.Int32 _siblingId)
		{
			int count = -1;
			return GetBySiblingId(transactionManager, _siblingId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Sibling index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siblingId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Sibling"/> class.</returns>
		public Ekip.Framework.Entities.Sibling GetBySiblingId(TransactionManager transactionManager, System.Int32 _siblingId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiblingId(transactionManager, _siblingId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Sibling index.
		/// </summary>
		/// <param name="_siblingId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Sibling"/> class.</returns>
		public Ekip.Framework.Entities.Sibling GetBySiblingId(System.Int32 _siblingId, int start, int pageLength, out int count)
		{
			return GetBySiblingId(null, _siblingId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Sibling index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siblingId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Sibling"/> class.</returns>
		public abstract Ekip.Framework.Entities.Sibling GetBySiblingId(TransactionManager transactionManager, System.Int32 _siblingId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Sibling&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Sibling&gt;"/></returns>
		public static TList<Sibling> Fill(IDataReader reader, TList<Sibling> rows, int start, int pageLength)
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
				
				Ekip.Framework.Entities.Sibling c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Sibling")
					.Append("|").Append((System.Int32)reader[((int)SiblingColumn.SiblingId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Sibling>(
					key.ToString(), // EntityTrackingKey
					"Sibling",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Ekip.Framework.Entities.Sibling();
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
					c.SiblingId = (System.Int32)reader[((int)SiblingColumn.SiblingId - 1)];
					c.ClientId = (System.Int32)reader[((int)SiblingColumn.ClientId - 1)];
					c.FullName = (System.String)reader[((int)SiblingColumn.FullName - 1)];
					c.BirthDate = (reader.IsDBNull(((int)SiblingColumn.BirthDate - 1)))?null:(System.DateTime?)reader[((int)SiblingColumn.BirthDate - 1)];
					c.Gender = (System.Byte)reader[((int)SiblingColumn.Gender - 1)];
					c.Age = (System.Int32)reader[((int)SiblingColumn.Age - 1)];
					c.School = (reader.IsDBNull(((int)SiblingColumn.School - 1)))?null:(System.String)reader[((int)SiblingColumn.School - 1)];
					c.ClassRoom = (reader.IsDBNull(((int)SiblingColumn.ClassRoom - 1)))?null:(System.Byte?)reader[((int)SiblingColumn.ClassRoom - 1)];
					c.Note = (reader.IsDBNull(((int)SiblingColumn.Note - 1)))?null:(System.String)reader[((int)SiblingColumn.Note - 1)];
					c.CreateOn = (System.DateTime)reader[((int)SiblingColumn.CreateOn - 1)];
					c.UpdateOn = (reader.IsDBNull(((int)SiblingColumn.UpdateOn - 1)))?null:(System.DateTime?)reader[((int)SiblingColumn.UpdateOn - 1)];
					c.UserId = (System.Int32)reader[((int)SiblingColumn.UserId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.Sibling"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Sibling"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Ekip.Framework.Entities.Sibling entity)
		{
			if (!reader.Read()) return;
			
			entity.SiblingId = (System.Int32)reader[((int)SiblingColumn.SiblingId - 1)];
			entity.ClientId = (System.Int32)reader[((int)SiblingColumn.ClientId - 1)];
			entity.FullName = (System.String)reader[((int)SiblingColumn.FullName - 1)];
			entity.BirthDate = (reader.IsDBNull(((int)SiblingColumn.BirthDate - 1)))?null:(System.DateTime?)reader[((int)SiblingColumn.BirthDate - 1)];
			entity.Gender = (System.Byte)reader[((int)SiblingColumn.Gender - 1)];
			entity.Age = (System.Int32)reader[((int)SiblingColumn.Age - 1)];
			entity.School = (reader.IsDBNull(((int)SiblingColumn.School - 1)))?null:(System.String)reader[((int)SiblingColumn.School - 1)];
			entity.ClassRoom = (reader.IsDBNull(((int)SiblingColumn.ClassRoom - 1)))?null:(System.Byte?)reader[((int)SiblingColumn.ClassRoom - 1)];
			entity.Note = (reader.IsDBNull(((int)SiblingColumn.Note - 1)))?null:(System.String)reader[((int)SiblingColumn.Note - 1)];
			entity.CreateOn = (System.DateTime)reader[((int)SiblingColumn.CreateOn - 1)];
			entity.UpdateOn = (reader.IsDBNull(((int)SiblingColumn.UpdateOn - 1)))?null:(System.DateTime?)reader[((int)SiblingColumn.UpdateOn - 1)];
			entity.UserId = (System.Int32)reader[((int)SiblingColumn.UserId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.Sibling"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Sibling"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Ekip.Framework.Entities.Sibling entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.SiblingId = (System.Int32)dataRow["SiblingId"];
			entity.ClientId = (System.Int32)dataRow["ClientId"];
			entity.FullName = (System.String)dataRow["FullName"];
			entity.BirthDate = Convert.IsDBNull(dataRow["BirthDate"]) ? null : (System.DateTime?)dataRow["BirthDate"];
			entity.Gender = (System.Byte)dataRow["Gender"];
			entity.Age = (System.Int32)dataRow["Age"];
			entity.School = Convert.IsDBNull(dataRow["School"]) ? null : (System.String)dataRow["School"];
			entity.ClassRoom = Convert.IsDBNull(dataRow["ClassRoom"]) ? null : (System.Byte?)dataRow["ClassRoom"];
			entity.Note = Convert.IsDBNull(dataRow["Note"]) ? null : (System.String)dataRow["Note"];
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
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Sibling"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.Sibling Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Ekip.Framework.Entities.Sibling entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the Ekip.Framework.Entities.Sibling object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Ekip.Framework.Entities.Sibling instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.Sibling Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Ekip.Framework.Entities.Sibling entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region SiblingChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Ekip.Framework.Entities.Sibling</c>
	///</summary>
	public enum SiblingChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Client</c> at ClientIdSource
		///</summary>
		[ChildEntityType(typeof(Client))]
		Client,
		}
	
	#endregion SiblingChildEntityTypes
	
	#region SiblingFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;SiblingColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Sibling"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiblingFilterBuilder : SqlFilterBuilder<SiblingColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiblingFilterBuilder class.
		/// </summary>
		public SiblingFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiblingFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiblingFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiblingFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiblingFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiblingFilterBuilder
	
	#region SiblingParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;SiblingColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Sibling"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiblingParameterBuilder : ParameterizedSqlFilterBuilder<SiblingColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiblingParameterBuilder class.
		/// </summary>
		public SiblingParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiblingParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiblingParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiblingParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiblingParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiblingParameterBuilder
	
	#region SiblingSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;SiblingColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Sibling"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class SiblingSortBuilder : SqlSortBuilder<SiblingColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiblingSqlSortBuilder class.
		/// </summary>
		public SiblingSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion SiblingSortBuilder
	
} // end namespace
