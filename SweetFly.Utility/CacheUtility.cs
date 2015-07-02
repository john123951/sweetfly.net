using System;
using System.Web;
using System.Web.Caching;

namespace SweetFly.Utility
{
    /// <summary>
    /// 缓存通用类
    /// </summary>
    public static class CacheUtility
    {
        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="exp">超时时间</param>
        public static void Set(string key, object value, DateTime exp)
        {
            var timeSpan = exp - DateTime.Now;
            HttpContext.Current.Cache.Insert(key, value, null, Cache.NoAbsoluteExpiration, timeSpan);
        }

        /// <summary>
        /// 设置缓存，默认20分钟后超时
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public static void Set(string key, object value)
        {
            Set(key, value, DateTime.Now.AddMinutes(20));
        }

        /// <summary>
        /// 取出缓存
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        public static object Get(string key)
        {
            return HttpContext.Current.Cache.Get(key);
        }

        /// <summary>
        /// 取出缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        public static T Get<T>(string key)
        {
            var cached = HttpContext.Current.Cache.Get(key);
            if (cached is T)
            {
                return (T)cached;
            }
            return default(T);
        }
    }
}
