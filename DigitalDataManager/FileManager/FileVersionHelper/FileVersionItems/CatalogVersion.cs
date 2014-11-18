using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DdmHelpers.Serialize;

namespace FileSystemManager.FileVersionHelper.FileVersionItems
{
    public class CatalogVersion
    {
        public VersionNumber VersionNumber { get; set; }
        public List<FileVersion> Files { get; set; }

        public string CatalogPath { get; set; }

        public CatalogVersion()
        {

        }

        public CatalogVersion(string catalogPath)
        {
            CatalogPath = catalogPath;

            Files = new List<FileVersion>();

            VersionNumber = new VersionNumber() { Number = 0 };

            var filePaths = Directory.GetFiles(CatalogPath, ClientFileManager.SearchPattern);

            foreach (var filePath in filePaths)
            {
                var vers = new FileVersion(filePath);

                Files.Add(vers);
            }
        }

        public void CreateEmpty(string catalogPath)
        {
            CatalogPath = catalogPath;

            Files = new List<FileVersion>();

            VersionNumber = new VersionNumber() { Number = 0 };
        }

        public string ToXmlString()
        {
            var stream = XmlSerializerHelper.Serialize<CatalogVersion>(this);

            stream.Position = 0;

            using (var reader = new StreamReader(stream, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }

        public override bool Equals(object obj)
        {
            var res = true;

            var item = (CatalogVersion) obj;

            if (item.Files.Count == Files.Count)
            {
                foreach (var fileVersion in item.Files)
                {
                    if (Files.Contains(fileVersion) == false)
                    {
                        res = false;
                    }
                }
            }
            else
            {
                res = false;
            }

            return res;
        }
    }
}
