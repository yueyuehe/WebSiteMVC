using Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteBLL.Implements;
using WebSiteBLL.Interface;
using WebSiteEntity;

namespace WebSiteManage.Controllers
{
    public class WebSiteController : Controller
    {
        private IWebSiteBll bll = new WebSiteBll();
        // GET: WebSite
        public ActionResult Index(int id = 0)
        {
            var webSite = bll.FindById(Convert.ToInt32(id));
            return View(webSite);
        }

        /// <summary>
        /// 不验证，可输入特殊字符串
        /// </summary>
        /// <param name="webSite"></param>
        /// <returns></returns>
        [ValidateInput(false)]
        public ActionResult AddOrUpdate(WebSite webSite)
        {
            webSite.CreateDate = DateTime.Now;
            //保存文件到项目
            HttpPostedFileBase webLogFile = Request.Files["WebLogo"] as HttpPostedFileBase;
            HttpPostedFileBase webIconFile = Request.Files["WebIcon"] as HttpPostedFileBase;
            //保存网站logo
            var logoPath = this.SaveFile(webLogFile, Common.CommonFilePath.WebLogoImagePath);
            if (!string.IsNullOrEmpty(logoPath))
            {
                webSite.Logo = logoPath;
            }
            //保存IconUrl
            var IconPath = this.SaveFile(webIconFile, Common.CommonFilePath.WebLogoImagePath);
            if (!string.IsNullOrEmpty(IconPath))
            {
                webSite.Icon = IconPath;
            }
            if (bll.IsExist(webSite.Id))
            {
                bll.Update(webSite);
            }
            else
            {
                bll.Add(webSite);
            }
            return RedirectToAction("Index/" + webSite.Id);
        }

        /// <summary>
        /// 返回文件相对路径
        /// </summary>
        /// <param name="file">文件</param>
        /// <param name="path">相对路径下的目录</param>
        /// <returns></returns>
        [NonAction]
        private string SaveFile(HttpPostedFileBase file, string path)
        {
            if (file != null && file.ContentLength > 0)
            {
                var servicePath = Server.MapPath("~/");
                //新文件名名称
                var newFileName = DateTime.Now.ToString("yyyyMMddHHmmss") + file.FileName.Substring(file.FileName.IndexOf('.'));
                //磁盘路径
                var directory = Path.Combine(servicePath, path);
                //判断磁盘路径是否存在
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                var fullPath = Path.Combine(directory, newFileName);
                //保存
                file.SaveAs(fullPath);
                return fullPath.Replace(servicePath, @"~\");
            }
            return null;
        }

        /// <summary>
        /// 删除指定ID的网站
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            bll.Delete(id);
            return View();
        }
    }
}