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
            ViewBag.webSiteId = id;
            return View();
        }

        public JsonResult GetWebColumn(int id = 0)
        {
            var json = new JsonResult();
            var query = bll.Find(m => m.WebSite.Id == id).Select(m=>new {m.Id,m.Name,m.Position,m.ModuleType,ParentId= m.Parent==null?"":m.Parent.Id.ToString() });
            json.Data = query.ToList();
            return json;
            //var result = new JsonResult();
            //var model = new { Id = 1, Sort = 0, Name = "我是父元素", Position = "", WebModuleName = "", WebModuleCatalog = "", Parent = 0 };
            //var list = Enumerable.Repeat(model, 0).ToList();
            //list.Add(model);
            //for (int i = 2; i < 20; i++)
            //{
            //    var model2 = new { Id = i, Sort = i, Name = "Name" + i, Position = "位置" + i, WebModuleName = "模块" + i, WebModuleCatalog = "目录" + i, Parent = 1 };
            //    list.Add(model2);
            //}
            //result.Data = list;
            //return result;
        }

        /// <summary>
        /// 跳转到更新页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult UpdateUI(int id)
        {
            var query = bll.FindById(id);
            return View(query);
        }

        /// <summary>
        /// 跳转到更新页面
        /// </summary>
        /// <returns></returns>
        public ActionResult AddUI(int? id)
        {
            //如果id!=null则是修改
            var list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "文章", Value = ModuleType.Article.ToString() });
            list.Add(new SelectListItem() { Text = "案例", Value = ModuleType.Case.ToString() });
            list.Add(new SelectListItem() { Text = "下载", Value = ModuleType.Download.ToString() });
            list.Add(new SelectListItem() { Text = "反馈", Value = ModuleType.Feedback.ToString() });
            list.Add(new SelectListItem() { Text = "招聘", Value = ModuleType.Job.ToString() });
            list.Add(new SelectListItem() { Text = "链接", Value = ModuleType.Link.ToString() });
            list.Add(new SelectListItem() { Text = "会员中心", Value = ModuleType.Member.ToString() });
            list.Add(new SelectListItem() { Text = "留言", Value = ModuleType.Message.ToString() });
            list.Add(new SelectListItem() { Text = "产品", Value = ModuleType.Produce.ToString() });
            list.Add(new SelectListItem() { Text = "搜索", Value = ModuleType.Search.ToString() });
            list.Add(new SelectListItem() { Text = "网站地图", Value = ModuleType.Sitemap.ToString() });
            list.Add(new SelectListItem() { Text = "简介", Value = ModuleType.Summary.ToString() });
            if (id != null)
            {
                //获取对象
                var model = bll.FindById(Convert.ToInt32(id));
                ViewBag.parentId = model.Parent == null ? "" : model.Parent.Id.ToString();
                ViewBag.webSiteId = model.WebSite == null ? "" : model.WebSite.Id.ToString();
                this.View(model);
                //对selection设置默认值
                foreach (var item in list)
                {
                    if (item.Value == model.ModuleType.ToString())
                    {
                        item.Selected = true;
                    }
                }
            }
            ViewBag.webModuleList = new SelectList(list, "Value", "Text");
            return View();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            //查找指定的id
            var modle = bll.FindById(id);
            //存在则删除
            if (modle != null)
            {
                bll.Delete(modle.Id);
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Save(WebColumn model)
        {
            //判断该对象在数据库中是否存在
            var result = bll.IsExist(model.Id);
            if (result)
            {
                //存在更新
                bll.Update(model);
            }
            else
            {
                //不存在，保存
                bll.Add(model);
            }
            //返回Index页面
            return RedirectToAction("Index");
        }
    }
}