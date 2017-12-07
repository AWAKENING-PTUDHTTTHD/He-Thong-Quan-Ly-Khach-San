using Distributor.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributor.Service.Interfaces
{
    public interface IDeparmentService
    {
        List<Department> GetAll();
        bool Add(Department dept);
        bool Edit(Department dept);
        bool Delete(Department dept);
        Category GetOne(string id);
        bool AddRange(List<Department> depts);

        Department GetByUserNameOrEmail(string UsernameOrEmail);

    }
}
