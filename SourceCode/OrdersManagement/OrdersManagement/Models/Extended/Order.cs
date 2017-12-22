using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrdersManagement.Models
{
    public partial class Order
    {
        public string OrderDateString { get; set; }
        public string DeliveryDateString { get; set; }
    }
}