using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SweetFly.Job.Models.Cmr;

namespace SweetFly.ConsoleTest.CmrModel
{
    /// <summary>
    /// 人大计划任务的配置类
    /// </summary>
    [Serializable]
    public class CmrConfig
    {
        /// <summary>
        /// 所有科目
        /// </summary>
        public List<Subject> Subjects { get; set; }
    }
}
