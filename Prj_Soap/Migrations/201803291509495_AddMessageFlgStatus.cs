namespace Prj_Soap.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMessageFlgStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "Flg", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "Flg");
        }
    }
}
