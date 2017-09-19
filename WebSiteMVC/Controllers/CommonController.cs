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
            var columnList = new List<WebColumn>();



            return View();
        }
    }
}