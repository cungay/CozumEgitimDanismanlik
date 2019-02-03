
#region Using directives

using System;
using System.Collections;
using System.Collections.Specialized;


using System.Web.Configuration;
using System.Data;
using System.Data.Common;
using System.Configuration.Provider;

using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using Ekip.Framework.Entities;
using Ekip.Framework.Data;
using Ekip.Framework.Data.Bases;

#endregion

namespace Ekip.Framework.Data.SqlClient
{
	/// <summary>
	/// This class is the Sql implementation of the NetTiersProvider.
	/// </summary>
	public sealed class SqlNetTiersProvider : Ekip.Framework.Data.Bases.NetTiersProvider
	{
		private static object syncRoot = new Object();
		private string _applicationName;
        private string _connectionString;
        private bool _useStoredProcedure;
        string _providerInvariantName;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="SqlNetTiersProvider"/> class.
		///</summary>
		public SqlNetTiersProvider()
		{	
		}		
		
		/// <summary>
        /// Initializes the provider.
        /// </summary>
        /// <param name="name">The friendly name of the provider.</param>
        /// <param name="config">A collection of the name/value pairs representing the provider-specific attributes specified in the configuration for this provider.</param>
        /// <exception cref="T:System.ArgumentNullException">The name of the provider is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">An attempt is made to call <see cref="M:System.Configuration.Provider.ProviderBase.Initialize(System.String,System.Collections.Specialized.NameValueCollection)"></see> on a provider after the provider has already been initialized.</exception>
        /// <exception cref="T:System.ArgumentException">The name of the provider has a length of zero.</exception>
		public override void Initialize(string name, NameValueCollection config)
        {
            // Verify that config isn't null
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }

            // Assign the provider a default name if it doesn't have one
            if (String.IsNullOrEmpty(name))
            {
                name = "SqlNetTiersProvider";
            }

            // Add a default "description" attribute to config if the
            // attribute doesn't exist or is empty
            if (string.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "NetTiers Sql provider");
            }

            // Call the base class's Initialize method
            base.Initialize(name, config);

            // Initialize _applicationName
            _applicationName = config["applicationName"];

            if (string.IsNullOrEmpty(_applicationName))
            {
                _applicationName = "/";
            }
            config.Remove("applicationName");


            #region "Initialize UseStoredProcedure"
            string storedProcedure  = config["useStoredProcedure"];
           	if (string.IsNullOrEmpty(storedProcedure))
            {
                throw new ProviderException("Empty or missing useStoredProcedure");
            }
            this._useStoredProcedure = Convert.ToBoolean(config["useStoredProcedure"]);
            config.Remove("useStoredProcedure");
            #endregion

			#region ConnectionString

			// Initialize _connectionString
			_connectionString = config["connectionString"];
			config.Remove("connectionString");

			string connect = config["connectionStringName"];
			config.Remove("connectionStringName");

			if ( String.IsNullOrEmpty(_connectionString) )
			{
				if ( String.IsNullOrEmpty(connect) )
				{
					throw new ProviderException("Empty or missing connectionStringName");
				}

				if ( DataRepository.ConnectionStrings[connect] == null )
				{
					throw new ProviderException("Missing connection string");
				}

				_connectionString = DataRepository.ConnectionStrings[connect].ConnectionString;
			}

            if ( String.IsNullOrEmpty(_connectionString) )
            {
                throw new ProviderException("Empty connection string");
			}

			#endregion
            
             #region "_providerInvariantName"

            // initialize _providerInvariantName
            this._providerInvariantName = config["providerInvariantName"];

            if (String.IsNullOrEmpty(_providerInvariantName))
            {
                throw new ProviderException("Empty or missing providerInvariantName");
            }
            config.Remove("providerInvariantName");

