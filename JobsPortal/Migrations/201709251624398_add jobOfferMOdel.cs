namespace JobsPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addjobOfferMOdel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobOfferViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 30),
                        Country = c.String(),
                        City = c.String(),
                        Description = c.String(nullable: false),
                        Requaierments = c.String(nullable: false),
                        Category = c.String(),
                        DateFrom = c.DateTime(nullable: false),
                        DateTo = c.DateTime(nullable: false),
                        SalaryMin = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalaryMax = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.JobOfferViewModels");
        }
    }
}
