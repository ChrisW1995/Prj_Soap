namespace Prj_Soap.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CahngeRVTableAddScore : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "Score", c => c.Int(nullable: false));
            DropColumn("dbo.Reviews", "ReviewImgUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reviews", "ReviewImgUrl", c => c.String());
            DropColumn("dbo.Reviews", "Score");
        }
    }
}
