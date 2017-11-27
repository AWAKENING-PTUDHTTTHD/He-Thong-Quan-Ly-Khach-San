using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Management_Distributor.POCO
{
    public class Invoices
    {
        [Key]
        public string InvoiceId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string InvoiceName { get; set; }

        public DateTime? CreatedDate { get; set; }

        [Required(ErrorMessage = "RequireDeliveryDate is required")]
        public DateTime RequireDeliveryDate { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        public decimal Amount { get; set; }

        [ForeignKey("Orders")]
        public virtual string OrderId { get; set; }

    }
}