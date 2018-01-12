namespace JobsPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetimeissues : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.JobOffers", "DateFrom", c => c.DateTime());
            AlterColumn("dbo.JobOffers", "DateTo", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.JobOffers", "DateTo", c => c.DateTime(nullable: false));
            AlterColumn("dbo.JobOffers", "DateFrom", c => c.DateTime(nullable: false));
        }
    }
}
