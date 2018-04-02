namespace Prj_Soap.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderIdInCarts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "OrderId", c => c.String(maxLength: 25));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Carts", "OrderId");
        }
    }
}
