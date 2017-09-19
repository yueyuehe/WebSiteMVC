using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteBLL.Implements;
using WebSiteBLL.Interface;
using WebSiteEntity;

namespace WebSiteManage.Controllers
{
    public class WebColumnController : Controller
    {
        private IWebColumnBll bll = new WebColumnBll();
        // GET: WebColumn
        /// <summary>
        /// 主页
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Index(int id)
        {
            var query = bll.Find(model => model.WebSite.Id == id);
            return View(query.ToList());
        }
       
        /// <summary>
        /// 跳转到更新页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult UpdateUI(int id)
        {
            var query = bll.Find(model => model.Id == id);
            return View(query.First());
        }
        
        /// <summary>
        /// 跳转到更新页面
        /// </summary>
        /// <returns></returns>
        public ActionResult AddUI()
        {
            return View();
        }
      
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            var query = bll.Find(model => model.Id == id);
            bll.Delete(query.First());
            return View("Index");
        }
    }
}