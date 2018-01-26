namespace JobsPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addisActivefield : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobOffers", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobOffers", "IsActive");
        }
    }
}
