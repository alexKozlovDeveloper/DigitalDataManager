using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbController.Tables.DigitalDate
{
    class FileVsTagT
    {
        public Guid Id { get; set; }
        public Guid FileId { get; set; }
        public Guid TagId { get; set; }
    }
}
