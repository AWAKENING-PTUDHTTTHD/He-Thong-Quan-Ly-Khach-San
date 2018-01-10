using Distributor.Dao.Interfaces;
using Distributor.POCO;
using Management_Distributor.Service.Interfaces;
using NLog;
using Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Management_Distributor.Service.Implementations
{
    public class DeliveryPlanService : IDeliveryPlanService
    {

        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        private IUnitOfWork _uow = null;
        private IRepository<DeliveryPlan> repodeliveryPlan = null;

        private IRepository<Order> repoOder = null;
        private IRepository<_Distributor> repoDistributor = null;

        public DeliveryPlanService(IUnitOfWork uow)
        {
            _uow = uow;
            repodeliveryPlan = _uow.Repository<DeliveryPlan>();
            repoOder = _uow.Repository<Order>();
            repoDistributor = _uow.Repository<_Distributor>();
        }
        public bool Add(DeliveryPlan deliveryPlan)
        {
            bool success;
            _logger.Info("Start add new deliveryPlan");
            repodeliveryPlan.Add(deliveryPlan);
            _logger.Info("End add new deliveryPlan");
            success = (_uow.SaveChange() > 0) ? true : false;
            if (success == true)
                _logger.Info("successfull added deliveryPlan");
            else
                _logger.Info("failed to add");
            _logger.Info("End add a list deliveryPlan deliveryPlan");
            return success;
        }

        public bool AddRange(List<DeliveryPlan> deliveryPlans)
        {
            bool success;
            _logger.Info("Start add a list DeliveryPlan");
            repodeliveryPlan.AddRange(deliveryPlans);
            success = (_uow.SaveChange() == deliveryPlans.Count()) ? true : false;
            if (success == true)
                _logger.Info("successfull added list DeliveryPlan");
            else
                _logger.Info("failed to add");
            _logger.Info("End add a list DeliveryPlan list DeliveryPlan");
            return success;
        }

        public bool Delete(DeliveryPlan deliveryPlan)
        {
            bool success;
            _logger.Info("Start deleting");
            repodeliveryPlan.Delete(deliveryPlan);
            success = _uow.SaveChange() > 0;
            if (success == true)
                _logger.Info("successfull deteled deliveryPlan");
            else _logger.Info("failed to delete");
            _logger.Info("End delete a deliveryPlan");
            return success;
        }

        public bool Edit(DeliveryPlan deliveryPlan)
        {
            bool success;
            _logger.Info("Start Editing");
            repodeliveryPlan.Attach(deliveryPlan);
            success = (_uow.SaveChange() > 0);
            if (success == true)
                _logger.Info("successfull Edited deliveryPlan");
            else _logger.Info("failed to Edit");
            _logger.Info("End Edit a deliveryPlan");
            return success;
        }

        public List<DeliveryPlan> GetAll()
        {
            _logger.Info("Start fetch ALl deliveryPlans");
            List<DeliveryPlan> deliveryPlans = repodeliveryPlan.GetAll().ToList();
            _logger.Info("End fetch ALl deliveryPlans");
            return deliveryPlans;
        }

        public List<DeliveryPlan> GetBetween(DateTime beg, DateTime end)
        {
            _logger.Info("Start fetch ALl deliveryPlans");
            List<DeliveryPlan> deliveryPlans = repodeliveryPlan.GetAll()
                .Where(d => d.DeliveryDate >= beg && d.DeliveryDate <= end)
                .ToList();
            _logger.Info("End fetch ALl deliveryPlans");
            return deliveryPlans;
        }

        public List<DeliveryPlan> GetByRegion(int regionID)
        {
            _logger.Info("Start fetch ALl deliveryPlans");
            //var deliveryPlans = from dp in repodeliveryPlan.GetAll()
            //                    join o in repoOder.GetAll()
            //                    on dp.OrderId equals o.OrderId
            //                    join d in repoDistributor.GetAll()
            //                    on o.DistributorId equals d.DistributorId
            //                    select new
            //                    {
            //                        dp.DeliveryPlanId,
            //                        dp.DeliveryDate,
            //                        dp.Status,
            //                        dp.Description,
            //                        dp.OrderId
            //                    };

            //  lambda Join function
            var deliveryPlans = repodeliveryPlan.GetAll().Where(dlp => dlp.Status == "PROCESSING").Join(repoOder.GetAll(),
                                dp => dp.OrderId,
                                od => od.OrderId,
                                (deliveryPlan, order) => new { DeliveryPlan = deliveryPlan, Order = order }
                                ).Select(x => x.DeliveryPlan);

            _logger.Info("End fetch ALl deliveryPlans");
            return deliveryPlans.ToList();
        }

        public List<DeliveryPlan> GetByTime(DateTime beg, DateTime end)
        {
            _logger.Info("Start fetch ALl deliveryPlans");
            List<DeliveryPlan> deliveryPlans = repodeliveryPlan.GetAll()
                .Where(d => d.DeliveryDate >= beg && d.DeliveryDate <= end)
                .ToList();
            _logger.Info("End fetch ALl deliveryPlans");
            return deliveryPlans;
        }

        public DeliveryPlan GetOne(int id)
        {
            _logger.Info("Start fetch single DeliveryPlan");
            DeliveryPlan delivery = null;
            delivery = repodeliveryPlan.GetById(id);
            if (delivery == null)
                _logger.Info("this category not existed");
            else _logger.Info("Got this DeliveryPlan");
            _logger.Info("End fetch single DeliveryPlan");
            return delivery;
        }

        public List<DeliveryPlan> GetPage(int page = 1)
        {

            List<DeliveryPlan> L;
            L = repodeliveryPlan.GetAll()
                            .OrderByDescending(p => p.DeliveryPlanId)
                            .Skip((page - 1) * PageConfig.PageSize)
                            .Take(PageConfig.PageSize)
                            .ToList();
            return L;
        }
    }
}