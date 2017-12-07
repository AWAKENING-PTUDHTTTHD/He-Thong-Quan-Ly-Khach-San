using Distributor.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Distributor.POCO;
using NLog;
using Distributor.Dao.Interfaces;

namespace Distributor.Service.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        #region member
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        private IUnitOfWork _uow = null;
        private IRepository<Employee> repoEmployee = null;
        #endregion


        public EmployeeService(IUnitOfWork uow)
        {
            _uow = uow;
            repoEmployee = _uow.Repository<Employee>();
        }

        public bool Add(Employee employee)
        {
            bool success;
            _logger.Info("Start add new Employee");
            repoEmployee.Add(employee);
            _logger.Info("End add new Employee");
            success = (_uow.SaveChange() > 0) ? true : false;
            return success;
        }

        public bool AddRange(List<Employee> employees)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Employee employee)
        {
            repoEmployee.Delete(employee);
            return (_uow.SaveChange() > 0);
        }

        public bool Edit(Employee employee)
        {
            repoEmployee.Attach(employee);
            return (_uow.SaveChange() > 0);
        }

            public List<Employee> GetAll()
        {
            return repoEmployee.GetAll().ToList();
        }

        public Employee GetByUserNameOrEmail(string UsernameOrEmail)
        {
            return repoEmployee.GetAll().Where(emp => emp.UserName == UsernameOrEmail || emp.EmpEmail == UsernameOrEmail).FirstOrDefault();
        }

        public Employee GetOne(string id)
        {
            return repoEmployee.GetById(id);
        }

        Employee IEmployeeService.GetOne(string id)
        {
            throw new NotImplementedException();
        }
    }
}