using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Management_Distributor.POCO
{
    public class Region
    {
        //Region()
        //{
        //    //Distributor = new List<Distributor>();
        //}
        [Key]
        public string RegionId { get; set; }
        public string RegionName { get; set; }
        //public virtual ICollection<Distributor> Distributor { get; set; }
    }
}