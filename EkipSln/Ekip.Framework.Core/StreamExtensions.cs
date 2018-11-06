using System;
using System.IO;
using System.Reflection;

namespace Ekip.Framework.Core
{
    public static class StreamExtensions
    {   
        public static string FileToString(string fileName)
        {
            string str = string.Empty;
            try
            {
                using (StreamReader reader = File.OpenText(fileName))
                {
                    str = reader.ReadToEnd();
                    reader.Close();
                }
            }
            catch (IOException ex)
            {
                throw ex;
            }
            return str;
        }

        public static string StreamToString(this Stream stream)
        {
            try
            {
                string result = string.Empty;
                if (stream.CanSeek)
                {
                    stream.Seek(0, SeekOrigin.Begin);
                }
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }
                return result;
            }
            catch (IOException ex)
            {
                throw ex;
            }
        }

        public static string ResourceToString(string resourceName)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            return ResourceToString(resourceName, asm);
        }

        public static string ResourceByFullNameToString(string resourceName, Assembly asm)
        {
            Stream stream = null;
            try
            {
                stream = asm.GetManifestResourceStream(resourceName);
            }
            catch (IOException ex)
            {
                throw ex;
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
            if (stream == null)
            {
                throw new ApplicationException("Couldn't find embedded resource " + resourceName);
            }
            return StreamToString(stream);
        }

        public static void ResourceToFile(string resourceName, Assembly asm, string fileName)
        {
            Stream stream = GetManifestResourceStream(resourceName, asm);

            using (StreamReader reader = new StreamReader(stream))
            {
                using (StreamWriter writer = new StreamWriter(fileName, false))
                {
                    writer.Write(reader.ReadToEnd());
                    
                    writer.Close();
                }
            }
        }

        public static string ResourceToString(string resourceName, Assembly asm)
        {
            Stream stream = GetManifestResourceStream(resourceName, asm);
            return StreamToString(stream);
        }

        public static Stream GetManifestResourceStream(string resourceName, Assembly asm)
        {
            string name = asm.GetName().Name + "." + resourceName;
            Stream stream = asm.GetManifestResourceStream(name);
            if (stream == null)
            {
                throw new ApplicationException("Couldn't find embedded resource " + name);
            }
            return stream;
        }

        public static void SaveToFile(byte[] data, string fileName)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName, false))
                {
                    writer.BaseStream.Write(data, 0, data.Length);
                    writer.Close();
                }
            }
            catch (IOException ex)
            {
                throw ex;
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
        }

        public static void SaveToFile(this Stream stream, string fileName)
        {
            try
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    StreamWriter writer = new StreamWriter(fileName, false);
                    writer.WriteLine(reader.ReadToEnd());
                    writer.Close();
                }
            }
            catch (IOException ex)
            {
                throw ex;
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
        }

        public static void SaveStringToFile(string sData, string fileName)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName, false))
                {
                    writer.Write(sData);
                    writer.Close();
                }
            }
            catch (IOException ex)
            {
                throw ex;
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
        }

        public static void Copy(this Stream fromStream, Stream toStream)
        {
            try
            {
                using (StreamReader reader = new StreamReader(fromStream))
                {
                    using (StreamWriter writer = new StreamWriter(toStream))
                    {
                        writer.WriteLine(reader.ReadToEnd());
                        writer.Flush();
                    }
                }
            }
            catch (IOException ex)
            {
                throw ex;
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
        }
       
    }
}
