namespace ResumeBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changed_phone_annotation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserInfoes", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.UserInfoes", "AlternatePhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserInfoes", "AlternatePhoneNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.UserInfoes", "PhoneNumber", c => c.Int(nullable: false));
        }
    }
}
