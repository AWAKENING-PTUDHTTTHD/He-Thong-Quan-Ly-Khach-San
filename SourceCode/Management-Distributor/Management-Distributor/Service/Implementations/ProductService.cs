using Management_Distributor.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Management_Distributor.POCO;
using Management_Distributor.Dao.Implementations;
using Management_Distributor.Dao.Interfaces;

namespace Management_Distributor.Service.Implementations
{
   
    public class ProductService : IProductService
    {
        private IUnitOfWork _uow;
        ProductService()
        {
        }
        public List<Product> GetAll()
        {
            var products = _uow.Repository<Product>().GetAll().ToList();
            return products;
        }
    }
}