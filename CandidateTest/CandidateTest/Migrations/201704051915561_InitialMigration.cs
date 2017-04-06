namespace CandidateTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candidates",
                c => new
                    {
                        CandidateId = c.Int(nullable: false, identity: true),
                        CandidateName = c.String(unicode: false),
                        CandidateScore = c.Int(),
                        Review = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CandidateId);
            
            CreateTable(
                "dbo.Forms",
                c => new
                    {
                        FormId = c.Int(nullable: false, identity: true),
                        Candidate = c.String(unicode: false),
                        Positiion = c.String(unicode: false),
                        InterviewDate = c.DateTime(nullable: false, precision: 0),
                        HR_rep = c.String(unicode: false),
                        candidate_type = c.String(unicode: false),
                        manager_email = c.String(unicode: false),
                        question1 = c.String(unicode: false),
                        question2 = c.String(unicode: false),
                        question3 = c.String(unicode: false),
                        question4 = c.String(unicode: false),
                        question5 = c.String(unicode: false),
                        question6 = c.String(unicode: false),
                        question7 = c.String(unicode: false),
                        question8 = c.String(unicode: false),
                        question9 = c.String(unicode: false),
                        question10 = c.String(unicode: false),
                        Strengths = c.String(unicode: false),
                        Weaknesses = c.String(unicode: false),
                        Recommendations = c.String(unicode: false),
                        Interviewer = c.String(unicode: false),
                        Continue = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.FormId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Forms");
            DropTable("dbo.Candidates");
        }
    }
}
