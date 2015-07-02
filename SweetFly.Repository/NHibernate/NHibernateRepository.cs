using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using NHibernate;
using NHibernate.Linq;
using SweetFly.Repository.contract;
using System.Diagnostics;

namespace SweetFly.Repository.NHibernate
{
    public abstract class NHibernateRepository<T> : INHibernateRepository<T> where T : class
    {
        protected string _sessionFactoryName;

        public NHibernateRepository(string factoryName)
        {
            this._sessionFactoryName = factoryName;
        }

        public ISession OpenSession()
        {
            var session = NSessionFactoryManager.GetInstance(_sessionFactoryName).OpenSession();

            return session;
        }

        public int ExecuteNonQuery(string sqlCommand)
        {
            using (var session = this.OpenSession())
            {
                var command = session.Connection.CreateCommand();

                command.CommandText = sqlCommand;

                int result =command.ExecuteNonQuery();
                return result;
            }
        }
        public IQuery SqlIQuery(string queryString)
        {
            var query = this.OpenSession().CreateSQLQuery(queryString);
            return query;
        }

        public T Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            using (var session = OpenSession())
            {
                Trace.WriteLine(session.GetHashCode());

                session.Save(entity);
                session.Flush();
            }

            return entity;
        }
        public int InsertTransaction(IEnumerable<T> entityList)
        {
            int result = 0;

            if (entityList == null)
            {
                return 0;
            }

            using (var session = OpenSession())
            {
                using (var trans = session.BeginTransaction())
                {
                    foreach (var item in entityList)
                    {
                        session.Save(item);
                        ++result;
                    }
                    trans.Commit();
                }
            }
            return result;
        }

        public bool Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            using (var session = OpenSession())
            {
                session.Update(entity);
                session.Flush();
                return true;
            }
        }
        public int UpdateTransaction(IEnumerable<T> entityList)
        {
            int result = 0;

            if (entityList == null)
            {
                return 0;
            }

            using (var session = OpenSession())
            {
                using (var trans = session.BeginTransaction())
                {
                    foreach (var item in entityList)
                    {
                        session.Update(item);
                        ++result;
                    }
                    trans.Commit();
                }
            }
            return result;
        }

        public bool SaveOrUpdate(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            using (var session = OpenSession())
            {
                session.SaveOrUpdate(entity);
                session.Flush();
                return true;
            }
        }
        public int SaveOrUpdateTransaction(IEnumerable<T> entityList)
        {
            int result = 0;

            if (entityList == null)
            {
                return 0;
            }

            using (var session = OpenSession())
            {
                using (var trans = session.BeginTransaction())
                {
                    foreach (var item in entityList)
                    {
                        session.SaveOrUpdate(item);
                        ++result;
                    }
                    trans.Commit();
                }
            }
            return result;
        }

        public bool Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            using (var session = OpenSession())
            {
                session.Delete(entity);
                session.Flush();
                return true;
            }
        }
        public int RemoveTransaction(IEnumerable<T> entityList)
        {
            int result = 0;

            if (entityList == null)
            {
                return 0;
            }

            using (var session = OpenSession())
            {
                using (var trans = session.BeginTransaction())
                {
                    foreach (var item in entityList)
                    {
                        session.Delete(item);
                        ++result;
                    }
                    trans.Commit();
                }
            }
            return result;
        }

        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda)
        {
            var session = OpenSession();
            var result = session.Query<T>().Where(whereLambda);

            return result;
        }

        public IQueryable<T> LoadPageEntities<TS>(int pageIndex, int pageSize, out int totalCount,
                                                                                Expression<Func<T, bool>> whereLambda,
                                                                                Expression<Func<T, TS>> orderLambda,
                                                                                bool isAsc = true)
        {
            var session = OpenSession();
            IQueryable<T> linq = session.Query<T>().Where(whereLambda).AsQueryable();

            totalCount = linq.Count();

            linq = isAsc ? linq.OrderBy(orderLambda) : linq.OrderByDescending(orderLambda);
            linq = linq.Skip(pageSize * (pageIndex - 1)).Take(pageSize);

            return linq;

        }


    }
}
