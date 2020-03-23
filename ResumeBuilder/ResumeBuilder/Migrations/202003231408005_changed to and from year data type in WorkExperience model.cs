namespace ResumeBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedtoandfromyeardatatypeinWorkExperiencemodel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WorkExperiences", "FromYear", c => c.String());
            AlterColumn("dbo.WorkExperiences", "ToYear", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WorkExperiences", "ToYear", c => c.DateTime());
            AlterColumn("dbo.WorkExperiences", "FromYear", c => c.DateTime());
        }
    }
}
