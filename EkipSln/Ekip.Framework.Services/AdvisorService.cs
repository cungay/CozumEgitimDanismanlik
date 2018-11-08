#region Using Directives
using System;
using Ekip.Framework.Entities;
using Ekip.Framework.Data;
using Ekip.Framework.Core.Caching;
#endregion

namespace Ekip.Framework.Services
{
    /// <summary>
    /// An component type implementation of the 'Advisor' table.
    /// </summary>
    /// <remarks>
    /// All custom implementations should be done here.
    /// </remarks>
    [CLSCompliant(true)]
    public partial class AdvisorService : Ekip.Framework.Services.AdvisorServiceBase
    {
        #region Constants

        private const string ADVISOR_ALL_KEY = "ekip.advisor.all";

        #endregion

        #region Fields

        private ICacheManager cacheManager = null;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the AdvisorService class.
        /// </summary>
        public AdvisorService() : base()
        {
            cacheManager = new MemoryCacheManager();
        }

        #endregion Constructors

        public TList<Advisor> GetAll(bool addEmptyItem = false)
        {
            return cacheManager.Get(ADVISOR_ALL_KEY, () =>
            {
                var list = DataRepository.AdvisorProvider.GetAll();
                if (addEmptyItem)
                    list.Insert(0, new Advisor() { AdvisorId = 0, FullName = "Belirtilmedi" });
                return list;
            });
        }

    }//End Class

} // end namespace
