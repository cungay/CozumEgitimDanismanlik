﻿
/*
	File Generated by NetTiers templates [www.nettiers.net]
	Generated on : 18 Aralık 2018 Salı
	Important: Do not modify this file. Edit the file SqlClientAddressProvider.cs instead.
*/

#region using directives

using System;
using System.Data;
using System.Data.Common;
using System.Text;

using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using System.Collections;
using System.Collections.Specialized;

using System.Diagnostics;
using Ekip.Framework.Entities;
using Ekip.Framework.Data;
using Ekip.Framework.Data.Bases;

#endregion

namespace Ekip.Framework.Data.SqlClient
{
	///<summary>
	/// This class is the SqlClient Data Access Logic Component implementation for the <see cref="ClientAddress"/> entity.
	///</summary>
	public abstract partial class SqlClientAddressProviderBase : ClientAddressProviderBase
	{
		#region Declarations
		
		string _connectionString;
	    bool _useStoredProcedure;
	    string _providerInvariantName;
			
		#endregion "Declarations"
			
		#region Constructors
		
		/// <summary>
		/// Creates a new <see cref="SqlClientAddressProviderBase"/> instance.
		/// </summary>
		public SqlClientAddressProviderBase()
		{
		}
	
	/// <summary>
	/// Creates a new <see cref="SqlClientAddressProviderBase"/> instance.
	/// Uses connection string to connect to datasource.
	/// </summary>
	/// <param name="connectionString">The connection string to the database.</param>
	/// <param name="useStoredProcedure">A boolean value that indicates if we should use stored procedures or embedded queries.</param>
	/// <param name="providerInvariantName">Name of the invariant provider use by the DbProviderFactory.</param>
	public SqlClientAddressProviderBase(string connectionString, bool useStoredProcedure, string providerInvariantName)
	{
		this._connectionString = connectionString;
		this._useStoredProcedure = useStoredProcedure;
		this._providerInvariantName = providerInvariantName;
	}
		
	#endregion "Constructors"
	
		#region Public properties
	/// <summary>
    /// Gets or sets the connection string.
    /// </summary>
    /// <value>The connection string.</value>
    public string ConnectionString
	{
		get {return this._connectionString;}
		set {this._connectionString = value;}
	}
	
	/// <summary>
    /// Gets or sets a value indicating whether to use stored procedures.
    /// </summary>
    /// <value><c>true</c> if we choose to use use stored procedures; otherwise, <c>false</c>.</value>
	public bool UseStoredProcedure
	{
		get {return this._useStoredProcedure;}
		set {this._useStoredProcedure = value;}
	}
	
	/// <summary>
    /// Gets or sets the invariant provider name listed in the DbProviderFactories machine.config section.
    /// </summary>
    /// <value>The name of the provider invariant.</value>
    public string ProviderInvariantName
    {
        get { return this._providerInvariantName; }
        set { this._providerInvariantName = value; }
    }
	#endregion
	
		#region Get Many To Many Relationship Functions
		#endregion
	
		#region Delete Functions
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_addressId">. Primary Key.</param>	
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override bool Delete(TransactionManager transactionManager, System.Int32 _addressId)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.sp_ClientAddress_Delete", _useStoredProcedure);
			database.AddInParameter(commandWrapper, "@AddressId", DbType.Int32, _addressId);
			
			//Provider Data Requesting Command Event
			OnDataRequesting(new CommandEventArgs(commandWrapper, "Delete")); 

			int results = 0;
			
			if (transactionManager != null)
			{	
				results = Utility.ExecuteNonQuery(transactionManager, commandWrapper);
			}
			else
			{
				results = Utility.ExecuteNonQuery(database,commandWrapper);
			}
			
			//Stop Tracking Now that it has been updated and persisted.
			if (DataRepository.Provider.EnableEntityTracking)
			{
				string entityKey = EntityLocator.ConstructKeyFromPkItems(typeof(ClientAddress)
					,_addressId);
                EntityManager.StopTracking(entityKey);
                
			}
			
