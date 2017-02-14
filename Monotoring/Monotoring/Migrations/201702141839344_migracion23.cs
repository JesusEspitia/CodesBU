namespace Monotoring.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracion23 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserNewRequests",
                c => new
                    {
                        UserNewRequestId = c.Int(nullable: false, identity: true),
                        userNameRequest = c.String(unicode: false),
                        areaRequest = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.UserNewRequestId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserNewRequests");
        }
    }
}
