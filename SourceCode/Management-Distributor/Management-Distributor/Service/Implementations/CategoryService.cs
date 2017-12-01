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
        private readonly ILogger _logger;
        private IUnitOfWork _uow = null;
        private IRepository<Category> repoCategory = null;
        public CategoryService(IUnitOfWork uow, ILogger logger)
        {
            _logger = logger;
            _uow = uow;
            repoCategory = _uow.Repository<Category>();
        }
        public bool Add(Category category)
        {
            _logger.Info("Start add new Category");
            repoCategory.Add(category);
            _logger.Info("End add new Category");
            return  (_uow.SaveChange() > 0 );
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
    }
}