using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.IO;
using System.Data.SqlClient;
using System.Collections.Specialized;
using Microsoft.Data.ConnectionUI;
using Ekip.Framework.Data;
using Ekip.Framework.Data.SqlClient;

namespace Ekip.WinApp.ConnectionDialog
{
    public class DataConnectionConfiguration : IDataConnectionConfiguration
    {
        private const string configFileName = @"DataConnection.xml";
        const string entityCreationalFactoryType = "Ekip.Entities.EntityFactory";
        const string connectionStringName = "EkipConnectionString";
        const string providerInvariantName = "System.Data.SqlClient";
        private string fullFilePath = null;
        private XDocument xDoc = null;
        
        //private IDictionary<string, DataSource> dataSources = null;
        //private IDictionary<string, DataProvider> dataProviders = null;
        
        public DataConnectionConfiguration(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                fullFilePath = Path.GetFullPath(Path.Combine(path, configFileName));
            }
            else
            {
                fullFilePath = Path.Combine(System.Environment.CurrentDirectory, configFileName);
            }
            if (!string.IsNullOrEmpty(fullFilePath) && File.Exists(fullFilePath))
            {
                xDoc = XDocument.Load(fullFilePath);
            }
            else
            {
                xDoc = new XDocument();
                xDoc.Add(new XElement("ConnectionDialog", new XElement("DataSourceSelection")));
            }

            this.RootElement = xDoc.Root;
        }

        public XElement RootElement { get; set; }

        public string LoadConfiguration(DataConnectionDialog dialog)
        {
            dialog.DataSources.Add(DataSource.SqlDataSource);
            //dialog.DataSources.Add(DataSource.SqlFileDataSource);
            //dialog.DataSources.Add(DataSource.OracleDataSource);
            //dialog.DataSources.Add(DataSource.AccessDataSource);
            //dialog.DataSources.Add(DataSource.OdbcDataSource);

            //dialog.UnspecifiedDataSource.Providers.Add(DataProvider.SqlDataProvider);
            //dialog.UnspecifiedDataSource.Providers.Add(DataProvider.OracleDataProvider);
            //dialog.UnspecifiedDataSource.Providers.Add(DataProvider.OleDBDataProvider);
            //dialog.UnspecifiedDataSource.Providers.Add(DataProvider.OdbcDataProvider);
            //dialog.DataSources.Add(dialog.UnspecifiedDataSource);

            //dataSources = new Dictionary<string, DataSource>();
            //dataSources.Add(DataSource.SqlDataSource.Name, DataSource.SqlDataSource);
            //dataSources.Add(DataSource.SqlFileDataSource.Name, DataSource.SqlFileDataSource);
            //dataSources.Add(DataSource.OracleDataSource.Name, DataSource.OracleDataSource);
            //dataSources.Add(DataSource.AccessDataSource.Name, DataSource.AccessDataSource);
            //dataSources.Add(DataSource.OdbcDataSource.Name, DataSource.OdbcDataSource);
            //dataSources.Add(dialog.UnspecifiedDataSource.DisplayName, dialog.UnspecifiedDataSource);

            //dataProviders = new Dictionary<string, DataProvider>();
            //dataProviders.Add(DataProvider.SqlDataProvider.Name, DataProvider.SqlDataProvider);
            //dataProviders.Add(DataProvider.OracleDataProvider.Name, DataProvider.OracleDataProvider);
            //dataProviders.Add(DataProvider.OleDBDataProvider.Name, DataProvider.OleDBDataProvider);
            //dataProviders.Add(DataProvider.OdbcDataProvider.Name, DataProvider.OdbcDataProvider);

            DataSource ds = null;
            string dsName = this.GetSelectedSource();
            //if (!string.IsNullOrEmpty(dsName) && this.dataSources.TryGetValue(dsName, out ds))
            //{
            //    dialog.SelectedDataSource = ds;
            //}

            //DataProvider dp = null;
            //string dpName = this.GetSelectedProvider();
            //if (!string.IsNullOrEmpty(dpName) && this.dataProviders.TryGetValue(dpName, out dp))
            //{
            //    dialog.SelectedDataProvider = dp;
            //}

            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder(dialog.ConnectionString);

            string datasource = this.GetSelectedDataSource();
            bool? integratedSecurity = this.GetIntegratedSecurity();
            string initialCatalog = this.GetInitialCatalog();
            string userName = this.GetUserName();
            string password = this.GetPassword();
            bool multipleActiveResultSets = this.GetMultipleActiveResultSets();
            int connectionTimeout = this.GetConnectionTimeout();

            if (!string.IsNullOrEmpty(datasource)) scsb.DataSource = datasource;
            if (integratedSecurity.HasValue) scsb.IntegratedSecurity = integratedSecurity.Value;
            if (!string.IsNullOrEmpty(initialCatalog)) scsb.InitialCatalog = initialCatalog;

            if (!string.IsNullOrEmpty(userName)) scsb.UserID = userName;
            if (!string.IsNullOrEmpty(password)) scsb.Password = password;

            if ((!string.IsNullOrEmpty(datasource)) && (!String.IsNullOrEmpty(initialCatalog)))
            {
                scsb.MultipleActiveResultSets = multipleActiveResultSets;
                scsb.ConnectTimeout = connectionTimeout;
            }

            if (!string.IsNullOrEmpty(scsb.ConnectionString))
                dialog.ConnectionString = scsb.ConnectionString;

            return dialog.ConnectionString;
        }

