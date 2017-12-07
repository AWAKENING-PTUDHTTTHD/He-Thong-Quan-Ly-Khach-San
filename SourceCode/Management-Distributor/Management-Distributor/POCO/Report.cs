using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Distributor.POCO
{
    public class Report
    {
        // Construct some prop
        Report ()
        {
            NumbOfEdit = 1;
            CreatedDate = DateTime.Now;
        }
        [Key]
        public int ReportId { get; set; }

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


        public Nullable<int> NumbOfEdit { get; set; }

        // Foreign Key
        public int EmployeeId { get; set; }

        // One to One with Employee
        public virtual Employee Employee { get; set; }

    }
}