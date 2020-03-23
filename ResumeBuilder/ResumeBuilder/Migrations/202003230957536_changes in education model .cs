namespace ResumeBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changesineducationmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Educations", "YearOfPassingTmp", c => c.Int());
            DropColumn("dbo.Educations", "YearOfPassing");
            RenameColumn("dbo.Educations", "YearOfPassingTmp", "YearOfPassing");
            AddColumn("dbo.Educations", "CGPAorPercentageTmp", c => c.String());
            DropColumn("dbo.Educations", "CGPAorPercentage");
            RenameColumn("dbo.Educations", "CGPAorPercentageTmp", "CGPAorPercentage");
        }

        public override void Down()
        {
            AlterColumn("dbo.Educations", "CGPAorPercentage", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Educations", "YearOfPassing", c => c.DateTime());
        }
    }
}
