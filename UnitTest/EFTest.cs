using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebSiteDAL;
using WebSiteEntity;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class EFTest
    {
        [TestMethod]
        public void TestInit()
        {
           var  context = DBContextFactory.GetCurrentContext();
            var tra = context.Database.BeginTransaction();
            var webColumn = new WebColumn();
            webColumn.Name = "测试测试栏目11";

            var webSite = new WebSite();
            webSite.Name = "测试网站33";

            var webModule = new WebModule();
            //webModule.Name = "测试模块22";
            context.WebColumn.Add(webColumn);
            context.WebSite.Add(webSite);
            context.WebModule.Add(webModule);
            context.SaveChanges();
            tra.Commit();
        }
        [TestMethod]
        public void testStatic()
        {
          

     


        }


    }
    public enum A
    {
      name,
      age

    }

}
