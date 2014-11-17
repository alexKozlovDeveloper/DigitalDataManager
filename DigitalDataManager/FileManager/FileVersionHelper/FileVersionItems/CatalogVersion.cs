using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemManager.FileVersionHelper.FileVersionItems
{
    public class CatalogVersion
    {
        public VersionNumber VersionNumber { get; set; }
        public List<FileVersion> Files { get; set; }
    }
}
