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
	/// This class is the base class for any <see cref="ClientProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ClientProviderBaseCore : EntityProviderBase<Ekip.Framework.Entities.Client, Ekip.Framework.Entities.ClientKey>
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
		public override bool Delete(TransactionManager transactionManager, Ekip.Framework.Entities.ClientKey key)
		{
			return Delete(transactionManager, key.ClientId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_clientId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _clientId)
		{
			return Delete(null, _clientId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_clientId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _clientId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Client_ClientAddress key.
		///		FK_Client_ClientAddress Description: 
		/// </summary>
		/// <param name="_addressId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Client objects.</returns>
		public TList<Client> GetByAddressId(System.Int32? _addressId)
		{
			int count = -1;
			return GetByAddressId(_addressId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Client_ClientAddress key.
		///		FK_Client_ClientAddress Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_addressId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Client objects.</returns>
		/// <remarks></remarks>
		public TList<Client> GetByAddressId(TransactionManager transactionManager, System.Int32? _addressId)
		{
			int count = -1;
			return GetByAddressId(transactionManager, _addressId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Client_ClientAddress key.
		///		FK_Client_ClientAddress Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_addressId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Client objects.</returns>
		public TList<Client> GetByAddressId(TransactionManager transactionManager, System.Int32? _addressId, int start, int pageLength)
		{
			int count = -1;
			return GetByAddressId(transactionManager, _addressId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Client_ClientAddress key.
		///		fkClientClientAddress Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_addressId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Client objects.</returns>
		public TList<Client> GetByAddressId(System.Int32? _addressId, int start, int pageLength)
		{
			int count =  -1;
			return GetByAddressId(null, _addressId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Client_ClientAddress key.
		///		fkClientClientAddress Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_addressId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Client objects.</returns>
		public TList<Client> GetByAddressId(System.Int32? _addressId, int start, int pageLength,out int count)
		{
			return GetByAddressId(null, _addressId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Client_ClientAddress key.
		///		FK_Client_ClientAddress Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_addressId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Client objects.</returns>
		public abstract TList<Client> GetByAddressId(TransactionManager transactionManager, System.Int32? _addressId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Client_ClientFather key.
		///		FK_Client_ClientFather Description: 
		/// </summary>
		/// <param name="_fatherId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Client objects.</returns>
		public TList<Client> GetByFatherId(System.Int32 _fatherId)
		{
			int count = -1;
			return GetByFatherId(_fatherId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Client_ClientFather key.
		///		FK_Client_ClientFather Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_fatherId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Client objects.</returns>
		/// <remarks></remarks>
		public TList<Client> GetByFatherId(TransactionManager transactionManager, System.Int32 _fatherId)
		{
			int count = -1;
			return GetByFatherId(transactionManager, _fatherId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Client_ClientFather key.
		///		FK_Client_ClientFather Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_fatherId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Client objects.</returns>
		public TList<Client> GetByFatherId(TransactionManager transactionManager, System.Int32 _fatherId, int start, int pageLength)
		{
			int count = -1;
			return GetByFatherId(transactionManager, _fatherId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Client_ClientFather key.
		///		fkClientClientFather Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_fatherId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Client objects.</returns>
		public TList<Client> GetByFatherId(System.Int32 _fatherId, int start, int pageLength)
		{
			int count =  -1;
			return GetByFatherId(null, _fatherId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Client_ClientFather key.
		///		fkClientClientFather Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_fatherId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Client objects.</returns>
		public TList<Client> GetByFatherId(System.Int32 _fatherId, int start, int pageLength,out int count)
		{
			return GetByFatherId(null, _fatherId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Client_ClientFather key.
		///		FK_Client_ClientFather Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_fatherId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Client objects.</returns>
		public abstract TList<Client> GetByFatherId(TransactionManager transactionManager, System.Int32 _fatherId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Client_ClientMother key.
		///		FK_Client_ClientMother Description: 
		/// </summary>
		/// <param name="_motherId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Client objects.</returns>
		public TList<Client> GetByMotherId(System.Int32 _motherId)
		{
			int count = -1;
			return GetByMotherId(_motherId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Client_ClientMother key.
		///		FK_Client_ClientMother Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_motherId"></param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Client objects.</returns>
		/// <remarks></remarks>
		public TList<Client> GetByMotherId(TransactionManager transactionManager, System.Int32 _motherId)
		{
			int count = -1;
			return GetByMotherId(transactionManager, _motherId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Client_ClientMother key.
		///		FK_Client_ClientMother Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_motherId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Client objects.</returns>
		public TList<Client> GetByMotherId(TransactionManager transactionManager, System.Int32 _motherId, int start, int pageLength)
		{
			int count = -1;
			return GetByMotherId(transactionManager, _motherId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Client_ClientMother key.
		///		fkClientClientMother Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_motherId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Client objects.</returns>
		public TList<Client> GetByMotherId(System.Int32 _motherId, int start, int pageLength)
		{
			int count =  -1;
			return GetByMotherId(null, _motherId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Client_ClientMother key.
		///		fkClientClientMother Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_motherId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Client objects.</returns>
		public TList<Client> GetByMotherId(System.Int32 _motherId, int start, int pageLength,out int count)
		{
			return GetByMotherId(null, _motherId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Client_ClientMother key.
		///		FK_Client_ClientMother Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_motherId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Client objects.</returns>
		public abstract TList<Client> GetByMotherId(TransactionManager transactionManager, System.Int32 _motherId, int start, int pageLength, out int count);
		
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
		public override Ekip.Framework.Entities.Client Get(TransactionManager transactionManager, Ekip.Framework.Entities.ClientKey key, int start, int pageLength)
		{
			return GetByClientId(transactionManager, key.ClientId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Client index.
		/// </summary>
		/// <param name="_fileNumber"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Client"/> class.</returns>
		public Ekip.Framework.Entities.Client GetByFileNumber(System.Int32 _fileNumber)
		{
			int count = -1;
			return GetByFileNumber(null,_fileNumber, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Client index.
		/// </summary>
		/// <param name="_fileNumber"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Client"/> class.</returns>
		public Ekip.Framework.Entities.Client GetByFileNumber(System.Int32 _fileNumber, int start, int pageLength)
		{
			int count = -1;
			return GetByFileNumber(null, _fileNumber, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Client index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_fileNumber"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Client"/> class.</returns>
		public Ekip.Framework.Entities.Client GetByFileNumber(TransactionManager transactionManager, System.Int32 _fileNumber)
		{
			int count = -1;
			return GetByFileNumber(transactionManager, _fileNumber, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Client index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_fileNumber"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Client"/> class.</returns>
		public Ekip.Framework.Entities.Client GetByFileNumber(TransactionManager transactionManager, System.Int32 _fileNumber, int start, int pageLength)
		{
			int count = -1;
			return GetByFileNumber(transactionManager, _fileNumber, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Client index.
		/// </summary>
		/// <param name="_fileNumber"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Client"/> class.</returns>
		public Ekip.Framework.Entities.Client GetByFileNumber(System.Int32 _fileNumber, int start, int pageLength, out int count)
		{
			return GetByFileNumber(null, _fileNumber, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Client index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_fileNumber"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Client"/> class.</returns>
		public abstract Ekip.Framework.Entities.Client GetByFileNumber(TransactionManager transactionManager, System.Int32 _fileNumber, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Client index.
		/// </summary>
		/// <param name="_clientId"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Client"/> class.</returns>
		public Ekip.Framework.Entities.Client GetByClientId(System.Int32 _clientId)
		{
			int count = -1;
			return GetByClientId(null,_clientId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Client index.
		/// </summary>
		/// <param name="_clientId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Client"/> class.</returns>
		public Ekip.Framework.Entities.Client GetByClientId(System.Int32 _clientId, int start, int pageLength)
		{
			int count = -1;
			return GetByClientId(null, _clientId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Client index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_clientId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Client"/> class.</returns>
		public Ekip.Framework.Entities.Client GetByClientId(TransactionManager transactionManager, System.Int32 _clientId)
		{
			int count = -1;
			return GetByClientId(transactionManager, _clientId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Client index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_clientId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Client"/> class.</returns>
		public Ekip.Framework.Entities.Client GetByClientId(TransactionManager transactionManager, System.Int32 _clientId, int start, int pageLength)
		{
			int count = -1;
			return GetByClientId(transactionManager, _clientId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Client index.
		/// </summary>
		/// <param name="_clientId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Client"/> class.</returns>
		public Ekip.Framework.Entities.Client GetByClientId(System.Int32 _clientId, int start, int pageLength, out int count)
		{
			return GetByClientId(null, _clientId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Client index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_clientId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Client"/> class.</returns>
		public abstract Ekip.Framework.Entities.Client GetByClientId(TransactionManager transactionManager, System.Int32 _clientId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region Client_FindByReason_FirstDate_BirthDate 
		
		/// <summary>
		///	This method wrap the 'Client_FindByReason_FirstDate_BirthDate' stored procedure. 
		/// </summary>
		/// <param name="seanceReasonIds"> A <c>System.String</c> instance.</param>
		/// <param name="firstContactYears"> A <c>System.String</c> instance.</param>
		/// <param name="birthDateYears"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void FindByReason_FirstDate_BirthDate(System.String seanceReasonIds, System.String firstContactYears, System.String birthDateYears)
		{
			 FindByReason_FirstDate_BirthDate(null, 0, int.MaxValue , seanceReasonIds, firstContactYears, birthDateYears);
		}
		
		/// <summary>
		///	This method wrap the 'Client_FindByReason_FirstDate_BirthDate' stored procedure. 
		/// </summary>
		/// <param name="seanceReasonIds"> A <c>System.String</c> instance.</param>
		/// <param name="firstContactYears"> A <c>System.String</c> instance.</param>
		/// <param name="birthDateYears"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void FindByReason_FirstDate_BirthDate(int start, int pageLength, System.String seanceReasonIds, System.String firstContactYears, System.String birthDateYears)
		{
			 FindByReason_FirstDate_BirthDate(null, start, pageLength , seanceReasonIds, firstContactYears, birthDateYears);
		}
				
		/// <summary>
		///	This method wrap the 'Client_FindByReason_FirstDate_BirthDate' stored procedure. 
		/// </summary>
		/// <param name="seanceReasonIds"> A <c>System.String</c> instance.</param>
		/// <param name="firstContactYears"> A <c>System.String</c> instance.</param>
		/// <param name="birthDateYears"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void FindByReason_FirstDate_BirthDate(TransactionManager transactionManager, System.String seanceReasonIds, System.String firstContactYears, System.String birthDateYears)
		{
			 FindByReason_FirstDate_BirthDate(transactionManager, 0, int.MaxValue , seanceReasonIds, firstContactYears, birthDateYears);
		}
		
		/// <summary>
		///	This method wrap the 'Client_FindByReason_FirstDate_BirthDate' stored procedure. 
		/// </summary>
		/// <param name="seanceReasonIds"> A <c>System.String</c> instance.</param>
		/// <param name="firstContactYears"> A <c>System.String</c> instance.</param>
		/// <param name="birthDateYears"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void FindByReason_FirstDate_BirthDate(TransactionManager transactionManager, int start, int pageLength , System.String seanceReasonIds, System.String firstContactYears, System.String birthDateYears);
		
		#endregion
		
		#region Client_AdvisorReport 
		
		/// <summary>
		///	This method wrap the 'Client_AdvisorReport' stored procedure. 
		/// </summary>
		/// <param name="advisorIds"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void AdvisorReport(System.String advisorIds)
		{
			 AdvisorReport(null, 0, int.MaxValue , advisorIds);
		}
		
		/// <summary>
		///	This method wrap the 'Client_AdvisorReport' stored procedure. 
		/// </summary>
		/// <param name="advisorIds"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void AdvisorReport(int start, int pageLength, System.String advisorIds)
		{
			 AdvisorReport(null, start, pageLength , advisorIds);
		}
				
		/// <summary>
		///	This method wrap the 'Client_AdvisorReport' stored procedure. 
		/// </summary>
		/// <param name="advisorIds"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void AdvisorReport(TransactionManager transactionManager, System.String advisorIds)
		{
			 AdvisorReport(transactionManager, 0, int.MaxValue , advisorIds);
		}
		
		/// <summary>
		///	This method wrap the 'Client_AdvisorReport' stored procedure. 
		/// </summary>
		/// <param name="advisorIds"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void AdvisorReport(TransactionManager transactionManager, int start, int pageLength , System.String advisorIds);
		
		#endregion
		
		#region Client_GetAllFirstContactYears 
		
		/// <summary>
		///	This method wrap the 'Client_GetAllFirstContactYears' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="IDataReader"/> instance.</returns>
		public IDataReader GetAllFirstContactYears()
		{
			return GetAllFirstContactYears(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'Client_GetAllFirstContactYears' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="IDataReader"/> instance.</returns>
		public IDataReader GetAllFirstContactYears(int start, int pageLength)
		{
			return GetAllFirstContactYears(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'Client_GetAllFirstContactYears' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="IDataReader"/> instance.</returns>
		public IDataReader GetAllFirstContactYears(TransactionManager transactionManager)
		{
			return GetAllFirstContactYears(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'Client_GetAllFirstContactYears' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="IDataReader"/> instance.</returns>
		public abstract IDataReader GetAllFirstContactYears(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region Client_GetByFirstContactYears 
		
		/// <summary>
		///	This method wrap the 'Client_GetByFirstContactYears' stored procedure. 
		/// </summary>
		/// <param name="years"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Client&gt;"/> instance.</returns>
		public TList<Client> GetByFirstContactYears(System.String years)
		{
			return GetByFirstContactYears(null, 0, int.MaxValue , years);
		}
		
		/// <summary>
		///	This method wrap the 'Client_GetByFirstContactYears' stored procedure. 
		/// </summary>
		/// <param name="years"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Client&gt;"/> instance.</returns>
		public TList<Client> GetByFirstContactYears(int start, int pageLength, System.String years)
		{
			return GetByFirstContactYears(null, start, pageLength , years);
		}
				
		/// <summary>
		///	This method wrap the 'Client_GetByFirstContactYears' stored procedure. 
		/// </summary>
		/// <param name="years"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Client&gt;"/> instance.</returns>
		public TList<Client> GetByFirstContactYears(TransactionManager transactionManager, System.String years)
		{
			return GetByFirstContactYears(transactionManager, 0, int.MaxValue , years);
		}
		
		/// <summary>
		///	This method wrap the 'Client_GetByFirstContactYears' stored procedure. 
		/// </summary>
		/// <param name="years"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Client&gt;"/> instance.</returns>
		public abstract TList<Client> GetByFirstContactYears(TransactionManager transactionManager, int start, int pageLength , System.String years);
		
		#endregion
		
		#region Client_GetAllBirthDateYears 
		
		/// <summary>
		///	This method wrap the 'Client_GetAllBirthDateYears' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="IDataReader"/> instance.</returns>
		public IDataReader GetAllBirthDateYears()
		{
			return GetAllBirthDateYears(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'Client_GetAllBirthDateYears' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="IDataReader"/> instance.</returns>
		public IDataReader GetAllBirthDateYears(int start, int pageLength)
		{
			return GetAllBirthDateYears(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'Client_GetAllBirthDateYears' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="IDataReader"/> instance.</returns>
		public IDataReader GetAllBirthDateYears(TransactionManager transactionManager)
		{
			return GetAllBirthDateYears(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'Client_GetAllBirthDateYears' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="IDataReader"/> instance.</returns>
		public abstract IDataReader GetAllBirthDateYears(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region Client_GetFirst 
		
		/// <summary>
		///	This method wrap the 'Client_GetFirst' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Client&gt;"/> instance.</returns>
		public TList<Client> GetFirst()
		{
			return GetFirst(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'Client_GetFirst' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Client&gt;"/> instance.</returns>
		public TList<Client> GetFirst(int start, int pageLength)
		{
			return GetFirst(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'Client_GetFirst' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Client&gt;"/> instance.</returns>
		public TList<Client> GetFirst(TransactionManager transactionManager)
		{
			return GetFirst(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'Client_GetFirst' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Client&gt;"/> instance.</returns>
		public abstract TList<Client> GetFirst(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region Client_GetFileNumbers 
		
		/// <summary>
		///	This method wrap the 'Client_GetFileNumbers' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="IDataReader"/> instance.</returns>
		public IDataReader GetFileNumbers()
		{
			return GetFileNumbers(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'Client_GetFileNumbers' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="IDataReader"/> instance.</returns>
		public IDataReader GetFileNumbers(int start, int pageLength)
		{
			return GetFileNumbers(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'Client_GetFileNumbers' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="IDataReader"/> instance.</returns>
		public IDataReader GetFileNumbers(TransactionManager transactionManager)
		{
			return GetFileNumbers(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'Client_GetFileNumbers' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="IDataReader"/> instance.</returns>
		public abstract IDataReader GetFileNumbers(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region Client_GetLast 
		
		/// <summary>
		///	This method wrap the 'Client_GetLast' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Client&gt;"/> instance.</returns>
		public TList<Client> GetLast()
		{
			return GetLast(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'Client_GetLast' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Client&gt;"/> instance.</returns>
		public TList<Client> GetLast(int start, int pageLength)
		{
			return GetLast(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'Client_GetLast' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Client&gt;"/> instance.</returns>
		public TList<Client> GetLast(TransactionManager transactionManager)
		{
			return GetLast(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'Client_GetLast' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Client&gt;"/> instance.</returns>
		public abstract TList<Client> GetLast(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Client&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Client&gt;"/></returns>
		public static TList<Client> Fill(IDataReader reader, TList<Client> rows, int start, int pageLength)
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
				
				Ekip.Framework.Entities.Client c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Client")
					.Append("|").Append((System.Int32)reader[((int)ClientColumn.ClientId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Client>(
					key.ToString(), // EntityTrackingKey
					"Client",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Ekip.Framework.Entities.Client();
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
					c.ClientId = (System.Int32)reader[((int)ClientColumn.ClientId - 1)];
					c.FileNumber = (System.Int32)reader[((int)ClientColumn.FileNumber - 1)];
					c.FirstContactDate = (System.DateTime)reader[((int)ClientColumn.FirstContactDate - 1)];
					c.FirstContactAge = (System.Int32)reader[((int)ClientColumn.FirstContactAge - 1)];
					c.CurrentAge = (System.Int32)reader[((int)ClientColumn.CurrentAge - 1)];
					c.BirthDate = (System.DateTime)reader[((int)ClientColumn.BirthDate - 1)];
					c.CalendarAgeId = (System.Int32)reader[((int)ClientColumn.CalendarAgeId - 1)];
					c.FullName = (System.String)reader[((int)ClientColumn.FullName - 1)];
					c.MiddleName = (reader.IsDBNull(((int)ClientColumn.MiddleName - 1)))?null:(System.String)reader[((int)ClientColumn.MiddleName - 1)];
					c.Reference = (reader.IsDBNull(((int)ClientColumn.Reference - 1)))?null:(System.String)reader[((int)ClientColumn.Reference - 1)];
					c.MotherId = (System.Int32)reader[((int)ClientColumn.MotherId - 1)];
					c.FatherId = (System.Int32)reader[((int)ClientColumn.FatherId - 1)];
					c.AddressId = (reader.IsDBNull(((int)ClientColumn.AddressId - 1)))?null:(System.Int32?)reader[((int)ClientColumn.AddressId - 1)];
					c.IdCard = (reader.IsDBNull(((int)ClientColumn.IdCard - 1)))?null:(System.String)reader[((int)ClientColumn.IdCard - 1)];
					c.Gender = (System.Byte)reader[((int)ClientColumn.Gender - 1)];
					c.Blood = (System.Byte)reader[((int)ClientColumn.Blood - 1)];
					c.Pediatrician = (reader.IsDBNull(((int)ClientColumn.Pediatrician - 1)))?null:(System.String)reader[((int)ClientColumn.Pediatrician - 1)];
					c.CountOfChild = (System.Int32)reader[((int)ClientColumn.CountOfChild - 1)];
					c.FamilyStatus = (System.Byte)reader[((int)ClientColumn.FamilyStatus - 1)];
					c.Notes = (reader.IsDBNull(((int)ClientColumn.Notes - 1)))?null:(System.String)reader[((int)ClientColumn.Notes - 1)];
					c.CreateDate = (System.DateTime)reader[((int)ClientColumn.CreateDate - 1)];
					c.UpdateDate = (reader.IsDBNull(((int)ClientColumn.UpdateDate - 1)))?null:(System.DateTime?)reader[((int)ClientColumn.UpdateDate - 1)];
					c.CreateUserId = (System.Int32)reader[((int)ClientColumn.CreateUserId - 1)];
					c.UpdateUserId = (reader.IsDBNull(((int)ClientColumn.UpdateUserId - 1)))?null:(System.Int32?)reader[((int)ClientColumn.UpdateUserId - 1)];
					c.Active = (System.Boolean)reader[((int)ClientColumn.Active - 1)];
					c.Deleted = (System.Boolean)reader[((int)ClientColumn.Deleted - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.Client"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Client"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Ekip.Framework.Entities.Client entity)
		{
			if (!reader.Read()) return;
			
			entity.ClientId = (System.Int32)reader[((int)ClientColumn.ClientId - 1)];
			entity.FileNumber = (System.Int32)reader[((int)ClientColumn.FileNumber - 1)];
			entity.FirstContactDate = (System.DateTime)reader[((int)ClientColumn.FirstContactDate - 1)];
			entity.FirstContactAge = (System.Int32)reader[((int)ClientColumn.FirstContactAge - 1)];
			entity.CurrentAge = (System.Int32)reader[((int)ClientColumn.CurrentAge - 1)];
			entity.BirthDate = (System.DateTime)reader[((int)ClientColumn.BirthDate - 1)];
			entity.CalendarAgeId = (System.Int32)reader[((int)ClientColumn.CalendarAgeId - 1)];
			entity.FullName = (System.String)reader[((int)ClientColumn.FullName - 1)];
			entity.MiddleName = (reader.IsDBNull(((int)ClientColumn.MiddleName - 1)))?null:(System.String)reader[((int)ClientColumn.MiddleName - 1)];
			entity.Reference = (reader.IsDBNull(((int)ClientColumn.Reference - 1)))?null:(System.String)reader[((int)ClientColumn.Reference - 1)];
			entity.MotherId = (System.Int32)reader[((int)ClientColumn.MotherId - 1)];
			entity.FatherId = (System.Int32)reader[((int)ClientColumn.FatherId - 1)];
			entity.AddressId = (reader.IsDBNull(((int)ClientColumn.AddressId - 1)))?null:(System.Int32?)reader[((int)ClientColumn.AddressId - 1)];
			entity.IdCard = (reader.IsDBNull(((int)ClientColumn.IdCard - 1)))?null:(System.String)reader[((int)ClientColumn.IdCard - 1)];
			entity.Gender = (System.Byte)reader[((int)ClientColumn.Gender - 1)];
			entity.Blood = (System.Byte)reader[((int)ClientColumn.Blood - 1)];
			entity.Pediatrician = (reader.IsDBNull(((int)ClientColumn.Pediatrician - 1)))?null:(System.String)reader[((int)ClientColumn.Pediatrician - 1)];
			entity.CountOfChild = (System.Int32)reader[((int)ClientColumn.CountOfChild - 1)];
			entity.FamilyStatus = (System.Byte)reader[((int)ClientColumn.FamilyStatus - 1)];
			entity.Notes = (reader.IsDBNull(((int)ClientColumn.Notes - 1)))?null:(System.String)reader[((int)ClientColumn.Notes - 1)];
			entity.CreateDate = (System.DateTime)reader[((int)ClientColumn.CreateDate - 1)];
			entity.UpdateDate = (reader.IsDBNull(((int)ClientColumn.UpdateDate - 1)))?null:(System.DateTime?)reader[((int)ClientColumn.UpdateDate - 1)];
			entity.CreateUserId = (System.Int32)reader[((int)ClientColumn.CreateUserId - 1)];
			entity.UpdateUserId = (reader.IsDBNull(((int)ClientColumn.UpdateUserId - 1)))?null:(System.Int32?)reader[((int)ClientColumn.UpdateUserId - 1)];
			entity.Active = (System.Boolean)reader[((int)ClientColumn.Active - 1)];
			entity.Deleted = (System.Boolean)reader[((int)ClientColumn.Deleted - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.Client"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Client"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Ekip.Framework.Entities.Client entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ClientId = (System.Int32)dataRow["ClientId"];
			entity.FileNumber = (System.Int32)dataRow["FileNumber"];
			entity.FirstContactDate = (System.DateTime)dataRow["FirstContactDate"];
			entity.FirstContactAge = (System.Int32)dataRow["FirstContactAge"];
			entity.CurrentAge = (System.Int32)dataRow["CurrentAge"];
			entity.BirthDate = (System.DateTime)dataRow["BirthDate"];
			entity.CalendarAgeId = (System.Int32)dataRow["CalendarAgeId"];
			entity.FullName = (System.String)dataRow["FullName"];
			entity.MiddleName = Convert.IsDBNull(dataRow["MiddleName"]) ? null : (System.String)dataRow["MiddleName"];
			entity.Reference = Convert.IsDBNull(dataRow["Reference"]) ? null : (System.String)dataRow["Reference"];
			entity.MotherId = (System.Int32)dataRow["MotherId"];
			entity.FatherId = (System.Int32)dataRow["FatherId"];
			entity.AddressId = Convert.IsDBNull(dataRow["AddressId"]) ? null : (System.Int32?)dataRow["AddressId"];
			entity.IdCard = Convert.IsDBNull(dataRow["IdCard"]) ? null : (System.String)dataRow["IdCard"];
			entity.Gender = (System.Byte)dataRow["Gender"];
			entity.Blood = (System.Byte)dataRow["Blood"];
			entity.Pediatrician = Convert.IsDBNull(dataRow["Pediatrician"]) ? null : (System.String)dataRow["Pediatrician"];
			entity.CountOfChild = (System.Int32)dataRow["CountOfChild"];
			entity.FamilyStatus = (System.Byte)dataRow["FamilyStatus"];
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
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Client"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.Client Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Ekip.Framework.Entities.Client entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region AddressIdSource	
			if (CanDeepLoad(entity, "ClientAddress|AddressIdSource", deepLoadType, innerList) 
				&& entity.AddressIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.AddressId ?? (int)0);
				ClientAddress tmpEntity = EntityManager.LocateEntity<ClientAddress>(EntityLocator.ConstructKeyFromPkItems(typeof(ClientAddress), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.AddressIdSource = tmpEntity;
				else
					entity.AddressIdSource = DataRepository.ClientAddressProvider.GetByAddressId(transactionManager, (entity.AddressId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AddressIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.AddressIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ClientAddressProvider.DeepLoad(transactionManager, entity.AddressIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion AddressIdSource

			#region FatherIdSource	
			if (CanDeepLoad(entity, "ClientFather|FatherIdSource", deepLoadType, innerList) 
				&& entity.FatherIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.FatherId;
				ClientFather tmpEntity = EntityManager.LocateEntity<ClientFather>(EntityLocator.ConstructKeyFromPkItems(typeof(ClientFather), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.FatherIdSource = tmpEntity;
				else
					entity.FatherIdSource = DataRepository.ClientFatherProvider.GetByFatherId(transactionManager, entity.FatherId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'FatherIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.FatherIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ClientFatherProvider.DeepLoad(transactionManager, entity.FatherIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion FatherIdSource

			#region MotherIdSource	
			if (CanDeepLoad(entity, "ClientMother|MotherIdSource", deepLoadType, innerList) 
				&& entity.MotherIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.MotherId;
				ClientMother tmpEntity = EntityManager.LocateEntity<ClientMother>(EntityLocator.ConstructKeyFromPkItems(typeof(ClientMother), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.MotherIdSource = tmpEntity;
				else
					entity.MotherIdSource = DataRepository.ClientMotherProvider.GetByMotherId(transactionManager, entity.MotherId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'MotherIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.MotherIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ClientMotherProvider.DeepLoad(transactionManager, entity.MotherIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion MotherIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByClientId methods when available
			
			#region ObservationFormAnswerCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ObservationFormAnswer>|ObservationFormAnswerCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ObservationFormAnswerCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ObservationFormAnswerCollection = DataRepository.ObservationFormAnswerProvider.GetByClientId(transactionManager, entity.ClientId);

				if (deep && entity.ObservationFormAnswerCollection.Count > 0)
				{
					deepHandles.Add("ObservationFormAnswerCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<ObservationFormAnswer>) DataRepository.ObservationFormAnswerProvider.DeepLoad,
						new object[] { transactionManager, entity.ObservationFormAnswerCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region SiblingCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Sibling>|SiblingCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SiblingCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SiblingCollection = DataRepository.SiblingProvider.GetByClientId(transactionManager, entity.ClientId);

				if (deep && entity.SiblingCollection.Count > 0)
				{
					deepHandles.Add("SiblingCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Sibling>) DataRepository.SiblingProvider.DeepLoad,
						new object[] { transactionManager, entity.SiblingCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region SeanceCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Seance>|SeanceCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SeanceCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SeanceCollection = DataRepository.SeanceProvider.GetByClientId(transactionManager, entity.ClientId);

				if (deep && entity.SeanceCollection.Count > 0)
				{
					deepHandles.Add("SeanceCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Seance>) DataRepository.SeanceProvider.DeepLoad,
						new object[] { transactionManager, entity.SeanceCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region QuestionFormAnswerCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<QuestionFormAnswer>|QuestionFormAnswerCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'QuestionFormAnswerCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.QuestionFormAnswerCollection = DataRepository.QuestionFormAnswerProvider.GetByClientId(transactionManager, entity.ClientId);

				if (deep && entity.QuestionFormAnswerCollection.Count > 0)
				{
					deepHandles.Add("QuestionFormAnswerCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<QuestionFormAnswer>) DataRepository.QuestionFormAnswerProvider.DeepLoad,
						new object[] { transactionManager, entity.QuestionFormAnswerCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region SeanceQuestionAnswerCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SeanceQuestionAnswer>|SeanceQuestionAnswerCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SeanceQuestionAnswerCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SeanceQuestionAnswerCollection = DataRepository.SeanceQuestionAnswerProvider.GetByClientId(transactionManager, entity.ClientId);

				if (deep && entity.SeanceQuestionAnswerCollection.Count > 0)
				{
					deepHandles.Add("SeanceQuestionAnswerCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SeanceQuestionAnswer>) DataRepository.SeanceQuestionAnswerProvider.DeepLoad,
						new object[] { transactionManager, entity.SeanceQuestionAnswerCollection, deep, deepLoadType, childTypes, innerList }
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

				entity.ClientEducationCollection = DataRepository.ClientEducationProvider.GetByClientId(transactionManager, entity.ClientId);

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
		/// Deep Save the entire object graph of the Ekip.Framework.Entities.Client object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Ekip.Framework.Entities.Client instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.Client Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Ekip.Framework.Entities.Client entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region AddressIdSource
			if (CanDeepSave(entity, "ClientAddress|AddressIdSource", deepSaveType, innerList) 
				&& entity.AddressIdSource != null)
			{
				DataRepository.ClientAddressProvider.Save(transactionManager, entity.AddressIdSource);
				entity.AddressId = entity.AddressIdSource.AddressId;
			}
			#endregion 
			
			#region FatherIdSource
			if (CanDeepSave(entity, "ClientFather|FatherIdSource", deepSaveType, innerList) 
				&& entity.FatherIdSource != null)
			{
				DataRepository.ClientFatherProvider.Save(transactionManager, entity.FatherIdSource);
				entity.FatherId = entity.FatherIdSource.FatherId;
			}
			#endregion 
			
			#region MotherIdSource
			if (CanDeepSave(entity, "ClientMother|MotherIdSource", deepSaveType, innerList) 
				&& entity.MotherIdSource != null)
			{
				DataRepository.ClientMotherProvider.Save(transactionManager, entity.MotherIdSource);
				entity.MotherId = entity.MotherIdSource.MotherId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<ObservationFormAnswer>
				if (CanDeepSave(entity.ObservationFormAnswerCollection, "List<ObservationFormAnswer>|ObservationFormAnswerCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ObservationFormAnswer child in entity.ObservationFormAnswerCollection)
					{
						if(child.ClientIdSource != null)
						{
							child.ClientId = child.ClientIdSource.ClientId;
						}
						else
						{
							child.ClientId = entity.ClientId;
						}

					}

					if (entity.ObservationFormAnswerCollection.Count > 0 || entity.ObservationFormAnswerCollection.DeletedItems.Count > 0)
					{
						//DataRepository.ObservationFormAnswerProvider.Save(transactionManager, entity.ObservationFormAnswerCollection);
						
						deepHandles.Add("ObservationFormAnswerCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< ObservationFormAnswer >) DataRepository.ObservationFormAnswerProvider.DeepSave,
							new object[] { transactionManager, entity.ObservationFormAnswerCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<Sibling>
				if (CanDeepSave(entity.SiblingCollection, "List<Sibling>|SiblingCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Sibling child in entity.SiblingCollection)
					{
						if(child.ClientIdSource != null)
						{
							child.ClientId = child.ClientIdSource.ClientId;
						}
						else
						{
							child.ClientId = entity.ClientId;
						}

					}

					if (entity.SiblingCollection.Count > 0 || entity.SiblingCollection.DeletedItems.Count > 0)
					{
						//DataRepository.SiblingProvider.Save(transactionManager, entity.SiblingCollection);
						
						deepHandles.Add("SiblingCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Sibling >) DataRepository.SiblingProvider.DeepSave,
							new object[] { transactionManager, entity.SiblingCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<Seance>
				if (CanDeepSave(entity.SeanceCollection, "List<Seance>|SeanceCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Seance child in entity.SeanceCollection)
					{
						if(child.ClientIdSource != null)
						{
							child.ClientId = child.ClientIdSource.ClientId;
						}
						else
						{
							child.ClientId = entity.ClientId;
						}

					}

					if (entity.SeanceCollection.Count > 0 || entity.SeanceCollection.DeletedItems.Count > 0)
					{
						//DataRepository.SeanceProvider.Save(transactionManager, entity.SeanceCollection);
						
						deepHandles.Add("SeanceCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Seance >) DataRepository.SeanceProvider.DeepSave,
							new object[] { transactionManager, entity.SeanceCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<QuestionFormAnswer>
				if (CanDeepSave(entity.QuestionFormAnswerCollection, "List<QuestionFormAnswer>|QuestionFormAnswerCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(QuestionFormAnswer child in entity.QuestionFormAnswerCollection)
					{
						if(child.ClientIdSource != null)
						{
							child.ClientId = child.ClientIdSource.ClientId;
						}
						else
						{
							child.ClientId = entity.ClientId;
						}

					}

					if (entity.QuestionFormAnswerCollection.Count > 0 || entity.QuestionFormAnswerCollection.DeletedItems.Count > 0)
					{
						//DataRepository.QuestionFormAnswerProvider.Save(transactionManager, entity.QuestionFormAnswerCollection);
						
						deepHandles.Add("QuestionFormAnswerCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< QuestionFormAnswer >) DataRepository.QuestionFormAnswerProvider.DeepSave,
							new object[] { transactionManager, entity.QuestionFormAnswerCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<SeanceQuestionAnswer>
				if (CanDeepSave(entity.SeanceQuestionAnswerCollection, "List<SeanceQuestionAnswer>|SeanceQuestionAnswerCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SeanceQuestionAnswer child in entity.SeanceQuestionAnswerCollection)
					{
						if(child.ClientIdSource != null)
						{
							child.ClientId = child.ClientIdSource.ClientId;
						}
						else
						{
							child.ClientId = entity.ClientId;
						}

					}

					if (entity.SeanceQuestionAnswerCollection.Count > 0 || entity.SeanceQuestionAnswerCollection.DeletedItems.Count > 0)
					{
						//DataRepository.SeanceQuestionAnswerProvider.Save(transactionManager, entity.SeanceQuestionAnswerCollection);
						
						deepHandles.Add("SeanceQuestionAnswerCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SeanceQuestionAnswer >) DataRepository.SeanceQuestionAnswerProvider.DeepSave,
							new object[] { transactionManager, entity.SeanceQuestionAnswerCollection, deepSaveType, childTypes, innerList }
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
						if(child.ClientIdSource != null)
						{
							child.ClientId = child.ClientIdSource.ClientId;
						}
						else
						{
							child.ClientId = entity.ClientId;
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
	
	#region ClientChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Ekip.Framework.Entities.Client</c>
	///</summary>
	public enum ClientChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>ClientAddress</c> at AddressIdSource
		///</summary>
		[ChildEntityType(typeof(ClientAddress))]
		ClientAddress,
			
		///<summary>
		/// Composite Property for <c>ClientFather</c> at FatherIdSource
		///</summary>
		[ChildEntityType(typeof(ClientFather))]
		ClientFather,
			
		///<summary>
		/// Composite Property for <c>ClientMother</c> at MotherIdSource
		///</summary>
		[ChildEntityType(typeof(ClientMother))]
		ClientMother,
	
		///<summary>
		/// Collection of <c>Client</c> as OneToMany for ObservationFormAnswerCollection
		///</summary>
		[ChildEntityType(typeof(TList<ObservationFormAnswer>))]
		ObservationFormAnswerCollection,

		///<summary>
		/// Collection of <c>Client</c> as OneToMany for SiblingCollection
		///</summary>
		[ChildEntityType(typeof(TList<Sibling>))]
		SiblingCollection,

		///<summary>
		/// Collection of <c>Client</c> as OneToMany for SeanceCollection
		///</summary>
		[ChildEntityType(typeof(TList<Seance>))]
		SeanceCollection,

		///<summary>
		/// Collection of <c>Client</c> as OneToMany for QuestionFormAnswerCollection
		///</summary>
		[ChildEntityType(typeof(TList<QuestionFormAnswer>))]
		QuestionFormAnswerCollection,

		///<summary>
		/// Collection of <c>Client</c> as OneToMany for SeanceQuestionAnswerCollection
		///</summary>
		[ChildEntityType(typeof(TList<SeanceQuestionAnswer>))]
		SeanceQuestionAnswerCollection,

		///<summary>
		/// Collection of <c>Client</c> as OneToMany for ClientEducationCollection
		///</summary>
		[ChildEntityType(typeof(TList<ClientEducation>))]
		ClientEducationCollection,
	}
	
	#endregion ClientChildEntityTypes
	
	#region ClientFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ClientColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Client"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClientFilterBuilder : SqlFilterBuilder<ClientColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClientFilterBuilder class.
		/// </summary>
		public ClientFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ClientFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ClientFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ClientFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ClientFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ClientFilterBuilder
	
	#region ClientParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ClientColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Client"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClientParameterBuilder : ParameterizedSqlFilterBuilder<ClientColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClientParameterBuilder class.
		/// </summary>
		public ClientParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ClientParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ClientParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ClientParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ClientParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ClientParameterBuilder
	
	#region ClientSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ClientColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Client"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ClientSortBuilder : SqlSortBuilder<ClientColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClientSqlSortBuilder class.
		/// </summary>
		public ClientSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ClientSortBuilder
	
} // end namespace
