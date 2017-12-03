using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Management_Distributor.POCO
{
    public class Payment
    {
        [Key, ForeignKey("Invoice")]
        public string PaymentId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [DataType(DataType.CreditCard, ErrorMessage = "Cart Number is invalid")]
        public string Cardnumber { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; }

        public string Note { get; set; }

        [Required(ErrorMessage = "ExceedDate is required")]
        public DateTime ExceedDate { get; set; }

        [Required(ErrorMessage = "PaidDate is required")]
        public DateTime? PaidDate { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        public decimal Amount { get; set; }

        // Foreign  key
        public string InvoiceId { get; set; }
        public string EmployeeId { get; set; }
        // One to One with Invoice and Employee
        public virtual Invoice Invoice { get; set; }
        public virtual Employee Employee { get; set; }

    }
}