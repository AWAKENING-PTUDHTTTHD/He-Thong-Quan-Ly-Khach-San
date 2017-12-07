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
    public class DepartmentService : IDeparmentService
    {
        #region member
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        private IUnitOfWork _uow = null;
        private IRepository<Department> repoDept = null;
        #endregion


        public DepartmentService(IUnitOfWork uow)
        {
            _uow = uow;
            repoDept = _uow.Repository<Department>();
        }

        public bool Add(Department dept)
        {
            bool success;
            _logger.Info("Start add new Deparment");
            repoDept.Add(dept);
            _logger.Info("End add new Deparment");
            success = (_uow.SaveChange() > 0) ? true : false;
            return success;
        }

        public bool AddRange(List<Department> depts)
        {
            bool success;
            _logger.Info("Start add a list Deparments");
            repoDept.AddRange(depts);
            success = (_uow.SaveChange() == depts.Count()) ? true : false;

            _logger.Info("End add a list Deparments");
            return success;
        }

        public bool Delete(Department dept)
        {
            repoDept.Delete(dept);
            return (_uow.SaveChange() > 0);
        }

        public bool Edit(Employee employee)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Department dept)
        {
            throw new NotImplementedException();
        }

        public List<Department> GetAll()
        {
            return repoDept.GetAll().ToList();
        }

        public Department GetOne(int id)
        {
            Department dept = null;
            dept = repoDept.GetById(id);
            return dept;
        }
        Category IDeparmentService.GetOne(int id)
        {
            throw new NotImplementedException();
        }
    }
}