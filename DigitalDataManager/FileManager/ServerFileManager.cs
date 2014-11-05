using System.Collections.Generic;
using System.IO;

namespace FileSystemManager
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
            return UsersPath + userName;
        }

        public void CreateFile(MemoryStream fileStream, string name)
        {
            var file = System.IO.File.OpenWrite(UsersPath + name);

            file.Write(fileStream.ToArray(), 0, (int)fileStream.Length);
        }

        public MemoryStream GetFileStream(string name)
        {
            var ms = new MemoryStream();
            var fs = System.IO.File.OpenRead(UsersPath + name);
            fs.CopyTo(ms);
            fs.Close();
            ms.Position = 0;

            return ms;
        }
    }
}
