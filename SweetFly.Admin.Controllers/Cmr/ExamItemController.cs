using System.Web.Mvc;
using SweetFly.BusinessLogic.contract.Cmr.cn;
using SweetFly.Infrastructure;

namespace SweetFly.Admin.Controllers.Cmr
{
    /// <summary>
    /// 习题管理
    /// </summary>
    public class ExamItemController : AdminBaseController
    {
        public IExamItemService ExamItemService { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PageList(int page, int pageSize)
        {
            int total;
            var list = ExamItemService.PageList(page, pageSize, out total);

            var result = new { Rows = list, Total = total };

            return Json(result);
        }

    }
}
