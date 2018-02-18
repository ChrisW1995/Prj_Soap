namespace Prj_Soap.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSoapTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Soaps",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 15),
                        ItemName = c.String(nullable: false, maxLength: 50),
                        ItemContent = c.String(maxLength: 250),
                        Price = c.Int(nullable: false),
                        IsInStock = c.Boolean(nullable: false),
                        AddTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Soaps");
        }
    }
}
