using System;
using System.Collections.Generic;
using System.Xml;
using System.Data;
using DevExpress.XtraEditors.Repository;
using Ekip.Framework.Core.Caching;
using Ekip.Framework.Core;
using DevExpress.XtraEditors.Controls;

namespace Ekip.Win.Framework
{
    public static class ListManager
    {
        //const string lookUpResourcePath = "Ekip.Framework.Core.Resources.LookUpList.xml";
        //const string validationRulesResourcePath = "Ekip.Framework.Core.Resources.Validation.xml";

        //static DataTable GetListItem(string listType)
        //{
        //    string lang = "@Description";
        //    string xQuery = String.Format("Lists/List[@Key='{0}']/Item", listType);
        //    Dictionary<string, int> dict = new Dictionary<string, int>();

        //    foreach (XmlNode node in CachedDocumentManager.GetXmlNodeList(lookUpResourcePath, xQuery))
        //    {
        //        int v = int.Parse(node.SelectSingleNode("@Value").InnerText);
        //        string n;
        //        XmlNode nameNode = node.SelectSingleNode(lang);
        //        if (nameNode == null) nameNode = node.SelectSingleNode("@Description");
        //        n = (nameNode == null) ? "Unknown" : nameNode.InnerText;

        //        if (!dict.ContainsKey(n))
        //            dict.Add(n, v);
        //    }
            
        //    DataTable listTable = dict.ToDataTable();
        //    return listTable;
        //}

        //public static DataTable BindListItem(this RepositoryItemLookUpEdit repositoryItem, string listType, string listDesc)
        //{
        //    DataTable table = GetListItem(listType);
        //    if (table.Rows.Count > 0)
        //    {
        //        repositoryItem.BeginUpdate();
        //        repositoryItem.Columns.Clear();
        //        repositoryItem.Columns.Add(new LookUpColumnInfo("Key", listDesc));
        //        repositoryItem.DisplayMember = "Key";
        //        repositoryItem.ValueMember = "Value";
        //        repositoryItem.DataSource = table;
        //        repositoryItem.EndUpdate();
        //    }
        //    return table;
        //}
    }
}
