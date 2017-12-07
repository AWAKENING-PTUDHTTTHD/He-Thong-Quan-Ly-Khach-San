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
        public ActionResult Index()
        {
            var products = productService.GetAll();
            return View(products);
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
    }
}
