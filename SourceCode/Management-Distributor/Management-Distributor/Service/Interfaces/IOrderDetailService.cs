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
        bool Add(OrderDetail detail);

        // using Form Collection to Resolve Array OrderDetail
        int AddListDetail(int OrderId, string[] productId, string[] price, string[] qty);
        

    }
}