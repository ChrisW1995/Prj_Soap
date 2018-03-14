namespace Prj_Soap.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumn_AddCount_InCartsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "AddCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Carts", "AddCount");
        }
    }
}
