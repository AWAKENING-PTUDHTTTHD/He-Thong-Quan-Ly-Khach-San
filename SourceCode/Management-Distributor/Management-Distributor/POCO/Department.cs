using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Management_Distributor.POCO
{
    public class Department
    {
        //public Department()
        //{
        //    this.Employees = new HashSet<Employee>();
        //}
        [Key]
        public string DepartmentId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string DepartmentName { get; set; }
        [Required(ErrorMessage = "Department is required")]

        //[ForeignKey("Employees")]
        public string EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}