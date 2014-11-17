using System;
using System.Collections.Generic;
using System.IO;
using FileSystemManager.DdmServiceReference;
using FileSystemManager.FileReader;
using FileSystemManager.FileVersionHelper;
using FileSystemManager.FileVersionHelper.FileVersionItems;
using FileSystemManager.VersionChanges;
using FileSystemManager.XmlSerialize;

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

            var changes = VersionComparator.Compare(_catalogVersion, XmlSerializerHelper.Deserialize<CatalogVersion>(serverVers));

            UpdateClientFiles(changes);

            // update to server version
            _catalogVersion = XmlSerializerHelper.Deserialize<CatalogVersion>(serverVers);

            var newVersion = new CatalogVersion(CatalogVersionPath);

            if (newVersion.Equals(_catalogVersion) == false)
            {
                var newChanges = VersionComparator.Compare(_catalogVersion, newVersion);

                // update server to new version

                // execute newChanges
                UpdateServerFiles(newChanges);

                client.UpdateCatalogVersion(Login, newVersion.ToXmlString());

                _catalogVersion = newVersion;
            }
        }

        public void UpdateClientFiles(List<ChangeCommand> changes)
        {
            foreach (var changeCommand in changes)
            {
                switch (changeCommand.Type)
                {
                    case ChangeType.Remove:
                        // удаляем картинку
                        break;
                    case ChangeType.Create:
                        // подгружаем с сервера новую версию картинки и копируем в папку
                        break;
                    case ChangeType.Update:
                        // подгружаем с сервера новую версию картинки и заменяем ей существующюю
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public void UpdateServerFiles(List<ChangeCommand> changes)
        {
            foreach (var changeCommand in changes)
            {
                switch (changeCommand.Type)
                {
                    case ChangeType.Remove:
                        // удаляем картинку с сервера
                        break;
                    case ChangeType.Create:
                        // подгружаем на сервер новую картинку
                        break;
                    case ChangeType.Update:
                        // подгружаем на сервер новую картинку и заменяем ее старую
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}
