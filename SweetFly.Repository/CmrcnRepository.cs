using SweetFly.Repository.contract;
using SweetFly.Repository.NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SweetFly.Repository
{
    public class CmrcnRepository<TEntity> : NHibernateRepository<TEntity>, ICmrcnRepository<TEntity>
        where TEntity : class
    {
        public CmrcnRepository()
            : base(NSessionFactoryManager.SessionFactory.Cmrcn)
        {
        }
    }
}
