using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Distributor.POCO
{
    public class Product
    {

        public Product()
        {
            ImageUrl = "/Uploads/ProductImages/No_Image_Available.jpg";
        }
        [Key]
        [Display(Name = "ID")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100)]
        [Index(IsUnique = true)]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Price is required")]
        //public decimal Price { get; set; }

        public string Description { get; set; } 

        // Foreign Key
        public int CategoryId { get; set; }

        // One to One with category
        public virtual Category Category { get; set; }

        // One to Many with OrderDetail
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        [DefaultValue(0)]
        [Required(ErrorMessage = "Availabel Quantity is required!")]
        [Range(0, 100000)]
        public int AvailableQty { get; set; }

        [Range(0, Double.PositiveInfinity)]
        public decimal Price { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}