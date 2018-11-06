using System;

namespace Ekip.Framework.Core
{
    public static class ConvertionExtensions
    {
        public static int ToInt32(this object obj)
        {
            int k = 0;

            if (obj != null && obj != DBNull.Value)
            {
                k = Convert.ToInt32(obj);
            }
            return k;
        }

        public static string ToValue(this object obj)
        {
            string k = null;

            if (obj != null && obj != DBNull.Value)
            {
                k = obj.ToString();
            }
            return k;
        }

        public static int? ToNullableInt(this object obj)
        {
            int? k = null;
            if (obj != null && obj != DBNull.Value)
            {
                k = Convert.ToInt32(obj);
            }
            return k;
        }

        public static DateTime? ToDateTime(this object obj)
        {
            DateTime? date = null;

            if (obj != null && obj != DBNull.Value && Convert.ToDateTime(obj) > DateTime.MinValue)
            {
                date = Convert.ToDateTime(obj);
            }
            return date;
        }

        public static byte? ToByte(this object obj)
        {
            byte? result = null;

            if (obj != null && obj != DBNull.Value)
            {
                result = Convert.ToByte(result);
            }
            return result;
        }
    }
}
