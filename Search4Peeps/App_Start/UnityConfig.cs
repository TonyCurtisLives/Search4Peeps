using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using Search4Peeps.Services;
using Search4Peeps.DAL;

namespace Search4Peeps
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterType<IPeepService, PeepService>();

            // since this is an iDisposable, this is recommended for lifetime management
            container.RegisterType<MontyPeepsContext, MontyPeepsContext>(new HierarchicalLifetimeManager());
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}