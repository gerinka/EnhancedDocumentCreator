//using Edc.Domain.Common.Security;
//using Edc.Domain.Common.UnitTest;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using Autofac;
using Edc.Infrastructure.Configuration;
using Edc.Infrastructure.DataAccess;
using MtcModel;
using MySql.Data.MySqlClient;
using NUnit.Framework;

namespace Edc.Domain.Services.Tests
{
    public class MtcServiceBaseTests : BaseDatabaseIntegrationTests
    {
        protected IContainer _diContainer;

        protected override DbContext CreateDbContext()
        {
            var entities = new MtcEntities(this.GetConnectionStringName());
            return entities;
        }

        protected override string GetConnectionStringName()
        {
            return "MTCEntitiesConnectionString";
        }

        [OneTimeSetUp]
        public void FixtureSetup()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new MtcModule());

            containerBuilder.RegisterType<MtcEntities>().UsingConstructor(typeof(DbConnection));
            containerBuilder.Register(c =>
            {
                var dbConn = new MySqlConnection(ConfigurationManager.ConnectionStrings[GetConnectionStringName()].ConnectionString);
                dbConn.Open();
                return dbConn;
            }).As<DbConnection>().InstancePerLifetimeScope();


            _diContainer = containerBuilder.Build();

        }

    }
}