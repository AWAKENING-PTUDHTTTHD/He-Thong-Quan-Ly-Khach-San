using Distributor.POCO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Distributor.Dao._DbContext
{
    public class ManagementDistributorDbContext:DbContext
    {
        public ManagementDistributorDbContext() 
            : base("name=DbContext")
        {
            Database.SetInitializer<ManagementDistributorDbContext>(new CreateDatabaseIfNotExists<ManagementDistributorDbContext>());
            this.Configuration.ProxyCreationEnabled = false;
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Region> Regions { get; set; }
        public DbSet<_Distributor> Distributors { get; set; }
       // public DbSet<Contract> Contracts { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<DeliveryPlan> DeliveryPlans { get; set; }

        public DbSet<Report> Reports { get; set; }
        public DbSet<Statistic> Statistics { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<_Distributor>().HasMany(i => i.Contracts).WithRequired().WillCascadeOnDelete(false);
        //}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        }
    }
}