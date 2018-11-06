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
	/// This class is the base class for any <see cref="TestResultProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class TestResultProviderBaseCore : EntityProviderBase<Ekip.Framework.Entities.TestResult, Ekip.Framework.Entities.TestResultKey>
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
		public override bool Delete(TransactionManager transactionManager, Ekip.Framework.Entities.TestResultKey key)
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
		/// 	Gets rows from the datasource based on the FK_TestResult_Client key.
		///		FK_TestResult_Client Description: 
		/// </summary>
		/// <param name="_clientId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.TestResult objects.</returns>
		public TList<TestResult> GetByClientId(System.Int32 _clientId)
		{
			int count = -1;
			return GetByClientId(_clientId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_TestResult_Client key.
		///		FK_TestResult_Client Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_clientId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.TestResult objects.</returns>
		/// <remarks></remarks>
		public TList<TestResult> GetByClientId(TransactionManager transactionManager, System.Int32 _clientId)
		{
			int count = -1;
			return GetByClientId(transactionManager, _clientId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_TestResult_Client key.
		///		FK_TestResult_Client Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_clientId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.TestResult objects.</returns>
		public TList<TestResult> GetByClientId(TransactionManager transactionManager, System.Int32 _clientId, int start, int pageLength)
		{
			int count = -1;
			return GetByClientId(transactionManager, _clientId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_TestResult_Client key.
		///		fkTestResultClient Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_clientId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.TestResult objects.</returns>
		public TList<TestResult> GetByClientId(System.Int32 _clientId, int start, int pageLength)
		{
			int count =  -1;
			return GetByClientId(null, _clientId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_TestResult_Client key.
		///		fkTestResultClient Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_clientId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.TestResult objects.</returns>
		public TList<TestResult> GetByClientId(System.Int32 _clientId, int start, int pageLength,out int count)
		{
			return GetByClientId(null, _clientId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_TestResult_Client key.
		///		FK_TestResult_Client Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_clientId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.TestResult objects.</returns>
		public abstract TList<TestResult> GetByClientId(TransactionManager transactionManager, System.Int32 _clientId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_TestResult_Option key.
		///		FK_TestResult_Option Description: 
		/// </summary>
		/// <param name="_optionId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.TestResult objects.</returns>
		public TList<TestResult> GetByOptionId(System.Int32 _optionId)
		{
			int count = -1;
			return GetByOptionId(_optionId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_TestResult_Option key.
		///		FK_TestResult_Option Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_optionId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.TestResult objects.</returns>
		/// <remarks></remarks>
		public TList<TestResult> GetByOptionId(TransactionManager transactionManager, System.Int32 _optionId)
		{
			int count = -1;
			return GetByOptionId(transactionManager, _optionId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_TestResult_Option key.
		///		FK_TestResult_Option Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_optionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.TestResult objects.</returns>
		public TList<TestResult> GetByOptionId(TransactionManager transactionManager, System.Int32 _optionId, int start, int pageLength)
		{
			int count = -1;
			return GetByOptionId(transactionManager, _optionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_TestResult_Option key.
		///		fkTestResultOption Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_optionId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.TestResult objects.</returns>
		public TList<TestResult> GetByOptionId(System.Int32 _optionId, int start, int pageLength)
		{
			int count =  -1;
			return GetByOptionId(null, _optionId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_TestResult_Option key.
		///		fkTestResultOption Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_optionId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.TestResult objects.</returns>
		public TList<TestResult> GetByOptionId(System.Int32 _optionId, int start, int pageLength,out int count)
		{
			return GetByOptionId(null, _optionId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_TestResult_Option key.
		///		FK_TestResult_Option Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_optionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.TestResult objects.</returns>
		public abstract TList<TestResult> GetByOptionId(TransactionManager transactionManager, System.Int32 _optionId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_TestResult_Question key.
		///		FK_TestResult_Question Description: 
		/// </summary>
		/// <param name="_questionId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.TestResult objects.</returns>
		public TList<TestResult> GetByQuestionId(System.Int32 _questionId)
		{
			int count = -1;
			return GetByQuestionId(_questionId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_TestResult_Question key.
		///		FK_TestResult_Question Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_questionId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.TestResult objects.</returns>
		/// <remarks></remarks>
		public TList<TestResult> GetByQuestionId(TransactionManager transactionManager, System.Int32 _questionId)
		{
			int count = -1;
			return GetByQuestionId(transactionManager, _questionId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_TestResult_Question key.
		///		FK_TestResult_Question Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_questionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.TestResult objects.</returns>
		public TList<TestResult> GetByQuestionId(TransactionManager transactionManager, System.Int32 _questionId, int start, int pageLength)
		{
			int count = -1;
			return GetByQuestionId(transactionManager, _questionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_TestResult_Question key.
		///		fkTestResultQuestion Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_questionId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.TestResult objects.</returns>
		public TList<TestResult> GetByQuestionId(System.Int32 _questionId, int start, int pageLength)
		{
			int count =  -1;
			return GetByQuestionId(null, _questionId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_TestResult_Question key.
		///		fkTestResultQuestion Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_questionId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.TestResult objects.</returns>
		public TList<TestResult> GetByQuestionId(System.Int32 _questionId, int start, int pageLength,out int count)
		{
			return GetByQuestionId(null, _questionId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_TestResult_Question key.
		///		FK_TestResult_Question Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_questionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.TestResult objects.</returns>
		public abstract TList<TestResult> GetByQuestionId(TransactionManager transactionManager, System.Int32 _questionId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_TestResult_Test key.
		///		FK_TestResult_Test Description: 
		/// </summary>
		/// <param name="_testId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.TestResult objects.</returns>
		public TList<TestResult> GetByTestId(System.Int32 _testId)
		{
			int count = -1;
			return GetByTestId(_testId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_TestResult_Test key.
		///		FK_TestResult_Test Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_testId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.TestResult objects.</returns>
		/// <remarks></remarks>
		public TList<TestResult> GetByTestId(TransactionManager transactionManager, System.Int32 _testId)
		{
			int count = -1;
			return GetByTestId(transactionManager, _testId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_TestResult_Test key.
		///		FK_TestResult_Test Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_testId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.TestResult objects.</returns>
		public TList<TestResult> GetByTestId(TransactionManager transactionManager, System.Int32 _testId, int start, int pageLength)
		{
			int count = -1;
			return GetByTestId(transactionManager, _testId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_TestResult_Test key.
		///		fkTestResultTest Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_testId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.TestResult objects.</returns>
		public TList<TestResult> GetByTestId(System.Int32 _testId, int start, int pageLength)
		{
			int count =  -1;
			return GetByTestId(null, _testId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_TestResult_Test key.
		///		fkTestResultTest Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_testId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.TestResult objects.</returns>
		public TList<TestResult> GetByTestId(System.Int32 _testId, int start, int pageLength,out int count)
		{
			return GetByTestId(null, _testId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_TestResult_Test key.
		///		FK_TestResult_Test Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_testId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.TestResult objects.</returns>
		public abstract TList<TestResult> GetByTestId(TransactionManager transactionManager, System.Int32 _testId, int start, int pageLength, out int count);
		
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
		public override Ekip.Framework.Entities.TestResult Get(TransactionManager transactionManager, Ekip.Framework.Entities.TestResultKey key, int start, int pageLength)
		{
			return GetByRowId(transactionManager, key.RowId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_TestResult index.
		/// </summary>
		/// <param name="_rowId"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.TestResult"/> class.</returns>
		public Ekip.Framework.Entities.TestResult GetByRowId(System.Int32 _rowId)
		{
			int count = -1;
			return GetByRowId(null,_rowId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_TestResult index.
		/// </summary>
		/// <param name="_rowId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.TestResult"/> class.</returns>
		public Ekip.Framework.Entities.TestResult GetByRowId(System.Int32 _rowId, int start, int pageLength)
		{
			int count = -1;
			return GetByRowId(null, _rowId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_TestResult index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.TestResult"/> class.</returns>
		public Ekip.Framework.Entities.TestResult GetByRowId(TransactionManager transactionManager, System.Int32 _rowId)
		{
			int count = -1;
			return GetByRowId(transactionManager, _rowId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_TestResult index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.TestResult"/> class.</returns>
		public Ekip.Framework.Entities.TestResult GetByRowId(TransactionManager transactionManager, System.Int32 _rowId, int start, int pageLength)
		{
			int count = -1;
			return GetByRowId(transactionManager, _rowId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_TestResult index.
		/// </summary>
		/// <param name="_rowId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.TestResult"/> class.</returns>
		public Ekip.Framework.Entities.TestResult GetByRowId(System.Int32 _rowId, int start, int pageLength, out int count)
		{
			return GetByRowId(null, _rowId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_TestResult index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.TestResult"/> class.</returns>
		public abstract Ekip.Framework.Entities.TestResult GetByRowId(TransactionManager transactionManager, System.Int32 _rowId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region TestResult_AnswerList 
		
		/// <summary>
		///	This method wrap the 'TestResult_AnswerList' stored procedure. 
		/// </summary>
		/// <param name="testId"> A <c>System.Int32</c> instance.</param>
		/// <param name="clientId"> A <c>System.Int32</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;TestResult&gt;"/> instance.</returns>
		public TList<TestResult> AnswerList(System.Int32 testId, System.Int32 clientId)
		{
			return AnswerList(null, 0, int.MaxValue , testId, clientId);
		}
		
		/// <summary>
		///	This method wrap the 'TestResult_AnswerList' stored procedure. 
		/// </summary>
		/// <param name="testId"> A <c>System.Int32</c> instance.</param>
		/// <param name="clientId"> A <c>System.Int32</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;TestResult&gt;"/> instance.</returns>
		public TList<TestResult> AnswerList(int start, int pageLength, System.Int32 testId, System.Int32 clientId)
		{
			return AnswerList(null, start, pageLength , testId, clientId);
		}
				
		/// <summary>
		///	This method wrap the 'TestResult_AnswerList' stored procedure. 
		/// </summary>
		/// <param name="testId"> A <c>System.Int32</c> instance.</param>
		/// <param name="clientId"> A <c>System.Int32</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;TestResult&gt;"/> instance.</returns>
		public TList<TestResult> AnswerList(TransactionManager transactionManager, System.Int32 testId, System.Int32 clientId)
		{
			return AnswerList(transactionManager, 0, int.MaxValue , testId, clientId);
		}
		
		/// <summary>
		///	This method wrap the 'TestResult_AnswerList' stored procedure. 
		/// </summary>
		/// <param name="testId"> A <c>System.Int32</c> instance.</param>
		/// <param name="clientId"> A <c>System.Int32</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;TestResult&gt;"/> instance.</returns>
		public abstract TList<TestResult> AnswerList(TransactionManager transactionManager, int start, int pageLength , System.Int32 testId, System.Int32 clientId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;TestResult&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;TestResult&gt;"/></returns>
		public static TList<TestResult> Fill(IDataReader reader, TList<TestResult> rows, int start, int pageLength)
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
				
				Ekip.Framework.Entities.TestResult c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("TestResult")
					.Append("|").Append((System.Int32)reader[((int)TestResultColumn.RowId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<TestResult>(
					key.ToString(), // EntityTrackingKey
					"TestResult",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Ekip.Framework.Entities.TestResult();
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
					c.RowId = (System.Int32)reader[((int)TestResultColumn.RowId - 1)];
					c.TestId = (System.Int32)reader[((int)TestResultColumn.TestId - 1)];
					c.ClientId = (System.Int32)reader[((int)TestResultColumn.ClientId - 1)];
					c.QuestionId = (System.Int32)reader[((int)TestResultColumn.QuestionId - 1)];
					c.OptionId = (System.Int32)reader[((int)TestResultColumn.OptionId - 1)];
					c.Description = (reader.IsDBNull(((int)TestResultColumn.Description - 1)))?null:(System.String)reader[((int)TestResultColumn.Description - 1)];
					c.CreateOn = (System.DateTime)reader[((int)TestResultColumn.CreateOn - 1)];
					c.UpdateOn = (reader.IsDBNull(((int)TestResultColumn.UpdateOn - 1)))?null:(System.DateTime?)reader[((int)TestResultColumn.UpdateOn - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.TestResult"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.TestResult"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Ekip.Framework.Entities.TestResult entity)
		{
			if (!reader.Read()) return;
			
			entity.RowId = (System.Int32)reader[((int)TestResultColumn.RowId - 1)];
			entity.TestId = (System.Int32)reader[((int)TestResultColumn.TestId - 1)];
			entity.ClientId = (System.Int32)reader[((int)TestResultColumn.ClientId - 1)];
			entity.QuestionId = (System.Int32)reader[((int)TestResultColumn.QuestionId - 1)];
			entity.OptionId = (System.Int32)reader[((int)TestResultColumn.OptionId - 1)];
			entity.Description = (reader.IsDBNull(((int)TestResultColumn.Description - 1)))?null:(System.String)reader[((int)TestResultColumn.Description - 1)];
			entity.CreateOn = (System.DateTime)reader[((int)TestResultColumn.CreateOn - 1)];
			entity.UpdateOn = (reader.IsDBNull(((int)TestResultColumn.UpdateOn - 1)))?null:(System.DateTime?)reader[((int)TestResultColumn.UpdateOn - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.TestResult"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.TestResult"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Ekip.Framework.Entities.TestResult entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.RowId = (System.Int32)dataRow["RowID"];
			entity.TestId = (System.Int32)dataRow["TestID"];
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
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.TestResult"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.TestResult Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Ekip.Framework.Entities.TestResult entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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

			#region OptionIdSource	
			if (CanDeepLoad(entity, "Option|OptionIdSource", deepLoadType, innerList) 
				&& entity.OptionIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.OptionId;
				Option tmpEntity = EntityManager.LocateEntity<Option>(EntityLocator.ConstructKeyFromPkItems(typeof(Option), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.OptionIdSource = tmpEntity;
				else
					entity.OptionIdSource = DataRepository.OptionProvider.GetByOptionId(transactionManager, entity.OptionId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'OptionIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.OptionIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.OptionProvider.DeepLoad(transactionManager, entity.OptionIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion OptionIdSource

			#region QuestionIdSource	
			if (CanDeepLoad(entity, "Question|QuestionIdSource", deepLoadType, innerList) 
				&& entity.QuestionIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.QuestionId;
				Question tmpEntity = EntityManager.LocateEntity<Question>(EntityLocator.ConstructKeyFromPkItems(typeof(Question), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.QuestionIdSource = tmpEntity;
				else
					entity.QuestionIdSource = DataRepository.QuestionProvider.GetByQuestionId(transactionManager, entity.QuestionId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'QuestionIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.QuestionIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.QuestionProvider.DeepLoad(transactionManager, entity.QuestionIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion QuestionIdSource

			#region TestIdSource	
			if (CanDeepLoad(entity, "Test|TestIdSource", deepLoadType, innerList) 
				&& entity.TestIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.TestId;
				Test tmpEntity = EntityManager.LocateEntity<Test>(EntityLocator.ConstructKeyFromPkItems(typeof(Test), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.TestIdSource = tmpEntity;
				else
					entity.TestIdSource = DataRepository.TestProvider.GetByTestId(transactionManager, entity.TestId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'TestIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.TestIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.TestProvider.DeepLoad(transactionManager, entity.TestIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion TestIdSource
			
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
		/// Deep Save the entire object graph of the Ekip.Framework.Entities.TestResult object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Ekip.Framework.Entities.TestResult instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.TestResult Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Ekip.Framework.Entities.TestResult entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
			
			#region OptionIdSource
			if (CanDeepSave(entity, "Option|OptionIdSource", deepSaveType, innerList) 
				&& entity.OptionIdSource != null)
			{
				DataRepository.OptionProvider.Save(transactionManager, entity.OptionIdSource);
				entity.OptionId = entity.OptionIdSource.OptionId;
			}
			#endregion 
			
			#region QuestionIdSource
			if (CanDeepSave(entity, "Question|QuestionIdSource", deepSaveType, innerList) 
				&& entity.QuestionIdSource != null)
			{
				DataRepository.QuestionProvider.Save(transactionManager, entity.QuestionIdSource);
				entity.QuestionId = entity.QuestionIdSource.QuestionId;
			}
			#endregion 
			
			#region TestIdSource
			if (CanDeepSave(entity, "Test|TestIdSource", deepSaveType, innerList) 
				&& entity.TestIdSource != null)
			{
				DataRepository.TestProvider.Save(transactionManager, entity.TestIdSource);
				entity.TestId = entity.TestIdSource.TestId;
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
	
	#region TestResultChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Ekip.Framework.Entities.TestResult</c>
	///</summary>
	public enum TestResultChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Client</c> at ClientIdSource
		///</summary>
		[ChildEntityType(typeof(Client))]
		Client,
			
		///<summary>
		/// Composite Property for <c>Option</c> at OptionIdSource
		///</summary>
		[ChildEntityType(typeof(Option))]
		Option,
			
		///<summary>
		/// Composite Property for <c>Question</c> at QuestionIdSource
		///</summary>
		[ChildEntityType(typeof(Question))]
		Question,
			
		///<summary>
		/// Composite Property for <c>Test</c> at TestIdSource
		///</summary>
		[ChildEntityType(typeof(Test))]
		Test,
		}
	
	#endregion TestResultChildEntityTypes
	
	#region TestResultFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;TestResultColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TestResult"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TestResultFilterBuilder : SqlFilterBuilder<TestResultColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TestResultFilterBuilder class.
		/// </summary>
		public TestResultFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TestResultFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TestResultFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TestResultFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TestResultFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TestResultFilterBuilder
	
	#region TestResultParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;TestResultColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TestResult"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TestResultParameterBuilder : ParameterizedSqlFilterBuilder<TestResultColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TestResultParameterBuilder class.
		/// </summary>
		public TestResultParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TestResultParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TestResultParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TestResultParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TestResultParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TestResultParameterBuilder
	
	#region TestResultSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;TestResultColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TestResult"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class TestResultSortBuilder : SqlSortBuilder<TestResultColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TestResultSqlSortBuilder class.
		/// </summary>
		public TestResultSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion TestResultSortBuilder
	
} // end namespace
