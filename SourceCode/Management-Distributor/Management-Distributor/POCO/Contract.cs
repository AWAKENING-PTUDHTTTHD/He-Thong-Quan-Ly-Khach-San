using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Management_Distributor.POCO
{
    public class Contracts
    {
        Contracts()
        {
            Status = "";
        }
        [Key]
        public string ContractId { get; set; }

        public DateTime? SignedDate { get; set; }
        public string Description { get; set; }

        public string Status { get; set; }

        [ForeignKey("Employees")]
        public string EmpolyeeId { get; set; }

        [ForeignKey("Distributor")]
        public virtual string DistributorId { get; set; }
    }
}