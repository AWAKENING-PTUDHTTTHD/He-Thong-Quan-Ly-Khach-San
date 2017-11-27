using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Management_Distributor.POCO
{
    public class Categorys
    {
        //Categorys ()
        //{
        //    products = new IList<Products>();
        //}
        [Key]
        public string CategoryId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        /*
         * 
         * Has many product
         * 
         * 
         * 
         */
        //public virtual ICollection<Products> products { get; set; }
    }
}