namespace Monotoring.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration15 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DelayComments",
                c => new
                    {
                        DelayCommentId = c.Int(nullable: false, identity: true),
                        DelayWorkId = c.Int(nullable: false),
                        Comment = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.DelayCommentId)
                .ForeignKey("dbo.DelayWorks", t => t.DelayWorkId, cascadeDelete: true)
                .Index(t => t.DelayWorkId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DelayComments", "DelayWorkId", "dbo.DelayWorks");
            DropIndex("dbo.DelayComments", new[] { "DelayWorkId" });
            DropTable("dbo.DelayComments");
        }
    }
}
