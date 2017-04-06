namespace CandidateTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationA : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidates", "Accepted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Candidates", "Accepted");
        }
    }
}
