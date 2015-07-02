using SweetFly.BusinessLogic.contract.Cmr.cn;
using SweetFly.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace SweetFly.Controllers
{
    public class CmrController : BaseController
    {
        public ISubjectService SubjectService { get; set; }
        public ISubjectModuleService SubjectModuleService { get; set; }
        public IExamItemService ExamItemService { get; set; }

        public ActionResult Index()
        {
            string msg = string.Format("当前题库共有{0}道题目。", ExamItemService.Count().ToString("#,###"));

            return Content(msg);
        }

    }
}
