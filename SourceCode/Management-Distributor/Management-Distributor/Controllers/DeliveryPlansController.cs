using Distributor.POCO;
using Distributor.Service.Interfaces;
using Distributor.ViewModels;
using Management_Distributor.Service.Interfaces;
using Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Management_Distributor.Controllers
{
    [Authorize]
    public class DeliveryPlansController : Controller
    {


        private IDeliveryPlanService deliveryPlanService = null;
        private IOrderService orderService = null;
        private IDistributorService distributorService = null;

        public DeliveryPlansController(IDeliveryPlanService _deliveryPlanService, IOrderService _orderService, IDistributorService _distributorService)
        {
            this.deliveryPlanService = _deliveryPlanService;
            this.orderService = _orderService;
        }
        // GET: DeliveryPlans
         public ActionResult Index()
        {
            return View();
        }
        // GET: Products

        // Page

        public ActionResult Page(int page = 1)
        {
            List<DeliveryPlan> productz = deliveryPlanService.GetPage(page);
            DeliveryPlansListViewModel model = new DeliveryPlansListViewModel()
            {
                DeliveryPlans = productz,
                PagingInfo = new Pagination.PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = PageConfig.PageSize,
                    TotalItems = deliveryPlanService.GetAll().Count()
                }

            };
            return View(model);
        }
        public JsonResult LoadData(int deliveryPlanId)
        {
            //var data = db.Categories.ToList();
            var data = deliveryPlanService.GetAll();
            return Json(new { data }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {

            List<Order> orders = orderService.GetAll();
            ViewBag.OrderId = new SelectList(orders, "OrderID", "OrderId");

            if (id == 0)
            {
                return View(new DeliveryPlan());
            }
            else
            {
                DeliveryPlan deliveryPlan = deliveryPlanService.GetOne(id);
                return View(deliveryPlan);
            }

        }

        [HttpPost]
        public ActionResult AddOrEdit(DeliveryPlan deliveryPlan)
        {

            if (deliveryPlan.DeliveryPlanId == 0)
            {
                if (deliveryPlanService.Add(deliveryPlan))
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

                if (deliveryPlanService.Edit(deliveryPlan))
                {
                    return Json(new { success = true, message = "Edit successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = "Failed to edit" }, JsonRequestBehavior.AllowGet);
                }

            }
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryPlan deliveryPlan = deliveryPlanService.GetOne(id);
            if (deliveryPlan == null)
            {
                return HttpNotFound();
            }
            return View(deliveryPlan);
        }
        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ProductId,ProductName,Price,Description,CategoryId")] DeliveryPlan deliveryPlan)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        deliveryPlanService.Add(deliveryPlan);
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.CategoryId = new SelectList(CategoriesForSelectList(), "CategoryId", "CategoryName", deliveryPlan.CategoryId);
        //    return View(deliveryPlan);
        //}

        // GET: Products/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    if (id == 0)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    DeliveryPlan deliveryPlan = deliveryPlanService.GetOne(id);
        //    if (deliveryPlan == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.CategoryId = new SelectList(CategoriesForSelectList(), "CategoryId", "CategoryName", deliveryPlan.CategoryId);
        //    return View(deliveryPlan);
        //}

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ProductId,ProductName,Price,Description,CategoryId")] DeliveryPlan deliveryPlan)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        deliveryPlanService.Edit(deliveryPlan);
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.CategoryId = new SelectList(CategoriesForSelectList(), "CategoryId", "CategoryName", deliveryPlan.CategoryId);
        //    return View(deliveryPlan);
        //}

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryPlan deliveryPlan = deliveryPlanService.GetOne(id);
            if (deliveryPlan == null)
            {
                return HttpNotFound();
            }
            return View(deliveryPlan);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeliveryPlan deliveryPlan = deliveryPlanService.GetOne(id);
            deliveryPlanService.Delete(deliveryPlan);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Remove(int id)
        {
            DeliveryPlan deliveryPlan = deliveryPlanService.GetOne(id);
            deliveryPlanService.Delete(deliveryPlan);
            return Json(new { success = true, message = "Removal success!" }, JsonRequestBehavior.AllowGet);
        }
    }
}