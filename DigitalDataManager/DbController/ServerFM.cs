using DdmHelpers.FileReader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbController
{
    public static class ServerFM
    {
        public static string root = @"C:\Ddm\Server\Files";

        public static void WriteFile(byte[] bytes, Guid fileId, string ext)
        {
            var filePath = root + "\\" + fileId + ext;

            //FileReaderHelper.WriteStreamInFile(fileStream, filePath);

            File.WriteAllBytes(filePath, bytes);
        }

        public static Stream ReadFile(Guid fileId, string ext)
        {
            var filePath = root + "\\" + fileId + ext;

            return FileReaderHelper.ReadStreamFromFile(filePath);
        }
    }
}
