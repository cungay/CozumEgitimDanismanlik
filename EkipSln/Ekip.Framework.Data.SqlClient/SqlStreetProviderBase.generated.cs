﻿
/*
	File Generated by NetTiers templates [www.nettiers.net]
	Generated on : 6 Kasım 2018 Salı
	Important: Do not modify this file. Edit the file SqlStreetProvider.cs instead.
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
	/// This class is the SqlClient Data Access Logic Component implementation for the <see cref="Street"/> entity.
	///</summary>
	public abstract partial class SqlStreetProviderBase : StreetProviderBase
	{
		#region Declarations
		
		string _connectionString;
	    bool _useStoredProcedure;
	    string _providerInvariantName;
			
		#endregion "Declarations"
			
		#region Constructors
		
		/// <summary>
		/// Creates a new <see cref="SqlStreetProviderBase"/> instance.
		/// </summary>
		public SqlStreetProviderBase()
		{
		}
	
	/// <summary>
	/// Creates a new <see cref="SqlStreetProviderBase"/> instance.
	/// Uses connection string to connect to datasource.
	/// </summary>
	/// <param name="connectionString">The connection string to the database.</param>
	/// <param name="useStoredProcedure">A boolean value that indicates if we should use stored procedures or embedded queries.</param>
	/// <param name="providerInvariantName">Name of the invariant provider use by the DbProviderFactory.</param>
	public SqlStreetProviderBase(string connectionString, bool useStoredProcedure, string providerInvariantName)
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
		/// <param name="_ıd">. Primary Key.</param>	
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override bool Delete(TransactionManager transactionManager, System.Int32 _ıd)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.sp_Street_Delete", _useStoredProcedure);
			database.AddInParameter(commandWrapper, "@Id", DbType.Int32, _ıd);
			
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
				string entityKey = EntityLocator.ConstructKeyFromPkItems(typeof(Street)
					,_ıd);
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
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Street objects.</returns>
		public override TList<Street> Find(TransactionManager transactionManager, string whereClause, int start, int pageLength, out int count)
		{
			count = -1;
			if (whereClause.IndexOf(";") > -1)
				return new TList<Street>();
	
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.sp_Street_Find", _useStoredProcedure);

		bool searchUsingOR = false;
		if (whereClause.IndexOf(" OR ") > 0) // did they want to do "a=b OR c=d OR..."?
			searchUsingOR = true;
		
		database.AddInParameter(commandWrapper, "@SearchUsingOR", DbType.Boolean, searchUsingOR);
		
		database.AddInParameter(commandWrapper, "@Id", DbType.Int32, DBNull.Value);
		database.AddInParameter(commandWrapper, "@AdminId", DbType.Int64, DBNull.Value);
		database.AddInParameter(commandWrapper, "@ObjectId", DbType.Int64, DBNull.Value);
		database.AddInParameter(commandWrapper, "@RowNumber", DbType.Int32, DBNull.Value);
		database.AddInParameter(commandWrapper, "@NeighborhoodId", DbType.Int32, DBNull.Value);
		database.AddInParameter(commandWrapper, "@StreetName", DbType.String, DBNull.Value);
		database.AddInParameter(commandWrapper, "@Longitude", DbType.AnsiString, DBNull.Value);
		database.AddInParameter(commandWrapper, "@Latitude", DbType.AnsiString, DBNull.Value);
		database.AddInParameter(commandWrapper, "@ZipCode", DbType.AnsiString, DBNull.Value);
		database.AddInParameter(commandWrapper, "@CreateDate", DbType.Date, DBNull.Value);
		database.AddInParameter(commandWrapper, "@CreateTime", DbType.Time, DBNull.Value);
		database.AddInParameter(commandWrapper, "@UpdateDate", DbType.Date, DBNull.Value);
		database.AddInParameter(commandWrapper, "@UpdateTime", DbType.Time, DBNull.Value);
	
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
				if (clause.Trim().StartsWith("ıd ") || clause.Trim().StartsWith("ıd="))
				{
					database.SetParameterValue(commandWrapper, "@Id", 
						clause.Trim().Remove(0,2).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("adminıd ") || clause.Trim().StartsWith("adminıd="))
				{
					database.SetParameterValue(commandWrapper, "@AdminId", 
						clause.Trim().Remove(0,7).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("objectıd ") || clause.Trim().StartsWith("objectıd="))
				{
					database.SetParameterValue(commandWrapper, "@ObjectId", 
						clause.Trim().Remove(0,8).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("rownumber ") || clause.Trim().StartsWith("rownumber="))
				{
					database.SetParameterValue(commandWrapper, "@RowNumber", 
						clause.Trim().Remove(0,9).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("neighborhoodıd ") || clause.Trim().StartsWith("neighborhoodıd="))
				{
					database.SetParameterValue(commandWrapper, "@NeighborhoodId", 
						clause.Trim().Remove(0,14).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("streetname ") || clause.Trim().StartsWith("streetname="))
				{
					database.SetParameterValue(commandWrapper, "@StreetName", 
						clause.Trim().Remove(0,10).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("longitude ") || clause.Trim().StartsWith("longitude="))
				{
					database.SetParameterValue(commandWrapper, "@Longitude", 
						clause.Trim().Remove(0,9).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("latitude ") || clause.Trim().StartsWith("latitude="))
				{
					database.SetParameterValue(commandWrapper, "@Latitude", 
						clause.Trim().Remove(0,8).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("zipcode ") || clause.Trim().StartsWith("zipcode="))
				{
					database.SetParameterValue(commandWrapper, "@ZipCode", 
						clause.Trim().Remove(0,7).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("createdate ") || clause.Trim().StartsWith("createdate="))
				{
					database.SetParameterValue(commandWrapper, "@CreateDate", 
						clause.Trim().Remove(0,10).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("createtime ") || clause.Trim().StartsWith("createtime="))
				{
					database.SetParameterValue(commandWrapper, "@CreateTime", 
						clause.Trim().Remove(0,10).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("updatedate ") || clause.Trim().StartsWith("updatedate="))
				{
					database.SetParameterValue(commandWrapper, "@UpdateDate", 
						clause.Trim().Remove(0,10).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("updatetime ") || clause.Trim().StartsWith("updatetime="))
				{
					database.SetParameterValue(commandWrapper, "@UpdateTime", 
						clause.Trim().Remove(0,10).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
	
				throw new ArgumentException("Unable to use this part of the where clause in this version of Find: " + clause);
			}
					
			IDataReader reader = null;
			//Create Collection
			TList<Street> rows = new TList<Street>();
	
				
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
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Street objects.</returns>
		public override TList<Street> Find(TransactionManager transactionManager, IFilterParameterCollection parameters, string orderBy, int start, int pageLength, out int count)
		{
			SqlFilterParameterCollection filter = null;
			
			if (parameters == null)
				filter = new SqlFilterParameterCollection();
			else 
				filter = parameters.GetParameters();
				
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.sp_Street_Find_Dynamic", typeof(StreetColumn), filter, orderBy, start, pageLength);
		
			SqlFilterParameter param;

			for ( int i = 0; i < filter.Count; i++ )
			{
				param = filter[i];
				database.AddInParameter(commandWrapper, param.Name, param.DbType, param.GetValue());
			}

			TList<Street> rows = new TList<Street>();
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
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Street objects.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override TList<Street> GetAll(TransactionManager transactionManager, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.sp_Street_Get_List", _useStoredProcedure);
			
			IDataReader reader = null;
		
			//Create Collection
			TList<Street> rows = new TList<Street>();
			
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
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.Street objects.</returns>
		public override TList<Street> GetPaged(TransactionManager transactionManager, string whereClause, string orderBy, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.sp_Street_GetPaged", _useStoredProcedure);
		
			
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
			TList<Street> rows = new TList<Street>();
			
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

		#region GetByNeighborhoodId
					
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Street index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_neighborhoodId"></param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Street&gt;"/> class.</returns>
		/// <remarks></remarks>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override TList<Street> GetByNeighborhoodId(TransactionManager transactionManager, System.Int32 _neighborhoodId, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.sp_Street_GetByNeighborhoodId", _useStoredProcedure);
			
				database.AddInParameter(commandWrapper, "@NeighborhoodId", DbType.Int32, _neighborhoodId);
			
			IDataReader reader = null;
			TList<Street> tmp = new TList<Street>();
			try
			{
				//Provider Data Requesting Command Event
				OnDataRequesting(new CommandEventArgs(commandWrapper, "GetByNeighborhoodId", tmp)); 

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
				OnDataRequested(new CommandEventArgs(commandWrapper, "GetByNeighborhoodId", tmp));
			}
			finally 
			{
				if (reader != null) 
					reader.Close();
					
				commandWrapper = null;
			}
			
			return tmp;
			
			//return rows;
		}
		
		#endregion


		#region GetById
					
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Street index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_ıd"></param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Street"/> class.</returns>
		/// <remarks></remarks>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override Ekip.Framework.Entities.Street GetById(TransactionManager transactionManager, System.Int32 _ıd, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.sp_Street_GetById", _useStoredProcedure);
			
				database.AddInParameter(commandWrapper, "@Id", DbType.Int32, _ıd);
			
			IDataReader reader = null;
			TList<Street> tmp = new TList<Street>();
			try
			{
				//Provider Data Requesting Command Event
				OnDataRequesting(new CommandEventArgs(commandWrapper, "GetById", tmp)); 

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
				OnDataRequested(new CommandEventArgs(commandWrapper, "GetById", tmp));
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
		///		After inserting into the datasource, the Ekip.Framework.Entities.Street object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>	
		public override void BulkInsert(TransactionManager transactionManager, TList<Ekip.Framework.Entities.Street> entities)
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
			bulkCopy.DestinationTableName = "Street";
			
			DataTable dataTable = new DataTable();
			DataColumn col0 = dataTable.Columns.Add("Id", typeof(System.Int32));
			col0.AllowDBNull = false;		
			DataColumn col1 = dataTable.Columns.Add("AdminId", typeof(System.Int64));
			col1.AllowDBNull = false;		
			DataColumn col2 = dataTable.Columns.Add("ObjectId", typeof(System.Int64));
			col2.AllowDBNull = false;		
			DataColumn col3 = dataTable.Columns.Add("RowNumber", typeof(System.Int32));
			col3.AllowDBNull = false;		
			DataColumn col4 = dataTable.Columns.Add("NeighborhoodId", typeof(System.Int32));
			col4.AllowDBNull = false;		
			DataColumn col5 = dataTable.Columns.Add("StreetName", typeof(System.String));
			col5.AllowDBNull = false;		
			DataColumn col6 = dataTable.Columns.Add("Longitude", typeof(System.String));
			col6.AllowDBNull = false;		
			DataColumn col7 = dataTable.Columns.Add("Latitude", typeof(System.String));
			col7.AllowDBNull = false;		
			DataColumn col8 = dataTable.Columns.Add("ZipCode", typeof(System.String));
			col8.AllowDBNull = false;		
			DataColumn col9 = dataTable.Columns.Add("CreateDate", typeof(System.DateTime));
			col9.AllowDBNull = false;		
			DataColumn col10 = dataTable.Columns.Add("CreateTime", typeof(System.TimeSpan));
			col10.AllowDBNull = false;		
			DataColumn col11 = dataTable.Columns.Add("UpdateDate", typeof(System.DateTime));
			col11.AllowDBNull = true;		
			DataColumn col12 = dataTable.Columns.Add("UpdateTime", typeof(System.TimeSpan));
			col12.AllowDBNull = true;		
			
			bulkCopy.ColumnMappings.Add("Id", "Id");
			bulkCopy.ColumnMappings.Add("AdminId", "AdminId");
			bulkCopy.ColumnMappings.Add("ObjectId", "ObjectId");
			bulkCopy.ColumnMappings.Add("RowNumber", "RowNumber");
			bulkCopy.ColumnMappings.Add("NeighborhoodId", "NeighborhoodId");
			bulkCopy.ColumnMappings.Add("StreetName", "StreetName");
			bulkCopy.ColumnMappings.Add("Longitude", "Longitude");
			bulkCopy.ColumnMappings.Add("Latitude", "Latitude");
			bulkCopy.ColumnMappings.Add("ZipCode", "ZipCode");
			bulkCopy.ColumnMappings.Add("CreateDate", "CreateDate");
			bulkCopy.ColumnMappings.Add("CreateTime", "CreateTime");
			bulkCopy.ColumnMappings.Add("UpdateDate", "UpdateDate");
			bulkCopy.ColumnMappings.Add("UpdateTime", "UpdateTime");
			
			foreach(Ekip.Framework.Entities.Street entity in entities)
			{
				if (entity.EntityState != EntityState.Added)
					continue;
					
				DataRow row = dataTable.NewRow();
				
					row["Id"] = entity.Id;
							
				
					row["AdminId"] = entity.AdminId;
							
				
					row["ObjectId"] = entity.ObjectId;
							
				
					row["RowNumber"] = entity.RowNumber;
							
				
					row["NeighborhoodId"] = entity.NeighborhoodId;
							
				
					row["StreetName"] = entity.StreetName;
							
				
					row["Longitude"] = entity.Longitude;
							
				
					row["Latitude"] = entity.Latitude;
							
				
					row["ZipCode"] = entity.ZipCode;
							
				
					row["CreateDate"] = entity.CreateDate;
							
				
					row["CreateTime"] = entity.CreateTime;
							
				
					row["UpdateDate"] = entity.UpdateDate.HasValue ? (object) entity.UpdateDate  : System.DBNull.Value;
							
				
					row["UpdateTime"] = entity.UpdateTime.HasValue ? (object) entity.UpdateTime  : System.DBNull.Value;
							
				
				dataTable.Rows.Add(row);
			}		
			
			// send the data to the server		
			bulkCopy.WriteToServer(dataTable);		
			
			// update back the state
			foreach(Ekip.Framework.Entities.Street entity in entities)
			{
				if (entity.EntityState != EntityState.Added)
					continue;
			
				entity.AcceptChanges();
			}
		}
				
		/// <summary>
		/// 	Inserts a Ekip.Framework.Entities.Street object into the datasource using a transaction.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">Ekip.Framework.Entities.Street object to insert.</param>
		/// <remarks>
		///		After inserting into the datasource, the Ekip.Framework.Entities.Street object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>	
		/// <returns>Returns true if operation is successful.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override bool Insert(TransactionManager transactionManager, Ekip.Framework.Entities.Street entity)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.sp_Street_Insert", _useStoredProcedure);
			
			database.AddOutParameter(commandWrapper, "@Id", DbType.Int32, 4);
            database.AddInParameter(commandWrapper, "@AdminId", DbType.Int64, entity.AdminId );
            database.AddInParameter(commandWrapper, "@ObjectId", DbType.Int64, entity.ObjectId );
            database.AddInParameter(commandWrapper, "@RowNumber", DbType.Int32, entity.RowNumber );
            database.AddInParameter(commandWrapper, "@NeighborhoodId", DbType.Int32, entity.NeighborhoodId );
            database.AddInParameter(commandWrapper, "@StreetName", DbType.String, entity.StreetName );
            database.AddInParameter(commandWrapper, "@Longitude", DbType.AnsiString, entity.Longitude );
            database.AddInParameter(commandWrapper, "@Latitude", DbType.AnsiString, entity.Latitude );
            database.AddInParameter(commandWrapper, "@ZipCode", DbType.AnsiString, entity.ZipCode );
            database.AddInParameter(commandWrapper, "@CreateDate", DbType.Date, entity.CreateDate );
            database.AddInParameter(commandWrapper, "@CreateTime", SqlDbType.Time, entity.CreateTime );
			database.AddInParameter(commandWrapper, "@UpdateDate", DbType.Date, (entity.UpdateDate.HasValue ? (object) entity.UpdateDate  : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@UpdateTime", SqlDbType.Time, (entity.UpdateTime.HasValue ? (object) entity.UpdateTime  : System.DBNull.Value));
			
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
					
			object _ıd = database.GetParameterValue(commandWrapper, "@Id");
			entity.Id = (System.Int32)_ıd;
			
			
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
		/// <param name="entity">Ekip.Framework.Entities.Street object to update.</param>
		/// <remarks>
		///		After updating the datasource, the Ekip.Framework.Entities.Street object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>
		/// <returns>Returns true if operation is successful.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override bool Update(TransactionManager transactionManager, Ekip.Framework.Entities.Street entity)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.sp_Street_Update", _useStoredProcedure);
			
            database.AddInParameter(commandWrapper, "@Id", DbType.Int32, entity.Id );
            database.AddInParameter(commandWrapper, "@AdminId", DbType.Int64, entity.AdminId );
            database.AddInParameter(commandWrapper, "@ObjectId", DbType.Int64, entity.ObjectId );
            database.AddInParameter(commandWrapper, "@RowNumber", DbType.Int32, entity.RowNumber );
            database.AddInParameter(commandWrapper, "@NeighborhoodId", DbType.Int32, entity.NeighborhoodId );
            database.AddInParameter(commandWrapper, "@StreetName", DbType.String, entity.StreetName );
            database.AddInParameter(commandWrapper, "@Longitude", DbType.AnsiString, entity.Longitude );
            database.AddInParameter(commandWrapper, "@Latitude", DbType.AnsiString, entity.Latitude );
            database.AddInParameter(commandWrapper, "@ZipCode", DbType.AnsiString, entity.ZipCode );
            database.AddInParameter(commandWrapper, "@CreateDate", DbType.Date, entity.CreateDate );
            database.AddInParameter(commandWrapper, "@CreateTime", SqlDbType.Time, entity.CreateTime );
			database.AddInParameter(commandWrapper, "@UpdateDate", DbType.Date, (entity.UpdateDate.HasValue ? (object) entity.UpdateDate : System.DBNull.Value) );
            database.AddInParameter(commandWrapper, "@UpdateTime", SqlDbType.Time, (entity.UpdateTime.HasValue ? (object) entity.UpdateTime : System.DBNull.Value) );
			
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
	

		#region Street_GetByNeighborhoodId
					
		/// <summary>
		///	This method wraps the 'Street_GetByNeighborhoodId' stored procedure. 
		/// </summary>	
		/// <param name="neighborhoodId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object.</param>
		/// <remark>This method is generated from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Street&gt;"/> instance.</returns>
		public override TList<Street> GetByNeighborhoodId(TransactionManager transactionManager, int start, int pageLength , System.Int32? neighborhoodId)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.Street_GetByNeighborhoodId", true);
			
			database.AddInParameter(commandWrapper, "@NeighborhoodId", DbType.Int32,  neighborhoodId );
	
			
			IDataReader reader = null;
			
			//Create Collection
				TList<Street> rows = new TList<Street>();
				//Provider Data Requesting Command Event
				OnDataRequesting(new CommandEventArgs(commandWrapper, "GetByNeighborhoodId", rows));
	
				if (transactionManager != null)
				{	
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}	
				
				try
				{    
					Fill(reader, rows, start, pageLength);
				}
				finally
				{
					if (reader != null) 
						reader.Close();
				}
				
				//Provider Data Requested Command Event
				OnDataRequested(new CommandEventArgs(commandWrapper, "GetByNeighborhoodId", rows));


				return rows;
		}
		#endregion
		#endregion
	}//end class
} // end namespace
