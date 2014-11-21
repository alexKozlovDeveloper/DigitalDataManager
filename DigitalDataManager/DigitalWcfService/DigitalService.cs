using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;
using DbController.Entityes;
using DbController.Repositoryes;
using DdmHelpers.FileReader;
using DdmHelpers.Serialize;
using DigitalWcfService.Entityes;

namespace DigitalWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class DigitalService : IDigitalService
    {
        public string RootPath
        {
            get { return @"C:\Users\Aliaksei_Kazlou\Documents\DigitalDataManager\TestDBFolder\Server"; }
        }

        public string GetData(string value)
        {
            return string.Format("You entered: {0}", value);
        }

        public Stream GetImage(string login, string imageName)
        {
            var rep = new Repository(RootPath);
            var image = rep.GetImage(login, imageName);

            var imageStream = FileReaderHelper.ReadStreamFromFile(image.Path);

            var imageData = new PartFileData { ImageName = imageName, Login = login, ImageStream = imageStream };

            return BinarySerializerHelper.Serialize(imageData);
        }

        public void AddNewImage(Stream imageDataStream)
        {
            var imageData = BinarySerializerHelper.Deserialize<PartFileData>(imageDataStream);

            var rep = new Repository(RootPath);

            var user = rep.GetUserByName(imageData.Login);

            var album = (from item in user.Albums
                         where item.Name == imageData.AlbumName
                         select item).ToList();

            if (album.Count != 0)
            {
                rep.CreateImage(imageData.Login, album[0].Id, imageData.ImageName, imageData.ImageStream);
            }
        }

        public void UpdateImage(Stream imageDataStream)
        {
            var imageData = BinarySerializerHelper.Deserialize<PartFileData>(imageDataStream);

            var rep = new Repository(RootPath);

            var user = rep.GetUserByName(imageData.Login);

            var album = (from item in user.Albums
                         where item.Name == imageData.AlbumName
                         select item).ToList();

            if (album.Count != 0)
            {
                rep.UpdateImage(imageData.Login, album[0].Id, imageData.ImageName, imageData.ImageStream);
            }
        }

        public void UpdateCatalogVersion(string login, string xmlVersion)
        {
            var rep = new Repository(RootPath);
            var user = rep.GetUserByName(login);
            rep.AddUserVersion(user.Id, xmlVersion);
        }

        public UserDateVersion GetLastCatalogVersion(string login)
        {
            var rep = new Repository(RootPath);
            var user = rep.GetUserByName(login);
            var lastV = rep.GetLastUserVersion(user.Id);
            return lastV;// != null ? lastV.VersionXml : null;
        }

        public Stream GetFilePart(Stream data)
        {
            var item = BinarySerializerHelper.Deserialize<PartFileData>(data);
            var PartSize = 1000;
            var filePath = ":";

            using (var fs = File.OpenRead(filePath))
            {
                fs.Position = PartSize * item.PartNumber;

                var size = PartSize;

                if (fs.Length - PartSize * item.PartNumber < PartSize)
                {
                    size = (int)fs.Length - PartSize * item.PartNumber;
                }

                var buffer = new byte[size];

                fs.Read(buffer, 0, size);

                var ms = new MemoryStream(buffer);

                var info = new PartFileData
                {
                    ImageStream = ms
                };

                return BinarySerializerHelper.Serialize(info);
            }
        }

        public void AppendFile(Stream data)
        {
            var item = BinarySerializerHelper.Deserialize<PartFileData>(data);

            var filePath = ":"; // путь к файлу куда писать

            if (!File.Exists(filePath))
            {
                using (File.Create(filePath)) { }
            }

            using (var fs = File.OpenWrite(filePath))
            {
                var buffer = new byte[item.ImageStream.Length];

                item.ImageStream.Read(buffer, 0, (int)item.ImageStream.Length);

                if (fs.Length != 0)
                {
                    fs.Position = fs.Length;
                }

                fs.Write(buffer, 0, (int)item.ImageStream.Length);
            }
        }

        public long GetFileSize(Stream data)
        {
            var filePath = ":";

            using (var fs = File.OpenRead(filePath))
            {
                return fs.Length;
            }
        }

        // public string GetLastFile

        //public CompositeType GetDataUsingDataContract(CompositeType composite)
        //{
        //    if (composite == null)
        //    {
        //        throw new ArgumentNullException("composite");
        //    }
        //    if (composite.BoolValue)
        //    {
        //        composite.StringValue += "Suffix";
        //    }
        //    return composite;
        //}

    }
}
