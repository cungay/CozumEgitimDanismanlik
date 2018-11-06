﻿#region Using directives

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
	/// This class is the base class for any <see cref="ClientFormProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ClientFormProviderBaseCore : EntityProviderBase<Ekip.Framework.Entities.ClientForm, Ekip.Framework.Entities.ClientFormKey>
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
		public override bool Delete(TransactionManager transactionManager, Ekip.Framework.Entities.ClientFormKey key)
		{
			return Delete(transactionManager, key.FormId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_formId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _formId)
		{
			return Delete(null, _formId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_formId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _formId);		
		
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
		public override Ekip.Framework.Entities.ClientForm Get(TransactionManager transactionManager, Ekip.Framework.Entities.ClientFormKey key, int start, int pageLength)
		{
			return GetByFormId(transactionManager, key.FormId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ClientForm index.
		/// </summary>
		/// <param name="_formId"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ClientForm"/> class.</returns>
		public Ekip.Framework.Entities.ClientForm GetByFormId(System.Int32 _formId)
		{
			int count = -1;
			return GetByFormId(null,_formId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ClientForm index.
		/// </summary>
		/// <param name="_formId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ClientForm"/> class.</returns>
		public Ekip.Framework.Entities.ClientForm GetByFormId(System.Int32 _formId, int start, int pageLength)
		{
			int count = -1;
			return GetByFormId(null, _formId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ClientForm index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_formId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ClientForm"/> class.</returns>
		public Ekip.Framework.Entities.ClientForm GetByFormId(TransactionManager transactionManager, System.Int32 _formId)
		{
			int count = -1;
			return GetByFormId(transactionManager, _formId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ClientForm index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_formId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ClientForm"/> class.</returns>
		public Ekip.Framework.Entities.ClientForm GetByFormId(TransactionManager transactionManager, System.Int32 _formId, int start, int pageLength)
		{
			int count = -1;
			return GetByFormId(transactionManager, _formId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ClientForm index.
		/// </summary>
		/// <param name="_formId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ClientForm"/> class.</returns>
		public Ekip.Framework.Entities.ClientForm GetByFormId(System.Int32 _formId, int start, int pageLength, out int count)
		{
			return GetByFormId(null, _formId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ClientForm index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_formId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ClientForm"/> class.</returns>
		public abstract Ekip.Framework.Entities.ClientForm GetByFormId(TransactionManager transactionManager, System.Int32 _formId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;ClientForm&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;ClientForm&gt;"/></returns>
		public static TList<ClientForm> Fill(IDataReader reader, TList<ClientForm> rows, int start, int pageLength)
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
				
				Ekip.Framework.Entities.ClientForm c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ClientForm")
					.Append("|").Append((System.Int32)reader[((int)ClientFormColumn.FormId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<ClientForm>(
					key.ToString(), // EntityTrackingKey
					"ClientForm",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Ekip.Framework.Entities.ClientForm();
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
					c.FormId = (System.Int32)reader[((int)ClientFormColumn.FormId - 1)];
					c.FormCode = (System.String)reader[((int)ClientFormColumn.FormCode - 1)];
					c.Name = (System.String)reader[((int)ClientFormColumn.Name - 1)];
					c.Title = (System.String)reader[((int)ClientFormColumn.Title - 1)];
					c.Description = (reader.IsDBNull(((int)ClientFormColumn.Description - 1)))?null:(System.String)reader[((int)ClientFormColumn.Description - 1)];
					c.CreateOn = (System.DateTime)reader[((int)ClientFormColumn.CreateOn - 1)];
					c.UpdateOn = (reader.IsDBNull(((int)ClientFormColumn.UpdateOn - 1)))?null:(System.DateTime?)reader[((int)ClientFormColumn.UpdateOn - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.ClientForm"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.ClientForm"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Ekip.Framework.Entities.ClientForm entity)
		{
			if (!reader.Read()) return;
			
			entity.FormId = (System.Int32)reader[((int)ClientFormColumn.FormId - 1)];
			entity.FormCode = (System.String)reader[((int)ClientFormColumn.FormCode - 1)];
			entity.Name = (System.String)reader[((int)ClientFormColumn.Name - 1)];
			entity.Title = (System.String)reader[((int)ClientFormColumn.Title - 1)];
			entity.Description = (reader.IsDBNull(((int)ClientFormColumn.Description - 1)))?null:(System.String)reader[((int)ClientFormColumn.Description - 1)];
			entity.CreateOn = (System.DateTime)reader[((int)ClientFormColumn.CreateOn - 1)];
			entity.UpdateOn = (reader.IsDBNull(((int)ClientFormColumn.UpdateOn - 1)))?null:(System.DateTime?)reader[((int)ClientFormColumn.UpdateOn - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.ClientForm"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.ClientForm"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Ekip.Framework.Entities.ClientForm entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.FormId = (System.Int32)dataRow["FormID"];
			entity.FormCode = (System.String)dataRow["FormCode"];
			entity.Name = (System.String)dataRow["Name"];
			entity.Title = (System.String)dataRow["Title"];
			entity.Description = Convert.IsDBNull(dataRow["Description"]) ? null : (System.String)dataRow["Description"];
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
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.ClientForm"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.ClientForm Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Ekip.Framework.Entities.ClientForm entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByFormId methods when available
			
			#region FormQuestionCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<FormQuestion>|FormQuestionCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'FormQuestionCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.FormQuestionCollection = DataRepository.FormQuestionProvider.GetByFormId(transactionManager, entity.FormId);

				if (deep && entity.FormQuestionCollection.Count > 0)
				{
					deepHandles.Add("FormQuestionCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<FormQuestion>) DataRepository.FormQuestionProvider.DeepLoad,
						new object[] { transactionManager, entity.FormQuestionCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Ekip.Framework.Entities.ClientForm object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Ekip.Framework.Entities.ClientForm instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.ClientForm Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Ekip.Framework.Entities.ClientForm entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<FormQuestion>
				if (CanDeepSave(entity.FormQuestionCollection, "List<FormQuestion>|FormQuestionCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(FormQuestion child in entity.FormQuestionCollection)
					{
						if(child.FormIdSource != null)
						{
							child.FormId = child.FormIdSource.FormId;
						}
						else
						{
							child.FormId = entity.FormId;
						}

					}

					if (entity.FormQuestionCollection.Count > 0 || entity.FormQuestionCollection.DeletedItems.Count > 0)
					{
						//DataRepository.FormQuestionProvider.Save(transactionManager, entity.FormQuestionCollection);
						
						deepHandles.Add("FormQuestionCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< FormQuestion >) DataRepository.FormQuestionProvider.DeepSave,
							new object[] { transactionManager, entity.FormQuestionCollection, deepSaveType, childTypes, innerList }
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
	
	#region ClientFormChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Ekip.Framework.Entities.ClientForm</c>
	///</summary>
	public enum ClientFormChildEntityTypes
	{

		///<summary>
		/// Collection of <c>ClientForm</c> as OneToMany for FormQuestionCollection
		///</summary>
		[ChildEntityType(typeof(TList<FormQuestion>))]
		FormQuestionCollection,
	}
	
	#endregion ClientFormChildEntityTypes
	
	#region ClientFormFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ClientFormColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClientForm"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClientFormFilterBuilder : SqlFilterBuilder<ClientFormColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClientFormFilterBuilder class.
		/// </summary>
		public ClientFormFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ClientFormFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ClientFormFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ClientFormFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ClientFormFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ClientFormFilterBuilder
	
	#region ClientFormParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ClientFormColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClientForm"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClientFormParameterBuilder : ParameterizedSqlFilterBuilder<ClientFormColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClientFormParameterBuilder class.
		/// </summary>
		public ClientFormParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ClientFormParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ClientFormParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ClientFormParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ClientFormParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ClientFormParameterBuilder
	
	#region ClientFormSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ClientFormColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClientForm"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ClientFormSortBuilder : SqlSortBuilder<ClientFormColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClientFormSqlSortBuilder class.
		/// </summary>
		public ClientFormSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ClientFormSortBuilder
	
} // end namespace
