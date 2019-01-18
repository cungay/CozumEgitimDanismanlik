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
	/// This class is the base class for any <see cref="JobProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class JobProviderBaseCore : EntityProviderBase<Ekip.Framework.Entities.Job, Ekip.Framework.Entities.JobKey>
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
		public override bool Delete(TransactionManager transactionManager, Ekip.Framework.Entities.JobKey key)
		{
			return Delete(transactionManager, key.JobId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_jobId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _jobId)
		{
			return Delete(null, _jobId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _jobId);		
		
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
		public override Ekip.Framework.Entities.Job Get(TransactionManager transactionManager, Ekip.Framework.Entities.JobKey key, int start, int pageLength)
		{
			return GetByJobId(transactionManager, key.JobId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Job_FullName index.
		/// </summary>
		/// <param name="_jobName"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Job"/> class.</returns>
		public Ekip.Framework.Entities.Job GetByJobName(System.String _jobName)
		{
			int count = -1;
			return GetByJobName(null,_jobName, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Job_FullName index.
		/// </summary>
		/// <param name="_jobName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Job"/> class.</returns>
		public Ekip.Framework.Entities.Job GetByJobName(System.String _jobName, int start, int pageLength)
		{
			int count = -1;
			return GetByJobName(null, _jobName, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Job_FullName index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobName"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Job"/> class.</returns>
		public Ekip.Framework.Entities.Job GetByJobName(TransactionManager transactionManager, System.String _jobName)
		{
			int count = -1;
			return GetByJobName(transactionManager, _jobName, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Job_FullName index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Job"/> class.</returns>
		public Ekip.Framework.Entities.Job GetByJobName(TransactionManager transactionManager, System.String _jobName, int start, int pageLength)
		{
			int count = -1;
			return GetByJobName(transactionManager, _jobName, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Job_FullName index.
		/// </summary>
		/// <param name="_jobName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Job"/> class.</returns>
		public Ekip.Framework.Entities.Job GetByJobName(System.String _jobName, int start, int pageLength, out int count)
		{
			return GetByJobName(null, _jobName, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Job_FullName index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Job"/> class.</returns>
		public abstract Ekip.Framework.Entities.Job GetByJobName(TransactionManager transactionManager, System.String _jobName, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Job index.
		/// </summary>
		/// <param name="_jobId"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Job"/> class.</returns>
		public Ekip.Framework.Entities.Job GetByJobId(System.Int32 _jobId)
		{
			int count = -1;
			return GetByJobId(null,_jobId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Job index.
		/// </summary>
		/// <param name="_jobId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Job"/> class.</returns>
		public Ekip.Framework.Entities.Job GetByJobId(System.Int32 _jobId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobId(null, _jobId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Job index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Job"/> class.</returns>
		public Ekip.Framework.Entities.Job GetByJobId(TransactionManager transactionManager, System.Int32 _jobId)
		{
			int count = -1;
			return GetByJobId(transactionManager, _jobId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Job index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Job"/> class.</returns>
		public Ekip.Framework.Entities.Job GetByJobId(TransactionManager transactionManager, System.Int32 _jobId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobId(transactionManager, _jobId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Job index.
		/// </summary>
		/// <param name="_jobId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Job"/> class.</returns>
		public Ekip.Framework.Entities.Job GetByJobId(System.Int32 _jobId, int start, int pageLength, out int count)
		{
			return GetByJobId(null, _jobId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Job index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Job"/> class.</returns>
		public abstract Ekip.Framework.Entities.Job GetByJobId(TransactionManager transactionManager, System.Int32 _jobId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Job&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Job&gt;"/></returns>
		public static TList<Job> Fill(IDataReader reader, TList<Job> rows, int start, int pageLength)
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
				
				Ekip.Framework.Entities.Job c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Job")
					.Append("|").Append((System.Int32)reader[((int)JobColumn.JobId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Job>(
					key.ToString(), // EntityTrackingKey
					"Job",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Ekip.Framework.Entities.Job();
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
					c.JobId = (System.Int32)reader[((int)JobColumn.JobId - 1)];
					c.JobCode = (System.String)reader[((int)JobColumn.JobCode - 1)];
					c.JobName = (System.String)reader[((int)JobColumn.JobName - 1)];
					c.CreateDate = (System.DateTime)reader[((int)JobColumn.CreateDate - 1)];
					c.UpdateDate = (reader.IsDBNull(((int)JobColumn.UpdateDate - 1)))?null:(System.DateTime?)reader[((int)JobColumn.UpdateDate - 1)];
					c.CreateUserId = (System.Int32)reader[((int)JobColumn.CreateUserId - 1)];
					c.UpdateUserId = (reader.IsDBNull(((int)JobColumn.UpdateUserId - 1)))?null:(System.Int32?)reader[((int)JobColumn.UpdateUserId - 1)];
					c.Active = (System.Boolean)reader[((int)JobColumn.Active - 1)];
					c.Deleted = (System.Boolean)reader[((int)JobColumn.Deleted - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.Job"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Job"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Ekip.Framework.Entities.Job entity)
		{
			if (!reader.Read()) return;
			
			entity.JobId = (System.Int32)reader[((int)JobColumn.JobId - 1)];
			entity.JobCode = (System.String)reader[((int)JobColumn.JobCode - 1)];
			entity.JobName = (System.String)reader[((int)JobColumn.JobName - 1)];
			entity.CreateDate = (System.DateTime)reader[((int)JobColumn.CreateDate - 1)];
			entity.UpdateDate = (reader.IsDBNull(((int)JobColumn.UpdateDate - 1)))?null:(System.DateTime?)reader[((int)JobColumn.UpdateDate - 1)];
			entity.CreateUserId = (System.Int32)reader[((int)JobColumn.CreateUserId - 1)];
			entity.UpdateUserId = (reader.IsDBNull(((int)JobColumn.UpdateUserId - 1)))?null:(System.Int32?)reader[((int)JobColumn.UpdateUserId - 1)];
			entity.Active = (System.Boolean)reader[((int)JobColumn.Active - 1)];
			entity.Deleted = (System.Boolean)reader[((int)JobColumn.Deleted - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.Job"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Job"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Ekip.Framework.Entities.Job entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.JobId = (System.Int32)dataRow["JobId"];
			entity.JobCode = (System.String)dataRow["JobCode"];
			entity.JobName = (System.String)dataRow["JobName"];
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
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Job"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.Job Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Ekip.Framework.Entities.Job entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the Ekip.Framework.Entities.Job object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Ekip.Framework.Entities.Job instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.Job Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Ekip.Framework.Entities.Job entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region JobChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Ekip.Framework.Entities.Job</c>
	///</summary>
	public enum JobChildEntityTypes
	{
	}
	
	#endregion JobChildEntityTypes
	
	#region JobFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;JobColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Job"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobFilterBuilder : SqlFilterBuilder<JobColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobFilterBuilder class.
		/// </summary>
		public JobFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobFilterBuilder
	
	#region JobParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;JobColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Job"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobParameterBuilder : ParameterizedSqlFilterBuilder<JobColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobParameterBuilder class.
		/// </summary>
		public JobParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobParameterBuilder
	
	#region JobSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;JobColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Job"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class JobSortBuilder : SqlSortBuilder<JobColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobSqlSortBuilder class.
		/// </summary>
		public JobSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion JobSortBuilder
	
} // end namespace
