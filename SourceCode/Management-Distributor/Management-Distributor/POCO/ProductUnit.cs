using Distributor.POCO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Management_Distributor.POCO
{
    public class ProductUnit
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int UnitId { get; set; }

        public decimal UnitPrice { get; set; }

        public int AvailableQty {get;set;}

        public virtual Product Product { get; set; }

        public virtual Unit Unit { get; set; }

    }
}