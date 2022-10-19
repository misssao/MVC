using OnlineShop.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class ProductDetailModel
    {
        public Product objProduct { get; set; }
        public List<Category> lstCategory { get; set; }
        public List<Product> lstProduct { get; set; }
    }
}