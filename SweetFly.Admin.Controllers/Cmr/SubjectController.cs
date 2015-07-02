using System.Web.Mvc;
using SweetFly.BusinessLogic.contract.Cmr.cn;
using SweetFly.Infrastructure;
using SweetFly.Model.Entities.Cmr.cn;

namespace SweetFly.Admin.Controllers.Cmr
{
    /// <summary>
    /// 课目管理
    /// </summary>
    public class SubjectController : AdminBaseController
    {
        public ISubjectService SubjectService { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PageList(int page, int pageSize)
        {
            int total;
            var list = SubjectService.PageList(page, pageSize, out total);

            var result = new { Rows = list, Total = total };

            return Json(result);
        }

        public ActionResult Insert()
        {
            return PartialView("_Insert");
        }

        [HttpPost]
        public ActionResult Insert(Subject model)
        {
            var result = SubjectService.Insert(model);

            return Json(result);
        }

        public ActionResult Update(Subject model)
        {
            var result = SubjectService.Update(model);

            return Json(result);
        }

        public ActionResult Remove(int id)
        {
            var result = SubjectService.Remove(id);

            return Json(result);
        }
    }
}
