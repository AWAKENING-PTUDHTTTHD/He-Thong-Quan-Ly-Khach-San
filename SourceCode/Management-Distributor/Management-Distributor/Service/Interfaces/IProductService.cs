using Distributor.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributor.Service.Interfaces
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product GetOne(int id);

        bool Edit(Product product);

        bool Add(Product product);

        bool Delete(Product product);

        List<Product>GetByCategory(int categoryId);

        List<Product> GetPage(int page = 1);

        Product FindById(int ProductId);

        int DecreaseAvailableQty(int ProductId, int DescreaseAmt);
    }
    
}
