using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UserFilesDbController.Entityes;

namespace UserFilesDbController.Repositoryes
{
    public interface IRepository
    {
        Guid CreateUser(string name, string password);

        Guid CreateAlbum(string name);

        Guid CreateFile(string name);


        void AddAlbumToUser(Guid userId, Guid albumId);

        void AddFileToAlbum(Guid albumId, Guid fileId);

        void AddFriendLink(Guid userId, Guid friendId);


        User GetUser(Guid userId);

        Album GetAlbum(Guid albumId);

        DigitalFile GetFile(Guid fileId);
    }
}
