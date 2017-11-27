using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Management_Distributor.POCO
{
    public class Payments
    {
        [Key]
        public string PaymentId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Cardnumber { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Note is required")]
        public string Note { get; set; }


        [Required(ErrorMessage = "ExceedDate is required")]
        public DateTime ExceedDate { get; set; }

        [Required(ErrorMessage = "PaidDate is required")]
        public DateTime? PaidDate { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        public decimal Amount { get; set; }

        [ForeignKey("Invoices")]
        public virtual string InvoiceId { get; set; }

        [ForeignKey("Employees")]
        public virtual string EmployeeId { get; set; }

    }
}