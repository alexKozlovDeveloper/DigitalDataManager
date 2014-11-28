using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DdmHelpers.FileReader;

namespace ServerFsManager.UserFilesManager
{
    public class UserFilesServerManager : IUserFilesServerManager
    {
        private readonly string _rootFolder;

        private const string Users = "//Users//";

        public string RootFolder
        {
            get { return _rootFolder; }
        }

        private string UsersFolder
        {
            get { return RootFolder + Users; }
        }

        public UserFilesServerManager(string rootFolder)
        {
            _rootFolder = rootFolder;
            
            if (!Directory.Exists(_rootFolder))
            {
                Directory.CreateDirectory(_rootFolder);
            }

            if (!Directory.Exists(UsersFolder))
            {
                Directory.CreateDirectory(UsersFolder);
            }
        }


        public void CreateOrUpdateFile(Stream fileStream, string name, string fileName)
        {
            var fielPath = GetUserFilePath(name, fileName);

            FileReaderHelper.WriteStreamInFile(fileStream, fielPath);
        }

        public void DeleteFile(string name, string fileName)
        {
            var fielPath = GetUserFilePath(name, fileName);

            if (File.Exists(fielPath))
            {
                File.Delete(fielPath);
            }
        }


        public void CreateUserFolder(string name)
        {
            var path = GetUserFolderPath(name);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public void DeleteUserFolder(string name)
        {
            var path = GetUserFolderPath(name);

            if (Directory.Exists(path))
            {
                Directory.Delete(path);
            }
        }


        private string GetUserFolderPath(string name)
        {
            return _rootFolder + Users + name;
        }

        private string GetUserFilePath(string name, string fileName)
        {
            return _rootFolder + Users + name + "//" + fileName;
        }
    }
}
