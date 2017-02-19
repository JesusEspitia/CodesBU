namespace Monotoring.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracionE : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FamilyProducts",
                c => new
                    {
                        FamilyProductId = c.Int(nullable: false, identity: true),
                        nameFamily = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.FamilyProductId);
            
            CreateTable(
                "dbo.DelayComments",
                c => new
                    {
                        DelayCommentId = c.Int(nullable: false, identity: true),
                        DelayWorkId = c.Int(nullable: false),
                        titleComment = c.String(unicode: false),
                        Comment = c.String(unicode: false),
                        dateComment = c.DateTime(nullable: false, precision: 0),
                        UsersId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DelayCommentId)
                .ForeignKey("dbo.DelayWorks", t => t.DelayWorkId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UsersId, cascadeDelete: true)
                .Index(t => t.DelayWorkId)
                .Index(t => t.UsersId);
            
            CreateTable(
                "dbo.UserNewRequests",
                c => new
                    {
                        UserNewRequestId = c.Int(nullable: false, identity: true),
                        userNameRequest = c.String(unicode: false),
                        areaRequest = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.UserNewRequestId);
            
            AddColumn("dbo.Catalogs", "FamilyProductId", c => c.Int());
            AddColumn("dbo.Users", "fullname", c => c.String(unicode: false));
            CreateIndex("dbo.Catalogs", "FamilyProductId");
            AddForeignKey("dbo.Catalogs", "FamilyProductId", "dbo.FamilyProducts", "FamilyProductId");
            DropColumn("dbo.Users", "userEmail");
            DropColumn("dbo.Users", "userPass");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "userPass", c => c.String(unicode: false));
            AddColumn("dbo.Users", "userEmail", c => c.String(unicode: false));
            DropForeignKey("dbo.DelayComments", "UsersId", "dbo.Users");
            DropForeignKey("dbo.DelayComments", "DelayWorkId", "dbo.DelayWorks");
            DropForeignKey("dbo.Catalogs", "FamilyProductId", "dbo.FamilyProducts");
            DropIndex("dbo.DelayComments", new[] { "UsersId" });
            DropIndex("dbo.DelayComments", new[] { "DelayWorkId" });
            DropIndex("dbo.Catalogs", new[] { "FamilyProductId" });
            DropColumn("dbo.Users", "fullname");
            DropColumn("dbo.Catalogs", "FamilyProductId");
            DropTable("dbo.UserNewRequests");
            DropTable("dbo.DelayComments");
            DropTable("dbo.FamilyProducts");
        }
    }
}
