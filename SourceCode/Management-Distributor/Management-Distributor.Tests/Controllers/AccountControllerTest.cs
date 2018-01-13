using System;
using System.Web.Security;
using Distributor.Dao.Implementations;
using Distributor.POCO;
using Distributor.Utils;
using Distributor.Service.Implementations;
using Distributor.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Distributor.Controllers;

namespace Management_Distributor.Tests.Controllers
{
    [TestClass]
    public class AccountControllerTest
    {

        private static GenericUnitOfWork uow = new GenericUnitOfWork();
        private static EmployeeService employeeService = new EmployeeService(uow);
        private static AccountController  accountcontroller= new AccountController(employeeService);
        private static HomeController homecontroller = new HomeController();
        [TestMethod]
        public void LoginSucces()
        {
            LoginViewModel loginVM = new LoginViewModel()
            {
                UsernameOrEmail = "user10",
                PasswordRaw = "kingkaka"
            };
            Employee employee = employeeService.GetByUserNameOrEmail(loginVM.UsernameOrEmail);
            if (employee == null) return;
             if (Hashing.ValidatePassword(loginVM.PasswordRaw,employee.EncryptedPassword) == false) return;
            FormsAuthentication.SetAuthCookie(employee.EmpName, false);
            var result = (RedirectToRouteResult)homecontroller.Dashboard();
            Assert.AreEqual("Dashboard", result.RouteValues["action"]);
            Assert.AreEqual("Home", result.RouteValues["controller"]);
        }
    }
}
