namespace WebSiteDAL
{
    using System;
    using System.Collections;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;
    using System.Runtime.Remoting.Messaging;
    using WebSiteEntity;
    using WebSiteEntity.Module;

    public class DataContext : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“DataContext”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“WebSiteDAL.DataContext”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“DataContext”
        //连接字符串。

        private DbModelBuilder modelBuilder = new DbModelBuilder();

        public DataContext() : base("name=WebSite")
        {

        }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Conventions.Add<OneToManyCascadeDeleteConvention>();
        //}


        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<WebSite> WebSite { get; set; }
        public virtual DbSet<WebColumn> WebColumn { get; set; }
        //  public virtual DbSet<WebModule> WebModule { get; set; }

         public virtual DbSet<Article> Article { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}