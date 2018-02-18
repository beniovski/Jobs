namespace JobsPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcountries : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountryName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.JobOffers", "Countries_Id", c => c.Int());
            CreateIndex("dbo.JobOffers", "Countries_Id");
            AddForeignKey("dbo.JobOffers", "Countries_Id", "dbo.Countries", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobOffers", "Countries_Id", "dbo.Countries");
            DropIndex("dbo.JobOffers", new[] { "Countries_Id" });
            DropColumn("dbo.JobOffers", "Countries_Id");
            DropTable("dbo.Countries");
        }
    }
}
