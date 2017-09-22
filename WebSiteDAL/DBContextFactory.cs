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
        /// <summary>
        /// 创建DataContext 获取的是当前请求的DataContext
        /// </summary>
        /// <returns></returns>
        public static DataContext GetCurrentContext()
        {
            DataContext dbContext = CallContext.GetData(typeof(DataContext).FullName) as DataContext;
            if (dbContext == null)
            {
                dbContext = new DataContext();
                CallContext.SetData(typeof(DataContext).FullName, dbContext);
            }
            return dbContext;
        }
    }
}
