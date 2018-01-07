using Management_Distributor.POCO;
using Management_Distributor.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Management_Distributor.Controllers
{
    public class ProductUnitsController : Controller
    {
        private IProductUnitService productUnitService = null;

        public ProductUnitsController(IProductUnitService _productUnitService)
        {
            productUnitService = _productUnitService;
        }


        public JsonResult FetchAll()
        {
            var data = productUnitService.GetAll();
            return Json(new { data }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult AddOrEdit(ProductUnit unit)
        {
            if (unit.UnitId == 0)
            {
                if (productUnitService.Add(unit))
                {
                    return Json(new { success = true, message = "Created successfully!" }, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    return Json(new { success = false, message = "Failed To create!" }, JsonRequestBehavior.AllowGet);
                }
            }

            else
            {
                if (productUnitService.Edit(unit))
                {
                    return Json(new { success = true, message = "Edited successfully!" }, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    return Json(new { success = false, message = "Failed To Edit!" }, JsonRequestBehavior.AllowGet);
                }
            }
        }
    }
}