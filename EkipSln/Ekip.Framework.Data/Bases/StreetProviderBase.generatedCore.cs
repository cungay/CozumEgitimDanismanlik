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
	/// This class is the base class for any <see cref="StreetProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class StreetProviderBaseCore : EntityProviderBase<Ekip.Framework.Entities.Street, Ekip.Framework.Entities.StreetKey>
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
		public override bool Delete(TransactionManager transactionManager, Ekip.Framework.Entities.StreetKey key)
		{
			return Delete(transactionManager, key.Id);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_ıd">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _ıd)
		{
			return Delete(null, _ıd);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_ıd">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _ıd);		
		
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
		public override Ekip.Framework.Entities.Street Get(TransactionManager transactionManager, Ekip.Framework.Entities.StreetKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Street index.
		/// </summary>
		/// <param name="_neighborhoodId"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Street&gt;"/> class.</returns>
		public TList<Street> GetByNeighborhoodId(System.Int32 _neighborhoodId)
		{
			int count = -1;
			return GetByNeighborhoodId(null,_neighborhoodId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Street index.
		/// </summary>
		/// <param name="_neighborhoodId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Street&gt;"/> class.</returns>
		public TList<Street> GetByNeighborhoodId(System.Int32 _neighborhoodId, int start, int pageLength)
		{
			int count = -1;
			return GetByNeighborhoodId(null, _neighborhoodId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Street index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_neighborhoodId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Street&gt;"/> class.</returns>
		public TList<Street> GetByNeighborhoodId(TransactionManager transactionManager, System.Int32 _neighborhoodId)
		{
			int count = -1;
			return GetByNeighborhoodId(transactionManager, _neighborhoodId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Street index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_neighborhoodId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Street&gt;"/> class.</returns>
		public TList<Street> GetByNeighborhoodId(TransactionManager transactionManager, System.Int32 _neighborhoodId, int start, int pageLength)
		{
			int count = -1;
			return GetByNeighborhoodId(transactionManager, _neighborhoodId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Street index.
		/// </summary>
		/// <param name="_neighborhoodId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Street&gt;"/> class.</returns>
		public TList<Street> GetByNeighborhoodId(System.Int32 _neighborhoodId, int start, int pageLength, out int count)
		{
			return GetByNeighborhoodId(null, _neighborhoodId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Street index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_neighborhoodId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Street&gt;"/> class.</returns>
		public abstract TList<Street> GetByNeighborhoodId(TransactionManager transactionManager, System.Int32 _neighborhoodId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Street index.
		/// </summary>
		/// <param name="_ıd"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Street"/> class.</returns>
		public Ekip.Framework.Entities.Street GetById(System.Int32 _ıd)
		{
			int count = -1;
			return GetById(null,_ıd, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Street index.
		/// </summary>
		/// <param name="_ıd"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Street"/> class.</returns>
		public Ekip.Framework.Entities.Street GetById(System.Int32 _ıd, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _ıd, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Street index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_ıd"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Street"/> class.</returns>
		public Ekip.Framework.Entities.Street GetById(TransactionManager transactionManager, System.Int32 _ıd)
		{
			int count = -1;
			return GetById(transactionManager, _ıd, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Street index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_ıd"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Street"/> class.</returns>
		public Ekip.Framework.Entities.Street GetById(TransactionManager transactionManager, System.Int32 _ıd, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _ıd, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Street index.
		/// </summary>
		/// <param name="_ıd"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Street"/> class.</returns>
		public Ekip.Framework.Entities.Street GetById(System.Int32 _ıd, int start, int pageLength, out int count)
		{
			return GetById(null, _ıd, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Street index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_ıd"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Street"/> class.</returns>
		public abstract Ekip.Framework.Entities.Street GetById(TransactionManager transactionManager, System.Int32 _ıd, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region Street_GetByNeighborhoodId 
		
		/// <summary>
		///	This method wrap the 'Street_GetByNeighborhoodId' stored procedure. 
		/// </summary>
		/// <param name="neighborhoodId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Street&gt;"/> instance.</returns>
		public TList<Street> GetByNeighborhoodId(System.Int32? neighborhoodId)
		{
			return GetByNeighborhoodId(null, 0, int.MaxValue , neighborhoodId);
		}
		
		/// <summary>
		///	This method wrap the 'Street_GetByNeighborhoodId' stored procedure. 
		/// </summary>
		/// <param name="neighborhoodId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Street&gt;"/> instance.</returns>
		public TList<Street> GetByNeighborhoodId(int start, int pageLength, System.Int32? neighborhoodId)
		{
			return GetByNeighborhoodId(null, start, pageLength , neighborhoodId);
		}
				
		/// <summary>
		///	This method wrap the 'Street_GetByNeighborhoodId' stored procedure. 
		/// </summary>
		/// <param name="neighborhoodId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Street&gt;"/> instance.</returns>
		public TList<Street> GetByNeighborhoodId(TransactionManager transactionManager, System.Int32? neighborhoodId)
		{
			return GetByNeighborhoodId(transactionManager, 0, int.MaxValue , neighborhoodId);
		}
		
		/// <summary>
		///	This method wrap the 'Street_GetByNeighborhoodId' stored procedure. 
		/// </summary>
		/// <param name="neighborhoodId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Street&gt;"/> instance.</returns>
		public abstract TList<Street> GetByNeighborhoodId(TransactionManager transactionManager, int start, int pageLength , System.Int32? neighborhoodId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Street&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Street&gt;"/></returns>
		public static TList<Street> Fill(IDataReader reader, TList<Street> rows, int start, int pageLength)
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
				
				Ekip.Framework.Entities.Street c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Street")
					.Append("|").Append((System.Int32)reader[((int)StreetColumn.Id - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Street>(
					key.ToString(), // EntityTrackingKey
					"Street",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Ekip.Framework.Entities.Street();
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
					c.Id = (System.Int32)reader[((int)StreetColumn.Id - 1)];
					c.AdminId = (System.Int64)reader[((int)StreetColumn.AdminId - 1)];
					c.ObjectId = (System.Int64)reader[((int)StreetColumn.ObjectId - 1)];
					c.RowNumber = (System.Int32)reader[((int)StreetColumn.RowNumber - 1)];
					c.NeighborhoodId = (System.Int32)reader[((int)StreetColumn.NeighborhoodId - 1)];
					c.StreetName = (System.String)reader[((int)StreetColumn.StreetName - 1)];
					c.Longitude = (System.String)reader[((int)StreetColumn.Longitude - 1)];
					c.Latitude = (System.String)reader[((int)StreetColumn.Latitude - 1)];
					c.ZipCode = (System.String)reader[((int)StreetColumn.ZipCode - 1)];
					c.CreateDate = (System.DateTime)reader[((int)StreetColumn.CreateDate - 1)];
					c.CreateTime = (System.TimeSpan)reader[((int)StreetColumn.CreateTime - 1)];
					c.UpdateDate = (reader.IsDBNull(((int)StreetColumn.UpdateDate - 1)))?null:(System.DateTime?)reader[((int)StreetColumn.UpdateDate - 1)];
					c.UpdateTime = (reader.IsDBNull(((int)StreetColumn.UpdateTime - 1)))?null:(System.TimeSpan?)reader[((int)StreetColumn.UpdateTime - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.Street"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Street"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Ekip.Framework.Entities.Street entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)StreetColumn.Id - 1)];
			entity.AdminId = (System.Int64)reader[((int)StreetColumn.AdminId - 1)];
			entity.ObjectId = (System.Int64)reader[((int)StreetColumn.ObjectId - 1)];
			entity.RowNumber = (System.Int32)reader[((int)StreetColumn.RowNumber - 1)];
			entity.NeighborhoodId = (System.Int32)reader[((int)StreetColumn.NeighborhoodId - 1)];
			entity.StreetName = (System.String)reader[((int)StreetColumn.StreetName - 1)];
			entity.Longitude = (System.String)reader[((int)StreetColumn.Longitude - 1)];
			entity.Latitude = (System.String)reader[((int)StreetColumn.Latitude - 1)];
			entity.ZipCode = (System.String)reader[((int)StreetColumn.ZipCode - 1)];
			entity.CreateDate = (System.DateTime)reader[((int)StreetColumn.CreateDate - 1)];
			entity.CreateTime = (System.TimeSpan)reader[((int)StreetColumn.CreateTime - 1)];
			entity.UpdateDate = (reader.IsDBNull(((int)StreetColumn.UpdateDate - 1)))?null:(System.DateTime?)reader[((int)StreetColumn.UpdateDate - 1)];
			entity.UpdateTime = (reader.IsDBNull(((int)StreetColumn.UpdateTime - 1)))?null:(System.TimeSpan?)reader[((int)StreetColumn.UpdateTime - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.Street"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Street"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Ekip.Framework.Entities.Street entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["Id"];
			entity.AdminId = (System.Int64)dataRow["AdminId"];
			entity.ObjectId = (System.Int64)dataRow["ObjectId"];
			entity.RowNumber = (System.Int32)dataRow["RowNumber"];
			entity.NeighborhoodId = (System.Int32)dataRow["NeighborhoodId"];
			entity.StreetName = (System.String)dataRow["StreetName"];
			entity.Longitude = (System.String)dataRow["Longitude"];
			entity.Latitude = (System.String)dataRow["Latitude"];
			entity.ZipCode = (System.String)dataRow["ZipCode"];
			entity.CreateDate = (System.DateTime)dataRow["CreateDate"];
			entity.CreateTime = (System.TimeSpan)dataRow["CreateTime"];
			entity.UpdateDate = Convert.IsDBNull(dataRow["UpdateDate"]) ? null : (System.DateTime?)dataRow["UpdateDate"];
			entity.UpdateTime = Convert.IsDBNull(dataRow["UpdateTime"]) ? null : (System.TimeSpan?)dataRow["UpdateTime"];
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
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Street"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.Street Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Ekip.Framework.Entities.Street entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region NeighborhoodIdSource	
			if (CanDeepLoad(entity, "Neighborhood|NeighborhoodIdSource", deepLoadType, innerList) 
				&& entity.NeighborhoodIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.NeighborhoodId;
				Neighborhood tmpEntity = EntityManager.LocateEntity<Neighborhood>(EntityLocator.ConstructKeyFromPkItems(typeof(Neighborhood), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.NeighborhoodIdSource = tmpEntity;
				else
					entity.NeighborhoodIdSource = DataRepository.NeighborhoodProvider.GetById(transactionManager, entity.NeighborhoodId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'NeighborhoodIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.NeighborhoodIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.NeighborhoodProvider.DeepLoad(transactionManager, entity.NeighborhoodIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion NeighborhoodIdSource
			
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
		/// Deep Save the entire object graph of the Ekip.Framework.Entities.Street object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Ekip.Framework.Entities.Street instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.Street Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Ekip.Framework.Entities.Street entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region NeighborhoodIdSource
			if (CanDeepSave(entity, "Neighborhood|NeighborhoodIdSource", deepSaveType, innerList) 
				&& entity.NeighborhoodIdSource != null)
			{
				DataRepository.NeighborhoodProvider.Save(transactionManager, entity.NeighborhoodIdSource);
				entity.NeighborhoodId = entity.NeighborhoodIdSource.Id;
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
	
	#region StreetChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Ekip.Framework.Entities.Street</c>
	///</summary>
	public enum StreetChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Neighborhood</c> at NeighborhoodIdSource
		///</summary>
		[ChildEntityType(typeof(Neighborhood))]
		Neighborhood,
		}
	
	#endregion StreetChildEntityTypes
	
	#region StreetFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;StreetColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Street"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class StreetFilterBuilder : SqlFilterBuilder<StreetColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the StreetFilterBuilder class.
		/// </summary>
		public StreetFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the StreetFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public StreetFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the StreetFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public StreetFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion StreetFilterBuilder
	
	#region StreetParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;StreetColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Street"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class StreetParameterBuilder : ParameterizedSqlFilterBuilder<StreetColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the StreetParameterBuilder class.
		/// </summary>
		public StreetParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the StreetParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public StreetParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the StreetParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public StreetParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion StreetParameterBuilder
	
	#region StreetSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;StreetColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Street"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class StreetSortBuilder : SqlSortBuilder<StreetColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the StreetSqlSortBuilder class.
		/// </summary>
		public StreetSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion StreetSortBuilder
	
} // end namespace
