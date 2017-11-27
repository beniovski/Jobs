namespace JobsPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addjobcategories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobCategoriesViewModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.JobOfferViewModels", "JobCategoryId", c => c.String());
            AddColumn("dbo.JobOfferViewModels", "JobCategories_id", c => c.Int());
            CreateIndex("dbo.JobOfferViewModels", "JobCategories_id");
            AddForeignKey("dbo.JobOfferViewModels", "JobCategories_id", "dbo.JobCategoriesViewModels", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobOfferViewModels", "JobCategories_id", "dbo.JobCategoriesViewModels");
            DropIndex("dbo.JobOfferViewModels", new[] { "JobCategories_id" });
            DropColumn("dbo.JobOfferViewModels", "JobCategories_id");
            DropColumn("dbo.JobOfferViewModels", "JobCategoryId");
            DropTable("dbo.JobCategoriesViewModels");
        }
    }
}
