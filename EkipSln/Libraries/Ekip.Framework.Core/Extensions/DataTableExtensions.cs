using System;
using System.Linq;
using System.Data;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using System.Globalization;

namespace Ekip.Framework.Core
{
    public static class DataTableExtensionsEx
    {
        public static DataTable ToDataTable<T>(this IEnumerable<T> source)
        {
            return new ObjectShredder<T>().Shred(source, null, null);
        }

        public static DataTable GetMonths()
        {
            Dictionary<int, string> list = new Dictionary<int, string>();
            var tr = new CultureInfo("tr-TR");
            for (int i = 0; i < 12; i++)
            {
                if (list.Keys.Contains(i.GetHashCode()))
                    continue;
                list.Add(i, new DateTime(2000, i + 1, 1).ToString("MMMM", tr));
            }
            return list.ToDataTable();
        }

        public static DataTable ToDataTable<T>(this IEnumerable<T> source, DataTable table, LoadOption? options)
        {
            return new ObjectShredder<T>().Shred(source, table, options);
        }

        public static DataTable CloneTable<T>(this IEnumerable<T> source)
        {
            DataTable dt = new DataTable();
            return new ObjectShredder<T>().ExtendTable(dt, typeof(T));
        }

        public static DataTable ListTable<T>(this IEnumerable<T> source, string keyMember, string valueMember)
        {
            return new ObjectShredder<T>().ListTable(source, keyMember, valueMember);
        }

        public class ObjectShredder<T>
        {
            private FieldInfo[] _fi;
            private PropertyInfo[] _pi;
            private Dictionary<string, int> _ordinalMap;
            private Type _type;

            public ObjectShredder()
            {
                _type = typeof(T);
                _fi = _type.GetFields();
                _pi = _type.GetProperties();
                _ordinalMap = new Dictionary<string, int>();
            }

            public DataTable ListTable(IEnumerable<T> source, string keyMember, string valueMember)
            {
                Type instance = typeof(T);
                DataTable table = new DataTable(instance.Name);

                // now see if need to extend datatable base on the type T + build ordinal map
                table = ExtendListTable(table, instance, keyMember, valueMember);

                table.BeginLoadData();
                using (IEnumerator<T> e = source.GetEnumerator())
                {
                    while (e.MoveNext())
                    {

                        Object[] values = new object[2];

                        values[table.Columns["Key"].Ordinal] = instance.GetProperty(keyMember).GetValue(e.Current, null);
                        values[table.Columns["Value"].Ordinal] = instance.GetProperty(valueMember).GetValue(e.Current, null);

                        table.LoadDataRow(values, true);

                    }
                }
                table.EndLoadData();
                return table;
            }

            public DataTable Shred(IEnumerable<T> source, DataTable table, LoadOption? options)
            {
                if (typeof(T).IsPrimitive)
                {
                    return ShredPrimitive(source, table, options);
                }


                if (table == null)
                {
                    table = new DataTable(typeof(T).Name);
                }

                // now see if need to extend datatable base on the type T + build ordinal map
                table = ExtendTable(table, typeof(T));

                table.BeginLoadData();
                using (IEnumerator<T> e = source.GetEnumerator())
                {
                    while (e.MoveNext())
                    {
                        if (options != null)
                        {
                            table.LoadDataRow(ShredObject(table, e.Current), (LoadOption)options);
                        }
                        else
                        {
                            table.LoadDataRow(ShredObject(table, e.Current), true);
                        }
                    }
                }
                table.EndLoadData();
                return table;
            }

            public DataTable ShredPrimitive(IEnumerable<T> source, DataTable table, LoadOption? options)
            {
                if (table == null)
                {
                    table = new DataTable(typeof(T).Name);
                }

                if (!table.Columns.Contains("Value"))
                {
                    table.Columns.Add("Value", typeof(T));
                }

                table.BeginLoadData();
                using (IEnumerator<T> e = source.GetEnumerator())
                {
                    Object[] values = new object[table.Columns.Count];
                    while (e.MoveNext())
                    {
                        values[table.Columns["Value"].Ordinal] = e.Current;

                        if (options != null)
                        {
                            table.LoadDataRow(values, (LoadOption)options);
                        }
                        else
                        {
                            table.LoadDataRow(values, true);
                        }
                    }
                }
                table.EndLoadData();
                return table;
            }

            public DataTable ExtendTable(DataTable table, Type type)
            {
                // value is type derived from T, may need to extend table.
                foreach (FieldInfo f in type.GetFields())
                {
                    if (!_ordinalMap.ContainsKey(f.Name))
                    {
                        DataColumn dc = table.Columns.Contains(f.Name) ? table.Columns[f.Name]
                            : table.Columns.Add(f.Name, f.FieldType);
                        _ordinalMap.Add(f.Name, dc.Ordinal);
                    }
                }
                foreach (PropertyInfo p in type.GetProperties())
                {
                    if (!_ordinalMap.ContainsKey(p.Name))
                    {
                        System.Type t = System.Nullable.GetUnderlyingType(p.PropertyType);
                        if (t != null)
                        {
                            DataColumn dc = table.Columns.Contains(p.Name) ? table.Columns[p.Name]
                                : table.Columns.Add(p.Name, t);
                            _ordinalMap.Add(p.Name, dc.Ordinal);
                        }
                        else
                        {
                            DataColumn dc = table.Columns.Contains(p.Name) ? table.Columns[p.Name]
                               : table.Columns.Add(p.Name, p.PropertyType);
                            _ordinalMap.Add(p.Name, dc.Ordinal);
                        }
                    }
                }
                return table;
            }

