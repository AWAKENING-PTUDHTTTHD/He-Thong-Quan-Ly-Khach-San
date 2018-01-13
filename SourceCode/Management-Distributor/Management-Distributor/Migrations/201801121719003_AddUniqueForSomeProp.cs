namespace Management_Distributor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUniqueForSomeProp : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Payments", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Payments", "PaymentId", "dbo.Invoices");
            DropIndex("dbo.Payments", new[] { "PaymentId" });
            DropIndex("dbo.Payments", new[] { "EmployeeId" });
            AlterColumn("dbo.Categories", "CategoryName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Products", "ProductName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo._Distributor", "DistributorName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Employees", "Rolez", c => c.String(nullable: false));
            AlterColumn("dbo.Departments", "DepartmentName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Reports", "ReportName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Statistics", "StatisticName", c => c.String(nullable: false, maxLength: 100));
            CreateIndex("dbo.Categories", "CategoryName", unique: true);
            CreateIndex("dbo.Products", "ProductName", unique: true);
            CreateIndex("dbo._Distributor", "DistributorName", unique: true);
            CreateIndex("dbo.Departments", "DepartmentName", unique: true);
            CreateIndex("dbo.Reports", "ReportName", unique: true);
            CreateIndex("dbo.Statistics", "StatisticName", unique: true);
            DropTable("dbo.Payments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentId = c.Int(nullable: false),
                        Cardnumber = c.String(nullable: false),
                        Status = c.String(nullable: false),
                        Note = c.String(),
                        ExceedDate = c.DateTime(nullable: false),
                        PaidDate = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InvoiceId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentId);
            
            DropIndex("dbo.Statistics", new[] { "StatisticName" });
            DropIndex("dbo.Reports", new[] { "ReportName" });
            DropIndex("dbo.Departments", new[] { "DepartmentName" });
            DropIndex("dbo._Distributor", new[] { "DistributorName" });
            DropIndex("dbo.Products", new[] { "ProductName" });
            DropIndex("dbo.Categories", new[] { "CategoryName" });
            AlterColumn("dbo.Statistics", "StatisticName", c => c.String(nullable: false));
            AlterColumn("dbo.Reports", "ReportName", c => c.String(nullable: false));
            AlterColumn("dbo.Departments", "DepartmentName", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Rolez", c => c.String());
            AlterColumn("dbo._Distributor", "DistributorName", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "ProductName", c => c.String(nullable: false));
            AlterColumn("dbo.Categories", "CategoryName", c => c.String(nullable: false));
            CreateIndex("dbo.Payments", "EmployeeId");
            CreateIndex("dbo.Payments", "PaymentId");
            AddForeignKey("dbo.Payments", "PaymentId", "dbo.Invoices", "InvoiceId");
            AddForeignKey("dbo.Payments", "EmployeeId", "dbo.Employees", "EmployeeId");
        }
    }
}
