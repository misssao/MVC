using OnlineShop.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class Category_Product
    {
        public List<Product> listProduct { get; set; }
        public List<Category> listCategory { get; set; }
    }
}