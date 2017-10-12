using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteBLL.Implements;
using WebSiteBLL.Implements.Module;
using WebSiteBLL.Interface.Module;
using WebSiteEntity.Module;

namespace WebSiteManage.Controllers
{
    public class ArticleController : Controller
    {
        private IArticleBll bll = new ArticleBll();
        // GET: Article
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListAll()
        {
            JsonResult result = new JsonResult();
            var websiteId = Request["websiteId"] ?? "";
            if (string.IsNullOrEmpty(websiteId))
            {
                //获取article文章数据
                var list = bll.GetArticles(Convert.ToInt32(websiteId));
                result.Data = list;
            }
            return result;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult Delete(int? id)
        {
            if (id != null)
            {
                bll.Delete(Convert.ToInt32(id));
            }
            return null;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Save(Article model)
        {
            var websiteId = Request["webSiteId"]??"";
            var webColumnId = Request["webColumnId"] ?? "";
            if (!string.IsNullOrEmpty(webColumnId))
            {
                model.WebColumn = new WebColumnBll().FindById(Convert.ToInt32(webColumnId));
            }

            if (bll.IsExist(model.Id))
            {
                model.CreateDate = DateTime.Now;
                model.PublishDate = DateTime.Now;
                model.PublishUser = "";//User
                bll.Update(model);
            }
            else
            {
                model.PublishDate = DateTime.Now;
                model.PublishUser = "";//User
                bll.Add(model);
            }
            string path = Path.Combine("ListAll", websiteId);
            //返回ListAll
            return RedirectToAction(path);
        }

        /// <summary>
        /// 跳转到AddUI
        /// </summary>
        /// <returns></returns>
        public ActionResult AddUI()
        {
            return View();
        }


    }
}