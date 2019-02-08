﻿
/*
	File Generated by NetTiers templates [www.nettiers.net]
	Generated on : 5 Şubat 2019 Salı
	Important: Do not modify this file. Edit the file SqlQuestionFormProvider.cs instead.
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
	/// This class is the SqlClient Data Access Logic Component implementation for the <see cref="QuestionForm"/> entity.
	///</summary>
	public abstract partial class SqlQuestionFormProviderBase : QuestionFormProviderBase
	{
		#region Declarations
		
		string _connectionString;
	    bool _useStoredProcedure;
	    string _providerInvariantName;
			
		#endregion "Declarations"
			
		#region Constructors
		
		/// <summary>
		/// Creates a new <see cref="SqlQuestionFormProviderBase"/> instance.
		/// </summary>
		public SqlQuestionFormProviderBase()
		{
		}
	
	/// <summary>
	/// Creates a new <see cref="SqlQuestionFormProviderBase"/> instance.
	/// Uses connection string to connect to datasource.
	/// </summary>
	/// <param name="connectionString">The connection string to the database.</param>
	/// <param name="useStoredProcedure">A boolean value that indicates if we should use stored procedures or embedded queries.</param>
	/// <param name="providerInvariantName">Name of the invariant provider use by the DbProviderFactory.</param>
	public SqlQuestionFormProviderBase(string connectionString, bool useStoredProcedure, string providerInvariantName)
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
		/// <param name="_questionId">. Primary Key.</param>	
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override bool Delete(TransactionManager transactionManager, System.Int32 _questionId)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.sp_QuestionForm_Delete", _useStoredProcedure);
			database.AddInParameter(commandWrapper, "@QuestionId", DbType.Int32, _questionId);
			
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
				string entityKey = EntityLocator.ConstructKeyFromPkItems(typeof(QuestionForm)
					,_questionId);
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
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.QuestionForm objects.</returns>
		public override TList<QuestionForm> Find(TransactionManager transactionManager, string whereClause, int start, int pageLength, out int count)
		{
			count = -1;
			if (whereClause.IndexOf(";") > -1)
				return new TList<QuestionForm>();
	
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.sp_QuestionForm_Find", _useStoredProcedure);

		bool searchUsingOR = false;
		if (whereClause.IndexOf(" OR ") > 0) // did they want to do "a=b OR c=d OR..."?
			searchUsingOR = true;
		
		database.AddInParameter(commandWrapper, "@SearchUsingOR", DbType.Boolean, searchUsingOR);
		
		database.AddInParameter(commandWrapper, "@QuestionId", DbType.Int32, DBNull.Value);
		database.AddInParameter(commandWrapper, "@GroupId", DbType.Int32, DBNull.Value);
		database.AddInParameter(commandWrapper, "@QuestionRef", DbType.AnsiString, DBNull.Value);
		database.AddInParameter(commandWrapper, "@QuestionName", DbType.AnsiString, DBNull.Value);
		database.AddInParameter(commandWrapper, "@LineNumber", DbType.Int32, DBNull.Value);
		database.AddInParameter(commandWrapper, "@Status", DbType.Boolean, DBNull.Value);
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
				if (clause.Trim().StartsWith("questionıd ") || clause.Trim().StartsWith("questionıd="))
				{
					database.SetParameterValue(commandWrapper, "@QuestionId", 
						clause.Trim().Remove(0,10).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("groupıd ") || clause.Trim().StartsWith("groupıd="))
				{
					database.SetParameterValue(commandWrapper, "@GroupId", 
						clause.Trim().Remove(0,7).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("questionref ") || clause.Trim().StartsWith("questionref="))
				{
					database.SetParameterValue(commandWrapper, "@QuestionRef", 
						clause.Trim().Remove(0,11).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("questionname ") || clause.Trim().StartsWith("questionname="))
				{
					database.SetParameterValue(commandWrapper, "@QuestionName", 
						clause.Trim().Remove(0,12).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("linenumber ") || clause.Trim().StartsWith("linenumber="))
				{
					database.SetParameterValue(commandWrapper, "@LineNumber", 
						clause.Trim().Remove(0,10).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("status ") || clause.Trim().StartsWith("status="))
				{
					database.SetParameterValue(commandWrapper, "@Status", 
						clause.Trim().Remove(0,6).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
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
			TList<QuestionForm> rows = new TList<QuestionForm>();
	
				
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
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.QuestionForm objects.</returns>
		public override TList<QuestionForm> Find(TransactionManager transactionManager, IFilterParameterCollection parameters, string orderBy, int start, int pageLength, out int count)
		{
			SqlFilterParameterCollection filter = null;
			
			if (parameters == null)
				filter = new SqlFilterParameterCollection();
			else 
				filter = parameters.GetParameters();
				
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.sp_QuestionForm_Find_Dynamic", typeof(QuestionFormColumn), filter, orderBy, start, pageLength);
		
			SqlFilterParameter param;

			for ( int i = 0; i < filter.Count; i++ )
			{
				param = filter[i];
				database.AddInParameter(commandWrapper, param.Name, param.DbType, param.GetValue());
			}

			TList<QuestionForm> rows = new TList<QuestionForm>();
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
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.QuestionForm objects.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override TList<QuestionForm> GetAll(TransactionManager transactionManager, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.sp_QuestionForm_Get_List", _useStoredProcedure);
			
			IDataReader reader = null;
		
			//Create Collection
			TList<QuestionForm> rows = new TList<QuestionForm>();
			
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
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.QuestionForm objects.</returns>
		public override TList<QuestionForm> GetPaged(TransactionManager transactionManager, string whereClause, string orderBy, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.sp_QuestionForm_GetPaged", _useStoredProcedure);
		
			
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
			TList<QuestionForm> rows = new TList<QuestionForm>();
			
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

		#region GetByGroupId
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QuestionForm_QuestionForm_Group key.
		///		FK_QuestionForm_QuestionForm_Group Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_groupId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Ekip.Framework.Entities.QuestionForm objects.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override TList<QuestionForm> GetByGroupId(TransactionManager transactionManager, System.Int32? _groupId, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.sp_QuestionForm_GetByGroupId", _useStoredProcedure);
			
				database.AddInParameter(commandWrapper, "@GroupId", DbType.Int32, _groupId);
			
			IDataReader reader = null;
			TList<QuestionForm> rows = new TList<QuestionForm>();
			try
			{
				//Provider Data Requesting Command Event
				OnDataRequesting(new CommandEventArgs(commandWrapper, "GetByGroupId", rows)); 

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
				OnDataRequested(new CommandEventArgs(commandWrapper, "GetByGroupId", rows)); 
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

		#region GetByQuestionId
					
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_QuestionForm index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_questionId"></param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.QuestionForm"/> class.</returns>
		/// <remarks></remarks>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override Ekip.Framework.Entities.QuestionForm GetByQuestionId(TransactionManager transactionManager, System.Int32 _questionId, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.sp_QuestionForm_GetByQuestionId", _useStoredProcedure);
			
				database.AddInParameter(commandWrapper, "@QuestionId", DbType.Int32, _questionId);
			
			IDataReader reader = null;
			TList<QuestionForm> tmp = new TList<QuestionForm>();
			try
			{
				//Provider Data Requesting Command Event
				OnDataRequesting(new CommandEventArgs(commandWrapper, "GetByQuestionId", tmp)); 

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
				OnDataRequested(new CommandEventArgs(commandWrapper, "GetByQuestionId", tmp));
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
		///		After inserting into the datasource, the Ekip.Framework.Entities.QuestionForm object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>	
		public override void BulkInsert(TransactionManager transactionManager, TList<Ekip.Framework.Entities.QuestionForm> entities)
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
			bulkCopy.DestinationTableName = "QuestionForm";
			
			DataTable dataTable = new DataTable();
			DataColumn col0 = dataTable.Columns.Add("QuestionId", typeof(System.Int32));
			col0.AllowDBNull = false;		
			DataColumn col1 = dataTable.Columns.Add("GroupId", typeof(System.Int32));
			col1.AllowDBNull = true;		
			DataColumn col2 = dataTable.Columns.Add("QuestionRef", typeof(System.String));
			col2.AllowDBNull = true;		
			DataColumn col3 = dataTable.Columns.Add("QuestionName", typeof(System.String));
			col3.AllowDBNull = false;		
			DataColumn col4 = dataTable.Columns.Add("LineNumber", typeof(System.Int32));
			col4.AllowDBNull = false;		
			DataColumn col5 = dataTable.Columns.Add("Status", typeof(System.Boolean));
			col5.AllowDBNull = false;		
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
			
			bulkCopy.ColumnMappings.Add("QuestionId", "QuestionId");
			bulkCopy.ColumnMappings.Add("GroupId", "GroupId");
			bulkCopy.ColumnMappings.Add("QuestionRef", "QuestionRef");
			bulkCopy.ColumnMappings.Add("QuestionName", "QuestionName");
			bulkCopy.ColumnMappings.Add("LineNumber", "LineNumber");
			bulkCopy.ColumnMappings.Add("Status", "Status");
			bulkCopy.ColumnMappings.Add("CreateDate", "CreateDate");
			bulkCopy.ColumnMappings.Add("UpdateDate", "UpdateDate");
			bulkCopy.ColumnMappings.Add("CreateUserId", "CreateUserId");
			bulkCopy.ColumnMappings.Add("UpdateUserId", "UpdateUserId");
			bulkCopy.ColumnMappings.Add("Active", "Active");
			bulkCopy.ColumnMappings.Add("Deleted", "Deleted");
			
			foreach(Ekip.Framework.Entities.QuestionForm entity in entities)
			{
				if (entity.EntityState != EntityState.Added)
					continue;
					
				DataRow row = dataTable.NewRow();
				
					row["QuestionId"] = entity.QuestionId;
							
				
					row["GroupId"] = entity.GroupId.HasValue ? (object) entity.GroupId  : System.DBNull.Value;
							
				
					row["QuestionRef"] = entity.QuestionRef;
							
				
					row["QuestionName"] = entity.QuestionName;
							
				
					row["LineNumber"] = entity.LineNumber;
							
				
					row["Status"] = entity.Status;
							
				
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
			foreach(Ekip.Framework.Entities.QuestionForm entity in entities)
			{
				if (entity.EntityState != EntityState.Added)
					continue;
			
				entity.AcceptChanges();
			}
		}
				
		/// <summary>
		/// 	Inserts a Ekip.Framework.Entities.QuestionForm object into the datasource using a transaction.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">Ekip.Framework.Entities.QuestionForm object to insert.</param>
		/// <remarks>
		///		After inserting into the datasource, the Ekip.Framework.Entities.QuestionForm object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>	
		/// <returns>Returns true if operation is successful.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override bool Insert(TransactionManager transactionManager, Ekip.Framework.Entities.QuestionForm entity)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.sp_QuestionForm_Insert", _useStoredProcedure);
			
			database.AddOutParameter(commandWrapper, "@QuestionId", DbType.Int32, 4);
			database.AddInParameter(commandWrapper, "@GroupId", DbType.Int32, (entity.GroupId.HasValue ? (object) entity.GroupId  : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@QuestionRef", DbType.AnsiString, entity.QuestionRef );
            database.AddInParameter(commandWrapper, "@QuestionName", DbType.AnsiString, entity.QuestionName );
            database.AddInParameter(commandWrapper, "@LineNumber", DbType.Int32, entity.LineNumber );
            database.AddInParameter(commandWrapper, "@Status", DbType.Boolean, entity.Status );
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
					
			object _questionId = database.GetParameterValue(commandWrapper, "@QuestionId");
			entity.QuestionId = (System.Int32)_questionId;
			
			
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
		/// <param name="entity">Ekip.Framework.Entities.QuestionForm object to update.</param>
		/// <remarks>
		///		After updating the datasource, the Ekip.Framework.Entities.QuestionForm object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>
		/// <returns>Returns true if operation is successful.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override bool Update(TransactionManager transactionManager, Ekip.Framework.Entities.QuestionForm entity)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.sp_QuestionForm_Update", _useStoredProcedure);
			
            database.AddInParameter(commandWrapper, "@QuestionId", DbType.Int32, entity.QuestionId );
			database.AddInParameter(commandWrapper, "@GroupId", DbType.Int32, (entity.GroupId.HasValue ? (object) entity.GroupId : System.DBNull.Value) );
            database.AddInParameter(commandWrapper, "@QuestionRef", DbType.AnsiString, entity.QuestionRef );
            database.AddInParameter(commandWrapper, "@QuestionName", DbType.AnsiString, entity.QuestionName );
            database.AddInParameter(commandWrapper, "@LineNumber", DbType.Int32, entity.LineNumber );
            database.AddInParameter(commandWrapper, "@Status", DbType.Boolean, entity.Status );
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
