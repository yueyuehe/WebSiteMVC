using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebSiteDAL;
using WebSiteEntity;

namespace UnitTest
{
    [TestClass]
    public class EFTest
    {
        [TestMethod]
        public void TestInit()
        {
            DataContext context = new DataContext();
           var tra = context.Database.BeginTransaction();
            var webColumn = new WebColumn();
            webColumn.Name = "测试测试栏目1";
            var webSite = new WebSite();
            webSite.Name = "测试网站3";


            var webModule = new WebModule();
            webModule.Name = "测试模块2";
            context.WebColumn.Add(webColumn);
            context.WebSite.Add(webSite);
            context.WebModule.Add(webModule);
            context.SaveChanges();
            tra.Commit();
        }
    }
}
