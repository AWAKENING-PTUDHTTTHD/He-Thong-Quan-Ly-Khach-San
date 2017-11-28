using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Management_Distributor.POCO
{
    public class Statistic
    {
        Statistic()
        {
            NumbOfEdit = 1;
            CreatedDate = DateTime.Now;
        }
        [Key]
        public string StatisticId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string StatisticName { get; set; }

        [Required(ErrorMessage = "Statistic Content is required")]
        public string StatisticContent { get; set; }

        public string Note { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime RequiredDate { get; set; }

        public DateTime LastEdited { get; set; }


        public int NumbOfEdit { get; set; }

        public string EmployeeEmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

    }
}