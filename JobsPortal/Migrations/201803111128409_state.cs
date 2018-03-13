namespace JobsPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class state : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StateName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.JobOffers", "StateId", c => c.Int(nullable: false));
            CreateIndex("dbo.JobOffers", "StateId");
            AddForeignKey("dbo.JobOffers", "StateId", "dbo.States", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobOffers", "StateId", "dbo.States");
            DropIndex("dbo.JobOffers", new[] { "StateId" });
            DropColumn("dbo.JobOffers", "StateId");
            DropTable("dbo.States");
        }
    }
}
