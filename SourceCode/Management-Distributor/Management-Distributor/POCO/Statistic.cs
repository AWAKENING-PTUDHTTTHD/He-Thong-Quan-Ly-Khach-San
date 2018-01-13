using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Distributor.POCO
{
    public class Statistic
    {
        Statistic()
        {
            NumbOfEdit = 1;
            CreatedDate = DateTime.Now;
        }
        [Key]
        public int StatisticId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100)]
        [Index(IsUnique = true)]
        public string StatisticName { get; set; }

        [Required(ErrorMessage = "Statistic Content is required")]
        public string StatisticContent { get; set; }

        public string Note { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime RequiredDate { get; set; }

        public DateTime LastEdited { get; set; }


        public Nullable<int> NumbOfEdit { get; set; }

        // Foreign key
        public int EmployeeId { get; set; }

        // One to One with Employee
        public virtual Employee Employee { get; set; }

    }
}