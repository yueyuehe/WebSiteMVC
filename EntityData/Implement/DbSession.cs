using EntityData.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityData.Implement
{
    /// <summary>
    /// DbContext上下文本管理类
    /// 管理多个DbContext,(主要是针对可能数据库不止一个或者可能分DbContext) 这部分功能未实现
    /// 事务的管理(现只实现了单个DbContext的事务管理,因为每一个DbContext的数据库连接对象不是同一个对象)
    /// （后期实现）
    /// （可以抽象出一个相关的工厂类创建DbSession）
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DbSession<T>  where T : DbContext, new()
    {
        /// <summary>
        /// 获取DBContent
        /// 
        /// </summary>
        public static T DbContext
        {
            get
            {
                return DBContextFactory.GetCurrentContext<T>();
            }
        }
        
        /// <summary>
        /// 用于业务层统一保存
        /// </summary>
        /// <returns></returns>
        public static int SaveChange()
        {
            return DbContext.SaveChanges();
        }

        /// <summary>
        /// 开启一个事务
        /// </summary>
        /// <returns></returns>
        public static DbContextTransaction BeginTransaction()
        {
            return DbContext.Database.BeginTransaction();
        }

        /// <summary>
        /// 回滚一个事务
        /// </summary>
        /// <param name="transaction"></param>
        public static void Rollback(DbContextTransaction transaction)
        {
            transaction.Rollback();
        }

        /// <summary>
        /// 提交一个事务
        /// </summary>
        /// <param name="transaction"></param>
        public static void Commit(DbContextTransaction transaction)
        {
            transaction.Commit();
        }
    }
}
