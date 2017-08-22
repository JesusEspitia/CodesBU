namespace Monotoring.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracionXX : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeliveryOrders",
                c => new
                    {
                        DeliveryOrderID = c.Int(nullable: false, identity: true),
                        WorkOrdenID = c.Int(nullable: false),
                        date_area_One = c.String(unicode: false),
                        date_area_Two = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.DeliveryOrderID)
                .ForeignKey("dbo.WorkOrdens", t => t.WorkOrdenID, cascadeDelete: true)
                .Index(t => t.WorkOrdenID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DeliveryOrders", "WorkOrdenID", "dbo.WorkOrdens");
            DropIndex("dbo.DeliveryOrders", new[] { "WorkOrdenID" });
            DropTable("dbo.DeliveryOrders");
        }
    }
}
