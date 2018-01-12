namespace JobsPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changemodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobOffers", "Category", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobOffers", "Category");
        }
    }
}
