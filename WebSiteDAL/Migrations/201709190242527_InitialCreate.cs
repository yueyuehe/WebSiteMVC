namespace WebSiteDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WebColumns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sort = c.Int(nullable: false),
                        Name = c.String(),
                        Position = c.String(),
                        IsOpenNewWindow = c.Boolean(nullable: false),
                        CanAddContent = c.Boolean(nullable: false),
                        Title = c.String(),
                        Keyword = c.String(),
                        Description = c.String(),
                        StaticName = c.String(),
                        Level = c.Int(nullable: false),
                        IsShow = c.Boolean(nullable: false),
                        ModuleId_Id = c.Int(),
                        ParentID_Id = c.Int(),
                        webSiteId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WebModules", t => t.ModuleId_Id)
                .ForeignKey("dbo.WebColumns", t => t.ParentID_Id)
                .ForeignKey("dbo.WebSites", t => t.webSiteId_Id)
                .Index(t => t.ModuleId_Id)
                .Index(t => t.ParentID_Id)
                .Index(t => t.webSiteId_Id);
            
            CreateTable(
                "dbo.WebModules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Catalog = c.String(),
                        Sort = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WebSites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        WebUrl = c.String(),
                        Logo = c.String(),
                        Icon = c.String(),
                        Keyword = c.String(),
                        Description = c.String(),
                        Copyright = c.String(),
                        Place = c.String(),
                        ZipCode = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Others = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WebColumns", "webSiteId_Id", "dbo.WebSites");
            DropForeignKey("dbo.WebColumns", "ParentID_Id", "dbo.WebColumns");
            DropForeignKey("dbo.WebColumns", "ModuleId_Id", "dbo.WebModules");
            DropIndex("dbo.WebColumns", new[] { "webSiteId_Id" });
            DropIndex("dbo.WebColumns", new[] { "ParentID_Id" });
            DropIndex("dbo.WebColumns", new[] { "ModuleId_Id" });
            DropTable("dbo.WebSites");
            DropTable("dbo.WebModules");
            DropTable("dbo.WebColumns");
        }
    }
}
