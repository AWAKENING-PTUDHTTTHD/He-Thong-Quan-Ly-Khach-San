using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Distributor.POCO
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }

        public string Description { get; set; } 

        // Foreign Key
        public int CategoryId { get; set; }

        // One to One with category
        public virtual Category Category { get; set; }

        // One to Many with OrderDetail
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}