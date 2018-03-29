namespace Prj_Soap.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAboutTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(maxLength: 100),
                        PhoneNumber = c.String(maxLength: 15),
                        Email = c.String(maxLength: 100),
                        Content = c.String(),
                        FaceBookUrl = c.String(),
                        GoogPlusUrl = c.String(),
                        TwitterUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Abouts");
        }
    }
}
