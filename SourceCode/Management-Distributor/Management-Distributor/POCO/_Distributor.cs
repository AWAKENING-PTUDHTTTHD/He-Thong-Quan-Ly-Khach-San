using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Distributor.POCO
{
    public class _Distributor
    {
        [Key]
        public int DistributorId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100)]
        [Index(IsUnique = true)]
        [Display(Name = "Name")]
        public string DistributorName { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is required")]
        public string DistributorAddress { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "The email provided is invalid!")]
        public string DistributorEmail { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number is required")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "The phone provided is invalid!")]
        public string DistributorPhoneNumber { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; }

        public int RegionId { get;set;}

        public virtual Region Region { get; set; }

       // public virtual ICollection<Contract> Contracts { get; set; }
    }
}