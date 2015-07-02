using System;
using System.ComponentModel;

namespace SweetFly.Utility.Extentions
{
    /// <summary>
    /// 枚举类型扩展方法类
    /// </summary>
    public static class EnumExtention
    {
        /// <summary>
        /// 获取枚举值的详细文本[Description]
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static string GetDescription(this System.Enum target)
        {
            Type t = target.GetType();
            //获取字段信息
            System.Reflection.FieldInfo[] fieldInfos = t.GetFields();
            foreach (System.Reflection.FieldInfo info in fieldInfos)
            {
                //判断名称是否相等
                if (info.Name != target.ToString()) continue;

                #region 4.5
                ////反射出自定义属性
                //var dscript = info.GetCustomAttribute<DescriptionAttribute>(true);
                ////类型转换找到一个Description，用Description作为成员名称
                //if (dscript != null)
                //    return dscript.Description; 
                #endregion

                #region 3.5
                //反射出自定义属性
                foreach (Attribute attr in info.GetCustomAttributes(true))
                {
                    //类型转换找到一个Description，用Description作为成员名称
                    var dscript = attr as DescriptionAttribute;
                    if (dscript != null)
                        return dscript.Description;
                }
                #endregion
            }

            //如果没有检测到合适的注释，则用默认名称
            return target.ToString();
        }

    }
}
