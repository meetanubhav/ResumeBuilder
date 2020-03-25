namespace ResumeBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_model : DbMigration
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
                        Stream = c.String(),
                        Institution = c.String(),
                        Board = c.String(),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EduID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 100),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        AlternatePhoneNumber = c.String(),
                        ResumeName = c.String(),
                        Summary = c.String(maxLength: 100),
                        SettingsID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Settings", t => t.SettingsID, cascadeDelete: true)
                .Index(t => t.SettingsID);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        LanguageID = c.Int(nullable: false, identity: true),
                        LanguageName = c.String(),
                    })
                .PrimaryKey(t => t.LanguageID);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectID = c.Int(nullable: false, identity: true),
                        DurationInMonth = c.Byte(nullable: false),
                        ProjectName = c.String(),
                        ProjectDetails = c.String(),
                        YourRole = c.String(),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);

            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        SettingsID = c.Int(nullable: false, identity: true),
                        Education = c.Boolean(nullable: false),
                        Language = c.Boolean(nullable: false),
                        Project = c.Boolean(nullable: false),
                        Skill = c.Boolean(nullable: false),
                        WorkExperience = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SettingsID);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        SkillID = c.Int(nullable: false, identity: true),
                        SkillName = c.String(),
                    })
                .PrimaryKey(t => t.SkillID);
            
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
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.LanguageUsers",
                c => new
                    {
                        Language_LanguageID = c.Int(nullable: false),
                        User_UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Language_LanguageID, t.User_UserID })
                .ForeignKey("dbo.Languages", t => t.Language_LanguageID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_UserID, cascadeDelete: true)
                .Index(t => t.Language_LanguageID)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.SkillUsers",
                c => new
                    {
                        Skill_SkillID = c.Int(nullable: false),
                        User_UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Skill_SkillID, t.User_UserID })
                .ForeignKey("dbo.Skills", t => t.Skill_SkillID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_UserID, cascadeDelete: true)
                .Index(t => t.Skill_SkillID)
                .Index(t => t.User_UserID);
            
        }

        public override void Down()
        {
            DropForeignKey("dbo.WorkExperiences", "UserID", "dbo.Users");
            DropForeignKey("dbo.SkillUsers", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.SkillUsers", "Skill_SkillID", "dbo.Skills");
            DropForeignKey("dbo.Users", "SettingsID", "dbo.Settings");
            DropForeignKey("dbo.Projects", "UserID", "dbo.Users");
            DropForeignKey("dbo.LanguageUsers", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.LanguageUsers", "Language_LanguageID", "dbo.Languages");
            DropForeignKey("dbo.Educations", "UserID", "dbo.Users");
            DropIndex("dbo.SkillUsers", new[] { "User_UserID" });
            DropIndex("dbo.SkillUsers", new[] { "Skill_SkillID" });
            DropIndex("dbo.LanguageUsers", new[] { "User_UserID" });
            DropIndex("dbo.LanguageUsers", new[] { "Language_LanguageID" });
            DropIndex("dbo.WorkExperiences", new[] { "UserID" });
            DropIndex("dbo.Projects", new[] { "UserID" });
            DropIndex("dbo.Users", new[] { "SettingsID" });
            DropIndex("dbo.Educations", new[] { "UserID" });
            DropTable("dbo.SkillUsers");
            DropTable("dbo.LanguageUsers");
            DropTable("dbo.WorkExperiences");
            DropTable("dbo.Skills");
            DropTable("dbo.Settings");
            DropTable("dbo.Projects");
            DropTable("dbo.Languages");
            DropTable("dbo.Users");
            DropTable("dbo.Educations");
        }
    }
}
