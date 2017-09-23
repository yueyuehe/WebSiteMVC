﻿using Common;
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
        public ActionResult Index(int id)
        {
            var webSite = bll.Find(model => model.Id == id);

            return View();
        }
   
        public ActionResult AddOrUpdate(WebSite webSite)
        {
            //保存文件到项目
            HttpPostedFileBase webLogFile = Request.Files["WebLogo"] as HttpPostedFileBase;
            HttpPostedFileBase webIconFile = Request.Files["WebIcon"] as HttpPostedFileBase;
            var servicePath = Server.MapPath("~/");
            //保存网站log
            var logoPath = this.SaveFile(webLogFile, Common.CommonFilePath.WebLogoImagePath);
            if (!string.IsNullOrEmpty(logoPath))
            {
                webSite.Logo = logoPath;
            }

            this.SaveFile(webIconFile, Common.CommonFilePath.WebIconImagePath);
            var IconPath = this.SaveFile(webLogFile, Common.CommonFilePath.WebLogoImagePath);
            if (!string.IsNullOrEmpty(IconPath))
            {
                webSite.Logo = IconPath;
            }
            if (bll.IsExist(webSite.Id))
            {
                bll.Update(webSite);
            }
            else
            {
                bll.Add(webSite);
            }

            return View("Index");
        }

        /// <summary>
        /// 返回相对路径
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
                //保存
                file.SaveAs(Path.Combine(directory, newFileName));
                return Path.Combine(path, newFileName);
            }
            return null;
        }


        public ActionResult Delete(int id)
        {
            bll.Delete(id);
            return View();
        }
    }
}