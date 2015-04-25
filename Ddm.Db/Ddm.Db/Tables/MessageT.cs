using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ddm.Db.Tables
{
    class MessageT
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public Guid UserId { get; set; }
        public Guid DestUserId { get; set; }
        public Guid FileId { get; set; }
    }
}
