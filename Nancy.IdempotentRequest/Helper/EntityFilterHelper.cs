using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Nancy.IdempotentRequest.Helper
{
    public static class EntityFilterHelper
    {
        public static string GenerateETag(Stream stream)
        {
            using (var sha1 = new SHA1CryptoServiceProvider())
            {
                var hash = sha1.ComputeHash(stream);

                return string.Concat("\"", ByteArrayToString(hash), "\"");
            }
        }

        private static string ByteArrayToString(byte[] data)
        {
            var output = new StringBuilder(data.Length);
            for (int i = 0; i < data.Length; i++)
            {
                output.Append(data[i].ToString("X2"));
            }

            return output.ToString();
        }
    }
}