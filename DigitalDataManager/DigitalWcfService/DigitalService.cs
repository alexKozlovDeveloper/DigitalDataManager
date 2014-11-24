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
using DdmHelpers.Const;
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

        //public string GetData(string value)
        //{
        //    return string.Format("You entered: {0}", value);
        //}

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
            return lastV;
        }

        public IEnumerable<Album> GetAllAlbum(string login)
        {
            var rep = new Repository(RootPath);
            var user = rep.GetUserByName(login);
            return rep.GetAllAlbums(user.Id);
        }

        public void CreateNewAlbum(string login, string albumName)
        {
            var rep = new Repository(RootPath);
            var user = rep.GetUserByName(login);
            rep.CreateAlbum(albumName, user.Id);
        }

        public Stream GetFilePart(string login, string fileName, int partNumber)
        {
            var rep = new Repository(RootPath);

            var filePath = rep.GetFilePath(login, fileName);

            using (var fs = File.OpenRead(filePath))
            {
                fs.Position = ConstHelper.PartSize * partNumber;

                var size = ConstHelper.PartSize;

                if (fs.Length - ConstHelper.PartSize * partNumber < ConstHelper.PartSize)
                {
                    size = (int)fs.Length - ConstHelper.PartSize * partNumber;
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

        public bool AppendFile(Stream data)
        {
            var item = BinarySerializerHelper.Deserialize<PartFileData>(data);

            var rep = new Repository(RootPath);

            var filePath = rep.GetFilePath(item.Login, item.ImageName);

            if (!File.Exists(filePath))
            {
                using (File.Create(filePath)) { }

                var user = rep.GetUserByName(item.Login);

                var album = (from obj in user.Albums
                             where obj.Name == item.AlbumName
                             select obj).ToList();

                if (album.Count != 0)
                {
                    rep.CreateImage(item.Login, album[0].Id, item.ImageName, item.ImageStream);
                }

                return true;
            }

            while (true)
            {
                try
                {
                    using (var fs = File.OpenWrite(filePath))
                    {
                        var buffer = new byte[item.ImageStream.Length];

                        item.ImageStream.Read(buffer, 0, (int) item.ImageStream.Length);

                        fs.Position = ConstHelper.PartSize*item.PartNumber;

                        //if (fs.Length != 0)
                        //{
                        //    fs.Position = fs.Length;
                        //}

                        fs.Write(buffer, 0, (int) item.ImageStream.Length);

                        return true;
                    }
                }
                catch (Exception ex)
                {

                }
            }

            return true;
        }

        public long GetFileSize(string login, string fileName)
        {
            var rep = new Repository(RootPath);

            var filePath = rep.GetFilePath(login, fileName);

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
