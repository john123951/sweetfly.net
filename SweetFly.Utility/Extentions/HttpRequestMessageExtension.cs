using System.Net.Http;
using System.Web;

namespace SweetFly.Utility.Extentions
{
    /// <summary>
    /// Web Api的扩展
    /// </summary>
    public static class HttpRequestMessageExtension
    {
        private const string HttpContext = "MS_HttpContext";
        private const string RemoteEndpointMessage = "System.ServiceModel.Channels.RemoteEndpointMessageProperty";

        /// <summary>
        /// 获取当前请求的HttpContext
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static HttpContextWrapper GetHttpContext(this HttpRequestMessage request)
        {
            if (false == request.Properties.ContainsKey("MS_HttpContext"))
            {
                return null;
            }
            var ctx = request.Properties["MS_HttpContext"] as HttpContextWrapper;
            return ctx;
        }

        /// <summary>
        /// 获取当前请求的IP地址
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string GetClientIpAddress(this HttpRequestMessage request)
        {
            if (request.Properties.ContainsKey(HttpContext))
            {
                dynamic ctx = request.Properties[HttpContext];
                if (ctx != null)
                {
                    return ctx.Request.UserHostAddress;
                }
            }
            if (request.Properties.ContainsKey(RemoteEndpointMessage))
            {
                dynamic remoteEndpoint = request.Properties[RemoteEndpointMessage];
                if (remoteEndpoint != null)
                {
                    return remoteEndpoint.Address;
                }
            }
            return null;
        }
    }
}