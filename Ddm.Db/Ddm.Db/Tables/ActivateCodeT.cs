using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ddm.Db.Tables
{
    class ActivateCodeT
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public DateTime Date { get; set; }
        public Guid UserId { get; set; }
    }
}
