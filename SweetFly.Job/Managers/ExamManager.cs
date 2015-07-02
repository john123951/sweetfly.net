using log4net;
using SweetFly.BusinessLogic.contract.Cmr.cn;
using SweetFly.Job.Handler;
using SweetFly.Job.JobItems;
using SweetFly.Job.Models.Cmr;
using SweetFly.Utility;
using System;
using System.Data;
using System.Text;

namespace SweetFly.Job.Managers
{
    public class ExamManager
    {
        public readonly IExamItemService ExamItemService = WindsorUtility.Instance.Resolve<IExamItemService>();

        public LoginInfo LoginInfo { get; set; }

        private readonly ILog _logger = LogUtility.GetInstance().GetLog(typeof(CmrcnCrawlerJob).Name);

        #region 构造函数

        public ExamManager(LoginInfo loginInfo)
        {
            this.LoginInfo = loginInfo;
        }

        #endregion 构造函数

        /// <summary>
        /// 得到8道随机题目及答案
        /// </summary>
        public int GetExam(SubjectModule module)
        {
            if (LoginInfo == null)
            {
                throw new NoNullAllowedException("LoginInfo");
            }

            var encoding = Encoding.GetEncoding(module.HtmlDataSource.Encoding);

            //获取原始信息
            try
            {
                var strResponse = HttpUtility.Get(module.HtmlDataSource.Uri, encoding, x =>
                           {
                               x.Headers["Authorization"] = LoginInfo.Authorization;
                           });

                if (string.IsNullOrEmpty(strResponse)) { return 0; }

                ExamItemHandler handler = Activator.CreateInstance(module.HandlerType) as ExamItemHandler;
                var list = handler.Process(strResponse, module.Id);

                if (list == null || list.Count <= 0) { return 0; }

                //保存数据库
                return ExamItemService.SaveOrUpdate(list);
            }
            catch (Exception ex)
            {
                _logger.Error("异常", ex);
                return 0;
            }
        }
    }
}