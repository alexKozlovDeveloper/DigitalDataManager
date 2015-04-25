using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ddm.Db.Tables
{
    class DigitalFileT
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CheckSum { get; set; }
    }
}
