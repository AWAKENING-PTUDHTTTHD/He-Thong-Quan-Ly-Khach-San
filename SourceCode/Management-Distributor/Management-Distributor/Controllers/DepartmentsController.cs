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
    //[AllowAnonymous]
    //[Authorize]

    [Authorize(Roles = "Admin")]
    public class DepartmentsController : Controller
    {
        IEmployeeService EmpService = null;
        IDeparmentService DeptService = null;

        public DepartmentsController(IEmployeeService _EmpService, IDeparmentService _DeptService)
        {
            EmpService = _EmpService;
            DeptService = _DeptService;
        }
        //[Authorize(Roles = "V,A")]
        public ActionResult Index()
        {
            var departments = DeptService.GetAll();
            return View(departments);
        }

        // GET: Departments/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = DeptService.GetOne(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        //[Authorize(Roles = "A")]
        // GET: Departments/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeEmployeeId = new SelectList(EmpService.GetAll(), "EmployeeId", "EmpName");
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepartmentId,DepartmentName,EmployeeId")] Department department)
        {
            if (ModelState.IsValid)
            {
                DeptService.Add(department);
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeEmployeeId = new SelectList(EmpService.GetAll(), "EmployeeId", "EmpName", department.EmployeeId);
            return View(department);
        }

        // GET: Departments/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = DeptService.GetOne(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeEmployeeId = new SelectList(EmpService.GetAll(), "EmployeeId", "EmpName", department.EmployeeId);
            return View(department);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult  Edit([Bind(Include = "DepartmentId,DepartmentName,EmployeeId")] Department department)
        {
            if (ModelState.IsValid)
            {
                DeptService.Edit(department);
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeEmployeeId = new SelectList(EmpService.GetAll(), "EmployeeId", "EmpName", department.EmployeeId);
            return View(department);
        }

        // GET: Departments/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = DeptService.GetOne(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Department department = DeptService.GetOne(id);
            return RedirectToAction("Index");
        }
    }
}
