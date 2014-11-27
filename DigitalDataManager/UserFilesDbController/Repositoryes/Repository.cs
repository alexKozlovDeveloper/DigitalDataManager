using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserFilesDbController.Context;
using UserFilesDbController.Convert;
using UserFilesDbController.Entityes;
using UserFilesDbController.Tables;

namespace UserFilesDbController.Repositoryes
{
    public class Repository : IRepository
    {
        public Guid CreateUser(string name, string password)
        {
            var id = Guid.NewGuid();

            using (var db = new DdmDataBase())
            {
                var user = new UserT
                {
                    Id = id,
                    Name = name,
                    Password = password
                };

                db.Users.Add(user);

                db.SaveChanges();
            }

            return id;
        }

        public Guid CreateAlbum(string name)
        {
            var id = Guid.NewGuid();

            using (var db = new DdmDataBase())
            {
                var album = new AlbumT
                {
                    Id = id,
                    Name = name
                };

                db.Albums.Add(album);

                db.SaveChanges();
            }

            return id;
        }

        public Guid CreateFile(string name)
        {
            var id = Guid.NewGuid();

            using (var db = new DdmDataBase())
            {
                var file = new FileT
                {
                    Id = id,
                    Name = name
                };

                db.Files.Add(file);

                db.SaveChanges();
            }

            return id;
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
                var user = GetUserT(userId, db);

                return DbConverter.GetUser(user);
            }
        }

        public Album GetAlbum(Guid albumId)
        {
            using (var db = new DdmDataBase())
            {
                var album = GetAlbumT(albumId, db);

                return DbConverter.GetAlbum(album);
            }
        }

        public DigitalFile GetFile(Guid fileId)
        {
            using (var db = new DdmDataBase())
            {
                var file = GetFileT(fileId, db);

                return DbConverter.GetFile(file);
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
