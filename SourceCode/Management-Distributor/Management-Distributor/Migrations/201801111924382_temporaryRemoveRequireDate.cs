namespace Management_Distributor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class temporaryRemoveRequireDate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "RequireDeliveryDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "RequireDeliveryDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
    }
}
