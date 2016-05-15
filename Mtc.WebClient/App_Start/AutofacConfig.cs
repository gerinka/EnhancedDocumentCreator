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
        private const string WEBAPI_CONNSTR_NAME = "WebApi";

        internal static void ConfigureAutofac(HttpConfiguration config)
        {
            RegisterWebApi(config);
        }

        public static ContainerBuilder CreateContainerBuilder()
        {
            ContainerBuilder builder = new ContainerBuilder();
            //DependencyInjectionConfiguration dependencyInjectionConfiguration = Configuration.Settings.Debug.DependencyInjection;
            return builder;
        }

        private static void RegisterWebApi(HttpConfiguration config)
        {
            ContainerBuilder builder = CreateContainerBuilder();
            //builder.RegisterDomainModules();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            #region Entities

            builder.RegisterType<MtcEntities>().UsingConstructor(typeof(DbConnection)).InstancePerRequest();


            builder.Register(c =>
            {
                DbConnection dbConn = new MySqlConnection(ConfigurationManager.ConnectionStrings[WEBAPI_CONNSTR_NAME].ConnectionString);
                dbConn.Open();
                return dbConn;
            }).As<DbConnection>().InstancePerRequest();

            #endregion
            IContainer container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}