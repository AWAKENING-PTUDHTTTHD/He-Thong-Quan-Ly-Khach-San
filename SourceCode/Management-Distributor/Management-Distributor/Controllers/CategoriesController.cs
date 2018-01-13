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
    [Authorize]
    public class CategoriesController : Controller
    {
        private ICategoryService categoryService =  null;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Category());
            }
            else
            {
                Category category = categoryService.GetOne(id);
                return View(category);
            }

        }

        [HttpPost]
        public ActionResult AddOrEdit(Category category)
        {
            if (category.CategoryId == 0)
            {
                if (categoryService.Add(category))
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
                
                if (categoryService.Edit(category))
                {
                    return Json(new { success = true, message = "Edit successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = "Failed to edit" }, JsonRequestBehavior.AllowGet);
                }

            }
        }

        // GET: Categories
        //[Authorize]
        public ActionResult Index()
        {
            return View();
            
        }

        public JsonResult LoadData()
        {
            //var data = db.Categories.ToList();
            var data = categoryService.GetAll();
            return Json(new {  data }, JsonRequestBehavior.AllowGet);
        }

        // GET: Categories/Details/5
        public ActionResult Details(int id)
        {
            if (id  == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = categoryService.GetOne(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryId,CategoryName,Description")] Category category)
        {
            if (ModelState.IsValid)
            {
                categoryService.Add(category);
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = categoryService.GetOne(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryId,CategoryName,Description")] Category category)
        {
            if (ModelState.IsValid)
            {
                categoryService.Edit(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = categoryService.GetOne(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = categoryService.GetOne(id);
            categoryService.Delete(category);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Remove(int id)
        {
            Category category = categoryService.GetOne(id);
            categoryService.Delete(category);
            return Json(new {success=true, message="Removal success!" }, JsonRequestBehavior.AllowGet);
        }
    }
}
