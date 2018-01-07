namespace Management_Distributor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInvoiceCreatedDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "Created_At", c => c.DateTime(nullable: false, defaultValue: DateTime.Now));
            AlterColumn("dbo.Invoices", "CreatedDate", c => c.DateTime(nullable: false, defaultValueSql: "GETDATE()"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Invoices", "CreatedDate", c => c.DateTime());
            DropColumn("dbo.Invoices", "Created_At");
        }
    }
}
