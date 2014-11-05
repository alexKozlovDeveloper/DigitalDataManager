using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemManager
{
    public class ClientFileManager
    {
        private readonly string _root;

        public ClientFileManager(string root)
        {
            _root = root;

            if (!Directory.Exists(_root))
            {
                Directory.CreateDirectory(_root);
            }
        }

        public IEnumerable<string> GetAllFilePath()
        {
            return Directory.GetFiles(_root);
        }
    }
}
