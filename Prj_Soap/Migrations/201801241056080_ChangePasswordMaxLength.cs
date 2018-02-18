namespace Prj_Soap.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePasswordMaxLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Account", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Customers", "Password", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Customers", "Email", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Customers", "Phone", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Customers", "DetailAddress", c => c.String(nullable: false, maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "DetailAddress", c => c.String(maxLength: 250));
            AlterColumn("dbo.Customers", "Phone", c => c.String(maxLength: 10));
            AlterColumn("dbo.Customers", "Email", c => c.String(maxLength: 200));
            AlterColumn("dbo.Customers", "Name", c => c.String(maxLength: 25));
            AlterColumn("dbo.Customers", "Password", c => c.String(maxLength: 25));
            AlterColumn("dbo.Customers", "Account", c => c.String(maxLength: 25));
        }
    }
}
