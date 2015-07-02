using log4net;
using SweetFly.Utility;
using SweetFly.Utility.Extentions;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace SweetFly.Interceptors.DelegatingHandlers
{
    /// <summary>
    /// 监视Api请求
    /// </summary>
    public class TraceHandler : DelegatingHandler
    {
        private ILog logger = LogUtility.GetInstance().GetLog("ApiTrace");

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var httpContext = request.GetHttpContext();
            string clientIp = httpContext.Request.UserHostAddress;

            string msg = string.Format("IP:[{0}] ,Method:[{1}], Url:[{2}]",
                                        clientIp,
                                        httpContext.Request.HttpMethod,
                                        httpContext.Request.RawUrl
                );

            logger.Info(msg);

            return base.SendAsync(request, cancellationToken);
        }
    }
}