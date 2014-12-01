using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerFsManager.UserFilesManager
{
    public interface IUserFilesServerManager
    {
        string RootFolder { get; }


        void CreateOrUpdateFile(Stream fileStream, Guid fileId, string fileName);

        void DeleteFile(Guid fileId, string fileName);


        //void CreateUserFolder(string name);

        //void DeleteUserFolder(string name);
    }
}
