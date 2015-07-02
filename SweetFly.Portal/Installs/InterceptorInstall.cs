using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System.Collections.Generic;
using SweetFly.Interceptors;

namespace SweetFly.Portal.Installs
{
    public class InterceptorInstall : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var selector = new List<string>() { "^Process$" };

            container.Register(
                Component.For<TraceInterceptor>()
                //.DependsOn(Dependency.OnValue("RegexSelector", selector))
                //.DynamicParameters((k, d) =>
                //{
                //    d["RetryTimes"] = YqbConfig.GetInstance().RetryTimes;
                //    d["Interval"] = YqbConfig.GetInstance().Interval;
                //})
                //.LifestyleTransient()
                );
        }
    }
}
