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
	/// This class is the base class for any <see cref="SeanceQuestionProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SeanceQuestionProviderBaseCore : EntityProviderBase<Ekip.Framework.Entities.SeanceQuestion, Ekip.Framework.Entities.SeanceQuestionKey>
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
		public override bool Delete(TransactionManager transactionManager, Ekip.Framework.Entities.SeanceQuestionKey key)
		{
			return Delete(transactionManager, key.QuestionId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_questionId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _questionId)
		{
			return Delete(null, _questionId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_questionId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _questionId);		
		
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
		public override Ekip.Framework.Entities.SeanceQuestion Get(TransactionManager transactionManager, Ekip.Framework.Entities.SeanceQuestionKey key, int start, int pageLength)
		{
			return GetByQuestionId(transactionManager, key.QuestionId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_SeanceQuestion index.
		/// </summary>
		/// <param name="_questionId"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.SeanceQuestion"/> class.</returns>
		public Ekip.Framework.Entities.SeanceQuestion GetByQuestionId(System.Int32 _questionId)
		{
			int count = -1;
			return GetByQuestionId(null,_questionId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SeanceQuestion index.
		/// </summary>
		/// <param name="_questionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.SeanceQuestion"/> class.</returns>
		public Ekip.Framework.Entities.SeanceQuestion GetByQuestionId(System.Int32 _questionId, int start, int pageLength)
		{
			int count = -1;
			return GetByQuestionId(null, _questionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SeanceQuestion index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_questionId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.SeanceQuestion"/> class.</returns>
		public Ekip.Framework.Entities.SeanceQuestion GetByQuestionId(TransactionManager transactionManager, System.Int32 _questionId)
		{
			int count = -1;
			return GetByQuestionId(transactionManager, _questionId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SeanceQuestion index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_questionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.SeanceQuestion"/> class.</returns>
		public Ekip.Framework.Entities.SeanceQuestion GetByQuestionId(TransactionManager transactionManager, System.Int32 _questionId, int start, int pageLength)
		{
			int count = -1;
			return GetByQuestionId(transactionManager, _questionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SeanceQuestion index.
		/// </summary>
		/// <param name="_questionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.SeanceQuestion"/> class.</returns>
		public Ekip.Framework.Entities.SeanceQuestion GetByQuestionId(System.Int32 _questionId, int start, int pageLength, out int count)
		{
			return GetByQuestionId(null, _questionId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SeanceQuestion index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_questionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.SeanceQuestion"/> class.</returns>
		public abstract Ekip.Framework.Entities.SeanceQuestion GetByQuestionId(TransactionManager transactionManager, System.Int32 _questionId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;SeanceQuestion&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;SeanceQuestion&gt;"/></returns>
		public static TList<SeanceQuestion> Fill(IDataReader reader, TList<SeanceQuestion> rows, int start, int pageLength)
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
				
				Ekip.Framework.Entities.SeanceQuestion c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("SeanceQuestion")
					.Append("|").Append((System.Int32)reader[((int)SeanceQuestionColumn.QuestionId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<SeanceQuestion>(
					key.ToString(), // EntityTrackingKey
					"SeanceQuestion",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Ekip.Framework.Entities.SeanceQuestion();
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
					c.QuestionId = (System.Int32)reader[((int)SeanceQuestionColumn.QuestionId - 1)];
					c.QuestionRef = (System.String)reader[((int)SeanceQuestionColumn.QuestionRef - 1)];
					c.QuestionName = (System.String)reader[((int)SeanceQuestionColumn.QuestionName - 1)];
					c.LineNumber = (System.Int32)reader[((int)SeanceQuestionColumn.LineNumber - 1)];
					c.Status = (System.Boolean)reader[((int)SeanceQuestionColumn.Status - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.SeanceQuestion"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.SeanceQuestion"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Ekip.Framework.Entities.SeanceQuestion entity)
		{
			if (!reader.Read()) return;
			
			entity.QuestionId = (System.Int32)reader[((int)SeanceQuestionColumn.QuestionId - 1)];
			entity.QuestionRef = (System.String)reader[((int)SeanceQuestionColumn.QuestionRef - 1)];
			entity.QuestionName = (System.String)reader[((int)SeanceQuestionColumn.QuestionName - 1)];
			entity.LineNumber = (System.Int32)reader[((int)SeanceQuestionColumn.LineNumber - 1)];
			entity.Status = (System.Boolean)reader[((int)SeanceQuestionColumn.Status - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.SeanceQuestion"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.SeanceQuestion"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Ekip.Framework.Entities.SeanceQuestion entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.QuestionId = (System.Int32)dataRow["QuestionId"];
			entity.QuestionRef = (System.String)dataRow["QuestionRef"];
			entity.QuestionName = (System.String)dataRow["QuestionName"];
			entity.LineNumber = (System.Int32)dataRow["LineNumber"];
			entity.Status = (System.Boolean)dataRow["Status"];
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
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.SeanceQuestion"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.SeanceQuestion Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Ekip.Framework.Entities.SeanceQuestion entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByQuestionId methods when available
			
			#region SeanceQuestionOptionCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SeanceQuestionOption>|SeanceQuestionOptionCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SeanceQuestionOptionCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SeanceQuestionOptionCollection = DataRepository.SeanceQuestionOptionProvider.GetByQuestionId(transactionManager, entity.QuestionId);

				if (deep && entity.SeanceQuestionOptionCollection.Count > 0)
				{
					deepHandles.Add("SeanceQuestionOptionCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SeanceQuestionOption>) DataRepository.SeanceQuestionOptionProvider.DeepLoad,
						new object[] { transactionManager, entity.SeanceQuestionOptionCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region SeanceQuestionAnswerCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SeanceQuestionAnswer>|SeanceQuestionAnswerCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SeanceQuestionAnswerCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SeanceQuestionAnswerCollection = DataRepository.SeanceQuestionAnswerProvider.GetByQuestionId(transactionManager, entity.QuestionId);

				if (deep && entity.SeanceQuestionAnswerCollection.Count > 0)
				{
					deepHandles.Add("SeanceQuestionAnswerCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SeanceQuestionAnswer>) DataRepository.SeanceQuestionAnswerProvider.DeepLoad,
						new object[] { transactionManager, entity.SeanceQuestionAnswerCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Ekip.Framework.Entities.SeanceQuestion object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Ekip.Framework.Entities.SeanceQuestion instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.SeanceQuestion Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Ekip.Framework.Entities.SeanceQuestion entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<SeanceQuestionOption>
				if (CanDeepSave(entity.SeanceQuestionOptionCollection, "List<SeanceQuestionOption>|SeanceQuestionOptionCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SeanceQuestionOption child in entity.SeanceQuestionOptionCollection)
					{
						if(child.QuestionIdSource != null)
						{
							child.QuestionId = child.QuestionIdSource.QuestionId;
						}
						else
						{
							child.QuestionId = entity.QuestionId;
						}

					}

					if (entity.SeanceQuestionOptionCollection.Count > 0 || entity.SeanceQuestionOptionCollection.DeletedItems.Count > 0)
					{
						//DataRepository.SeanceQuestionOptionProvider.Save(transactionManager, entity.SeanceQuestionOptionCollection);
						
						deepHandles.Add("SeanceQuestionOptionCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SeanceQuestionOption >) DataRepository.SeanceQuestionOptionProvider.DeepSave,
							new object[] { transactionManager, entity.SeanceQuestionOptionCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<SeanceQuestionAnswer>
				if (CanDeepSave(entity.SeanceQuestionAnswerCollection, "List<SeanceQuestionAnswer>|SeanceQuestionAnswerCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SeanceQuestionAnswer child in entity.SeanceQuestionAnswerCollection)
					{
						if(child.QuestionIdSource != null)
						{
							child.QuestionId = child.QuestionIdSource.QuestionId;
						}
						else
						{
							child.QuestionId = entity.QuestionId;
						}

					}

					if (entity.SeanceQuestionAnswerCollection.Count > 0 || entity.SeanceQuestionAnswerCollection.DeletedItems.Count > 0)
					{
						//DataRepository.SeanceQuestionAnswerProvider.Save(transactionManager, entity.SeanceQuestionAnswerCollection);
						
						deepHandles.Add("SeanceQuestionAnswerCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SeanceQuestionAnswer >) DataRepository.SeanceQuestionAnswerProvider.DeepSave,
							new object[] { transactionManager, entity.SeanceQuestionAnswerCollection, deepSaveType, childTypes, innerList }
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
	
	#region SeanceQuestionChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Ekip.Framework.Entities.SeanceQuestion</c>
	///</summary>
	public enum SeanceQuestionChildEntityTypes
	{

		///<summary>
		/// Collection of <c>SeanceQuestion</c> as OneToMany for SeanceQuestionOptionCollection
		///</summary>
		[ChildEntityType(typeof(TList<SeanceQuestionOption>))]
		SeanceQuestionOptionCollection,

		///<summary>
		/// Collection of <c>SeanceQuestion</c> as OneToMany for SeanceQuestionAnswerCollection
		///</summary>
		[ChildEntityType(typeof(TList<SeanceQuestionAnswer>))]
		SeanceQuestionAnswerCollection,
	}
	
	#endregion SeanceQuestionChildEntityTypes
	
	#region SeanceQuestionFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;SeanceQuestionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SeanceQuestion"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SeanceQuestionFilterBuilder : SqlFilterBuilder<SeanceQuestionColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SeanceQuestionFilterBuilder class.
		/// </summary>
		public SeanceQuestionFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SeanceQuestionFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SeanceQuestionFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SeanceQuestionFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SeanceQuestionFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SeanceQuestionFilterBuilder
	
	#region SeanceQuestionParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;SeanceQuestionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SeanceQuestion"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SeanceQuestionParameterBuilder : ParameterizedSqlFilterBuilder<SeanceQuestionColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SeanceQuestionParameterBuilder class.
		/// </summary>
		public SeanceQuestionParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SeanceQuestionParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SeanceQuestionParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SeanceQuestionParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SeanceQuestionParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SeanceQuestionParameterBuilder
	
	#region SeanceQuestionSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;SeanceQuestionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SeanceQuestion"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class SeanceQuestionSortBuilder : SqlSortBuilder<SeanceQuestionColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SeanceQuestionSqlSortBuilder class.
		/// </summary>
		public SeanceQuestionSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion SeanceQuestionSortBuilder
	
} // end namespace
