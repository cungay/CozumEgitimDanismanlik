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
	/// This class is the base class for any <see cref="EducationProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class EducationProviderBaseCore : EntityProviderBase<Ekip.Framework.Entities.Education, Ekip.Framework.Entities.EducationKey>
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
		public override bool Delete(TransactionManager transactionManager, Ekip.Framework.Entities.EducationKey key)
		{
			return Delete(transactionManager, key.EducationId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_educationId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _educationId)
		{
			return Delete(null, _educationId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_educationId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _educationId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Education_Client key.
		///		FK_Education_Client Description: 
		/// </summary>
		/// <param name="_clientId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Education objects.</returns>
		public TList<Education> GetByClientId(System.Int32? _clientId)
		{
			int count = -1;
			return GetByClientId(_clientId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Education_Client key.
		///		FK_Education_Client Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_clientId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Education objects.</returns>
		/// <remarks></remarks>
		public TList<Education> GetByClientId(TransactionManager transactionManager, System.Int32? _clientId)
		{
			int count = -1;
			return GetByClientId(transactionManager, _clientId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Education_Client key.
		///		FK_Education_Client Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_clientId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Education objects.</returns>
		public TList<Education> GetByClientId(TransactionManager transactionManager, System.Int32? _clientId, int start, int pageLength)
		{
			int count = -1;
			return GetByClientId(transactionManager, _clientId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Education_Client key.
		///		fkEducationClient Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_clientId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Education objects.</returns>
		public TList<Education> GetByClientId(System.Int32? _clientId, int start, int pageLength)
		{
			int count =  -1;
			return GetByClientId(null, _clientId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Education_Client key.
		///		fkEducationClient Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_clientId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Education objects.</returns>
		public TList<Education> GetByClientId(System.Int32? _clientId, int start, int pageLength,out int count)
		{
			return GetByClientId(null, _clientId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Education_Client key.
		///		FK_Education_Client Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_clientId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Education objects.</returns>
		public abstract TList<Education> GetByClientId(TransactionManager transactionManager, System.Int32? _clientId, int start, int pageLength, out int count);
		
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
		public override Ekip.Framework.Entities.Education Get(TransactionManager transactionManager, Ekip.Framework.Entities.EducationKey key, int start, int pageLength)
		{
			return GetByEducationId(transactionManager, key.EducationId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Educator index.
		/// </summary>
		/// <param name="_educationId"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Education"/> class.</returns>
		public Ekip.Framework.Entities.Education GetByEducationId(System.Int32 _educationId)
		{
			int count = -1;
			return GetByEducationId(null,_educationId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Educator index.
		/// </summary>
		/// <param name="_educationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Education"/> class.</returns>
		public Ekip.Framework.Entities.Education GetByEducationId(System.Int32 _educationId, int start, int pageLength)
		{
			int count = -1;
			return GetByEducationId(null, _educationId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Educator index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_educationId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Education"/> class.</returns>
		public Ekip.Framework.Entities.Education GetByEducationId(TransactionManager transactionManager, System.Int32 _educationId)
		{
			int count = -1;
			return GetByEducationId(transactionManager, _educationId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Educator index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_educationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Education"/> class.</returns>
		public Ekip.Framework.Entities.Education GetByEducationId(TransactionManager transactionManager, System.Int32 _educationId, int start, int pageLength)
		{
			int count = -1;
			return GetByEducationId(transactionManager, _educationId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Educator index.
		/// </summary>
		/// <param name="_educationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Education"/> class.</returns>
		public Ekip.Framework.Entities.Education GetByEducationId(System.Int32 _educationId, int start, int pageLength, out int count)
		{
			return GetByEducationId(null, _educationId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Educator index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_educationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Education"/> class.</returns>
		public abstract Ekip.Framework.Entities.Education GetByEducationId(TransactionManager transactionManager, System.Int32 _educationId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Education&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Education&gt;"/></returns>
		public static TList<Education> Fill(IDataReader reader, TList<Education> rows, int start, int pageLength)
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
				
				Ekip.Framework.Entities.Education c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Education")
					.Append("|").Append((System.Int32)reader[((int)EducationColumn.EducationId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Education>(
					key.ToString(), // EntityTrackingKey
					"Education",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Ekip.Framework.Entities.Education();
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
					c.EducationId = (System.Int32)reader[((int)EducationColumn.EducationId - 1)];
					c.ClientId = (reader.IsDBNull(((int)EducationColumn.ClientId - 1)))?null:(System.Int32?)reader[((int)EducationColumn.ClientId - 1)];
					c.TeacherName = (System.String)reader[((int)EducationColumn.TeacherName - 1)];
					c.TeacherEmail = (reader.IsDBNull(((int)EducationColumn.TeacherEmail - 1)))?null:(System.String)reader[((int)EducationColumn.TeacherEmail - 1)];
					c.SchoolName = (reader.IsDBNull(((int)EducationColumn.SchoolName - 1)))?null:(System.String)reader[((int)EducationColumn.SchoolName - 1)];
					c.ClassRoom = (System.String)reader[((int)EducationColumn.ClassRoom - 1)];
					c.Note = (reader.IsDBNull(((int)EducationColumn.Note - 1)))?null:(System.String)reader[((int)EducationColumn.Note - 1)];
					c.CreateOn = (System.DateTime)reader[((int)EducationColumn.CreateOn - 1)];
					c.UpdateOn = (reader.IsDBNull(((int)EducationColumn.UpdateOn - 1)))?null:(System.DateTime?)reader[((int)EducationColumn.UpdateOn - 1)];
					c.UserId = (System.Int32)reader[((int)EducationColumn.UserId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.Education"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Education"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Ekip.Framework.Entities.Education entity)
		{
			if (!reader.Read()) return;
			
			entity.EducationId = (System.Int32)reader[((int)EducationColumn.EducationId - 1)];
			entity.ClientId = (reader.IsDBNull(((int)EducationColumn.ClientId - 1)))?null:(System.Int32?)reader[((int)EducationColumn.ClientId - 1)];
			entity.TeacherName = (System.String)reader[((int)EducationColumn.TeacherName - 1)];
			entity.TeacherEmail = (reader.IsDBNull(((int)EducationColumn.TeacherEmail - 1)))?null:(System.String)reader[((int)EducationColumn.TeacherEmail - 1)];
			entity.SchoolName = (reader.IsDBNull(((int)EducationColumn.SchoolName - 1)))?null:(System.String)reader[((int)EducationColumn.SchoolName - 1)];
			entity.ClassRoom = (System.String)reader[((int)EducationColumn.ClassRoom - 1)];
			entity.Note = (reader.IsDBNull(((int)EducationColumn.Note - 1)))?null:(System.String)reader[((int)EducationColumn.Note - 1)];
			entity.CreateOn = (System.DateTime)reader[((int)EducationColumn.CreateOn - 1)];
			entity.UpdateOn = (reader.IsDBNull(((int)EducationColumn.UpdateOn - 1)))?null:(System.DateTime?)reader[((int)EducationColumn.UpdateOn - 1)];
			entity.UserId = (System.Int32)reader[((int)EducationColumn.UserId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.Education"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Education"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Ekip.Framework.Entities.Education entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.EducationId = (System.Int32)dataRow["EducationID"];
			entity.ClientId = Convert.IsDBNull(dataRow["ClientID"]) ? null : (System.Int32?)dataRow["ClientID"];
			entity.TeacherName = (System.String)dataRow["TeacherName"];
			entity.TeacherEmail = Convert.IsDBNull(dataRow["TeacherEmail"]) ? null : (System.String)dataRow["TeacherEmail"];
			entity.SchoolName = Convert.IsDBNull(dataRow["SchoolName"]) ? null : (System.String)dataRow["SchoolName"];
			entity.ClassRoom = (System.String)dataRow["ClassRoom"];
			entity.Note = Convert.IsDBNull(dataRow["Note"]) ? null : (System.String)dataRow["Note"];
			entity.CreateOn = (System.DateTime)dataRow["CreateOn"];
			entity.UpdateOn = Convert.IsDBNull(dataRow["UpdateOn"]) ? null : (System.DateTime?)dataRow["UpdateOn"];
			entity.UserId = (System.Int32)dataRow["UserID"];
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
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Education"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.Education Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Ekip.Framework.Entities.Education entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region ClientIdSource	
			if (CanDeepLoad(entity, "Client|ClientIdSource", deepLoadType, innerList) 
				&& entity.ClientIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.ClientId ?? (int)0);
				Client tmpEntity = EntityManager.LocateEntity<Client>(EntityLocator.ConstructKeyFromPkItems(typeof(Client), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ClientIdSource = tmpEntity;
				else
					entity.ClientIdSource = DataRepository.ClientProvider.GetByClientId(transactionManager, (entity.ClientId ?? (int)0));		
				
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
		/// Deep Save the entire object graph of the Ekip.Framework.Entities.Education object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Ekip.Framework.Entities.Education instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.Education Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Ekip.Framework.Entities.Education entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region EducationChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Ekip.Framework.Entities.Education</c>
	///</summary>
	public enum EducationChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Client</c> at ClientIdSource
		///</summary>
		[ChildEntityType(typeof(Client))]
		Client,
		}
	
	#endregion EducationChildEntityTypes
	
	#region EducationFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EducationColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Education"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EducationFilterBuilder : SqlFilterBuilder<EducationColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EducationFilterBuilder class.
		/// </summary>
		public EducationFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the EducationFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EducationFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EducationFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EducationFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EducationFilterBuilder
	
	#region EducationParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EducationColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Education"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EducationParameterBuilder : ParameterizedSqlFilterBuilder<EducationColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EducationParameterBuilder class.
		/// </summary>
		public EducationParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the EducationParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EducationParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EducationParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EducationParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EducationParameterBuilder
	
	#region EducationSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EducationColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Education"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class EducationSortBuilder : SqlSortBuilder<EducationColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EducationSqlSortBuilder class.
		/// </summary>
		public EducationSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion EducationSortBuilder
	
} // end namespace
