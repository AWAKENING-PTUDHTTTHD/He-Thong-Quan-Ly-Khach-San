using Management_Distributor.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Management_Distributor.POCO;
using Management_Distributor.Dao.Interfaces;
using Management_Distributor.Dao.Implementations;

namespace Management_Distributor.Service.Implementations
{
    public class CategoryService : ICategoryService
    {

        private IUnitOfWork uow = null;
        public CategoryService() { uow = new GenericUnitOfWork(); }
        public void Add(Category category)
        {
            IRepository<Category> RepoCategory = uow.Repository<Category>();
            RepoCategory.Add(category);
            uow.SaveChange();
        }

        public List<Category> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}