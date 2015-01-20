using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DdmHelpers.Checksum
{
    public class ChecksumHelper
    {
        public static string GetFileChecksum(string filePath)
        {
            using (var fileStream = File.OpenRead(filePath))
            {
                return GetHashFromStream(fileStream);
            }
        }

        private static string GetHashFromStream(Stream fielStream)
        {
            var algorithm = (HashAlgorithm)new MD5CryptoServiceProvider();

            var hash = algorithm.ComputeHash(fielStream);

            var resultHashString = string.Empty;

            for (var i = 0; i <= hash.Length - 1; i++)
            {
                resultHashString += hash[i].ToString("x2");
            }

            return resultHashString;
        }
    }
}
