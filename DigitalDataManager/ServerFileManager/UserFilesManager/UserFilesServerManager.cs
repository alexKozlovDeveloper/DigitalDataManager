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

        //private const string Users = "//Users//";
        private const string Files = "//Files//";

        public string RootFolder
        {
            get { return _rootFolder; }
        }

        private string FilesFolder
        {
            get { return RootFolder + Files; }
        }

        public UserFilesServerManager(string rootFolder)
        {
            _rootFolder = rootFolder;
            
            if (!Directory.Exists(_rootFolder))
            {
                Directory.CreateDirectory(_rootFolder);
            }

            if (!Directory.Exists(FilesFolder))
            {
                Directory.CreateDirectory(FilesFolder);
            }
        }


        public void CreateOrUpdateFile(Stream fileStream, Guid fileId, string fileName)
        {
            var fielPath = GetFilePath(fileId, fileName);

            FileReaderHelper.WriteStreamInFile(fileStream, fielPath);
        }

        public void DeleteFile(Guid fileId, string fileName)
        {
            var fielPath = GetFilePath(fileId, fileName);

            if (File.Exists(fielPath))
            {
                File.Delete(fielPath);
            }
        }

        public Stream GetFileStream(Guid fileId, string fileName)
        {
            var fielPath = GetFilePath(fileId, fileName);

            return File.OpenRead(fielPath);
        }


        //public void CreateUserFolder(string name)
        //{
        //    var path = GetUserFolderPath(name);

        //    if (!Directory.Exists(path))
        //    {
        //        Directory.CreateDirectory(path);
        //    }
        //}

        //public void DeleteUserFolder(string name)
        //{
        //    var path = GetUserFolderPath(name);

        //    if (Directory.Exists(path))
        //    {
        //        Directory.Delete(path);
        //    }
        //}


        //private string GetUserFolderPath(string name)
        //{
        //    return _rootFolder + Users + name;
        //}

        //private string GetUserFilePath(string name, string fileName)
        //{
        //    return _rootFolder + Users + name + "//" + fileName;
        //}

        private string GetFilePath(Guid fileId, string fileName)
        {
            return FilesFolder + fileId + fileName;
        }
    }
}
