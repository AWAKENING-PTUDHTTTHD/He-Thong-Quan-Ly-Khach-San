using OrdersManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
//using System.DateTime;

namespace OrdersManagement.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getCategories()
        {
            List<Category> categories = new List<Category>();
            using (MyDatabaseEntities3 dc = new MyDatabaseEntities3())
            {
                categories = dc.Categories.OrderBy(a => a.CategoryName).ToList();
            }
            return new JsonResult { Data = categories, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult getProducts(int categoryID)
        {
            List<Product> products = new List<Product>();
            using (MyDatabaseEntities3 dc = new MyDatabaseEntities3())
            {
                products = dc.Products.Where(a => a.CategoryID.Equals(categoryID)).OrderBy(a => a.ProductName).ToList();
            }
            return new JsonResult { Data = products, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }



        [HttpPost]
        public JsonResult save(Order order)
        {
            bool status = false;
            DateTime dateOrg;
            //var isValidDate1 = DateTime.TryParseExact(order.OrderDate, "mm-dd-yyyy", null, System.Globalization.DateTimeStyles.None, out dateOrg);
            var isValidData1 = DateTime.TryParseExact(order.OrderDateString, "DD-mmm-yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateOrg);
            if (isValidData1)
            {
                order.OrderDate = dateOrg;
            }

            var isValidDate2 = DateTime.TryParseExact(order.DeliveryDateString, "DD-mmm-yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateOrg);
            if (isValidDate2)
            {
                order.DeliveryDate = dateOrg;
            }

            var isValidModel = TryUpdateModel(order);
            if (isValidModel)
            {
                using (MyDatabaseEntities3 dc = new MyDatabaseEntities3())
                {
                    dc.Orders.Add(order);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }
        
	}
}