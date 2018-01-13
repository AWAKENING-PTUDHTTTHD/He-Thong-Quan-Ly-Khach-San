namespace Management_Distributor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveSomeRedundantColumn : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "LastLogged", c => c.DateTime());
            AlterColumn("dbo.Employees", "LastAttemp", c => c.DateTime());
            DropColumn("dbo.Employees", "Salt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Salt", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "LastAttemp", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Employees", "LastLogged", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
    }
}
