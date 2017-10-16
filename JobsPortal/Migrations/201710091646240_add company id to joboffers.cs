namespace JobsPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcompanyidtojoboffers : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.JobOfferViewModels", name: "Company_Id", newName: "CompanyId");
            RenameIndex(table: "dbo.JobOfferViewModels", name: "IX_Company_Id", newName: "IX_CompanyId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.JobOfferViewModels", name: "IX_CompanyId", newName: "IX_Company_Id");
            RenameColumn(table: "dbo.JobOfferViewModels", name: "CompanyId", newName: "Company_Id");
        }
    }
}
