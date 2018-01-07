using Management_Distributor.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Management_Distributor.Service.Interfaces
{
    public interface IUnitService
    {
        bool Add(Unit unit);
        List<Unit> GetAll();

        bool Edit(Unit unit);
    }
}