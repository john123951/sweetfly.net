using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SweetFly.Infrastructure;
using System.Web.Mvc;

namespace SweetFly.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public ActionResult Index()
        {
            return Content("AdminHome");
        }
    }
}
