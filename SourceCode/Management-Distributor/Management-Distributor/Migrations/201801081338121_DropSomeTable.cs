namespace Management_Distributor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropSomeTable : DbMigration
    {
        public override void Up()
        {
        }
        
        public override void Down()
        {
            DropTable("dbo.ProductUnits");
            DropTable("dbo.Units");
        }
    }
}
