using System;
using System.Collections.Generic;
using Distributor.Dao.Implementations;
using Distributor.POCO;
using Distributor.Service.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Distributor.Utils;

namespace Management_Distributor.Tests.Employeez
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Testmethod1()
        {

            GenericUnitOfWork uow = new GenericUnitOfWork();
            EmployeeService empservice = new EmployeeService(uow);
            List<Employee> Employees = new List<Employee>()
            {
                    new Employee()
                    {
                        EmpName = "Employee1",
                        UserName = "user1",
                        EmpEmail = "Employee1@test.test",
                        EmpAddress = "address1",
                        PhoneNumber = "0120-0000-000",
                        
                        EncryptedPassword = Hashing.HashPassword("kingkaka"),
                        DepartmentId = 1,
                        Rolez = "staff"

                    },
                    new Employee()
                    {
                        EmpName = "Employee2",
                        UserName = "user2",
                        EmpEmail = "Employee2@test.test",
                        EmpAddress = "address2",
                        PhoneNumber = "0120-0000-000",
                        
                        EncryptedPassword = Hashing.HashPassword("kingkaka"),
                        DepartmentId = 9,
                        Rolez = "staff"

                    },
                     new Employee()
                    {
                        EmpName = "Employee3",
                        UserName = "user3",
                        EmpEmail = "Employee2@test.test",
                        EmpAddress = "address2",
                        PhoneNumber = "0120-0000-000",
                        
                        EncryptedPassword = Hashing.HashPassword("kingkaka"),
                        DepartmentId = 9,
                        Rolez = "staff"

                    },
                     new Employee()
                    {
                        EmpName = "Employee4",
                        UserName = "user4",
                        EmpEmail = "Employee2@test.test",
                        EmpAddress = "address2",
                        PhoneNumber = "0120-0000-000",
                        
                        EncryptedPassword = Hashing.HashPassword("kingkaka"),
                        DepartmentId = 9,
                        Rolez = "staff"

                    },
                     new Employee()
                    {
                        EmpName = "Employee5",
                        UserName = "user5",
                        EmpEmail = "Employee2@test.test",
                        EmpAddress = "address2",
                        PhoneNumber = "0120-0000-000",
                        
                        EncryptedPassword = Hashing.HashPassword("kingkaka"),
                        DepartmentId = 9,
                        Rolez = "staff"

                    },
                     new Employee()
                    {
                        EmpName = "Employee6",
                        UserName = "user6",
                        EmpEmail = "Employee2@test.test",
                        EmpAddress = "address2",
                        PhoneNumber = "0120-0000-000",
                        
                        EncryptedPassword = Hashing.HashPassword("kingkaka"),
                        DepartmentId = 9,
                        Rolez = "staff"

                    },
                     new Employee()
                    {
                        EmpName = "Employee7",
                        UserName = "user7",
                        EmpEmail = "Employee2@test.test",
                        EmpAddress = "address2",
                        PhoneNumber = "0120-0000-000",
                        
                        EncryptedPassword = Hashing.HashPassword("kingkaka"),
                        DepartmentId = 9,
                        Rolez = "staff"

                    },
                     new Employee()
                    {
                        EmpName = "Employee8",
                        UserName = "user8",
                        EmpEmail = "Employee2@test.test",
                        EmpAddress = "address2",
                        PhoneNumber = "0120-0000-000",
                        
                        EncryptedPassword = Hashing.HashPassword("kingkaka"),
                        DepartmentId = 9,
                        Rolez = "staff"

                    },
                     new Employee()
                    {
                        EmpName = "Employee9",
                        UserName = "user9",
                        EmpEmail = "Employee2@test.test",
                        EmpAddress = "address2",
                        PhoneNumber = "0120-0000-000",
                        
                        EncryptedPassword = Hashing.HashPassword("kingkaka"),
                        DepartmentId = 9,
                        Rolez = "staff"

                    },
                     new Employee()
                    {
                        EmpName = "Employee10",
                        UserName = "user10",
                        EmpEmail = "Employee2@test.test",
                        EmpAddress = "address2",
                        PhoneNumber = "0120-0000-000",
                        
                        EncryptedPassword = Hashing.HashPassword("kingkaka"),
                        DepartmentId = 9,
                        Rolez = "staff"

                    },
                     new Employee()
                    {
                        EmpName = "Employee11",
                        UserName = "user11",
                        EmpEmail = "Employee2@test.test",
                        EmpAddress = "address2",
                        PhoneNumber = "0120-0000-000",
                        AvatarUrl = "krystal-jung.jpg",
                        
                        EncryptedPassword = Hashing.HashPassword("kingkaka"),
                        DepartmentId = 9,
                        Rolez = "admin"

                    }

               };
            bool saveall = empservice.AddRange(Employees);
            Assert.AreEqual(true, saveall, "added 11 Employee records");

        }
    }
}
