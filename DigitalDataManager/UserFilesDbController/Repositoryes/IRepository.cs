using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UserFilesDbController.Repositoryes
{
    public interface IRepository
    {
        void CreateUser(string name, string password);

        void CreateAlbum(string name);

        void CreateFile(string name);

        void AddAlbumToUser(Guid userId, Guid albumId);

        void AddFileToAlbum(Guid albumId, Guid fileId);
    }
}
