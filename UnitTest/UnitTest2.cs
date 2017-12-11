using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using EntityData.Implement;
using EntityData.Interface;
using EntityData.Extend;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using EntityData;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class UnitTest2
    {
        /// <summary>
        /// 测试  通用类
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            IEntityContext<User> context = new EntityContext<User, DataContext>();
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add("@id", 1);
            var db = context.QueryList<User>("select * from Users where ID =@id ", list);
            var table =  db.ToDataTable();


            var s = "";
            //User user = new User();
            //user.UserName = "李四";
            //user.Sex = "男";
            //user.Update();
            //
            //user.Select<User, DataContext>();
            //user.Insert();
            //context.Add(user);
            //context.CreateTransaction();
            //DbSession<DataContext>.SaveChange();
        }

        public void TestAttrabute()
        {
            var type = typeof(User);
            var key = type.GetCustomAttribute(typeof(KeyAttribute));

            string s = "";


        }


    }




    public class User : DataEntity<DataContext>
    {

        [Key]
        public int id { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public string Title2 { get; set; }
        public string Title3 { get; set; }
        public string Title4 { get; set; }
        public string Title5 { get; set; }

        public decimal Title6 { get; set; }

        public DateTime? Title7 { get; set; }

        public User parent { get; set; }
    }


    public class DataContext : DbContext
    {
        public DataContext() : base("name=Test")
        {

        }

        public virtual DbSet<User> User { get; set; }
    }
}
