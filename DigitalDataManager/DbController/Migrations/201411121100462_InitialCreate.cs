namespace DbController.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Path = c.String(),
                        Album_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Albums", t => t.Album_Id)
                .Index(t => t.Album_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserDateVersions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        VersionNumber = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VersionXml = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Albums", "UserId", "dbo.Users");
            DropForeignKey("dbo.Images", "Album_Id", "dbo.Albums");
            DropIndex("dbo.Images", new[] { "Album_Id" });
            DropIndex("dbo.Albums", new[] { "UserId" });
            DropTable("dbo.UserDateVersions");
            DropTable("dbo.Users");
            DropTable("dbo.Images");
            DropTable("dbo.Albums");
        }
    }
}
