using SweetFly.Repository.NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SweetFly.Repository.contract
{
    public interface ICmrcnRepository<T> : INHibernateRepository<T> where T : class
    {
    }
}