            #endregion

        }
		
		/// <summary>
		/// Creates a new <see cref="TransactionManager"/> instance from the current datasource.
		/// </summary>
		/// <returns></returns>
		public override TransactionManager CreateTransaction()
		{
			return new TransactionManager(this._connectionString);
		}
		
		/// <summary>
		/// Gets a value indicating whether to use stored procedure or not.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this repository use stored procedures; otherwise, <c>false</c>.
		/// </value>
		public bool UseStoredProcedure
		{
			get {return this._useStoredProcedure;}
			set {this._useStoredProcedure = value;}
		}
		
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
	    /// Gets or sets the invariant provider name listed in the DbProviderFactories machine.config section.
	    /// </summary>
	    /// <value>The name of the provider invariant.</value>
	    public string ProviderInvariantName
	    {
	        get { return this._providerInvariantName; }
	        set { this._providerInvariantName = value; }
	    }		
		
		///<summary>
		/// Indicates if the current <see cref="NetTiersProvider"/> implementation supports Transacton.
		///</summary>
		public override bool IsTransactionSupported
		{
			get
			{
				return true;
			}
		}

		
		#region "AdvisorProvider"
			
		private SqlAdvisorProvider innerSqlAdvisorProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Advisor"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AdvisorProviderBase AdvisorProvider
		{
			get
			{
				if (innerSqlAdvisorProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAdvisorProvider == null)
						{
							this.innerSqlAdvisorProvider = new SqlAdvisorProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAdvisorProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlAdvisorProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAdvisorProvider SqlAdvisorProvider
		{
			get {return AdvisorProvider as SqlAdvisorProvider;}
		}
		
		#endregion
		
		
		#region "SeanceQuestionProvider"
			
		private SqlSeanceQuestionProvider innerSqlSeanceQuestionProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SeanceQuestion"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SeanceQuestionProviderBase SeanceQuestionProvider
		{
			get
			{
				if (innerSqlSeanceQuestionProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSeanceQuestionProvider == null)
						{
							this.innerSqlSeanceQuestionProvider = new SqlSeanceQuestionProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSeanceQuestionProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlSeanceQuestionProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSeanceQuestionProvider SqlSeanceQuestionProvider
		{
			get {return SeanceQuestionProvider as SqlSeanceQuestionProvider;}
		}
		
		#endregion
		
		
		#region "SeanceProvider"
			
		private SqlSeanceProvider innerSqlSeanceProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Seance"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SeanceProviderBase SeanceProvider
		{
			get
			{
				if (innerSqlSeanceProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSeanceProvider == null)
						{
							this.innerSqlSeanceProvider = new SqlSeanceProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSeanceProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlSeanceProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSeanceProvider SqlSeanceProvider
		{
			get {return SeanceProvider as SqlSeanceProvider;}
		}
		
		#endregion
		
		
		#region "SchoolProvider"
			
		private SqlSchoolProvider innerSqlSchoolProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="School"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SchoolProviderBase SchoolProvider
		{
			get
			{
				if (innerSqlSchoolProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSchoolProvider == null)
						{
							this.innerSqlSchoolProvider = new SqlSchoolProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSchoolProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlSchoolProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSchoolProvider SqlSchoolProvider
		{
			get {return SchoolProvider as SqlSchoolProvider;}
		}
		
		#endregion
		
		
		#region "ReasonProvider"
			
		private SqlReasonProvider innerSqlReasonProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Reason"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ReasonProviderBase ReasonProvider
		{
			get
			{
				if (innerSqlReasonProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlReasonProvider == null)
						{
							this.innerSqlReasonProvider = new SqlReasonProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlReasonProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlReasonProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlReasonProvider SqlReasonProvider
		{
			get {return ReasonProvider as SqlReasonProvider;}
		}
		
		#endregion
		
		
		#region "QuestionFormGroupProvider"
			
		private SqlQuestionFormGroupProvider innerSqlQuestionFormGroupProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="QuestionFormGroup"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override QuestionFormGroupProviderBase QuestionFormGroupProvider
		{
			get
			{
				if (innerSqlQuestionFormGroupProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlQuestionFormGroupProvider == null)
						{
							this.innerSqlQuestionFormGroupProvider = new SqlQuestionFormGroupProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlQuestionFormGroupProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlQuestionFormGroupProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlQuestionFormGroupProvider SqlQuestionFormGroupProvider
		{
			get {return QuestionFormGroupProvider as SqlQuestionFormGroupProvider;}
		}
		
		#endregion
		
		
		#region "SeanceQuestionOptionProvider"
			
		private SqlSeanceQuestionOptionProvider innerSqlSeanceQuestionOptionProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SeanceQuestionOption"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SeanceQuestionOptionProviderBase SeanceQuestionOptionProvider
		{
			get
			{
				if (innerSqlSeanceQuestionOptionProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSeanceQuestionOptionProvider == null)
						{
							this.innerSqlSeanceQuestionOptionProvider = new SqlSeanceQuestionOptionProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSeanceQuestionOptionProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlSeanceQuestionOptionProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSeanceQuestionOptionProvider SqlSeanceQuestionOptionProvider
		{
			get {return SeanceQuestionOptionProvider as SqlSeanceQuestionOptionProvider;}
		}
		
		#endregion
		
		
		#region "TownProvider"
			
		private SqlTownProvider innerSqlTownProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Town"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override TownProviderBase TownProvider
		{
			get
			{
				if (innerSqlTownProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlTownProvider == null)
						{
							this.innerSqlTownProvider = new SqlTownProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlTownProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlTownProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlTownProvider SqlTownProvider
		{
			get {return TownProvider as SqlTownProvider;}
		}
		
		#endregion
		
		
		#region "SeanceReasonProvider"
			
		private SqlSeanceReasonProvider innerSqlSeanceReasonProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SeanceReason"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SeanceReasonProviderBase SeanceReasonProvider
		{
			get
			{
				if (innerSqlSeanceReasonProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSeanceReasonProvider == null)
						{
							this.innerSqlSeanceReasonProvider = new SqlSeanceReasonProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSeanceReasonProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlSeanceReasonProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSeanceReasonProvider SqlSeanceReasonProvider
		{
			get {return SeanceReasonProvider as SqlSeanceReasonProvider;}
		}
		
		#endregion
		
		
		#region "TeacherProvider"
			
		private SqlTeacherProvider innerSqlTeacherProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Teacher"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override TeacherProviderBase TeacherProvider
		{
			get
			{
				if (innerSqlTeacherProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlTeacherProvider == null)
						{
							this.innerSqlTeacherProvider = new SqlTeacherProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlTeacherProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlTeacherProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlTeacherProvider SqlTeacherProvider
		{
			get {return TeacherProvider as SqlTeacherProvider;}
		}
		
		#endregion
		
		
		#region "WippsiProvider"
			
		private SqlWippsiProvider innerSqlWippsiProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Wippsi"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override WippsiProviderBase WippsiProvider
		{
			get
			{
				if (innerSqlWippsiProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlWippsiProvider == null)
						{
							this.innerSqlWippsiProvider = new SqlWippsiProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlWippsiProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlWippsiProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlWippsiProvider SqlWippsiProvider
		{
			get {return WippsiProvider as SqlWippsiProvider;}
		}
		
		#endregion
		
		
		#region "SeanceQuestionAnswerProvider"
			
		private SqlSeanceQuestionAnswerProvider innerSqlSeanceQuestionAnswerProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SeanceQuestionAnswer"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SeanceQuestionAnswerProviderBase SeanceQuestionAnswerProvider
		{
			get
			{
				if (innerSqlSeanceQuestionAnswerProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSeanceQuestionAnswerProvider == null)
						{
							this.innerSqlSeanceQuestionAnswerProvider = new SqlSeanceQuestionAnswerProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSeanceQuestionAnswerProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlSeanceQuestionAnswerProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSeanceQuestionAnswerProvider SqlSeanceQuestionAnswerProvider
		{
			get {return SeanceQuestionAnswerProvider as SqlSeanceQuestionAnswerProvider;}
		}
		
		#endregion
		
		
		#region "StreetProvider"
			
		private SqlStreetProvider innerSqlStreetProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Street"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override StreetProviderBase StreetProvider
		{
			get
			{
				if (innerSqlStreetProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlStreetProvider == null)
						{
							this.innerSqlStreetProvider = new SqlStreetProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlStreetProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlStreetProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlStreetProvider SqlStreetProvider
		{
			get {return StreetProvider as SqlStreetProvider;}
		}
		
		#endregion
		
		
		#region "QuestionFormProvider"
			
		private SqlQuestionFormProvider innerSqlQuestionFormProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="QuestionForm"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override QuestionFormProviderBase QuestionFormProvider
		{
			get
			{
				if (innerSqlQuestionFormProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlQuestionFormProvider == null)
						{
							this.innerSqlQuestionFormProvider = new SqlQuestionFormProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlQuestionFormProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlQuestionFormProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlQuestionFormProvider SqlQuestionFormProvider
		{
			get {return QuestionFormProvider as SqlQuestionFormProvider;}
		}
		
		#endregion
		
		
		#region "SiblingProvider"
			
		private SqlSiblingProvider innerSqlSiblingProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Sibling"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SiblingProviderBase SiblingProvider
		{
			get
			{
				if (innerSqlSiblingProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSiblingProvider == null)
						{
							this.innerSqlSiblingProvider = new SqlSiblingProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSiblingProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlSiblingProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSiblingProvider SqlSiblingProvider
		{
			get {return SiblingProvider as SqlSiblingProvider;}
		}
		
		#endregion
		
		
		#region "ClientFatherProvider"
			
		private SqlClientFatherProvider innerSqlClientFatherProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ClientFather"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ClientFatherProviderBase ClientFatherProvider
		{
			get
			{
				if (innerSqlClientFatherProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlClientFatherProvider == null)
						{
							this.innerSqlClientFatherProvider = new SqlClientFatherProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlClientFatherProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlClientFatherProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlClientFatherProvider SqlClientFatherProvider
		{
			get {return ClientFatherProvider as SqlClientFatherProvider;}
		}
		
		#endregion
		
		
		#region "ClientMotherProvider"
			
		private SqlClientMotherProvider innerSqlClientMotherProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ClientMother"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ClientMotherProviderBase ClientMotherProvider
		{
			get
			{
				if (innerSqlClientMotherProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlClientMotherProvider == null)
						{
							this.innerSqlClientMotherProvider = new SqlClientMotherProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlClientMotherProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlClientMotherProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlClientMotherProvider SqlClientMotherProvider
		{
			get {return ClientMotherProvider as SqlClientMotherProvider;}
		}
		
		#endregion
		
		
		#region "ClientAddressProvider"
			
		private SqlClientAddressProvider innerSqlClientAddressProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ClientAddress"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ClientAddressProviderBase ClientAddressProvider
		{
			get
			{
				if (innerSqlClientAddressProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlClientAddressProvider == null)
						{
							this.innerSqlClientAddressProvider = new SqlClientAddressProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlClientAddressProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlClientAddressProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlClientAddressProvider SqlClientAddressProvider
		{
			get {return ClientAddressProvider as SqlClientAddressProvider;}
		}
		
		#endregion
		
		
		#region "ProvinceProvider"
			
		private SqlProvinceProvider innerSqlProvinceProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Province"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProvinceProviderBase ProvinceProvider
		{
			get
			{
				if (innerSqlProvinceProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlProvinceProvider == null)
						{
							this.innerSqlProvinceProvider = new SqlProvinceProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlProvinceProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlProvinceProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlProvinceProvider SqlProvinceProvider
		{
			get {return ProvinceProvider as SqlProvinceProvider;}
		}
		
		#endregion
		
		
		#region "CalendarAgeProvider"
			
		private SqlCalendarAgeProvider innerSqlCalendarAgeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="CalendarAge"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CalendarAgeProviderBase CalendarAgeProvider
		{
			get
			{
				if (innerSqlCalendarAgeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCalendarAgeProvider == null)
						{
							this.innerSqlCalendarAgeProvider = new SqlCalendarAgeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCalendarAgeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlCalendarAgeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCalendarAgeProvider SqlCalendarAgeProvider
		{
			get {return CalendarAgeProvider as SqlCalendarAgeProvider;}
		}
		
		#endregion
		
		
		#region "ClientProvider"
			
		private SqlClientProvider innerSqlClientProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Client"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ClientProviderBase ClientProvider
		{
			get
			{
				if (innerSqlClientProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlClientProvider == null)
						{
							this.innerSqlClientProvider = new SqlClientProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlClientProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlClientProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlClientProvider SqlClientProvider
		{
			get {return ClientProvider as SqlClientProvider;}
		}
		
		#endregion
		
		
		#region "ClientEducationProvider"
			
		private SqlClientEducationProvider innerSqlClientEducationProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ClientEducation"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ClientEducationProviderBase ClientEducationProvider
		{
			get
			{
				if (innerSqlClientEducationProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlClientEducationProvider == null)
						{
							this.innerSqlClientEducationProvider = new SqlClientEducationProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlClientEducationProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlClientEducationProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlClientEducationProvider SqlClientEducationProvider
		{
			get {return ClientEducationProvider as SqlClientEducationProvider;}
		}
		
		#endregion
		
		
		#region "AreaProvider"
			
		private SqlAreaProvider innerSqlAreaProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Area"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AreaProviderBase AreaProvider
		{
			get
			{
				if (innerSqlAreaProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAreaProvider == null)
						{
							this.innerSqlAreaProvider = new SqlAreaProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAreaProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlAreaProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAreaProvider SqlAreaProvider
		{
			get {return AreaProvider as SqlAreaProvider;}
		}
		
		#endregion
		
		
		#region "JobProvider"
			
		private SqlJobProvider innerSqlJobProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Job"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override JobProviderBase JobProvider
		{
			get
			{
				if (innerSqlJobProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlJobProvider == null)
						{
							this.innerSqlJobProvider = new SqlJobProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlJobProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlJobProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlJobProvider SqlJobProvider
		{
			get {return JobProvider as SqlJobProvider;}
		}
		
		#endregion
		
		
		#region "NeighborhoodProvider"
			
		private SqlNeighborhoodProvider innerSqlNeighborhoodProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Neighborhood"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override NeighborhoodProviderBase NeighborhoodProvider
		{
			get
			{
				if (innerSqlNeighborhoodProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlNeighborhoodProvider == null)
						{
							this.innerSqlNeighborhoodProvider = new SqlNeighborhoodProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlNeighborhoodProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlNeighborhoodProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlNeighborhoodProvider SqlNeighborhoodProvider
		{
			get {return NeighborhoodProvider as SqlNeighborhoodProvider;}
		}
		
		#endregion
		
		
		#region "QuestionFormOptionProvider"
			
		private SqlQuestionFormOptionProvider innerSqlQuestionFormOptionProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="QuestionFormOption"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override QuestionFormOptionProviderBase QuestionFormOptionProvider
		{
			get
			{
				if (innerSqlQuestionFormOptionProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlQuestionFormOptionProvider == null)
						{
							this.innerSqlQuestionFormOptionProvider = new SqlQuestionFormOptionProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlQuestionFormOptionProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlQuestionFormOptionProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlQuestionFormOptionProvider SqlQuestionFormOptionProvider
		{
			get {return QuestionFormOptionProvider as SqlQuestionFormOptionProvider;}
		}
		
		#endregion
		
		
		#region "QuestionFormAnswerProvider"
			
		private SqlQuestionFormAnswerProvider innerSqlQuestionFormAnswerProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="QuestionFormAnswer"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override QuestionFormAnswerProviderBase QuestionFormAnswerProvider
		{
			get
			{
				if (innerSqlQuestionFormAnswerProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlQuestionFormAnswerProvider == null)
						{
							this.innerSqlQuestionFormAnswerProvider = new SqlQuestionFormAnswerProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlQuestionFormAnswerProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlQuestionFormAnswerProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlQuestionFormAnswerProvider SqlQuestionFormAnswerProvider
		{
			get {return QuestionFormAnswerProvider as SqlQuestionFormAnswerProvider;}
		}
		
		#endregion
		
		
		#region "ObservationFormGroupProvider"
			
		private SqlObservationFormGroupProvider innerSqlObservationFormGroupProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ObservationFormGroup"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ObservationFormGroupProviderBase ObservationFormGroupProvider
		{
			get
			{
				if (innerSqlObservationFormGroupProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlObservationFormGroupProvider == null)
						{
							this.innerSqlObservationFormGroupProvider = new SqlObservationFormGroupProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlObservationFormGroupProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlObservationFormGroupProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlObservationFormGroupProvider SqlObservationFormGroupProvider
		{
			get {return ObservationFormGroupProvider as SqlObservationFormGroupProvider;}
		}
		
		#endregion
		
		
		#region "ObservationFormProvider"
			
		private SqlObservationFormProvider innerSqlObservationFormProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ObservationForm"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ObservationFormProviderBase ObservationFormProvider
		{
			get
			{
				if (innerSqlObservationFormProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlObservationFormProvider == null)
						{
							this.innerSqlObservationFormProvider = new SqlObservationFormProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlObservationFormProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlObservationFormProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlObservationFormProvider SqlObservationFormProvider
		{
			get {return ObservationFormProvider as SqlObservationFormProvider;}
		}
		
		#endregion
		
		
		#region "ObservationFormOptionProvider"
			
		private SqlObservationFormOptionProvider innerSqlObservationFormOptionProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ObservationFormOption"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ObservationFormOptionProviderBase ObservationFormOptionProvider
		{
			get
			{
				if (innerSqlObservationFormOptionProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlObservationFormOptionProvider == null)
						{
							this.innerSqlObservationFormOptionProvider = new SqlObservationFormOptionProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlObservationFormOptionProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlObservationFormOptionProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlObservationFormOptionProvider SqlObservationFormOptionProvider
		{
			get {return ObservationFormOptionProvider as SqlObservationFormOptionProvider;}
		}
		
		#endregion
		
		
		#region "ObservationFormAnswerProvider"
			
		private SqlObservationFormAnswerProvider innerSqlObservationFormAnswerProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ObservationFormAnswer"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ObservationFormAnswerProviderBase ObservationFormAnswerProvider
		{
			get
			{
				if (innerSqlObservationFormAnswerProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlObservationFormAnswerProvider == null)
						{
							this.innerSqlObservationFormAnswerProvider = new SqlObservationFormAnswerProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlObservationFormAnswerProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlObservationFormAnswerProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlObservationFormAnswerProvider SqlObservationFormAnswerProvider
		{
			get {return ObservationFormAnswerProvider as SqlObservationFormAnswerProvider;}
		}
		
		#endregion
		
		
		#region "WiscrProvider"
			
		private SqlWiscrProvider innerSqlWiscrProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Wiscr"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override WiscrProviderBase WiscrProvider
		{
			get
			{
				if (innerSqlWiscrProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlWiscrProvider == null)
						{
							this.innerSqlWiscrProvider = new SqlWiscrProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlWiscrProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlWiscrProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlWiscrProvider SqlWiscrProvider
		{
			get {return WiscrProvider as SqlWiscrProvider;}
		}
		
		#endregion
		
		
		
		#region "NeighborhoodViewProvider"
		
		private SqlNeighborhoodViewProvider innerSqlNeighborhoodViewProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="NeighborhoodView"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override NeighborhoodViewProviderBase NeighborhoodViewProvider
		{
			get
			{
				if (innerSqlNeighborhoodViewProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlNeighborhoodViewProvider == null)
						{
							this.innerSqlNeighborhoodViewProvider = new SqlNeighborhoodViewProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlNeighborhoodViewProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlNeighborhoodViewProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlNeighborhoodViewProvider SqlNeighborhoodViewProvider
		{
			get {return NeighborhoodViewProvider as SqlNeighborhoodViewProvider;}
		}
		
		#endregion
		
		
		#region "ProvinceViewProvider"
		
		private SqlProvinceViewProvider innerSqlProvinceViewProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProvinceView"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProvinceViewProviderBase ProvinceViewProvider
		{
			get
			{
				if (innerSqlProvinceViewProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlProvinceViewProvider == null)
						{
							this.innerSqlProvinceViewProvider = new SqlProvinceViewProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlProvinceViewProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlProvinceViewProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlProvinceViewProvider SqlProvinceViewProvider
		{
			get {return ProvinceViewProvider as SqlProvinceViewProvider;}
		}
		
		#endregion
		
		
		#region "StreetViewProvider"
		
		private SqlStreetViewProvider innerSqlStreetViewProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="StreetView"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override StreetViewProviderBase StreetViewProvider
		{
			get
			{
				if (innerSqlStreetViewProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlStreetViewProvider == null)
						{
							this.innerSqlStreetViewProvider = new SqlStreetViewProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlStreetViewProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlStreetViewProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlStreetViewProvider SqlStreetViewProvider
		{
			get {return StreetViewProvider as SqlStreetViewProvider;}
		}
		
		#endregion
		
		
		#region "TownViewProvider"
		
		private SqlTownViewProvider innerSqlTownViewProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="TownView"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override TownViewProviderBase TownViewProvider
		{
			get
			{
				if (innerSqlTownViewProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlTownViewProvider == null)
						{
							this.innerSqlTownViewProvider = new SqlTownViewProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlTownViewProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlTownViewProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlTownViewProvider SqlTownViewProvider
		{
			get {return TownViewProvider as SqlTownViewProvider;}
		}
		
		#endregion
		
		
		#region "General data access methods"

		#region "ExecuteNonQuery"
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		public override void ExecuteNonQuery(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			database.ExecuteNonQuery(commandWrapper);	
			
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		public override void ExecuteNonQuery(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			database.ExecuteNonQuery(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(commandType, commandText);	
		}
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteNonQuery(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteDataReader"
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteReader(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteReader(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteReader(commandWrapper);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteReader(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteReader(commandType, commandText);	
		}
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteReader(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteDataSet"
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteDataSet(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteDataSet(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteDataSet(commandWrapper);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteDataSet(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteDataSet(commandType, commandText);	
		}
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteDataSet(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteScalar"
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override object ExecuteScalar(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteScalar(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteScalar(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override object ExecuteScalar(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteScalar(commandWrapper);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteScalar(commandWrapper, transactionManager.TransactionObject);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override object ExecuteScalar(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteScalar(commandType, commandText);	
		}
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteScalar(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#endregion


	}
}
