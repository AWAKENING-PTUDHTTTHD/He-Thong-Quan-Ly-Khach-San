using Management_Distributor.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Distributor.Service.Interfaces
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        bool Add(Category category);
        bool Edit(Category category);
        bool Delete(Category category);
        Category GetOne(string id);
        bool AddRange(List<Category> categories);

    }
}
