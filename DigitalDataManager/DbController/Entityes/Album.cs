using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbController.Entityes
{
    public class Album
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Name { get; set; }
        public virtual List<Image> Images { get; set; }
    }
}
