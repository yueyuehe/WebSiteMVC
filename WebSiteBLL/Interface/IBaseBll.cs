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
    }
}
