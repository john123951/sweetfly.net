using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using System;
using System.Reflection;

namespace SweetFly.Utility
{
    public class WindsorUtility
    {
        #region 静态成员
        static WindsorUtility _instance;
        public static WindsorUtility Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new WindsorUtility();
                }
                return _instance;
            }
        }
        #endregion

        #region 构造函数
        private WindsorUtility() { }
        #endregion

        #region 实例成员
        private IWindsorContainer _container;
        public IWindsorContainer Container { get { return _container; } }
        #endregion

        #region 实例方法

        /// <summary>
        /// 使用AppConfig的设置注册组件
        /// </summary>
        public void RegisterAppConfig()
        {
            _container = new WindsorContainer();
            _container.Install(Configuration.FromAppConfig());
        }

        /// <summary>
        /// 扫描自身程序集并自动注册组件
        /// </summary>
        public void Register(Assembly asm)
        {
            _container = new WindsorContainer();
            _container.Install(FromAssembly.Instance(asm));
        }

        /// <summary>
        /// 使用XML文件注册组件 
        /// </summary>
        public void Register(string configFile = "config/castle.xml")
        {
            _container = new WindsorContainer();
            _container.Install(Configuration.FromXmlFile(configFile));
        }

        /// <summary>
        /// 注册一个组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TM"></typeparam>
        public void Register<T, TM>()
            where TM : T
            where T : class
        {
            if (Container == null) { throw new NullReferenceException("Container"); }

            Container.Register(Component.For<T>().ImplementedBy<TM>());
        }

        /// <summary>
        /// 获取一个组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Resolve<T>()
        {
            if (Container == null) { throw new NullReferenceException("Container"); }

            return Container.Resolve<T>();
        }

        #endregion

    }
}
