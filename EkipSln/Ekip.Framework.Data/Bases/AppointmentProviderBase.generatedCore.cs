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
	/// This class is the base class for any <see cref="AppointmentProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class AppointmentProviderBaseCore : EntityProviderBase<Ekip.Framework.Entities.Appointment, Ekip.Framework.Entities.AppointmentKey>
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
		public override bool Delete(TransactionManager transactionManager, Ekip.Framework.Entities.AppointmentKey key)
		{
			return Delete(transactionManager, key.AppointmentId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_appointmentId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _appointmentId)
		{
			return Delete(null, _appointmentId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_appointmentId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _appointmentId);		
		
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
		public override Ekip.Framework.Entities.Appointment Get(TransactionManager transactionManager, Ekip.Framework.Entities.AppointmentKey key, int start, int pageLength)
		{
			return GetByAppointmentId(transactionManager, key.AppointmentId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Appointment index.
		/// </summary>
		/// <param name="_appointmentId"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Appointment"/> class.</returns>
		public Ekip.Framework.Entities.Appointment GetByAppointmentId(System.Int32 _appointmentId)
		{
			int count = -1;
			return GetByAppointmentId(null,_appointmentId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Appointment index.
		/// </summary>
		/// <param name="_appointmentId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Appointment"/> class.</returns>
		public Ekip.Framework.Entities.Appointment GetByAppointmentId(System.Int32 _appointmentId, int start, int pageLength)
		{
			int count = -1;
			return GetByAppointmentId(null, _appointmentId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Appointment index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_appointmentId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Appointment"/> class.</returns>
		public Ekip.Framework.Entities.Appointment GetByAppointmentId(TransactionManager transactionManager, System.Int32 _appointmentId)
		{
			int count = -1;
			return GetByAppointmentId(transactionManager, _appointmentId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Appointment index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_appointmentId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Appointment"/> class.</returns>
		public Ekip.Framework.Entities.Appointment GetByAppointmentId(TransactionManager transactionManager, System.Int32 _appointmentId, int start, int pageLength)
		{
			int count = -1;
			return GetByAppointmentId(transactionManager, _appointmentId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Appointment index.
		/// </summary>
		/// <param name="_appointmentId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Appointment"/> class.</returns>
		public Ekip.Framework.Entities.Appointment GetByAppointmentId(System.Int32 _appointmentId, int start, int pageLength, out int count)
		{
			return GetByAppointmentId(null, _appointmentId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Appointment index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_appointmentId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Appointment"/> class.</returns>
		public abstract Ekip.Framework.Entities.Appointment GetByAppointmentId(TransactionManager transactionManager, System.Int32 _appointmentId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Appointment&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Appointment&gt;"/></returns>
		public static TList<Appointment> Fill(IDataReader reader, TList<Appointment> rows, int start, int pageLength)
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
				
				Ekip.Framework.Entities.Appointment c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Appointment")
					.Append("|").Append((System.Int32)reader[((int)AppointmentColumn.AppointmentId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Appointment>(
					key.ToString(), // EntityTrackingKey
					"Appointment",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Ekip.Framework.Entities.Appointment();
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
					c.AppointmentId = (System.Int32)reader[((int)AppointmentColumn.AppointmentId - 1)];
					c.ClientId = (System.Int32)reader[((int)AppointmentColumn.ClientId - 1)];
					c.DoctorId = (reader.IsDBNull(((int)AppointmentColumn.DoctorId - 1)))?null:(System.Int32?)reader[((int)AppointmentColumn.DoctorId - 1)];
					c.CalenderAgeId = (reader.IsDBNull(((int)AppointmentColumn.CalenderAgeId - 1)))?null:(System.Int32?)reader[((int)AppointmentColumn.CalenderAgeId - 1)];
					c.ReasonId = (reader.IsDBNull(((int)AppointmentColumn.ReasonId - 1)))?null:(System.Int32?)reader[((int)AppointmentColumn.ReasonId - 1)];
					c.Symptom = (reader.IsDBNull(((int)AppointmentColumn.Symptom - 1)))?null:(System.String)reader[((int)AppointmentColumn.Symptom - 1)];
					c.Complaint = (reader.IsDBNull(((int)AppointmentColumn.Complaint - 1)))?null:(System.String)reader[((int)AppointmentColumn.Complaint - 1)];
					c.Finding = (reader.IsDBNull(((int)AppointmentColumn.Finding - 1)))?null:(System.String)reader[((int)AppointmentColumn.Finding - 1)];
					c.AppointmentDate = (reader.IsDBNull(((int)AppointmentColumn.AppointmentDate - 1)))?null:(System.DateTime?)reader[((int)AppointmentColumn.AppointmentDate - 1)];
					c.AppointmentNote = (reader.IsDBNull(((int)AppointmentColumn.AppointmentNote - 1)))?null:(System.String)reader[((int)AppointmentColumn.AppointmentNote - 1)];
					c.Status = (reader.IsDBNull(((int)AppointmentColumn.Status - 1)))?null:(System.Int32?)reader[((int)AppointmentColumn.Status - 1)];
					c.CreateOn = (System.DateTime)reader[((int)AppointmentColumn.CreateOn - 1)];
					c.UpdateOn = (reader.IsDBNull(((int)AppointmentColumn.UpdateOn - 1)))?null:(System.DateTime?)reader[((int)AppointmentColumn.UpdateOn - 1)];
					c.UserId = (System.Int32)reader[((int)AppointmentColumn.UserId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.Appointment"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Appointment"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Ekip.Framework.Entities.Appointment entity)
		{
			if (!reader.Read()) return;
			
			entity.AppointmentId = (System.Int32)reader[((int)AppointmentColumn.AppointmentId - 1)];
			entity.ClientId = (System.Int32)reader[((int)AppointmentColumn.ClientId - 1)];
			entity.DoctorId = (reader.IsDBNull(((int)AppointmentColumn.DoctorId - 1)))?null:(System.Int32?)reader[((int)AppointmentColumn.DoctorId - 1)];
			entity.CalenderAgeId = (reader.IsDBNull(((int)AppointmentColumn.CalenderAgeId - 1)))?null:(System.Int32?)reader[((int)AppointmentColumn.CalenderAgeId - 1)];
			entity.ReasonId = (reader.IsDBNull(((int)AppointmentColumn.ReasonId - 1)))?null:(System.Int32?)reader[((int)AppointmentColumn.ReasonId - 1)];
			entity.Symptom = (reader.IsDBNull(((int)AppointmentColumn.Symptom - 1)))?null:(System.String)reader[((int)AppointmentColumn.Symptom - 1)];
			entity.Complaint = (reader.IsDBNull(((int)AppointmentColumn.Complaint - 1)))?null:(System.String)reader[((int)AppointmentColumn.Complaint - 1)];
			entity.Finding = (reader.IsDBNull(((int)AppointmentColumn.Finding - 1)))?null:(System.String)reader[((int)AppointmentColumn.Finding - 1)];
			entity.AppointmentDate = (reader.IsDBNull(((int)AppointmentColumn.AppointmentDate - 1)))?null:(System.DateTime?)reader[((int)AppointmentColumn.AppointmentDate - 1)];
			entity.AppointmentNote = (reader.IsDBNull(((int)AppointmentColumn.AppointmentNote - 1)))?null:(System.String)reader[((int)AppointmentColumn.AppointmentNote - 1)];
			entity.Status = (reader.IsDBNull(((int)AppointmentColumn.Status - 1)))?null:(System.Int32?)reader[((int)AppointmentColumn.Status - 1)];
			entity.CreateOn = (System.DateTime)reader[((int)AppointmentColumn.CreateOn - 1)];
			entity.UpdateOn = (reader.IsDBNull(((int)AppointmentColumn.UpdateOn - 1)))?null:(System.DateTime?)reader[((int)AppointmentColumn.UpdateOn - 1)];
			entity.UserId = (System.Int32)reader[((int)AppointmentColumn.UserId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.Appointment"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Appointment"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Ekip.Framework.Entities.Appointment entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.AppointmentId = (System.Int32)dataRow["AppointmentID"];
			entity.ClientId = (System.Int32)dataRow["ClientID"];
			entity.DoctorId = Convert.IsDBNull(dataRow["DoctorID"]) ? null : (System.Int32?)dataRow["DoctorID"];
			entity.CalenderAgeId = Convert.IsDBNull(dataRow["CalenderAgeID"]) ? null : (System.Int32?)dataRow["CalenderAgeID"];
			entity.ReasonId = Convert.IsDBNull(dataRow["ReasonID"]) ? null : (System.Int32?)dataRow["ReasonID"];
			entity.Symptom = Convert.IsDBNull(dataRow["Symptom"]) ? null : (System.String)dataRow["Symptom"];
			entity.Complaint = Convert.IsDBNull(dataRow["Complaint"]) ? null : (System.String)dataRow["Complaint"];
			entity.Finding = Convert.IsDBNull(dataRow["Finding"]) ? null : (System.String)dataRow["Finding"];
			entity.AppointmentDate = Convert.IsDBNull(dataRow["AppointmentDate"]) ? null : (System.DateTime?)dataRow["AppointmentDate"];
			entity.AppointmentNote = Convert.IsDBNull(dataRow["AppointmentNote"]) ? null : (System.String)dataRow["AppointmentNote"];
			entity.Status = Convert.IsDBNull(dataRow["Status"]) ? null : (System.Int32?)dataRow["Status"];
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
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Appointment"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.Appointment Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Ekip.Framework.Entities.Appointment entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the Ekip.Framework.Entities.Appointment object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Ekip.Framework.Entities.Appointment instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.Appointment Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Ekip.Framework.Entities.Appointment entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region AppointmentChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Ekip.Framework.Entities.Appointment</c>
	///</summary>
	public enum AppointmentChildEntityTypes
	{
	}
	
	#endregion AppointmentChildEntityTypes
	
	#region AppointmentFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;AppointmentColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Appointment"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AppointmentFilterBuilder : SqlFilterBuilder<AppointmentColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AppointmentFilterBuilder class.
		/// </summary>
		public AppointmentFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AppointmentFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AppointmentFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AppointmentFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AppointmentFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AppointmentFilterBuilder
	
	#region AppointmentParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;AppointmentColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Appointment"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AppointmentParameterBuilder : ParameterizedSqlFilterBuilder<AppointmentColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AppointmentParameterBuilder class.
		/// </summary>
		public AppointmentParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AppointmentParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AppointmentParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AppointmentParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AppointmentParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AppointmentParameterBuilder
	
	#region AppointmentSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;AppointmentColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Appointment"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class AppointmentSortBuilder : SqlSortBuilder<AppointmentColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AppointmentSqlSortBuilder class.
		/// </summary>
		public AppointmentSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion AppointmentSortBuilder
	
} // end namespace
