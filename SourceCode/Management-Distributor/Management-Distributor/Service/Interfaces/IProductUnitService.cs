using Management_Distributor.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Management_Distributor.Service.Interfaces
{
    public interface IProductUnitService
    {
        bool Add(ProductUnit product_unit);
        List<ProductUnit> GetAll();
        bool Edit(ProductUnit productUnit);
    }
}