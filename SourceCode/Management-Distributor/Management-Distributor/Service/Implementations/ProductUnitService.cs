using Distributor.Dao.Interfaces;
using Management_Distributor.POCO;
using Management_Distributor.Service.Interfaces;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Management_Distributor.Service.Implementations
{
    public class ProductUnitService : IProductUnitService
    {

        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        private IUnitOfWork _uow = null;
        private IRepository<ProductUnit> repoProductUnit = null;

        public ProductUnitService(IUnitOfWork _uow)
        {
            this._uow = _uow;
        }
        public bool Add(ProductUnit product_unit)
        {
            bool success;
            _logger.Info("Start add new Unit");
            try
            {
                repoProductUnit.Add(product_unit);
                _logger.Info("End add new Product Unit");
                success = (_uow.SaveChange() > 0) ? true : false;
            }
            catch (Exception ex)
            {
                success = false;
            }

            if (success == true)
                _logger.Info("successfull added Product Unit");
            else
                _logger.Info("failed to add");
            _logger.Info("End add a list Product Unit");
            return success;
        }

        public List<ProductUnit> GetAll()
        {
            _logger.Info("Start fetch ALl Product Unit");
            List<ProductUnit> product_units = repoProductUnit.GetAll().ToList();
            _logger.Info("End fetch ALl Unit");
            return product_units;
        }

        bool Edit(ProductUnit productUnit)
        {
            bool success;
            _logger.Info("Start Editing");
            try
            {
                repoProductUnit.Attach(productUnit);
                _uow.SaveChange();
                success = true;
            }
            catch (Exception ex)
            {
                success = false;
            }
            if (success == true)
                _logger.Info("successfull Edited ProductUnit");
            else _logger.Info("failed to Edit");
            _logger.Info("End Edit a ProductUnit");
            return success;
        }

        bool IProductUnitService.Edit(ProductUnit productUnit)
        {
            throw new NotImplementedException();
        }
    }
}