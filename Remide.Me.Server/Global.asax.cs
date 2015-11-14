using System.Reflection;
using System.Web.Http;

using Remide.Me.DataAccess.Infrastructure;
using Remide.Me.DataAccess.Redis;

using Autofac;
using Autofac.Integration.WebApi;

namespace Remide.Me.Server
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);

            RegisterDataAccess(builder);

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private void RegisterDataAccess(ContainerBuilder builder)
        {
            builder.RegisterType<RedisLocationStorageProvider>().As<ILocationStorageProvider>();
        }
    }
}
