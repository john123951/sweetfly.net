using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SweetFly.Repository.NHibernate
{
    public interface INHibernateRepository<T> where T : class
    {
        T Insert(T entity);

        bool Update(T entity);

        bool SaveOrUpdate(T entity);

        bool Remove(T entity);


        int InsertTransaction(IEnumerable<T> entityList);

        int UpdateTransaction(IEnumerable<T> entityList);

        int SaveOrUpdateTransaction(IEnumerable<T> entityList);

        int RemoveTransaction(IEnumerable<T> entityList);

        IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda);

        IQueryable<T> LoadPageEntities<S>(int pageIndex, int pageSize, out int totalCount,
                                            Expression<Func<T, bool>> whereLambda,
                                            Expression<Func<T, S>> orderLambda, bool isAsc = true);

    }
}
