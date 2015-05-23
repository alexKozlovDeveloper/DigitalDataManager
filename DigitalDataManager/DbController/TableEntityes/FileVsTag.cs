using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbController.TableEntityes
{
    public class FileVsTag
    {
        public Guid Id { get; set; }
        public Guid FileId { get; set; }
        public Guid TagId { get; set; }
    }
}
