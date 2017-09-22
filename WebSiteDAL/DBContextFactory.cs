using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace WebSiteDAL
{

    public class DBContextFactory
    {
        //public static DbContext Create()
        //{
        //    //DbContext dbContext = CallContext.GetData("DbContext") as DbContext;
        //    //if (dbContext == null)
        //    //{
        //    //    dbContext = new DataContext();
        //    //    CallContext.SetData("DbContext", dbContext);
        //    //}
        //    //return dbContext;
        //}


        /// <summary>
        /// 创建DataContext 获取的是当前请求的DataContext
        /// </summary>
        /// <returns></returns>
        public static DbContext getCurrentContext()
        {
            DbContext dbContext = CallContext.GetData("DbContext") as DataContext;
            if (dbContext == null)
            {
                dbContext = new DataContext();
                CallContext.SetData("DbContext", dbContext);
            }
            return dbContext;
        }
    }
}
