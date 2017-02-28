namespace Monotoring.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracion28 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserNewRequests", "areaRequest", c => c.Int(nullable: false));
            CreateIndex("dbo.UserNewRequests", "areaRequest");
            AddForeignKey("dbo.UserNewRequests", "areaRequest", "dbo.Areas", "AreaId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserNewRequests", "areaRequest", "dbo.Areas");
            DropIndex("dbo.UserNewRequests", new[] { "areaRequest" });
            AlterColumn("dbo.UserNewRequests", "areaRequest", c => c.String(unicode: false));
        }
    }
}
