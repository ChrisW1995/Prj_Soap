namespace Prj_Soap.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMessagesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        C_Id = c.String(nullable: false, maxLength: 25),
                        P_Id = c.String(nullable: false, maxLength: 15),
                        Content = c.String(maxLength: 200),
                        ReplyContent = c.String(maxLength: 200),
                        AddTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.C_Id, cascadeDelete: true)
                .ForeignKey("dbo.Soaps", t => t.P_Id, cascadeDelete: true)
                .Index(t => t.C_Id)
                .Index(t => t.P_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "P_Id", "dbo.Soaps");
            DropForeignKey("dbo.Messages", "C_Id", "dbo.Customers");
            DropIndex("dbo.Messages", new[] { "P_Id" });
            DropIndex("dbo.Messages", new[] { "C_Id" });
            DropTable("dbo.Messages");
        }
    }
}
