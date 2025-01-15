using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using System.Reflection;
using ClientManagementSystem.UI.ClientManagementServiceReference;
using Autofac.Integration.Wcf;

namespace ClientManagementSystem.UI.App_Start
{
    public class AutofacConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            // Register your MVC controllers.
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            // Register your WCF service client.
            builder.Register(c => new ClientManagementServiceClient())
                .As<IClientManagementService>()
                .InstancePerRequest();

            // Build the container.
            var container = builder.Build();

            // Set the dependency resolver.
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            // Set the WCF DependencyResolver
            AutofacHostFactory.Container = container;
        }
    }
}

