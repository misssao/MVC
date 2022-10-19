using OnlineShop.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class NewsController : Controller
    {
        //
        // GET: /News/
        OnlineShopEntities objModel = new OnlineShopEntities();
        public ActionResult Index()
        {
            var lstNews = objModel.News.ToList();
            return View(lstNews);
        }

    }
}
