namespace Management_Distributor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAvailableQtyToProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "AvailableQty", c => c.Int(nullable: false, defaultValue: 0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "AvailableQty");
        }
    }
}
