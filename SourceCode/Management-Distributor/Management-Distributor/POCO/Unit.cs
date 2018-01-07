using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Management_Distributor.POCO
{
    public class Unit
    {
        [Key]
        public int UnitId { get; set; }

        [Required(ErrorMessage = "Unit Name is required!")]
        [Index(IsUnique=true)]
        public string UnitName { get; set; }
        
        [Required(ErrorMessage = "Number of Product Per Unit is require!")]
        public int NumbProduct { get; set; }
    }
}