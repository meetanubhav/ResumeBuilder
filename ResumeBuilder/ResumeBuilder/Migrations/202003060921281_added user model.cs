namespace ResumeBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedusermodel : DbMigration
    {
        public override void Up()
        {
     
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Username", c => c.String());
            DropColumn("dbo.Users", "Password");
        }
    }
}
