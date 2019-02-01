#region Using directives

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Provider;
using System.Web.Configuration;
using System.Web;
using Ekip.Framework.Entities;
using Ekip.Framework.Data;
using Ekip.Framework.Data.Bases;

#endregion

namespace Ekip.Framework.Data
{
	/// <summary>
	/// This class represents the Data source repository and gives access to all the underlying providers.
	/// </summary>
	[CLSCompliant(true)]
	public sealed class DataRepository 
	{
		private static volatile NetTiersProvider _provider = null;
        private static volatile NetTiersProviderCollection _providers = null;
		private static volatile NetTiersServiceSection _section = null;
        
        private static object SyncRoot = new object();
				
		private DataRepository()
		{
		}
		
		#region Public LoadProvider
		/// <summary>
        /// Enables the DataRepository to programatically create and 
        /// pass in a <c>NetTiersProvider</c> during runtime.
        /// </summary>
        /// <param name="provider">An instatiated NetTiersProvider.</param>
        public static void LoadProvider(NetTiersProvider provider)
        {
			LoadProvider(provider, false);
        }
		
		/// <summary>
        /// Enables the DataRepository to programatically create and 
        /// pass in a <c>NetTiersProvider</c> during runtime.
        /// </summary>
        /// <param name="provider">An instatiated NetTiersProvider.</param>
        /// <param name="setAsDefault">ability to set any valid provider as the default provider for the DataRepository.</param>
		public static void LoadProvider(NetTiersProvider provider, bool setAsDefault)
        {
            if (provider == null)
                throw new ArgumentNullException("provider");

            if (_providers == null)
			{
				lock(SyncRoot)
				{
            		if (_providers == null)
						_providers = new NetTiersProviderCollection();
				}
			}
			
            if (_providers[provider.Name] == null)
            {
                lock (_providers.SyncRoot)
                {
                    _providers.Add(provider);
                }
            }

            if (_provider == null || setAsDefault)
            {
                lock (SyncRoot)
                {
                    if(_provider == null || setAsDefault)
                         _provider = provider;
                }
            }
        }
		#endregion 
		
		///<summary>
		/// Configuration based provider loading, will load the providers on first call.
		///</summary>
		private static void LoadProviders()
        {
            // Avoid claiming lock if providers are already loaded
            if (_provider == null)
            {
                lock (SyncRoot)
                {
                    // Do this again to make sure _provider is still null
                    if (_provider == null)
                    {
                        // Load registered providers and point _provider to the default provider
                        _providers = new NetTiersProviderCollection();

                        ProvidersHelper.InstantiateProviders(NetTiersSection.Providers, _providers, typeof(NetTiersProvider));
						_provider = _providers[NetTiersSection.DefaultProvider];

                        if (_provider == null)
                        {
                            throw new ProviderException("Unable to load default NetTiersProvider");
                        }
                    }
                }
            }
        }

		/// <summary>
        /// Gets the provider.
        /// </summary>
        /// <value>The provider.</value>
        public static NetTiersProvider Provider
        {
            get { LoadProviders(); return _provider; }
        }

		/// <summary>
        /// Gets the provider collection.
        /// </summary>
        /// <value>The providers.</value>
        public static NetTiersProviderCollection Providers
        {
            get { LoadProviders(); return _providers; }
        }
		
		/// <summary>
		/// Creates a new <see cref="TransactionManager"/> instance from the current datasource.
		/// </summary>
		/// <returns></returns>
		public TransactionManager CreateTransaction()
		{
			return _provider.CreateTransaction();
		}

		#region Configuration

		/// <summary>
		/// Gets a reference to the configured NetTiersServiceSection object.
		/// </summary>
		public static NetTiersServiceSection NetTiersSection
		{
			get
			{
				// Try to get a reference to the default <netTiersService> section
				_section = WebConfigurationManager.GetSection("netTiersService") as NetTiersServiceSection;

				if ( _section == null )
				{
					// otherwise look for section based on the assembly name
					_section = WebConfigurationManager.GetSection("Ekip.Framework.Data") as NetTiersServiceSection;
				}

				if ( _section == null )
				{
					throw new ProviderException("Unable to load NetTiersServiceSection");
				}

				return _section;
			}
		}

		#endregion Configuration

		#region Connections

