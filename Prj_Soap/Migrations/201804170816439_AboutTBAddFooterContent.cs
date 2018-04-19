namespace Prj_Soap.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AboutTBAddFooterContent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "FooterContent", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Abouts", "FooterContent");
        }
    }
}
