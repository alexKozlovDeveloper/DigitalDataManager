using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemManager.ChecksumHelper
{
    public class CsHelper
    {
        public static string GetFileChecksum(string filePath)
        {
            var fi = new FileInfo(filePath);

            var checksum = GetHashFromStream(fi.OpenRead());

            return checksum;
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
