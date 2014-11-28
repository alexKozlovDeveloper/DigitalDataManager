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


        void CreateOrUpdateFile(Stream fileStream, string name, string fileName);

        void DeleteFile(string name, string fileName);


        void CreateUserFolder(string name);

        void DeleteUserFolder(string name);
    }
}
