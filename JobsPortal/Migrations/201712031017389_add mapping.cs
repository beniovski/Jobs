namespace JobsPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmapping : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.JobCategoriesViewModels", newName: "JobCategories");
            RenameTable(name: "dbo.JobOfferViewModels", newName: "JobOffers");
            AddColumn("dbo.JobOffers", "DateTo", c => c.DateTime(nullable: false));
            AlterColumn("dbo.JobOffers", "Title", c => c.String());
            AlterColumn("dbo.JobOffers", "Descriptions", c => c.String());
            AlterColumn("dbo.JobOffers", "Requaierments", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.JobOffers", "Requaierments", c => c.String(nullable: false, maxLength: 4000));
            AlterColumn("dbo.JobOffers", "Descriptions", c => c.String(nullable: false, maxLength: 4000));
            AlterColumn("dbo.JobOffers", "Title", c => c.String(nullable: false, maxLength: 30));
            DropColumn("dbo.JobOffers", "DateTo");
            RenameTable(name: "dbo.JobOffers", newName: "JobOfferViewModels");
            RenameTable(name: "dbo.JobCategories", newName: "JobCategoriesViewModels");
        }
    }
}
