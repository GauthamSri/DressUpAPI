using DressUpAPI.Commands;
using DressUpAPI.Processors;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace DressUpAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<ICommandProcessor, CommandProcessor>();
            container.RegisterType<IRuleProcessor, RuleProcessor>();
            container.RegisterType<ICommandFactory, CommandFactory>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}