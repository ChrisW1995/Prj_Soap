namespace Prj_Soap.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRecords : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO OrderStatus VALUES( '�B�z��')");
            Sql("INSERT INTO OrderStatus VALUES( '�X�f��')");
            Sql("INSERT INTO OrderStatus VALUES( '�w�X�f')");
            Sql("INSERT INTO OrderStatus VALUES( '�w����')");
        }
        
        public override void Down()
        {
        }
    }
}
