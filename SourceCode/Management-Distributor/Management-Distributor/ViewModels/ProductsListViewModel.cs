using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pagination;
using Distributor.POCO;

namespace Management_Distributor.ViewModels
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> products { get; set; }
        public PagingInfo pagingInfo { get; set; }
    }
}