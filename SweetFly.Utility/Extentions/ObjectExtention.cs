using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Extentions
{
    public static class ObjectExtention
    {
        /// <summary>
        /// 遍历对象的公有属性，生成字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="split"></param>
        /// <returns></returns>
        public static string GetFeildString(this object obj, string split = "\r\n")
        {
            if (obj == null) { return string.Empty; }

            StringBuilder sbInfo = new StringBuilder();

            var props = obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (var propertyInfo in props)
            {
                sbInfo.AppendFormat("{0}:{1}", propertyInfo.Name, propertyInfo.GetValue(obj,null));
                sbInfo.Append(split);
            }


            return sbInfo.ToString(0, sbInfo.Length - split.Length);
        }
    }
}
