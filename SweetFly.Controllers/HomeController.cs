using SweetFly.BusinessLogic.contract;
using SweetFly.Infrastructure;
using SweetFly.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace SweetFly.Controllers
{
    /// <summary>
    /// 主页控制器
    /// </summary>
    public class HomeController : BaseController
    {
        public IProductService ProductService { get; set; }

        public ActionResult Index()
        {
            return View();
        }
    }
}
