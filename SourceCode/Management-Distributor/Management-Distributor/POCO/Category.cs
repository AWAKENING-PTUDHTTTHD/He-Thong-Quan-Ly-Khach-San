using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Management_Distributor.POCO
{
    public class Category
    {
        //public Category()
        //{
        //    this.Products = new HashSet<Product>();
        //}
        [Key]
        public string CategoryId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}