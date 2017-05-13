namespace Monotoring.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1205 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrdenComments",
                c => new
                    {
                        OrdenCommentId = c.Int(nullable: false, identity: true),
                        WorkOrdenId = c.Int(nullable: false),
                        Commnet = c.String(unicode: false),
                        UsersId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrdenCommentId)
                .ForeignKey("dbo.Users", t => t.UsersId, cascadeDelete: true)
                .ForeignKey("dbo.WorkOrdens", t => t.WorkOrdenId, cascadeDelete: true)
                .Index(t => t.WorkOrdenId)
                .Index(t => t.UsersId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrdenComments", "WorkOrdenId", "dbo.WorkOrdens");
            DropForeignKey("dbo.OrdenComments", "UsersId", "dbo.Users");
            DropIndex("dbo.OrdenComments", new[] { "UsersId" });
            DropIndex("dbo.OrdenComments", new[] { "WorkOrdenId" });
            DropTable("dbo.OrdenComments");
        }
    }
}
