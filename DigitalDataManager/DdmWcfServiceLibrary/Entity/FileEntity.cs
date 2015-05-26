using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DdmWcfServiceLibrary.Entity
{
    [Serializable]
    public class FileEntity
    {
        public Stream FileStream { get; set; }
        public string Name { get; set; }
        public string CheckSum { get; set; }
    }
}
