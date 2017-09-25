using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteBLL.Implements;
using WebSiteBLL.Implements.Module;
using WebSiteBLL.Interface;
using WebSiteBLL.Interface.Module;
using WebSiteEntity;
using WebSiteEntity.Module;

namespace WebSiteMVC.Controllers
{
    public class ArticleController : Controller
    {
        IWebColumnBll columnBll = new WebColumnBll();
        IArticleBll articleBll = new ArticleBll();

        // GET: Article
        /// <summary>
        /// 相关模块的主页
        /// </summary>
        /// <param name="id">栏目ID</param>
        /// <returns></returns>
        public ActionResult Index(int id)
        {
            //1:获取父栏目以及子栏目
          //  List<WebColumn> columnList = columnBll.FindChildAndParent(id);
          //  //一级
          //  WebColumn one_level = columnList.Where(model => model.Level == 1 && model.IsShow).First();
          //  //二级
          //  List<WebColumn> second_level = columnList.Where(model => model.Level == 2 && model.IsShow).OrderBy(model => model.Sort).ToList();
          //  //三级
          //  List<WebColumn> third_level = columnList.Where(model => model.Level == 3 && model.IsShow).OrderBy(model => model.Sort).ToList();
          //
          //  //2:获取栏目的指定的值 没有默认
          //  //设置指定的栏目被选择
          //
          //  //获取选择栏目的文章列表
          //  List<Article> articles = articleBll.GetArticlesByColumnID(id).Where(model => model.IsShow).OrderBy(model => model.IsTop).ThenBy(model => model.IsRecommend).ThenByDescending(model => model.PublishDate).ToList();
          //
          //  //没有指定栏目的文章被选中的话 就显示置顶 推荐 一般的文章
          //
          //  //3:设置主页默认显示的数据或者指定的数据
          //  ViewData["articles"] = articles;
          //  ViewData["one_level"] = one_level;
          //  ViewData["second_level"] = second_level;
          //  ViewData["third_level"] = third_level;
            return View();
        }
    }
}