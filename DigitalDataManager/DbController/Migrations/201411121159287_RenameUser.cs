namespace DbController.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameUser : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Users", newName: "TableUsers");
            DropForeignKey("dbo.Albums", "UserId", "dbo.Users");
            DropIndex("dbo.Albums", new[] { "UserId" });
            AddColumn("dbo.Albums", "TableUser_Id", c => c.Guid());
            CreateIndex("dbo.Albums", "TableUser_Id");
            AddForeignKey("dbo.Albums", "TableUser_Id", "dbo.TableUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Albums", "TableUser_Id", "dbo.TableUsers");
            DropIndex("dbo.Albums", new[] { "TableUser_Id" });
            DropColumn("dbo.Albums", "TableUser_Id");
            CreateIndex("dbo.Albums", "UserId");
            AddForeignKey("dbo.Albums", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.TableUsers", newName: "Users");
        }
    }
}
