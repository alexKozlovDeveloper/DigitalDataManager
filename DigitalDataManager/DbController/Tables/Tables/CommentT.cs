using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbController.Tables.DigitalDate
{
    class CommentT
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public Guid UserId { get; set; }
        public Guid FileId { get; set; }
        public int Index { get; set; }
    }
}
