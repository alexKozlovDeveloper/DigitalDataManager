using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DdmHelpers.FileTree.Entity
{
    public class FolderEntity
    {
        public string Name { get; set; }
        public string Path { get; set; }

        public List<string> FilesPath { get; set; }
        public List<FolderEntity> Folders { get; set; }

        public FolderEntity()
        {
            FilesPath = new List<string>();
            Folders = new List<FolderEntity>();
        }
    }
}
