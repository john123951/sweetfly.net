using SweetFly.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using SweetFly.Infrastructure.ApiServices;

namespace SweetFly.ApiControllers
{
    /// <summary>
    /// 通用接口控制器
    /// </summary>
    public class UtilController : ApiController
    {
        /// <summary>
        /// 得到服务器的当前时间
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public DateTime GetDateTime()
        {
            return DateTime.Now;
        }
    }
}
