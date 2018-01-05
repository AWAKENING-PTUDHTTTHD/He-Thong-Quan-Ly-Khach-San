using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Xml.Linq;
using Distributor.Dao._DbContext;
using Distributor.POCO;
using Distributor.Service.Interfaces;
using Management_Distributor.ExceptionHandler;
using Management_Distributor.Service.Interfaces;
using System.Windows;

namespace Management_Distributor.Controllers
{
    public class OrdersController : Controller
    {

        private IProductService productService = null;
        private IOrderService orderService = null;
        private IOrderDetailService detailService  = null;
        public OrdersController(IProductService _productService, IOrderService _orderService, IOrderDetailService _detailService)
        {
            this.productService = _productService;
            this.orderService = _orderService;
            this.detailService = _detailService;
        }

        protected override void HandleUnknownAction(string actionName)
        {
            try
            {
                this.View(actionName).ExecuteResult(this.ControllerContext);
            }
            catch (Exception ex)
            {
                //ExceptionProofer.LogToFile()
                Response.Redirect("PageNotFound");
            }
        }
        

        public ActionResult Create()
        {
            return View(productService.GetAll().ToList());
        }


        [HttpPost]
        public JsonResult SerializeFormData(FormCollection _collection)
        {
            if (_collection != null)
            {
                string[] _productID, _qty, _price, _amt;
                //for orderDetails
                _productID = _collection["ProductID"].Split(',');
                _qty = _collection["Qty"].Split(',');
                _price = _collection["Price"].Split(',');
                _amt = _collection["Amount"].Split(',');
                //for order
                decimal _total = Convert.ToDecimal(_collection["Total"]);
                //decimal _discount = Convert.ToDecimal(_collection["Discount"]);
                //decimal _grandTotal = Convert.ToDecimal(_collection["GrandTotal"]);
                DateTime _date = DateTime.Now;

                Order order = new Order()
                {
                    OrderDate = _date,
                    ToTalAmount = _total,
                    DistributorId = 2,
                    //Discount = _discount,
                    //GrandTotal = _grandTotal,
                    //Tax = 0,
                    //UserID = User.Identity.GetUserId(),
                    EmployeeId = Convert.ToInt32(Session["EmployeeId"])
                    //Remarks = "-"
                };



                int orderID = orderService.Add(order);

                if (orderID > 0)
                {
                    //service.UpdateStock(_stockID, _qty);
                    if ((detailService.AddListDetail(orderID, _productID, _amt, _qty)) == _productID.Count())
                        return Json(new { success = true, message = "Order added" }, JsonRequestBehavior.AllowGet);
                    return Json(new { success = false, message = "wrong with insert detail" }, JsonRequestBehavior.AllowGet);
                }

                return Json(new { success = false, message = "wrong with generic Order" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false, message = "wrong from form" }, JsonRequestBehavior.AllowGet);
        }



        //public JsonResult GetAllJSON()
        //{

        //}


        //public JsonResult Save(Order od)
        //{

        //    bool status = false;
        //    DateTime dataOrg;
        //    var isValiDate = DateTime.TryParseExact(od.OrderDate.Value.ToString("mm-dd-yyyy"), "mm-dd-yyyy", null, System.Globalization.DateTimeStyles.None, out dataOrg);
        //    if(isValiDate)
        //    {
        //        od.OrderDate = dataOrg;

        //    }

        //    var isValidModel = TryUpdateModel(od);
        //    if(isValidModel)
        //    {
        //        try
        //        {
        //            db.Orders.Add(od);
        //            db.SaveChanges();
        //            status = true;
        //        }
        //        catch(Exception ex)
        //        {
        //            status = false;
        //        }



        //    }
        //    return new JsonResult { Data = new { status = status } };


        //}

        //// GET: Orders
        //public ActionResult Index()
        //{
        //    var orders = db.Orders.Include(o => o.Contract).Include(o => o.Employee).Include(o => o.Invoice);
        //    return View(orders.ToList());
        //}

        //// GET: Orders/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Order order = db.Orders.Find(id);
        //    if (order == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(order);
        //}

        //// GET: Orders/Create
        //public ActionResult Create()
        //{
        //    ViewBag.ContractId = new SelectList(db.Contracts, "ContractId", "Description");
        //    ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmpName");
        //    ViewBag.OrderId = new SelectList(db.Invoices, "InvoiceId", "InvoiceName");
        //    return View();
        //}

        //// POST: Orders/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "OrderId,OrderDate,RequireDeliveryDate,Status,EmployeeId,ContractId,DistributorId")] Order order)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Orders.Add(order);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.ContractId = new SelectList(db.Contracts, "ContractId", "Description", order.ContractId);
        //    ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmpName", order.EmployeeId);
        //    ViewBag.OrderId = new SelectList(db.Invoices, "InvoiceId", "InvoiceName", order.OrderId);
        //    return View(order);
        //}

        //// GET: Orders/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Order order = db.Orders.Find(id);
        //    if (order == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.ContractId = new SelectList(db.Contracts, "ContractId", "Description", order.ContractId);
        //    ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmpName", order.EmployeeId);
        //    ViewBag.OrderId = new SelectList(db.Invoices, "InvoiceId", "InvoiceName", order.OrderId);
        //    return View(order);
        //}

        //// POST: Orders/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "OrderId,OrderDate,RequireDeliveryDate,Status,EmployeeId,ContractId,DistributorId")] Order order)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(order).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.ContractId = new SelectList(db.Contracts, "ContractId", "Description", order.ContractId);
        //    ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmpName", order.EmployeeId);
        //    ViewBag.OrderId = new SelectList(db.Invoices, "InvoiceId", "InvoiceName", order.OrderId);
        //    return View(order);
        //}

        //// GET: Orders/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Order order = db.Orders.Find(id);
        //    if (order == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(order);
        //}

        //// POST: Orders/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Order order = db.Orders.Find(id);
        //    db.Orders.Remove(order);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
}
