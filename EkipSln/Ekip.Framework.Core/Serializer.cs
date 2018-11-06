using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Ekip.Framework.Core
{
    public static class Serializer
    {
        public static string XmlSerialize<T>(this T source)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                System.Xml.Serialization.XmlSerializer xsr = new System.Xml.Serialization.XmlSerializer(typeof(T));
                xsr.Serialize(ms, source);
                ms.Position = 0;
                using (StreamReader reader = new StreamReader(ms))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public static T XmlDeserialize<T>(this string source)
        {
            using (MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(source)))
            {
                System.Xml.Serialization.XmlSerializer xdsr = new System.Xml.Serialization.XmlSerializer(typeof(T));
                return (T)xdsr.Deserialize(ms);
            }
        }

        public static string JsonSerialize<T>(this T source)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(source.GetType());
                serializer.WriteObject(ms, source);
                ms.Position = 0;
                using (StreamReader reader = new StreamReader(ms))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public static T JsonDeserialize<T>(this string source)
        {
            using (MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(source)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                return (T)serializer.ReadObject(ms);
            }
        }

        public static dynamic JsonDeserialize(this string source)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject(source);
        }
    }
}
