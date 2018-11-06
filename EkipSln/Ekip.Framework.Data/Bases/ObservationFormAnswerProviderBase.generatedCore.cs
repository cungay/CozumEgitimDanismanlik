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
	/// This class is the base class for any <see cref="ObservationFormAnswerProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ObservationFormAnswerProviderBaseCore : EntityProviderBase<Ekip.Framework.Entities.ObservationFormAnswer, Ekip.Framework.Entities.ObservationFormAnswerKey>
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
		public override bool Delete(TransactionManager transactionManager, Ekip.Framework.Entities.ObservationFormAnswerKey key)
		{
			return Delete(transactionManager, key.RowId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_rowId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _rowId)
		{
			return Delete(null, _rowId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _rowId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ObservationForm_Answer_Client key.
		///		FK_ObservationForm_Answer_Client Description: 
		/// </summary>
		/// <param name="_clientId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ObservationFormAnswer objects.</returns>
		public TList<ObservationFormAnswer> GetByClientId(System.Int32 _clientId)
		{
			int count = -1;
			return GetByClientId(_clientId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ObservationForm_Answer_Client key.
		///		FK_ObservationForm_Answer_Client Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_clientId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ObservationFormAnswer objects.</returns>
		/// <remarks></remarks>
		public TList<ObservationFormAnswer> GetByClientId(TransactionManager transactionManager, System.Int32 _clientId)
		{
			int count = -1;
			return GetByClientId(transactionManager, _clientId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ObservationForm_Answer_Client key.
		///		FK_ObservationForm_Answer_Client Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_clientId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ObservationFormAnswer objects.</returns>
		public TList<ObservationFormAnswer> GetByClientId(TransactionManager transactionManager, System.Int32 _clientId, int start, int pageLength)
		{
			int count = -1;
			return GetByClientId(transactionManager, _clientId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ObservationForm_Answer_Client key.
		///		fkObservationFormAnswerClient Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_clientId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ObservationFormAnswer objects.</returns>
		public TList<ObservationFormAnswer> GetByClientId(System.Int32 _clientId, int start, int pageLength)
		{
			int count =  -1;
			return GetByClientId(null, _clientId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ObservationForm_Answer_Client key.
		///		fkObservationFormAnswerClient Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_clientId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ObservationFormAnswer objects.</returns>
		public TList<ObservationFormAnswer> GetByClientId(System.Int32 _clientId, int start, int pageLength,out int count)
		{
			return GetByClientId(null, _clientId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ObservationForm_Answer_Client key.
		///		FK_ObservationForm_Answer_Client Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_clientId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ObservationFormAnswer objects.</returns>
		public abstract TList<ObservationFormAnswer> GetByClientId(TransactionManager transactionManager, System.Int32 _clientId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ObservationForm_Answer_ObservationForm key.
		///		FK_ObservationForm_Answer_ObservationForm Description: 
		/// </summary>
		/// <param name="_questionId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ObservationFormAnswer objects.</returns>
		public TList<ObservationFormAnswer> GetByQuestionId(System.Int32 _questionId)
		{
			int count = -1;
			return GetByQuestionId(_questionId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ObservationForm_Answer_ObservationForm key.
		///		FK_ObservationForm_Answer_ObservationForm Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_questionId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ObservationFormAnswer objects.</returns>
		/// <remarks></remarks>
		public TList<ObservationFormAnswer> GetByQuestionId(TransactionManager transactionManager, System.Int32 _questionId)
		{
			int count = -1;
			return GetByQuestionId(transactionManager, _questionId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ObservationForm_Answer_ObservationForm key.
		///		FK_ObservationForm_Answer_ObservationForm Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_questionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ObservationFormAnswer objects.</returns>
		public TList<ObservationFormAnswer> GetByQuestionId(TransactionManager transactionManager, System.Int32 _questionId, int start, int pageLength)
		{
			int count = -1;
			return GetByQuestionId(transactionManager, _questionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ObservationForm_Answer_ObservationForm key.
		///		fkObservationFormAnswerObservationForm Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_questionId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ObservationFormAnswer objects.</returns>
		public TList<ObservationFormAnswer> GetByQuestionId(System.Int32 _questionId, int start, int pageLength)
		{
			int count =  -1;
			return GetByQuestionId(null, _questionId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ObservationForm_Answer_ObservationForm key.
		///		fkObservationFormAnswerObservationForm Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_questionId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ObservationFormAnswer objects.</returns>
		public TList<ObservationFormAnswer> GetByQuestionId(System.Int32 _questionId, int start, int pageLength,out int count)
		{
			return GetByQuestionId(null, _questionId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ObservationForm_Answer_ObservationForm key.
		///		FK_ObservationForm_Answer_ObservationForm Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_questionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ObservationFormAnswer objects.</returns>
		public abstract TList<ObservationFormAnswer> GetByQuestionId(TransactionManager transactionManager, System.Int32 _questionId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ObservationForm_Answer_ObservationForm_Option key.
		///		FK_ObservationForm_Answer_ObservationForm_Option Description: 
		/// </summary>
		/// <param name="_optionId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ObservationFormAnswer objects.</returns>
		public TList<ObservationFormAnswer> GetByOptionId(System.Int32 _optionId)
		{
			int count = -1;
			return GetByOptionId(_optionId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ObservationForm_Answer_ObservationForm_Option key.
		///		FK_ObservationForm_Answer_ObservationForm_Option Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_optionId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ObservationFormAnswer objects.</returns>
		/// <remarks></remarks>
		public TList<ObservationFormAnswer> GetByOptionId(TransactionManager transactionManager, System.Int32 _optionId)
		{
			int count = -1;
			return GetByOptionId(transactionManager, _optionId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ObservationForm_Answer_ObservationForm_Option key.
		///		FK_ObservationForm_Answer_ObservationForm_Option Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_optionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ObservationFormAnswer objects.</returns>
		public TList<ObservationFormAnswer> GetByOptionId(TransactionManager transactionManager, System.Int32 _optionId, int start, int pageLength)
		{
			int count = -1;
			return GetByOptionId(transactionManager, _optionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ObservationForm_Answer_ObservationForm_Option key.
		///		fkObservationFormAnswerObservationFormOption Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_optionId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ObservationFormAnswer objects.</returns>
		public TList<ObservationFormAnswer> GetByOptionId(System.Int32 _optionId, int start, int pageLength)
		{
			int count =  -1;
			return GetByOptionId(null, _optionId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ObservationForm_Answer_ObservationForm_Option key.
		///		fkObservationFormAnswerObservationFormOption Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_optionId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ObservationFormAnswer objects.</returns>
		public TList<ObservationFormAnswer> GetByOptionId(System.Int32 _optionId, int start, int pageLength,out int count)
		{
			return GetByOptionId(null, _optionId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ObservationForm_Answer_ObservationForm_Option key.
		///		FK_ObservationForm_Answer_ObservationForm_Option Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_optionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ObservationFormAnswer objects.</returns>
		public abstract TList<ObservationFormAnswer> GetByOptionId(TransactionManager transactionManager, System.Int32 _optionId, int start, int pageLength, out int count);
		
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
		public override Ekip.Framework.Entities.ObservationFormAnswer Get(TransactionManager transactionManager, Ekip.Framework.Entities.ObservationFormAnswerKey key, int start, int pageLength)
		{
			return GetByRowId(transactionManager, key.RowId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ObservationForm_Answer index.
		/// </summary>
		/// <param name="_rowId"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ObservationFormAnswer"/> class.</returns>
		public Ekip.Framework.Entities.ObservationFormAnswer GetByRowId(System.Int32 _rowId)
		{
			int count = -1;
			return GetByRowId(null,_rowId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ObservationForm_Answer index.
		/// </summary>
		/// <param name="_rowId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ObservationFormAnswer"/> class.</returns>
		public Ekip.Framework.Entities.ObservationFormAnswer GetByRowId(System.Int32 _rowId, int start, int pageLength)
		{
			int count = -1;
			return GetByRowId(null, _rowId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ObservationForm_Answer index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ObservationFormAnswer"/> class.</returns>
		public Ekip.Framework.Entities.ObservationFormAnswer GetByRowId(TransactionManager transactionManager, System.Int32 _rowId)
		{
			int count = -1;
			return GetByRowId(transactionManager, _rowId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ObservationForm_Answer index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ObservationFormAnswer"/> class.</returns>
		public Ekip.Framework.Entities.ObservationFormAnswer GetByRowId(TransactionManager transactionManager, System.Int32 _rowId, int start, int pageLength)
		{
			int count = -1;
			return GetByRowId(transactionManager, _rowId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ObservationForm_Answer index.
		/// </summary>
		/// <param name="_rowId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ObservationFormAnswer"/> class.</returns>
		public Ekip.Framework.Entities.ObservationFormAnswer GetByRowId(System.Int32 _rowId, int start, int pageLength, out int count)
		{
			return GetByRowId(null, _rowId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ObservationForm_Answer index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ObservationFormAnswer"/> class.</returns>
		public abstract Ekip.Framework.Entities.ObservationFormAnswer GetByRowId(TransactionManager transactionManager, System.Int32 _rowId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;ObservationFormAnswer&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;ObservationFormAnswer&gt;"/></returns>
		public static TList<ObservationFormAnswer> Fill(IDataReader reader, TList<ObservationFormAnswer> rows, int start, int pageLength)
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
				
				Ekip.Framework.Entities.ObservationFormAnswer c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ObservationFormAnswer")
					.Append("|").Append((System.Int32)reader[((int)ObservationFormAnswerColumn.RowId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<ObservationFormAnswer>(
					key.ToString(), // EntityTrackingKey
					"ObservationFormAnswer",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Ekip.Framework.Entities.ObservationFormAnswer();
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
					c.RowId = (System.Int32)reader[((int)ObservationFormAnswerColumn.RowId - 1)];
					c.ClientId = (System.Int32)reader[((int)ObservationFormAnswerColumn.ClientId - 1)];
					c.QuestionId = (System.Int32)reader[((int)ObservationFormAnswerColumn.QuestionId - 1)];
					c.OptionId = (System.Int32)reader[((int)ObservationFormAnswerColumn.OptionId - 1)];
					c.Description = (reader.IsDBNull(((int)ObservationFormAnswerColumn.Description - 1)))?null:(System.String)reader[((int)ObservationFormAnswerColumn.Description - 1)];
					c.CreateOn = (System.DateTime)reader[((int)ObservationFormAnswerColumn.CreateOn - 1)];
					c.UpdateOn = (reader.IsDBNull(((int)ObservationFormAnswerColumn.UpdateOn - 1)))?null:(System.DateTime?)reader[((int)ObservationFormAnswerColumn.UpdateOn - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.ObservationFormAnswer"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.ObservationFormAnswer"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Ekip.Framework.Entities.ObservationFormAnswer entity)
		{
			if (!reader.Read()) return;
			
			entity.RowId = (System.Int32)reader[((int)ObservationFormAnswerColumn.RowId - 1)];
			entity.ClientId = (System.Int32)reader[((int)ObservationFormAnswerColumn.ClientId - 1)];
			entity.QuestionId = (System.Int32)reader[((int)ObservationFormAnswerColumn.QuestionId - 1)];
			entity.OptionId = (System.Int32)reader[((int)ObservationFormAnswerColumn.OptionId - 1)];
			entity.Description = (reader.IsDBNull(((int)ObservationFormAnswerColumn.Description - 1)))?null:(System.String)reader[((int)ObservationFormAnswerColumn.Description - 1)];
			entity.CreateOn = (System.DateTime)reader[((int)ObservationFormAnswerColumn.CreateOn - 1)];
			entity.UpdateOn = (reader.IsDBNull(((int)ObservationFormAnswerColumn.UpdateOn - 1)))?null:(System.DateTime?)reader[((int)ObservationFormAnswerColumn.UpdateOn - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.ObservationFormAnswer"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.ObservationFormAnswer"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Ekip.Framework.Entities.ObservationFormAnswer entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.RowId = (System.Int32)dataRow["RowID"];
			entity.ClientId = (System.Int32)dataRow["ClientID"];
			entity.QuestionId = (System.Int32)dataRow["QuestionID"];
			entity.OptionId = (System.Int32)dataRow["OptionID"];
			entity.Description = Convert.IsDBNull(dataRow["Description"]) ? null : (System.String)dataRow["Description"];
			entity.CreateOn = (System.DateTime)dataRow["CreateOn"];
			entity.UpdateOn = Convert.IsDBNull(dataRow["UpdateOn"]) ? null : (System.DateTime?)dataRow["UpdateOn"];
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
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.ObservationFormAnswer"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.ObservationFormAnswer Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Ekip.Framework.Entities.ObservationFormAnswer entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region ClientIdSource	
			if (CanDeepLoad(entity, "Client|ClientIdSource", deepLoadType, innerList) 
				&& entity.ClientIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ClientId;
				Client tmpEntity = EntityManager.LocateEntity<Client>(EntityLocator.ConstructKeyFromPkItems(typeof(Client), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ClientIdSource = tmpEntity;
				else
					entity.ClientIdSource = DataRepository.ClientProvider.GetByClientId(transactionManager, entity.ClientId);		
				
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

			#region QuestionIdSource	
			if (CanDeepLoad(entity, "ObservationForm|QuestionIdSource", deepLoadType, innerList) 
				&& entity.QuestionIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.QuestionId;
				ObservationForm tmpEntity = EntityManager.LocateEntity<ObservationForm>(EntityLocator.ConstructKeyFromPkItems(typeof(ObservationForm), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.QuestionIdSource = tmpEntity;
				else
					entity.QuestionIdSource = DataRepository.ObservationFormProvider.GetByQuestionId(transactionManager, entity.QuestionId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'QuestionIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.QuestionIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ObservationFormProvider.DeepLoad(transactionManager, entity.QuestionIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion QuestionIdSource

			#region OptionIdSource	
			if (CanDeepLoad(entity, "ObservationFormOption|OptionIdSource", deepLoadType, innerList) 
				&& entity.OptionIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.OptionId;
				ObservationFormOption tmpEntity = EntityManager.LocateEntity<ObservationFormOption>(EntityLocator.ConstructKeyFromPkItems(typeof(ObservationFormOption), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.OptionIdSource = tmpEntity;
				else
					entity.OptionIdSource = DataRepository.ObservationFormOptionProvider.GetByOptionId(transactionManager, entity.OptionId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'OptionIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.OptionIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ObservationFormOptionProvider.DeepLoad(transactionManager, entity.OptionIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion OptionIdSource
			
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
		/// Deep Save the entire object graph of the Ekip.Framework.Entities.ObservationFormAnswer object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Ekip.Framework.Entities.ObservationFormAnswer instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.ObservationFormAnswer Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Ekip.Framework.Entities.ObservationFormAnswer entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
			
			#region QuestionIdSource
			if (CanDeepSave(entity, "ObservationForm|QuestionIdSource", deepSaveType, innerList) 
				&& entity.QuestionIdSource != null)
			{
				DataRepository.ObservationFormProvider.Save(transactionManager, entity.QuestionIdSource);
				entity.QuestionId = entity.QuestionIdSource.QuestionId;
			}
			#endregion 
			
			#region OptionIdSource
			if (CanDeepSave(entity, "ObservationFormOption|OptionIdSource", deepSaveType, innerList) 
				&& entity.OptionIdSource != null)
			{
				DataRepository.ObservationFormOptionProvider.Save(transactionManager, entity.OptionIdSource);
				entity.OptionId = entity.OptionIdSource.OptionId;
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
	
	#region ObservationFormAnswerChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Ekip.Framework.Entities.ObservationFormAnswer</c>
	///</summary>
	public enum ObservationFormAnswerChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Client</c> at ClientIdSource
		///</summary>
		[ChildEntityType(typeof(Client))]
		Client,
			
		///<summary>
		/// Composite Property for <c>ObservationForm</c> at QuestionIdSource
		///</summary>
		[ChildEntityType(typeof(ObservationForm))]
		ObservationForm,
			
		///<summary>
		/// Composite Property for <c>ObservationFormOption</c> at OptionIdSource
		///</summary>
		[ChildEntityType(typeof(ObservationFormOption))]
		ObservationFormOption,
		}
	
	#endregion ObservationFormAnswerChildEntityTypes
	
	#region ObservationFormAnswerFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ObservationFormAnswerColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ObservationFormAnswer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ObservationFormAnswerFilterBuilder : SqlFilterBuilder<ObservationFormAnswerColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ObservationFormAnswerFilterBuilder class.
		/// </summary>
		public ObservationFormAnswerFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ObservationFormAnswerFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ObservationFormAnswerFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ObservationFormAnswerFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ObservationFormAnswerFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ObservationFormAnswerFilterBuilder
	
	#region ObservationFormAnswerParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ObservationFormAnswerColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ObservationFormAnswer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ObservationFormAnswerParameterBuilder : ParameterizedSqlFilterBuilder<ObservationFormAnswerColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ObservationFormAnswerParameterBuilder class.
		/// </summary>
		public ObservationFormAnswerParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ObservationFormAnswerParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ObservationFormAnswerParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ObservationFormAnswerParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ObservationFormAnswerParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ObservationFormAnswerParameterBuilder
	
	#region ObservationFormAnswerSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ObservationFormAnswerColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ObservationFormAnswer"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ObservationFormAnswerSortBuilder : SqlSortBuilder<ObservationFormAnswerColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ObservationFormAnswerSqlSortBuilder class.
		/// </summary>
		public ObservationFormAnswerSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ObservationFormAnswerSortBuilder
	
} // end namespace
