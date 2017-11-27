using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Management_Distributor.POCO
{
    public class Distributor
    {
        Distributor()
        {
            Region = new Region();
        }
        [Key]
        public string DistributorId { get; set; }
        [Required]
        public string DistributorName { get; set; }
        [Required]
        public string DistributorAddress { get; set; }
        [Required]
        public string DistributorEmail { get; set; }
        [Required]
        public string DistributorPhoneNumber { get; set; }
        public string Description { get; set; }
        [Required]
        public string Status { get; set; }
        public virtual Region Region { get;set;}
    }
}