        private SqlConnectionStringBuilder ConnectionProperties(DataConnectionDialog dcd)
        {
            return new SqlConnectionStringBuilder(dcd.ConnectionString);
        }

        public void SaveConfiguration(DataConnectionDialog dcd)
        {
            DataSource ds = dcd.SelectedDataSource;

            if (ds != null)
            {
                if (ds == dcd.UnspecifiedDataSource)
                {
                    this.SaveSelectedSource(ds.DisplayName);
                }
                else
                {
                    this.SaveSelectedSource(ds.Name);
                }
            }

            DataProvider dp = dcd.SelectedDataProvider;

            if (dp != null)
            {
                this.SaveSelectedProvider(dp.Name);
            }

            SqlConnectionStringBuilder scsb = ConnectionProperties(dcd);
            SaveIntegratedSecurity(scsb.IntegratedSecurity);
            if (!string.IsNullOrEmpty(scsb.DataSource)) this.SaveSelectedDataSource(ConnectionProperties(dcd).DataSource);
            if (!string.IsNullOrEmpty(scsb.InitialCatalog)) this.SaveInitialCatalog(scsb.InitialCatalog);
            if (!string.IsNullOrEmpty(scsb.UserID)) this.SaveUserName(scsb.UserID);
            if (!string.IsNullOrEmpty(scsb.Password)) this.SavePassword(scsb.Password);
            SaveMultipleActiveResultSets(scsb.MultipleActiveResultSets);
            SaveConnectionTimeout(scsb.ConnectTimeout);
            xDoc.Save(fullFilePath);
        }

