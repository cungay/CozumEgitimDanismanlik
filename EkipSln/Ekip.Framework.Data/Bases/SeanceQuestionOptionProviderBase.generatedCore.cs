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
	/// This class is the base class for any <see cref="SeanceQuestionOptionProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SeanceQuestionOptionProviderBaseCore : EntityProviderBase<Ekip.Framework.Entities.SeanceQuestionOption, Ekip.Framework.Entities.SeanceQuestionOptionKey>
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
		public override bool Delete(TransactionManager transactionManager, Ekip.Framework.Entities.SeanceQuestionOptionKey key)
		{
			return Delete(transactionManager, key.OptionId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_optionId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _optionId)
		{
			return Delete(null, _optionId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_optionId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _optionId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SeanceQuestion_Option_SeanceQuestion key.
		///		FK_SeanceQuestion_Option_SeanceQuestion Description: 
		/// </summary>
		/// <param name="_questionId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.SeanceQuestionOption objects.</returns>
		public TList<SeanceQuestionOption> GetByQuestionId(System.Int32 _questionId)
		{
			int count = -1;
			return GetByQuestionId(_questionId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SeanceQuestion_Option_SeanceQuestion key.
		///		FK_SeanceQuestion_Option_SeanceQuestion Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_questionId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.SeanceQuestionOption objects.</returns>
		/// <remarks></remarks>
		public TList<SeanceQuestionOption> GetByQuestionId(TransactionManager transactionManager, System.Int32 _questionId)
		{
			int count = -1;
			return GetByQuestionId(transactionManager, _questionId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_SeanceQuestion_Option_SeanceQuestion key.
		///		FK_SeanceQuestion_Option_SeanceQuestion Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_questionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.SeanceQuestionOption objects.</returns>
		public TList<SeanceQuestionOption> GetByQuestionId(TransactionManager transactionManager, System.Int32 _questionId, int start, int pageLength)
		{
			int count = -1;
			return GetByQuestionId(transactionManager, _questionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SeanceQuestion_Option_SeanceQuestion key.
		///		fkSeanceQuestionOptionSeanceQuestion Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_questionId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.SeanceQuestionOption objects.</returns>
		public TList<SeanceQuestionOption> GetByQuestionId(System.Int32 _questionId, int start, int pageLength)
		{
			int count =  -1;
			return GetByQuestionId(null, _questionId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SeanceQuestion_Option_SeanceQuestion key.
		///		fkSeanceQuestionOptionSeanceQuestion Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_questionId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.SeanceQuestionOption objects.</returns>
		public TList<SeanceQuestionOption> GetByQuestionId(System.Int32 _questionId, int start, int pageLength,out int count)
		{
			return GetByQuestionId(null, _questionId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SeanceQuestion_Option_SeanceQuestion key.
		///		FK_SeanceQuestion_Option_SeanceQuestion Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_questionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.SeanceQuestionOption objects.</returns>
		public abstract TList<SeanceQuestionOption> GetByQuestionId(TransactionManager transactionManager, System.Int32 _questionId, int start, int pageLength, out int count);
		
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
		public override Ekip.Framework.Entities.SeanceQuestionOption Get(TransactionManager transactionManager, Ekip.Framework.Entities.SeanceQuestionOptionKey key, int start, int pageLength)
		{
			return GetByOptionId(transactionManager, key.OptionId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_SeanceQuestion_Option index.
		/// </summary>
		/// <param name="_optionId"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.SeanceQuestionOption"/> class.</returns>
		public Ekip.Framework.Entities.SeanceQuestionOption GetByOptionId(System.Int32 _optionId)
		{
			int count = -1;
			return GetByOptionId(null,_optionId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SeanceQuestion_Option index.
		/// </summary>
		/// <param name="_optionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.SeanceQuestionOption"/> class.</returns>
		public Ekip.Framework.Entities.SeanceQuestionOption GetByOptionId(System.Int32 _optionId, int start, int pageLength)
		{
			int count = -1;
			return GetByOptionId(null, _optionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SeanceQuestion_Option index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_optionId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.SeanceQuestionOption"/> class.</returns>
		public Ekip.Framework.Entities.SeanceQuestionOption GetByOptionId(TransactionManager transactionManager, System.Int32 _optionId)
		{
			int count = -1;
			return GetByOptionId(transactionManager, _optionId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SeanceQuestion_Option index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_optionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.SeanceQuestionOption"/> class.</returns>
		public Ekip.Framework.Entities.SeanceQuestionOption GetByOptionId(TransactionManager transactionManager, System.Int32 _optionId, int start, int pageLength)
		{
			int count = -1;
			return GetByOptionId(transactionManager, _optionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SeanceQuestion_Option index.
		/// </summary>
		/// <param name="_optionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.SeanceQuestionOption"/> class.</returns>
		public Ekip.Framework.Entities.SeanceQuestionOption GetByOptionId(System.Int32 _optionId, int start, int pageLength, out int count)
		{
			return GetByOptionId(null, _optionId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SeanceQuestion_Option index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_optionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.SeanceQuestionOption"/> class.</returns>
		public abstract Ekip.Framework.Entities.SeanceQuestionOption GetByOptionId(TransactionManager transactionManager, System.Int32 _optionId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;SeanceQuestionOption&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;SeanceQuestionOption&gt;"/></returns>
		public static TList<SeanceQuestionOption> Fill(IDataReader reader, TList<SeanceQuestionOption> rows, int start, int pageLength)
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
				
				Ekip.Framework.Entities.SeanceQuestionOption c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("SeanceQuestionOption")
					.Append("|").Append((System.Int32)reader[((int)SeanceQuestionOptionColumn.OptionId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<SeanceQuestionOption>(
					key.ToString(), // EntityTrackingKey
					"SeanceQuestionOption",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Ekip.Framework.Entities.SeanceQuestionOption();
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
					c.OptionId = (System.Int32)reader[((int)SeanceQuestionOptionColumn.OptionId - 1)];
					c.QuestionId = (System.Int32)reader[((int)SeanceQuestionOptionColumn.QuestionId - 1)];
					c.OptionName = (System.String)reader[((int)SeanceQuestionOptionColumn.OptionName - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.SeanceQuestionOption"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.SeanceQuestionOption"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Ekip.Framework.Entities.SeanceQuestionOption entity)
		{
			if (!reader.Read()) return;
			
			entity.OptionId = (System.Int32)reader[((int)SeanceQuestionOptionColumn.OptionId - 1)];
			entity.QuestionId = (System.Int32)reader[((int)SeanceQuestionOptionColumn.QuestionId - 1)];
			entity.OptionName = (System.String)reader[((int)SeanceQuestionOptionColumn.OptionName - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.SeanceQuestionOption"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.SeanceQuestionOption"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Ekip.Framework.Entities.SeanceQuestionOption entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.OptionId = (System.Int32)dataRow["OptionId"];
			entity.QuestionId = (System.Int32)dataRow["QuestionId"];
			entity.OptionName = (System.String)dataRow["OptionName"];
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
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.SeanceQuestionOption"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.SeanceQuestionOption Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Ekip.Framework.Entities.SeanceQuestionOption entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region QuestionIdSource	
			if (CanDeepLoad(entity, "SeanceQuestion|QuestionIdSource", deepLoadType, innerList) 
				&& entity.QuestionIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.QuestionId;
				SeanceQuestion tmpEntity = EntityManager.LocateEntity<SeanceQuestion>(EntityLocator.ConstructKeyFromPkItems(typeof(SeanceQuestion), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.QuestionIdSource = tmpEntity;
				else
					entity.QuestionIdSource = DataRepository.SeanceQuestionProvider.GetByQuestionId(transactionManager, entity.QuestionId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'QuestionIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.QuestionIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.SeanceQuestionProvider.DeepLoad(transactionManager, entity.QuestionIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion QuestionIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByOptionId methods when available
			
			#region SeanceQuestionAnswerCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SeanceQuestionAnswer>|SeanceQuestionAnswerCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SeanceQuestionAnswerCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SeanceQuestionAnswerCollection = DataRepository.SeanceQuestionAnswerProvider.GetByOptionId(transactionManager, entity.OptionId);

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
		/// Deep Save the entire object graph of the Ekip.Framework.Entities.SeanceQuestionOption object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Ekip.Framework.Entities.SeanceQuestionOption instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.SeanceQuestionOption Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Ekip.Framework.Entities.SeanceQuestionOption entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region QuestionIdSource
			if (CanDeepSave(entity, "SeanceQuestion|QuestionIdSource", deepSaveType, innerList) 
				&& entity.QuestionIdSource != null)
			{
				DataRepository.SeanceQuestionProvider.Save(transactionManager, entity.QuestionIdSource);
				entity.QuestionId = entity.QuestionIdSource.QuestionId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<SeanceQuestionAnswer>
				if (CanDeepSave(entity.SeanceQuestionAnswerCollection, "List<SeanceQuestionAnswer>|SeanceQuestionAnswerCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SeanceQuestionAnswer child in entity.SeanceQuestionAnswerCollection)
					{
						if(child.OptionIdSource != null)
						{
							child.OptionId = child.OptionIdSource.OptionId;
						}
						else
						{
							child.OptionId = entity.OptionId;
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
	
	#region SeanceQuestionOptionChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Ekip.Framework.Entities.SeanceQuestionOption</c>
	///</summary>
	public enum SeanceQuestionOptionChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>SeanceQuestion</c> at QuestionIdSource
		///</summary>
		[ChildEntityType(typeof(SeanceQuestion))]
		SeanceQuestion,
	
		///<summary>
		/// Collection of <c>SeanceQuestionOption</c> as OneToMany for SeanceQuestionAnswerCollection
		///</summary>
		[ChildEntityType(typeof(TList<SeanceQuestionAnswer>))]
		SeanceQuestionAnswerCollection,
	}
	
	#endregion SeanceQuestionOptionChildEntityTypes
	
	#region SeanceQuestionOptionFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;SeanceQuestionOptionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SeanceQuestionOption"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SeanceQuestionOptionFilterBuilder : SqlFilterBuilder<SeanceQuestionOptionColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SeanceQuestionOptionFilterBuilder class.
		/// </summary>
		public SeanceQuestionOptionFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SeanceQuestionOptionFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SeanceQuestionOptionFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SeanceQuestionOptionFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SeanceQuestionOptionFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SeanceQuestionOptionFilterBuilder
	
	#region SeanceQuestionOptionParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;SeanceQuestionOptionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SeanceQuestionOption"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SeanceQuestionOptionParameterBuilder : ParameterizedSqlFilterBuilder<SeanceQuestionOptionColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SeanceQuestionOptionParameterBuilder class.
		/// </summary>
		public SeanceQuestionOptionParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SeanceQuestionOptionParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SeanceQuestionOptionParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SeanceQuestionOptionParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SeanceQuestionOptionParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SeanceQuestionOptionParameterBuilder
	
	#region SeanceQuestionOptionSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;SeanceQuestionOptionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SeanceQuestionOption"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class SeanceQuestionOptionSortBuilder : SqlSortBuilder<SeanceQuestionOptionColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SeanceQuestionOptionSqlSortBuilder class.
		/// </summary>
		public SeanceQuestionOptionSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion SeanceQuestionOptionSortBuilder
	
} // end namespace
