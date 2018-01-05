using Distributor.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Management_Distributor.Service.Interfaces
{
    public interface IDistributorService
    {
        bool AddRange(List<Distributor.POCO._Distributor> distributors);

        _Distributor FindById(int Id);

    }
}