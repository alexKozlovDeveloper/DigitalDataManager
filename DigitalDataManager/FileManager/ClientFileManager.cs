using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileSystemManager.FileVersionHelper;

namespace FileSystemManager
{
    public class ClientFileManager
    {
        private readonly string _root;

        public const string FileVersionName = "FileVersion.xml";
        public const string SearchPattern = "*.jpg";

        private readonly FileVersionInfo _fileVersion;

        public string FileVersionPath 
        {
            get { return _root + @"\" +  FileVersionName; }
        }
        public FileVersionInfo FileVersion
        {
            get { return _fileVersion; }
        }

        public ClientFileManager(string root)
        {
            _root = root;

            if (!Directory.Exists(_root))
            {
                Directory.CreateDirectory(_root);
            }

            _fileVersion = new FileVersionInfo(FileVersionPath);

            _fileVersion.UpdateFilesChecksum(GetAllFilePath());
        }

        public IEnumerable<string> GetAllFilePath()
        {
            return Directory.GetFiles(_root, SearchPattern);
        }

        public void UpdateFileVersion()
        {
            _fileVersion.UpdateFilesChecksum(GetAllFilePath());
        }
    }
}
