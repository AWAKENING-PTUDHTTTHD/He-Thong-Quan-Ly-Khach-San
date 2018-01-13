using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Distributor.POCO
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100)]
        [Index(IsUnique = true)]
        public string DepartmentName { get; set; }

        [ForeignKey("Employee")]
        public int? EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}