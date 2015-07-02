using log4net;
using Quartz;
using SweetFly.BusinessLogic.contract.Cmr.cn;
using SweetFly.Job.Configs;
using SweetFly.Job.Managers;
using SweetFly.Utility;
using System;
using System.Threading;

namespace SweetFly.Job.JobItems
{
    /// <summary>
    /// 抓取人大作业的答案
    /// </summary>
    public class CmrcnCrawlerJob : IJob
    {
        private readonly ILog _logger = LogUtility.GetInstance().GetLog(typeof(CmrcnCrawlerJob).Name);
        private readonly IExamItemService _examItemService = WindsorUtility.Instance.Resolve<IExamItemService>();

        public void Execute(IJobExecutionContext context)
        {
            _logger.Info("===== CmrcnCrawlerJob 任务开始 =====");

            try
            {
                var config = CmrConfig.GetInstance();

                config.Subjects.Reverse();
                foreach (var subject in config.Subjects)
                {
                    var manager = new ExamManager(subject.LoginInfo);

                    if (false == subject.Enabled) { continue; }

                    int totalExam = 0;
                    foreach (var module in subject.SubjectModules)
                    {
                        totalExam += manager.GetExam(module);
                        Thread.Sleep(1000);
                    }

                    _logger.Info(string.Format("正常完成。SubjcetId:[{0}]-Total:[{1}]", subject.Id, totalExam));
                }
            }
            catch (Exception ex)
            {
                _logger.Error("异常停止", ex);
            }

            _logger.Info(string.Format("===== 目前题库共有 {0} 道题目 =====", _examItemService.Count()));
            _logger.Info("===== CmrcnCrawlerJob 任务结束 =====");
        }
    }
}