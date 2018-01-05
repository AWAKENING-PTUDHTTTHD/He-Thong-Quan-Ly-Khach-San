using Distributor.Dao.Interfaces;
using Distributor.POCO;
using Management_Distributor.Service.Interfaces;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Management_Distributor.Service.Implementations
{
    public class RegionService : IRegionService
    {
        #region member
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        private IUnitOfWork _uow = null;
        private IRepository<Region> repoRegion = null;
        #endregion

        #region method
        public RegionService(IUnitOfWork uow)
        {
            _uow = uow;
            repoRegion = _uow.Repository<Region>();
        }
        public bool Add(Region region)
        {
            bool success;
            _logger.Info("Start add new Region");
            repoRegion.Add(region);
            _logger.Info("End add new Region");
            success = (_uow.SaveChange() > 0) ? true : false;
            if (success == true)
                _logger.Info("successfull added Region");
            else
                _logger.Info("failed to add");
            _logger.Info("End add a list Region");
            return success;
        }

        public bool AddRange(List<Region> regions)
        {
            bool success;
            _logger.Info("Start add a list Region");
            repoRegion.AddRange(regions);
            success = (_uow.SaveChange() == regions.Count()) ? true : false;
            if (success == true)
                _logger.Info("successfull added list Region");
            else
                _logger.Info("failed to add");
            _logger.Info("End add a list Category list Region");
            return success;
        }

        public bool Delete(Region region)
        {
            bool success;
            _logger.Info("Start deleting");
            repoRegion.Delete(region);
            success = _uow.SaveChange() > 0;
            if (success == true)
                _logger.Info("successfull deteled region");
            else _logger.Info("failed to delete");
            _logger.Info("End delete a region");
            return success;
        }

        public bool Edit(Region region)
        {
            bool success;
            _logger.Info("Start Editing");
            repoRegion.Attach(region);
            success = (_uow.SaveChange() > 0);
            if (success == true)
                _logger.Info("successfull Edited Region");
            else _logger.Info("failed to Edit");
            _logger.Info("End Edit a Region");
            return success;
        }

        public List<Region> GetAll()
        {
            _logger.Info("Start fetch ALl category");
            List<Region> regions = repoRegion.GetAll().ToList();
            _logger.Info("End fetch ALl category");
            return regions;
        }

        public Region GetOne(int id)
        {
            _logger.Info("Start fetch single category");
            Region region = null;
            region = repoRegion.GetById(id);
            if (region == null)
                _logger.Info("this category not existed");
            else _logger.Info("Got this category");
            _logger.Info("End fetch single category");
            return region;
        }
        #endregion method
    }
}