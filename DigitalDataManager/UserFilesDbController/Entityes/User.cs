using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserFilesDbController.Entityes
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Password { get; set; }

        public List<Album> Albums { get; set; }
        public List<Guid> FriendsId { get; set; }
    }
}
