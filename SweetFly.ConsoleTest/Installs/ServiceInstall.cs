using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SweetFly.BusinessLogic;
using SweetFly.BusinessLogic.contract;

namespace SweetFly.Portal.Installs
{
    public class ServiceInstall : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var asm = typeof(LoginInfoService).Assembly;

            container.Register(
                Classes.FromAssembly(asm)
                .IncludeNonPublicTypes()
                .Pick()
                .WithService.DefaultInterfaces()
                .LifestyleTransient()
                );

        }
    }
}
