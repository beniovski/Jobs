namespace JobsPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changemaxlenghtofrequirementsanddescriptions : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.JobOfferViewModels", "Descriptions", c => c.String(nullable: false, maxLength: 4000));
            AlterColumn("dbo.JobOfferViewModels", "Requaierments", c => c.String(nullable: false, maxLength: 4000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.JobOfferViewModels", "Requaierments", c => c.String(nullable: false));
            AlterColumn("dbo.JobOfferViewModels", "Descriptions", c => c.String(nullable: false));
        }
    }
}
