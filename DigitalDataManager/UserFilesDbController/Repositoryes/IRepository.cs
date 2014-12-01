using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UserFilesDbController.Entityes;

namespace UserFilesDbController.Repositoryes
{
    public interface IRepository
    {
        Guid CreateUser(string userName, string password);

        Guid CreateAlbum(string albumName);

        Guid CreateFile(Stream fileStream, string fielName);

        void UpdateFile(Stream fileStream, Guid fileId);

        Stream GetFileStream(Guid fileId);


        void AddAlbumToUser(Guid userId, Guid albumId);

        void AddFileToAlbum(Guid albumId, Guid fileId);

        void AddFriendLink(Guid userId, Guid friendId);


        User GetUser(Guid userId);

        Album GetAlbum(Guid albumId);

        DigitalFile GetFile(Guid fileId);


        List<User> GetAllUsers();

        List<Album> GetAllAlbums();

        List<DigitalFile> GetAllFiles();
    }
}
