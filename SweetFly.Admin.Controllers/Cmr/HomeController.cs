using System.Web.Mvc;
using SweetFly.Infrastructure;

namespace SweetFly.Admin.Controllers.Cmr
{
    /// <summary>
    /// 人大助手项目管理首页
    /// </summary>
    public class HomeController : AdminBaseController
    {
        public ActionResult Index()
        {
            return Content("Hello CmrAdmin");
        }

        public ActionResult Insert()
        {
            return View();
        }
    }
}
