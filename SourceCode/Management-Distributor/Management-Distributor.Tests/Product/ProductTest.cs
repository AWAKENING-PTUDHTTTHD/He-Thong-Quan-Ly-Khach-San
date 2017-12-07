using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Distributor.POCO;
using Distributor.Dao._DbContext;
using Distributor.Service.Interfaces;
using Distributor.Service.Implementations;
using Distributor.Dao.Implementations;
using NLog;
using System.Collections.Generic;

namespace Distributor.Tests.Product
{
    [TestClass]
    public class Product
    {
        [TestMethod]
        public void TestAddition()
        {
            GenericUnitOfWork uow = new GenericUnitOfWork();
            CategoryService ctgr = new CategoryService(uow);
            ctgr.AddRange(new List<Category>()
                    {
                          new POCO.Category { CategoryName = "Liquid Milk"},
                          new POCO.Category { CategoryName = "Yourgut"},
                          new POCO.Category { CategoryName = "Powdered milk"},
                          new POCO.Category { CategoryName = "Infant Cereals"},
                          new POCO.Category { CategoryName = "Condensed Milk"},
                          new POCO.Category { CategoryName = "Special Nutrition Products for Adults"},
                          new POCO.Category { CategoryName = "Beverages"},
                          new POCO.Category { CategoryName = "Ice Cream"},
                          new POCO.Category { CategoryName = "Cheese"},
                          new POCO.Category { CategoryName = "Soymilk"}
                    })
              ;
        }

        //[TestMethod]
        //public void TestUpdate()
        //{
        //    GenericUnitOfWork uow = new GenericUnitOfWork();
        //    CategoryService ctgr = new CategoryService(uow);
        //    Category category = ctgr.GetOne("C000000002");
        //    bool success = false;
        //    if(category!= null)
        //    {
        //        category.Description = "lol";
        //        if(ctgr.Edit(category))
        //        {
        //            success = true;
        //        }
        //    }
        //    Assert.AreEqual(true, success);
        //}
    }
}
