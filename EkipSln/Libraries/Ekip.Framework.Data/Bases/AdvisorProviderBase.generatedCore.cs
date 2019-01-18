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
	/// This class is the base class for any <see cref="AdvisorProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class AdvisorProviderBaseCore : EntityProviderBase<Ekip.Framework.Entities.Advisor, Ekip.Framework.Entities.AdvisorKey>
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
		public override bool Delete(TransactionManager transactionManager, Ekip.Framework.Entities.AdvisorKey key)
		{
			return Delete(transactionManager, key.AdvisorId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_advisorId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _advisorId)
		{
			return Delete(null, _advisorId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advisorId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _advisorId);		
		
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
		public override Ekip.Framework.Entities.Advisor Get(TransactionManager transactionManager, Ekip.Framework.Entities.AdvisorKey key, int start, int pageLength)
		{
			return GetByAdvisorId(transactionManager, key.AdvisorId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Advisor index.
		/// </summary>
		/// <param name="_advisorId"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Advisor"/> class.</returns>
		public Ekip.Framework.Entities.Advisor GetByAdvisorId(System.Int32 _advisorId)
		{
			int count = -1;
			return GetByAdvisorId(null,_advisorId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Advisor index.
		/// </summary>
		/// <param name="_advisorId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Advisor"/> class.</returns>
		public Ekip.Framework.Entities.Advisor GetByAdvisorId(System.Int32 _advisorId, int start, int pageLength)
		{
			int count = -1;
			return GetByAdvisorId(null, _advisorId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Advisor index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advisorId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Advisor"/> class.</returns>
		public Ekip.Framework.Entities.Advisor GetByAdvisorId(TransactionManager transactionManager, System.Int32 _advisorId)
		{
			int count = -1;
			return GetByAdvisorId(transactionManager, _advisorId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Advisor index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advisorId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Advisor"/> class.</returns>
		public Ekip.Framework.Entities.Advisor GetByAdvisorId(TransactionManager transactionManager, System.Int32 _advisorId, int start, int pageLength)
		{
			int count = -1;
			return GetByAdvisorId(transactionManager, _advisorId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Advisor index.
		/// </summary>
		/// <param name="_advisorId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Advisor"/> class.</returns>
		public Ekip.Framework.Entities.Advisor GetByAdvisorId(System.Int32 _advisorId, int start, int pageLength, out int count)
		{
			return GetByAdvisorId(null, _advisorId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Advisor index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advisorId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Advisor"/> class.</returns>
		public abstract Ekip.Framework.Entities.Advisor GetByAdvisorId(TransactionManager transactionManager, System.Int32 _advisorId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Advisor&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Advisor&gt;"/></returns>
		public static TList<Advisor> Fill(IDataReader reader, TList<Advisor> rows, int start, int pageLength)
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
				
				Ekip.Framework.Entities.Advisor c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Advisor")
					.Append("|").Append((System.Int32)reader[((int)AdvisorColumn.AdvisorId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Advisor>(
					key.ToString(), // EntityTrackingKey
					"Advisor",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Ekip.Framework.Entities.Advisor();
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
					c.AdvisorId = (System.Int32)reader[((int)AdvisorColumn.AdvisorId - 1)];
					c.TitleId = (reader.IsDBNull(((int)AdvisorColumn.TitleId - 1)))?null:(System.Byte?)reader[((int)AdvisorColumn.TitleId - 1)];
					c.FullName = (System.String)reader[((int)AdvisorColumn.FullName - 1)];
					c.Email = (reader.IsDBNull(((int)AdvisorColumn.Email - 1)))?null:(System.String)reader[((int)AdvisorColumn.Email - 1)];
					c.Phone = (reader.IsDBNull(((int)AdvisorColumn.Phone - 1)))?null:(System.String)reader[((int)AdvisorColumn.Phone - 1)];
					c.Gsm = (reader.IsDBNull(((int)AdvisorColumn.Gsm - 1)))?null:(System.String)reader[((int)AdvisorColumn.Gsm - 1)];
					c.Notes = (reader.IsDBNull(((int)AdvisorColumn.Notes - 1)))?null:(System.String)reader[((int)AdvisorColumn.Notes - 1)];
					c.CreateDate = (System.DateTime)reader[((int)AdvisorColumn.CreateDate - 1)];
					c.UpdateDate = (reader.IsDBNull(((int)AdvisorColumn.UpdateDate - 1)))?null:(System.DateTime?)reader[((int)AdvisorColumn.UpdateDate - 1)];
					c.CreateUserId = (System.Int32)reader[((int)AdvisorColumn.CreateUserId - 1)];
					c.UpdateUserId = (reader.IsDBNull(((int)AdvisorColumn.UpdateUserId - 1)))?null:(System.Int32?)reader[((int)AdvisorColumn.UpdateUserId - 1)];
					c.Active = (System.Boolean)reader[((int)AdvisorColumn.Active - 1)];
					c.Deleted = (System.Boolean)reader[((int)AdvisorColumn.Deleted - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.Advisor"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Advisor"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Ekip.Framework.Entities.Advisor entity)
		{
			if (!reader.Read()) return;
			
			entity.AdvisorId = (System.Int32)reader[((int)AdvisorColumn.AdvisorId - 1)];
			entity.TitleId = (reader.IsDBNull(((int)AdvisorColumn.TitleId - 1)))?null:(System.Byte?)reader[((int)AdvisorColumn.TitleId - 1)];
			entity.FullName = (System.String)reader[((int)AdvisorColumn.FullName - 1)];
			entity.Email = (reader.IsDBNull(((int)AdvisorColumn.Email - 1)))?null:(System.String)reader[((int)AdvisorColumn.Email - 1)];
			entity.Phone = (reader.IsDBNull(((int)AdvisorColumn.Phone - 1)))?null:(System.String)reader[((int)AdvisorColumn.Phone - 1)];
			entity.Gsm = (reader.IsDBNull(((int)AdvisorColumn.Gsm - 1)))?null:(System.String)reader[((int)AdvisorColumn.Gsm - 1)];
			entity.Notes = (reader.IsDBNull(((int)AdvisorColumn.Notes - 1)))?null:(System.String)reader[((int)AdvisorColumn.Notes - 1)];
			entity.CreateDate = (System.DateTime)reader[((int)AdvisorColumn.CreateDate - 1)];
			entity.UpdateDate = (reader.IsDBNull(((int)AdvisorColumn.UpdateDate - 1)))?null:(System.DateTime?)reader[((int)AdvisorColumn.UpdateDate - 1)];
			entity.CreateUserId = (System.Int32)reader[((int)AdvisorColumn.CreateUserId - 1)];
			entity.UpdateUserId = (reader.IsDBNull(((int)AdvisorColumn.UpdateUserId - 1)))?null:(System.Int32?)reader[((int)AdvisorColumn.UpdateUserId - 1)];
			entity.Active = (System.Boolean)reader[((int)AdvisorColumn.Active - 1)];
			entity.Deleted = (System.Boolean)reader[((int)AdvisorColumn.Deleted - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.Advisor"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Advisor"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Ekip.Framework.Entities.Advisor entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.AdvisorId = (System.Int32)dataRow["AdvisorId"];
			entity.TitleId = Convert.IsDBNull(dataRow["TitleId"]) ? null : (System.Byte?)dataRow["TitleId"];
			entity.FullName = (System.String)dataRow["FullName"];
			entity.Email = Convert.IsDBNull(dataRow["Email"]) ? null : (System.String)dataRow["Email"];
			entity.Phone = Convert.IsDBNull(dataRow["Phone"]) ? null : (System.String)dataRow["Phone"];
			entity.Gsm = Convert.IsDBNull(dataRow["Gsm"]) ? null : (System.String)dataRow["Gsm"];
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
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Advisor"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.Advisor Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Ekip.Framework.Entities.Advisor entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the Ekip.Framework.Entities.Advisor object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Ekip.Framework.Entities.Advisor instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.Advisor Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Ekip.Framework.Entities.Advisor entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region AdvisorChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Ekip.Framework.Entities.Advisor</c>
	///</summary>
	public enum AdvisorChildEntityTypes
	{
	}
	
	#endregion AdvisorChildEntityTypes
	
	#region AdvisorFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;AdvisorColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Advisor"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvisorFilterBuilder : SqlFilterBuilder<AdvisorColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvisorFilterBuilder class.
		/// </summary>
		public AdvisorFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdvisorFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdvisorFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdvisorFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdvisorFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdvisorFilterBuilder
	
	#region AdvisorParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;AdvisorColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Advisor"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvisorParameterBuilder : ParameterizedSqlFilterBuilder<AdvisorColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvisorParameterBuilder class.
		/// </summary>
		public AdvisorParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdvisorParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdvisorParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdvisorParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdvisorParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdvisorParameterBuilder
	
	#region AdvisorSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;AdvisorColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Advisor"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class AdvisorSortBuilder : SqlSortBuilder<AdvisorColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvisorSqlSortBuilder class.
		/// </summary>
		public AdvisorSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion AdvisorSortBuilder
	
} // end namespace
