using System.Collections.Generic;
using System.Linq.Expressions;
using System;

namespace CRUD_COREAPI.Interface
{

    public interface IBaseRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes);
        IEnumerable<T> Filter(Expression<Func<T, bool>> predi, params Expression<Func<T, object>>[] includes);
        int SaveChanges();
    }
}
