using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Globalization;

namespace Ekip.Framework.Core
{
    public static class StringExtensions
    {
        #region Methods
        public static bool StartWithLike(this string stringvalue, string likevalue)
        {
            bool b = false;
            if (likevalue.StartsWith("%"))
                b = stringvalue.Contains(likevalue.Substring(1));
            else
                b = stringvalue.StartsWith(likevalue);
            return b;
        }
        public static void Clear(this StringBuilder s)
        {
            s.Length = 0;
        }

        public static string ToEng(this string source)
        {
            source = source.Replace('Ç', 'C');
            source = source.Replace('ç', 'c');
            source = source.Replace('Ş', 'S');
            source = source.Replace('ş', 's');
            source = source.Replace('Ğ', 'G');
            source = source.Replace('ğ', 'g');
            source = source.Replace('Ü', 'U');
            source = source.Replace('ü', 'u');
            source = source.Replace('Ö', 'O');
            source = source.Replace('ö', 'o');
            source = source.Replace('İ', 'I');
            source = source.Replace('ı', 'i');
            return source;

        }
        public static Guid ToGuid(this string input)
        {
            var guid = @"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]" + @"{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$";
            return input.IsNotNullOrEmpty()
                && input.IsRegexMatch(guid) ? new Guid(input) : Guid.Empty;
        }
        public static T ToEnum<T>(this string value) where T : struct
        {
            System.Diagnostics.Debug.Assert(!string.IsNullOrEmpty(value));
            return (T)Enum.Parse(typeof(T), value, true);
        }
        public static string Format(this string format, params object[] args)
        {
            return String.Format(format, args);
        }
        public static string Format(this string format, object arg, params object[] additionalArgs)
        {
            if (additionalArgs == null || additionalArgs.Length == 0)
            {
                return string.Format(format, arg);
            }
            else
            {
                return string.Format(format, new object[] { arg }.Concat(additionalArgs).ToArray());
            }
        }
        #endregion

        #region Regex
        public static bool IsRegexMatch(this string input, string pattern)
        {
            return Regex.IsMatch(input, pattern);
        }
        public static bool IsRegexMatch(this string input, string pattern, RegexOptions options)
        {
            return Regex.IsMatch(input, pattern, options);
        }
        public static bool IsRegexMatchAny(this string input, params string[] patterns)
        {
            var isMatch = false;
            foreach (string pattern in patterns)
            {
                isMatch |= input.IsRegexMatch(pattern);
            }
            return isMatch;
        }
        public static bool IsRegexMatchAny(this string input, RegexOptions options, params string[] patterns)
        {
            var isMatch = false;
            foreach (string pattern in patterns)
            {
                isMatch |= input.IsRegexMatch(pattern, options);
            }
            return isMatch;
        }
        public static bool IsRegexMatchAll(this string input, params string[] patterns)
        {
            var isMatch = true;
            foreach (string pattern in patterns)
            {
                isMatch &= input.IsRegexMatch(pattern);
            }
            return isMatch;
        }
        public static bool IsRegexMatchAll(this string input, RegexOptions options, params string[] patterns)
        {
            var isMatch = true;
            foreach (string pattern in patterns)
            {
                isMatch &= input.IsRegexMatch(pattern, options);
            }
            return isMatch;
        }
        public static bool EmailTest(this string email)
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
              + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
              + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }
        #endregion

        #region String Extensions

        public static void Clear(this string str)
        {
            str = string.Empty;
        }

        /// <summary>
        /// Extends String to escape embedded single and double quotes.
        /// </summary>
        /// <param name="s">Extension Method Parameter:: this is an Extension reference to the actionable string.</param>
        /// <returns>The properly escaped string.</returns>
        public static string EscapeEmbeddedQuotes(this string s)
        {
            s = s.Replace("\"", "\"\"");
            s = s.Replace("\'", "\'\'");

            return s;
        }

