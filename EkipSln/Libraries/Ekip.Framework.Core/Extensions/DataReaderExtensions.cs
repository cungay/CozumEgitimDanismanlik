using System;
using System.ComponentModel;
using System.Data;
using System.Reflection;

namespace Ekip.Framework.Core
{
    public static class DataReaderExtensions
    {
        public static string GetSafeString(this IDataReader reader, string columnName)
        {
            int index = reader.GetOrdinal(columnName);

            return !reader.IsDBNull(index) ? reader.GetString(index) : string.Empty;
        }

        public static string GetSafeString(this IDataReader reader, string columnName, string defaultValue)
        {
            int index = reader.GetOrdinal(columnName);

            return !reader.IsDBNull(index) ? reader.GetString(index) : defaultValue;
        }

        public static int? GetSafeInt(this IDataReader reader, string columnName)
        {
            return reader.GetSafeInt32(columnName);
        }

        public static int GetSafeInt(this IDataReader reader, string columnName, int defaultValue)
        {
            return reader.GetSafeInt32(columnName, defaultValue);
        }

        public static int? GetSafeInt32(this IDataReader reader, string columnName)
        {
            int index = reader.GetOrdinal(columnName);

            return !reader.IsDBNull(index) ? (int?)reader.GetInt32(index) : null;
        }

        public static int GetSafeInt32(this IDataReader reader, string columnName, int defaultValue)
        {
            int index = reader.GetOrdinal(columnName);

            return !reader.IsDBNull(index) ? reader.GetInt32(index) : defaultValue;
        }

        public static long? GetSafeInt64(this IDataReader reader, string columnName)
        {
            int index = reader.GetOrdinal(columnName);

            return !reader.IsDBNull(index) ? (long?)reader.GetInt64(index) : null;
        }

        public static long GetSafeInt64(this IDataReader reader, string columnName, long defaultValue)
        {
            // DB type: bigint
            int index = reader.GetOrdinal(columnName);

            return !reader.IsDBNull(index) ? reader.GetInt64(index) : defaultValue;
        }

        public static short? GetSafeInt16(this IDataReader reader, string columnName)
        {
            // DB type: smallint
            int index = reader.GetOrdinal(columnName);

            return !reader.IsDBNull(index) ? (short?)reader.GetInt16(index) : null;
        }

        public static short GetSafeInt16(this IDataReader reader, string columnName, short defaultValue)
        {
            int index = reader.GetOrdinal(columnName);

            return !reader.IsDBNull(index) ? reader.GetInt16(index) : defaultValue;
        }

        public static Guid GetSafeGuid(this IDataReader reader, string columnName, Guid defaultValue)
        {
            int index = reader.GetOrdinal(columnName);

            return !reader.IsDBNull(index) ? reader.GetGuid(index) : defaultValue;
        }

        public static Guid? GetSafeGuid(this IDataReader reader, string columnName)
        {
            int index = reader.GetOrdinal(columnName);

            return !reader.IsDBNull(index) ? (Guid?)reader.GetGuid(index) : null;
        }

        public static Guid GetSafeGuidOrEmpty(this IDataReader reader, string columnName)
        {
            int index = reader.GetOrdinal(columnName);

            return !reader.IsDBNull(index) ? reader.GetGuid(index) : Guid.Empty;
        }

        public static DateTime? GetSafeDateTime(this IDataReader reader, string columnName)
        {
            int index = reader.GetOrdinal(columnName);

            return !reader.IsDBNull(index) ? (DateTime?)reader.GetDateTime(index) : null;
        }

        public static DateTime GetSafeDateTime(this IDataReader reader, string columnName, DateTime defaultValue)
        {
            int index = reader.GetOrdinal(columnName);

            return !reader.IsDBNull(index) ? reader.GetDateTime(index) : defaultValue;
        }

        public static dynamic GetSafeDateTime(this IDataReader reader, string columnName, string defaultValue)
        {
            int index = reader.GetOrdinal(columnName);

            return !reader.IsDBNull(index) ? (dynamic)reader.GetDateTime(index) : defaultValue;
        }

        public static DateTimeOffset GetSafeDateTimeOffset(this IDataReader reader, string columnName, DateTimeOffset defaultValue)
        {
            // Gets the record value casted as DateTimeOffset (UTC) or the specified default value.
            int index = reader.GetOrdinal(columnName);
            if (!reader.IsDBNull(index))
            {
                DateTime dt = reader.GetDateTime(index);
                if (dt != DateTime.MinValue)
                {
                    return new DateTimeOffset(dt, TimeSpan.Zero);
                }
            }

            return defaultValue;
        }

        public static bool? GetSafeBool(this IDataReader reader, string columnName)
        {
            int index = reader.GetOrdinal(columnName);

            return !reader.IsDBNull(index) ? (bool?)reader.GetBoolean(index) : null;
        }

        public static bool GetSafeBool(this IDataReader reader, string columnName, bool defaultValue)
        {
            int index = reader.GetOrdinal(columnName);

            return !reader.IsDBNull(index) ? reader.GetBoolean(index) : defaultValue;
        }

        public static T Fill<T>(this IDataReader reader, T obj)
        {
            foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(obj))
            {
                if (!prop.IsReadOnly)
                {
                    if (reader.FieldExists(prop.Name))
                    {
                        if (reader[prop.Name] is DBNull)
                        {
                            prop.SetValue(obj, null);
                        }
                        else
                        {
                            prop.SetValue(obj, reader[prop.Name]);
                        }
                    }
                }
            }

            return obj;
        }

        public static bool FieldExists(this IDataRecord record, string columnName)
        {
            for (int i = 0; i < record.FieldCount; i++)
            {
                if (record.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Returns the index of a column by name or -1.
        /// </summary>
        /// <param name="this">The data record.</param>
        /// <param name="name">The field name (case insensitive).</param>
        /// <returns>The index of a column by name, or -1.</returns>
        public static int IndexOf(this IDataRecord @this, string name)
        {
            for (int i = 0; i < @this.FieldCount; i++)
            {
                if (String.Compare(@this.GetName(i), name, StringComparison.InvariantCultureIgnoreCase) == 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public static bool IsDbNull(this IDataReader reader, string field)
        {
            return reader[field] == DBNull.Value;
        }

        /// <summary>
        /// Reads all all records from a data reader and performs an
        /// action for each.
        /// </summary>
        /// <param name="reader">The data reader.</param>
        /// <param name="action">The action to be performed.</param>
        /// <returns>The count of actions that were performed.</returns>
        public static int ReadAll(this IDataReader reader, Action<IDataReader> action)
        {
            int count = 0;

            while (reader.Read())
            {
                action(reader);
                count++;
            }

            return count;
        }

        public static T SingleOrDefault<T>(this IDataReader reader)
        {
            T obj = Activator.CreateInstance<T>();
            PropertyInfo[] props = obj.GetType().GetProperties();
            while (reader.Read())
            {
                for (int i = 0; i < props.Length; i++)
                {
                    if (FieldExists(reader, props[i].Name) && reader[props[i].Name] != DBNull.Value)
                        obj.GetType().InvokeMember(props[i].Name, BindingFlags.SetProperty, null, obj, new object[] { reader[props[i].Name] });
                }
            }
            return obj;
        }
    }
}