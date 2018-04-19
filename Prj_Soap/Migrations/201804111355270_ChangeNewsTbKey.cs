namespace Prj_Soap.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeNewsTbKey : DbMigration
    {
        public override void Up()
        {

            DropPrimaryKey("dbo.News");

            DropColumn("dbo.News", "Id");
            AddColumn("dbo.News", "Id", c => c.String(nullable: false, maxLength: 20));

            AddPrimaryKey("dbo.News", "Id");
        }
        
        public override void Down()
        {

            DropPrimaryKey("dbo.News");

            DropColumn("dbo.News", "Id");
            AddColumn("dbo.News", "Id", c => c.Int(nullable: false, identity: true));

            AddPrimaryKey("dbo.News", "Id");
        }
    }
}
