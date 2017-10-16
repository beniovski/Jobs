namespace JobsPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addreference : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobOfferViewModels", "Company_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.JobOfferViewModels", "Company_Id");
            AddForeignKey("dbo.JobOfferViewModels", "Company_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobOfferViewModels", "Company_Id", "dbo.AspNetUsers");
            DropIndex("dbo.JobOfferViewModels", new[] { "Company_Id" });
            DropColumn("dbo.JobOfferViewModels", "Company_Id");
        }
    }
}