        /// <summary>
        /// Extends String to right adjust to the specified length, padding leading characters with the specified FillCharacter.
        /// </summary>
        /// <code>
        /// string s = "1234";
        /// string x = s.RightAdjust(10, '0');
        /// // s now contains "0000001234"
        /// </code>
        /// <param name="s">Extension Method Parameter:: this is an Extension reference to the actionable string.</param>
        /// <param name="Size">The final size of the string</param>
        /// <param name="FillCharacter">The character used to fill the leading string positions.</param>
        /// <returns>The adjusted string.</returns>
        public static string RightAdjust(this string s, int Size, char FillCharacter)
        {
            string ch = FillCharacter.ToString();

            if (s.Length > Size)
            {
                throw new ArgumentException("Size of Value larger than Requested Size.");
            }

            while (s.Length < Size)
            {
                s = ch + s;
            }

            return s;
        }

        /// <summary>
        /// Extends String to right adjust to the specified length, padding leading characters with blanks.
        /// </summary>
        /// <code>
        /// string s = "C# ROCKS";
        /// string x = s.RightAdjust(10);
        /// // s now contains "  C# ROCKS"
        /// </code>
        /// <param name="s">Extension Method Parameter:: this is an Extension reference to the actionable string.</param>
        /// <param name="Size">The final size of the string</param>
        /// <returns>The adjusted string.</returns>
        public static string RightAdjust(this string s, int Size)
        {
            return s.RightAdjust(Size, ' ');
        }

        /// <summary>
        /// Extends String to reverse the contents of the string.
        /// </summary>
        /// <param name="s">Extension Method Parameter:: this is an Extension reference to the actionable string.</param>
        /// <returns>The string contents in reversed order.</returns>
        public static string Reverse2(this string s)
        {
            char[] chars = s.ToCharArray();
            StringBuilder b = new StringBuilder();
            for (int i = chars.Count() - 1; i >= 0; i--)
            {
                b.Append(chars[i]);
            }
            return b.ToString();
        }

        /// <summary>
        /// Extends String to determine if the string matches a Regular Expression.
        /// </summary>
        /// <code>
        /// if (s.IsRegexMatch("\r\n", RegexOptions.Explicit))
        /// </code>
        /// <param name="s">Extension Method Parameter:: this is an Extension reference to the actionable string.</param>
        /// <param name="pattern">The Regular Expression Pattern to match.</param>
        /// <param name="options">The Regular Expression Options for the Match determination.</param>
        /// <returns>True if the string matches the pattern, false otherwise.</returns>
        public static bool IsRegexMatch2(this string s, string pattern, RegexOptions options)
        {
            return Regex.IsMatch(s, pattern, options);
        }

        /// <summary>
        /// Extends String to determine if the string matches a Regular Expression using "RegexOptions.None".
        /// </summary>
        /// <code>
        /// if (s.IsRegexMatch("\r\n"))
        /// </code>
        /// <param name="s">Extension Method Parameter:: this is an Extension reference to the actionable string.</param>
        /// <param name="pattern">The Regular Expression Pattern to match.</param>
        /// <param name="options">The Regular Expression Options for the Match determination.</param>
        /// <returns>True if the string matches the pattern, false otherwise.</returns>
        public static bool IsRegexMatch2(this string s, string pattern)
        {
            return s.IsRegexMatch(pattern, RegexOptions.None);
        }

        public static string RemoveSpaceAreas(this string value)
        {
            return value.Replace(" ", "").Trim();
        }

