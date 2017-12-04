using System;
using System.Collections.Generic;
using System.Text;

namespace EFData.DAL.Implements
{
    internal class EntityDal<T> : IEntityDal<T> where T : class, new()
    {
        private DbContext context = DBContextFactory.GetCurrentContext();
        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }


        public void Delete(T entity)
        {
            //将对象添加到EF管理容器中 ObjectStateManager
            context.Set<T>().Attach(entity);
            context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            context.Set<T>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
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
