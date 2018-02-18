namespace Prj_Soap.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropInCustomers : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Customers", new[] { "CountyId" });
            DropIndex("dbo.Customers", new[] { "AreaId" });
            RenameColumn(table: "dbo.Customers", name: "AreaId", newName: "Areas_Id");
            RenameColumn(table: "dbo.Customers", name: "CountyId", newName: "Counties_Id");
            AddColumn("dbo.Customers", "Phone", c => c.String(maxLength: 10));
            AlterColumn("dbo.Customers", "Name", c => c.String(maxLength: 25));
            AlterColumn("dbo.Customers", "Email", c => c.String(maxLength: 200));
            AlterColumn("dbo.Customers", "Counties_Id", c => c.Int());
            AlterColumn("dbo.Customers", "Areas_Id", c => c.Int());
            AlterColumn("dbo.Customers", "DetailAddress", c => c.String(maxLength: 250));
            CreateIndex("dbo.Customers", "Counties_Id");
            CreateIndex("dbo.Customers", "Areas_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Customers", new[] { "Areas_Id" });
            DropIndex("dbo.Customers", new[] { "Counties_Id" });
            AlterColumn("dbo.Customers", "DetailAddress", c => c.String());
            AlterColumn("dbo.Customers", "Areas_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "Counties_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "Email", c => c.String());
            AlterColumn("dbo.Customers", "Name", c => c.String());
            DropColumn("dbo.Customers", "Phone");
            RenameColumn(table: "dbo.Customers", name: "Counties_Id", newName: "CountyId");
            RenameColumn(table: "dbo.Customers", name: "Areas_Id", newName: "AreaId");
            CreateIndex("dbo.Customers", "AreaId");
            CreateIndex("dbo.Customers", "CountyId");
        }
    }
}
