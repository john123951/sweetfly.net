using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SweetFly.Repository;
using SweetFly.Repository.contract;

namespace SweetFly.Portal.Installs
{
    public class RepositoryInstall : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For(typeof(ISweetFlyRepository<>))
                .ImplementedBy(typeof(SweetFlyRepository<>))
                .LifestyleTransient()
                ,
                Component.For(typeof(ICmrcnRepository<>))
                .ImplementedBy(typeof(CmrcnRepository<>))
                .LifestyleTransient()
                );
        }
    }
}
