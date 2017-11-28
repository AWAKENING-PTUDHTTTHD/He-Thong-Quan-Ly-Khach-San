using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Management_Distributor.POCO;
using Management_Distributor.Dao._DbContext;
using Management_Distributor.Service.Interfaces;
using Management_Distributor.Service.Implementations;

namespace Management_Distributor.Tests.Product
{
    [TestClass]
    public class Product
    {
        [TestMethod]
        public void TestAddition()
        {

            Category category = new Category() { CategoryName = "Milk" };
            CategoryService _CategoryService = new CategoryService();
            _CategoryService.Add(category);
        }
    }
}
