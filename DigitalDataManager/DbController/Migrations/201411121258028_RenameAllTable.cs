namespace DbController.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameAllTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Albums", newName: "AlbumDbItems");
            RenameTable(name: "dbo.Images", newName: "ImageDbItems");
            RenameTable(name: "dbo.TableUsers", newName: "UserDbItems");
            RenameTable(name: "dbo.UserDateVersions", newName: "UserDateVersionDbItems");
            RenameColumn(table: "dbo.ImageDbItems", name: "Album_Id", newName: "AlbumDbItem_Id");
            RenameColumn(table: "dbo.AlbumDbItems", name: "TableUser_Id", newName: "UserDbItem_Id");
            RenameIndex(table: "dbo.AlbumDbItems", name: "IX_TableUser_Id", newName: "IX_UserDbItem_Id");
            RenameIndex(table: "dbo.ImageDbItems", name: "IX_Album_Id", newName: "IX_AlbumDbItem_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ImageDbItems", name: "IX_AlbumDbItem_Id", newName: "IX_Album_Id");
            RenameIndex(table: "dbo.AlbumDbItems", name: "IX_UserDbItem_Id", newName: "IX_TableUser_Id");
            RenameColumn(table: "dbo.AlbumDbItems", name: "UserDbItem_Id", newName: "TableUser_Id");
            RenameColumn(table: "dbo.ImageDbItems", name: "AlbumDbItem_Id", newName: "Album_Id");
            RenameTable(name: "dbo.UserDateVersionDbItems", newName: "UserDateVersions");
            RenameTable(name: "dbo.UserDbItems", newName: "TableUsers");
            RenameTable(name: "dbo.ImageDbItems", newName: "Images");
            RenameTable(name: "dbo.AlbumDbItems", newName: "Albums");
        }
    }
}
