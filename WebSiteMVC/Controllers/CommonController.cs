using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteEntity;

namespace WebSiteMVC.Controllers
{
    public class CommonController : Controller
    {
        // GET: Common
        public ActionResult TopNav()
        {
            var site = new WebSite();
            site.Title = "我的测试网站";
            site.Name = "XXX网站";
            site.Logo = @"~\Content\Image\1342516529.png";
            var columnList = new List<WebColumn>();



            return View();
        }
        public ActionResult Header()
        {
            return View();
        }


    }
}