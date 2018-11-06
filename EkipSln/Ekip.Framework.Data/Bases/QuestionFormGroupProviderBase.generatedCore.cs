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
	/// This class is the base class for any <see cref="QuestionFormGroupProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class QuestionFormGroupProviderBaseCore : EntityProviderBase<Ekip.Framework.Entities.QuestionFormGroup, Ekip.Framework.Entities.QuestionFormGroupKey>
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
		public override bool Delete(TransactionManager transactionManager, Ekip.Framework.Entities.QuestionFormGroupKey key)
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
		public override Ekip.Framework.Entities.QuestionFormGroup Get(TransactionManager transactionManager, Ekip.Framework.Entities.QuestionFormGroupKey key, int start, int pageLength)
		{
			return GetByGroupId(transactionManager, key.GroupId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_QuestionForm_Group index.
		/// </summary>
		/// <param name="_groupId"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.QuestionFormGroup"/> class.</returns>
		public Ekip.Framework.Entities.QuestionFormGroup GetByGroupId(System.Int32 _groupId)
		{
			int count = -1;
			return GetByGroupId(null,_groupId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_QuestionForm_Group index.
		/// </summary>
		/// <param name="_groupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.QuestionFormGroup"/> class.</returns>
		public Ekip.Framework.Entities.QuestionFormGroup GetByGroupId(System.Int32 _groupId, int start, int pageLength)
		{
			int count = -1;
			return GetByGroupId(null, _groupId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_QuestionForm_Group index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_groupId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.QuestionFormGroup"/> class.</returns>
		public Ekip.Framework.Entities.QuestionFormGroup GetByGroupId(TransactionManager transactionManager, System.Int32 _groupId)
		{
			int count = -1;
			return GetByGroupId(transactionManager, _groupId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_QuestionForm_Group index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_groupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.QuestionFormGroup"/> class.</returns>
		public Ekip.Framework.Entities.QuestionFormGroup GetByGroupId(TransactionManager transactionManager, System.Int32 _groupId, int start, int pageLength)
		{
			int count = -1;
			return GetByGroupId(transactionManager, _groupId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_QuestionForm_Group index.
		/// </summary>
		/// <param name="_groupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.QuestionFormGroup"/> class.</returns>
		public Ekip.Framework.Entities.QuestionFormGroup GetByGroupId(System.Int32 _groupId, int start, int pageLength, out int count)
		{
			return GetByGroupId(null, _groupId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_QuestionForm_Group index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_groupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.QuestionFormGroup"/> class.</returns>
		public abstract Ekip.Framework.Entities.QuestionFormGroup GetByGroupId(TransactionManager transactionManager, System.Int32 _groupId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;QuestionFormGroup&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;QuestionFormGroup&gt;"/></returns>
		public static TList<QuestionFormGroup> Fill(IDataReader reader, TList<QuestionFormGroup> rows, int start, int pageLength)
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
				
				Ekip.Framework.Entities.QuestionFormGroup c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("QuestionFormGroup")
					.Append("|").Append((System.Int32)reader[((int)QuestionFormGroupColumn.GroupId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<QuestionFormGroup>(
					key.ToString(), // EntityTrackingKey
					"QuestionFormGroup",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Ekip.Framework.Entities.QuestionFormGroup();
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
					c.GroupId = (System.Int32)reader[((int)QuestionFormGroupColumn.GroupId - 1)];
					c.GroupName = (System.String)reader[((int)QuestionFormGroupColumn.GroupName - 1)];
					c.LineNumber = (System.Int32)reader[((int)QuestionFormGroupColumn.LineNumber - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.QuestionFormGroup"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.QuestionFormGroup"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Ekip.Framework.Entities.QuestionFormGroup entity)
		{
			if (!reader.Read()) return;
			
			entity.GroupId = (System.Int32)reader[((int)QuestionFormGroupColumn.GroupId - 1)];
			entity.GroupName = (System.String)reader[((int)QuestionFormGroupColumn.GroupName - 1)];
			entity.LineNumber = (System.Int32)reader[((int)QuestionFormGroupColumn.LineNumber - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.QuestionFormGroup"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.QuestionFormGroup"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Ekip.Framework.Entities.QuestionFormGroup entity)
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
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.QuestionFormGroup"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.QuestionFormGroup Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Ekip.Framework.Entities.QuestionFormGroup entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByGroupId methods when available
			
			#region QuestionFormCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<QuestionForm>|QuestionFormCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'QuestionFormCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.QuestionFormCollection = DataRepository.QuestionFormProvider.GetByGroupId(transactionManager, entity.GroupId);

				if (deep && entity.QuestionFormCollection.Count > 0)
				{
					deepHandles.Add("QuestionFormCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<QuestionForm>) DataRepository.QuestionFormProvider.DeepLoad,
						new object[] { transactionManager, entity.QuestionFormCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Ekip.Framework.Entities.QuestionFormGroup object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Ekip.Framework.Entities.QuestionFormGroup instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.QuestionFormGroup Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Ekip.Framework.Entities.QuestionFormGroup entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<QuestionForm>
				if (CanDeepSave(entity.QuestionFormCollection, "List<QuestionForm>|QuestionFormCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(QuestionForm child in entity.QuestionFormCollection)
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

					if (entity.QuestionFormCollection.Count > 0 || entity.QuestionFormCollection.DeletedItems.Count > 0)
					{
						//DataRepository.QuestionFormProvider.Save(transactionManager, entity.QuestionFormCollection);
						
						deepHandles.Add("QuestionFormCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< QuestionForm >) DataRepository.QuestionFormProvider.DeepSave,
							new object[] { transactionManager, entity.QuestionFormCollection, deepSaveType, childTypes, innerList }
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
	
	#region QuestionFormGroupChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Ekip.Framework.Entities.QuestionFormGroup</c>
	///</summary>
	public enum QuestionFormGroupChildEntityTypes
	{

		///<summary>
		/// Collection of <c>QuestionFormGroup</c> as OneToMany for QuestionFormCollection
		///</summary>
		[ChildEntityType(typeof(TList<QuestionForm>))]
		QuestionFormCollection,
	}
	
	#endregion QuestionFormGroupChildEntityTypes
	
	#region QuestionFormGroupFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;QuestionFormGroupColumn&gt;"/> class
	/// that is used exclusively with a <see cref="QuestionFormGroup"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuestionFormGroupFilterBuilder : SqlFilterBuilder<QuestionFormGroupColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuestionFormGroupFilterBuilder class.
		/// </summary>
		public QuestionFormGroupFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the QuestionFormGroupFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public QuestionFormGroupFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the QuestionFormGroupFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public QuestionFormGroupFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion QuestionFormGroupFilterBuilder
	
	#region QuestionFormGroupParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;QuestionFormGroupColumn&gt;"/> class
	/// that is used exclusively with a <see cref="QuestionFormGroup"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuestionFormGroupParameterBuilder : ParameterizedSqlFilterBuilder<QuestionFormGroupColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuestionFormGroupParameterBuilder class.
		/// </summary>
		public QuestionFormGroupParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the QuestionFormGroupParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public QuestionFormGroupParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the QuestionFormGroupParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public QuestionFormGroupParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion QuestionFormGroupParameterBuilder
	
	#region QuestionFormGroupSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;QuestionFormGroupColumn&gt;"/> class
	/// that is used exclusively with a <see cref="QuestionFormGroup"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class QuestionFormGroupSortBuilder : SqlSortBuilder<QuestionFormGroupColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuestionFormGroupSqlSortBuilder class.
		/// </summary>
		public QuestionFormGroupSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion QuestionFormGroupSortBuilder
	
} // end namespace
