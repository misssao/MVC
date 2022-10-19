using OnlineShop.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Admin/Product/
        OnlineShopEntities dbObj = new OnlineShopEntities();
        public ActionResult Index()
        {
            var lstProduct = dbObj.Products.ToList();
            return View(lstProduct);
        }

        [HttpGet]
        public ActionResult Create(){
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product objProduct)
        {
            try
            {
                if (objProduct.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
                    string extension = Path.GetExtension(objProduct.ImageUpload.FileName);
                    fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                    objProduct.avartar = fileName;
                    objProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/home_shoppe-web_Free26-10-2017_607046700/web/images"), fileName));
                }
                dbObj.Products.Add(objProduct);
                dbObj.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
                throw;
            }
        }

        public ActionResult Details(int id)
        {
            var objProduct = dbObj.Products.Where(n => n.id == id).FirstOrDefault();
            return View(objProduct);
        }
    }
}
