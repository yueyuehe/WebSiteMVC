using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebSiteBLL.Interface;
using WebSiteDAL;
using WebSiteDAL.Implements;
using WebSiteDAL.Interface;

namespace WebSiteBLL.Implements
{
    public abstract class BaseBll<T> : IBaseBll<T> where T:class,new()
    {
        protected IBaseDal<T> dal = new BaseDal<T>();
        public void Add(T entity)
        {
            dal.Add(entity);
            DbSession.SaveChange();
        }

        public void Delete(T entity)
        {
            dal.Delete(entity);
            DbSession.SaveChange();
        }

        public abstract void Delete(int id);

        public IQueryable<T> Find(Expression<Func<T, bool>> where)
        {
            return dal.Find(where);
        }

        public abstract T FindById(int id);
        public abstract bool IsExist(int id);

        public void Update(T entity)
        {
            dal.Update(entity);
            DbSession.SaveChange();
        }
    }
}
