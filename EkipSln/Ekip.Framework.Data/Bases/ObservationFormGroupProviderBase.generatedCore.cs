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
	/// This class is the base class for any <see cref="ObservationFormGroupProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ObservationFormGroupProviderBaseCore : EntityProviderBase<Ekip.Framework.Entities.ObservationFormGroup, Ekip.Framework.Entities.ObservationFormGroupKey>
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
		public override bool Delete(TransactionManager transactionManager, Ekip.Framework.Entities.ObservationFormGroupKey key)
		{
			return Delete(transactionManager, key.GroupId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_groupId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _groupId)
		{
			return Delete(null, _groupId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_groupId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _groupId);		
		
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
		public override Ekip.Framework.Entities.ObservationFormGroup Get(TransactionManager transactionManager, Ekip.Framework.Entities.ObservationFormGroupKey key, int start, int pageLength)
		{
			return GetByGroupId(transactionManager, key.GroupId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ObservationForm_Group index.
		/// </summary>
		/// <param name="_groupId"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ObservationFormGroup"/> class.</returns>
		public Ekip.Framework.Entities.ObservationFormGroup GetByGroupId(System.Int32 _groupId)
		{
			int count = -1;
			return GetByGroupId(null,_groupId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ObservationForm_Group index.
		/// </summary>
		/// <param name="_groupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ObservationFormGroup"/> class.</returns>
		public Ekip.Framework.Entities.ObservationFormGroup GetByGroupId(System.Int32 _groupId, int start, int pageLength)
		{
			int count = -1;
			return GetByGroupId(null, _groupId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ObservationForm_Group index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_groupId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ObservationFormGroup"/> class.</returns>
		public Ekip.Framework.Entities.ObservationFormGroup GetByGroupId(TransactionManager transactionManager, System.Int32 _groupId)
		{
			int count = -1;
			return GetByGroupId(transactionManager, _groupId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ObservationForm_Group index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_groupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ObservationFormGroup"/> class.</returns>
		public Ekip.Framework.Entities.ObservationFormGroup GetByGroupId(TransactionManager transactionManager, System.Int32 _groupId, int start, int pageLength)
		{
			int count = -1;
			return GetByGroupId(transactionManager, _groupId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ObservationForm_Group index.
		/// </summary>
		/// <param name="_groupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ObservationFormGroup"/> class.</returns>
		public Ekip.Framework.Entities.ObservationFormGroup GetByGroupId(System.Int32 _groupId, int start, int pageLength, out int count)
		{
			return GetByGroupId(null, _groupId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ObservationForm_Group index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_groupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ObservationFormGroup"/> class.</returns>
		public abstract Ekip.Framework.Entities.ObservationFormGroup GetByGroupId(TransactionManager transactionManager, System.Int32 _groupId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;ObservationFormGroup&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;ObservationFormGroup&gt;"/></returns>
		public static TList<ObservationFormGroup> Fill(IDataReader reader, TList<ObservationFormGroup> rows, int start, int pageLength)
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
				
				Ekip.Framework.Entities.ObservationFormGroup c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ObservationFormGroup")
					.Append("|").Append((System.Int32)reader[((int)ObservationFormGroupColumn.GroupId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<ObservationFormGroup>(
					key.ToString(), // EntityTrackingKey
					"ObservationFormGroup",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Ekip.Framework.Entities.ObservationFormGroup();
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
					c.GroupId = (System.Int32)reader[((int)ObservationFormGroupColumn.GroupId - 1)];
					c.GroupName = (System.String)reader[((int)ObservationFormGroupColumn.GroupName - 1)];
					c.LineNumber = (System.Int32)reader[((int)ObservationFormGroupColumn.LineNumber - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.ObservationFormGroup"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.ObservationFormGroup"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Ekip.Framework.Entities.ObservationFormGroup entity)
		{
			if (!reader.Read()) return;
			
			entity.GroupId = (System.Int32)reader[((int)ObservationFormGroupColumn.GroupId - 1)];
			entity.GroupName = (System.String)reader[((int)ObservationFormGroupColumn.GroupName - 1)];
			entity.LineNumber = (System.Int32)reader[((int)ObservationFormGroupColumn.LineNumber - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.ObservationFormGroup"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.ObservationFormGroup"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Ekip.Framework.Entities.ObservationFormGroup entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.GroupId = (System.Int32)dataRow["GroupID"];
			entity.GroupName = (System.String)dataRow["GroupName"];
			entity.LineNumber = (System.Int32)dataRow["LineNumber"];
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
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.ObservationFormGroup"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.ObservationFormGroup Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Ekip.Framework.Entities.ObservationFormGroup entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByGroupId methods when available
			
			#region ObservationFormCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ObservationForm>|ObservationFormCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ObservationFormCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ObservationFormCollection = DataRepository.ObservationFormProvider.GetByGroupId(transactionManager, entity.GroupId);

				if (deep && entity.ObservationFormCollection.Count > 0)
				{
					deepHandles.Add("ObservationFormCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<ObservationForm>) DataRepository.ObservationFormProvider.DeepLoad,
						new object[] { transactionManager, entity.ObservationFormCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Ekip.Framework.Entities.ObservationFormGroup object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Ekip.Framework.Entities.ObservationFormGroup instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.ObservationFormGroup Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Ekip.Framework.Entities.ObservationFormGroup entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<ObservationForm>
				if (CanDeepSave(entity.ObservationFormCollection, "List<ObservationForm>|ObservationFormCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ObservationForm child in entity.ObservationFormCollection)
					{
						if(child.GroupIdSource != null)
						{
							child.GroupId = child.GroupIdSource.GroupId;
						}
						else
						{
							child.GroupId = entity.GroupId;
						}

					}

					if (entity.ObservationFormCollection.Count > 0 || entity.ObservationFormCollection.DeletedItems.Count > 0)
					{
						//DataRepository.ObservationFormProvider.Save(transactionManager, entity.ObservationFormCollection);
						
						deepHandles.Add("ObservationFormCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< ObservationForm >) DataRepository.ObservationFormProvider.DeepSave,
							new object[] { transactionManager, entity.ObservationFormCollection, deepSaveType, childTypes, innerList }
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
	
	#region ObservationFormGroupChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Ekip.Framework.Entities.ObservationFormGroup</c>
	///</summary>
	public enum ObservationFormGroupChildEntityTypes
	{

		///<summary>
		/// Collection of <c>ObservationFormGroup</c> as OneToMany for ObservationFormCollection
		///</summary>
		[ChildEntityType(typeof(TList<ObservationForm>))]
		ObservationFormCollection,
	}
	
	#endregion ObservationFormGroupChildEntityTypes
	
	#region ObservationFormGroupFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ObservationFormGroupColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ObservationFormGroup"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ObservationFormGroupFilterBuilder : SqlFilterBuilder<ObservationFormGroupColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ObservationFormGroupFilterBuilder class.
		/// </summary>
		public ObservationFormGroupFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ObservationFormGroupFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ObservationFormGroupFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ObservationFormGroupFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ObservationFormGroupFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ObservationFormGroupFilterBuilder
	
	#region ObservationFormGroupParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ObservationFormGroupColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ObservationFormGroup"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ObservationFormGroupParameterBuilder : ParameterizedSqlFilterBuilder<ObservationFormGroupColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ObservationFormGroupParameterBuilder class.
		/// </summary>
		public ObservationFormGroupParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ObservationFormGroupParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ObservationFormGroupParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ObservationFormGroupParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ObservationFormGroupParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ObservationFormGroupParameterBuilder
	
	#region ObservationFormGroupSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ObservationFormGroupColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ObservationFormGroup"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ObservationFormGroupSortBuilder : SqlSortBuilder<ObservationFormGroupColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ObservationFormGroupSqlSortBuilder class.
		/// </summary>
		public ObservationFormGroupSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ObservationFormGroupSortBuilder
	
} // end namespace