        public string GetSelectedSource()
        {
            try
            {
                XElement xElem = RootElement.Element("DataSourceSelection");
                XElement sourceElem = xElem.Element("SelectedSource");
                if (sourceElem != null)
                {
                    return sourceElem.Value as string;
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

        public string GetSelectedProvider()
        {
            try
            {
                XElement xElem = RootElement.Element("DataSourceSelection");
                XElement providerElem = xElem.Element("SelectedProvider");
                if (providerElem != null)
                {
                    return providerElem.Value as string;
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

        public string GetSelectedDataSource()
        {
            XElement xElem = RootElement.Element("DataSourceSelection");
            XElement providerElem = xElem.Element("DataSource");
            if (providerElem == null)
            {
                return null;
            }
            return providerElem.Value as string;
        }

        private bool? GetIntegratedSecurity()
        {
            try
            {
                XElement xElem = this.RootElement.Element("DataSourceSelection");
                XElement providerElem = xElem.Element("IntegratedSecurity");
                if (providerElem != null)
                {
                    return Convert.ToBoolean(providerElem.Value);
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

        public string GetInitialCatalog()
        {
            try
            {
                XElement xElem = this.RootElement.Element("DataSourceSelection");
                XElement providerElem = xElem.Element("InitialCatalog");
                if (providerElem != null)
                {
                    return providerElem.Value;
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

        private string GetUserName()
        {
            try
            {
                XElement xElem = this.RootElement.Element("DataSourceSelection");
                XElement providerElem = xElem.Element("UserID");
                if (providerElem != null)
                {
                    return providerElem.Value;
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

        private string GetPassword()
        {
            try
            {
                XElement xElem = this.RootElement.Element("DataSourceSelection");
                XElement providerElem = xElem.Element("Password");
                if (providerElem != null)
                {
                    return providerElem.Value;
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

        public bool GetMultipleActiveResultSets()
        {
            try
            {
                XElement xElem = this.RootElement.Element("DataSourceSelection");
                XElement providerElem = xElem.Element("MultipleActiveResultSets");
                if (providerElem != null)
                {
                    return Convert.ToBoolean(providerElem.Value);
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        public int GetConnectionTimeout()
        {
            int connectionTimeout = 45;
            try
            {
                XElement xElem = this.RootElement.Element("DataSourceSelection");
                XElement providerElem = xElem.Element("ConnectionTimeout");
                if (providerElem != null)
                {
                    connectionTimeout = Convert.ToInt32(providerElem.Value);
                }
            }
            catch { }
            return connectionTimeout;
        }

        #region Save Methods

        public void SaveSelectedSource(string source)
        {
            if (!String.IsNullOrEmpty(source))
            {
                try
                {
                    XElement xElem = this.RootElement.Element("DataSourceSelection");
                    XElement sourceElem = xElem.Element("SelectedSource");
                    if (sourceElem != null)
                    {
                        sourceElem.Value = source;
                    }
                    else
                    {
                        xElem.Add(new XElement("SelectedSource", source));
                    }
                }
                catch
                {
                }
            }
        }

        public void SaveSelectedDataSource(string dataSource)
        {
            if (!String.IsNullOrEmpty(dataSource))
            {
                try
                {
                    XElement xElem = this.RootElement.Element("DataSourceSelection");
                    XElement sourceElem = xElem.Element("DataSource");
                    if (sourceElem != null)
                    {
                        sourceElem.Value = dataSource;
                    }
                    else
                    {
                        xElem.Add(new XElement("DataSource", dataSource));
                    }
                }
                catch
                {
                }
            }
        }

        public void SaveSelectedProvider(string provider)
        {
            if (!String.IsNullOrEmpty(provider))
            {
                try
                {
                    XElement xElem = this.RootElement.Element("DataSourceSelection");
                    XElement sourceElem = xElem.Element("SelectedProvider");
                    if (sourceElem != null)
                    {
                        sourceElem.Value = provider;
                    }
                    else
                    {
                        xElem.Add(new XElement("SelectedProvider", provider));
                    }
                }
                catch
                {
                }
            }
        }

        private void SaveIntegratedSecurity(bool integratedSecurity)
        {
            try
            {
                XElement xElem = this.RootElement.Element("DataSourceSelection");
                XElement sourceElem = xElem.Element("IntegratedSecurity");
                if (sourceElem != null)
                {
                    sourceElem.Value = integratedSecurity.ToString();
                }
                else
                {
                    xElem.Add(new XElement("IntegratedSecurity", integratedSecurity.ToString()));
                }
            }
            catch
            {
            }
        }

        private void SaveInitialCatalog(string initialCatalog)
        {
            XElement xElem = this.RootElement.Element("DataSourceSelection");
            XElement sourceElem = xElem.Element("InitialCatalog");
            if (sourceElem != null)
            {
                sourceElem.Value = initialCatalog;
            }
            else
            {
                xElem.Add(new XElement("InitialCatalog", initialCatalog));
            }
        }

        private void SaveUserName(string userId)
        {
            XElement xElem = this.RootElement.Element("DataSourceSelection");
            XElement sourceElem = xElem.Element("UserID");
            if (sourceElem != null)
            {
                sourceElem.Value = userId;
            }
            else
            {
                xElem.Add(new XElement("UserID", userId));
            }
        }

        private void SavePassword(string password)
        {
            XElement xElem = this.RootElement.Element("DataSourceSelection");
            XElement sourceElem = xElem.Element("Password");
            if (sourceElem != null)
            {
                sourceElem.Value = password;
            }
            else
            {
                xElem.Add(new XElement("Password", password));
            }
        }

        private void SaveMultipleActiveResultSets(bool allowMultipleActiveResultSets)
        {
            XElement xElem = this.RootElement.Element("DataSourceSelection");
            XElement sourceElem = xElem.Element("MultipleActiveResultSets");
            if (sourceElem != null)
            {
                sourceElem.Value = allowMultipleActiveResultSets.ToString();
            }
            else
            {
                xElem.Add(new XElement("MultipleActiveResultSets", allowMultipleActiveResultSets));
            }
        }

        private void SaveConnectionTimeout(int connectionTimeout)
        {
            XElement xElem = this.RootElement.Element("DataSourceSelection");
            XElement sourceElem = xElem.Element("ConnectionTimeout");
            if (sourceElem != null)
            {
                sourceElem.Value = connectionTimeout.ToString();
            }
            else
            {
                xElem.Add(new XElement("ConnectionTimeout", connectionTimeout));
            }
        }

        #endregion

        public void InitializeProvider()
        {
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
            sb.DataSource = GetSelectedDataSource();
            sb.InitialCatalog = GetInitialCatalog();
            sb.IntegratedSecurity = GetIntegratedSecurity().Value;
            sb.UserID = GetUserName();
            sb.Password = GetPassword();
            sb.MultipleActiveResultSets = GetMultipleActiveResultSets();
            sb.ConnectTimeout = GetConnectionTimeout();
            
            SqlNetTiersProvider provider = new SqlNetTiersProvider();
            NameValueCollection collection = new NameValueCollection();
            collection.Add("UseStoredProcedure", "true");
            collection.Add("EnableEntityTracking", "true");
            collection.Add("EntityCreationalFactoryType", entityCreationalFactoryType);
            collection.Add("EnableMethodAuthorization", "false");
            collection.Add("DefaultCommandTimeout", "600");
            collection.Add("ConnectionString", sb.ConnectionString);
            collection.Add("ConnectionStringName", connectionStringName);
            collection.Add("ProviderInvariantName", providerInvariantName);
            provider.Initialize("DynamicSqlNetTiersProvider", collection);
            DataRepository.LoadProvider(provider, true);
        }
    }
}
