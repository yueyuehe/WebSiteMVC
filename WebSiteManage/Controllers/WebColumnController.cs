using System;
using System.Collections.Generic;
using System.Data;
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
        public ActionResult Index(int? id)
        {
            var query = bll.Find(model => model.WebSite.Id == id);
            return View(query.ToList());
        }

        public JsonResult GetWebColumn(int? id)
        {
            var result = new JsonResult();
            var model = new { Id = 0, Sort = 0, Name = "", Position = "", WebModuleName = "", WebModuleCatalog = "", Parent = 0 };
            var list = Enumerable.Repeat(model, 0).ToList();
            for(int i = 0; i < 20; i++)
            {
                var model2 = new { Id = i, Sort = i, Name = "Name"+i, Position = "位置"+i, WebModuleName = "模块"+i, WebModuleCatalog = "目录"+i, Parent = 0 };
                list.Add(model2);
            }

            result.Data = list;
            return result;
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