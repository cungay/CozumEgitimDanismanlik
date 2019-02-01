using System;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using Ekip.Framework.Core;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using Ekip.Framework.Core.Resources;

namespace Ekip.Framework.UI.Extensions
{
    public static class LookUpExtension
    {
        public static void BindEnumarable<T>(this LookUpEdit lk, IEnumerable<T> source, string display, string value)
        {
            DataTable dt = source.ToDataTable();
            DataRow eRow = dt.NewRow();
            eRow[display] = SystemMessages.Lookup_Not_Specified;
            eRow[value] = 0;
            dt.Rows.InsertAt(eRow, 0);
            lk.Properties.BeginUpdate();
            lk.Properties.DisplayMember = display;
            lk.Properties.ValueMember = value;
            lk.Properties.DataSource = dt;
            lk.Properties.EndUpdate();
        }
        
        #region Enum Bind

        public static void BindEnum(this LookUpEdit lk, Type enumType)
        {
            var source = enumType.ToValueList();
            DescriptionAttribute[] attributes = (DescriptionAttribute[])enumType.GetCustomAttributes(typeof(DescriptionAttribute), false);
            string header = (attributes.Length > 0) ? attributes[0].Description : enumType.ToString();
            lk.BindTable(source.ToDataTable(), "Value", "Key", header);
        }

        private static void BindTable(this LookUpEdit lk, DataTable table, string display, string value, string header)
        {
            lk.Properties.BeginInit();
            lk.Properties.Columns.Clear();
            lk.Properties.Columns.Add(new LookUpColumnInfo() { FieldName = "Value", Caption = string.Format("{0} Seçiniz", header) });
            lk.Properties.Columns[0].AllowSort = DevExpress.Utils.DefaultBoolean.False;
            lk.Properties.ShowHeader = true;
            lk.Properties.EndInit();
            //DataRow row = table.NewRow();
            //row[display] = "Belirtilmedi";
            //row[value] = 0;
            //table.Rows.InsertAt(row, 0);
            lk.Properties.NullText = header;
            lk.Properties.BeginUpdate();
            lk.Properties.DisplayMember = display;
            lk.Properties.ValueMember = value;
            lk.Properties.DataSource = table;
            lk.Properties.EndUpdate();
        }

        #endregion

        #region RepositoryItemLookUpEdit

        private static void BindEnumarable<T>(this RepositoryItemLookUpEdit rlk, IEnumerable<T> source, string
               display, string value, LookUpColumnInfo[] columns, bool emptyRow, string emptyRowString)
        {
            rlk.BeginInit();
            rlk.Columns.Clear();
            if (columns != null && columns.Count() > 0)
                rlk.Columns.AddRange(columns);
            else
            {
                rlk.ShowHeader = false;
                rlk.Columns.Add(new LookUpColumnInfo() { FieldName = display });
            }
            rlk.EndInit();

            DataTable dt = null;
            if (emptyRow)
            {
                dt = source.ToDataTable();
                DataRow eRow = dt.NewRow();
                eRow[display] = emptyRowString;
                if (value == null) value = "Id";
                eRow[value] = DBNull.Value;// 0;
                dt.Rows.InsertAt(eRow, 0);
            }
            rlk.NullText = emptyRowString;
            rlk.BeginUpdate();
            rlk.DisplayMember = display;
            if (value.Trim().Length > 0)
                rlk.ValueMember = value;
            if (dt != null) rlk.DataSource = dt;
            else rlk.DataSource = source;
            rlk.EndUpdate();
        }

        private static void BindEnumarable(this RepositoryItemLookUpEdit rlk, DataTable source, string
          display, string value, LookUpColumnInfo[] columns, bool emptyRow, string emptyRowString)
        {
            rlk.BeginInit();
            rlk.Columns.Clear();
            if (columns != null && columns.Count() > 0)
                rlk.Columns.AddRange(columns);
            else
            {
                rlk.ShowHeader = false;
                rlk.Columns.Add(new LookUpColumnInfo() { FieldName = display });
            }
            rlk.EndInit();

            DataTable dt = null;
            if (emptyRow)
            {
                dt = source.AsEnumerable().CopyToDataTable();
                DataRow eRow = dt.NewRow();
                eRow[display] = emptyRowString;
                if (value == null) value = "Id";
                eRow[value] = DBNull.Value;// 0;
                dt.Rows.InsertAt(eRow, 0);
            }
            rlk.NullText = emptyRowString;
            rlk.BeginUpdate();
            rlk.DisplayMember = display;
            if (value.Trim().Length > 0)
                rlk.ValueMember = value;
            if (dt != null) rlk.DataSource = dt;
            else rlk.DataSource = source;
            rlk.EndUpdate();
        }

        #region IEnumerable Bind

        public static void Bind(this RepositoryItemLookUpEdit rlk, DataTable dataTable, string display, string value)
        {
            BindEnumarable(rlk, dataTable, display, value, null, false, "Belirtilmedi");
        }

        public static void Bind(this RepositoryItemLookUpEdit rlk, DataTable dataTable, string display,
            string value, bool emptyRow, string emptyRowString)
        {
            BindEnumarable(rlk, dataTable, display, value, null, emptyRow, emptyRowString);
        }

