namespace Prj_Soap.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatusTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StatusName = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Orders", "StatusId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "StatusId");
            AddForeignKey("dbo.Orders", "StatusId", "dbo.OrderStatus", "Id", cascadeDelete: true);
            DropColumn("dbo.Orders", "CheckStatus");

        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "CheckStatus", c => c.String());
            DropForeignKey("dbo.Orders", "StatusId", "dbo.OrderStatus");
            DropIndex("dbo.Orders", new[] { "StatusId" });
            DropColumn("dbo.Orders", "StatusId");
            DropTable("dbo.OrderStatus");
        }
    }
}
