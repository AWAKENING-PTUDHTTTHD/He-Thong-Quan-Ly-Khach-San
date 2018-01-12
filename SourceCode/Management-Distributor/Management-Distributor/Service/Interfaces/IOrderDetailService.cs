using Distributor.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Management_Distributor.Service.Interfaces
{
    public interface IOrderDetailService
    {
        List<OrderDetail> FindByOrderId(int Id);

        OrderDetail FindById(int id);
        bool Add(OrderDetail detail);

        bool Edit(OrderDetail detail);
        // using Form Collection to Resolve Array OrderDetail
        int AddListDetail(int OrderId, string[] productId, string[] price, string[] DemandQty, string[]ActualQty);
        int AddOrEditListDetail(int OrderId, string [] DetailId, string[] productId, string[] price, string[] DemandQty, string[] ActualQty, string[] flag);



    }
}