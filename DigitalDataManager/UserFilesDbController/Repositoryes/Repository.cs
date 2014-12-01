using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerFsManager.UserFilesManager;
using UserFilesDbController.Context;
using UserFilesDbController.Convert;
using UserFilesDbController.Entityes;
using UserFilesDbController.Tables;

namespace UserFilesDbController.Repositoryes
{
    public class Repository : IRepository
    {
        private IUserFilesServerManager _userFilesManager;

        public Repository(IUserFilesServerManager manager)
        {
            _userFilesManager = manager;
        }


        public Guid CreateUser(string userName, string password)
        {
            var id = Guid.NewGuid();

            using (var db = new DdmDataBase())
            {
                var user = new UserT
                {
                    Id = id,
                    Name = userName,
                    Password = password
                };

                db.Users.Add(user);

                db.SaveChanges();
            }

            return id;
        }

        public Guid CreateAlbum(string albumName)
        {
            var id = Guid.NewGuid();

            using (var db = new DdmDataBase())
            {
                var album = new AlbumT
                {
                    Id = id,
                    Name = albumName
                };

                db.Albums.Add(album);

                db.SaveChanges();
            }

            return id;
        }

        public Guid CreateFile(Stream fileStream, string fielName)
        {
            var id = Guid.NewGuid();

            using (var db = new DdmDataBase())
            {
                var file = new FileT
                {
                    Id = id,
                    Name = fielName
                };

                db.Files.Add(file);

                _userFilesManager.CreateOrUpdateFile(fileStream, id, fielName);

                db.SaveChanges();
            }

            return id;
        }

        public void UpdateFile(Stream fileStream, Guid fileId)
        {
            var file = GetFile(fileId);

            _userFilesManager.CreateOrUpdateFile(fileStream, fileId, file.Name);
        }


        public void AddAlbumToUser(Guid userId, Guid albumId)
        {
            using (var db = new DdmDataBase())
            {
                var user = GetUserT(userId,db);

                var album = GetAlbumT(albumId,db);

                user.Albums.Add(album);

                db.SaveChanges();
            }
        }

        public void AddFileToAlbum(Guid albumId, Guid fileId)
        {
            using (var db = new DdmDataBase())
            {
                var album = GetAlbumT(albumId, db);

                var file = GetFileT(fileId, db);

                album.Files.Add(file);

                db.SaveChanges();
            }
        }

        public void AddFriendLink(Guid userId, Guid friendId)
        {
            using (var db = new DdmDataBase())
            {
                var link = new FriendsLinkT
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    FriendUserId = friendId
                };

                db.FriendLinks.Add(link);

                db.SaveChanges();
            }
        }


        public User GetUser(Guid userId)
        {
            using (var db = new DdmDataBase())
            {
                var userT = GetUserT(userId, db);

                var user = DbConverter.GetUser(userT);

                user.FriendsId = new List<Guid>();

                var ids = from item in db.FriendLinks
                        where item.UserId == userId
                        select item;

                foreach (var linkT in ids)
                {
                    user.FriendsId.Add(linkT.FriendUserId);
                }

                return user;
            }
        }

        public Album GetAlbum(Guid albumId)
        {
            using (var db = new DdmDataBase())
            {
                var albumT = GetAlbumT(albumId, db);

                var album =  DbConverter.GetAlbum(albumT);

                album.UsersId = new List<Guid>();

                foreach (var userT in albumT.Users)
                {
                    album.UsersId.Add(userT.Id);
                }

                return album;
            }
        }

        public DigitalFile GetFile(Guid fileId)
        {
            using (var db = new DdmDataBase())
            {
                var fileT = GetFileT(fileId, db);

                var file = DbConverter.GetFile(fileT);

                file.AlbumsId = new List<Guid>();

                foreach (var albumT in fileT.Albums)
                {
                    file.AlbumsId.Add(albumT.Id);
                }

                return file;
            }
        }


        public List<User> GetAllUsers()
        {
            using (var db = new DdmDataBase())
            {
                var userIds = from item in db.Users
                    select item.Id;

                var res = new List<User>();

                foreach (var id in userIds)
                {
                    res.Add(GetUser(id));
                }

                return res;
            }
        }

        public List<Album> GetAllAlbums()
        {
            using (var db = new DdmDataBase())
            {
                var albumIds = from item in db.Albums
                              select item.Id;

                var res = new List<Album>();

                foreach (var id in albumIds)
                {
                    res.Add(GetAlbum(id));
                }

                return res;
            }
        }

        public List<DigitalFile> GetAllFiles()
        {
            using (var db = new DdmDataBase())
            {
                var fileIds = from item in db.Files
                              select item.Id;

                var res = new List<DigitalFile>();

                foreach (var id in fileIds)
                {
                    res.Add(GetFile(id));
                }

                return res;
            }
        }


        private UserT GetUserT(Guid userId, DdmDataBase db)
        {
            var user = (from item in db.Users
                        where item.Id == userId
                        select item).FirstOrDefault();

            return user;
        }

        private AlbumT GetAlbumT(Guid albumId, DdmDataBase db)
        {
            var album = (from item in db.Albums
                        where item.Id == albumId
                        select item).FirstOrDefault();

            return album;
        }

        private FileT GetFileT(Guid fileId, DdmDataBase db)
        {
            var file = (from item in db.Files
                        where item.Id == fileId
                        select item).FirstOrDefault();

            return file;
        }
    }
}
