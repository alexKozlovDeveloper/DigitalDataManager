using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserFilesDbController.Entityes
{
    public class DigitalFile
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<Guid> AlbumsId { get; set; }
    }
}
