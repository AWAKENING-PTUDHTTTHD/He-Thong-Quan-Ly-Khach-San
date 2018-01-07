using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Distributor.POCO
{
    public class Order
    {
        public Order()
        {
            //this.OrderDetails = new HashSet<OrderDetail>();
            Status = "PROCESSING";
        }
        [Key]

        public int OrderId { get; set; }

        public decimal ToTalAmount { get; set; }

        public DateTime? OrderDate { get; set; }

        public Nullable<DateTime> RequireDeliveryDate { get; set; }

        public string Status { get; set; }

        //[ForeignKey("Employees")]
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

        //[ForeignKey("Contracts")]
        //public virtual int ContractId { get; set; }
        //public virtual Contract Contract { get; set; }

        public int DistributorId { get; set; }
        public virtual _Distributor Distributor { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual Invoice Invoice { get; set; }

    }
}