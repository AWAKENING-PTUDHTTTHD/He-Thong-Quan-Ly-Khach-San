using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Distributor.Controllers;
using Distributor.Dao.Implementations;
using Distributor.POCO;
using Distributor.Service.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Management_Distributor.Tests.Controllers
{
    [TestClass]
    public class ProductsControllerTest
    {
        private static GenericUnitOfWork uow = new GenericUnitOfWork();
        private static CategoryService categoryService = new CategoryService(uow);
        private static ProductService productService = new ProductService(uow);
        private static ProductsController controller = new ProductsController(productService, categoryService);
        // Test Validition 
        [TestMethod]
        public void Test_Validation()
        {
            Category category = new Category() { CategoryName = "" };
            var context = new ValidationContext(category, null, null);
            var result = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(category, context, result, true);

            Assert.AreEqual(false, isModelStateValid);
        }

        // Case 1 - Testing the View returned by a Controller
        [TestMethod]
        public void TestReturnIndexViews()
        {
            var result = controller.Index() as ViewResult;
            Assert.AreNotEqual("Index", result.ViewName);
        }

        // Case 2 - Testing the View Data returned by a Controller

        [TestMethod]
        public void TestDetailsViewData()
        {
            var result = controller.Details(1009) as ViewResult;
            var product = (Product)result.Model;
            Assert.AreEqual("Twin Cows UHT imported fresh milk from New Zealand", product.ProductName);
        }

        // Case 3 - Testing the Action Result returned by a Controller
        [TestMethod]
        public void TestDetailsRedirect()
        {
            int productID = 10099;
            var result = controller.Details(productID) as HttpStatusCodeResult;
            Assert.AreEqual(404, result.StatusCode);
        }

        // case 4 - Test JsonResult
        [TestMethod]
        public void TestJsonResult()
        {
            JsonResult actual = controller.LoadData(62) as JsonResult;
            //List<Category> categories = actual.Data as List<Category>;
            dynamic data = actual.Data;
            int numberRecord = 1;
            Assert.AreEqual(numberRecord, data.Count);
        }

        // case 5 - Test JsonResult return as Creation Result
        [TestMethod]
        public static void TestJsonResultCreationSuccess()
        {
            Product product = new Product() {
                ProductName= "Vfresh 100% Fruit Juice - Grape (1L)",
                Price = 125000,
                CategoryId = 63,
                AvailableQty = 560,

            };
            var jsonRes = controller.AddOrEdit(product) as JsonResult;
            dynamic data = jsonRes.Data;
            //bool testValue = GetValueFromJsonResult<bool>(jsonRes, "success");
            bool success = (bool)(new PrivateObject(jsonRes.Data, "success")).Target;
            Assert.IsTrue(success);

        }
    }
}
