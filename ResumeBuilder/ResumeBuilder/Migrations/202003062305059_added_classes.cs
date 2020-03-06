namespace ResumeBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_classes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        EduID = c.Int(nullable: false, identity: true),
                        EducationLevel = c.String(),
                        YearOfPassing = c.DateTime(),
                        CGPAorPercentage = c.Boolean(nullable: false),
                        Score = c.Double(nullable: false),
                        UserID = c.Int(nullable: false),
                        Stream_StreamID = c.Int(),
                        University_UniversityID = c.Int(),
                    })
                .PrimaryKey(t => t.EduID)
                .ForeignKey("dbo.Streams", t => t.Stream_StreamID)
                .ForeignKey("dbo.Universities", t => t.University_UniversityID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.UserInfoes", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.Stream_StreamID)
                .Index(t => t.University_UniversityID);
            
            CreateTable(
                "dbo.Streams",
                c => new
                    {
                        StreamID = c.Int(nullable: false, identity: true),
                        StreamName = c.String(),
                    })
                .PrimaryKey(t => t.StreamID);
            
            CreateTable(
                "dbo.Universities",
                c => new
                    {
                        UniversityID = c.Int(nullable: false, identity: true),
                        UniversityName = c.String(),
                    })
                .PrimaryKey(t => t.UniversityID);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        LanguageID = c.Int(nullable: false, identity: true),
                        LanguageName = c.String(),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LanguageID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.UserInfoes", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectID = c.Int(nullable: false, identity: true),
                        DurationInMonth = c.Int(nullable: false),
                        ProjectName = c.String(),
                        ProjectDetails = c.String(),
                        YourRole = c.String(),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.UserInfoes", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        SkillID = c.Int(nullable: false, identity: true),
                        SkillName = c.String(),
                        Project_ProjectID = c.Int(),
                    })
                .PrimaryKey(t => t.SkillID)
                .ForeignKey("dbo.Projects", t => t.Project_ProjectID)
                .Index(t => t.Project_ProjectID);
            
            CreateTable(
                "dbo.UserInfoes",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        AlternatePhoneNumber = c.Int(nullable: false),
                        ResumeName = c.String(),
                        Summary = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.UserSkills",
                c => new
                    {
                        UserSkillID = c.Int(nullable: false, identity: true),
                        Skill = c.String(),
                        Rating = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserSkillID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.UserInfoes", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.WorkExperiences",
                c => new
                    {
                        ExpId = c.Int(nullable: false, identity: true),
                        Organization = c.String(),
                        Designation = c.String(),
                        FromYear = c.DateTime(),
                        ToYear = c.DateTime(),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExpId)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.UserInfoes", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            AddColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkExperiences", "UserID", "dbo.UserInfoes");
            DropForeignKey("dbo.WorkExperiences", "UserID", "dbo.Users");
            DropForeignKey("dbo.UserSkills", "UserID", "dbo.UserInfoes");
            DropForeignKey("dbo.UserSkills", "UserID", "dbo.Users");
            DropForeignKey("dbo.Projects", "UserID", "dbo.UserInfoes");
            DropForeignKey("dbo.Languages", "UserID", "dbo.UserInfoes");
            DropForeignKey("dbo.Educations", "UserID", "dbo.UserInfoes");
            DropForeignKey("dbo.Projects", "UserID", "dbo.Users");
            DropForeignKey("dbo.Skills", "Project_ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Languages", "UserID", "dbo.Users");
            DropForeignKey("dbo.Educations", "UserID", "dbo.Users");
            DropForeignKey("dbo.Educations", "University_UniversityID", "dbo.Universities");
            DropForeignKey("dbo.Educations", "Stream_StreamID", "dbo.Streams");
            DropIndex("dbo.WorkExperiences", new[] { "UserID" });
            DropIndex("dbo.UserSkills", new[] { "UserID" });
            DropIndex("dbo.Skills", new[] { "Project_ProjectID" });
            DropIndex("dbo.Projects", new[] { "UserID" });
            DropIndex("dbo.Languages", new[] { "UserID" });
            DropIndex("dbo.Educations", new[] { "University_UniversityID" });
            DropIndex("dbo.Educations", new[] { "Stream_StreamID" });
            DropIndex("dbo.Educations", new[] { "UserID" });
            AlterColumn("dbo.Users", "Username", c => c.String());
            DropColumn("dbo.Users", "Password");
            DropTable("dbo.WorkExperiences");
            DropTable("dbo.UserSkills");
            DropTable("dbo.UserInfoes");
            DropTable("dbo.Skills");
            DropTable("dbo.Projects");
            DropTable("dbo.Languages");
            DropTable("dbo.Universities");
            DropTable("dbo.Streams");
            DropTable("dbo.Educations");
        }
    }
}
