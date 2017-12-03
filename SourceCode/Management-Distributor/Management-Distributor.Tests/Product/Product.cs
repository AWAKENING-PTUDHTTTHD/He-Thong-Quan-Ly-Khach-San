using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Management_Distributor.POCO;
using Management_Distributor.Dao._DbContext;
using Management_Distributor.Service.Interfaces;
using Management_Distributor.Service.Implementations;
using Management_Distributor.Dao.Implementations;
using NLog;
using System.Collections.Generic;

namespace Management_Distributor.Tests.Product
{
    [TestClass]
    public class Product
    {
        [TestMethod]
        public void TestAddition()
        {

            ManagementDistributorDbContext context = new ManagementDistributorDbContext();
            GenericUnitOfWork uow = new GenericUnitOfWork(context);
            CategoryService ctgr = new CategoryService(uow, LogManager.GetCurrentClassLogger());
            ctgr.AddRange(new List<Category>()
                    {
                          new POCO.Category { CategoryId = "C000000003", CategoryName = "Milk"},
                          new POCO.Category { CategoryId = "C000000004", CategoryName = "Yourgut"},
                          new POCO.Category { CategoryId = "C000000005", CategoryName = "Whey"}
                    })
              ;
        }
    }
}
