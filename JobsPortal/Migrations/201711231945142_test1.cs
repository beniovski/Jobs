namespace JobsPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobOfferViewModels", "Descritpions", c => c.String(nullable: false));
            DropColumn("dbo.JobOfferViewModels", "Descritpion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.JobOfferViewModels", "Descritpion", c => c.String(nullable: false));
            DropColumn("dbo.JobOfferViewModels", "Descritpions");
        }
    }
}
