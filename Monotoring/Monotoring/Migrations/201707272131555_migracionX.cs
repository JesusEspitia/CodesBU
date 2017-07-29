namespace Monotoring.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracionX : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AreaPlus",
                c => new
                    {
                        AreaPlusId = c.Int(nullable: false, identity: true),
                        userId = c.Int(nullable: false),
                        areaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AreaPlusId)
                .ForeignKey("dbo.Areas", t => t.areaId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.userId, cascadeDelete: true)
                .Index(t => t.userId)
                .Index(t => t.areaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AreaPlus", "userId", "dbo.Users");
            DropForeignKey("dbo.AreaPlus", "areaId", "dbo.Areas");
            DropIndex("dbo.AreaPlus", new[] { "areaId" });
            DropIndex("dbo.AreaPlus", new[] { "userId" });
            DropTable("dbo.AreaPlus");
        }
    }
}
