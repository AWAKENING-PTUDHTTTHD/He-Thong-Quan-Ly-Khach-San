using Distributor.Dao.Interfaces;
using Distributor.POCO;
using Management_Distributor.Service.Interfaces;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace Management_Distributor.Service.Implementations
{
    public class DistributorService : IDistributorService
    {
        #region member
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        private IUnitOfWork _uow = null;
        private IRepository<_Distributor> repoDistributor = null;
        #endregion

        //#region method
        public DistributorService(IUnitOfWork uow)
        {
            _uow = uow;
            repoDistributor = _uow.Repository<_Distributor>();
        }

        //    public _Distributor FindById(int Id)
        //    {
        //        return repoDistributor.GetById(Id);
        //    }
        //    public bool AddRange(List<_Distributor> distributors)
        //    {

        //        bool success=false;
        //        _logger.Info("Start add a list Region");
        //        try
        //        {
        //            repoDistributor.AddRange(distributors);
        //            _uow.SaveChange();
        //            success = true;

        //        }
        //        catch(DbEntityValidationException e)
        //        {
        //            foreach(var eve in e.EntityValidationErrors)
        //            {
        //                Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
        //                 eve.Entry.Entity.GetType().Name, eve.Entry.State);
        //                foreach (var ve in eve.ValidationErrors)
        //                {
        //                    Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
        //                        ve.PropertyName, ve.ErrorMessage);
        //                }
        //            }
        //            throw;
        //        }

        //        //success = (_uow.SaveChange() == distributors.Count()) ? true : false;
        //        if (success == true)
        //            _logger.Info("successfull added list Region");
        //        else
        //            _logger.Info("failed to add");
        //        _logger.Info("End add a list _Distributor list Region");
        //        return success;
        //    }

        //    #endregion
        //

        public bool Add(_Distributor _Distributor)
        {
            bool success;
            _logger.Info("Start add new _Distributor");
            repoDistributor.Add(_Distributor);
            _logger.Info("End add new _Distributor");
            success = (_uow.SaveChange() > 0) ? true : false;
            if (success == true)
                _logger.Info("successfull added _Distributor");
            else
                _logger.Info("failed to add");
            _logger.Info("End add a list _Distributor _Distributor");
            return success;
        }

        public bool AddRange(List<_Distributor> distributors)
        {
            bool success;
            _logger.Info("Start add a list _Distributor");
            repoDistributor.AddRange(distributors);
            success = (_uow.SaveChange() == distributors.Count()) ? true : false;
            if (success == true)
                _logger.Info("successfull added list _Distributor");
            else
                _logger.Info("failed to add");
            _logger.Info("End add a list _Distributor list _Distributor");
            return success;
        }

        public bool Delete(_Distributor _Distributor)
        {
            bool success;
            _logger.Info("Start deleting");
            repoDistributor.Delete(_Distributor);
            success = _uow.SaveChange() > 0;
            if (success == true)
                _logger.Info("successfull deteled _Distributor");
            else _logger.Info("failed to delete");
            _logger.Info("End delete a _Distributor");
            return success;
        }

        public bool Edit(_Distributor _Distributor)
        {
            bool success;
            _logger.Info("Start Editing");
            repoDistributor.Attach(_Distributor);
            success = (_uow.SaveChange() > 0);
            if (success == true)
                _logger.Info("successfull Edited _Distributor");
            else _logger.Info("failed to Edit");
            _logger.Info("End Edit a _Distributor");
            return success;
        }

        public List<_Distributor> GetAll()
        {
            _logger.Info("Start fetch ALl _Distributor");
            List<_Distributor> _Distributor = repoDistributor.GetAll().ToList();
            _logger.Info("End fetch ALl _Distributor");
            return _Distributor;
        }

        public _Distributor GetOne(int id)
        {
            _logger.Info("Start fetch single _Distributor");
            _Distributor _Distributor = null;
            _Distributor = repoDistributor.GetById(id);
            if (_Distributor == null)
                _logger.Info("this _Distributor not existed");
            else _logger.Info("Got this _Distributor");
            _logger.Info("End fetch single _Distributor");
            return _Distributor;
        }
    }
}