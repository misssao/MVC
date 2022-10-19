using OnlineShop.Context;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        OnlineShopEntities objModel = new OnlineShopEntities();
        public ActionResult Index(int id)
        {
            var objProduct = objModel.Products.Where(n => n.id.ToString() == id.ToString()).FirstOrDefault();
            var lstCategory = objModel.Categories.ToList();
            var lstProduct = objModel.Products.Where(n => n.categoryID == objProduct.categoryID && n.name != objProduct.name).ToList();
            ProductDetailModel objProductDetailModel = new ProductDetailModel();
            objProductDetailModel.objProduct = objProduct;
            objProductDetailModel.lstCategory = lstCategory;
            objProductDetailModel.lstProduct = lstProduct;

            return View(objProductDetailModel);
        }

    }
}