        public static string RemoveMultipleSpaces(this string value)
        {
            string result = string.Empty;
            value = value.TrimStart().TrimEnd().Trim();
            var arr = value.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < arr.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(arr[i]))
                {
                    result += arr[i];
                    result += " ";
                }
            }
            result = result.TrimStart().TrimEnd().Trim();
            return result;
        }

        /// <summary>
        /// Formats a string to the current culture.
        /// </summary>
        /// <param name="formatString">The format string.</param>
        /// <param name="objects">The objects.</p
        public static string FormatCurrentCulture(string formatString, params object[] objects)
        {
            return string.Format(CultureInfo.CurrentCulture, formatString, objects);
        }

        #endregion

        #region IsValid

        public static bool IsEmpty(this StringBuilder instance)
        {
            return instance.Length < 1;
        }

        public static bool IsNotNullOrEmpty(this string input)
        {
            return String.IsNullOrEmpty(input.Trim());
        }

        public static bool IsValidPostCode(this string value)
        {
            return value.IsRegexMatch(@"\d\d\d\d\d");
        }

        public static bool IsValidEmail(this string value)
        {
            return value.IsRegexMatch(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}");
        }

        public static bool IsValidIpAddress(this string value)
        {
            return value.IsRegexMatch(@"\d\d?\d?\.\d\d?\d?\.\d\d?\d?\.\d\d?\d?");
        }

        public static bool IsValidUrl(this string value)
        {
            return value.IsRegexMatch(@"(((http|ftp)://)|(www\.))+(([a-zA-Z0-9\._-]+\.[a-zA-Z]{2,6})|([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))(/[a-zA-Z0-9\&amp;%_\./-~-]*)?");

        }

        public static bool IsValidPhone(this string value)
        {
            return value.IsRegexMatch(@"(\(\d\d\d\))?\d{1,3}-\d\d-\d\d (\(\d\HAT\))?");
        }

        #endregion

        #region Beetween

        public static string[] InBetween(this  string strSource, string strBegin, string strEnd,
                      bool includeBegin, bool includeEnd)
        {

            string[] result = { "", "" };

            int iIndexOfBegin = strSource.IndexOf(strBegin);

            if (iIndexOfBegin != -1)
            {

                // include the Begin string if desired

                if (includeBegin)

                    iIndexOfBegin -= strBegin.Length;

                strSource = strSource.Substring(iIndexOfBegin

                    + strBegin.Length);

                int iEnd = strSource.IndexOf(strEnd);

                if (iEnd != -1)
                {

                    // include the End string if desired

                    if (includeEnd)

                        iEnd += strEnd.Length;

                    result[0] = strSource.Substring(0, iEnd);

                    // advance beyond this segment

                    if (iEnd + strEnd.Length < strSource.Length)
                        result[1] = strSource.Substring(iEnd + strEnd.Length);
                }

            }

            else

                // stay where we are

                result[1] = strSource;

            return result;

        }

        public static string RemoveBetween(this string Source, string Begin, string End,
            bool removeBegin, bool removeEnd)
        {

            string[] result = InBetween(Begin, End, Source, removeBegin, removeEnd);

            if (result[0] != "")
            {

                return Source.Replace(result[0], "");

            }

            // nothing found between begin & end

            return Source;

        }

        public static string RemoveBetween(string Begin, string End, string Source)
        {

            // default behavior

            return RemoveBetween(Begin, End, Source, false, false);

        }

        #endregion

        #region Reverser - Strip - Right - Left - RightAdjust

        public static string Reverse(this string value)
        {
            char[] c = value.ToCharArray();
            Array.Reverse(c);
            return new string(c);
        }

        /// <summary>
        /// Strip a string of the specified character.
        /// </summary>
        /// <param name="s">the string to process</param>
        /// <param name="char">character to remove from the string</param>
        /// <example>
        /// string s = "abcde";
        /// 
        /// s = s.Strip('b');  //s becomes 'acde;
        /// </example>
        /// <returns></returns>
        public static string Strip(this string s, char character)
        {
            s = s.Replace(character.ToString(), "");

            return s;
        }

        /// <summary>
        /// Strip a string of the specified characters.
        /// </summary>
        /// <param name="s">the string to process</param>
        /// <param name="chars">list of characters to remove from the string</param>
        /// <example>
        /// string s = "abcde";
        /// 
        /// s = s.Strip('a', 'd');  //s becomes 'bce;
        /// </example>
        /// <returns></returns>
        public static string Strip(this string s, params char[] chars)
        {
            foreach (char c in chars)
            {
                s = s.Replace(c.ToString(), "");
            }

            return s;
        }

        /// <summary>
        /// Strip a string of the specified substring.
        /// </summary>
        /// <param name="s">the string to process</param>
        /// <param name="subString">substring to remove</param>
        /// <example>
        /// string s = "abcde";
        /// 
        /// s = s.Strip("bcd");  //s becomes 'ae;
        /// </example>
        /// <returns></returns>
        public static string Strip(this string value, string subString)
        {
            value = value.Replace(subString, "");

            return value;
        }

        /// <summary>
        /// Returns the last few characters of the string with a length
        /// specified by the given parameter. If the string's length is less than the 
        /// given length the complete string is returned. If length is zero or 
        /// less an empty string is returned
        /// </summary>
        /// <param name="s">the string to process</param>
        /// <param name="length">Number of characters to return</param>
        /// <returns></returns>
        public static string Right(this string s, int length)
        {
            length = Math.Max(length, 0);

            if (s.Length > length)
            {
                return s.Substring(s.Length - length, length);
            }
            else
            {
                return s;
            }
        }

        /// <summary>
        /// Returns the first few characters of the string with a length
        /// specified by the given parameter. If the string's length is less than the 
        /// given length the complete string is returned. If length is zero or 
        /// less an empty string is returned
        /// </summary>
        /// <param name="s">the string to process</param>
        /// <param name="length">Number of characters to return</param>
        /// <returns></returns>
        public static string Left(this string s, int length)
        {
            length = Math.Max(length, 0);

            if (s.Length > length)
            {
                return s.Substring(0, length);
            }
            else
            {
                return s;
            }
        }

        public static string RightAdjust2(string s, int Size, char FillCharacter)
        {
            string ch = FillCharacter.ToString();

            if (s.Length > Size)
            {
                throw new ArgumentException("Size of Value larger than Requested Size.");
            }

            while (s.Length < Size)
            {
                s = ch + s;
            }

            return s;
        }
        public static string RightAdjust2(this string s, int Size)
        {
            return s.RightAdjust(Size, ' ');
        }

        #endregion

        #region Encrypt & Decrypt

        /// <summary>
        /// Encryptes a string using the supplied key. Encoding is done using RSA encryption.
        /// </summary>
        /// <param name="stringToEncrypt">String that must be encrypted.</param>
        /// <param name="key">Encryptionkey.</param>
        /// <returns>A string representing a byte array separated by a minus sign.</returns>
        /// <exception cref="ArgumentException">Occurs when stringToEncrypt or key is null or empty.</exception>
        public static string Encrypt(this string stringToEncrypt, string key)
        {
            if (string.IsNullOrEmpty(stringToEncrypt))
            {
                throw new ArgumentException("An empty string value cannot be encrypted.");
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("Cannot encrypt using an empty key. Please supply an encryption key.");
            }

            CspParameters cspp = new CspParameters();
            cspp.KeyContainerName = key;

            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cspp);
            rsa.PersistKeyInCsp = true;

            byte[] bytes = rsa.Encrypt(System.Text.UTF8Encoding.UTF8.GetBytes(stringToEncrypt), true);

            return BitConverter.ToString(bytes);
        }

        /// <summary>
        /// Decryptes a string using the supplied key. Decoding is done using RSA encryption.
        /// </summary>
        /// <param name="stringToDecrypt">String that must be decrypted.</param>
        /// <param name="key">Decryptionkey.</param>
        /// <returns>The decrypted string or null if decryption failed.</returns>
        /// <exception cref="ArgumentException">Occurs when stringToDecrypt or key is null or empty.</exception>
        public static string Decrypt(this string stringToDecrypt, string key)
        {
            string result = null;

            if (string.IsNullOrEmpty(stringToDecrypt))
            {
                throw new ArgumentException("An empty string value cannot be encrypted.");
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("Cannot decrypt using an empty key. Please supply a decryption key.");
            }

            try
            {
                CspParameters cspp = new CspParameters();
                cspp.KeyContainerName = key;

                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cspp);
                rsa.PersistKeyInCsp = true;

                string[] decryptArray = stringToDecrypt.Split(new string[] { "-" }, StringSplitOptions.None);
                byte[] decryptByteArray = Array.ConvertAll<string, byte>(decryptArray, (s => Convert.ToByte(byte.Parse(s, System.Globalization.NumberStyles.HexNumber))));


                byte[] bytes = rsa.Decrypt(decryptByteArray, true);

                result = System.Text.UTF8Encoding.UTF8.GetString(bytes);

            }
            finally
            {

            }

            return result;
        }


        static string validationKey="A06BDCF2F6CF.A.VERY.LONG.44F13E76184945A7C477601";
        static string decryptionKey = "99079B21C2F3644.A.BIT.SHORTER.BB81C7E9D58378";

        public static void Encrypt(this string fileName)
        {
            string password = validationKey;
            string outFileName = string.Format("{0}.enc", fileName);
            try
            {
                byte[] saltValueBytes = Encoding.ASCII.GetBytes(decryptionKey);
                Rfc2898DeriveBytes passwordKey = new Rfc2898DeriveBytes(password, saltValueBytes);

                RijndaelManaged alg = new RijndaelManaged();
                alg.Key = passwordKey.GetBytes(alg.KeySize / 8);
                alg.IV = passwordKey.GetBytes(alg.BlockSize / 8);

                System.IO.FileStream inFile = new System.IO.FileStream(fileName, 
                    System.IO.FileMode.Open, System.IO.FileAccess.Read);
                byte[] fileData = new byte[inFile.Length];
                inFile.Read(fileData, 0, (int)inFile.Length);

                ICryptoTransform encryptor = alg.CreateEncryptor();
                System.IO.FileStream outFile = 
                    new System.IO.FileStream(outFileName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
                CryptoStream encryptStream = new CryptoStream(outFile, encryptor, CryptoStreamMode.Write);
                encryptStream.Write(fileData, 0, fileData.Length);

                encryptStream.Close();
                inFile.Close();
                outFile.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Decrypt(this string fileName)
        {
            string password = validationKey;
            string outFileName = string.Format("{0}.dec", fileName);
            try
            {
                byte[] saltValueBytes = Encoding.ASCII.GetBytes(decryptionKey);
                Rfc2898DeriveBytes passwordKey = new Rfc2898DeriveBytes(password, saltValueBytes);

                RijndaelManaged alg = new RijndaelManaged();
                alg.Key = passwordKey.GetBytes(alg.KeySize / 8);
                alg.IV = passwordKey.GetBytes(alg.BlockSize / 8);

                ICryptoTransform decryptor = alg.CreateDecryptor();
                System.IO.FileStream inFile = new System.IO.FileStream(fileName, 
                    System.IO.FileMode.Open, 
                    System.IO.FileAccess.Read);
                CryptoStream decryptStream = new CryptoStream(inFile, decryptor, CryptoStreamMode.Read);
                byte[] fileData = new byte[inFile.Length];
                decryptStream.Read(fileData, 0, (int)inFile.Length);

                System.IO.FileStream outFile = new System.IO.FileStream(outFileName, System.IO.FileMode.OpenOrCreate, 
                    System.IO.FileAccess.Write);
                outFile.Write(fileData, 0, fileData.Length);

                decryptStream.Close();
                inFile.Close();
                outFile.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        public static bool IsStringEqual(string tagText, string tagType)
        {
            return (string.Compare(tagText, tagType, true) == 0) ? true : false;
        }

        public static byte TryParseByte(this string stringValue, byte defaultValue)
        {
            byte result;

            if (!byte.TryParse(stringValue, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out result))
            {
                result = defaultValue;
            }
            return result;
        }

        public static ushort TryParseUshort(this string stringValue, ushort defaultValue)
        {
            ushort result;
            if (!ushort.TryParse(stringValue, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out result))
            {
                result = defaultValue;
            }
            return result;
        }

        public static object TryParseEnum(this Type enumType, string stringValue, object defaultValue)
        {
            object result = defaultValue;
            try
            {
                result = Enum.Parse(enumType, stringValue, true);
            }
            catch (Exception)
            {
                result = defaultValue;
            }
            return result;
        }
    }
}
