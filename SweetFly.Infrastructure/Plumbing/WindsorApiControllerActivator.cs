using Castle.MicroKernel;
using SweetFly.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Web.Http.Services;

namespace SweetFly.Infrastructure.Plumbing
{
    /// <summary>
    /// Web API 控制器工厂
    /// </summary>
    public class WindsorApiControllerActivator : IHttpControllerActivator
    {
        private readonly IKernel _kernel;

        public WindsorApiControllerActivator()
        {
            _kernel = WindsorUtility.Instance.Container.Kernel;
        }
        public WindsorApiControllerActivator(IKernel kernel)
        {
            _kernel = kernel;
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            if (controllerType == null)
            {
                var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("The controller for path '{0}' could not be found.", request.RequestUri))
                };
                throw new HttpResponseException(httpResponseMessage);
            }
            return _kernel.Resolve(controllerType) as IHttpController;
        }
    }
}
