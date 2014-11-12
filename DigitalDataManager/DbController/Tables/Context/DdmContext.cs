using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbController.Tables.DigitalDate;
using DbController.Tables.Versions;

namespace DbController.Tables.Context
{
    public class DdmDateBaseContext : DbContext
    {
        public DbSet<UserDbItem> Users { get; set; }
        public DbSet<AlbumDbItem> Albums { get; set; }
        public DbSet<ImageDbItem> Images { get; set; }
        public DbSet<UserDateVersionDbItem> Versions { get; set; }
    }
}
