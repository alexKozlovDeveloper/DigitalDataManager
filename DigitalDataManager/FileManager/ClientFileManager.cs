using System.Collections.Generic;
using System.IO;
using FileSystemManager.DdmServiceReference;
using FileSystemManager.FileReader;
using FileSystemManager.FileVersionHelper;
using FileSystemManager.FileVersionHelper.FileVersionItems;

namespace FileSystemManager
{
    public class ClientFileManager
    {
        private readonly string _root;

        public const string CatalogVersionName = "CatalogVersion.xml";
        public const string SearchPattern = "*.jpg";

        //private readonly FileVersionInfo _fileVersion;

        public string Login = "Alex";

        private CatalogVersion _catalogVersion;

        public string CatalogVersionPath
        {
            get { return _root + @"\" + CatalogVersionName; }
        }

        public CatalogVersion CatalogVersion
        {
            get { return _catalogVersion; }
        }

        public string RootPath
        {
            get { return _root; }
        }

        public ClientFileManager(string root)
        {
            _root = root;

            if (!Directory.Exists(_root))
            {
                Directory.CreateDirectory(_root);
            }

            if (File.Exists(CatalogVersionPath))
            {
                _catalogVersion = XmlVersionReader.ReadVersion(CatalogVersionPath);
            }
            else
            {
                _catalogVersion = new CatalogVersion();
                _catalogVersion.CreateEmpty(RootPath);
                XmlVersionReader.WriteVeriosn(CatalogVersionPath, _catalogVersion);
            }

            //_fileVersion = new FileVersionInfo(FileVersionPath);

            //_fileVersion.UpdateFilesChecksum(GetAllFilePath());
        }

        public IEnumerable<string> GetAllFilePath()
        {
            return Directory.GetFiles(_root, SearchPattern);
        }

        public void UpdateFileVersion()
        {
            var client = new DigitalServiceClient();

            var serverVers = client.GetLastCatalogVersion(Login);

            if (serverVers == null)
            {
                client.UpdateCatalogVersion(Login, _catalogVersion.ToXmlString());
                serverVers = _catalogVersion.ToXmlString();
            }

            

            //_fileVersion.UpdateFilesChecksum(GetAllFilePath());
        }
    }
}
