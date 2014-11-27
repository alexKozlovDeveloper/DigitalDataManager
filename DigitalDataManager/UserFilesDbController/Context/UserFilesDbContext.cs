using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserFilesDbController.Tables;

namespace UserFilesDbController.Context
{
    public class DdmDataBase : DbContext
    {
        public DbSet<UserT> Users { get; set; }
        public DbSet<FriendsLinkT> FriendLinks { get; set; }
        public DbSet<AlbumT> Albums { get; set; }
        public DbSet<FileT> Files { get; set; }
    }
}
