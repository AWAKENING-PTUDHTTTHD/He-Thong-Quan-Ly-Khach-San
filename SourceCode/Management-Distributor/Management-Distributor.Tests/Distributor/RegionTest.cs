using System;
using System.Collections.Generic;
using Distributor.Dao.Implementations;
using Distributor.POCO;
using Distributor.Service.Implementations;
using Management_Distributor.Service.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Management_Distributor.Tests.Distributor
{
    [TestClass]
    public class RegionTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            GenericUnitOfWork uow = new GenericUnitOfWork();
           RegionService regionService = new RegionService(uow);
            bool SavedAll = regionService.AddRange(new List<Region>()
            {
                new Region (){RegionName="Hà Nội"},
                new Region(){RegionName="Vĩnh Phúc"},
                new Region(){RegionName="Bắc Ninh"},
                new Region(){RegionName="Hà Nam"},
                new Region(){RegionName="Hải Dương"},
                new Region(){RegionName="Thái Bình"},
                new Region(){RegionName="Ninh Bình"},
                new Region(){RegionName="Quảng Trị"},
                new Region(){RegionName="Quảng Nam"},
                new Region(){RegionName="Khánh Hòa"},
                new Region(){RegionName="Lâm Đồng"},
                new Region(){RegionName="Bình Thuận"},
                new Region(){RegionName="Đồng Nai"},
                new Region(){RegionName="Bà Rịa - Vũng Tàu"},
                new Region(){RegionName="TP Hồ Chí Minh"}
            });
            Assert.AreEqual(true, SavedAll);
        }
    }
}
