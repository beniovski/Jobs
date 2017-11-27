namespace JobsPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedateto : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.JobOfferViewModels", "DateTo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.JobOfferViewModels", "DateTo", c => c.DateTime(nullable: false));
        }
    }
}
