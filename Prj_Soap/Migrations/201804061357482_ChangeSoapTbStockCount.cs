namespace Prj_Soap.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeSoapTbStockCount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Soaps", "StockCount", c => c.Int(nullable: false));
            DropColumn("dbo.Soaps", "IsInStock");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Soaps", "IsInStock", c => c.Boolean(nullable: false));
            DropColumn("dbo.Soaps", "StockCount");
        }
    }
}
