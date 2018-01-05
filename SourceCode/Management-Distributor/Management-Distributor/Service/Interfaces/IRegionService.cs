using Distributor.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Distributor.Service.Interfaces
{
    public interface IRegionService
    {
        List<Region> GetAll();
        bool Add(Region region);
        bool Edit(Region region);
        bool Delete(Region region);
        Region GetOne(int id);
        bool AddRange(List<Region> categories);
    }
}
