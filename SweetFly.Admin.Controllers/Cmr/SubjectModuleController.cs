using System.Web.Mvc;
using SweetFly.BusinessLogic.contract.Cmr.cn;
using SweetFly.Infrastructure;
using SweetFly.Model.Entities.Cmr.cn;

namespace SweetFly.Admin.Controllers.Cmr
{
    /// <summary>
    /// 课目下模块管理
    /// </summary>
    public class SubjectModuleController : AdminBaseController
    {
        public ISubjectModuleService SubjectModuleService { get; set; }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PageList(int page, int pageSize)
        {
            int total;
            var list = SubjectModuleService.PageList(page, pageSize, out total);

            var result = new { Rows = list, Total = total };

            return Json(result);
        }

        public ActionResult Insert()
        {
            return PartialView("_Insert");
        }

        [HttpPost]
        public ActionResult Insert(SubjectModule model)
        {
            var result = SubjectModuleService.Insert(model);

            return Json(result);
        }

        public ActionResult Update(SubjectModule model)
        {
            var result = SubjectModuleService.Update(model);

            return Json(result);
        }

        public ActionResult Remove(int id)
        {
            var result = SubjectModuleService.Remove(id);

            return Json(result);
        }
    }
}
