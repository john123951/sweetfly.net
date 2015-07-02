using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SweetFly.BusinessLogic.Implementations
{
    /// <summary>
    /// 支持逻辑删除
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseSoftDeleteable<T>
    {
        protected abstract IQueryable<T> Search();
        protected abstract bool Remove(T entity);
    }
}
