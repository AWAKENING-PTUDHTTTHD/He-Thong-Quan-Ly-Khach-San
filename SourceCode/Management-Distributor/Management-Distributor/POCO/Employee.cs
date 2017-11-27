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
        [Required(ErrorMessage = "Name is required")]
        public string EmpName { get; set; }
        [Required(ErrorMessage = "Department is required")]
        public int EmpDepart { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string EmpAddress { get; set; }

        // temporary skip avatar image 
        [Required(ErrorMessage = "Phone number is required!")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email is required!")]
        //[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [DataType(DataType.EmailAddress,ErrorMessage = "Email is not valid")]
        public string EmpEmail { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [MaxLength(20, ErrorMessage = "Username maximum is 20 character"), MinLength(5, ErrorMessage = "Username could not less than 5 character")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string EncryptedPassword { get; set; }
        [Required(ErrorMessage = "Salf is required")]
        public string Salt { get; set; }
        public DateTime LastLogged { get; set; }
        public int NumOfLoginAttemp { get; set; }
        public DateTime LastAttemp { get; set; }
    }
}