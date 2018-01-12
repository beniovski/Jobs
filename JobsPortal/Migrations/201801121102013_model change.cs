namespace JobsPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelchange : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.JobOffers", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.JobOffers", "Category", c => c.String());
        }
    }
}
