using System;
using System.Collections.Generic;
using Distributor.Dao.Implementations;
using Distributor.POCO;
using Management_Distributor.Service.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Management_Distributor.Tests.Distributor
{
    [TestClass]
    public class DistributorTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            GenericUnitOfWork uow = new GenericUnitOfWork();
            DistributorService distributorService = new DistributorService(uow);
            bool SavedAll = distributorService.AddRange(new List<_Distributor>()
            {
                new _Distributor (){
                                    DistributorName = "Cty ABC",
                                    RegionId = 1,
                                    DistributorAddress = "552 Quang Trung, Thanh Xuân, TP Hà Nội",
                                    DistributorEmail = "Test1@Test.gmail.com",
                                    DistributorPhoneNumber = "0120000001",
                                    Status = "Cooperating",
                                    Description = "No Describe anymore"
                                   },
                new _Distributor (){
                                    DistributorName = "Cty XYZ",
                                    RegionId = 1,
                                    DistributorAddress = "789 Nguyễn Huệ, Đống Đa, TP Hà Nội",
                                    DistributorEmail = "Test2@Test.gmail.com",
                                    DistributorPhoneNumber = "0120000002",
                                    Status = "Cooperating",
                                    Description = "No Describe anymore"
                                   },
            });
            Assert.AreEqual(true, SavedAll);
        }
    }
}
