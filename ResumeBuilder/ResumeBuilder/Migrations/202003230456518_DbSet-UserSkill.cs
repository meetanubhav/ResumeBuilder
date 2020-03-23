namespace ResumeBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbSetUserSkill : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.SkillUsers", newName: "SkillUser1");
            CreateTable(
                "dbo.SkillUsers",
                c => new
                    {
                        Skill_SkillID = c.Int(nullable: false, identity: true),
                        User_UserID = c.String(),
                    })
                .PrimaryKey(t => t.Skill_SkillID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SkillUsers");
            RenameTable(name: "dbo.SkillUser1", newName: "SkillUsers");
        }
    }
}
