namespace Prj_Soap.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRecordToOrderStatusTb2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "StatusId", "dbo.OrderStatus");
            DropPrimaryKey("dbo.OrderStatus");
            AlterColumn("dbo.OrderStatus", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.OrderStatus", "Id");
            AddForeignKey("dbo.Orders", "StatusId", "dbo.OrderStatus", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "StatusId", "dbo.OrderStatus");
            DropPrimaryKey("dbo.OrderStatus");
            AlterColumn("dbo.OrderStatus", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.OrderStatus", "Id");
            AddForeignKey("dbo.Orders", "StatusId", "dbo.OrderStatus", "Id", cascadeDelete: true);
        }
    }
}
