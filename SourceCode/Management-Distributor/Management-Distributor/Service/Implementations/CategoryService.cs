using Distributor.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Distributor.POCO;
using Distributor.Dao.Interfaces;
using Distributor.Dao.Implementations;
using System.Data.Entity;

using NLog;

namespace Distributor.Service.Implementations
{
    public class CategoryService : ICategoryService
    {
        #region member
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        private IUnitOfWork _uow = null;
        private IRepository<Category> repoCategory = null;
        #endregion

        #region method
        public CategoryService(IUnitOfWork uow)
        {
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
            if (success == true)
                _logger.Info("successfull added Category");
            else
                _logger.Info("failed to add");
            _logger.Info("End add a list Category Category");
            return  success;
        }

        public bool AddRange(List<Category> categories)
        {
            bool success;
            _logger.Info("Start add a list Category");
            repoCategory.AddRange(categories);
            success = (_uow.SaveChange() == categories.Count()) ? true : false;
            if (success == true)
                _logger.Info("successfull added list Category");
            else
                _logger.Info("failed to add");
            _logger.Info("End add a list Category list Category");
            return success;
        }

        public bool Delete(Category category)
        {
            bool success;
            _logger.Info("Start deleting");
            repoCategory.Delete(category);
            success = _uow.SaveChange() > 0;
            if (success == true)
                _logger.Info("successfull deteled category");
            else _logger.Info("failed to delete");
            _logger.Info("End delete a Category");
            return success;
        }

        public bool Edit(Category category)
        {
            bool success;
            _logger.Info("Start Editing");
            repoCategory.Attach(category);
            success = (_uow.SaveChange() > 0);
            if (success == true)
                _logger.Info("successfull Edited category");
            else _logger.Info("failed to Edit");
            _logger.Info("End Edit a Category");
            return success;
        }

        public List<Category> GetAll()
        {
            _logger.Info("Start fetch ALl category");
            List<Category> category = repoCategory.GetAll().ToList();
            _logger.Info("End fetch ALl category");
            return category;
        }

        public Category GetOne(int id)
        {
            _logger.Info("Start fetch single category");
            Category category = null;
            category = repoCategory.GetById(id);
            if (category == null)
                _logger.Info("this category not existed");
            else _logger.Info("Got this category");
            _logger.Info("End fetch single category");
            return category;
        }
        #endregion method
    }
}