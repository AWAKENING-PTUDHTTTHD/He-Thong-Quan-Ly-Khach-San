using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Management_Distributor.POCO
{
    public class Employee
    {
        [Key]
        public string EmployeeId { get; set; }
        [Required]
        public string EmpName { get; set; }
        [Required]
        public int EmpDepart { get; set; }
        [Required]
        public string EmpAddress { get; set; }

        // temporary skip avatar image 
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string EmpEmail { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string EncryptedPassword { get; set; }
        [Required]
        public string Salt { get; set; }
        public DateTime LastLogged { get; set; }
        public int NumOfLoginAttemp { get; set; }
        public DateTime LastAttemp { get; set; }
    }
}