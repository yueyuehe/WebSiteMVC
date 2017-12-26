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
   
    /// <summary>
    /// 泛型实体类接口
    /// </summary>
    /// <typeparam name="T">DbContext类型</typeparam>
    public interface IDataEntity<T> : IDataEntity where T : DbContext, new()
    {
      T  GetDbContext();
    }
  
}
