using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSiteManage.Controllers
{
    public class WebSiteController : Controller
    {
        // GET: WebSite
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddUI()
        {
            return View();
        }
        public ActionResult UpdateUI()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Update()
        {
            return View();
        }
        public ActionResult Delete()
        {
            return View();
        }
    }
}