//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Web;

//namespace Distributor.POCO
//{
//    public class Contract
//    {
//        [Key]
//        public int ContractId { get; set; }

//        public DateTime? SignedDate { get; set; }
//        public string Description { get; set; }

//        [Required(ErrorMessage = "Status is required")]
//        public string Status { get; set; }

//        // Foreign Key
//        public int DistributorId { get; set; }
//        //public int EmployeeId { get; set; }

//        // One to One with Employee and Distributor
//        //public virtual Employee Employee { get; set; }
//        public virtual _Distributor Distributor { get; set; }
//    }
//}