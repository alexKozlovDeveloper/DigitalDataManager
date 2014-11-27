using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserFilesDbController.Tables
{
    public class AlbumT
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual List<FileT> Files { get; set; }
        public virtual List<UserT> Users { get; set; }
    }
}
