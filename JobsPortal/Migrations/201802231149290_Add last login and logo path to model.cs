namespace JobsPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addlastloginandlogopathtomodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "LogoPath", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastLoginDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "LastLoginDate");
            DropColumn("dbo.AspNetUsers", "LogoPath");
        }
    }
}
