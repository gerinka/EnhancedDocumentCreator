/*using System;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using Autofac;
using Cpims.CDG.Infrastructure.Configuration;
using Cpims.Common.Security;
using Cpims.Common.UnitTest;
using Cpims.WFM.Domain.Actors;
using Cpims.WFM.Domain.Brands;
using Cpims.WFM.Domain.Countries;
using Cpims.WFM.Domain.DeliveryTypes;
using Cpims.WFM.Domain.Languages;
using Cpims.WFM.Domain.Productgroups;
using Cpims.WFM.Domain.Workflows;
using Cpims.WFM.Infrastructure.Configuration;
using Cpims.WFM.Infrastructure.DataAccess;
using Cpims.WFM.Infrastructure.Services;
using Devart.Data.Oracle;
using NUnit.Framework;
using StarTrack.Common.Messaging.Enqueue;

namespace Mtc.Domain.Tests.ComponentTests
{
    public class MtcServiceTestsBase : BaseDatabaseComponentTests
    {
        protected IContainer _diContainer;
        private const int TEST_PCO_ID = 993939;

        protected override DbContext CreateDbContext()
        {
            var entities = new MtcEntities(this.GetConnectionStringName());
            entities.Configuration.LazyLoadingEnabled = true;
            entities.Configuration.ProxyCreationEnabled = false;
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
                var dbConn = new OracleConnection(ConfigurationManager.ConnectionStrings[GetConnectionStringName()].ConnectionString);
                dbConn.Open();
                return dbConn;
            }).As<DbConnection>().InstancePerLifetimeScope();


            _diContainer = containerBuilder.Build();

        }

    }
}*/