		/// <summary>
		/// Gets a reference to the ConnectionStringSettings collection.
		/// </summary>
		public static ConnectionStringSettingsCollection ConnectionStrings
		{
			get
			{
					return WebConfigurationManager.ConnectionStrings;
			}
		}

		// dictionary of connection providers
		private static Dictionary<String, ConnectionProvider> _connections;

		/// <summary>
		/// Gets the dictionary of connection providers.
		/// </summary>
		public static Dictionary<String, ConnectionProvider> Connections
		{
			get
			{
				if ( _connections == null )
				{
					lock (SyncRoot)
                	{
						if (_connections == null)
						{
							_connections = new Dictionary<String, ConnectionProvider>();
		
							// add a connection provider for each configured connection string
							foreach ( ConnectionStringSettings conn in ConnectionStrings )
							{
								_connections.Add(conn.Name, new ConnectionProvider(conn.Name, conn.ConnectionString));
							}
						}
					}
				}

				return _connections;
			}
		}

		/// <summary>
		/// Adds the specified connection string to the map of connection strings.
		/// </summary>
		/// <param name="connectionStringName">The connection string name.</param>
		/// <param name="connectionString">The provider specific connection information.</param>
		public static void AddConnection(String connectionStringName, String connectionString)
		{
			lock (SyncRoot)
            {
				Connections.Remove(connectionStringName);
				ConnectionProvider connection = new ConnectionProvider(connectionStringName, connectionString);
				Connections.Add(connectionStringName, connection);
			}
		}

		/// <summary>
		/// Provides ability to switch connection string at runtime.
		/// </summary>
		public sealed class ConnectionProvider
		{
			private NetTiersProvider _provider;
			private NetTiersProviderCollection _providers;
			private String _connectionStringName;
			private String _connectionString;


			/// <summary>
			/// Initializes a new instance of the ConnectionProvider class.
			/// </summary>
			/// <param name="connectionStringName">The connection string name.</param>
			/// <param name="connectionString">The provider specific connection information.</param>
			public ConnectionProvider(String connectionStringName, String connectionString)
			{
				_connectionString = connectionString;
				_connectionStringName = connectionStringName;
			}

			/// <summary>
			/// Gets the provider.
			/// </summary>
			public NetTiersProvider Provider
			{
				get { LoadProviders(); return _provider; }
			}

			/// <summary>
			/// Gets the provider collection.
			/// </summary>
			public NetTiersProviderCollection Providers
			{
				get { LoadProviders(); return _providers; }
			}

			/// <summary>
			/// Instantiates the configured providers based on the supplied connection string.
			/// </summary>
			private void LoadProviders()
			{
				DataRepository.LoadProviders();

				// Avoid claiming lock if providers are already loaded
				if ( _providers == null )
				{
					lock ( SyncRoot )
					{
						// Do this again to make sure _provider is still null
						if ( _providers == null )
						{
							// apply connection information to each provider
							for ( int i = 0; i < NetTiersSection.Providers.Count; i++ )
							{
								NetTiersSection.Providers[i].Parameters["connectionStringName"] = _connectionStringName;
								// remove previous connection string, if any
								NetTiersSection.Providers[i].Parameters.Remove("connectionString");

								if ( !String.IsNullOrEmpty(_connectionString) )
								{
									NetTiersSection.Providers[i].Parameters["connectionString"] = _connectionString;
								}
							}

							// Load registered providers and point _provider to the default provider
							_providers = new NetTiersProviderCollection();

							ProvidersHelper.InstantiateProviders(NetTiersSection.Providers, _providers, typeof(NetTiersProvider));
							_provider = _providers[NetTiersSection.DefaultProvider];
						}
					}
				}
			}
		}

		#endregion Connections

		#region Static properties
		
