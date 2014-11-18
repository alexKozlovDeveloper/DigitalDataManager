using System.Collections.Generic;
using System.IO;

namespace ServerFsManager
{
    public class ServerFileManager
    {
        private const string Users = "\\Users\\";

        private readonly string _root;

        public string RootPath
        {
            get { return _root; }
        }

        public string UsersPath
        {
            get { return RootPath + Users; }
        }

        public ServerFileManager(string root)
        {
            _root = root;

            if (!Directory.Exists(_root))
            {
                Directory.CreateDirectory(_root);
            }

            if (!Directory.Exists(UsersPath))
            {
                Directory.CreateDirectory(UsersPath);
            }
        }

        public void CreateUserFolder(IEnumerable<string> userNames)
        {
            foreach (var name in userNames)
            {
                CreateUserFolder(name);
            }
        }

        public void CreateUserFolder(string userName)
        {
            var path = GetUserFolderPath(userName);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public string GetUserFolderPath(string userName)
        {
            return UsersPath + userName + "\\";
        }

        public string CreateFile(Stream fileStream, string userName, string fileName)
        {
            var fielPath = GetUserFolderPath(userName) + fileName;

            var file = System.IO.File.OpenWrite(fielPath);

            var data = new byte[fileStream.Length];

            fileStream.Read(data, 0, data.Length);

            file.Write(data, 0, (int)fileStream.Length);

            return fielPath;
        }

        public string UpdateFile(Stream fileStream, string userName, string fileName)
        {
            var fielPath = GetUserFolderPath(userName) + fileName;

            var file = System.IO.File.OpenWrite(fielPath);

            var data = new byte[fileStream.Length];

            fileStream.Read(data, 0, data.Length);

            file.Write(data, 0, (int)fileStream.Length);

            return fielPath;
        }

        public MemoryStream GetFileStream(string path)
        {
            var ms = new MemoryStream();
            var fs = System.IO.File.OpenRead(path);
            fs.CopyTo(ms);
            fs.Close();
            ms.Position = 0;

            return ms;
        }
    }
}
