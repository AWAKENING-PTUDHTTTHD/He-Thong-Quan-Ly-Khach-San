using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Distributor.POCO;

namespace Management_Distributor.Service.Interfaces
{
    public interface IOrderService
    {
        List<Order> GetAll();
        int Add(Order order);
        Order FindById(int Id);
    }
}