using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DdmWcfService.Entityes
{
    [Serializable]
    public class CreateFileEntity
    {
        public Stream FileStream { get; set; }
        public string FileName { get; set; }
    }
}
