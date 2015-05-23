using DbController.Tables.DigitalDate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbController.Tables.Context
{
    class DdmDbContextV2 : DbContext
    {
        public DbSet<ActivateCodeT> ActivateCodes { get; set; }
        public DbSet<CommentT> Comments { get; set; }
        public DbSet<DigitalFileT> Files { get; set; }
        public DbSet<FileVsTagT> FileVsTags { get; set; }
        public DbSet<FolderT> Folders { get; set; }
        public DbSet<FolderVsFileT> FolderVsFiles { get; set; }
        public DbSet<FolderVsUserT> FolderVsUsers { get; set; }
        public DbSet<FriendLinkT> FriendLinks { get; set; }
        public DbSet<MessageT> Messages { get; set; }
        public DbSet<TagT> Tags { get; set; }
        public DbSet<UserT> Users { get; set; }
    }
}
