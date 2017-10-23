using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteBLL.Implements;
using WebSiteBLL.Implements.Module;
using WebSiteBLL.Interface;
using WebSiteBLL.Interface.Module;
using WebSiteEntity.Module;

namespace WebSiteManage.Controllers
{
    public class SummaryController : Controller
    {
        private ISummaryBll bll = new SummaryBll();
        private IWebColumnBll columnBll = new WebColumnBll();
        // GET: Summary
        public ActionResult Index()
        {
            return View();
        }



        /// <summary>
        /// 跳转到新增页
        /// </summary>
        /// <returns></returns>
        public ActionResult AddUI()
        {
            return View();
        }

        /// <summary>
        /// 跳转到更新UI
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult EditUI(int? id)
        {
            if (id == null)
            {
                throw new Exception("简介ID不能为空!");
            }
            var model = bll.FindById(Convert.ToInt32(id));
            return View(model);
        }
        /// <summary>
        /// 保存方法
        /// </summary>
        /// <returns></returns>
        public ActionResult Save(Summary model)
        {
            //栏目ID
            var webColumnID = Request["webColumnId"] ?? "";
            if (string.IsNullOrEmpty(webColumnID))
            {
                model.WebColumn = null;
            }
            else
            {
                model.WebColumn = columnBll.FindById(Convert.ToInt32(webColumnID));
            }
            //判断是否存在
            //存在复制更新
            if (bll.IsExist(model.Id))
            {
                model.CreateDate = DateTime.Now;
                model.CreateUser = "";
                bll.Update(model);
            }
            //不存在插入新数据
            else
            {
                model.CreateDate = DateTime.Now;
                model.CreateUser = "";
                bll.Add(model);
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// 删除方法
        /// </summary>
        /// <returns></returns>
        private ActionResult Delete()
        {
            return View();
        }
    }
}