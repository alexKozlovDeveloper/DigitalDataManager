using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ServerFsManager.UserFilesManager;
using UserFilesDbController.Entityes;
using UserFilesDbController.Repositoryes;

namespace DdmWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class DdmService : IDdmService
    {
        private const string Root = @"C:\Users\Aliaksei_Kazlou\Documents\DigitalDataManager\TestDBFolder\Server";

        //public string GetData(int value)
        //{
        //    return string.Format("You entered: {0}", value);
        //}

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

        public Guid CreateUser(string userName, string password)
        {
            var rep = new Repository(new UserFilesServerManager(Root));

            var id = rep.CreateUser(userName, password);

            return id;
        }

        public Guid CreateAlbum(string albumName)
        {
            var rep = new Repository(new UserFilesServerManager(Root));

            var id = rep.CreateAlbum(albumName);

            return id;
        }

        public Guid CreateFile(Stream fileStream, string fielName)
        {
            var rep = new Repository(new UserFilesServerManager(Root));

            var id = rep.CreateFile(fileStream, fielName);

            return id;
        }

        public void UpdateFile(Stream fileStream, Guid fileId)
        {
            var rep = new Repository(new UserFilesServerManager(Root));

            rep.UpdateFile(fileStream, fileId);
        }


        public void AddAlbumToUser(Guid userId, Guid albumId)
        {
            var rep = new Repository(new UserFilesServerManager(Root));

            rep.AddAlbumToUser(userId, albumId);
        }

        public void AddFileToAlbum(Guid albumId, Guid fileId)
        {
            var rep = new Repository(new UserFilesServerManager(Root));

            rep.AddFileToAlbum(albumId, fileId);
        }

        public void AddFriendLink(Guid userId, Guid friendId)
        {
            var rep = new Repository(new UserFilesServerManager(Root));

            rep.AddFriendLink(userId, friendId);
        }


        public User GetUser(Guid userId)
        {
            var rep = new Repository(new UserFilesServerManager(Root));

            var user = rep.GetUser(userId);

            return user;
        }

        public Album GetAlbum(Guid albumId)
        {
            var rep = new Repository(new UserFilesServerManager(Root));

            var album = rep.GetAlbum(albumId);

            return album;
        }

        public DigitalFile GetFile(Guid fileId)
        {
            var rep = new Repository(new UserFilesServerManager(Root));

            var file = rep.GetFile(fileId);

            return file;
        }


        public List<User> GetAllUsers()
        {
            var rep = new Repository(new UserFilesServerManager(Root));

            var users = rep.GetAllUsers();

            return users;
        }

        public List<Album> GetAllAlbums()
        {
            var rep = new Repository(new UserFilesServerManager(Root));

            var albums = rep.GetAllAlbums();

            return albums;
        }

        public List<DigitalFile> GetAllFiles()
        {
            var rep = new Repository(new UserFilesServerManager(Root));

            var files = rep.GetAllFiles();

            return files;
        }
    }
}
