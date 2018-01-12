using Distributor.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Management_Distributor.Service.Interfaces
{
    public interface IInvoiceService
    {

        bool Add(Invoice invoice);
        Invoice FindByOrderId(int OrderId);

    }
}