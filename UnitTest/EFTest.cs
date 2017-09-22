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
           var  context = DBContextFactory.getCurrentContext();
            var tra = context.Database.BeginTransaction();
            var webColumn = new WebColumn();
            webColumn.Name = "测试测试栏目11";
            var webSite = new WebSite();
            webSite.Name = "测试网站33";


            var webModule = new WebModule();
            webModule.Name = "测试模块22";
            context.WebColumn.Add(webColumn);
            context.WebSite.Add(webSite);
            context.WebModule.Add(webModule);
            context.SaveChanges();
            tra.Commit();
        }
        [TestMethod]
        public void testStatic()
        {
            A.name = "12";
            var a1 = new A();

            var a2 = new A();




        }


    }
    public class A
    {
        public static string name { get; set; }

    }

}
