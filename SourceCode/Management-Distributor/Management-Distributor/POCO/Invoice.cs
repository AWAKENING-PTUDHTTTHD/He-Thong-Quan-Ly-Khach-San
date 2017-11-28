using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Management_Distributor.POCO
{
    public class Invoice
    {
        [Key]
        public string InvoiceId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string InvoiceName { get; set; }

        public DateTime? CreatedDate { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        public decimal Amount { get; set; }

        public string OrderOrderId { get; set; }
        public virtual Order Order { get; set; }

        public virtual Payment Payment { get; set; }

        public string EmployeeEmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

    }
}