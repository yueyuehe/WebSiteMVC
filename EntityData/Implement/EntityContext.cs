using EntityData.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EntityData.Implement
{
    public class EntityContext<T, F> : IEntityContext<T> where T : class, IDataEntity<F>, new() where F : DbContext, new()
    {

        public void Add(T entity)
        {
            GetDbContext().Set<T>().Add(entity);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(T entity)
        {
            //将对象添加到EF管理容器中 ObjectStateManager
            GetDbContext().Set<T>().Attach(entity);
            GetDbContext().Set<T>().Remove(entity);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            GetDbContext().Set<T>().Attach(entity);
            GetDbContext().Entry(entity).State = EntityState.Modified;
        }
        /// <summary>
        /// 按条件查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IQueryable<T> Find(Expression<Func<T, bool>> where)
        {
            return GetDbContext().Set<T>().Where(where);
        }

        /// <summary>
        /// 获取DbContext
        /// </summary>
        /// <returns></returns>
        public DbContext GetDbContext()
        {
            return DbSession<F>.DbContext;
        }
    }
}
