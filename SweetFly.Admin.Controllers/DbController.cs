using SweetFly.Infrastructure;
using SweetFly.Repository;
using SweetFly.Repository.NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace SweetFly.Admin.Controllers
{
    public class DbController : AdminBaseController
    {
        [HttpGet]
        public ActionResult Exec()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Exec(int dbName, string sql)
        {
            if (string.IsNullOrEmpty(sql)) { return Content("请输入正确的SQL语句"); }

            NHibernateRepository<string> sessionFactoryName = null;

            switch (dbName)
            {
                case 1:
                    sessionFactoryName = new CmrcnRepository<string>();
                    break;

                default:
                    break;
            }

            var result = sessionFactoryName.ExecuteNonQuery(sql);

            return Content(result.ToString());
        }
    }
}