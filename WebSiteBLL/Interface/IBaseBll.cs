using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebSiteBLL.Interface
{
    public interface IBaseBll<T>
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(T Entity);

        IQueryable<T> Find(Expression<Func<T, bool>> where);

        /*********子类共有的常用方法但又不能通过公共方法实现************/
        /// <summary>
        /// 判断该Id的对象是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool IsExist(int id);

        /// <summary>
        /// 根据ID删除
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);

        /// <summary>
        /// 根据ID查找
        /// </summary>
        /// <param name="id"></param>
        T FindById(int id);
    }
}
