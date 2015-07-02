using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using NHibernate.Mapping.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Web;

namespace SweetFly.Repository.NHibernate
{
    public sealed class NSessionFactoryManager
    {
        /// <summary>
        /// 数据库名
        /// </summary>
        public class SessionFactory
        {
            public static readonly string SweetFly = typeof(SweetFlyRepository<>).Name;
            public static readonly string Cmrcn = typeof(CmrcnRepository<>).Name;
        }

        #region 构造函数

        private NSessionFactoryManager()
        {
        }

        public static NSessionFactoryManager GetInstance(string dbName)
        {
            if (!_dictInstance.ContainsKey(dbName))
            {
                _dictInstance[dbName] = new NSessionFactoryManager();
            }
            return _dictInstance[dbName];
        }

        #endregion 构造函数

        #region 私有成员

        /// <summary>
        /// 数据库
        /// </summary>
        private ISessionFactory _sessionFactory;

        private const string CurrentSessionKey = "nhibernate.current_session";

        private static Dictionary<string, NSessionFactoryManager> _dictInstance = new Dictionary<string, NSessionFactoryManager>();

        #endregion 私有成员

        #region 静态方法

        /// <summary>
        /// 使用默认的配置文件注册（默认文件名：hibernate.cfg.xml）
        /// </summary>
        public void Register()
        {
            _sessionFactory = new Configuration().Configure().BuildSessionFactory();
        }

        /// <summary>
        /// 使用默认的配置文件注册（默认文件名：hibernate.cfg.xml）
        /// </summary>
        /// <param name="asm">带有映射关系Attribute的程序集</param>
        public void Register(Assembly asm)
        {
            var cfg = new Configuration();
            cfg.Configure();
            HbmSerializer.Default.Validate = true; // Enable validation (optional)
            // Here, we serialize all decorated classes (but you can also do it class by class)
            cfg.AddInputStream(
                HbmSerializer.Default.Serialize(asm));
            // Now you can use this configuration to build your SessionFactory...
            _sessionFactory = cfg.BuildSessionFactory();
        }

        /// <summary>
        /// 使用默认的配置文件注册
        /// </summary>
        /// <param name="fileName">文件位置</param>
        public void Register(string fileName)
        {
            _sessionFactory = new Configuration().Configure(fileName).BuildSessionFactory();
        }

        /// <summary>
        /// 使用默认的配置文件注册
        /// </summary>
        /// <param name="fileName">文件位置</param>
        /// <param name="asm">带有映射关系Attribute的程序集</param>
        public void Register(string fileName, Assembly asm)
        {
            var cfg = new Configuration();
            cfg.Configure(fileName);
            HbmSerializer.Default.Validate = true; // Enable validation (optional)
            // Here, we serialize all decorated classes (but you can also do it class by class)
            cfg.AddInputStream(
                HbmSerializer.Default.Serialize(asm));
            // Assembly.GetExecutingAssembly()
            // Now you can use this configuration to build your SessionFactory...
            _sessionFactory = cfg.BuildSessionFactory();
        }

        public void CloseSessionFactory()
        {
            if (_sessionFactory != null)
            {
                _sessionFactory.Close();
            }
        }

        #endregion 静态方法

        #region 成员方法

        public ISession OpenSession()
        {
            var session = _sessionFactory.OpenSession();
            return session;
        }

        #region Web

        public ISession GetCurrentSession()
        {
            if (!CurrentSessionContext.HasBind(_sessionFactory)) CurrentSessionContext.Bind(_sessionFactory.OpenSession());
            var session = _sessionFactory.GetCurrentSession();   //需配置 current_session_context_class
            //Trace.WriteLine("SessionHashCode:" + session.GetHashCode());
            return session;
            //HttpContext context = HttpContext.Current;
            //ISession currentSession = context.Items[CurrentSessionKey] as ISession;

            //if (currentSession == null)
            //{
            //    currentSession = _sessionFactory.OpenSession();
            //    context.Items[CurrentSessionKey] = currentSession;
            //}

            //return currentSession;
        }

        public void CloseSession()
        {
            ISession currentSession = _sessionFactory.GetCurrentSession();

            if (currentSession == null)
            {
                // No current session
                return;
            }

            currentSession.Close();
        }

        #endregion Web

        #endregion 成员方法
    }
}