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
        private IUnitOfWork _uow = null;
        private IRepository<Product> _ProductRepo = null;
        public ProductService(IUnitOfWork uow, IRepository<Product> ProductRepo)
        {
            _uow = uow;
            _ProductRepo = ProductRepo;
        }

        public bool Edit(Product product)
        {
            try
            {
                _ProductRepo.Attach(product);
                return true;
            }
            catch
            {
                return false;
            }
           
        }

        public List<Product> GetAll()
        {
            var products = _ProductRepo.GetAll().ToList();
            return products;
        }

        public Product GetOne(string id)
        {
           return _ProductRepo.GetAll(x => x.ProductId == id).First();
        }
    }
}