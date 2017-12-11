using EntityData.Implement;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityData.Interface
{
    /// <summary>
    /// 实体类的基类 ，所有的实体类都需要继承该类
    /// </summary>
    public interface IDataEntity
    {
    }
    public class DataEntity : IDataEntity
    {

    }

    public interface IDataEntity<T> : IDataEntity where T : DbContext, new()
    {
      T  GetDbContext();

    }
    public class DataEntity<T> : IDataEntity<T> where T : DbContext, new()
    {
        public T GetDbContext()
        {
            return DbSession<T>.DbContext;
        }
    }
}
