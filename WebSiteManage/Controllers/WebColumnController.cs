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
        public ActionResult Index(int id = 0)
        {
            //var query = bll.Find(model => model.WebSite.Id == id);
            //return View(query.ToList());
            return View();
        }

        public JsonResult GetWebColumn(int id = 0)
        {
            var result = new JsonResult();
            var model = new { Id = 1, Sort = 0, Name = "我是父元素", Position = "", WebModuleName = "", WebModuleCatalog = "", Parent = 0 };
            var list = Enumerable.Repeat(model, 0).ToList();
            list.Add(model);
            for (int i = 2; i < 20; i++)
            {
                var model2 = new { Id = i, Sort = i, Name = "Name" + i, Position = "位置" + i, WebModuleName = "模块" + i, WebModuleCatalog = "目录" + i, Parent = 1 };
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
            ViewBag.parentId = Request["parentID"] ?? "";
            ViewBag.webSiteId = Request["webSiteId"] ?? "";
            var dic = new Dictionary<ModuleType, string>();
            ViewBag.webModule = dic;
            dic.Add(ModuleType.Article, "文章");
            dic.Add(ModuleType.Case, "客户案例");
            dic.Add(ModuleType.Summary, "简介中心");
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

        public ActionResult Save(WebColumn model)
        {

            return RedirectToAction("Index");
        }
    }
}