using Distributor.POCO;
using Distributor.Service.Interfaces;
using Distributor.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Distributor.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        IEmployeeService EmpService = null;
        

        public AccountController(IEmployeeService EmpService) { this.EmpService = EmpService; }
        
        [HttpGet]
        public ActionResult Login()
        {
            if (Session["user"] != null)
            {
                return RedirectToAction("Dashboard", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel user)
        {
            
            if (ModelState.IsValid)
            {
                Employee employee = EmpService.GetByUserNameOrEmail((user.UsernameOrEmail));
                if (employee == null || Utils.Hashing.ValidatePassword(user.PasswordRaw, employee.EncryptedPassword) == false)
                {

                    ViewBag.Msg = "Username or Password is incorrect.";
                    Thread.Sleep(5000);
                    return View();
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(employee.UserName, false);
                    SessionStorageModel ssr = new SessionStorageModel()
                    {
                        Id = employee.EmployeeId,
                        Name = employee.EmpName,
                        Avatar = employee.AvatarUrl
                    };
                    //Session["EmployeeId"] = employee.EmployeeId;
                    //Session["EmployeeName"] = employee.EmpName;

                    Session["user"] = ssr;

                    Thread.Sleep(5000);
                    return RedirectToAction("Dashboard", "Home");
                }
            }
            else return View();
            
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}