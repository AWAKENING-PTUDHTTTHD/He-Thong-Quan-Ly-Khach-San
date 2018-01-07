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
    public class InvoiceService : IInvoiceService
    {

        #region member
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        private IUnitOfWork _uow = null;
        private IRepository<Invoice> repoCategory = null;
        #endregion

        #region method
        public InvoiceService(IUnitOfWork uow)
        {
            _uow = uow;
            repoCategory = _uow.Repository<Invoice>();
        }
        public bool Add(Invoice invoice)
        {
            bool success;
            _logger.Info("Start add new Invoice");
            repoCategory.Add(invoice);
            _logger.Info("End add new Invoice");
            success = (_uow.SaveChange() > 0) ? true : false;
            if (success == true)
                _logger.Info("successfull added Invoice");
            else
                _logger.Info("failed to add");
            _logger.Info("End add a new Invoice");
            return success;
        }
        #endregion
    }
}