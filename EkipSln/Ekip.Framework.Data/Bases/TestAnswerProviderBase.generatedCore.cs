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
	/// This class is the base class for any <see cref="TestAnswerProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class TestAnswerProviderBaseCore : EntityProviderBase<Ekip.Framework.Entities.TestAnswer, Ekip.Framework.Entities.TestAnswerKey>
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
		public override bool Delete(TransactionManager transactionManager, Ekip.Framework.Entities.TestAnswerKey key)
		{
			return Delete(transactionManager, key.AnswerId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_answerId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _answerId)
		{
			return Delete(null, _answerId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_answerId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _answerId);		
		
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
		public override Ekip.Framework.Entities.TestAnswer Get(TransactionManager transactionManager, Ekip.Framework.Entities.TestAnswerKey key, int start, int pageLength)
		{
			return GetByAnswerId(transactionManager, key.AnswerId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ClientAnswer index.
		/// </summary>
		/// <param name="_answerId"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.TestAnswer"/> class.</returns>
		public Ekip.Framework.Entities.TestAnswer GetByAnswerId(System.Int32 _answerId)
		{
			int count = -1;
			return GetByAnswerId(null,_answerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ClientAnswer index.
		/// </summary>
		/// <param name="_answerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.TestAnswer"/> class.</returns>
		public Ekip.Framework.Entities.TestAnswer GetByAnswerId(System.Int32 _answerId, int start, int pageLength)
		{
			int count = -1;
			return GetByAnswerId(null, _answerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ClientAnswer index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_answerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.TestAnswer"/> class.</returns>
		public Ekip.Framework.Entities.TestAnswer GetByAnswerId(TransactionManager transactionManager, System.Int32 _answerId)
		{
			int count = -1;
			return GetByAnswerId(transactionManager, _answerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ClientAnswer index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_answerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.TestAnswer"/> class.</returns>
		public Ekip.Framework.Entities.TestAnswer GetByAnswerId(TransactionManager transactionManager, System.Int32 _answerId, int start, int pageLength)
		{
			int count = -1;
			return GetByAnswerId(transactionManager, _answerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ClientAnswer index.
		/// </summary>
		/// <param name="_answerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.TestAnswer"/> class.</returns>
		public Ekip.Framework.Entities.TestAnswer GetByAnswerId(System.Int32 _answerId, int start, int pageLength, out int count)
		{
			return GetByAnswerId(null, _answerId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ClientAnswer index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_answerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.TestAnswer"/> class.</returns>
		public abstract Ekip.Framework.Entities.TestAnswer GetByAnswerId(TransactionManager transactionManager, System.Int32 _answerId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;TestAnswer&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;TestAnswer&gt;"/></returns>
		public static TList<TestAnswer> Fill(IDataReader reader, TList<TestAnswer> rows, int start, int pageLength)
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
				
				Ekip.Framework.Entities.TestAnswer c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("TestAnswer")
					.Append("|").Append((System.Int32)reader[((int)TestAnswerColumn.AnswerId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<TestAnswer>(
					key.ToString(), // EntityTrackingKey
					"TestAnswer",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Ekip.Framework.Entities.TestAnswer();
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
					c.AnswerId = (System.Int32)reader[((int)TestAnswerColumn.AnswerId - 1)];
					c.ClientId = (System.Int32)reader[((int)TestAnswerColumn.ClientId - 1)];
					c.TestId = (System.Int32)reader[((int)TestAnswerColumn.TestId - 1)];
					c.QuestionId = (System.Int32)reader[((int)TestAnswerColumn.QuestionId - 1)];
					c.OptionId = (System.Int32)reader[((int)TestAnswerColumn.OptionId - 1)];
					c.OptionDescription = (reader.IsDBNull(((int)TestAnswerColumn.OptionDescription - 1)))?null:(System.String)reader[((int)TestAnswerColumn.OptionDescription - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.TestAnswer"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.TestAnswer"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Ekip.Framework.Entities.TestAnswer entity)
		{
			if (!reader.Read()) return;
			
			entity.AnswerId = (System.Int32)reader[((int)TestAnswerColumn.AnswerId - 1)];
			entity.ClientId = (System.Int32)reader[((int)TestAnswerColumn.ClientId - 1)];
			entity.TestId = (System.Int32)reader[((int)TestAnswerColumn.TestId - 1)];
			entity.QuestionId = (System.Int32)reader[((int)TestAnswerColumn.QuestionId - 1)];
			entity.OptionId = (System.Int32)reader[((int)TestAnswerColumn.OptionId - 1)];
			entity.OptionDescription = (reader.IsDBNull(((int)TestAnswerColumn.OptionDescription - 1)))?null:(System.String)reader[((int)TestAnswerColumn.OptionDescription - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.TestAnswer"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.TestAnswer"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Ekip.Framework.Entities.TestAnswer entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.AnswerId = (System.Int32)dataRow["AnswerID"];
			entity.ClientId = (System.Int32)dataRow["ClientID"];
			entity.TestId = (System.Int32)dataRow["TestID"];
			entity.QuestionId = (System.Int32)dataRow["QuestionID"];
			entity.OptionId = (System.Int32)dataRow["OptionID"];
			entity.OptionDescription = Convert.IsDBNull(dataRow["OptionDescription"]) ? null : (System.String)dataRow["OptionDescription"];
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
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.TestAnswer"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.TestAnswer Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Ekip.Framework.Entities.TestAnswer entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the Ekip.Framework.Entities.TestAnswer object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Ekip.Framework.Entities.TestAnswer instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.TestAnswer Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Ekip.Framework.Entities.TestAnswer entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region TestAnswerChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Ekip.Framework.Entities.TestAnswer</c>
	///</summary>
	public enum TestAnswerChildEntityTypes
	{
	}
	
	#endregion TestAnswerChildEntityTypes
	
	#region TestAnswerFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;TestAnswerColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TestAnswer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TestAnswerFilterBuilder : SqlFilterBuilder<TestAnswerColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TestAnswerFilterBuilder class.
		/// </summary>
		public TestAnswerFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TestAnswerFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TestAnswerFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TestAnswerFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TestAnswerFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TestAnswerFilterBuilder
	
	#region TestAnswerParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;TestAnswerColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TestAnswer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TestAnswerParameterBuilder : ParameterizedSqlFilterBuilder<TestAnswerColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TestAnswerParameterBuilder class.
		/// </summary>
		public TestAnswerParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TestAnswerParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TestAnswerParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TestAnswerParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TestAnswerParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TestAnswerParameterBuilder
	
	#region TestAnswerSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;TestAnswerColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TestAnswer"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class TestAnswerSortBuilder : SqlSortBuilder<TestAnswerColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TestAnswerSqlSortBuilder class.
		/// </summary>
		public TestAnswerSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion TestAnswerSortBuilder
	
} // end namespace
