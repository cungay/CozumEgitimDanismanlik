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
	/// This class is the base class for any <see cref="TeacherProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class TeacherProviderBaseCore : EntityProviderBase<Ekip.Framework.Entities.Teacher, Ekip.Framework.Entities.TeacherKey>
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
		public override bool Delete(TransactionManager transactionManager, Ekip.Framework.Entities.TeacherKey key)
		{
			return Delete(transactionManager, key.TeacherId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_teacherId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _teacherId)
		{
			return Delete(null, _teacherId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_teacherId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _teacherId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Teacher_School key.
		///		FK_Teacher_School Description: 
		/// </summary>
		/// <param name="_schoolId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Teacher objects.</returns>
		public TList<Teacher> GetBySchoolId(System.Int32 _schoolId)
		{
			int count = -1;
			return GetBySchoolId(_schoolId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Teacher_School key.
		///		FK_Teacher_School Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_schoolId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Teacher objects.</returns>
		/// <remarks></remarks>
		public TList<Teacher> GetBySchoolId(TransactionManager transactionManager, System.Int32 _schoolId)
		{
			int count = -1;
			return GetBySchoolId(transactionManager, _schoolId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Teacher_School key.
		///		FK_Teacher_School Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_schoolId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Teacher objects.</returns>
		public TList<Teacher> GetBySchoolId(TransactionManager transactionManager, System.Int32 _schoolId, int start, int pageLength)
		{
			int count = -1;
			return GetBySchoolId(transactionManager, _schoolId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Teacher_School key.
		///		fkTeacherSchool Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_schoolId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Teacher objects.</returns>
		public TList<Teacher> GetBySchoolId(System.Int32 _schoolId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySchoolId(null, _schoolId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Teacher_School key.
		///		fkTeacherSchool Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_schoolId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Teacher objects.</returns>
		public TList<Teacher> GetBySchoolId(System.Int32 _schoolId, int start, int pageLength,out int count)
		{
			return GetBySchoolId(null, _schoolId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Teacher_School key.
		///		FK_Teacher_School Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_schoolId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Teacher objects.</returns>
		public abstract TList<Teacher> GetBySchoolId(TransactionManager transactionManager, System.Int32 _schoolId, int start, int pageLength, out int count);
		
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
		public override Ekip.Framework.Entities.Teacher Get(TransactionManager transactionManager, Ekip.Framework.Entities.TeacherKey key, int start, int pageLength)
		{
			return GetByTeacherId(transactionManager, key.TeacherId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Teacher_1 index.
		/// </summary>
		/// <param name="_teacherId"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Teacher"/> class.</returns>
		public Ekip.Framework.Entities.Teacher GetByTeacherId(System.Int32 _teacherId)
		{
			int count = -1;
			return GetByTeacherId(null,_teacherId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Teacher_1 index.
		/// </summary>
		/// <param name="_teacherId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Teacher"/> class.</returns>
		public Ekip.Framework.Entities.Teacher GetByTeacherId(System.Int32 _teacherId, int start, int pageLength)
		{
			int count = -1;
			return GetByTeacherId(null, _teacherId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Teacher_1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_teacherId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Teacher"/> class.</returns>
		public Ekip.Framework.Entities.Teacher GetByTeacherId(TransactionManager transactionManager, System.Int32 _teacherId)
		{
			int count = -1;
			return GetByTeacherId(transactionManager, _teacherId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Teacher_1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_teacherId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Teacher"/> class.</returns>
		public Ekip.Framework.Entities.Teacher GetByTeacherId(TransactionManager transactionManager, System.Int32 _teacherId, int start, int pageLength)
		{
			int count = -1;
			return GetByTeacherId(transactionManager, _teacherId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Teacher_1 index.
		/// </summary>
		/// <param name="_teacherId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Teacher"/> class.</returns>
		public Ekip.Framework.Entities.Teacher GetByTeacherId(System.Int32 _teacherId, int start, int pageLength, out int count)
		{
			return GetByTeacherId(null, _teacherId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Teacher_1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_teacherId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Teacher"/> class.</returns>
		public abstract Ekip.Framework.Entities.Teacher GetByTeacherId(TransactionManager transactionManager, System.Int32 _teacherId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Teacher&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Teacher&gt;"/></returns>
		public static TList<Teacher> Fill(IDataReader reader, TList<Teacher> rows, int start, int pageLength)
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
				
				Ekip.Framework.Entities.Teacher c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Teacher")
					.Append("|").Append((System.Int32)reader[((int)TeacherColumn.TeacherId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Teacher>(
					key.ToString(), // EntityTrackingKey
					"Teacher",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Ekip.Framework.Entities.Teacher();
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
					c.TeacherId = (System.Int32)reader[((int)TeacherColumn.TeacherId - 1)];
					c.SchoolId = (System.Int32)reader[((int)TeacherColumn.SchoolId - 1)];
					c.FirstName = (reader.IsDBNull(((int)TeacherColumn.FirstName - 1)))?null:(System.String)reader[((int)TeacherColumn.FirstName - 1)];
					c.LastName = (reader.IsDBNull(((int)TeacherColumn.LastName - 1)))?null:(System.String)reader[((int)TeacherColumn.LastName - 1)];
					c.Phone = (reader.IsDBNull(((int)TeacherColumn.Phone - 1)))?null:(System.String)reader[((int)TeacherColumn.Phone - 1)];
					c.Gsm = (reader.IsDBNull(((int)TeacherColumn.Gsm - 1)))?null:(System.String)reader[((int)TeacherColumn.Gsm - 1)];
					c.Email = (reader.IsDBNull(((int)TeacherColumn.Email - 1)))?null:(System.String)reader[((int)TeacherColumn.Email - 1)];
					c.Notes = (reader.IsDBNull(((int)TeacherColumn.Notes - 1)))?null:(System.String)reader[((int)TeacherColumn.Notes - 1)];
					c.CreateOn = (System.DateTime)reader[((int)TeacherColumn.CreateOn - 1)];
					c.UpdateOn = (reader.IsDBNull(((int)TeacherColumn.UpdateOn - 1)))?null:(System.DateTime?)reader[((int)TeacherColumn.UpdateOn - 1)];
					c.CreateUserId = (System.Int32)reader[((int)TeacherColumn.CreateUserId - 1)];
					c.UpdateUserId = (reader.IsDBNull(((int)TeacherColumn.UpdateUserId - 1)))?null:(System.Int32?)reader[((int)TeacherColumn.UpdateUserId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.Teacher"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Teacher"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Ekip.Framework.Entities.Teacher entity)
		{
			if (!reader.Read()) return;
			
			entity.TeacherId = (System.Int32)reader[((int)TeacherColumn.TeacherId - 1)];
			entity.SchoolId = (System.Int32)reader[((int)TeacherColumn.SchoolId - 1)];
			entity.FirstName = (reader.IsDBNull(((int)TeacherColumn.FirstName - 1)))?null:(System.String)reader[((int)TeacherColumn.FirstName - 1)];
			entity.LastName = (reader.IsDBNull(((int)TeacherColumn.LastName - 1)))?null:(System.String)reader[((int)TeacherColumn.LastName - 1)];
			entity.Phone = (reader.IsDBNull(((int)TeacherColumn.Phone - 1)))?null:(System.String)reader[((int)TeacherColumn.Phone - 1)];
			entity.Gsm = (reader.IsDBNull(((int)TeacherColumn.Gsm - 1)))?null:(System.String)reader[((int)TeacherColumn.Gsm - 1)];
			entity.Email = (reader.IsDBNull(((int)TeacherColumn.Email - 1)))?null:(System.String)reader[((int)TeacherColumn.Email - 1)];
			entity.Notes = (reader.IsDBNull(((int)TeacherColumn.Notes - 1)))?null:(System.String)reader[((int)TeacherColumn.Notes - 1)];
			entity.CreateOn = (System.DateTime)reader[((int)TeacherColumn.CreateOn - 1)];
			entity.UpdateOn = (reader.IsDBNull(((int)TeacherColumn.UpdateOn - 1)))?null:(System.DateTime?)reader[((int)TeacherColumn.UpdateOn - 1)];
			entity.CreateUserId = (System.Int32)reader[((int)TeacherColumn.CreateUserId - 1)];
			entity.UpdateUserId = (reader.IsDBNull(((int)TeacherColumn.UpdateUserId - 1)))?null:(System.Int32?)reader[((int)TeacherColumn.UpdateUserId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.Teacher"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Teacher"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Ekip.Framework.Entities.Teacher entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.TeacherId = (System.Int32)dataRow["TeacherId"];
			entity.SchoolId = (System.Int32)dataRow["SchoolId"];
			entity.FirstName = Convert.IsDBNull(dataRow["FirstName"]) ? null : (System.String)dataRow["FirstName"];
			entity.LastName = Convert.IsDBNull(dataRow["LastName"]) ? null : (System.String)dataRow["LastName"];
			entity.Phone = Convert.IsDBNull(dataRow["Phone"]) ? null : (System.String)dataRow["Phone"];
			entity.Gsm = Convert.IsDBNull(dataRow["Gsm"]) ? null : (System.String)dataRow["Gsm"];
			entity.Email = Convert.IsDBNull(dataRow["Email"]) ? null : (System.String)dataRow["Email"];
			entity.Notes = Convert.IsDBNull(dataRow["Notes"]) ? null : (System.String)dataRow["Notes"];
			entity.CreateOn = (System.DateTime)dataRow["CreateOn"];
			entity.UpdateOn = Convert.IsDBNull(dataRow["UpdateOn"]) ? null : (System.DateTime?)dataRow["UpdateOn"];
			entity.CreateUserId = (System.Int32)dataRow["CreateUserId"];
			entity.UpdateUserId = Convert.IsDBNull(dataRow["UpdateUserId"]) ? null : (System.Int32?)dataRow["UpdateUserId"];
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
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Teacher"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.Teacher Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Ekip.Framework.Entities.Teacher entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region SchoolIdSource	
			if (CanDeepLoad(entity, "School|SchoolIdSource", deepLoadType, innerList) 
				&& entity.SchoolIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.SchoolId;
				School tmpEntity = EntityManager.LocateEntity<School>(EntityLocator.ConstructKeyFromPkItems(typeof(School), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.SchoolIdSource = tmpEntity;
				else
					entity.SchoolIdSource = DataRepository.SchoolProvider.GetBySchoolId(transactionManager, entity.SchoolId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SchoolIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.SchoolIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.SchoolProvider.DeepLoad(transactionManager, entity.SchoolIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion SchoolIdSource
			
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
		/// Deep Save the entire object graph of the Ekip.Framework.Entities.Teacher object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Ekip.Framework.Entities.Teacher instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.Teacher Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Ekip.Framework.Entities.Teacher entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region SchoolIdSource
			if (CanDeepSave(entity, "School|SchoolIdSource", deepSaveType, innerList) 
				&& entity.SchoolIdSource != null)
			{
				DataRepository.SchoolProvider.Save(transactionManager, entity.SchoolIdSource);
				entity.SchoolId = entity.SchoolIdSource.SchoolId;
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
	
	#region TeacherChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Ekip.Framework.Entities.Teacher</c>
	///</summary>
	public enum TeacherChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>School</c> at SchoolIdSource
		///</summary>
		[ChildEntityType(typeof(School))]
		School,
		}
	
	#endregion TeacherChildEntityTypes
	
	#region TeacherFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;TeacherColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Teacher"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TeacherFilterBuilder : SqlFilterBuilder<TeacherColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TeacherFilterBuilder class.
		/// </summary>
		public TeacherFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TeacherFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TeacherFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TeacherFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TeacherFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TeacherFilterBuilder
	
	#region TeacherParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;TeacherColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Teacher"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TeacherParameterBuilder : ParameterizedSqlFilterBuilder<TeacherColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TeacherParameterBuilder class.
		/// </summary>
		public TeacherParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TeacherParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TeacherParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TeacherParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TeacherParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TeacherParameterBuilder
	
	#region TeacherSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;TeacherColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Teacher"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class TeacherSortBuilder : SqlSortBuilder<TeacherColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TeacherSqlSortBuilder class.
		/// </summary>
		public TeacherSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion TeacherSortBuilder
	
} // end namespace
