using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DdmHelpers.FileTree.Entity
{
    [DataContract]
    [KnownType(typeof(FolderEntity))]
    public class FolderEntity
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Path { get; set; }

        [DataMember]
        public List<string> FilesPath { get; set; }

        [DataMember]
        public List<FolderEntity> Folders { get; set; }

        [DataMember]
        public bool IsVirtual { get; set; }
        
        public FolderEntity Parrent { get; set; }
        
        public FolderEntity()
        {
            FilesPath = new List<string>();
            Folders = new List<FolderEntity>();
        }

        public FolderEntity(FolderEntity parrent)
        {
            FilesPath = new List<string>();
            Folders = new List<FolderEntity>();

            Parrent = parrent;
        }

        public override bool Equals(object obj)
        {
            var item = obj as FolderEntity;

            var res = item.Name == Name;

            return res;
        }

        public override string ToString()
        {
            var v = "";

            if (IsVirtual)
            {
                v = "virtual";
            }
            else
            {
                v = "Fizikal";
            }
            return string.Format("{0}[{1}]", Name, v);
        }
    }
}
