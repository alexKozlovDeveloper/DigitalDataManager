using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DdmHelpers.Serialize;
using FileSystemManager.FileVersionHelper.FileVersionItems;

namespace FileSystemManager.FileReader
{
    public static class XmlVersionReader
    {
        public static CatalogVersion ReadVersion(string filePath)
        {
            var ms = FileReaderHelper.ReadStreamFromFile(filePath);

            var vers = XmlSerializerHelper.Deserialize<CatalogVersion>(ms);

            return vers;
        }

        public static void WriteVeriosn(string filePath, CatalogVersion obj)
        {
            var ms = XmlSerializerHelper.Serialize<CatalogVersion>(obj);

            FileReaderHelper.WriteStreamInFile(ms, filePath);
        }
    }
}
