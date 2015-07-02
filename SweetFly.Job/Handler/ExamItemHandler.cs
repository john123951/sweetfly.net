using log4net;
using SweetFly.Job.JobItems;
using SweetFly.Model.Entities.Cmr.cn;
using SweetFly.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SweetFly.Job.Handler
{
    public abstract class ExamItemHandler
    {
        public abstract IList<ExamItem> Process(string strResponse, int moduleId);

        protected ILog logger = LogUtility.GetInstance().GetLog(typeof(CmrcnCrawlerJob).Name);

        protected void WriteLog(string strResponse, string msg)
        {
            string dirName = Path.Combine(typeof(CmrcnCrawlerJob).Name, this.GetType().Name);
            string fileName = Path.Combine(dirName, Guid.NewGuid().ToString() + ".htm");

            if (false == Directory.Exists(dirName))
            {
                Directory.CreateDirectory(dirName);
            }
            File.WriteAllText(fileName, strResponse);

            var sbLog = new StringBuilder();
            sbLog.AppendFormat("注意：未完全解析，{0}", msg);
            sbLog.AppendLine();
            sbLog.AppendFormat("文件已保存至：" + fileName);

            logger.Info(sbLog.ToString());
        }
    }
}
