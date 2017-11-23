namespace JobsPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changemodeldescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobOfferViewModels", "Descriptions", c => c.String(nullable: false));
            DropColumn("dbo.JobOfferViewModels", "Descritpions");
        }
        
        public override void Down()
        {
            AddColumn("dbo.JobOfferViewModels", "Descritpions", c => c.String(nullable: false));
            DropColumn("dbo.JobOfferViewModels", "Descriptions");
        }
    }
}
