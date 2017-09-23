using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSiteDAL
{
    public class DbSession
    {
        /// <summary>
        /// 获取DBContent
        /// </summary>
        public static DataContext DbContent
        {
            get
            {
                return DBContextFactory.GetCurrentContext();
            }
        }
        /// <summary>
        /// 用于业务层统一保存
        /// </summary>
        /// <returns></returns>
        public static int SaveChange()
        {
            return DbContent.SaveChanges();
        }

        /// <summary>
        /// 开启一个事务
        /// </summary>
        /// <returns></returns>
        public static DbContextTransaction BeginTransaction()
        {
            return DbContent.Database.BeginTransaction();
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
