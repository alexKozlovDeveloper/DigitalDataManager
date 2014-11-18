using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DbController.Convert;
using DbController.Entityes;
using DbController.Tables.Context;
using DbController.Tables.DigitalDate;
using DbController.Tables.Versions;
using ServerFsManager;


namespace DbController.Repositoryes
{
    public class Repository
    {
        private readonly ServerFileManager _manager;

        public Repository(string rootpath)
        {
             _manager = new ServerFileManager(rootpath);
        }


        public User CreateUser(string login, string password)
        {
            var id = Guid.NewGuid();

            using (var db = new DdmDateBaseContext())
            {
                var newUser = new UserDbItem
                {
                    Id = id,
                    Login = login,
                    Password = password
                };

                db.Users.Add(newUser);
                db.SaveChanges();
            }
            
            CreateAlbum("All", id);

            return GetUser(id);
        }

        public Album CreateAlbum(string name, Guid userId)
        {
            var id = Guid.NewGuid();

            using (var db = new DdmDateBaseContext())
            {
                var album = new AlbumDbItem
                {
                    Id = id,
                    Name = name,
                    UserId = userId,
                };

                var user = GetUser(db, userId);

                user.Albums.Add(album);
                db.SaveChanges();
            }

            return GetAlbum(id);
        }

        public Image CreateImage(string userName, Guid albumId, string imageName, Stream imageStream)
        {
            var id = Guid.NewGuid();

            var path = _manager.CreateFile(imageStream, userName, imageName);

            using (var db = new DdmDateBaseContext())
            {
                var image = new ImageDbItem
                {
                    Id = id,
                    Name = imageName,
                    Path = path
                };

                var album = GetAlbum(db, albumId);

                album.Images.Add(image);

                db.SaveChanges();
            }

            return GetImage(id);
        }

        public Image UpdateImage(string userName, Guid albumId, string imageName,Stream imageStream)
        {
            using (var db = new DdmDateBaseContext())
            {
                var album = GetAlbum(db, albumId);

                var image = (from item in album.Images
                             where item.Name == imageName
                             select item).ToList();

                _manager.UpdateFile(imageStream,userName, imageName);

                return DbConverter.GetImage(image[0]);
            }
        }

        public User GetUser(Guid userId)
        {
            User res = null;

            using (var db = new DdmDateBaseContext())
            {
                var user = GetUser(db, userId);

                res = DbConverter.GetUser(user);
            }

            return res;
        }

        public User GetUserByName(string login)
        {
            User res = null;

            using (var db = new DdmDateBaseContext())
            {
                var users = (from item in db.Users
                             where item.Login == login
                             select item).ToList();

                var user = users.FirstOrDefault();

                res = DbConverter.GetUser(user);
            }

            return res;
        }

        public Album GetAlbum(Guid albumId)
        {
            Album res = null;

            using (var db = new DdmDateBaseContext())
            {
                var album = GetAlbum(db, albumId);

                res = DbConverter.GetAlbum(album);
            }

            return res;
        }

        public Image GetImage(Guid imageId)
        {
            Image res = null;

            using (var db = new DdmDateBaseContext())
            {
                var image = GetImage(db, imageId);

                res = DbConverter.GetImage(image);
            }

            return res;
        }

        public Image GetImage(string userName, string imageName)
        {
            Image res = null;

            using (var db = new DdmDateBaseContext())
            {
                var user = GetUser(db, userName);

                foreach (var album in user.Albums)
                {
                    var images = (from item in album.Images
                                  where item.Name == imageName
                                  select item).ToList();

                    if (images.Count != 0)
                    {
                        res = DbConverter.GetImage(images[0]);
                    }
                }
            }

            return res;
        }

        public UserDateVersion GetVersion(Guid versionId)
        {
            UserDateVersion res = null;

            using (var db = new DdmDateBaseContext())
            {
                var version = GetVersion(db, versionId);

                res = DbConverter.GetVersion(version);
            }

            return res;
        }


        public IEnumerable<User> GetAllUser()
        {
            var res = new List<User>();

            using (var db = new DdmDateBaseContext())
            {
                var users = from item in db.Users
                        select item;

                foreach (var user in users)
                {
                    res.Add(DbConverter.GetUser(user));
                }
            }

            return res;
        }

        public IEnumerable<Album> GetAllAlbums(Guid userId)
        {
            var res = new List<Album>();

            using (var db = new DdmDateBaseContext())
            {
                var user = GetUser(db, userId);

                foreach (var item in user.Albums)
                {
                    res.Add(DbConverter.GetAlbum(item));
                }
            }

            return res;
        }

        public IEnumerable<Album> GetAllAlbums()
        {
            var res = new List<Album>();

            using (var db = new DdmDateBaseContext())
            {
                var albums = (from item in db.Albums
                             select item).ToList();

                foreach (var item in albums)
                {
                    res.Add(DbConverter.GetAlbum(item));
                }
            }

            return res;
        }



        //public void AddImage(int albumId, MemoryStream imagStream, string imageName)
        //{
        //    using (var db = new DdmDateBaseContext())
        //    {
        //        //var image = new Image { Name = imageName, Path = imageName };

        //        //db.Images.Add(image);

        //        //db.SaveChanges();

        //        //_manager.CreateFile(imagStream, image.Path);
        //    }
        //}

        //public void UpdateImage(int albumId, MemoryStream imagStream, string imageName)
        //{
        //    using (var db = new DdmDateBaseContext())
        //    {
        //        // _manager.CreateFile(imagStream, image.Path);
        //    }
        //}



        public IEnumerable<UserDateVersion> GetUserVersions(Guid userId)
        {
            var res = new List<UserDateVersion>();

            using (var db = new DdmDateBaseContext())
            {
                var versions = from item in db.Versions
                         where item.UserId == userId
                         select item;

                foreach (var version in versions)
                {
                    res.Add(DbConverter.GetVersion(version));
                }
            }

            return res;
        }

        public UserDateVersion GetLastUserVersion(Guid userId)
        {
            UserDateVersion result = null;

            using (var db = new DdmDateBaseContext())
            {
                var versions = (from item in db.Versions
                                where item.UserId == userId
                                select item).ToList();

                versions.Sort((item1, item2) => item2.VersionNumber.CompareTo(item1.VersionNumber));

                if (versions.Count != 0)
                {
                    result = DbConverter.GetVersion(versions.FirstOrDefault());
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



        private UserDbItem GetUser(DdmDateBaseContext db, Guid id)
        {
            var users = (from item in db.Users
                         where item.Id == id
                         select item).ToList();

            var user = users.FirstOrDefault();

            return user;
        }

        private UserDbItem GetUser(DdmDateBaseContext db, string name)
        {
            var users = (from item in db.Users
                         where item.Login == name
                         select item).ToList();

            var user = users.FirstOrDefault();

            return user;
        }

        private AlbumDbItem GetAlbum(DdmDateBaseContext db, Guid id)
        {
            var albums = (from item in db.Albums
                         where item.Id == id
                         select item).ToList();

            var album = albums.FirstOrDefault();

            return album;
        }

        private ImageDbItem GetImage(DdmDateBaseContext db, Guid id)
        {
            var images = (from item in db.Images
                          where item.Id == id
                          select item).ToList();

            var img = images.FirstOrDefault();

            return img;
        }

        private UserDateVersionDbItem GetVersion(DdmDateBaseContext db, Guid id)
        {
            var versions = (from item in db.Versions
                          where item.Id == id
                          select item).ToList();

            var res = versions.FirstOrDefault();

            return res;
        }
    }
}
