using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Management_Distributor.POCO
{
    public class Distributor
    {
        Distributor ()
        {
            this.Contracts = new HashSet<Contract>();
        }
        [Key]
        public string DistributorId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string DistributorName { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string DistributorAddress { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string DistributorEmail { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        public string DistributorPhoneNumber { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; }

        //[ForeignKey("Regions")]
        public string RegionRegionId { get;set;}

        public virtual Region Region { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
    }
}