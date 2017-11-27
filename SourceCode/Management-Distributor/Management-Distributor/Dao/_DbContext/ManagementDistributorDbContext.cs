using Management_Distributor.POCO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Management_Distributor.Dao._DbContext
{
    public class ManagementDistributorDbContext:DbContext
    {
        public ManagementDistributorDbContext() :base("name=connectionString")
        {

        }

        public DbSet<Department> _Department { get; set; }
        public DbSet<Employee> _Employees { get; set; }

        public DbSet<Region> _Region { get; set; }
        public DbSet<Distributor> _Distributor { get; set; }
        public DbSet<Contract> _Contract { get; set; }

        public DbSet<Category> _Category { get; set; }
        public DbSet<Product> _Product { get; set; }

        public DbSet<Order> _Order { get; set; }
        public DbSet<OrdersDetails> _OrdersDetails { get; set; }
        public DbSet<Invoice> _Invoice { get; set; }
        public DbSet<Payment> _Payment { get; set; }
        public DbSet<DeliveryPlan> _DeliveryPlan { get; set; }

        public DbSet<Report> _Report { get; set; }
        public DbSet<Statistic> _Statistic { get; set; }
    }
}