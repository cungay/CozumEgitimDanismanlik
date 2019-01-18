using System.Configuration;

namespace Ekip.Framework.Core
{
    public sealed class ConfigManager
    {
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["EkipConnectionString"].ConnectionString;
            }
        }

        public static string  UseStoredProcedure
        {
            get
            {
                bool result = false;
                string useStoredProcedure = ConfigurationManager.AppSettings["UseStoredProcedure"];
                if (!string.IsNullOrEmpty(useStoredProcedure))
                {
                    bool.TryParse(useStoredProcedure, out result);
                }
                return result.ToString();
            }
        }

        public static string EnableEntityTracking
        {
            get
            {
                bool result = false;
                string enableEntityTracking = ConfigurationManager.AppSettings["EnableEntityTracking"];
                if (!string.IsNullOrEmpty(enableEntityTracking))
                {
                    bool.TryParse(enableEntityTracking, out result);
                }
                return result.ToString();
            }
        }

        public static string EntityCreationalFactoryType
        {
            get
            {
                return ConfigurationManager.AppSettings["EntityCreationalFactoryType"];
            }
        }

        public static string EnableMethodAuthorization
        {
            get
            {
                bool result = false;
                string enableMethodAuthorization = ConfigurationManager.AppSettings["EnableMethodAuthorization"];
                if (!string.IsNullOrEmpty(enableMethodAuthorization))
                {
                    bool.TryParse(enableMethodAuthorization, out result);
                }
                return result.ToString();
            }
        }

        public static string DefaultCommandTimeout
        {
            get
            {
                int result = 0;
                string timeOut = ConfigurationManager.AppSettings["DefaultCommandTimeout"];
                if (!string.IsNullOrEmpty(timeOut))
                {
                    int.TryParse(timeOut, out result);
                }
                return result.ToString();
            }
        }

        public static string ConnectionStringName
        {
            get
            {
                return ConfigurationManager.AppSettings["ConnectionStringName"];
            }
        }

        public static string ProviderInvariantName
        {
            get
            {
                return ConfigurationManager.AppSettings["ProviderInvariantName"];
            }
        }
    }
}
