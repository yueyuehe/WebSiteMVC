using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebSiteBLL.Interface;
using WebSiteDAL.Implements;
using WebSiteDAL.Interface;

namespace WebSiteBLL.Implements
{
    public class BaseBll<T> : IBaseBll<T>
    {
        private IBaseDal<T> dal = new BaseDal<T>();
        public void Add(T entity)
        {
            dal.Add(entity);
        }

        public void Delete(T entity)
        {
            dal.Delete(entity);
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> where)
        {
            return dal.Find(where);
        }

        public void Update(T entity)
        {
            dal.Update(entity);
        }
    }
}
