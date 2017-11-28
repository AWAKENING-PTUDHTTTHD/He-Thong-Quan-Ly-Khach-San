using Management_Distributor.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Management_Distributor.POCO;
using Management_Distributor.Dao.Interfaces;

namespace Management_Distributor.Service.Implementations
{
    public class CategoryService : ICategoryService
    {
        private IUnitOfWork _uow;
        public void Add(Category category)
        {
            _uow.Repository<Category>().Add(category);
            _uow.SaveChange();
        }

        public List<Category> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}