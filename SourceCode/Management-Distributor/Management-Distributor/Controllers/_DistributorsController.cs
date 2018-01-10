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
    public class _DistributorsController : Controller
    {
        private IDistributorService distributorService = null;
        private IRegionService regionService = null;
        // GET: Distributors
        public ActionResult Index()
        {
            return View();
        }
        

        public _DistributorsController(IDistributorService distributorService, IRegionService _regionService)
        {
            this.distributorService = distributorService;
            regionService = _regionService;
        }
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            List<Region> regions = regionService.GetAll();
            ViewBag.RegionId = new SelectList(regions, "RegionId", "RegionName");

            if (id == 0)
            {
                return View(new _Distributor());
            }
            else
            {
                _Distributor distributor = distributorService.GetOne(id);
                return View(distributor);
            }

        }

        [HttpPost]
        public ActionResult AddOrEdit(_Distributor distributor)
        {

            
            if (distributor.DistributorId == 0)
            {
                if (distributorService.Add(distributor))
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

                if (distributorService.Edit(distributor))
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
        

        public JsonResult LoadData()
        {
            //var data = db.Categories.ToList();
            var data = distributorService.GetAll();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

        // GET: Categories/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _Distributor distributor = distributorService.GetOne(id);
            if (distributor == null)
            {
                return HttpNotFound();
            }
            return View(distributor);
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
        public ActionResult Create([Bind(Include = "DistributorId,CategoryName,Description")] _Distributor distributor)
        {
            if (ModelState.IsValid)
            {
                distributorService.Add(distributor);
                return RedirectToAction("Index");
            }

            return View(distributor);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _Distributor distributor = distributorService.GetOne(id);
            if (distributor == null)
            {
                return HttpNotFound();
            }
            return View(distributor);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DistributorId,CategoryName,Description")] _Distributor distributor)
        {
            if (ModelState.IsValid)
            {
                distributorService.Edit(distributor);
                return RedirectToAction("Index");
            }
            return View(distributor);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _Distributor distributor = distributorService.GetOne(id);
            if (distributor == null)
            {
                return HttpNotFound();
            }
            return View(distributor);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _Distributor distributor = distributorService.GetOne(id);
            distributorService.Delete(distributor);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Remove(int id)
        {
            _Distributor distributor = distributorService.GetOne(id);
            distributorService.Delete(distributor);
            return Json(new { success = true, message = "Removal success!" }, JsonRequestBehavior.AllowGet);
        }
    }
}