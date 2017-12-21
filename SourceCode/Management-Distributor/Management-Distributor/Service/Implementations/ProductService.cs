using Distributor.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Distributor.POCO;
using Distributor.Dao.Implementations;
using Distributor.Dao.Interfaces;
using NLog;

namespace Distributor.Service.Implementations
{

    public class ProductService : IProductService
    {

        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        private IUnitOfWork _uow = null;
        private IRepository<Product> _ProductRepo = null;
        public ProductService(IUnitOfWork uow)
        {
            _uow = uow;
            _ProductRepo = _uow.Repository<Product>();
        }

        public bool Add(Product product)
        {
            bool success;
            _logger.Info("Start add new Product");
            _ProductRepo.Add(product);
            _logger.Info("End add new Product");
            success = (_uow.SaveChange() > 0) ? true : false;
            return success;
        }

        public bool Delete(Product product)
        {
            _ProductRepo.Delete(product);
            return (_uow.SaveChange() > 0);
        }

        public bool Edit(Product product)
        {
            try
            {
                _ProductRepo.Attach(product);
                return (_uow.SaveChange() > 0);
            }
            catch (Exception ex)
            {
                return false;
            }
           
        }

        public List<Product> GetAll()
        {
            var products = _ProductRepo.GetAll().ToList();
            return products;
        }

        public List<Product> GetByCategory(int categoryId)
        {
            return _ProductRepo.GetAll(x => x.CategoryId == categoryId).ToList();
        }


        public Product GetOne(int id)
        {
           return _ProductRepo.GetAll(x => x.ProductId == id).First();
        }
    }
}