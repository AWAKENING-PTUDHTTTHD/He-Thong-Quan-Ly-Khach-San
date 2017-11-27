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
    }
}