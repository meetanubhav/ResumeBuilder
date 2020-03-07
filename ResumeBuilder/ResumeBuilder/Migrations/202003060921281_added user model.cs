namespace ResumeBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedusermodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
            "dbo.Users",
            c => new
            {
                UserID = c.Int(nullable: false, identity: true),
                Username = c.String(),
            })
            .PrimaryKey(t => t.UserID);

        }

        public override void Down()
        {

            DropTable("dbo.Users");
        }
    }
}