        public static void Bind<T>(this RepositoryItemLookUpEdit rlk, IEnumerable<T> source,
           string display, string value)
        {
            BindEnumarable(rlk, source, display, value, null, false, "Belirtilmedi");
        }

        public static void Bind<T>(this RepositoryItemLookUpEdit rlk, IEnumerable<T> source,
         string display, string value, string header)
        {
            LookUpColumnInfo[] columns = new LookUpColumnInfo[]
            {
                new LookUpColumnInfo()
                {
                    FieldName=display,Caption=header
                }
            };
            BindEnumarable(rlk, source, display, value, columns, false, "Belirtilmedi");
        }

        public static void Bind<T>(this RepositoryItemLookUpEdit rlk, IEnumerable<T> source, string display,
            string value, LookUpColumnInfo[] columns)
        {
            BindEnumarable(rlk, source, display, value, columns, false, "Belirtilmedi");
        }

        public static void Bind<T>(this RepositoryItemLookUpEdit rlk, IEnumerable<T> source, string display,
         string value, LookUpColumnInfo[] columns, bool emptyItem)
        {
            BindEnumarable(rlk, source, display, value, columns, emptyItem, "Belirtilmedi");
        }

        public static void Bind<T>(this RepositoryItemLookUpEdit rlk, IEnumerable<T> source, string display,
            string value, LookUpColumnInfo[] columns, bool emptyItem, string emptyItemString)
        {
            BindEnumarable(rlk, source, display, value, columns, emptyItem, emptyItemString);
        }

        public static void Bind<T>(this RepositoryItemLookUpEdit rlk, IEnumerable<T> source, string display,
            string value, string header, bool emptyItem, string emptyItemString)
        {
            LookUpColumnInfo[] columns = new LookUpColumnInfo[]
            {
                new LookUpColumnInfo()
                {
                    FieldName=display,Caption=header
                }
            };
            BindEnumarable(rlk, source, display, value, columns, emptyItem, emptyItemString);
        }

        public static void Bind<T>(this RepositoryItemLookUpEdit rlk, IEnumerable<T> source, string display,
            string value, string header, bool emptyItem)
        {
            LookUpColumnInfo[] columns = new LookUpColumnInfo[]
            {
                new LookUpColumnInfo()
                {
                    FieldName=display,Caption=header
                }
            };
            BindEnumarable(rlk, source, display, value, columns, emptyItem, "Belirtilmedi");
        }

        #endregion

        #region Enum Bind

        public static void BindEnum(this RepositoryItemLookUpEdit rlk, Type enumType, string header,
            bool emptyItem, string emptyItemString)
        {
            BindIList(rlk, enumType.ToValueList(), header, emptyItem, emptyItemString);
        }

        public static void BindEnum(this RepositoryItemLookUpEdit rlk, Type enumType,
            string header, bool emptyItem)
        {
            BindIList(rlk, enumType.ToValueList(), header, emptyItem, "Belirtilmedi");
        }

        public static void BindEnum(this RepositoryItemLookUpEdit rlk, Type enumType, string header)
        {
            BindIList(rlk, enumType.ToValueList(), header, false, "Belirtilmedi");
        }

        private static void BindIList(this RepositoryItemLookUpEdit rlk, Dictionary<int, string> list,
            string header, bool emptyItem, string emptyItemString)
        {
            rlk.BindTable(list.ToDataTable(), "Value", "Key", header, emptyItem, emptyItemString);
        }

        private static void BindTable(this RepositoryItemLookUpEdit rlk, DataTable table, string display,
            string value, string header, bool emptyItem, string emptyItemString)
        {
            rlk.BeginInit();
            rlk.Columns.Clear();
            rlk.Columns.Add(new LookUpColumnInfo() { FieldName = "Value", Caption = header });

            rlk.EndInit();

            if (emptyItem)
            {
                DataRow row = table.NewRow();
                row[display] = emptyItemString;
                row[value] = 0;//DBNull.Value;
                table.Rows.InsertAt(row, 0);
            }
            rlk.NullText = emptyItemString;
            //rlk.BeginUpdate();
            rlk.DisplayMember = display;
            rlk.ValueMember = value;
            rlk.DataSource = table;
            //rlk.EndUpdate();
        }

        #endregion

        #endregion

        #region RadioGroup

        private static void BindTable(this RadioGroup rg, DataTable table, string display, string value)
        {
            rg.Properties.BeginInit();
            rg.Properties.Items.Clear();
            rg.Properties.EndInit();

            rg.Properties.BeginUpdate();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                rg.Properties.Items.Add(new RadioGroupItem
                    (table.Rows[i]["Key"].ToString(), table.Rows[i]["Value"].ToString()));
            }

            rg.Properties.EndUpdate();
        }

        public static void BindEnum(this RadioGroup rg, Type enumType)
        {
            BindIList(rg, enumType.ToValueList());
        }

        private static void BindIList(this RadioGroup rg, Dictionary<int, string> list)
        {
            var dt = list.ToDataTable();
            rg.BindTable(dt, "Value", "Key");
        }

        #endregion
    }
}
