using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Distributor.Controllers;
using Distributor.Dao.Implementations;
using Distributor.POCO;
using Distributor.Service.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Management_Distributor.Tests.Controllers
{
    [TestClass]
    public class CategoriesControllerTest
    {
        private static GenericUnitOfWork uow = new GenericUnitOfWork();
        private static CategoryService categoryService = new CategoryService(uow);

        // helper
        private static T GetValueFromJsonResult<T>(JsonResult jsonResult, string propertyName)
        {
            var property =
                jsonResult.Data.GetType().GetProperties()
                .Where(p => string.Compare(p.Name, propertyName) == 0)
                .FirstOrDefault();

            if (null == property)
                throw new ArgumentException("propertyName not found", "propertyName");
            return (T)property.GetValue(jsonResult.Data, null);
        }
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
            var controller = new CategoriesController(categoryService);
            var result = controller.Index() as ViewResult;
            Assert.AreNotEqual("Index", result.ViewName);
        }

        // Case 2 - Testing the View Data returned by a Controller

        [TestMethod]
        public void TestDetailsViewData()
        {
            var controller = new CategoriesController(categoryService);
            int categoryID = 62;
            var result = controller.Details(categoryID) as ViewResult;
            var category = (Category)result.Model;
            Assert.AreEqual("Liquid Milk", category.CategoryName);
        }

        // Case 3 - Testing the Action Result returned by a Controller
        [TestMethod]
        public void TestDetailsRedirect()
        {
            var controller = new CategoriesController(categoryService);
            int categoryID = 92;
            var result = controller.Details(categoryID) as HttpStatusCodeResult;
            Assert.AreEqual(404, result.StatusCode);
        }

        // case 4 - Test JsonResult
        [TestMethod]
        public void TestJsonResult()
        {
            var controller = new CategoriesController(categoryService);
            JsonResult actual = controller.LoadData() as JsonResult;
            //List<Category> categories = actual.Data as List<Category>;
            dynamic data = actual.Data;
            int numberRecord = 2;
            Assert.AreEqual(numberRecord, data.Count);
        }

        // case 5 - Test JsonResult return as Creation Result
        [TestMethod]
        public static void TestJsonResultCreationSuccess()
        {
            var controller = new CategoriesController(categoryService);
            Category category = new Category() { CategoryName = "SoyMilk" };
            var  jsonRes = controller.AddOrEdit(category) as JsonResult;
            dynamic data = jsonRes.Data;
            //bool testValue = GetValueFromJsonResult<bool>(jsonRes, "success");
            bool success = (bool)(new PrivateObject(jsonRes.Data, "success")).Target;
            Assert.IsTrue(success);

        }

    }
}
