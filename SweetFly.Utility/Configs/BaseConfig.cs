using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SweetFly.Utility.Configs
{
    /// <summary>
    /// 操作Config文件的实体类
    /// </summary>
    public abstract class BaseConfig
    {
        public BaseConfig()
        {
            var type = this.GetType();
            var props = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (var item in props)
            {
                object defaultValue = null;
                if (item.PropertyType.IsValueType)
                {
                    defaultValue = 0;
                }

                string strValue = ConfigurationManager.AppSettings[item.Name];
#if DEBUG
                if (strValue == null) { throw new ConfigurationErrorsException("请检查AppSettings:" + item.Name); }
#endif
                try
                {
                    defaultValue = Convert.ChangeType(strValue, item.PropertyType);
                }
                catch (Exception ex)
                {
                }
                item.SetValue(this, defaultValue, null);
            }
        }

        public PropertyInfo[] GetProperties()
        {
            return this.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
        }
    }
}