using System;
using System.Xml;
using System.Web;
using System.IO;
using System.Reflection;

namespace Ekip.Framework.Core.Caching
{
    public class CachedDocumentManager
    {
        public static string GetString(string KeyField, string FilePath, string xQuery, string ValueField)
        {
            string Result = string.Empty;

            XmlDocument Document = GetCachedDocument(FilePath);

            try
            {
                XmlNode node = Document.SelectSingleNode(String.Format(xQuery, KeyField));

                if (node == null)
                    Result = "Bilinmiyor";
                else
                    Result = node.SelectSingleNode(ValueField).InnerText;
            }
            catch (Exception)
            {
            }

            if (Result == "Bilinmiyor") throw (new Exception(KeyField + " bulunamadý"));
            return Result;
        }


        public static XmlNodeList GetXmlNodeList(string FilePath, string xQuery)
        {
            string Result = string.Empty;
            XmlNodeList oList = null;

            XmlDocument Document = GetCachedDocument(FilePath);
            try
            {
                oList = Document.SelectNodes(xQuery);
            }
            catch (Exception)
            {
            }
            return oList;
        }

        public static bool GetBool(string KeyField, string FilePath, string xQuery, string ValueField)
        {
            bool blnResult = false;
            try
            {
                blnResult = GetString(KeyField, FilePath, xQuery, ValueField).ToLower().Equals("true");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return blnResult;
        }

        public static int GetInt32(string KeyField, string FilePath, string xQuery, string ValueField)
        {
            int intResult = 0;
            try
            {
                intResult = Convert.ToInt32(GetString(KeyField, FilePath, xQuery, ValueField));
            }
            catch (Exception ex)
            {
                string sMessage = string.Format("KeyField={0}, FilePath={1}, xQuery={2}, ValueField={3}", 
                    KeyField, FilePath, xQuery, ValueField);
                throw ex;
            }
            return intResult;
        }

        public static long GetLong(string KeyField, string FilePath, string xQuery, string ValueField)
        {
            int lResult = 0;
            try
            {
                lResult = Convert.ToInt16(GetString(KeyField, FilePath, xQuery, ValueField));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lResult;
        }

        /// <summary>
        /// Bu fonksiyon istenen xml dokümanýný döner.
        /// </summary>
        public static XmlDocument GetCachedDocument(string FilePath)
        {
            XmlDocument Document = null;

            if (!string.IsNullOrEmpty(FilePath))
            {
                System.Web.Caching.Cache oCache = (System.Web.HttpContext.Current != null) ? System.Web.HttpContext.Current.Cache : HttpRuntime.Cache;

                if (oCache[FilePath] == null)
                {
                    using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(FilePath))
                    {
                        // First time or cache expired.
                        Document = new XmlDocument();
                        Document.Load(stream);
                        //CacheDependency oDependency = new CacheDependency(FilePath);
                        oCache.Insert(FilePath, Document);
                    }
                }
                else
                    Document = (XmlDocument)oCache[FilePath];
            }
            return Document;
        }
    }
}
