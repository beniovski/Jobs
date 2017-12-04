namespace JobsPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedatetype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.JobOffers", "DateTo", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.JobOffers", "DateTo", c => c.DateTime(nullable: true));
        }
    }
}
