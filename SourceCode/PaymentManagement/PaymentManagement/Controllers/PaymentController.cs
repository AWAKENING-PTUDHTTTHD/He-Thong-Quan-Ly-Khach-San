using PaymentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PaymentManagement.Controllers
{
    public class PaymentController : Controller
    {
      
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult getPayment()
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var pay = dc.Payments.OrderBy(a => a.InvoiceID).ToList();
                return Json(new { data = pay }, JsonRequestBehavior.AllowGet);
            }
        }


        ///// Save
        [HttpGet]
        public ActionResult save(int id)
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var v = dc.Payments.Where(a => a.PaymentID == id).FirstOrDefault();
                return View(v);
            }
        }

        [HttpPost]
        public ActionResult save(Payment pay)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (MyDatabaseEntities dc = new MyDatabaseEntities())
                {
                    if (pay.PaymentID > 0)
                    {
                        //Edit 
                        var v = dc.Payments.Where(a => a.PaymentID == pay.PaymentID).FirstOrDefault();
                        if (v != null)
                        {

                            v.InvoiceID = pay.InvoiceID;
                            v.Amount = pay.Amount;
                            v.PaidDate = pay.PaidDate;
                            v.ExceedDate = pay.ExceedDate;
                            v.Status = pay.Status;
                            v.Note = pay.Note;

                        }
                    }
                    else
                    {
                        //Save
                        dc.Payments.Add(pay);
                    }
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }

        ///// Delete
        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var v = dc.Payments.Where(a => a.PaymentID == id).FirstOrDefault();
                if (v != null)
                {
                    return View(v);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePayment(int id)
        {
            bool status = false;
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var v = dc.Payments.Where(a => a.PaymentID == id).FirstOrDefault();
                if (v != null)
                {
                    dc.Payments.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }  
	}
}