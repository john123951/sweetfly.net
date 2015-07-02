using System.Web.Http;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace SweetFly.Portal.Installs
{
    public class ControllerInstall : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.FromAssemblyNamed("SweetFly.Controllers")
                .BasedOn<Controller>()
                .LifestyleTransient()
                );

            container.Register(
                Classes.FromAssemblyNamed("SweetFly.ApiControllers")
                .BasedOn<ApiController>()
                .LifestyleTransient()
                );

        }
    }
}