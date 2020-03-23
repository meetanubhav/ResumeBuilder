namespace ResumeBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            //RenameTable(name: "dbo.SkillUser1", newName: "SkillUsers");
            //DropTable("dbo.SkillUsers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SkillUsers",
                c => new
                    {
                        Skill_SkillID = c.Int(nullable: false, identity: true),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.Skill_SkillID);
            
            RenameTable(name: "dbo.SkillUsers", newName: "SkillUser1");
        }
    }
}
