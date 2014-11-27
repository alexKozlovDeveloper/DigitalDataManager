using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserFilesDbController.Entityes
{
    public class Album
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<DigitalFile> Files { get; set; }
    }
}
