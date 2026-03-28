using CRUD_COREAPI.Interface;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CRUD_COREAPI.Service
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        public readonly IBaseRepository<T> _baserepo;
        public BaseService(IBaseRepository<T> baserepo)
        {
            this._baserepo = baserepo;
        }

        public int Create(T t)
        {
            _baserepo.Add(t);
            int result = _baserepo.SaveChanges();
            return result;
        }

        public void Delete(T t)
        {
            _baserepo.Delete(t);
            _baserepo.SaveChanges();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includes)
        {
            return _baserepo.Filter(predicate, includes);
        }

        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            return _baserepo.GetAll(includes);
        }

        public int Update(T t)
        {
            _baserepo.Update(t);
            int result = _baserepo.SaveChanges();
            return result;
        }
    }
}
