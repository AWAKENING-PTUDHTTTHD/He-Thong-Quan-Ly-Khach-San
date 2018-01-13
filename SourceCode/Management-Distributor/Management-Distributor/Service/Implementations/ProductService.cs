using Distributor.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Distributor.POCO;
using Distributor.Dao.Implementations;
using Distributor.Dao.Interfaces;
using NLog;
using Pagination;
using Management_Distributor.ExceptionHandler;

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
            try
            {
                _ProductRepo.Add(product);
                _uow.SaveChange();
                success = true;
            }
            catch (Exception ex)
            {
                success = false;
                _logger.Error(ex, "catch errr");
            }
            
            _logger.Info("End add new Product");
            
            return success;
        }

        public int DecreaseAvailableQty(int ProductId, int DescreaseAmt)
        {
            // product not existed 
            int success = -1;
            Product p = FindById(ProductId);
            if (p != null)
            {
                // Turn flag to existed
                success = 0;
                if (p.AvailableQty >= DescreaseAmt)
                {
                    try
                    {

                        p.AvailableQty -= DescreaseAmt;
                        _uow.SaveChange();
                        // sucessfully updated
                        success = 1;
                    }
                    catch (Exception ex)
                    {
                        _logger.Error(ex, "Error");
                        string Path = @"C:/DescreaseAvailableQty.Exception.txt";
                        ExceptionProofer.LogToFile(Path, ex);
                    }

                }

            }  
              
            return success;
                

        }

        public bool Delete(Product product)
        {
            try
            {
                _ProductRepo.Delete(product);
                _uow.SaveChange();
                return true;
            }
           
            catch(Exception ex)
            {
                _logger.Error(ex, "Error");
                return false;
            }
        }

        public bool Edit(Product product)
        {
            try
            {
                _ProductRepo.Attach(product);
                _uow.SaveChange();
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error");
                return false;
            }
           
        }

        public Product FindById(int ProductId)
        {
            return _ProductRepo.GetById(ProductId);
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

        public List<Product> GetPage(int page = 1)
        {

            List<Product> L;
            L = _ProductRepo.GetAll()
                            .OrderByDescending(p => p.ProductId)
                            .Skip((page - 1) * PageConfig.PageSize)
                            .Take(PageConfig.PageSize)
                            .ToList();
            return L;
        }
    }
}