namespace Prj_Soap.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerIdinOrders : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "C_Id", c => c.String(nullable: false, maxLength: 25));
            CreateIndex("dbo.Orders", "C_Id");
            AddForeignKey("dbo.Orders", "C_Id", "dbo.Customers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "C_Id", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "C_Id" });
            DropColumn("dbo.Orders", "C_Id");
        }
    }
}
