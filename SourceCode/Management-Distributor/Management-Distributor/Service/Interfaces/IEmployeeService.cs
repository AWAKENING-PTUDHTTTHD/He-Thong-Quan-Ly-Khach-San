using Management_Distributor.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Distributor.Service.Interfaces
{
    public interface IEmployeeService
    {
        List<Employee> GetAll();
        bool Add(Employee employee);
        bool Edit(Employee employee);
        bool Delete(Employee employee);
        Employee GetOne(string id);
        bool AddRange(List<Employee> employees);

        Employee GetByUserNameOrEmail(string UsernameOrEmail);

    }
}
