using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebSiteDAL;
using WebSiteEntity;
using System.Collections.Generic;
using WebSiteBLL.Implements;

namespace UnitTest
{
    [TestClass]
    public class EFTest
    {
        [TestMethod]
        public void TestInit()
        {
            var context = DBContextFactory.GetCurrentContext();
            var webColumn = new WebColumn();
            webColumn.Name = "测试测试栏目11123123";

            var webSite = new WebSite();
            webSite.Name = "测试网站33123123";

            var webModule = new WebModule();
            //webModule.Name = "测试模块22";
            context.WebColumn.Add(webColumn);
            context.WebSite.Add(webSite);
          //  context.WebModule.Add(webModule);
            context.SaveChanges();
        }
        [TestMethod]
        public void TestUpdate()
        {
            var context = DBContextFactory.GetCurrentContext();

            WebSiteBll bll = new WebSiteBll();
            var model = bll.FindById(5);
            model.Name = "我的CXXXXSSSSSSS";
            bll.Update(model);
            var db2 = DbSession.DbContent;
            int count = db2.SaveChanges();
            string sq = "";
        }
    }
    public enum A
    {
        name,
        age
    }
}
