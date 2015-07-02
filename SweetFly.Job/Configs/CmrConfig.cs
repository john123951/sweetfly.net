using SweetFly.Job.Models.Cmr;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SweetFly.Job.Configs
{
    /// <summary>
    /// 人大计划任务的配置类
    /// </summary>
    [Serializable]
    public class CmrConfig
    {
        #region 公有属性
        /// <summary>
        /// 所有科目
        /// </summary>
        public List<Subject> Subjects { get; set; }
        #endregion

        #region 构造函数
        static CmrConfig _instance;
        private CmrConfig() { }
        public static CmrConfig GetInstance()
        {
            //请先调用注册Register()方法
            return _instance;
        }
        #endregion

        #region 静态方法
        public static void Register(string filePath)
        {
            var xs = new XmlSerializer(typeof(CmrConfig));
            using (var fsRead = File.OpenRead(filePath))
            {
                _instance = xs.Deserialize(fsRead) as CmrConfig;
            }
        }
        #endregion
    }
}
