namespace Management_Distributor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDatimeToDatime2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "RequireDeliveryDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "RequireDeliveryDate", c => c.DateTime());
        }
    }
}