		#region AdvisorProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Advisor"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static AdvisorProviderBase AdvisorProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AdvisorProvider;
			}
		}
		
		#endregion
		
		#region SeanceQuestionProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="SeanceQuestion"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SeanceQuestionProviderBase SeanceQuestionProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SeanceQuestionProvider;
			}
		}
		
		#endregion
		
		#region SeanceProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Seance"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SeanceProviderBase SeanceProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SeanceProvider;
			}
		}
		
		#endregion
		
		#region SchoolProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="School"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SchoolProviderBase SchoolProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SchoolProvider;
			}
		}
		
		#endregion
		
		#region ReasonProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Reason"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ReasonProviderBase ReasonProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ReasonProvider;
			}
		}
		
		#endregion
		
		#region QuestionFormGroupProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="QuestionFormGroup"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static QuestionFormGroupProviderBase QuestionFormGroupProvider
		{
			get 
			{
				LoadProviders();
				return _provider.QuestionFormGroupProvider;
			}
		}
		
		#endregion
		
		#region SeanceQuestionOptionProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="SeanceQuestionOption"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SeanceQuestionOptionProviderBase SeanceQuestionOptionProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SeanceQuestionOptionProvider;
			}
		}
		
		#endregion
		
		#region TownProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Town"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static TownProviderBase TownProvider
		{
			get 
			{
				LoadProviders();
				return _provider.TownProvider;
			}
		}
		
		#endregion
		
		#region SeanceReasonProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="SeanceReason"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SeanceReasonProviderBase SeanceReasonProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SeanceReasonProvider;
			}
		}
		
		#endregion
		
		#region TeacherProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Teacher"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static TeacherProviderBase TeacherProvider
		{
			get 
			{
				LoadProviders();
				return _provider.TeacherProvider;
			}
		}
		
		#endregion
		
		#region WippsiProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Wippsi"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static WippsiProviderBase WippsiProvider
		{
			get 
			{
				LoadProviders();
				return _provider.WippsiProvider;
			}
		}
		
		#endregion
		
		#region SeanceQuestionAnswerProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="SeanceQuestionAnswer"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SeanceQuestionAnswerProviderBase SeanceQuestionAnswerProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SeanceQuestionAnswerProvider;
			}
		}
		
		#endregion
		
		#region StreetProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Street"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static StreetProviderBase StreetProvider
		{
			get 
			{
				LoadProviders();
				return _provider.StreetProvider;
			}
		}
		
		#endregion
		
		#region QuestionFormProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="QuestionForm"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static QuestionFormProviderBase QuestionFormProvider
		{
			get 
			{
				LoadProviders();
				return _provider.QuestionFormProvider;
			}
		}
		
		#endregion
		
		#region SiblingProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Sibling"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SiblingProviderBase SiblingProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SiblingProvider;
			}
		}
		
		#endregion
		
		#region ClientFatherProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ClientFather"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ClientFatherProviderBase ClientFatherProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ClientFatherProvider;
			}
		}
		
		#endregion
		
		#region ClientMotherProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ClientMother"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ClientMotherProviderBase ClientMotherProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ClientMotherProvider;
			}
		}
		
		#endregion
		
		#region ClientAddressProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ClientAddress"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ClientAddressProviderBase ClientAddressProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ClientAddressProvider;
			}
		}
		
		#endregion
		
		#region ProvinceProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Province"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ProvinceProviderBase ProvinceProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ProvinceProvider;
			}
		}
		
		#endregion
		
		#region CalendarAgeProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="CalendarAge"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CalendarAgeProviderBase CalendarAgeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CalendarAgeProvider;
			}
		}
		
		#endregion
		
		#region ClientProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Client"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ClientProviderBase ClientProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ClientProvider;
			}
		}
		
		#endregion
		
		#region ClientEducationProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ClientEducation"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ClientEducationProviderBase ClientEducationProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ClientEducationProvider;
			}
		}
		
		#endregion
		
		#region AreaProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Area"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static AreaProviderBase AreaProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AreaProvider;
			}
		}
		
		#endregion
		
		#region JobProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Job"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static JobProviderBase JobProvider
		{
			get 
			{
				LoadProviders();
				return _provider.JobProvider;
			}
		}
		
		#endregion
		
		#region NeighborhoodProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Neighborhood"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static NeighborhoodProviderBase NeighborhoodProvider
		{
			get 
			{
				LoadProviders();
				return _provider.NeighborhoodProvider;
			}
		}
		
		#endregion
		
		#region QuestionFormOptionProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="QuestionFormOption"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static QuestionFormOptionProviderBase QuestionFormOptionProvider
		{
			get 
			{
				LoadProviders();
				return _provider.QuestionFormOptionProvider;
			}
		}
		
		#endregion
		
		#region QuestionFormAnswerProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="QuestionFormAnswer"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static QuestionFormAnswerProviderBase QuestionFormAnswerProvider
		{
			get 
			{
				LoadProviders();
				return _provider.QuestionFormAnswerProvider;
			}
		}
		
		#endregion
		
		#region ObservationFormGroupProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ObservationFormGroup"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ObservationFormGroupProviderBase ObservationFormGroupProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ObservationFormGroupProvider;
			}
		}
		
		#endregion
		
		#region ObservationFormProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ObservationForm"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ObservationFormProviderBase ObservationFormProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ObservationFormProvider;
			}
		}
		
		#endregion
		
		#region ObservationFormOptionProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ObservationFormOption"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ObservationFormOptionProviderBase ObservationFormOptionProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ObservationFormOptionProvider;
			}
		}
		
		#endregion
		
		#region ObservationFormAnswerProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ObservationFormAnswer"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ObservationFormAnswerProviderBase ObservationFormAnswerProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ObservationFormAnswerProvider;
			}
		}
		
		#endregion
		
		#region WiscrProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Wiscr"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static WiscrProviderBase WiscrProvider
		{
			get 
			{
				LoadProviders();
				return _provider.WiscrProvider;
			}
		}
		
		#endregion
		
		
		#region ProvinceViewProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ProvinceView"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ProvinceViewProviderBase ProvinceViewProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ProvinceViewProvider;
			}
		}
		
		#endregion
		
		#endregion
	}
	
	#region Query/Filters
		
	#region AdvisorFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Advisor"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvisorFilters : AdvisorFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvisorFilters class.
		/// </summary>
		public AdvisorFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdvisorFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdvisorFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdvisorFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdvisorFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdvisorFilters
	
	#region AdvisorQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="AdvisorParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Advisor"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvisorQuery : AdvisorParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvisorQuery class.
		/// </summary>
		public AdvisorQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdvisorQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdvisorQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdvisorQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdvisorQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdvisorQuery
		
	#region SeanceQuestionFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SeanceQuestion"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SeanceQuestionFilters : SeanceQuestionFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SeanceQuestionFilters class.
		/// </summary>
		public SeanceQuestionFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SeanceQuestionFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SeanceQuestionFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SeanceQuestionFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SeanceQuestionFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SeanceQuestionFilters
	
	#region SeanceQuestionQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SeanceQuestionParameterBuilder"/> class
	/// that is used exclusively with a <see cref="SeanceQuestion"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SeanceQuestionQuery : SeanceQuestionParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SeanceQuestionQuery class.
		/// </summary>
		public SeanceQuestionQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SeanceQuestionQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SeanceQuestionQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SeanceQuestionQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SeanceQuestionQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SeanceQuestionQuery
		
	#region SeanceFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Seance"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SeanceFilters : SeanceFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SeanceFilters class.
		/// </summary>
		public SeanceFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SeanceFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SeanceFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SeanceFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SeanceFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SeanceFilters
	
	#region SeanceQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SeanceParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Seance"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SeanceQuery : SeanceParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SeanceQuery class.
		/// </summary>
		public SeanceQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SeanceQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SeanceQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SeanceQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SeanceQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SeanceQuery
		
	#region SchoolFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="School"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SchoolFilters : SchoolFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SchoolFilters class.
		/// </summary>
		public SchoolFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SchoolFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SchoolFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SchoolFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SchoolFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SchoolFilters
	
	#region SchoolQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SchoolParameterBuilder"/> class
	/// that is used exclusively with a <see cref="School"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SchoolQuery : SchoolParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SchoolQuery class.
		/// </summary>
		public SchoolQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SchoolQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SchoolQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SchoolQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SchoolQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SchoolQuery
		
	#region ReasonFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Reason"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ReasonFilters : ReasonFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ReasonFilters class.
		/// </summary>
		public ReasonFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ReasonFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ReasonFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ReasonFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ReasonFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ReasonFilters
	
	#region ReasonQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ReasonParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Reason"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ReasonQuery : ReasonParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ReasonQuery class.
		/// </summary>
		public ReasonQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ReasonQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ReasonQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ReasonQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ReasonQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ReasonQuery
		
	#region QuestionFormGroupFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="QuestionFormGroup"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuestionFormGroupFilters : QuestionFormGroupFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuestionFormGroupFilters class.
		/// </summary>
		public QuestionFormGroupFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the QuestionFormGroupFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public QuestionFormGroupFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the QuestionFormGroupFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public QuestionFormGroupFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion QuestionFormGroupFilters
	
	#region QuestionFormGroupQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="QuestionFormGroupParameterBuilder"/> class
	/// that is used exclusively with a <see cref="QuestionFormGroup"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuestionFormGroupQuery : QuestionFormGroupParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuestionFormGroupQuery class.
		/// </summary>
		public QuestionFormGroupQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the QuestionFormGroupQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public QuestionFormGroupQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the QuestionFormGroupQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public QuestionFormGroupQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion QuestionFormGroupQuery
		
	#region SeanceQuestionOptionFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SeanceQuestionOption"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SeanceQuestionOptionFilters : SeanceQuestionOptionFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SeanceQuestionOptionFilters class.
		/// </summary>
		public SeanceQuestionOptionFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SeanceQuestionOptionFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SeanceQuestionOptionFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SeanceQuestionOptionFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SeanceQuestionOptionFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SeanceQuestionOptionFilters
	
	#region SeanceQuestionOptionQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SeanceQuestionOptionParameterBuilder"/> class
	/// that is used exclusively with a <see cref="SeanceQuestionOption"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SeanceQuestionOptionQuery : SeanceQuestionOptionParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SeanceQuestionOptionQuery class.
		/// </summary>
		public SeanceQuestionOptionQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SeanceQuestionOptionQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SeanceQuestionOptionQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SeanceQuestionOptionQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SeanceQuestionOptionQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SeanceQuestionOptionQuery
		
	#region TownFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Town"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TownFilters : TownFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TownFilters class.
		/// </summary>
		public TownFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the TownFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TownFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TownFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TownFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TownFilters
	
	#region TownQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="TownParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Town"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TownQuery : TownParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TownQuery class.
		/// </summary>
		public TownQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the TownQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TownQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TownQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TownQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TownQuery
		
	#region SeanceReasonFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SeanceReason"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SeanceReasonFilters : SeanceReasonFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SeanceReasonFilters class.
		/// </summary>
		public SeanceReasonFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SeanceReasonFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SeanceReasonFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SeanceReasonFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SeanceReasonFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SeanceReasonFilters
	
	#region SeanceReasonQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SeanceReasonParameterBuilder"/> class
	/// that is used exclusively with a <see cref="SeanceReason"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SeanceReasonQuery : SeanceReasonParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SeanceReasonQuery class.
		/// </summary>
		public SeanceReasonQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SeanceReasonQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SeanceReasonQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SeanceReasonQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SeanceReasonQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SeanceReasonQuery
		
	#region TeacherFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Teacher"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TeacherFilters : TeacherFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TeacherFilters class.
		/// </summary>
		public TeacherFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the TeacherFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TeacherFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TeacherFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TeacherFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TeacherFilters
	
	#region TeacherQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="TeacherParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Teacher"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TeacherQuery : TeacherParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TeacherQuery class.
		/// </summary>
		public TeacherQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the TeacherQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TeacherQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TeacherQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TeacherQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TeacherQuery
		
	#region WippsiFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Wippsi"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WippsiFilters : WippsiFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WippsiFilters class.
		/// </summary>
		public WippsiFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the WippsiFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public WippsiFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the WippsiFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public WippsiFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion WippsiFilters
	
	#region WippsiQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="WippsiParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Wippsi"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WippsiQuery : WippsiParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WippsiQuery class.
		/// </summary>
		public WippsiQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the WippsiQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public WippsiQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the WippsiQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public WippsiQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion WippsiQuery
		
	#region SeanceQuestionAnswerFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SeanceQuestionAnswer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SeanceQuestionAnswerFilters : SeanceQuestionAnswerFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SeanceQuestionAnswerFilters class.
		/// </summary>
		public SeanceQuestionAnswerFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SeanceQuestionAnswerFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SeanceQuestionAnswerFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SeanceQuestionAnswerFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SeanceQuestionAnswerFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SeanceQuestionAnswerFilters
	
	#region SeanceQuestionAnswerQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SeanceQuestionAnswerParameterBuilder"/> class
	/// that is used exclusively with a <see cref="SeanceQuestionAnswer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SeanceQuestionAnswerQuery : SeanceQuestionAnswerParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SeanceQuestionAnswerQuery class.
		/// </summary>
		public SeanceQuestionAnswerQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SeanceQuestionAnswerQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SeanceQuestionAnswerQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SeanceQuestionAnswerQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SeanceQuestionAnswerQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SeanceQuestionAnswerQuery
		
	#region StreetFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Street"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class StreetFilters : StreetFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the StreetFilters class.
		/// </summary>
		public StreetFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the StreetFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public StreetFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the StreetFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public StreetFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion StreetFilters
	
	#region StreetQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="StreetParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Street"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class StreetQuery : StreetParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the StreetQuery class.
		/// </summary>
		public StreetQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the StreetQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public StreetQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the StreetQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public StreetQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion StreetQuery
		
	#region QuestionFormFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="QuestionForm"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuestionFormFilters : QuestionFormFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuestionFormFilters class.
		/// </summary>
		public QuestionFormFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the QuestionFormFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public QuestionFormFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the QuestionFormFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public QuestionFormFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion QuestionFormFilters
	
	#region QuestionFormQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="QuestionFormParameterBuilder"/> class
	/// that is used exclusively with a <see cref="QuestionForm"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuestionFormQuery : QuestionFormParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuestionFormQuery class.
		/// </summary>
		public QuestionFormQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the QuestionFormQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public QuestionFormQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the QuestionFormQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public QuestionFormQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion QuestionFormQuery
		
	#region SiblingFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Sibling"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiblingFilters : SiblingFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiblingFilters class.
		/// </summary>
		public SiblingFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiblingFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiblingFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiblingFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiblingFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiblingFilters
	
	#region SiblingQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SiblingParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Sibling"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiblingQuery : SiblingParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiblingQuery class.
		/// </summary>
		public SiblingQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiblingQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiblingQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiblingQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiblingQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiblingQuery
		
	#region ClientFatherFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClientFather"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClientFatherFilters : ClientFatherFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClientFatherFilters class.
		/// </summary>
		public ClientFatherFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ClientFatherFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ClientFatherFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ClientFatherFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ClientFatherFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ClientFatherFilters
	
	#region ClientFatherQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ClientFatherParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ClientFather"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClientFatherQuery : ClientFatherParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClientFatherQuery class.
		/// </summary>
		public ClientFatherQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ClientFatherQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ClientFatherQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ClientFatherQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ClientFatherQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ClientFatherQuery
		
	#region ClientMotherFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClientMother"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClientMotherFilters : ClientMotherFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClientMotherFilters class.
		/// </summary>
		public ClientMotherFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ClientMotherFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ClientMotherFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ClientMotherFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ClientMotherFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ClientMotherFilters
	
	#region ClientMotherQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ClientMotherParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ClientMother"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClientMotherQuery : ClientMotherParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClientMotherQuery class.
		/// </summary>
		public ClientMotherQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ClientMotherQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ClientMotherQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ClientMotherQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ClientMotherQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ClientMotherQuery
		
	#region ClientAddressFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClientAddress"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClientAddressFilters : ClientAddressFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClientAddressFilters class.
		/// </summary>
		public ClientAddressFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ClientAddressFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ClientAddressFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ClientAddressFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ClientAddressFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ClientAddressFilters
	
	#region ClientAddressQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ClientAddressParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ClientAddress"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClientAddressQuery : ClientAddressParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClientAddressQuery class.
		/// </summary>
		public ClientAddressQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ClientAddressQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ClientAddressQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ClientAddressQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ClientAddressQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ClientAddressQuery
		
	#region ProvinceFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Province"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProvinceFilters : ProvinceFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProvinceFilters class.
		/// </summary>
		public ProvinceFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProvinceFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProvinceFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProvinceFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProvinceFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProvinceFilters
	
	#region ProvinceQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ProvinceParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Province"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProvinceQuery : ProvinceParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProvinceQuery class.
		/// </summary>
		public ProvinceQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProvinceQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProvinceQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProvinceQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProvinceQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProvinceQuery
		
	#region CalendarAgeFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CalendarAge"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CalendarAgeFilters : CalendarAgeFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CalendarAgeFilters class.
		/// </summary>
		public CalendarAgeFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CalendarAgeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CalendarAgeFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CalendarAgeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CalendarAgeFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CalendarAgeFilters
	
	#region CalendarAgeQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CalendarAgeParameterBuilder"/> class
	/// that is used exclusively with a <see cref="CalendarAge"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CalendarAgeQuery : CalendarAgeParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CalendarAgeQuery class.
		/// </summary>
		public CalendarAgeQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CalendarAgeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CalendarAgeQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CalendarAgeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CalendarAgeQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CalendarAgeQuery
		
	#region ClientFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Client"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClientFilters : ClientFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClientFilters class.
		/// </summary>
		public ClientFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ClientFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ClientFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ClientFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ClientFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ClientFilters
	
	#region ClientQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ClientParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Client"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClientQuery : ClientParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClientQuery class.
		/// </summary>
		public ClientQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ClientQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ClientQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ClientQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ClientQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ClientQuery
		
	#region ClientEducationFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClientEducation"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClientEducationFilters : ClientEducationFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClientEducationFilters class.
		/// </summary>
		public ClientEducationFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ClientEducationFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ClientEducationFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ClientEducationFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ClientEducationFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ClientEducationFilters
	
	#region ClientEducationQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ClientEducationParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ClientEducation"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClientEducationQuery : ClientEducationParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClientEducationQuery class.
		/// </summary>
		public ClientEducationQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ClientEducationQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ClientEducationQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ClientEducationQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ClientEducationQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ClientEducationQuery
		
	#region AreaFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Area"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AreaFilters : AreaFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AreaFilters class.
		/// </summary>
		public AreaFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the AreaFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AreaFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AreaFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AreaFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AreaFilters
	
	#region AreaQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="AreaParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Area"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AreaQuery : AreaParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AreaQuery class.
		/// </summary>
		public AreaQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the AreaQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AreaQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AreaQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AreaQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AreaQuery
		
	#region JobFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Job"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobFilters : JobFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobFilters class.
		/// </summary>
		public JobFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobFilters
	
	#region JobQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="JobParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Job"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobQuery : JobParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobQuery class.
		/// </summary>
		public JobQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobQuery
		
	#region NeighborhoodFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Neighborhood"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class NeighborhoodFilters : NeighborhoodFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NeighborhoodFilters class.
		/// </summary>
		public NeighborhoodFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the NeighborhoodFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public NeighborhoodFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the NeighborhoodFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public NeighborhoodFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion NeighborhoodFilters
	
	#region NeighborhoodQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="NeighborhoodParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Neighborhood"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class NeighborhoodQuery : NeighborhoodParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NeighborhoodQuery class.
		/// </summary>
		public NeighborhoodQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the NeighborhoodQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public NeighborhoodQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the NeighborhoodQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public NeighborhoodQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion NeighborhoodQuery
		
	#region QuestionFormOptionFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="QuestionFormOption"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuestionFormOptionFilters : QuestionFormOptionFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuestionFormOptionFilters class.
		/// </summary>
		public QuestionFormOptionFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the QuestionFormOptionFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public QuestionFormOptionFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the QuestionFormOptionFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public QuestionFormOptionFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion QuestionFormOptionFilters
	
	#region QuestionFormOptionQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="QuestionFormOptionParameterBuilder"/> class
	/// that is used exclusively with a <see cref="QuestionFormOption"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuestionFormOptionQuery : QuestionFormOptionParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuestionFormOptionQuery class.
		/// </summary>
		public QuestionFormOptionQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the QuestionFormOptionQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public QuestionFormOptionQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the QuestionFormOptionQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public QuestionFormOptionQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion QuestionFormOptionQuery
		
	#region QuestionFormAnswerFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="QuestionFormAnswer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuestionFormAnswerFilters : QuestionFormAnswerFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuestionFormAnswerFilters class.
		/// </summary>
		public QuestionFormAnswerFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the QuestionFormAnswerFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public QuestionFormAnswerFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the QuestionFormAnswerFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public QuestionFormAnswerFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion QuestionFormAnswerFilters
	
	#region QuestionFormAnswerQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="QuestionFormAnswerParameterBuilder"/> class
	/// that is used exclusively with a <see cref="QuestionFormAnswer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuestionFormAnswerQuery : QuestionFormAnswerParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuestionFormAnswerQuery class.
		/// </summary>
		public QuestionFormAnswerQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the QuestionFormAnswerQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public QuestionFormAnswerQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the QuestionFormAnswerQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public QuestionFormAnswerQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion QuestionFormAnswerQuery
		
	#region ObservationFormGroupFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ObservationFormGroup"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ObservationFormGroupFilters : ObservationFormGroupFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ObservationFormGroupFilters class.
		/// </summary>
		public ObservationFormGroupFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ObservationFormGroupFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ObservationFormGroupFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ObservationFormGroupFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ObservationFormGroupFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ObservationFormGroupFilters
	
	#region ObservationFormGroupQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ObservationFormGroupParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ObservationFormGroup"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ObservationFormGroupQuery : ObservationFormGroupParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ObservationFormGroupQuery class.
		/// </summary>
		public ObservationFormGroupQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ObservationFormGroupQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ObservationFormGroupQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ObservationFormGroupQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ObservationFormGroupQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ObservationFormGroupQuery
		
	#region ObservationFormFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ObservationForm"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ObservationFormFilters : ObservationFormFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ObservationFormFilters class.
		/// </summary>
		public ObservationFormFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ObservationFormFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ObservationFormFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ObservationFormFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ObservationFormFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ObservationFormFilters
	
	#region ObservationFormQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ObservationFormParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ObservationForm"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ObservationFormQuery : ObservationFormParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ObservationFormQuery class.
		/// </summary>
		public ObservationFormQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ObservationFormQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ObservationFormQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ObservationFormQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ObservationFormQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ObservationFormQuery
		
	#region ObservationFormOptionFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ObservationFormOption"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ObservationFormOptionFilters : ObservationFormOptionFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ObservationFormOptionFilters class.
		/// </summary>
		public ObservationFormOptionFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ObservationFormOptionFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ObservationFormOptionFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ObservationFormOptionFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ObservationFormOptionFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ObservationFormOptionFilters
	
	#region ObservationFormOptionQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ObservationFormOptionParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ObservationFormOption"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ObservationFormOptionQuery : ObservationFormOptionParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ObservationFormOptionQuery class.
		/// </summary>
		public ObservationFormOptionQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ObservationFormOptionQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ObservationFormOptionQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ObservationFormOptionQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ObservationFormOptionQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ObservationFormOptionQuery
		
	#region ObservationFormAnswerFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ObservationFormAnswer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ObservationFormAnswerFilters : ObservationFormAnswerFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ObservationFormAnswerFilters class.
		/// </summary>
		public ObservationFormAnswerFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ObservationFormAnswerFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ObservationFormAnswerFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ObservationFormAnswerFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ObservationFormAnswerFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ObservationFormAnswerFilters
	
	#region ObservationFormAnswerQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ObservationFormAnswerParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ObservationFormAnswer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ObservationFormAnswerQuery : ObservationFormAnswerParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ObservationFormAnswerQuery class.
		/// </summary>
		public ObservationFormAnswerQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ObservationFormAnswerQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ObservationFormAnswerQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ObservationFormAnswerQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ObservationFormAnswerQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ObservationFormAnswerQuery
		
	#region WiscrFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Wiscr"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WiscrFilters : WiscrFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WiscrFilters class.
		/// </summary>
		public WiscrFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the WiscrFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public WiscrFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the WiscrFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public WiscrFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion WiscrFilters
	
	#region WiscrQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="WiscrParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Wiscr"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WiscrQuery : WiscrParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WiscrQuery class.
		/// </summary>
		public WiscrQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the WiscrQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public WiscrQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the WiscrQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public WiscrQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion WiscrQuery
		
	#region ProvinceViewFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProvinceView"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProvinceViewFilters : ProvinceViewFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProvinceViewFilters class.
		/// </summary>
		public ProvinceViewFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProvinceViewFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProvinceViewFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProvinceViewFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProvinceViewFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProvinceViewFilters
	
	#region ProvinceViewQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ProvinceViewParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ProvinceView"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProvinceViewQuery : ProvinceViewParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProvinceViewQuery class.
		/// </summary>
		public ProvinceViewQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProvinceViewQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProvinceViewQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProvinceViewQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProvinceViewQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProvinceViewQuery
	#endregion

	
}
