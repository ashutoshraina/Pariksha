namespace EFRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "ParikshaDev.Users",
                c => new
                    {
                        UserDetailId = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 10),
                        Password = c.String(),
                        UserRole = c.Int(nullable: false),
                        DateOfCreation = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserDetailId);
            
            CreateTable(
                "ParikshaDev.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        Difficulty = c.Int(nullable: false),
                        DateOfCreation = c.DateTime(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        UserDetailId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("ParikshaDev.Subject", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("ParikshaDev.Users", t => t.UserDetailId, cascadeDelete: true)
                .Index(t => t.SubjectId)
                .Index(t => t.UserDetailId);
            
            CreateTable(
                "ParikshaDev.Subject",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(maxLength: 15),
                        SubjectCategory = c.String(),
                        StandardId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubjectId)
                .ForeignKey("ParikshaDev.Standard", t => t.StandardId)
                .Index(t => t.StandardId);
            
            CreateTable(
                "ParikshaDev.Standard",
                c => new
                    {
                        StandardId = c.Int(nullable: false, identity: true),
                        StandardName = c.String(),
                    })
                .PrimaryKey(t => t.StandardId);
            
            CreateTable(
                "ParikshaDev.Tests",
                c => new
                    {
                        TestId = c.Int(nullable: false, identity: true),
                        DateOfCreation = c.DateTime(nullable: false),
                        Subject_SubjectId = c.Int(),
                        Creator_UserDetailId = c.Int(),
                    })
                .PrimaryKey(t => t.TestId)
                .ForeignKey("ParikshaDev.Subject", t => t.Subject_SubjectId)
                .ForeignKey("ParikshaDev.Users", t => t.Creator_UserDetailId)
                .Index(t => t.Subject_SubjectId)
                .Index(t => t.Creator_UserDetailId);
            
            CreateTable(
                "ParikshaDev.TestQuestions",
                c => new
                    {
                        Test_TestId = c.Int(nullable: false),
                        Question_QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Test_TestId, t.Question_QuestionId })
                .ForeignKey("ParikshaDev.Tests", t => t.Test_TestId, cascadeDelete: true)
                .ForeignKey("ParikshaDev.Questions", t => t.Question_QuestionId, cascadeDelete: true)
                .Index(t => t.Test_TestId)
                .Index(t => t.Question_QuestionId);
            
            CreateTable(
                "ParikshaDev.Brief",
                c => new
                    {
                        QuestionId = c.Int(nullable: false),
                        QuestionText = c.String(),
                        Answer = c.String(),
                        Short = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("ParikshaDev.Questions", t => t.QuestionId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "ParikshaDev.Custom",
                c => new
                    {
                        QuestionId = c.Int(nullable: false),
                        QuestionText = c.String(),
                        Answer = c.String(),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("ParikshaDev.Questions", t => t.QuestionId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "ParikshaDev.Choice",
                c => new
                    {
                        QuestionId = c.Int(nullable: false),
                        QuestionText = c.String(),
                        Choices = c.String(),
                        Answers = c.String(),
                        IsMultiplechoice = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("ParikshaDev.Questions", t => t.QuestionId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "ParikshaDev.Match",
                c => new
                    {
                        QuestionId = c.Int(nullable: false),
                        QuestionText = c.String(),
                        LeftChoices = c.String(),
                        RightChoices = c.String(),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("ParikshaDev.Questions", t => t.QuestionId)
                .Index(t => t.QuestionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("ParikshaDev.Match", "QuestionId", "ParikshaDev.Questions");
            DropForeignKey("ParikshaDev.Choice", "QuestionId", "ParikshaDev.Questions");
            DropForeignKey("ParikshaDev.Custom", "QuestionId", "ParikshaDev.Questions");
            DropForeignKey("ParikshaDev.Brief", "QuestionId", "ParikshaDev.Questions");
            DropForeignKey("ParikshaDev.Questions", "UserDetailId", "ParikshaDev.Users");
            DropForeignKey("ParikshaDev.TestQuestions", "Question_QuestionId", "ParikshaDev.Questions");
            DropForeignKey("ParikshaDev.TestQuestions", "Test_TestId", "ParikshaDev.Tests");
            DropForeignKey("ParikshaDev.Tests", "Creator_UserDetailId", "ParikshaDev.Users");
            DropForeignKey("ParikshaDev.Tests", "Subject_SubjectId", "ParikshaDev.Subject");
            DropForeignKey("ParikshaDev.Subject", "StandardId", "ParikshaDev.Standard");
            DropForeignKey("ParikshaDev.Questions", "SubjectId", "ParikshaDev.Subject");
            DropIndex("ParikshaDev.Match", new[] { "QuestionId" });
            DropIndex("ParikshaDev.Choice", new[] { "QuestionId" });
            DropIndex("ParikshaDev.Custom", new[] { "QuestionId" });
            DropIndex("ParikshaDev.Brief", new[] { "QuestionId" });
            DropIndex("ParikshaDev.Questions", new[] { "UserDetailId" });
            DropIndex("ParikshaDev.TestQuestions", new[] { "Question_QuestionId" });
            DropIndex("ParikshaDev.TestQuestions", new[] { "Test_TestId" });
            DropIndex("ParikshaDev.Tests", new[] { "Creator_UserDetailId" });
            DropIndex("ParikshaDev.Tests", new[] { "Subject_SubjectId" });
            DropIndex("ParikshaDev.Subject", new[] { "StandardId" });
            DropIndex("ParikshaDev.Questions", new[] { "SubjectId" });
            DropTable("ParikshaDev.Match");
            DropTable("ParikshaDev.Choice");
            DropTable("ParikshaDev.Custom");
            DropTable("ParikshaDev.Brief");
            DropTable("ParikshaDev.TestQuestions");
            DropTable("ParikshaDev.Tests");
            DropTable("ParikshaDev.Standard");
            DropTable("ParikshaDev.Subject");
            DropTable("ParikshaDev.Questions");
            DropTable("ParikshaDev.Users");
        }
    }
}
