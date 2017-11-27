using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Management_Distributor.POCO
{
    public class Orders
    {
        [Key]
        public string OrderId { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime RequireDeliveryDate { get; set; }

        public string Status { get; set; }

        [ForeignKey("Employees")]
        public virtual string EmployeeId { get; set; }

        [ForeignKey("Contracts")]
        public virtual string ContractId { get; set; }

    }
}