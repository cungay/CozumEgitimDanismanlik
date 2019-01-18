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
	/// This class is the base class for any <see cref="SchoolProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SchoolProviderBaseCore : EntityProviderBase<Ekip.Framework.Entities.School, Ekip.Framework.Entities.SchoolKey>
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
		public override bool Delete(TransactionManager transactionManager, Ekip.Framework.Entities.SchoolKey key)
		{
			return Delete(transactionManager, key.SchoolId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_schoolId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _schoolId)
		{
			return Delete(null, _schoolId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_schoolId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _schoolId);		
		
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
		public override Ekip.Framework.Entities.School Get(TransactionManager transactionManager, Ekip.Framework.Entities.SchoolKey key, int start, int pageLength)
		{
			return GetBySchoolId(transactionManager, key.SchoolId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_School_SchoolName index.
		/// </summary>
		/// <param name="_schoolId"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.School"/> class.</returns>
		public Ekip.Framework.Entities.School GetBySchoolId(System.Int32 _schoolId)
		{
			int count = -1;
			return GetBySchoolId(null,_schoolId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_School_SchoolName index.
		/// </summary>
		/// <param name="_schoolId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.School"/> class.</returns>
		public Ekip.Framework.Entities.School GetBySchoolId(System.Int32 _schoolId, int start, int pageLength)
		{
			int count = -1;
			return GetBySchoolId(null, _schoolId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_School_SchoolName index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_schoolId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.School"/> class.</returns>
		public Ekip.Framework.Entities.School GetBySchoolId(TransactionManager transactionManager, System.Int32 _schoolId)
		{
			int count = -1;
			return GetBySchoolId(transactionManager, _schoolId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_School_SchoolName index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_schoolId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.School"/> class.</returns>
		public Ekip.Framework.Entities.School GetBySchoolId(TransactionManager transactionManager, System.Int32 _schoolId, int start, int pageLength)
		{
			int count = -1;
			return GetBySchoolId(transactionManager, _schoolId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_School_SchoolName index.
		/// </summary>
		/// <param name="_schoolId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.School"/> class.</returns>
		public Ekip.Framework.Entities.School GetBySchoolId(System.Int32 _schoolId, int start, int pageLength, out int count)
		{
			return GetBySchoolId(null, _schoolId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_School_SchoolName index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_schoolId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.School"/> class.</returns>
		public abstract Ekip.Framework.Entities.School GetBySchoolId(TransactionManager transactionManager, System.Int32 _schoolId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;School&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;School&gt;"/></returns>
		public static TList<School> Fill(IDataReader reader, TList<School> rows, int start, int pageLength)
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
				
				Ekip.Framework.Entities.School c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("School")
					.Append("|").Append((System.Int32)reader[((int)SchoolColumn.SchoolId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<School>(
					key.ToString(), // EntityTrackingKey
					"School",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Ekip.Framework.Entities.School();
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
					c.SchoolId = (System.Int32)reader[((int)SchoolColumn.SchoolId - 1)];
					c.SchoolName = (System.String)reader[((int)SchoolColumn.SchoolName - 1)];
					c.CorparationTypeId = (System.Byte)reader[((int)SchoolColumn.CorparationTypeId - 1)];
					c.SchoolTypeId = (System.Byte)reader[((int)SchoolColumn.SchoolTypeId - 1)];
					c.ProvinceId = (reader.IsDBNull(((int)SchoolColumn.ProvinceId - 1)))?null:(System.Int32?)reader[((int)SchoolColumn.ProvinceId - 1)];
					c.TownId = (reader.IsDBNull(((int)SchoolColumn.TownId - 1)))?null:(System.Int32?)reader[((int)SchoolColumn.TownId - 1)];
					c.Address = (reader.IsDBNull(((int)SchoolColumn.Address - 1)))?null:(System.String)reader[((int)SchoolColumn.Address - 1)];
					c.Phone = (reader.IsDBNull(((int)SchoolColumn.Phone - 1)))?null:(System.String)reader[((int)SchoolColumn.Phone - 1)];
					c.Fax = (reader.IsDBNull(((int)SchoolColumn.Fax - 1)))?null:(System.String)reader[((int)SchoolColumn.Fax - 1)];
					c.WebAddress = (reader.IsDBNull(((int)SchoolColumn.WebAddress - 1)))?null:(System.String)reader[((int)SchoolColumn.WebAddress - 1)];
					c.Notes = (reader.IsDBNull(((int)SchoolColumn.Notes - 1)))?null:(System.String)reader[((int)SchoolColumn.Notes - 1)];
					c.CreateDate = (System.DateTime)reader[((int)SchoolColumn.CreateDate - 1)];
					c.UpdateDate = (reader.IsDBNull(((int)SchoolColumn.UpdateDate - 1)))?null:(System.DateTime?)reader[((int)SchoolColumn.UpdateDate - 1)];
					c.CreateUserId = (System.Int32)reader[((int)SchoolColumn.CreateUserId - 1)];
					c.UpdateUserId = (reader.IsDBNull(((int)SchoolColumn.UpdateUserId - 1)))?null:(System.Int32?)reader[((int)SchoolColumn.UpdateUserId - 1)];
					c.Active = (System.Boolean)reader[((int)SchoolColumn.Active - 1)];
					c.Deleted = (System.Boolean)reader[((int)SchoolColumn.Deleted - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.School"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.School"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Ekip.Framework.Entities.School entity)
		{
			if (!reader.Read()) return;
			
			entity.SchoolId = (System.Int32)reader[((int)SchoolColumn.SchoolId - 1)];
			entity.SchoolName = (System.String)reader[((int)SchoolColumn.SchoolName - 1)];
			entity.CorparationTypeId = (System.Byte)reader[((int)SchoolColumn.CorparationTypeId - 1)];
			entity.SchoolTypeId = (System.Byte)reader[((int)SchoolColumn.SchoolTypeId - 1)];
			entity.ProvinceId = (reader.IsDBNull(((int)SchoolColumn.ProvinceId - 1)))?null:(System.Int32?)reader[((int)SchoolColumn.ProvinceId - 1)];
			entity.TownId = (reader.IsDBNull(((int)SchoolColumn.TownId - 1)))?null:(System.Int32?)reader[((int)SchoolColumn.TownId - 1)];
			entity.Address = (reader.IsDBNull(((int)SchoolColumn.Address - 1)))?null:(System.String)reader[((int)SchoolColumn.Address - 1)];
			entity.Phone = (reader.IsDBNull(((int)SchoolColumn.Phone - 1)))?null:(System.String)reader[((int)SchoolColumn.Phone - 1)];
			entity.Fax = (reader.IsDBNull(((int)SchoolColumn.Fax - 1)))?null:(System.String)reader[((int)SchoolColumn.Fax - 1)];
			entity.WebAddress = (reader.IsDBNull(((int)SchoolColumn.WebAddress - 1)))?null:(System.String)reader[((int)SchoolColumn.WebAddress - 1)];
			entity.Notes = (reader.IsDBNull(((int)SchoolColumn.Notes - 1)))?null:(System.String)reader[((int)SchoolColumn.Notes - 1)];
			entity.CreateDate = (System.DateTime)reader[((int)SchoolColumn.CreateDate - 1)];
			entity.UpdateDate = (reader.IsDBNull(((int)SchoolColumn.UpdateDate - 1)))?null:(System.DateTime?)reader[((int)SchoolColumn.UpdateDate - 1)];
			entity.CreateUserId = (System.Int32)reader[((int)SchoolColumn.CreateUserId - 1)];
			entity.UpdateUserId = (reader.IsDBNull(((int)SchoolColumn.UpdateUserId - 1)))?null:(System.Int32?)reader[((int)SchoolColumn.UpdateUserId - 1)];
			entity.Active = (System.Boolean)reader[((int)SchoolColumn.Active - 1)];
			entity.Deleted = (System.Boolean)reader[((int)SchoolColumn.Deleted - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.School"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.School"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Ekip.Framework.Entities.School entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.SchoolId = (System.Int32)dataRow["SchoolId"];
			entity.SchoolName = (System.String)dataRow["SchoolName"];
			entity.CorparationTypeId = (System.Byte)dataRow["CorparationTypeId"];
			entity.SchoolTypeId = (System.Byte)dataRow["SchoolTypeId"];
			entity.ProvinceId = Convert.IsDBNull(dataRow["ProvinceId"]) ? null : (System.Int32?)dataRow["ProvinceId"];
			entity.TownId = Convert.IsDBNull(dataRow["TownId"]) ? null : (System.Int32?)dataRow["TownId"];
			entity.Address = Convert.IsDBNull(dataRow["Address"]) ? null : (System.String)dataRow["Address"];
			entity.Phone = Convert.IsDBNull(dataRow["Phone"]) ? null : (System.String)dataRow["Phone"];
			entity.Fax = Convert.IsDBNull(dataRow["Fax"]) ? null : (System.String)dataRow["Fax"];
			entity.WebAddress = Convert.IsDBNull(dataRow["WebAddress"]) ? null : (System.String)dataRow["WebAddress"];
			entity.Notes = Convert.IsDBNull(dataRow["Notes"]) ? null : (System.String)dataRow["Notes"];
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
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.School"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.School Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Ekip.Framework.Entities.School entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetBySchoolId methods when available
			
			#region TeacherCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Teacher>|TeacherCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'TeacherCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.TeacherCollection = DataRepository.TeacherProvider.GetBySchoolId(transactionManager, entity.SchoolId);

				if (deep && entity.TeacherCollection.Count > 0)
				{
					deepHandles.Add("TeacherCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Teacher>) DataRepository.TeacherProvider.DeepLoad,
						new object[] { transactionManager, entity.TeacherCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region ClientEducationCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ClientEducation>|ClientEducationCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ClientEducationCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ClientEducationCollection = DataRepository.ClientEducationProvider.GetBySchoolId(transactionManager, entity.SchoolId);

				if (deep && entity.ClientEducationCollection.Count > 0)
				{
					deepHandles.Add("ClientEducationCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<ClientEducation>) DataRepository.ClientEducationProvider.DeepLoad,
						new object[] { transactionManager, entity.ClientEducationCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Ekip.Framework.Entities.School object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Ekip.Framework.Entities.School instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.School Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Ekip.Framework.Entities.School entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<Teacher>
				if (CanDeepSave(entity.TeacherCollection, "List<Teacher>|TeacherCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Teacher child in entity.TeacherCollection)
					{
						if(child.SchoolIdSource != null)
						{
							child.SchoolId = child.SchoolIdSource.SchoolId;
						}
						else
						{
							child.SchoolId = entity.SchoolId;
						}

					}

					if (entity.TeacherCollection.Count > 0 || entity.TeacherCollection.DeletedItems.Count > 0)
					{
						//DataRepository.TeacherProvider.Save(transactionManager, entity.TeacherCollection);
						
						deepHandles.Add("TeacherCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Teacher >) DataRepository.TeacherProvider.DeepSave,
							new object[] { transactionManager, entity.TeacherCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<ClientEducation>
				if (CanDeepSave(entity.ClientEducationCollection, "List<ClientEducation>|ClientEducationCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ClientEducation child in entity.ClientEducationCollection)
					{
						if(child.SchoolIdSource != null)
						{
							child.SchoolId = child.SchoolIdSource.SchoolId;
						}
						else
						{
							child.SchoolId = entity.SchoolId;
						}

					}

					if (entity.ClientEducationCollection.Count > 0 || entity.ClientEducationCollection.DeletedItems.Count > 0)
					{
						//DataRepository.ClientEducationProvider.Save(transactionManager, entity.ClientEducationCollection);
						
						deepHandles.Add("ClientEducationCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< ClientEducation >) DataRepository.ClientEducationProvider.DeepSave,
							new object[] { transactionManager, entity.ClientEducationCollection, deepSaveType, childTypes, innerList }
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
	
	#region SchoolChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Ekip.Framework.Entities.School</c>
	///</summary>
	public enum SchoolChildEntityTypes
	{

		///<summary>
		/// Collection of <c>School</c> as OneToMany for TeacherCollection
		///</summary>
		[ChildEntityType(typeof(TList<Teacher>))]
		TeacherCollection,

		///<summary>
		/// Collection of <c>School</c> as OneToMany for ClientEducationCollection
		///</summary>
		[ChildEntityType(typeof(TList<ClientEducation>))]
		ClientEducationCollection,
	}
	
	#endregion SchoolChildEntityTypes
	
	#region SchoolFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;SchoolColumn&gt;"/> class
	/// that is used exclusively with a <see cref="School"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SchoolFilterBuilder : SqlFilterBuilder<SchoolColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SchoolFilterBuilder class.
		/// </summary>
		public SchoolFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SchoolFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SchoolFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SchoolFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SchoolFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SchoolFilterBuilder
	
	#region SchoolParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;SchoolColumn&gt;"/> class
	/// that is used exclusively with a <see cref="School"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SchoolParameterBuilder : ParameterizedSqlFilterBuilder<SchoolColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SchoolParameterBuilder class.
		/// </summary>
		public SchoolParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SchoolParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SchoolParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SchoolParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SchoolParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SchoolParameterBuilder
	
	#region SchoolSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;SchoolColumn&gt;"/> class
	/// that is used exclusively with a <see cref="School"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class SchoolSortBuilder : SqlSortBuilder<SchoolColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SchoolSqlSortBuilder class.
		/// </summary>
		public SchoolSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion SchoolSortBuilder
	
} // end namespace
