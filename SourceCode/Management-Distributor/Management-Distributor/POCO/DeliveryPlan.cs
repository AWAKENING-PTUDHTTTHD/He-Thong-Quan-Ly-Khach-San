using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Distributor.POCO
{
    public class DeliveryPlan
    {
        public DeliveryPlan()
        {
            DeliveryDate = DateTime.Now;
        }
        [Key]
        public int DeliveryPlanId { get; set; }

        [Required(ErrorMessage = "Delivery Date is required")]
        public DateTime  DeliveryDate { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; }

        // Foreign key
        public int OrderId { get; set; }
        
        // One to One with Order
        public virtual Order Order { get; set; }


    }
}