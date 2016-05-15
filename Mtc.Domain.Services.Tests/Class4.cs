//using Mtc.Domain.Common.Security;
//using Mtc.Domain.Common.UnitTest;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using Autofac;
using Mtc.Infrastructure.DataAccess;
using MtcModel;
using MySql.Data.MySqlClient;
using NUnit.Framework;

namespace Mtc.Domain.Services.Tests
{
    public class MtcServiceTestsBase : BaseDatabaseIntegrationTests
    {
        protected IContainer _diContainer;
        private const int TEST_PCO_ID = 993939;

        protected override DbContext CreateDbContext()
        {
            var entities = new MtcEntities(this.GetConnectionStringName());
            return entities;
        }

        protected override string GetConnectionStringName()
        {
            return "MtcEntities";
        }

        [OneTimeSetUp]
        public void FixtureSetup()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new DataModule(GetConnectionStringName()));
            containerBuilder.RegisterModule(new ServiceModule(GetConnectionStringName()));

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