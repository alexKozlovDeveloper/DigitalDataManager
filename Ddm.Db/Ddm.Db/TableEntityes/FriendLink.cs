using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ddm.Db.TableEntityes
{
    public class FriendLink
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid FriendId { get; set; }
    }
}
