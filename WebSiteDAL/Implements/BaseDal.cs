using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebSiteDAL.Interface;

namespace WebSiteDAL.Implements
{
    public class BaseDal<T> : IBaseDal<T> where T :class,new()
    {
        private DataContext context = DBContextFactory.getCurrentContext();
        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }

      
        

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            context.Set<T>().Attach(entity);
        }
        /// <summary>
        /// 按条件查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IQueryable<T> Find(Expression<Func<T, bool>> where)
        {
            return context.Set<T>().Where(where);
        }

       
    }
}
