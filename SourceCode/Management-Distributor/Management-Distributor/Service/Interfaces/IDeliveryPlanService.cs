using Distributor.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Management_Distributor.Service.Interfaces
{
    public interface IDeliveryPlanService
    {
        List<DeliveryPlan> GetPage(int page = 1);
        List<DeliveryPlan> GetAll();
        bool Add(DeliveryPlan deliveryPlan);
        bool Edit(DeliveryPlan deliveryPlan);
        bool Delete(DeliveryPlan deliveryPlan);
        DeliveryPlan GetOne(int id);

        List<DeliveryPlan> GetByTime(DateTime beg, DateTime end);

        List<DeliveryPlan> GetByRegion(int regionID);
        bool AddRange(List<DeliveryPlan> deliveryPlans);
    }
}