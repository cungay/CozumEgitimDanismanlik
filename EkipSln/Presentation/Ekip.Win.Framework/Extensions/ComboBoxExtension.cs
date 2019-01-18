using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using Ekip.Framework.Core;

namespace Ekip.Framework.UI.Extensions
{
    public static class ComboBoxEditExtension
    {
        #region ComboBox

        public static void BindIEnumarable<T>(this ComboBoxEdit cb, IEnumerable<T> source, bool emptyItem)
        {
            if (emptyItem)
            {
                cb.Properties.Items.Add(new EmptyItem() { EmptyString = "<..Seçiniz..>" });
            }
            BindIEnumarable(cb, source);
        }

        public static void BindIEnumarable<T>(this ComboBoxEdit cb, IEnumerable<T> source)
        {
            cb.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            cb.Properties.Items.Clear();
            foreach (T item in source)
            {
                cb.Properties.BeginUpdate();
                cb.Properties.Items.Add(item);
                cb.Properties.EndUpdate();
            }
        }

        public static void BindIEnumarable<T>(this ComboBoxEdit cb, IEnumerable<T> source, bool emptyItem, string emptyString)
        {
            if (emptyItem)
            {
                cb.Properties.NullText = emptyString;
                cb.Properties.Items.Add(new EmptyItem() { EmptyString = emptyString });
            }
            BindIEnumarable(cb, source);
        }

        public static void BindIList(this ComboBoxEdit cb, Dictionary<int, string> list, bool header)
        {
            BindIList(cb, list, header, "Hepsi");
        }

        public static void BindIList(this ComboBoxEdit cb, Dictionary<int, string> list, bool header, string headerText)
        {
            cb.BindTable(list.ToDataTable(), "Value", "Key", header, headerText);
        }

        public static void BindEnum(this ComboBoxEdit cb, Type enumType, bool header, string headerText)
        {
            BindIList(cb, enumType.ToValueList(), header, headerText);
        }

        public static void BindEnum(this ComboBoxEdit cb, List<Enum> list, bool header, string headerText)
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            foreach (Enum value in list)
                dic.Add(value.GetHashCode(), value.GetDescription());
            BindIList(cb, dic, header, headerText);
        }

        public static void BindEnum(this ComboBoxEdit cb, Type enumType, bool header = false)
        {
            BindEnum(cb, enumType, header, "Hepsi");
        }

        public static void BindTable(this ComboBoxEdit cb, DataTable table, string display, string value, bool header)
        {
            BindTable(cb, table, display, value, header, "Hepsi");
        }

        public static void BindTable(this ComboBoxEdit cb, DataTable table, string display, string value, bool header, string headerText)
        {
            cb.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;

            if (header)
            {
                DataRow row = table.NewRow();
                row[display] = headerText;
                row[value] = 0;
                table.Rows.InsertAt(row, 0);
            }
            cb.Properties.BeginUpdate();
            table.AsEnumerable().ForEach(delegate (DataRow item)
            {
                cb.Properties.Items.Add(item.ItemArray[1]);
            });
            cb.Properties.EndUpdate();
        }

        #endregion

        #region RepositoryItemComboBox

        public static void BindIEnumarable<T>(this RepositoryItemComboBox cb, IEnumerable<T> source)
        {
            source.ForEach<T>(delegate (T item)
            {
                cb.BeginUpdate();
                cb.Items.Add(item);
                cb.EndUpdate();
            });
        }

        public static void BindIEnumarable<T>(this RepositoryItemComboBox cb, IEnumerable<T> source, bool emptyItem)
        {
            if (emptyItem)
            {
                cb.Items.Add(new EmptyItem() { EmptyString = "<Seçiniz>" });
            }
            BindIEnumarable(cb, source);
        }

        public static void BindIEnumarable<T>(this RepositoryItemComboBox cb, IEnumerable<T> source, bool emptyItem, string emptyString)
        {
            if (emptyItem)
            {
                cb.NullText = emptyString;
                cb.Items.Add(new EmptyItem() { EmptyString = emptyString });
            }
            BindIEnumarable(cb, source);
        }

        #endregion

        #region EmptyItem

        public class EmptyItem
        {
            public string EmptyString { get; set; }

            public override string ToString() => EmptyString;
        }

        #endregion
    }
}
