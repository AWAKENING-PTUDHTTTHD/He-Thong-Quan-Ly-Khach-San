using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Distributor.Dao.Implementations;
using Distributor.Service.Implementations;
using Distributor.POCO;
using System.Collections.Generic;

namespace Management_Distributor.Tests.Employeez
{
    [TestClass]
    public class DepartmentTest
    {
        [TestMethod]
        public void TestAddition()
        {
            GenericUnitOfWork uow = new GenericUnitOfWork();
            DepartmentService DeptService = new DepartmentService(uow);
            bool SavedAll  = DeptService.AddRange(new List<Department>()
            {
                new Department(){DepartmentName="Human Resource Dept"},
                new Department(){DepartmentName="Marketing Dept"},
                new Department(){DepartmentName="Sales Dept"},
                new Department(){DepartmentName="Public Relations Dept"},
                new Department(){DepartmentName="Administration Dept"},
                new Department(){DepartmentName="Training Dept"},
                new Department(){DepartmentName="Accounting Dept"},
                new Department(){DepartmentName="Treasury Dept"},
                new Department(){DepartmentName="Information Technology Dept"},
                new Department(){DepartmentName="Customer Service Dept"},
                new Department(){DepartmentName="Audit Dept"},
                new Department(){DepartmentName="Product Development Dep"}
            });
            Assert.AreEqual(true, SavedAll);
        }
    }
}
