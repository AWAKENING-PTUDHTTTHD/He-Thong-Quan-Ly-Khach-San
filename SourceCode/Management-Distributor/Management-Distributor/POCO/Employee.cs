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
        [DataType(DataType.PhoneNumber, ErrorMessage = "Phone Number is not valid")]
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

        // Foreign Key
        public string DepartmentId { get; set; }

        // One to one with Department
        public virtual Department Department { get; set; }

        // Zero->Many with Order, Invoice, Payment, Report and Statistic
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
        public virtual ICollection<Statistic> Statistics { get; set; }
    }
}