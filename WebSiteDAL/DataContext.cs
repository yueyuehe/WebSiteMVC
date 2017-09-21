﻿namespace WebSiteDAL
{
    using System;
    using System.Collections;
    using System.Data.Entity;
    using System.Linq;
    using System.Runtime.Remoting.Messaging;
    using WebSiteEntity;

    public class DataContext : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“DataContext”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“WebSiteDAL.DataContext”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“DataContext”
        //连接字符串。
        public DataContext(): base("name=WebSite")
        {
        }

        /// <summary>
        /// 创建DataContext 获取的是当前请求的DataContext
        /// </summary>
        /// <returns></returns>
        public static DataContext Create()
        {
            DataContext dbContext = CallContext.GetData("DbContext") as DataContext;
            if (dbContext == null)
            {
                dbContext = new DataContext();
                CallContext.SetData("DbContext", dbContext);
            }
            return dbContext;
        }

   
        /// <summary>
        /// 事务问题以后解决
        /// </summary>

        //为您要在模型中包含的每种实体类型都添加 DbSet。有关配置和使用 Code First  模型
        //的详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=390109。

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<WebSite> WebSite{ get; set; }
        public virtual DbSet<WebColumn> WebColumn { get; set; }
        public virtual DbSet<WebModule> WebModule { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}