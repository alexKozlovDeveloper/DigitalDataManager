using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbController.Tables.DigitalDate
{
    class FolderVsUserT
    {
        public Guid Id { get; set; }
        public Guid FolderId { get; set; }
        public Guid UserId { get; set; }
    }
}
