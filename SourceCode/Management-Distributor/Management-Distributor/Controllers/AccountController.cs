using Management_Distributor.POCO;
using Management_Distributor.Service.Interfaces;
using Management_Distributor.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Management_Distributor.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        IEmployeeService EmpService = null;
        

        public AccountController(IEmployeeService EmpService) { this.EmpService = EmpService; }
        
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel user)
        {
            Employee employee = EmpService.GetByUserNameOrEmail((user.usernameOremail));
            if (employee == null || Utils.Hashing.ValidatePassword(user.passwordRaw, employee.EncryptedPassword) == false)
            {
                ViewBag.Msg = "Invalid User";
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(employee.UserName, false);
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}