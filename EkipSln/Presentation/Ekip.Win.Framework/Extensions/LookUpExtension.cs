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
        #region Enum Bind

        public static void BindEnum(this LookUpEdit lk, Type enumType)
        {
            var source = enumType.ToValueList();
            DescriptionAttribute[] attributes = (DescriptionAttribute[])enumType.GetCustomAttributes(typeof(DescriptionAttribute), false);
            string header = (attributes.Length > 0) ? attributes[0].Description : enumType.ToString();
            lk.BindTable(source.ToDataTable(), "Value", "Key", header);
        }

        public static void BindEnum(this RepositoryItemLookUpEdit lk, Type enumType)
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
            lk.Properties.NullText = header;
            lk.Properties.BeginUpdate();
            lk.Properties.DisplayMember = display;
            lk.Properties.ValueMember = value;
            lk.Properties.DataSource = table;
            lk.Properties.EndUpdate();
        }

        private static void BindTable(this RepositoryItemLookUpEdit lk, DataTable table, string display, string value, string header)
        {
            lk.BeginInit();
            lk.Columns.Clear();
            lk.Columns.Add(new LookUpColumnInfo() { FieldName = "Value", Caption = string.Format("{0} Seçiniz", header) });
            lk.Columns[0].AllowSort = DevExpress.Utils.DefaultBoolean.False;
            lk.ShowHeader = true;
            lk.EndInit();
            lk.NullText = header;
            lk.BeginUpdate();
            lk.DisplayMember = display;
            lk.ValueMember = value;
            lk.DataSource = table;
            lk.EndUpdate();
        }

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
