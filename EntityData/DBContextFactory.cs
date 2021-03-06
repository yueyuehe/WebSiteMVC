﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace EntityData
{
    public class DBContextFactory
    {
        /// <summary>
        /// 创建DataContext 获取的是当前请求的DataContext
        /// 目的:一次请求处理 只需要一个DbContext，防止多次产生DbContext产生性能消耗。
        /// </summary>
        /// <returns></returns>
        public static T GetCurrentContext<T>() where T : DbContext,new ()
        {
            T dbContext = (T)CallContext.GetData(typeof(T).FullName);
            if (dbContext == null)
            {
                dbContext = new T();
                CallContext.SetData(typeof(T).FullName, dbContext);
            }
            return dbContext;
        }
    }
}
