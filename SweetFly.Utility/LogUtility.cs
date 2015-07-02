using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SweetFly.Utility
{
    public class LogUtility
    {
        private static LogUtility _instance;
        
        #region 构造函数
        private LogUtility() { }
        public static LogUtility GetInstance()
        {
            return _instance;
        }
        #endregion

        #region 注册
        public static void Register()
        {
            log4net.Config.XmlConfigurator.Configure();
            _instance = new LogUtility();
        }

        public static void Register(string xmlPath)
        {
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo(xmlPath));
            _instance = new LogUtility();
        }
        #endregion

        public ILog GetLog(string name)
        {
            var logger = LogManager.GetLogger(name);
            return logger;
        }
    }


}
