using Management_Distributor.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Management_Distributor.POCO;
using Management_Distributor.Dao.Interfaces;
using Management_Distributor.Dao.Implementations;
using System.Data.Entity;

using NLog;

namespace Management_Distributor.Service.Implementations
{
    public class CategoryService : ICategoryService
    {
        #region member
        private readonly ILogger _logger;
        private IUnitOfWork _uow = null;
        private IRepository<Category> repoCategory = null;
        #endregion

        #region method
        public CategoryService(IUnitOfWork uow, ILogger logger)
        {
            _logger = logger;
            _uow = uow;
            repoCategory = _uow.Repository<Category>();
        }
        public bool Add(Category category)
        {
            bool success;
            _logger.Info("Start add new Category");
            repoCategory.Add(category);
            _logger.Info("End add new Category");
            success = (_uow.SaveChange() > 0) ? true : false;
            return  success;
        }

        public bool AddRange(List<Category> categories)
        {
            bool success;
            _logger.Info("Start add a list Category");
            repoCategory.AddRange(categories);
            success = (_uow.SaveChange() == categories.Count()) ? true : false;

            _logger.Info("End add a list Category");
            return success;
        }

        public bool Delete(Category category)
        {
            repoCategory.Delete(category);
            return (_uow.SaveChange() > 0);
        }

        public bool Edit(Category category)
        {
            repoCategory.Attach(category);
            return (_uow.SaveChange() > 0);
        }

        public List<Category> GetAll()
        {
            return repoCategory.GetAll().ToList();
        }
        #endregion method
    }
}