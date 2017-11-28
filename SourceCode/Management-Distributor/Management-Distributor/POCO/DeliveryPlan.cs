using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Management_Distributor.POCO
{
    public class DeliveryPlan
    {
        [Key]
        public string DeliveryPlanId { get; set; }

        public string OrderOrderId { get; set; }

        public virtual Order Order { get; set; }

        [Required(ErrorMessage = "Delivery Date is required")]
        public DateTime  DeliveryDate { get; set; }


        public string Description { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; }

  
    }
}