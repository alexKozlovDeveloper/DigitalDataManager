﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;
using DbController.Repositoryes;
using DdmHelpers.FileReader;
using DigitalWcfService.Entityes;

namespace DigitalWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class DigitalService : IDigitalService
    {
        public string RootPath 
        {
            get { return ""; }
        }

        public string GetData(string value)
        {
            return string.Format("You entered: {0}", value);
        }

        public Stream GetImage(string login, string imageName)
        {
            var rep = new Repository(RootPath);
            var image = rep.GetImage(login, imageName);
            return FileReaderHelper.ReadStreamFromFile(image.Path);
        }

        public void AddNewImage(ImageData imageData)
        {
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

        public void UpdateImage(ImageData imageData)
        {
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

        public string GetLastCatalogVersion(string login)
        {
            var rep = new Repository(RootPath);
            var user = rep.GetUserByName(login);
            var lastV =  rep.GetLastUserVersion(user.Id);
            return lastV != null ? lastV.VersionXml : null;
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
