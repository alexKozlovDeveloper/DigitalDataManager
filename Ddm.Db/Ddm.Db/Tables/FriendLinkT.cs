using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ddm.Db.Tables
{
    class FriendLinkT
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid FriendId { get; set; }
    }
}
