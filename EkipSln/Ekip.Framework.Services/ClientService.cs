#region Using Directives
using System;
using System.Collections.Generic;
using System.Data;
using Ekip.Framework.Core;
using Ekip.Framework.Data;
using Ekip.Framework.Entities;

#endregion

namespace Ekip.Framework.Services
{
    /// <summary>
    /// An component type implementation of the 'Client' table.
    /// </summary>
    /// <remarks>
    /// All custom implementations should be done here.
    /// </remarks>
    [CLSCompliant(true)]
    public partial class ClientService : Ekip.Framework.Services.ClientServiceBase
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the ClientService class.
        /// </summary>
        public ClientService() : base()
        {
        }
        #endregion Constructors

        //public int GetRowCount()
        //{
        //    var rowCount = 0;
        //    object obj = DataRepository.Provider.ExecuteScalar("_GetRowCountByTableName", new object[] { "Client" });
        //    rowCount = obj.ToInt32();
        //    return rowCount;
        //}

        public List<string> GetAllClientFirstContactYears()
        {
            List<string> result = new List<string>();

            IDataReader dr = DataRepository.ClientProvider.GetAllFirstContactYears();

            while (dr.Read())
            {
                result.Add(dr[0].ToString());
            }

            return result;
        }

        public List<string> GetAllClientBirthDateYears()
        {
            List<string> result = new List<string>();

            IDataReader dr = DataRepository.ClientProvider.GetAllBirthDateYears();

            while (dr.Read())
            {
                result.Add(dr[0].ToString());
            }

            return result;
        }

        public List<int> GetAllFileNumbers()
        {
            List<int> result = new List<int>();
            System.Data.IDataReader reader = DataRepository.ClientProvider.GetFileNumbers();
            while (reader.Read())
            {
                int fileNumber = reader.GetSafeInt32("FileNumber", 0);
                result.Add(fileNumber);
            }
            return result;
        }

    }

} // end namespace
