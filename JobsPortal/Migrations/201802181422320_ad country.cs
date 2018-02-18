namespace JobsPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adcountry : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobOffers", "CountriesId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobOffers", "CountriesId");
        }
    }
}
