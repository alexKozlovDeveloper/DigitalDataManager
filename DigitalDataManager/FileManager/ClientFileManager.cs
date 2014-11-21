using System;
using System.Collections.Generic;
using System.IO;
//using FileSystemManager.DdmServiceReference;
using System.ServiceModel;
using DdmHelpers.FileReader;
using DdmHelpers.Serialize;
using DigitalWcfService.Entityes;
using FileSystemManager.DdmServiceReference;
using FileSystemManager.FileReader;
using FileSystemManager.FileVersionHelper;
using FileSystemManager.FileVersionHelper.FileVersionItems;
using FileSystemManager.VersionChanges;

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
        //private readonly DigitalServiceClient _wcfClient;
        private readonly IDigitalService _wcfClient;

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
            get { return _root + @"\"; }
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
                _catalogVersion = XmlVersionHelper.ReadVersion(CatalogVersionPath);
            }
            else
            {
                _catalogVersion = new CatalogVersion();
                _catalogVersion.CreateEmpty(RootPath);
                XmlVersionHelper.WriteVeriosn(CatalogVersionPath, _catalogVersion);
            }

            //Could not find endpoint element with name 'BasicHttpBinding_IDigitalService' and contract 
            //'DdmServiceReference.IDigitalService' in the ServiceModel client configuration section. This might 
            //be because no configuration file was found for your application, or because no endpoint element 
            //matching this name could be found in the client element.


            var myBinding = new BasicHttpBinding();
            var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/DigitalWcfService/Service1/");
            var myChannelFactory = new ChannelFactory<IDigitalService>(myBinding, myEndpoint);
            _wcfClient = myChannelFactory.CreateChannel();

            //_wcfClient = new DigitalServiceClient();

            //_fileVersion = new FileVersionInfo(FileVersionPath);

            //_fileVersion.UpdateFilesChecksum(GetAllFilePath());
        }

        public IEnumerable<string> GetAllFilePath()
        {
            return Directory.GetFiles(_root, SearchPattern);
        }

        public void UpdateFileVersion()
        {
            var serverVers = _wcfClient.GetLastCatalogVersion(Login);

            if (serverVers == null)
            {
                _wcfClient.UpdateCatalogVersion(Login, _catalogVersion.ToXmlString());
                serverVers.VersionXml = _catalogVersion.ToXmlString();
            }

            var serverVersion = XmlSerializerHelper.Deserialize<CatalogVersion>(serverVers.VersionXml);
            serverVersion.VersionNumber.Number = (int)serverVers.VersionNumber;

            var changes = VersionComparator.Compare(_catalogVersion, serverVersion);

            UpdateClientFiles(changes);

            // update to server version
            _catalogVersion = serverVersion;

            var newVersion = new CatalogVersion(RootPath);
            newVersion.VersionNumber.Number = _catalogVersion.VersionNumber.Number + 1;

            if (newVersion.Equals(_catalogVersion) == false)
            {
                var newChanges = VersionComparator.Compare(_catalogVersion, newVersion);

                // update server to new version

                // execute newChanges
                UpdateServerFiles(newChanges);

                _wcfClient.UpdateCatalogVersion(Login, newVersion.ToXmlString());

                _catalogVersion = newVersion;
            }

            XmlVersionHelper.WriteVeriosn(CatalogVersionPath, _catalogVersion);
        }

        public void UpdateClientFiles(List<ChangeCommand> changes)
        {
            foreach (var changeCommand in changes)
            {
                switch (changeCommand.Type)
                {
                    case ChangeType.Remove:
                        // удаляем картинку
                        //-
                        break;
                    case ChangeType.Create:
                    {
                        // подгружаем с сервера новую версию картинки и копируем в папку

                        var imageDataStream = _wcfClient.GetImage(Login, changeCommand.ActualVersion.FileName);

                        var imageData = BinarySerializerHelper.Deserialize<PartFileData>(imageDataStream);

                        FileReaderHelper.WriteStreamInFile(imageData.ImageStream, RootPath + changeCommand.ActualVersion.FileName);

                    }break;
                    case ChangeType.Update:
                    {
                        // подгружаем с сервера новую версию картинки и заменяем ей существующюю

                        var image = _wcfClient.GetImage(Login, changeCommand.ActualVersion.FileName);

                        FileReaderHelper.WriteStreamInFile(image, RootPath + changeCommand.ActualVersion.FileName);

                    }break;
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
                        //-
                        break;
                    case ChangeType.Create:
                    {
                        // подгружаем на сервер новую картинку

                        var imageStream = FileReaderHelper.ReadStreamFromFile(RootPath + changeCommand.ActualVersion.FileName);

                        var data = new PartFileData
                        {
                            AlbumName = "All", // ?????
                            ImageName = changeCommand.ActualVersion.FileName,
                            Login = Login,
                            ImageStream = imageStream
                        };

                        var requestData = BinarySerializerHelper.Serialize(data);

                        _wcfClient.AddNewImage(requestData);
                    }break;
                    case ChangeType.Update:
                    {
                        // подгружаем на сервер новую картинку и заменяем ее старую

                        var imageStream = FileReaderHelper.ReadStreamFromFile(RootPath + changeCommand.ActualVersion.FileName);

                        var data = new PartFileData
                        {
                            AlbumName = "All", // ?????
                            ImageName = changeCommand.ActualVersion.FileName,
                            Login = Login,
                            ImageStream = imageStream
                        };

                        _wcfClient.AddNewImage(BinarySerializerHelper.Serialize(data));

                    }break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }


        //public string CreateFile(Stream fileStream, string filePath)
        //{
        //    var file = System.IO.File.OpenWrite(filePath);

        //    var data = new byte[fileStream.Length];

        //    fileStream.Read(data, 0, data.Length);

        //    file.Write(data, 0, (int)fileStream.Length);

        //    return filePath;
        //}

        //public string UpdateFile(Stream fileStream, string filePath)
        //{
        //    var file = System.IO.File.OpenWrite(filePath);

        //    var data = new byte[fileStream.Length];

        //    fileStream.Read(data, 0, data.Length);

        //    file.Write(data, 0, (int)fileStream.Length);

        //    return filePath;
        //}

        //public MemoryStream GetFileStream(string path)
        //{
        //    var ms = new MemoryStream();
        //    var fs = System.IO.File.OpenRead(path);
        //    fs.CopyTo(ms);
        //    fs.Close();
        //    ms.Position = 0;

        //    return ms;
        //}
    }
}
