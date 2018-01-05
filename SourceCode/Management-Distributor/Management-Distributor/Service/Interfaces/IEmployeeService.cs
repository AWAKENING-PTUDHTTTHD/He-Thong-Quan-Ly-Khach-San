using Distributor.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributor.Service.Interfaces
{
    public interface IEmployeeService
    {
        Employee FindById(int Id);
        List<Employee> Load_Page(int PageNumb);
        List<Employee> GetAll();
        bool Add(Employee employee);
        bool Edit(Employee employee);
        bool Delete(Employee employee);
        Employee GetOne(int id);
        bool AddRange(List<Employee> employees);

        Employee GetByUserNameOrEmail(string UsernameOrEmail);

    }
}
