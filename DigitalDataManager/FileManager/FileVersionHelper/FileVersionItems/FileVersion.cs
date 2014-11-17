using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileSystemManager.ChecksumHelper;

namespace FileSystemManager.FileVersionHelper.FileVersionItems
{
    public class FileVersion
    {
        public string Checksum { get; set; }
        public string FullPath { get; set; }
        public string FileName { get; set; }

        public FileVersion()
        {
            
        }

        public FileVersion(string filePath)
        {
            FullPath = filePath;

            FileName = Path.GetFileNameWithoutExtension(FullPath);

            Checksum = CsHelper.GetFileChecksum(FullPath);
        }

        public override bool Equals(object obj)
        {
            var item = (FileVersion) obj;

            return item.FileName == FileName;
            //&& item.FullPath == FullPath;
        }
    }
}
