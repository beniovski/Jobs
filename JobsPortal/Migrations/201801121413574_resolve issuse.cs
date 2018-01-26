namespace JobsPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class resolveissuse : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.JobOffers", "CompanyId", "dbo.AspNetUsers");
            DropIndex("dbo.JobOffers", new[] { "CompanyId" });
            AddColumn("dbo.JobOffers", "Company_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.JobOffers", "CompanyId", c => c.Int(nullable: false));
            AlterColumn("dbo.JobOffers", "JobCategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.JobOffers", "Company_Id");
            AddForeignKey("dbo.JobOffers", "Company_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobOffers", "Company_Id", "dbo.AspNetUsers");
            DropIndex("dbo.JobOffers", new[] { "Company_Id" });
            AlterColumn("dbo.JobOffers", "JobCategoryId", c => c.String());
            AlterColumn("dbo.JobOffers", "CompanyId", c => c.String(maxLength: 128));
            DropColumn("dbo.JobOffers", "Company_Id");
            CreateIndex("dbo.JobOffers", "CompanyId");
            AddForeignKey("dbo.JobOffers", "CompanyId", "dbo.AspNetUsers", "Id");
        }
    }
}
