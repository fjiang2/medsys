using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tie;

namespace Sys
{
    public static class StringExtension
    {
        #region String Encrypt/Decrypt

        public static string Encrypt(this string jsonString)
        {
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            byte[] bytes = encoding.GetBytes(jsonString);
            return HostType.ByteArrayToHexString(bytes);
        }

        public static string Decrypt(this string hexString)
        {
            byte[] bytes = HostType.HexStringToByteArray(hexString);
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            return encoding.GetString(bytes);
        }

        public static byte[] GetBytes(this string str)
        {
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            return encoding.GetBytes(str);
        }

        public static string GetString(this byte[] bytes)
        {
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            return encoding.GetString(bytes);
        }

        #endregion

        public static string ToSentence(this string sent)
        {
            return string.Join(" ", 
                sent.Trim().Split(new char[] { ' ' })
                .Where(word => word !="")
                .Select(word => word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower())
                );
        }
    }
}
