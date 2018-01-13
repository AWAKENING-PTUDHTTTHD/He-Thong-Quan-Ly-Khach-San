using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Distributor.Dao._DbContext;
using Distributor.POCO;
using Distributor.Service.Interfaces;
using System.IO;
using Distributor.ViewModels;
using Pagination;

namespace Distributor.Controllers
{

    [Authorize(Roles = "staff")]
    public class ProductsController : Controller
    {
        private IProductService productService = null;
        private ICategoryService categoryService = null;

        public ProductsController(IProductService _productService, ICategoryService _categoryService)
        {
            productService = _productService;
            categoryService = _categoryService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Page(int page = 1)
        {
            List<Product> productz = productService.GetPage(page);
            ProductsListViewModel model = new ProductsListViewModel(){
                Products = productz,
                PagingInfo = new Pagination.PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = PageConfig.PageSize,
                    TotalItems = productService.GetAll().Count()
                }};

            return View(model);
        }

        public JsonResult LoadData(int categoryId)
        {
            var data = productService.GetByCategory(Convert.ToInt32(categoryId));
            return Json(new { data }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            List<Category> categories = categoryService.GetAll();
            ViewBag.CategoryId = new SelectList(categories, "CategoryId", "CategoryName");
            if (id == 0)
            {
                return View(new Product());
            }
            else
            {
                Product product = productService.GetOne(id);
                return View(product);
            }

        }

        [HttpPost]
        public ActionResult AddOrEdit(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.ImageUrl != "")
                {
                    string fileName = Path.GetFileNameWithoutExtension(product.ImageUpload.FileName);
                    string extension = Path.GetExtension(product.ImageUpload.FileName);

                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    product.ImageUrl = "/Uploads/ProductImages/" + fileName;
                    product.ImageUpload.SaveAs(Path.Combine(Server.MapPath("/Uploads/ProductImages/"), fileName));
                }
                if (product.ProductId == 0)
                {
                    if (productService.Add(product))
                    {
                        return Json(new { success = true, message = "Add successfully" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, message = "Failed to add" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {

                    if (productService.Edit(product))
                    {
                        return Json(new { success = true, message = "Edit successfully" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, message = "Failed to edit" }, JsonRequestBehavior.AllowGet);
                    }

                }
            }
            else return View();
            
        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(int id)
        {
            Product product = productService.GetOne(id);
            productService.Delete(product);
            return Json(new { success = true, message = "Removal success!" }, JsonRequestBehavior.AllowGet);
        }
    }
}
