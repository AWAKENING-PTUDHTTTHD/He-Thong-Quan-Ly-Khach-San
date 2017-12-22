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
using Management_Distributor.ViewModels;

namespace Distributor.Controllers
{
    [AllowAnonymous]
    public class ProductsController : Controller
    {
        private IProductService productService = null;
        private ICategoryService categoryService = null;
        public ProductsController(IProductService _productService, ICategoryService _categoryService)
        {
            productService = _productService;
            categoryService = _categoryService;
        }
        // GET: Products

        // Page

        public ActionResult Page(int page = 1)
        {
            List<Product> productz = productService.GetPage(page);
            ProductsListViewModel model = new ProductsListViewModel()
            {
                products = productz,
                pagingInfo = new Pagination.PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = PageConfig.PageSize,
                    TotalItems = productService.GetAll().Count()
                }

        };
            return View(model);
        }
        public JsonResult LoadData(int categoryId)
        {
            //var data = db.Categories.ToList();
            var data = productService.GetByCategory(categoryId);
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
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
            if(product.ImageUrl != "")
            {
                string fileName = Path.GetFileNameWithoutExtension(product.ImageUpload.FileName);
                string extension = Path.GetExtension(product.ImageUpload.FileName);

                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                product.ImageUrl = "~/Uploads/ProductImages/" + fileName;
                product.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Uploads/ProductImages/"), fileName));
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

        public ActionResult Index()
        {
            //var products = productService.GetAll();
            // return View(products);
            return View();
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = productService.GetOne(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public List<Category> CategoriesForSelectList()
        {
            return categoryService.GetAll();
        }
        // GET: Products/Create
        public ActionResult Create()
        {
            List<Category> categories = categoryService.GetAll();
            ViewBag.CategoryId = new SelectList(categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,Price,Description,CategoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                productService.Add(product);
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(CategoriesForSelectList(), "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = productService.GetOne(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(CategoriesForSelectList(), "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,Price,Description,CategoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                productService.Edit(product);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(CategoriesForSelectList(), "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = productService.GetOne(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = productService.GetOne(id);
            productService.Delete(product);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Remove(int id)
        {
            Product product = productService.GetOne(id);
            productService.Delete(product);
            return Json(new { success = true, message = "Removal success!" }, JsonRequestBehavior.AllowGet);
        }
    }
}
