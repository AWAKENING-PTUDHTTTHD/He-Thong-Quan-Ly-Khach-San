using Distributor.POCO;
using Management_Distributor.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Management_Distributor.Controllers
{
    [Authorize(Roles = "staff")]
    public class RegionsController : Controller
    {
        private IRegionService regionService = null;

        public RegionsController(IRegionService regionService)
        {
            this.regionService = regionService;
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Region());
            }
            else
            {
                Region Region = regionService.GetOne(id);
                return View(Region);
            }

        }

        [HttpPost]
        public ActionResult AddOrEdit(Region Region)
        {
            if (Region.RegionId == 0)
            {
                if (regionService.Add(Region))
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

                if (regionService.Edit(Region))
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
            return View();

        }

        public JsonResult LoadData()
        {
            //var data = db.Categories.ToList();
            var data = regionService.GetAll();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

        // GET: Categories/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Region Region = regionService.GetOne(id);
            if (Region == null)
            {
                return HttpNotFound();
            }
            return View(Region);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RegionId,RegionName,Description")] Region Region)
        {
            if (ModelState.IsValid)
            {
                regionService.Add(Region);
                return RedirectToAction("Index");
            }

            return View(Region);
        }

        // GET: Categories/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    if (id == 0)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Region Region = regionService.GetOne(id);
        //    if (Region == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(Region);
        //}

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RegionId,RegionName,Description")] Region Region)
        {
            if (ModelState.IsValid)
            {
                regionService.Edit(Region);
                return RedirectToAction("Index");
            }
            return View(Region);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Region Region = regionService.GetOne(id);
            if (Region == null)
            {
                return HttpNotFound();
            }
            return View(Region);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Region Region = regionService.GetOne(id);
            regionService.Delete(Region);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Remove(int id)
        {
            Region Region = regionService.GetOne(id);
            regionService.Delete(Region);
            return Json(new { success = true, message = "Removal success!" }, JsonRequestBehavior.AllowGet);
        }
    }
}