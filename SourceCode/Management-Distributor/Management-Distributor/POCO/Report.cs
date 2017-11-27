using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Management_Distributor.POCO
{
    public class Reports
    {
        Reports ()
        {
            NumbOfEdit = 1;
        }
        [Key]
        public string ReportId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string ReportName { get; set; }

        [Required(ErrorMessage = "ReportType is required")]

        public string ReportType { get; set; }

        [Required(ErrorMessage = "ReportContent is required")]
        public string ReportContent { get; set; }

        public string Note { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime RequiredDate { get; set; }

        public DateTime LastEdited { get; set; }


        public int NumbOfEdit { get; set; }

        [ForeignKey("Employees")]
        public virtual string EmployeeId { get; set; }

    }
}