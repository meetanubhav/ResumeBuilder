namespace ResumeBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class made_settingID_nullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "SettingsID", "dbo.Settings");
            DropIndex("dbo.Users", new[] { "SettingsID" });
            AlterColumn("dbo.Users", "SettingsID", c => c.Int());
            CreateIndex("dbo.Users", "SettingsID");
            AddForeignKey("dbo.Users", "SettingsID", "dbo.Settings", "SettingsID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "SettingsID", "dbo.Settings");
            DropIndex("dbo.Users", new[] { "SettingsID" });
            AlterColumn("dbo.Users", "SettingsID", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "SettingsID");
            AddForeignKey("dbo.Users", "SettingsID", "dbo.Settings", "SettingsID", cascadeDelete: true);
        }
    }
}
