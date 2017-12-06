using Management_Distributor.Dao._DbContext;
using Management_Distributor.Dao.Implementations;
using Management_Distributor.POCO;
using Management_Distributor.Service.Implementations;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Management_Distributor
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalFilters.Filters.Add(new AuthorizeAttribute());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
            //GenericUnitOfWork uow = new GenericUnitOfWork();
            //CategoryService ctgr = new CategoryService(uow);
            //ctgr.AddRange(new List<Category>()
            //        {
            //              new POCO.Category { CategoryId = "C000000003", CategoryName = "Milk", Description = "1st majority categories"},
            //              new POCO.Category { CategoryId = "C000000004", CategoryName = "Yourgut"},
            //              new POCO.Category { CategoryId = "C000000005", CategoryName = "Whey"}
            //        })
            // ;


            //GenericUnitOfWork uow = new GenericUnitOfWork();
            //EmployeeService emp = new EmployeeService(uow);
            //emp.Add({
            //    new Employee()
            //    {
            //        Department
            //    }
            //});

            //GenericUnitOfWork uow = new GenericUnitOfWork();
            //DepartmentService dept = new DepartmentService(uow);
            //dept.AddRange(new List<Department>()
            //{
            //    new Department()
            //    {
            //        DepartmentId = "D000000001",
            //        DepartmentName = "IT Support"
            //    },
            //    new Department()
            //    {
            //        DepartmentId = "D000000002",
            //        DepartmentName = "Sale"
            //    }
            //}
            //);

        }
    }
}
