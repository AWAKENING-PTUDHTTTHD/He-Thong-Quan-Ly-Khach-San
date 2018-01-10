using Distributor.POCO;
using Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Distributor.ViewModels
{
    public class DeliveryPlansListViewModel
    {
        public IEnumerable<DeliveryPlan> DeliveryPlans { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}