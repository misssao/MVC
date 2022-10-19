using OnlineShop.Context;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        OnlineShopEntities objModel = new OnlineShopEntities();
        public ActionResult Index()
        {
            var lstCategory = objModel.Categories.ToList();
            var lstProduct = objModel.Products.ToList();

            Category_Product objCategory_Product = new Category_Product();
            objCategory_Product.listCategory = lstCategory;
            objCategory_Product.listProduct = lstProduct;

            return View(objCategory_Product);
        }

    }
}
