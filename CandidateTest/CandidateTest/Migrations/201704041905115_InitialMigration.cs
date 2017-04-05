namespace CandidateTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        AnswerId = c.Int(nullable: false, identity: true),
                        AnswerContent = c.String(unicode: false),
                        QuestionId = c.Int(nullable: false),
                        AnswerValue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AnswerId)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        ContenQuestion = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.QuestionId);
            
            CreateTable(
                "dbo.Candidates",
                c => new
                    {
                        CandidateId = c.Int(nullable: false, identity: true),
                        CandidateName = c.String(unicode: false),
                        CandidatePosition = c.String(unicode: false),
                        HR = c.String(unicode: false),
                        InterviewDate = c.DateTime(nullable: false, precision: 0),
                        Manager = c.String(unicode: false),
                        CandidateType = c.String(unicode: false),
                        CandidateScore = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CandidateId);
            
            CreateTable(
                "dbo.Forms",
                c => new
                    {
                        FormId = c.Int(nullable: false, identity: true),
                        CandidateId = c.Int(nullable: false),
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
            DropForeignKey("dbo.Answers", "QuestionId", "dbo.Questions");
            DropIndex("dbo.Answers", new[] { "QuestionId" });
            DropTable("dbo.Forms");
            DropTable("dbo.Candidates");
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
        }
    }
}
