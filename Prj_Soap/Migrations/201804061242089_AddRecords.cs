namespace Prj_Soap.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRecords : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO OrderStatus VALUES( '處理中')");
            Sql("INSERT INTO OrderStatus VALUES( '出貨中')");
            Sql("INSERT INTO OrderStatus VALUES( '已出貨')");
            Sql("INSERT INTO OrderStatus VALUES( '已取消')");
        }
        
        public override void Down()
        {
        }
    }
}
