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

        #region method
        public DistributorService(IUnitOfWork uow)
        {
            _uow = uow;
            repoDistributor = _uow.Repository<_Distributor>();
        }

        public _Distributor FindById(int Id)
        {
            return repoDistributor.GetById(Id);
        }
        public bool AddRange(List<_Distributor> distributors)
        {

            bool success=false;
            _logger.Info("Start add a list Region");
            try
            {
                repoDistributor.AddRange(distributors);
                _uow.SaveChange();
                success = true;

            }
            catch(DbEntityValidationException e)
            {
                foreach(var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                     eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
           
            //success = (_uow.SaveChange() == distributors.Count()) ? true : false;
            if (success == true)
                _logger.Info("successfull added list Region");
            else
                _logger.Info("failed to add");
            _logger.Info("End add a list Category list Region");
            return success;
        }

        #endregion
    }
}