using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Distributor.POCO
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        // unique constraint can't be over 8000 bytes per row
        // only use the first 900 bytes
        [MaxLength(50)]
        [Required(ErrorMessage = "Name is required")]
        [Index(IsUnique = true)]
        public string CategoryName { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}