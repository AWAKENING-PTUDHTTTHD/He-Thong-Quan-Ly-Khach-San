using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Distributor.Dao.Implementations;
using Distributor.Service.Implementations;
using Distributor.POCO;
using System.Collections.Generic;

namespace Management_Distributor.Tests.Employee
{
    [TestClass]
    public class DepartmentTest
    {
        [TestMethod]
        public void TestAddition()
        {
            GenericUnitOfWork uow = new GenericUnitOfWork();
            DepartmentService DeptService = new DepartmentService(uow);
            bool SavedAll  = DeptService.AddRange(new List<Distributor.POCO.Department>()
            {
                new Distributor.POCO.Department(){DepartmentName="Human Resource Dept"},
                new Distributor.POCO.Department(){DepartmentName="Marketing Dept"},
                new Distributor.POCO.Department(){DepartmentName="Sales Dept"},
                new Distributor.POCO.Department(){DepartmentName="Public Relations Dept"},
                new Distributor.POCO.Department(){DepartmentName="Administration Dept"},
                new Distributor.POCO.Department(){DepartmentName="Training Dept"},
                new Distributor.POCO.Department(){DepartmentName="Accounting Dept"},
                new Distributor.POCO.Department(){DepartmentName="Treasury Dept"},
                new Distributor.POCO.Department(){DepartmentName="Information Technology Dept"},
                new Distributor.POCO.Department(){DepartmentName="Customer Service Dept"},
                new Distributor.POCO.Department(){DepartmentName="Audit Dept"},
                new Distributor.POCO.Department(){DepartmentName="Product Development Dep"}
            });
            Assert.AreEqual(true, SavedAll);
        }
    }
}
