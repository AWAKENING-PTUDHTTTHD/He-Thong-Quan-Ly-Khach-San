using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Management_Distributor.POCO
{
    public class Products
    {
        [Key]
        public string ProductId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }

        public string Description { get; set; } 

        [ForeignKey("Categorys")]
        public virtual string CategoryId { get;set }
    }
}