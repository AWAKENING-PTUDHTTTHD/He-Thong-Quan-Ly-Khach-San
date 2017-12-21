using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Distributor.Dao._DbContext;
using Distributor.POCO;

namespace Management_Distributor.Controllers
{
    public class OrdersController : Controller
    {
        private ManagementDistributorDbContext db = new ManagementDistributorDbContext();



        //public JsonResult GetAllJSON()
        //{

        //}


        public JsonResult Save(Order od)
        {

            bool status = false;
            DateTime dataOrg;
            var isValiDate = DateTime.TryParseExact(od.OrderDate.Value.ToString("mm-dd-yyyy"), "mm-dd-yyyy", null, System.Globalization.DateTimeStyles.None, out dataOrg);
            if(isValiDate)
            {
                od.OrderDate = dataOrg;

            }

            var isValidModel = TryUpdateModel(od);
            if(isValidModel)
            {
                try
                {
                    db.Orders.Add(od);
                    db.SaveChanges();
                    status = true;
                }
                catch(Exception ex)
                {
                    status = false;
                }

                
                
            }
            return new JsonResult { Data = new { status = status } };


        }

        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Contract).Include(o => o.Employee).Include(o => o.Invoice);
            return View(orders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.ContractId = new SelectList(db.Contracts, "ContractId", "Description");
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmpName");
            ViewBag.OrderId = new SelectList(db.Invoices, "InvoiceId", "InvoiceName");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderId,OrderDate,RequireDeliveryDate,Status,EmployeeId,ContractId,DistributorId")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContractId = new SelectList(db.Contracts, "ContractId", "Description", order.ContractId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmpName", order.EmployeeId);
            ViewBag.OrderId = new SelectList(db.Invoices, "InvoiceId", "InvoiceName", order.OrderId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContractId = new SelectList(db.Contracts, "ContractId", "Description", order.ContractId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmpName", order.EmployeeId);
            ViewBag.OrderId = new SelectList(db.Invoices, "InvoiceId", "InvoiceName", order.OrderId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,OrderDate,RequireDeliveryDate,Status,EmployeeId,ContractId,DistributorId")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContractId = new SelectList(db.Contracts, "ContractId", "Description", order.ContractId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmpName", order.EmployeeId);
            ViewBag.OrderId = new SelectList(db.Invoices, "InvoiceId", "InvoiceName", order.OrderId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
