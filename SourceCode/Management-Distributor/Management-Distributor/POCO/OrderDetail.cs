using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Management_Distributor.POCO
{
    public class OrderDetail
    {
        [Key]
        public string OrderDetailId { get; set; }
        //[ForeignKey("Orders")]

        public string OrderOrderId { get; set; }
        public virtual Order Order { get; set; }

        public string ProductProductId { get; set; }
        public virtual Product Product { get; set; }


        [Required(ErrorMessage = "Unit is required")]
        public string Unit { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Demandquantity is required")]
        public int DemandQuantity { get; set; }

        public int ActualQuantity { get; set; }




    }
}