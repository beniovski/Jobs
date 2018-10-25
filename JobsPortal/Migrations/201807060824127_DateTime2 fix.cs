namespace JobsPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTime2fix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "CreationDate", c => c.DateTime());
            AlterColumn("dbo.AspNetUsers", "LastLoginDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "LastLoginDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AspNetUsers", "CreationDate", c => c.DateTime(nullable: false));
        }
    }
}
