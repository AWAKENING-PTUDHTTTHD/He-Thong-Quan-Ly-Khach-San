using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Distributor.POCO
{
    public class Region
    {
        //Region()
        //{
        //    this.Distributors = new HashSet<Distributor>();
        //}
        [Key]
        public int RegionId { get; set; }
                
        [MinLength(5, ErrorMessage ="Region name could not be less than 5 character")]
        [MaxLength(50, ErrorMessage = "Region name could not be longer than 50 character")]
        [Required(ErrorMessage = "Name is required!")]
        [Index(IsUnique = true)]
        public string RegionName { get; set; }

        // Danh Sach nha PP
        public virtual ICollection<_Distributor> Distributors { get; set; }
    }
}