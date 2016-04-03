using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WProject.GenericLibrary.Helpers.Extensions
{
    public static class StringEx
    {
        public static bool IsNullOrEmpty(this string text) => string.IsNullOrEmpty(text);

        public static string DefaultIfEmpty(this string text, string @default) => text.IsNullOrEmpty() ? @default : text;

        public static string ToMd5(this string text)
        {
            MD5 md5 = MD5.Create();

            byte[] inputBytes = Encoding.ASCII.GetBytes(text);

            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();

            foreach (byte mt in hash)
                sb.Append(mt.ToString("X2"));

            return sb.ToString();
        }
    }
}
