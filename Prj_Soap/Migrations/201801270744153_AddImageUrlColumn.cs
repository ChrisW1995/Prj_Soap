namespace Prj_Soap.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageUrlColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Soaps", "ImageUrl", c => c.String());
            AddColumn("dbo.Soaps", "UploadTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Soaps", "AddTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Soaps", "AddTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Soaps", "UploadTime");
            DropColumn("dbo.Soaps", "ImageUrl");
        }
    }
}
