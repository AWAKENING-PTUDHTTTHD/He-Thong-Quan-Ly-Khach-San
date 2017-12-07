﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Distributor.Dao.Implementations;
using Distributor.Service.Implementations;
using System.Collections.Generic;
using Distributor.POCO;
namespace Management_Distributor.Tests.Employee
{
    [TestClass]
    public class EmployeeTest
    {
        [TestMethod]
        public void TestMethod1()
        {

            GenericUnitOfWork uow = new GenericUnitOfWork();
            EmployeeService EmpService = new EmployeeService(uow);
            List<Distributor.POCO.Employee> employees = new List<Distributor.POCO.Employee>()
            {
                    new Distributor.POCO.Employee()
                    {
                        EmpName = "Employee1",
                        UserName = "User1",
                        EmpEmail = "Employee1@test.test",
                        EmpAddress = "Address1",
                        PhoneNumber = "0120-0000-000",
                        Salt = "Nothingmuch",
                        EncryptedPassword = Distributor.Utils.Hashing.HashPassword("kingkaka"),
                        DepartmentId = 1,
                        Rolez = "Staff"

                    },
                    new Distributor.POCO.Employee()
                    {
                        EmpName = "Employee2",
                        UserName = "User2",
                        EmpEmail = "Employee2@test.test",
                        EmpAddress = "Address2",
                        PhoneNumber = "0120-0000-000",
                        Salt = "Nothingmuch",
                        EncryptedPassword = Distributor.Utils.Hashing.HashPassword("kingkaka"),
                        DepartmentId = 9,
                        Rolez = "Admin"

                    }
               };
            bool saveAll = EmpService.AddRange(employees);
            Assert.AreEqual(true, saveAll, "Added 2 employee records");

        }
    }
}