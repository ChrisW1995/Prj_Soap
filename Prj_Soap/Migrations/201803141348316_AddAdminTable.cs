namespace Prj_Soap.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdminTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Account = c.String(nullable: false, maxLength: 25),
                        Passowrd = c.String(nullable: false, maxLength: 25),
                        Adm_Name = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.Account);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Admins");
        }
    }
}
