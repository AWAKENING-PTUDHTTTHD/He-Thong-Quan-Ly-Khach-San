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
using Distributor.Service.Interfaces;

namespace Management_Distributor.Controllers
{
    //[AllowAnonymous]
    [Authorize(Roles = "Admin")]
    public class EmployeesController : Controller
    {
        IEmployeeService EmpService = null;
        IDeparmentService DeptService = null;
        public EmployeesController(IEmployeeService _EmpService, IDeparmentService _DeptService)
        {
            EmpService = _EmpService;
            DeptService = _DeptService;
        }
        // GET: Employees
        public ActionResult Index()
        {
            var employees = EmpService.GetAll();
            return View(employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = EmpService.GetOne(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(DeptService.GetAll(), "DepartmentId", "DepartmentName");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,EmpName,EmpAddress,PhoneNumber,EmpEmail,UserName,EncryptedPassword,Salt,LastLogged,NumOfLoginAttemp,LastAttemp,Role,DepartmentId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                EmpService.Add(employee);
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(DeptService.GetAll(), "DepartmentId", "DepartmentName", employee.DepartmentId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = EmpService.GetOne(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(DeptService.GetAll(), "DepartmentId", "DepartmentName", employee.DepartmentId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,EmpName,EmpAddress,PhoneNumber,EmpEmail,UserName,EncryptedPassword,Salt,LastLogged,NumOfLoginAttemp,LastAttemp,Role,DepartmentId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                EmpService.Edit(employee);
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(DeptService.GetAll(), "DepartmentId", "DepartmentName", employee.DepartmentId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = EmpService.GetOne(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = EmpService.GetOne(id);
            EmpService.Delete(employee);
            return RedirectToAction("Index");
        }
    }
}
