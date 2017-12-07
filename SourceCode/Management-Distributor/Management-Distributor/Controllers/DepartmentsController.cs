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

namespace Distributor.Controllers
{
    //[AllowAnonymous]
    //[Authorize]

    [Authorize(Roles = "Admin")]
    public class DepartmentsController : Controller
    {
        private ManagementDistributorDbContext db = new ManagementDistributorDbContext();

        //[Authorize(Roles = "V,A")]
        public async Task<ActionResult> Index()
        {
            var departments = db.Departments.Include(d => d.Employee);
            return View(await departments.ToListAsync());
        }

        // GET: Departments/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = await db.Departments.FindAsync(id);
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
            ViewBag.EmployeeEmployeeId = new SelectList(db.Employees, "EmployeeId", "EmpName");
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "DepartmentId,DepartmentName,EmployeeId")] Department department)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Add(department);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeEmployeeId = new SelectList(db.Employees, "EmployeeId", "EmpName", department.EmployeeId);
            return View(department);
        }

        // GET: Departments/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = await db.Departments.FindAsync(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeEmployeeId = new SelectList(db.Employees, "EmployeeId", "EmpName", department.EmployeeId);
            return View(department);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "DepartmentId,DepartmentName,EmployeeId")] Department department)
        {
            if (ModelState.IsValid)
            {
                db.Entry(department).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeEmployeeId = new SelectList(db.Employees, "EmployeeId", "EmpName", department.EmployeeId);
            return View(department);
        }

        // GET: Departments/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = await db.Departments.FindAsync(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Department department = await db.Departments.FindAsync(id);
            db.Departments.Remove(department);
            await db.SaveChangesAsync();
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
