using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ddm.Db.Tables
{
    class FolderT
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ParrentId { get; set; }
        public Guid CreateUserId { get; set; }
    }
}
