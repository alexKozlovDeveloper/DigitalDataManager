using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbController.Tables.Versions
{
    public class UserDateVersionDbItem
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public Decimal VersionNumber { get; set; }
        public string VersionXml { get; set; }
    }
}
