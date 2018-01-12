namespace Management_Distributor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class amendedRequireDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "RequireDeliveryDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "RequireDeliveryDate");
        }
    }
}
