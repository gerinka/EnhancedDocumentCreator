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
using Mtc.Infrastructure.DataAccess;
using Mtc.Infrastructure.Services;
//using Mtc.WebClient.Utils;
using AutofacDependencyResolver = Autofac.Integration.Mvc.AutofacDependencyResolver;

namespace Mtc.WebClient
{

    /// <summary>
    /// Configures the dependency injection system.
    /// </summary>
    internal static class AutofacConfiguration
    {
        private const string WEBAPI_CONNSTR_NAME = "WebApi";

        internal static void ConfigureAutofac(HttpConfiguration config)
        {
            RegisterWebApi(config);
            RegisterUrmSecurityForFederation();
        }

        public static ContainerBuilder CreateContainerBuilder()
        {
            ContainerBuilder builder = new ContainerBuilder();
            DependencyInjectionConfiguration dependencyInjectionConfiguration = CpimsConfiguration.Settings.Debug.DependencyInjection;
            if (dependencyInjectionConfiguration.ProfilingEnabled)
            {
                builder.EnableWhiteboxProfiling();
            }

            return builder;
        }

        private static void RegisterUrmSecurityForFederation()
        {
            ContainerBuilder builder = CreateContainerBuilder();
            builder.RegisterDomainModules();

            IContainer container = builder.Build();

            // Find the registration for the SessionMessagesSender service and wireup the events with 
            // the corresponding handler methods in the WFM subsystem.
            // Note: we could have done this with less code directly in the registration of the 
            // SessionMessagesSender, but since this registration is done in its own (URM) subsystem we know
            // nothing about WFM at that point. So we do it here and thats the only point where the interaction
            // between URM and WFM must be known.
            foreach (IComponentRegistration registration in container.ComponentRegistry.Registrations)
            {
                TypedService service = registration.Services.FirstOrDefault() as TypedService;
            }


            SecurityServicesRegistry.SetContainer(container);
        }

        private static void RegisterWebApi(HttpConfiguration config)
        {
            ContainerBuilder builder = CreateContainerBuilder();
            builder.RegisterDomainModules();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            #region Utils

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Name.EndsWith("CriteriaFactory"))
                .AsSelf();

            builder.RegisterType<TaskMapper>().AsImplementedInterfaces();

            #endregion

            #region Entities

            builder.RegisterType<WfmEntities>().UsingConstructor(typeof(DbConnection)).InstancePerRequest();

           
            builder.Register(c =>
            {
                DbConnection dbConn = new OracleConnection(ConfigurationManager.ConnectionStrings[WEBAPI_CONNSTR_NAME].ConnectionString);
                dbConn.StateChange += ConnectionModifier.OnConnectionStateChange;
                dbConn.Open();
                return dbConn;
            }).As<DbConnection>().InstancePerRequest();

            #region this is a workaround for the weird connection not closed bug 39658
            
            #endregion

           

            #endregion
            IContainer container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }

       

       
    }
}