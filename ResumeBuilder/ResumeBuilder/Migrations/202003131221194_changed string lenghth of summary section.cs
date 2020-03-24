namespace ResumeBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedstringlenghthofsummarysection : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Summary", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Summary", c => c.String(maxLength: 100));
        }
    }
}
