using System;
using System.Collections.Generic;
using System.Text;

namespace EFData.DAL.Interface
{
    internal interface IEntityDal<T>
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> Find(Expression<Func<T, bool>> where);
    }

}
