using System.Web.Mvc;
using SweetFly.BusinessLogic.contract.Cmr.cn;
using SweetFly.Infrastructure;

namespace SweetFly.Admin.Controllers.Cmr
{
    /// <summary>
    /// 人大用户查看
    /// </summary>
    public class CmrUserController : AdminBaseController
    {
        public ICmrUserService CmrUserService { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PageList(int page, int pageSize)
        {
            int total;
            var list = CmrUserService.PageList(page, pageSize, out total);
            list.ForEach(x => x.Password = new string('*', x.Password.Length));

            var result = new { Rows = list, Total = total };

            return Json(result);
        }
    }
}
