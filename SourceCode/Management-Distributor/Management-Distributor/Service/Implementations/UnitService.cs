using Distributor.Dao.Interfaces;
using Management_Distributor.POCO;
using Management_Distributor.Service.Interfaces;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Management_Distributor.Service.Implementations
{
    public class UnitService : IUnitService
    {
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        private IUnitOfWork _uow = null;
        private IRepository<Unit> repoUnit = null;

        public UnitService(IUnitOfWork _uow)
        {
            this._uow = _uow;
        }
        public bool Add(Unit unit)
        {
            bool success;
            _logger.Info("Start add new Unit");
            try
            {
                repoUnit.Add(unit);
                _logger.Info("End add new Unit");
                success = (_uow.SaveChange() > 0) ? true : false;
            }
            catch(Exception ex)
            {
                success = false;
            }
            
            if (success == true)
                _logger.Info("successfull added Category");
            else
                _logger.Info("failed to add");
            _logger.Info("End add a list Category Category");
            return success;
        }

        public bool Edit(Unit unit)
        {
            bool success;
            _logger.Info("Start Editing");
            try
            {
                repoUnit.Attach(unit);
                _uow.SaveChange();
                success = true;
            }
            catch(Exception ex)
            {
                success = false;
            }
            if (success == true)
                _logger.Info("successfull Edited category");
            else _logger.Info("failed to Edit");
            _logger.Info("End Edit a Category");
            return success;
        }

        public List<Unit> GetAll()
        {
            _logger.Info("Start fetch ALl Unit");
            List<Unit> units = repoUnit.GetAll().ToList();
            _logger.Info("End fetch ALl Unit");
            return units;

        }
    }
}