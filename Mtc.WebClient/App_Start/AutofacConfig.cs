using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Mtc.Infrastructure.Configuration;
using Mtc.Infrastructure.DataAccess;
using MtcModel;
using MySql.Data.MySqlClient;
using AutofacDependencyResolver = Autofac.Integration.Mvc.AutofacDependencyResolver;

namespace Mtc.WebClient
{

    /// <summary>
    /// Configures the dependency injection system.
    /// </summary>
    internal static class AutofacConfig
    {
        internal static void ConfigureAutofac(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<MtcEntities>().InstancePerRequest();
            builder.RegisterModule(new MtcModule());
  
            IContainer container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}