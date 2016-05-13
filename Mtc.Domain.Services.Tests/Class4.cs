using System;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using Autofac;
//using Mtc.Domain.Common.Security;
//using Mtc.Domain.Common.UnitTest;
using Mtc.Domain.Models;
using Mtc.Infrastructure.DataAccess;
using Mtc.Domain.Services;
using Devart.Data;
using Mtc.Domain.Services.Tests;
using MtcModel;
using MySql.Data.MySqlClient;
using NUnit.Framework;

namespace Mtc.Domain.Tests.ComponentTests
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

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new DataModule());
            containerBuilder.RegisterModule(new ServiceModule());

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