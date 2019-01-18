﻿
/*
	File Generated by NetTiers templates [www.nettiers.net]
	Generated on : 15 Ocak 2019 Salı
	Important: Do not modify this file. Edit the file SqlClientEducationProvider.cs instead.
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
	/// This class is the SqlClient Data Access Logic Component implementation for the <see cref="ClientEducation"/> entity.
	///</summary>
	public abstract partial class SqlClientEducationProviderBase : ClientEducationProviderBase
	{
		#region Declarations
		
		string _connectionString;
	    bool _useStoredProcedure;
	    string _providerInvariantName;
			
		#endregion "Declarations"
			
		#region Constructors
		
		/// <summary>
		/// Creates a new <see cref="SqlClientEducationProviderBase"/> instance.
		/// </summary>
		public SqlClientEducationProviderBase()
		{
		}
	
	/// <summary>
	/// Creates a new <see cref="SqlClientEducationProviderBase"/> instance.
	/// Uses connection string to connect to datasource.
	/// </summary>
	/// <param name="connectionString">The connection string to the database.</param>
	/// <param name="useStoredProcedure">A boolean value that indicates if we should use stored procedures or embedded queries.</param>
	/// <param name="providerInvariantName">Name of the invariant provider use by the DbProviderFactory.</param>
	public SqlClientEducationProviderBase(string connectionString, bool useStoredProcedure, string providerInvariantName)
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
		/// <param name="_educationId">. Primary Key.</param>	
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override bool Delete(TransactionManager transactionManager, System.Int32 _educationId)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.sp_ClientEducation_Delete", _useStoredProcedure);
			database.AddInParameter(commandWrapper, "@EducationId", DbType.Int32, _educationId);
			
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
				string entityKey = EntityLocator.ConstructKeyFromPkItems(typeof(ClientEducation)
					,_educationId);
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
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ClientEducation objects.</returns>
		public override TList<ClientEducation> Find(TransactionManager transactionManager, string whereClause, int start, int pageLength, out int count)
		{
			count = -1;
			if (whereClause.IndexOf(";") > -1)
				return new TList<ClientEducation>();
	
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.sp_ClientEducation_Find", _useStoredProcedure);

		bool searchUsingOR = false;
		if (whereClause.IndexOf(" OR ") > 0) // did they want to do "a=b OR c=d OR..."?
			searchUsingOR = true;
		
		database.AddInParameter(commandWrapper, "@SearchUsingOR", DbType.Boolean, searchUsingOR);
		
		database.AddInParameter(commandWrapper, "@EducationId", DbType.Int32, DBNull.Value);
		database.AddInParameter(commandWrapper, "@ClientId", DbType.Int32, DBNull.Value);
		database.AddInParameter(commandWrapper, "@SchoolId", DbType.Int32, DBNull.Value);
		database.AddInParameter(commandWrapper, "@ClassRoom", DbType.AnsiString, DBNull.Value);
		database.AddInParameter(commandWrapper, "@TeacherId", DbType.Int32, DBNull.Value);
		database.AddInParameter(commandWrapper, "@Notes", DbType.AnsiString, DBNull.Value);
		database.AddInParameter(commandWrapper, "@CreateDate", DbType.DateTime, DBNull.Value);
		database.AddInParameter(commandWrapper, "@UpdateDate", DbType.DateTime, DBNull.Value);
		database.AddInParameter(commandWrapper, "@CreateUserId", DbType.Int32, DBNull.Value);
		database.AddInParameter(commandWrapper, "@UpdateUserId", DbType.Int32, DBNull.Value);
		database.AddInParameter(commandWrapper, "@Active", DbType.Boolean, DBNull.Value);
		database.AddInParameter(commandWrapper, "@Deleted", DbType.Boolean, DBNull.Value);
	
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
				if (clause.Trim().StartsWith("educationıd ") || clause.Trim().StartsWith("educationıd="))
				{
					database.SetParameterValue(commandWrapper, "@EducationId", 
						clause.Trim().Remove(0,11).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("clientıd ") || clause.Trim().StartsWith("clientıd="))
				{
					database.SetParameterValue(commandWrapper, "@ClientId", 
						clause.Trim().Remove(0,8).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("schoolıd ") || clause.Trim().StartsWith("schoolıd="))
				{
					database.SetParameterValue(commandWrapper, "@SchoolId", 
						clause.Trim().Remove(0,8).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("classroom ") || clause.Trim().StartsWith("classroom="))
				{
					database.SetParameterValue(commandWrapper, "@ClassRoom", 
						clause.Trim().Remove(0,9).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("teacherıd ") || clause.Trim().StartsWith("teacherıd="))
				{
					database.SetParameterValue(commandWrapper, "@TeacherId", 
						clause.Trim().Remove(0,9).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("notes ") || clause.Trim().StartsWith("notes="))
				{
					database.SetParameterValue(commandWrapper, "@Notes", 
						clause.Trim().Remove(0,5).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("createdate ") || clause.Trim().StartsWith("createdate="))
				{
					database.SetParameterValue(commandWrapper, "@CreateDate", 
						clause.Trim().Remove(0,10).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("updatedate ") || clause.Trim().StartsWith("updatedate="))
				{
					database.SetParameterValue(commandWrapper, "@UpdateDate", 
						clause.Trim().Remove(0,10).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("createuserıd ") || clause.Trim().StartsWith("createuserıd="))
				{
					database.SetParameterValue(commandWrapper, "@CreateUserId", 
						clause.Trim().Remove(0,12).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("updateuserıd ") || clause.Trim().StartsWith("updateuserıd="))
				{
					database.SetParameterValue(commandWrapper, "@UpdateUserId", 
						clause.Trim().Remove(0,12).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("active ") || clause.Trim().StartsWith("active="))
				{
					database.SetParameterValue(commandWrapper, "@Active", 
						clause.Trim().Remove(0,6).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("deleted ") || clause.Trim().StartsWith("deleted="))
				{
					database.SetParameterValue(commandWrapper, "@Deleted", 
						clause.Trim().Remove(0,7).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
	
				throw new ArgumentException("Unable to use this part of the where clause in this version of Find: " + clause);
			}
					
			IDataReader reader = null;
			//Create Collection
			TList<ClientEducation> rows = new TList<ClientEducation>();
	
				
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
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ClientEducation objects.</returns>
		public override TList<ClientEducation> Find(TransactionManager transactionManager, IFilterParameterCollection parameters, string orderBy, int start, int pageLength, out int count)
		{
			SqlFilterParameterCollection filter = null;
			
			if (parameters == null)
				filter = new SqlFilterParameterCollection();
			else 
				filter = parameters.GetParameters();
				
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.sp_ClientEducation_Find_Dynamic", typeof(ClientEducationColumn), filter, orderBy, start, pageLength);
		
			SqlFilterParameter param;

			for ( int i = 0; i < filter.Count; i++ )
			{
				param = filter[i];
				database.AddInParameter(commandWrapper, param.Name, param.DbType, param.GetValue());
			}

			TList<ClientEducation> rows = new TList<ClientEducation>();
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
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ClientEducation objects.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override TList<ClientEducation> GetAll(TransactionManager transactionManager, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.sp_ClientEducation_Get_List", _useStoredProcedure);
			
			IDataReader reader = null;
		
			//Create Collection
			TList<ClientEducation> rows = new TList<ClientEducation>();
			
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
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ClientEducation objects.</returns>
		public override TList<ClientEducation> GetPaged(TransactionManager transactionManager, string whereClause, string orderBy, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.sp_ClientEducation_GetPaged", _useStoredProcedure);
		
			
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
			TList<ClientEducation> rows = new TList<ClientEducation>();
			
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

		#region GetByClientId
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClientEducation_Client key.
		///		FK_ClientEducation_Client Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_clientId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ClientEducation objects.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override TList<ClientEducation> GetByClientId(TransactionManager transactionManager, System.Int32 _clientId, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.sp_ClientEducation_GetByClientId", _useStoredProcedure);
			
				database.AddInParameter(commandWrapper, "@ClientId", DbType.Int32, _clientId);
			
			IDataReader reader = null;
			TList<ClientEducation> rows = new TList<ClientEducation>();
			try
			{
				//Provider Data Requesting Command Event
				OnDataRequesting(new CommandEventArgs(commandWrapper, "GetByClientId", rows)); 

				if (transactionManager != null)
				{
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}
			
				//Create Collection
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
				OnDataRequested(new CommandEventArgs(commandWrapper, "GetByClientId", rows)); 
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
	

		#region GetBySchoolId
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClientEducation_School key.
		///		FK_ClientEducation_School Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_schoolId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.ClientEducation objects.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override TList<ClientEducation> GetBySchoolId(TransactionManager transactionManager, System.Int32 _schoolId, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.sp_ClientEducation_GetBySchoolId", _useStoredProcedure);
			
				database.AddInParameter(commandWrapper, "@SchoolId", DbType.Int32, _schoolId);
			
			IDataReader reader = null;
			TList<ClientEducation> rows = new TList<ClientEducation>();
			try
			{
				//Provider Data Requesting Command Event
				OnDataRequesting(new CommandEventArgs(commandWrapper, "GetBySchoolId", rows)); 

				if (transactionManager != null)
				{
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}
			
				//Create Collection
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
				OnDataRequested(new CommandEventArgs(commandWrapper, "GetBySchoolId", rows)); 
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
	
	#endregion
	
		#region Get By Index Functions

		#region GetByEducationId
					
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ClientEducation index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_educationId"></param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.ClientEducation"/> class.</returns>
		/// <remarks></remarks>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override Ekip.Framework.Entities.ClientEducation GetByEducationId(TransactionManager transactionManager, System.Int32 _educationId, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.sp_ClientEducation_GetByEducationId", _useStoredProcedure);
			
				database.AddInParameter(commandWrapper, "@EducationId", DbType.Int32, _educationId);
			
			IDataReader reader = null;
			TList<ClientEducation> tmp = new TList<ClientEducation>();
			try
			{
				//Provider Data Requesting Command Event
				OnDataRequesting(new CommandEventArgs(commandWrapper, "GetByEducationId", tmp)); 

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
				OnDataRequested(new CommandEventArgs(commandWrapper, "GetByEducationId", tmp));
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
		///		After inserting into the datasource, the Ekip.Framework.Entities.ClientEducation object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>	
		public override void BulkInsert(TransactionManager transactionManager, TList<Ekip.Framework.Entities.ClientEducation> entities)
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
			bulkCopy.DestinationTableName = "ClientEducation";
			
			DataTable dataTable = new DataTable();
			DataColumn col0 = dataTable.Columns.Add("EducationId", typeof(System.Int32));
			col0.AllowDBNull = false;		
			DataColumn col1 = dataTable.Columns.Add("ClientId", typeof(System.Int32));
			col1.AllowDBNull = false;		
			DataColumn col2 = dataTable.Columns.Add("SchoolId", typeof(System.Int32));
			col2.AllowDBNull = false;		
			DataColumn col3 = dataTable.Columns.Add("ClassRoom", typeof(System.String));
			col3.AllowDBNull = false;		
			DataColumn col4 = dataTable.Columns.Add("TeacherId", typeof(System.Int32));
			col4.AllowDBNull = true;		
			DataColumn col5 = dataTable.Columns.Add("Notes", typeof(System.String));
			col5.AllowDBNull = true;		
			DataColumn col6 = dataTable.Columns.Add("CreateDate", typeof(System.DateTime));
			col6.AllowDBNull = false;		
			DataColumn col7 = dataTable.Columns.Add("UpdateDate", typeof(System.DateTime));
			col7.AllowDBNull = true;		
			DataColumn col8 = dataTable.Columns.Add("CreateUserId", typeof(System.Int32));
			col8.AllowDBNull = false;		
			DataColumn col9 = dataTable.Columns.Add("UpdateUserId", typeof(System.Int32));
			col9.AllowDBNull = true;		
			DataColumn col10 = dataTable.Columns.Add("Active", typeof(System.Boolean));
			col10.AllowDBNull = false;		
			DataColumn col11 = dataTable.Columns.Add("Deleted", typeof(System.Boolean));
			col11.AllowDBNull = false;		
			
			bulkCopy.ColumnMappings.Add("EducationId", "EducationId");
			bulkCopy.ColumnMappings.Add("ClientId", "ClientId");
			bulkCopy.ColumnMappings.Add("SchoolId", "SchoolId");
			bulkCopy.ColumnMappings.Add("ClassRoom", "ClassRoom");
			bulkCopy.ColumnMappings.Add("TeacherId", "TeacherId");
			bulkCopy.ColumnMappings.Add("Notes", "Notes");
			bulkCopy.ColumnMappings.Add("CreateDate", "CreateDate");
			bulkCopy.ColumnMappings.Add("UpdateDate", "UpdateDate");
			bulkCopy.ColumnMappings.Add("CreateUserId", "CreateUserId");
			bulkCopy.ColumnMappings.Add("UpdateUserId", "UpdateUserId");
			bulkCopy.ColumnMappings.Add("Active", "Active");
			bulkCopy.ColumnMappings.Add("Deleted", "Deleted");
			
			foreach(Ekip.Framework.Entities.ClientEducation entity in entities)
			{
				if (entity.EntityState != EntityState.Added)
					continue;
					
				DataRow row = dataTable.NewRow();
				
					row["EducationId"] = entity.EducationId;
							
				
					row["ClientId"] = entity.ClientId;
							
				
					row["SchoolId"] = entity.SchoolId;
							
				
					row["ClassRoom"] = entity.ClassRoom;
							
				
					row["TeacherId"] = entity.TeacherId.HasValue ? (object) entity.TeacherId  : System.DBNull.Value;
							
				
					row["Notes"] = entity.Notes;
							
				
					row["CreateDate"] = entity.CreateDate;
							
				
					row["UpdateDate"] = entity.UpdateDate.HasValue ? (object) entity.UpdateDate  : System.DBNull.Value;
							
				
					row["CreateUserId"] = entity.CreateUserId;
							
				
					row["UpdateUserId"] = entity.UpdateUserId.HasValue ? (object) entity.UpdateUserId  : System.DBNull.Value;
							
				
					row["Active"] = entity.Active;
							
				
					row["Deleted"] = entity.Deleted;
							
				
				dataTable.Rows.Add(row);
			}		
			
			// send the data to the server		
			bulkCopy.WriteToServer(dataTable);		
			
			// update back the state
			foreach(Ekip.Framework.Entities.ClientEducation entity in entities)
			{
				if (entity.EntityState != EntityState.Added)
					continue;
			
				entity.AcceptChanges();
			}
		}
				
		/// <summary>
		/// 	Inserts a Ekip.Framework.Entities.ClientEducation object into the datasource using a transaction.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">Ekip.Framework.Entities.ClientEducation object to insert.</param>
		/// <remarks>
		///		After inserting into the datasource, the Ekip.Framework.Entities.ClientEducation object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>	
		/// <returns>Returns true if operation is successful.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override bool Insert(TransactionManager transactionManager, Ekip.Framework.Entities.ClientEducation entity)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.sp_ClientEducation_Insert", _useStoredProcedure);
			
			database.AddOutParameter(commandWrapper, "@EducationId", DbType.Int32, 4);
            database.AddInParameter(commandWrapper, "@ClientId", DbType.Int32, entity.ClientId );
            database.AddInParameter(commandWrapper, "@SchoolId", DbType.Int32, entity.SchoolId );
            database.AddInParameter(commandWrapper, "@ClassRoom", DbType.AnsiString, entity.ClassRoom );
			database.AddInParameter(commandWrapper, "@TeacherId", DbType.Int32, (entity.TeacherId.HasValue ? (object) entity.TeacherId  : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@Notes", DbType.AnsiString, entity.Notes );
            database.AddInParameter(commandWrapper, "@CreateDate", DbType.DateTime, entity.CreateDate );
			database.AddInParameter(commandWrapper, "@UpdateDate", DbType.DateTime, (entity.UpdateDate.HasValue ? (object) entity.UpdateDate  : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@CreateUserId", DbType.Int32, entity.CreateUserId );
			database.AddInParameter(commandWrapper, "@UpdateUserId", DbType.Int32, (entity.UpdateUserId.HasValue ? (object) entity.UpdateUserId  : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@Active", DbType.Boolean, entity.Active );
            database.AddInParameter(commandWrapper, "@Deleted", DbType.Boolean, entity.Deleted );
			
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
					
			object _educationId = database.GetParameterValue(commandWrapper, "@EducationId");
			entity.EducationId = (System.Int32)_educationId;
			
			
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
		/// <param name="entity">Ekip.Framework.Entities.ClientEducation object to update.</param>
		/// <remarks>
		///		After updating the datasource, the Ekip.Framework.Entities.ClientEducation object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>
		/// <returns>Returns true if operation is successful.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override bool Update(TransactionManager transactionManager, Ekip.Framework.Entities.ClientEducation entity)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.sp_ClientEducation_Update", _useStoredProcedure);
			
            database.AddInParameter(commandWrapper, "@EducationId", DbType.Int32, entity.EducationId );
            database.AddInParameter(commandWrapper, "@ClientId", DbType.Int32, entity.ClientId );
            database.AddInParameter(commandWrapper, "@SchoolId", DbType.Int32, entity.SchoolId );
            database.AddInParameter(commandWrapper, "@ClassRoom", DbType.AnsiString, entity.ClassRoom );
			database.AddInParameter(commandWrapper, "@TeacherId", DbType.Int32, (entity.TeacherId.HasValue ? (object) entity.TeacherId : System.DBNull.Value) );
            database.AddInParameter(commandWrapper, "@Notes", DbType.AnsiString, entity.Notes );
            database.AddInParameter(commandWrapper, "@CreateDate", DbType.DateTime, entity.CreateDate );
			database.AddInParameter(commandWrapper, "@UpdateDate", DbType.DateTime, (entity.UpdateDate.HasValue ? (object) entity.UpdateDate : System.DBNull.Value) );
            database.AddInParameter(commandWrapper, "@CreateUserId", DbType.Int32, entity.CreateUserId );
			database.AddInParameter(commandWrapper, "@UpdateUserId", DbType.Int32, (entity.UpdateUserId.HasValue ? (object) entity.UpdateUserId : System.DBNull.Value) );
            database.AddInParameter(commandWrapper, "@Active", DbType.Boolean, entity.Active );
            database.AddInParameter(commandWrapper, "@Deleted", DbType.Boolean, entity.Deleted );
			
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
	
		#endregion
	}//end class
} // end namespace