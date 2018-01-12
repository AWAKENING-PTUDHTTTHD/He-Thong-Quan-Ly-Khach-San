namespace Management_Distributor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveUnitProperTyFromOrderDetail : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.OrderDetails", "Unit");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDetails", "Unit", c => c.String(nullable: false));
        }
    }
}
