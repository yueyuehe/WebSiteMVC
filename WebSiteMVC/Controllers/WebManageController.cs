using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSiteMVC.Controllers
{
    public class WebManageController : Controller
    {
        /// <summary>
        /// 管理页面的主页
        /// </summary>
        /// <returns></returns>
        // GET: WebManage
        public ActionResult Index()
        {
            return View();
        }
    }
}