            public DataTable ExtendListTable(DataTable table, Type type, string keyMember,
                string valueMember)
            {
                // value is type derived from T, may need to extend table.

                foreach (PropertyInfo p in type.GetProperties())
                {
                    if (!_ordinalMap.ContainsKey(p.Name))
                    {
                        System.Type t = System.Nullable.GetUnderlyingType(p.PropertyType);
                        if (t != null)
                        {
                            if (p.Name == keyMember)
                            {
                                DataColumn dc = table.Columns.Contains("Key") ? table.Columns["Key"]
                                    : table.Columns.Add("Key", t);
                                _ordinalMap.Add("Key", dc.Ordinal);
                            }
                            else if (p.Name == valueMember)
                            {
                                DataColumn dc = table.Columns.Contains("Value") ? table.Columns["Value"]
                                    : table.Columns.Add("Value", t);
                                _ordinalMap.Add("Value", dc.Ordinal);
                            }
                        }
                        else
                        {
                            if (p.Name == keyMember)
                            {
                                DataColumn dc = table.Columns.Contains("Key") ? table.Columns["Key"]
                                   : table.Columns.Add("Key", p.PropertyType);
                                _ordinalMap.Add("Key", dc.Ordinal);
                            }
                            else if (p.Name == valueMember)
                            {
                                DataColumn dc = table.Columns.Contains("Value") ? table.Columns["Value"]
                                  : table.Columns.Add("Value", p.PropertyType);
                                _ordinalMap.Add("Value", dc.Ordinal);
                            }
                        }
                    }
                }
                return table;
            }

            public object[] ShredObject(DataTable table, T instance)
            {

                FieldInfo[] fi = _fi;
                PropertyInfo[] pi = _pi;

                if (instance.GetType() != typeof(T))
                {
                    ExtendTable(table, instance.GetType());
                    fi = instance.GetType().GetFields();
                    pi = instance.GetType().GetProperties();
                }

                Object[] values = new object[table.Columns.Count];
                foreach (FieldInfo f in fi)
                {
                    values[_ordinalMap[f.Name]] = f.GetValue(instance);
                }

                foreach (PropertyInfo p in pi)
                {
                    if (p.Name == "Item")
                        continue;
                    values[_ordinalMap[p.Name]] = p.GetValue(instance, null);
                }
                return values;
            }
        }

        public static DataTable GetDataFromStream(this DataTable dataTable, Stream stream)
        {
            DataSet ds = new DataSet();
            if (stream != null)
            {
                ds.ReadXml(stream);
            }
            return ds.Tables[0];
        }

        public static DataTable GetDataFromFile(this DataTable dataTable, string fileName)
        {
            DataSet ds = new DataSet();
            fileName = string.Format("{0}.{1}", "XMLData", fileName);
            Stream stream = StreamExtensions.GetManifestResourceStream(fileName, Assembly.GetEntryAssembly());
            if (stream != null)
            {
                ds.ReadXml(stream);
                dataTable = ds.Tables[0];
            }
            return dataTable;
        }

        /// <summary>
        /// Convert a List{T} to a DataTable.
        /// </summary>
        //public static DataTable ToDataTable<T>(this List<T> items)
        //{
        //    var tb = new DataTable(typeof(T).Name);
        //    PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        //    foreach (PropertyInfo prop in props) {
        //        Type t = GetCoreType(prop.PropertyType);
        //        tb.Columns.Add(prop.Name, t);
        //    }
        //    foreach (T item in items) {
        //        var count = props.Count();
        //        var values = new object[count];
        //        for (int i = 0; i < count; i++) {
        //            if (props[i].Name == "Item")
        //                continue;
        //            values[i] = props[i].GetValue(item, null);
        //        }
        //        tb.Rows.Add(values);
        //    }
        //    return tb;
        //}

        /// <summary>
        /// Determine of specified type is nullable
        /// </summary>
        //public static bool IsNullable(Type t)
        //{
        //    return !t.IsValueType || (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
        //}

        /// <summary>
        /// Return underlying type if type is Nullable otherwise return the type
        /// </summary>
        //public static Type GetCoreType(Type t)
        //{
        //    if (t != null && IsNullable(t))
        //    {
        //        if (!t.IsValueType)
        //        {
        //            return t;
        //        }
        //        else
        //        {
        //            return Nullable.GetUnderlyingType(t);
        //        }
        //    }
        //    else
        //    {
        //        return t;
        //    }
        //}
    }
}
