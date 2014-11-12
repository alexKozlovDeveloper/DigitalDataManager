using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbController.Tables.DigitalDate
{
    public class UserDbItem
    {
        public Guid Id { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }

        public virtual List<AlbumDbItem> Albums { get; set; }
    }
}
