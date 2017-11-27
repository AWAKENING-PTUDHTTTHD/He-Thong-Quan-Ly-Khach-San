using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Management_Distributor.POCO
{
    public class OrdersDetails
    {
        [Key]
        [ForeignKey("Orders")]
        public virtual string OrderId { get; set; }

        [Key]
        [ForeignKey("Products")]
        public virtual string ProductId { get; set; }


        [Required(ErrorMessage = "Unit is required")]
        public string Unit { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Demandquantity is required")]
        public int DemandQuantity { get; set; }

        public int ActualQuantity { get; set; }




    }
}