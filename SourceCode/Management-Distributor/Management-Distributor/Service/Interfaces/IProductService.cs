using Management_Distributor.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Distributor.Service.Interfaces
{
    public interface IProductService
    {
        List<Product> GetAll();
    }
    
}
