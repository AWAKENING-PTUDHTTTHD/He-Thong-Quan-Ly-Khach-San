using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Distributor.POCO
{
    public class Invoice
    {
        [Key, ForeignKey("Order")]
        public int InvoiceId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string InvoiceName { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime Created_At { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        public decimal Amount { get; set; }

        // Foreign key
        public int OrderId { get; set; }
        public int EmployeeId { get; set; }

        // One to One with Order, Payment and Employee
        public virtual Order Order { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual Employee Employee { get; set; }

    }
}