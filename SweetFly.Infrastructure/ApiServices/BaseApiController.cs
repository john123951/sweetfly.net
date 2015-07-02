using SweetFly.Model.ApiControllers.BaseApiController;
using SweetFly.Model.ApiControllers.BaseApiController.Responses;
using SweetFly.Utility.Extentions;
using System;
using System.Web;
using System.Web.Http;

namespace SweetFly.Infrastructure.ApiServices
{
    /// <summary>
    /// API接口的基类
    /// </summary>
    public abstract class BaseApiController : ApiController
    {
        /// <summary>
        /// 当前Http请求
        /// </summary>
        protected HttpContext HttpContext
        {
            get { return HttpContext.Current; }
        }

        /// <summary>
        /// 产品Id
        /// </summary>
        protected abstract int ProductId { get; }

        /// <summary>
        /// 返回产品是否可用
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual ApiResponse<bool> IsEnabled()
        {
            var response = new ApiResponse<bool>
                {
                    Result = true
                };

            return response.Success();
        }
    }
}