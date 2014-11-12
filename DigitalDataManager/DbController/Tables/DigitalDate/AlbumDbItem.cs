using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbController.Tables.DigitalDate
{
    public class AlbumDbItem
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Name { get; set; }
        public virtual List<ImageDbItem> Images { get; set; }
    }
}
