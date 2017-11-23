namespace JobsPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class htmltodb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobOfferViewModels", "Descritpion", c => c.String(nullable: false));
            DropColumn("dbo.JobOfferViewModels", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.JobOfferViewModels", "Description", c => c.String(nullable: false));
            DropColumn("dbo.JobOfferViewModels", "Descritpion");
        }
    }
}
