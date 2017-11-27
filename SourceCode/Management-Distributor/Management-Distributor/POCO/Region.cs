using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Management_Distributor.POCO
{
    public class Regions
    {
        //Region()
        //{
        //    //Distributor = new List<Distributor>();
        //}
        [Key]
        public string RegionId { get; set; }
        [MinLength(5, ErrorMessage ="Region name could not be less than 5 character")]
        [MaxLength(50, ErrorMessage = "Region name could not be much than 50 character")]
        public string RegionName { get; set; }
        //public virtual ICollection<Distributor> Distributor { get; set; }
    }
}