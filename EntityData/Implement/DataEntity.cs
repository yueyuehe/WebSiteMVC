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
    /// 泛型接口类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DataEntity<T> : IDataEntity<T> where T : DbContext, new()
    {
        public T GetDbContext()
        {
            return DbSession<T>.DbContext;
        }
    }
    /// <summary>
    /// 实现
    /// </summary>
    public class DataEntity : IDataEntity
    {
      
    }
}
