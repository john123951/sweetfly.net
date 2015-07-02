using SweetFly.Infrastructure;
using SweetFly.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace SweetFly.Controllers
{
#if DEBUG
    public class TestController : BaseController
    {
        public ActionResult GetCache(string key)
        {
            var model = CacheUtility.Get(key);
            if (model == null)
            {
                return Content("Null");
            }
            return Content(model.ToString());
        }

        public ActionResult SetCache(string key)
        {
            CacheUtility.Set(key, DateTime.Now);

            return Content(DateTime.Now.ToString());
        }
    }
#endif
}
