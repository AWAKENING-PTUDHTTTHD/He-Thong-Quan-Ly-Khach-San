using Distributor.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Management_Distributor.Service.Interfaces
{
    public interface IDistributorService
    {
        //bool AddRange(List<distributor.POCO._Distributor> distributors);

        //_Distributor FindById(int Id);

        List<_Distributor> GetAll();
        bool Add(_Distributor distributor);
        bool Edit(_Distributor distributor);
        bool Delete(_Distributor distributor);
        _Distributor GetOne(int id);
        bool AddRange(List<_Distributor> distributors);


    }
}