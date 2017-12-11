namespace UnitTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Title3", c => c.String());
            AddColumn("dbo.Users", "Title4", c => c.String());
            AddColumn("dbo.Users", "Title5", c => c.String());
            DropColumn("dbo.Users", "Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Title", c => c.String());
            DropColumn("dbo.Users", "Title5");
            DropColumn("dbo.Users", "Title4");
            DropColumn("dbo.Users", "Title3");
        }
    }
}
