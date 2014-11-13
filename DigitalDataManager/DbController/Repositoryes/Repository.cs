using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DbController.Convert;
using DbController.Entityes;
using DbController.Tables.Context;
using DbController.Tables.DigitalDate;
using DbController.Tables.Versions;
using FileSystemManager;

namespace DbController.Repositoryes
{
    public class Repository
    {
        private readonly ServerFileManager _manager;

        public Repository(string rootpath)
        {
            // _manager = new ServerFileManager(rootpath);
        }

        public User CreateUser(string login, string password)
        {
            User res = null;

            using (var db = new DdmDateBaseContext())
            {
                var newUser = new UserDbItem()
                {
                    Id = Guid.NewGuid(),
                    Login = login,
                    Password = password
                };

                db.Users.Add(newUser);
                db.SaveChanges();

                res = DbConverter.GetUser(newUser);
            }

            return res;
        }

        public void CreateAlbum(string name, Guid userId)
        {
            using (var db = new DdmDateBaseContext())
            {
                AlbumDbItem album = null;

                album = new AlbumDbItem
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    UserId = userId,
                };

                //var user = GetUser(userId);

                //user.Albums.Add(album);
            }
        }

        //public void AddAlbum(Guid userId, Album album)
        //{
        //    //using (var db = new DdmDateBaseContext())
        //    //{
        //    var user = GetUser(userId);

        //    user.Albums.Add(album);

        //    db.SaveChanges();
        //    //}
        //}

        //public TableUser GetUser(Guid userId)
        //{
        //    TableUser user = null;

        //    using (var db = new DdmDateBaseContext())
        //    {
        //        var users = (from item in db.Users
        //                     where item.Id == userId
        //                     select item).ToList();

        //        user = users.FirstOrDefault();
        //    }

        //    return user;
        //}

        //public IEnumerable<TableUser> GetAllUser()
        //{
        //    IEnumerable<TableUser> users = null;

        //    using (var db = new DdmDateBaseContext())
        //    {
        //        users = from item in db.Users
        //                select item;

        //        return users;

        //    }

        //}

        public IEnumerable<AlbumDbItem> GetAllAlbums(Guid userId)
        {
            using (var db = new DdmDateBaseContext())
            {
                return from item in db.Albums
                       where item.UserId == userId
                       select item;
            }
        }

        public void AddImage(int albumId, MemoryStream imagStream, string imageName)
        {
            using (var db = new DdmDateBaseContext())
            {
                //var image = new Image { Name = imageName, Path = imageName };

                //db.Images.Add(image);

                //db.SaveChanges();

                //_manager.CreateFile(imagStream, image.Path);
            }
        }

        public void UpdateImage(int albumId, MemoryStream imagStream, string imageName)
        {
            using (var db = new DdmDateBaseContext())
            {
                // _manager.CreateFile(imagStream, image.Path);
            }
        }

        public List<UserDateVersionDbItem> GetUserVersion(Guid userId)
        {
            IEnumerable<UserDateVersionDbItem> result = null;

            using (var db = new DdmDateBaseContext())
            {
                result = from item in db.Versions
                         where item.UserId == userId
                         select item;
            }

            return result.ToList();
        }

        public UserDateVersionDbItem GetLastUserVersion(Guid userId)
        {
            UserDateVersionDbItem result = null;

            using (var db = new DdmDateBaseContext())
            {
                var versions = (from item in db.Versions
                                where item.UserId == userId
                                select item).ToList();

                versions.Sort((foo1, foo2) => foo2.VersionNumber.CompareTo(foo1.VersionNumber));

                if (versions.Count != 0)
                {
                    result = versions.FirstOrDefault();
                }
            }

            return result;
        }

        public void AddUserVersion(Guid userId, string xml)
        {
            using (var db = new DdmDateBaseContext())
            {
                var version = new UserDateVersionDbItem
                {
                    Id = new Guid(),
                    UserId = userId,
                    VersionXml = xml
                };

                var lastVersion = GetLastUserVersion(userId);

                if (lastVersion == null)
                {
                    version.VersionNumber = 1;
                }
                else
                {
                    version.VersionNumber = lastVersion.VersionNumber + 1.0m;
                }

                db.Versions.Add(version);
                db.SaveChanges();
            }
        }
    }
}
