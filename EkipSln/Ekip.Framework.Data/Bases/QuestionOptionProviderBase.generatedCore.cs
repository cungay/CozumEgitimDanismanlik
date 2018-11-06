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
	/// This class is the base class for any <see cref="QuestionOptionProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class QuestionOptionProviderBaseCore : EntityProviderBase<Ekip.Framework.Entities.QuestionOption, Ekip.Framework.Entities.QuestionOptionKey>
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
		public override bool Delete(TransactionManager transactionManager, Ekip.Framework.Entities.QuestionOptionKey key)
		{
			return Delete(transactionManager, key.QuestionId, key.OptionId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_questionId">. Primary Key.</param>
		/// <param name="_optionId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _questionId, System.Int32 _optionId)
		{
			return Delete(null, _questionId, _optionId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_questionId">. Primary Key.</param>
		/// <param name="_optionId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _questionId, System.Int32 _optionId);		
		
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
		public override Ekip.Framework.Entities.QuestionOption Get(TransactionManager transactionManager, Ekip.Framework.Entities.QuestionOptionKey key, int start, int pageLength)
		{
			return GetByQuestionIdOptionId(transactionManager, key.QuestionId, key.OptionId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Question_Option index.
		/// </summary>
		/// <param name="_questionId"></param>
		/// <param name="_optionId"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.QuestionOption"/> class.</returns>
		public Ekip.Framework.Entities.QuestionOption GetByQuestionIdOptionId(System.Int32 _questionId, System.Int32 _optionId)
		{
			int count = -1;
			return GetByQuestionIdOptionId(null,_questionId, _optionId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Question_Option index.
		/// </summary>
		/// <param name="_questionId"></param>
		/// <param name="_optionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.QuestionOption"/> class.</returns>
		public Ekip.Framework.Entities.QuestionOption GetByQuestionIdOptionId(System.Int32 _questionId, System.Int32 _optionId, int start, int pageLength)
		{
			int count = -1;
			return GetByQuestionIdOptionId(null, _questionId, _optionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Question_Option index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_questionId"></param>
		/// <param name="_optionId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.QuestionOption"/> class.</returns>
		public Ekip.Framework.Entities.QuestionOption GetByQuestionIdOptionId(TransactionManager transactionManager, System.Int32 _questionId, System.Int32 _optionId)
		{
			int count = -1;
			return GetByQuestionIdOptionId(transactionManager, _questionId, _optionId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Question_Option index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_questionId"></param>
		/// <param name="_optionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.QuestionOption"/> class.</returns>
		public Ekip.Framework.Entities.QuestionOption GetByQuestionIdOptionId(TransactionManager transactionManager, System.Int32 _questionId, System.Int32 _optionId, int start, int pageLength)
		{
			int count = -1;
			return GetByQuestionIdOptionId(transactionManager, _questionId, _optionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Question_Option index.
		/// </summary>
		/// <param name="_questionId"></param>
		/// <param name="_optionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.QuestionOption"/> class.</returns>
		public Ekip.Framework.Entities.QuestionOption GetByQuestionIdOptionId(System.Int32 _questionId, System.Int32 _optionId, int start, int pageLength, out int count)
		{
			return GetByQuestionIdOptionId(null, _questionId, _optionId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Question_Option index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_questionId"></param>
		/// <param name="_optionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.QuestionOption"/> class.</returns>
		public abstract Ekip.Framework.Entities.QuestionOption GetByQuestionIdOptionId(TransactionManager transactionManager, System.Int32 _questionId, System.Int32 _optionId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;QuestionOption&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;QuestionOption&gt;"/></returns>
		public static TList<QuestionOption> Fill(IDataReader reader, TList<QuestionOption> rows, int start, int pageLength)
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
				
				Ekip.Framework.Entities.QuestionOption c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("QuestionOption")
					.Append("|").Append((System.Int32)reader[((int)QuestionOptionColumn.QuestionId - 1)])
					.Append("|").Append((System.Int32)reader[((int)QuestionOptionColumn.OptionId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<QuestionOption>(
					key.ToString(), // EntityTrackingKey
					"QuestionOption",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Ekip.Framework.Entities.QuestionOption();
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
					c.QuestionId = (System.Int32)reader[((int)QuestionOptionColumn.QuestionId - 1)];
					c.OriginalQuestionId = c.QuestionId;
					c.OptionId = (System.Int32)reader[((int)QuestionOptionColumn.OptionId - 1)];
					c.OriginalOptionId = c.OptionId;
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.QuestionOption"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.QuestionOption"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Ekip.Framework.Entities.QuestionOption entity)
		{
			if (!reader.Read()) return;
			
			entity.QuestionId = (System.Int32)reader[((int)QuestionOptionColumn.QuestionId - 1)];
			entity.OriginalQuestionId = (System.Int32)reader["QuestionID"];
			entity.OptionId = (System.Int32)reader[((int)QuestionOptionColumn.OptionId - 1)];
			entity.OriginalOptionId = (System.Int32)reader["OptionID"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.QuestionOption"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.QuestionOption"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Ekip.Framework.Entities.QuestionOption entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.QuestionId = (System.Int32)dataRow["QuestionID"];
			entity.OriginalQuestionId = (System.Int32)dataRow["QuestionID"];
			entity.OptionId = (System.Int32)dataRow["OptionID"];
			entity.OriginalOptionId = (System.Int32)dataRow["OptionID"];
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
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.QuestionOption"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.QuestionOption Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Ekip.Framework.Entities.QuestionOption entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the Ekip.Framework.Entities.QuestionOption object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Ekip.Framework.Entities.QuestionOption instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.QuestionOption Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Ekip.Framework.Entities.QuestionOption entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region QuestionOptionChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Ekip.Framework.Entities.QuestionOption</c>
	///</summary>
	public enum QuestionOptionChildEntityTypes
	{
	}
	
	#endregion QuestionOptionChildEntityTypes
	
	#region QuestionOptionFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;QuestionOptionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="QuestionOption"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuestionOptionFilterBuilder : SqlFilterBuilder<QuestionOptionColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuestionOptionFilterBuilder class.
		/// </summary>
		public QuestionOptionFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the QuestionOptionFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public QuestionOptionFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the QuestionOptionFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public QuestionOptionFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion QuestionOptionFilterBuilder
	
	#region QuestionOptionParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;QuestionOptionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="QuestionOption"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuestionOptionParameterBuilder : ParameterizedSqlFilterBuilder<QuestionOptionColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuestionOptionParameterBuilder class.
		/// </summary>
		public QuestionOptionParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the QuestionOptionParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public QuestionOptionParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the QuestionOptionParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public QuestionOptionParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion QuestionOptionParameterBuilder
	
	#region QuestionOptionSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;QuestionOptionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="QuestionOption"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class QuestionOptionSortBuilder : SqlSortBuilder<QuestionOptionColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuestionOptionSqlSortBuilder class.
		/// </summary>
		public QuestionOptionSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion QuestionOptionSortBuilder
	
} // end namespace
