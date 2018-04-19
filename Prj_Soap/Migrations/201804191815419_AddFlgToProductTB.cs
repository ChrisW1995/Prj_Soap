namespace Prj_Soap.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFlgToProductTB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Soaps", "Flg", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Soaps", "Flg");
        }
    }
}
