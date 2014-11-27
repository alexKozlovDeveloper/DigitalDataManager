using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserFilesDbController.Tables;

namespace UserFilesDbController.Context
{
    public class UserFilesDbContext : DbContext
    {
        public DbSet<UserTable> Users { get; set; }
        public DbSet<AlbumTable> Albums { get; set; }
        public DbSet<FileTable> Files { get; set; }
    }
}
