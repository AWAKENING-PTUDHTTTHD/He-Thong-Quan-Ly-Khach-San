using Distributor.POCO;
using Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Distributor.ViewModels
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}