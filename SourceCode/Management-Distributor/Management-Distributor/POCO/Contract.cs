using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Management_Distributor.POCO
{
    public class Contract
    {
        //Contract()
        //{
        //    Status = "";
        //}
        [Key]
        public string ContractId { get; set; }

        public DateTime? SignedDate { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; }

        // Foreign Key
        public string EmployeeId { get; set; }
        public string DistributorId { get; set; }

        // One to One with Employee and Distributor
        public virtual Employee Employee { get; set; }
        public virtual Distributor Distributor { get; set; }
    }
}