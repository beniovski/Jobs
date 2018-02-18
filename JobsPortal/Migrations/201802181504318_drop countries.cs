namespace JobsPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropcountries : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.JobOffers", "Countries_Id", "dbo.Countries");
            DropIndex("dbo.JobOffers", new[] { "Countries_Id" });
            DropColumn("dbo.JobOffers", "Countries_Id");
            DropTable("dbo.Countries");
        }
        
        public override void Down()
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
    }
}