			//Provider Data Requested Command Event
			OnDataRequested(new CommandEventArgs(commandWrapper, "Delete")); 

			commandWrapper = null;
			
			return Convert.ToBoolean(results);
		}//end Delete
		#endregion

		#region Find Functions

		#region Parsed Find Methods
		/// <summary>
		/// 	Returns rows meeting the whereClause condition from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out. The number of rows that match this query.</param>
		/// <remarks>Operators must be capitalized (OR, AND).</remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ClientAddress objects.</returns>
		public override TList<ClientAddress> Find(TransactionManager transactionManager, string whereClause, int start, int pageLength, out int count)
		{
			count = -1;
			if (whereClause.IndexOf(";") > -1)
				return new TList<ClientAddress>();
	
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.sp_ClientAddress_Find", _useStoredProcedure);

		bool searchUsingOR = false;
		if (whereClause.IndexOf(" OR ") > 0) // did they want to do "a=b OR c=d OR..."?
			searchUsingOR = true;
		
		database.AddInParameter(commandWrapper, "@SearchUsingOR", DbType.Boolean, searchUsingOR);
		
		database.AddInParameter(commandWrapper, "@AddressId", DbType.Int32, DBNull.Value);
		database.AddInParameter(commandWrapper, "@TitleId", DbType.Byte, DBNull.Value);
		database.AddInParameter(commandWrapper, "@AddressLine", DbType.AnsiString, DBNull.Value);
		database.AddInParameter(commandWrapper, "@ProvinceId", DbType.Int32, DBNull.Value);
		database.AddInParameter(commandWrapper, "@TownId", DbType.Int32, DBNull.Value);
		database.AddInParameter(commandWrapper, "@NeighborhoodId", DbType.Int32, DBNull.Value);
		database.AddInParameter(commandWrapper, "@StreetId", DbType.Int32, DBNull.Value);
		database.AddInParameter(commandWrapper, "@Phone1", DbType.AnsiString, DBNull.Value);
		database.AddInParameter(commandWrapper, "@Phone2", DbType.AnsiString, DBNull.Value);
		database.AddInParameter(commandWrapper, "@Mobile", DbType.AnsiString, DBNull.Value);
		database.AddInParameter(commandWrapper, "@IsUsed", DbType.Boolean, DBNull.Value);
		database.AddInParameter(commandWrapper, "@CreateOn", DbType.DateTime, DBNull.Value);
		database.AddInParameter(commandWrapper, "@UpdateOn", DbType.DateTime, DBNull.Value);
		database.AddInParameter(commandWrapper, "@UserId", DbType.Int32, DBNull.Value);
	
			// replace all instances of 'AND' and 'OR' because we already set searchUsingOR
			whereClause = whereClause.Replace(" AND ", "|").Replace(" OR ", "|") ; 
			string[] clauses = whereClause.ToLower().Split('|');
		
			// Here's what's going on below: Find a field, then to get the value we
			// drop the field name from the front, trim spaces, drop the '=' sign,
			// trim more spaces, and drop any outer single quotes.
			// Now handles the case when two fields start off the same way - like "Friendly='Yes' AND Friend='john'"
				
			char[] equalSign = {'='};
			char[] singleQuote = {'\''};
	   		foreach (string clause in clauses)
			{
				if (clause.Trim().StartsWith("addressıd ") || clause.Trim().StartsWith("addressıd="))
				{
					database.SetParameterValue(commandWrapper, "@AddressId", 
						clause.Trim().Remove(0,9).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("titleıd ") || clause.Trim().StartsWith("titleıd="))
				{
					database.SetParameterValue(commandWrapper, "@TitleId", 
						clause.Trim().Remove(0,7).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("addressline ") || clause.Trim().StartsWith("addressline="))
				{
					database.SetParameterValue(commandWrapper, "@AddressLine", 
						clause.Trim().Remove(0,11).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("provinceıd ") || clause.Trim().StartsWith("provinceıd="))
				{
					database.SetParameterValue(commandWrapper, "@ProvinceId", 
						clause.Trim().Remove(0,10).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("townıd ") || clause.Trim().StartsWith("townıd="))
				{
					database.SetParameterValue(commandWrapper, "@TownId", 
						clause.Trim().Remove(0,6).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("neighborhoodıd ") || clause.Trim().StartsWith("neighborhoodıd="))
				{
					database.SetParameterValue(commandWrapper, "@NeighborhoodId", 
						clause.Trim().Remove(0,14).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("streetıd ") || clause.Trim().StartsWith("streetıd="))
				{
					database.SetParameterValue(commandWrapper, "@StreetId", 
						clause.Trim().Remove(0,8).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("phone1 ") || clause.Trim().StartsWith("phone1="))
				{
					database.SetParameterValue(commandWrapper, "@Phone1", 
						clause.Trim().Remove(0,6).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("phone2 ") || clause.Trim().StartsWith("phone2="))
				{
					database.SetParameterValue(commandWrapper, "@Phone2", 
						clause.Trim().Remove(0,6).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("mobile ") || clause.Trim().StartsWith("mobile="))
				{
					database.SetParameterValue(commandWrapper, "@Mobile", 
						clause.Trim().Remove(0,6).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("ısused ") || clause.Trim().StartsWith("ısused="))
				{
					database.SetParameterValue(commandWrapper, "@IsUsed", 
						clause.Trim().Remove(0,6).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("createon ") || clause.Trim().StartsWith("createon="))
				{
					database.SetParameterValue(commandWrapper, "@CreateOn", 
						clause.Trim().Remove(0,8).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("updateon ") || clause.Trim().StartsWith("updateon="))
				{
					database.SetParameterValue(commandWrapper, "@UpdateOn", 
						clause.Trim().Remove(0,8).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("userıd ") || clause.Trim().StartsWith("userıd="))
				{
					database.SetParameterValue(commandWrapper, "@UserId", 
						clause.Trim().Remove(0,6).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
	
				throw new ArgumentException("Unable to use this part of the where clause in this version of Find: " + clause);
			}
					
			IDataReader reader = null;
			//Create Collection
			TList<ClientAddress> rows = new TList<ClientAddress>();
	
				
			try
			{
				//Provider Data Requesting Command Event
				OnDataRequesting(new CommandEventArgs(commandWrapper, "Find", rows)); 

				if (transactionManager != null)
				{
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}		
				
				Fill(reader, rows, start, pageLength);
				
				if(reader.NextResult())
				{
					if(reader.Read())
					{
						count = reader.GetInt32(0);
					}
				}
				
				//Provider Data Requested Command Event
				OnDataRequested(new CommandEventArgs(commandWrapper, "Find", rows)); 
			}
			finally
			{
				if (reader != null) 
					reader.Close();	
					
				commandWrapper = null;
			}
			return rows;
		}

		#endregion Parsed Find Methods
		
		#region Parameterized Find Methods
		
		/// <summary>
		/// 	Returns rows from the DataSource that meet the parameter conditions.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="parameters">A collection of <see cref="SqlFilterParameter"/> objects.</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out. The number of rows that match this query.</param>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ClientAddress objects.</returns>
		public override TList<ClientAddress> Find(TransactionManager transactionManager, IFilterParameterCollection parameters, string orderBy, int start, int pageLength, out int count)
		{
			SqlFilterParameterCollection filter = null;
			
			if (parameters == null)
				filter = new SqlFilterParameterCollection();
			else 
				filter = parameters.GetParameters();
				
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.sp_ClientAddress_Find_Dynamic", typeof(ClientAddressColumn), filter, orderBy, start, pageLength);
		
			SqlFilterParameter param;

			for ( int i = 0; i < filter.Count; i++ )
			{
				param = filter[i];
				database.AddInParameter(commandWrapper, param.Name, param.DbType, param.GetValue());
			}

			TList<ClientAddress> rows = new TList<ClientAddress>();
			IDataReader reader = null;
			
			try
			{
				//Provider Data Requesting Command Event
				OnDataRequesting(new CommandEventArgs(commandWrapper, "Find", rows)); 

				if ( transactionManager != null )
				{
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}
				
				Fill(reader, rows, 0, int.MaxValue);
				count = rows.Count;
				
				if ( reader.NextResult() )
				{
					if ( reader.Read() )
					{
						count = reader.GetInt32(0);
					}
				}
				
				//Provider Data Requested Command Event
				OnDataRequested(new CommandEventArgs(commandWrapper, "Find", rows)); 
			}
			finally
			{
				if ( reader != null )
					reader.Close();
					
				commandWrapper = null;
			}
			
			return rows;
		}
		
		#endregion Parameterized Find Methods
		
		#endregion Find Functions
	
		#region GetAll Methods
				
		/// <summary>
		/// 	Gets All rows from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out. The number of rows that match this query.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ClientAddress objects.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override TList<ClientAddress> GetAll(TransactionManager transactionManager, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.sp_ClientAddress_Get_List", _useStoredProcedure);
			
			IDataReader reader = null;
		
			//Create Collection
			TList<ClientAddress> rows = new TList<ClientAddress>();
			
			try
			{
				//Provider Data Requesting Command Event
				OnDataRequesting(new CommandEventArgs(commandWrapper, "GetAll", rows)); 
					
				if (transactionManager != null)
				{
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}		
		
				Fill(reader, rows, start, pageLength);
				count = -1;
				if(reader.NextResult())
				{
					if(reader.Read())
					{
						count = reader.GetInt32(0);
					}
				}
				
				//Provider Data Requested Command Event
				OnDataRequested(new CommandEventArgs(commandWrapper, "GetAll", rows)); 
			}
			finally 
			{
				if (reader != null) 
					reader.Close();
					
				commandWrapper = null;	
			}
			return rows;
		}//end getall
		
		#endregion
				
		#region GetPaged Methods
				
		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">Number of rows in the DataSource.</param>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ClientAddress objects.</returns>
		public override TList<ClientAddress> GetPaged(TransactionManager transactionManager, string whereClause, string orderBy, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.sp_ClientAddress_GetPaged", _useStoredProcedure);
		
			
            if (commandWrapper.CommandType == CommandType.Text
                && commandWrapper.CommandText != null)
            {
                commandWrapper.CommandText = commandWrapper.CommandText.Replace(SqlUtil.PAGE_INDEX, string.Concat(SqlUtil.PAGE_INDEX, Guid.NewGuid().ToString("N").Substring(0, 8)));
            }
			
			database.AddInParameter(commandWrapper, "@WhereClause", DbType.String, whereClause);
			database.AddInParameter(commandWrapper, "@OrderBy", DbType.String, orderBy);
			database.AddInParameter(commandWrapper, "@PageIndex", DbType.Int32, start);
			database.AddInParameter(commandWrapper, "@PageSize", DbType.Int32, pageLength);
		
			IDataReader reader = null;
			//Create Collection
			TList<ClientAddress> rows = new TList<ClientAddress>();
			
			try
			{
				//Provider Data Requesting Command Event
				OnDataRequesting(new CommandEventArgs(commandWrapper, "GetPaged", rows)); 

				if (transactionManager != null)
				{
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}
				
				Fill(reader, rows, 0, int.MaxValue);
				count = rows.Count;

				if(reader.NextResult())
				{
					if(reader.Read())
					{
						count = reader.GetInt32(0);
					}
				}
				
				//Provider Data Requested Command Event
				OnDataRequested(new CommandEventArgs(commandWrapper, "GetPaged", rows)); 

			}
			catch(Exception)
			{			
				throw;
			}
			finally
			{
				if (reader != null) 
					reader.Close();
				
				commandWrapper = null;
			}
			
			return rows;
		}
		
		#endregion	
		
		#region Get By Foreign Key Functions
	#endregion
	
		#region Get By Index Functions

		#region GetByAddressId
					
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Users_Address index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_addressId"></param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ClientAddress"/> class.</returns>
		/// <remarks></remarks>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override Ekip.Framework.Entities.ClientAddress GetByAddressId(TransactionManager transactionManager, System.Int32 _addressId, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.sp_ClientAddress_GetByAddressId", _useStoredProcedure);
			
				database.AddInParameter(commandWrapper, "@AddressId", DbType.Int32, _addressId);
			
			IDataReader reader = null;
			TList<ClientAddress> tmp = new TList<ClientAddress>();
			try
			{
				//Provider Data Requesting Command Event
				OnDataRequesting(new CommandEventArgs(commandWrapper, "GetByAddressId", tmp)); 

				if (transactionManager != null)
				{
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}		
		
				//Create collection and fill
				Fill(reader, tmp, start, pageLength);
				count = -1;
				if(reader.NextResult())
				{
					if(reader.Read())
					{
						count = reader.GetInt32(0);
					}
				}
				
				//Provider Data Requested Command Event
				OnDataRequested(new CommandEventArgs(commandWrapper, "GetByAddressId", tmp));
			}
			finally 
			{
				if (reader != null) 
					reader.Close();
					
				commandWrapper = null;
			}
			
			if (tmp.Count == 1)
			{
				return tmp[0];
			}
			else if (tmp.Count == 0)
			{
				return null;
			}
			else
			{
				throw new DataException("Cannot find the unique instance of the class.");
			}
			
			//return rows;
		}
		
		#endregion

	#endregion Get By Index Functions

		#region Insert Methods
		/// <summary>
		/// Lets you efficiently bulk insert many entities to the database.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entities">The entities.</param>
		/// <remarks>
		///		After inserting into the datasource, the Ekip.Framework.Entities.ClientAddress object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>	
		public override void BulkInsert(TransactionManager transactionManager, TList<Ekip.Framework.Entities.ClientAddress> entities)
		{
			//System.Data.SqlClient.SqlBulkCopy bulkCopy = new System.Data.SqlClient.SqlBulkCopy(this._connectionString, System.Data.SqlClient.SqlBulkCopyOptions.CheckConstraints); //, null);
			
			System.Data.SqlClient.SqlBulkCopy bulkCopy = null;
	
			if (transactionManager != null && transactionManager.IsOpen)
			{			
				System.Data.SqlClient.SqlConnection cnx = transactionManager.TransactionObject.Connection as System.Data.SqlClient.SqlConnection;
				System.Data.SqlClient.SqlTransaction transaction = transactionManager.TransactionObject as System.Data.SqlClient.SqlTransaction;
				bulkCopy = new System.Data.SqlClient.SqlBulkCopy(cnx, System.Data.SqlClient.SqlBulkCopyOptions.CheckConstraints, transaction); //, null);
			}
			else
			{
				bulkCopy = new System.Data.SqlClient.SqlBulkCopy(this._connectionString, System.Data.SqlClient.SqlBulkCopyOptions.CheckConstraints); //, null);
			}
			
			bulkCopy.BulkCopyTimeout = 360;
			bulkCopy.DestinationTableName = "ClientAddress";
			
			DataTable dataTable = new DataTable();
			DataColumn col0 = dataTable.Columns.Add("AddressId", typeof(System.Int32));
			col0.AllowDBNull = false;		
			DataColumn col1 = dataTable.Columns.Add("TitleId", typeof(System.Byte));
			col1.AllowDBNull = false;		
			DataColumn col2 = dataTable.Columns.Add("AddressLine", typeof(System.String));
			col2.AllowDBNull = true;		
			DataColumn col3 = dataTable.Columns.Add("ProvinceId", typeof(System.Int32));
			col3.AllowDBNull = true;		
			DataColumn col4 = dataTable.Columns.Add("TownId", typeof(System.Int32));
			col4.AllowDBNull = true;		
			DataColumn col5 = dataTable.Columns.Add("NeighborhoodId", typeof(System.Int32));
			col5.AllowDBNull = true;		
			DataColumn col6 = dataTable.Columns.Add("StreetId", typeof(System.Int32));
			col6.AllowDBNull = true;		
			DataColumn col7 = dataTable.Columns.Add("Phone1", typeof(System.String));
			col7.AllowDBNull = true;		
			DataColumn col8 = dataTable.Columns.Add("Phone2", typeof(System.String));
			col8.AllowDBNull = true;		
			DataColumn col9 = dataTable.Columns.Add("Mobile", typeof(System.String));
			col9.AllowDBNull = true;		
			DataColumn col10 = dataTable.Columns.Add("IsUsed", typeof(System.Boolean));
			col10.AllowDBNull = false;		
			DataColumn col11 = dataTable.Columns.Add("CreateOn", typeof(System.DateTime));
			col11.AllowDBNull = false;		
			DataColumn col12 = dataTable.Columns.Add("UpdateOn", typeof(System.DateTime));
			col12.AllowDBNull = true;		
			DataColumn col13 = dataTable.Columns.Add("UserId", typeof(System.Int32));
			col13.AllowDBNull = false;		
			
			bulkCopy.ColumnMappings.Add("AddressId", "AddressId");
			bulkCopy.ColumnMappings.Add("TitleId", "TitleId");
			bulkCopy.ColumnMappings.Add("AddressLine", "AddressLine");
			bulkCopy.ColumnMappings.Add("ProvinceId", "ProvinceId");
			bulkCopy.ColumnMappings.Add("TownId", "TownId");
			bulkCopy.ColumnMappings.Add("NeighborhoodId", "NeighborhoodId");
			bulkCopy.ColumnMappings.Add("StreetId", "StreetId");
			bulkCopy.ColumnMappings.Add("Phone1", "Phone1");
			bulkCopy.ColumnMappings.Add("Phone2", "Phone2");
			bulkCopy.ColumnMappings.Add("Mobile", "Mobile");
			bulkCopy.ColumnMappings.Add("IsUsed", "IsUsed");
			bulkCopy.ColumnMappings.Add("CreateOn", "CreateOn");
			bulkCopy.ColumnMappings.Add("UpdateOn", "UpdateOn");
			bulkCopy.ColumnMappings.Add("UserId", "UserId");
			
			foreach(Ekip.Framework.Entities.ClientAddress entity in entities)
			{
				if (entity.EntityState != EntityState.Added)
					continue;
					
				DataRow row = dataTable.NewRow();
				
					row["AddressId"] = entity.AddressId;
							
				
					row["TitleId"] = entity.TitleId;
							
				
					row["AddressLine"] = entity.AddressLine;
							
				
					row["ProvinceId"] = entity.ProvinceId.HasValue ? (object) entity.ProvinceId  : System.DBNull.Value;
							
				
					row["TownId"] = entity.TownId.HasValue ? (object) entity.TownId  : System.DBNull.Value;
							
				
					row["NeighborhoodId"] = entity.NeighborhoodId.HasValue ? (object) entity.NeighborhoodId  : System.DBNull.Value;
							
				
					row["StreetId"] = entity.StreetId.HasValue ? (object) entity.StreetId  : System.DBNull.Value;
							
				
					row["Phone1"] = entity.Phone1;
							
				
					row["Phone2"] = entity.Phone2;
							
				
					row["Mobile"] = entity.Mobile;
							
				
					row["IsUsed"] = entity.IsUsed;
							
				
					row["CreateOn"] = entity.CreateOn;
							
				
					row["UpdateOn"] = entity.UpdateOn.HasValue ? (object) entity.UpdateOn  : System.DBNull.Value;
							
				
					row["UserId"] = entity.UserId;
							
				
				dataTable.Rows.Add(row);
			}		
			
			// send the data to the server		
			bulkCopy.WriteToServer(dataTable);		
			
			// update back the state
			foreach(Ekip.Framework.Entities.ClientAddress entity in entities)
			{
				if (entity.EntityState != EntityState.Added)
					continue;
			
				entity.AcceptChanges();
			}
		}
				
		/// <summary>
		/// 	Inserts a Ekip.Framework.Entities.ClientAddress object into the datasource using a transaction.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">Ekip.Framework.Entities.ClientAddress object to insert.</param>
		/// <remarks>
		///		After inserting into the datasource, the Ekip.Framework.Entities.ClientAddress object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>	
		/// <returns>Returns true if operation is successful.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override bool Insert(TransactionManager transactionManager, Ekip.Framework.Entities.ClientAddress entity)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.sp_ClientAddress_Insert", _useStoredProcedure);
			
			database.AddOutParameter(commandWrapper, "@AddressId", DbType.Int32, 4);
            database.AddInParameter(commandWrapper, "@TitleId", DbType.Byte, entity.TitleId );
            database.AddInParameter(commandWrapper, "@AddressLine", DbType.AnsiString, entity.AddressLine );
			database.AddInParameter(commandWrapper, "@ProvinceId", DbType.Int32, (entity.ProvinceId.HasValue ? (object) entity.ProvinceId  : System.DBNull.Value));
			database.AddInParameter(commandWrapper, "@TownId", DbType.Int32, (entity.TownId.HasValue ? (object) entity.TownId  : System.DBNull.Value));
			database.AddInParameter(commandWrapper, "@NeighborhoodId", DbType.Int32, (entity.NeighborhoodId.HasValue ? (object) entity.NeighborhoodId  : System.DBNull.Value));
			database.AddInParameter(commandWrapper, "@StreetId", DbType.Int32, (entity.StreetId.HasValue ? (object) entity.StreetId  : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@Phone1", DbType.AnsiString, entity.Phone1 );
            database.AddInParameter(commandWrapper, "@Phone2", DbType.AnsiString, entity.Phone2 );
            database.AddInParameter(commandWrapper, "@Mobile", DbType.AnsiString, entity.Mobile );
            database.AddInParameter(commandWrapper, "@IsUsed", DbType.Boolean, entity.IsUsed );
            database.AddInParameter(commandWrapper, "@CreateOn", DbType.DateTime, entity.CreateOn );
			database.AddInParameter(commandWrapper, "@UpdateOn", DbType.DateTime, (entity.UpdateOn.HasValue ? (object) entity.UpdateOn  : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@UserId", DbType.Int32, entity.UserId );
			
			int results = 0;
			
			//Provider Data Requesting Command Event
			OnDataRequesting(new CommandEventArgs(commandWrapper, "Insert", entity));
				
			if (transactionManager != null)
			{
				results = Utility.ExecuteNonQuery(transactionManager, commandWrapper);
			}
			else
			{
				results = Utility.ExecuteNonQuery(database,commandWrapper);
			}
					
			object _addressId = database.GetParameterValue(commandWrapper, "@AddressId");
			entity.AddressId = (System.Int32)_addressId;
			
			
			entity.AcceptChanges();
	
			//Provider Data Requested Command Event
			OnDataRequested(new CommandEventArgs(commandWrapper, "Insert", entity));

			return Convert.ToBoolean(results);
		}	
		#endregion

		#region Update Methods
				
		/// <summary>
		/// 	Update an existing row in the datasource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">Ekip.Framework.Entities.ClientAddress object to update.</param>
		/// <remarks>
		///		After updating the datasource, the Ekip.Framework.Entities.ClientAddress object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>
		/// <returns>Returns true if operation is successful.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override bool Update(TransactionManager transactionManager, Ekip.Framework.Entities.ClientAddress entity)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.sp_ClientAddress_Update", _useStoredProcedure);
			
            database.AddInParameter(commandWrapper, "@AddressId", DbType.Int32, entity.AddressId );
            database.AddInParameter(commandWrapper, "@TitleId", DbType.Byte, entity.TitleId );
            database.AddInParameter(commandWrapper, "@AddressLine", DbType.AnsiString, entity.AddressLine );
			database.AddInParameter(commandWrapper, "@ProvinceId", DbType.Int32, (entity.ProvinceId.HasValue ? (object) entity.ProvinceId : System.DBNull.Value) );
			database.AddInParameter(commandWrapper, "@TownId", DbType.Int32, (entity.TownId.HasValue ? (object) entity.TownId : System.DBNull.Value) );
			database.AddInParameter(commandWrapper, "@NeighborhoodId", DbType.Int32, (entity.NeighborhoodId.HasValue ? (object) entity.NeighborhoodId : System.DBNull.Value) );
			database.AddInParameter(commandWrapper, "@StreetId", DbType.Int32, (entity.StreetId.HasValue ? (object) entity.StreetId : System.DBNull.Value) );
            database.AddInParameter(commandWrapper, "@Phone1", DbType.AnsiString, entity.Phone1 );
            database.AddInParameter(commandWrapper, "@Phone2", DbType.AnsiString, entity.Phone2 );
            database.AddInParameter(commandWrapper, "@Mobile", DbType.AnsiString, entity.Mobile );
            database.AddInParameter(commandWrapper, "@IsUsed", DbType.Boolean, entity.IsUsed );
            database.AddInParameter(commandWrapper, "@CreateOn", DbType.DateTime, entity.CreateOn );
			database.AddInParameter(commandWrapper, "@UpdateOn", DbType.DateTime, (entity.UpdateOn.HasValue ? (object) entity.UpdateOn : System.DBNull.Value) );
            database.AddInParameter(commandWrapper, "@UserId", DbType.Int32, entity.UserId );
			
			int results = 0;
			
			//Provider Data Requesting Command Event
			OnDataRequesting(new CommandEventArgs(commandWrapper, "Update", entity));

			if (transactionManager != null)
			{
				results = Utility.ExecuteNonQuery(transactionManager, commandWrapper);
			}
			else
			{
				results = Utility.ExecuteNonQuery(database,commandWrapper);
			}
			
			//Stop Tracking Now that it has been updated and persisted.
			if (DataRepository.Provider.EnableEntityTracking)
            {
                EntityManager.StopTracking(entity.EntityTrackingKey);				
            }
			
			
			entity.AcceptChanges();
			
			//Provider Data Requested Command Event
			OnDataRequested(new CommandEventArgs(commandWrapper, "Update", entity));

			return Convert.ToBoolean(results);
		}
			
		#endregion
		
		#region Custom Methods
	

		#region ClientAddress_GetCurrentAddress
					
		/// <summary>
		///	This method wraps the 'ClientAddress_GetCurrentAddress' stored procedure. 
		/// </summary>	
		/// <param name="clientId"> A <c>System.Int32</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object.</param>
		/// <remark>This method is generated from a stored procedure.</remark>
		public override void GetCurrentAddress(TransactionManager transactionManager, int start, int pageLength , System.Int32 clientId)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.ClientAddress_GetCurrentAddress", true);
			
			database.AddInParameter(commandWrapper, "@ClientID", DbType.Int32,  clientId );
	
			
			//Provider Data Requesting Command Event
			OnDataRequesting(new CommandEventArgs(commandWrapper, "GetCurrentAddress", (IEntity)null));

			if (transactionManager != null)
			{	
				Utility.ExecuteNonQuery(transactionManager, commandWrapper );
			}
			else
			{
				Utility.ExecuteNonQuery(database, commandWrapper);
			}
						
			//Provider Data Requested Command Event
			OnDataRequested(new CommandEventArgs(commandWrapper, "GetCurrentAddress", (IEntity)null));


				
				return;
		}
		#endregion
		#endregion
	}//end class
} // end namespace
