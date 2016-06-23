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
using Edc.Infrastructure.Configuration;
using Edc.Infrastructure.DataAccess;
using MtcModel;
using MySql.Data.MySqlClient;
using AutofacDependencyResolver = Autofac.Integration.Mvc.AutofacDependencyResolver;

namespace Edc.WebClient
{

    /// <summary>
    /// Configures the dependency injection system.
    /// </summary>
    internal static class AutofacConfig
    {
        internal static void ConfigureAutofac()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<MtcEntities>().InstancePerRequest();
            builder.RegisterModule(new MtcModule());
  
            IContainer container = builder.Build();
            var mvcResolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(mvcResolver);
        }
    }
}