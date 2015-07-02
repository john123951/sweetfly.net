using SweetFly.Repository.contract;
using SweetFly.Repository.NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SweetFly.Repository
{
    public class SweetFlyRepository<TEntity> : NHibernateRepository<TEntity>, ISweetFlyRepository<TEntity>
        where TEntity : class
    {
        public SweetFlyRepository()
            : base(NSessionFactoryManager.SessionFactory.SweetFly)
        {
            
        }
    }
}
