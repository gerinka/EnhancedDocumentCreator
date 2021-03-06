﻿using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Runtime.InteropServices;
using System.Transactions;
using Autofac;
using Moq;
using Edc.Domain.Services.Interfaces;
using Edc.Infrastructure.Configuration;
using Edc.Infrastructure.DataAccess;
using Edc.Infrastructure.DataAccess.Interfaces;
using MtcModel;
using MySql.Data.MySqlClient;
using NSubstitute;
using NUnit.Framework;

namespace Edc.Domain.Services.Tests
{
    [TestFixture]
    [Category("IntegrationTest")]
    public class PersonServiceIntegrationTest : MtcRepositoryComponentTests<USER>
    {
        private IContainer _diContainer;

        protected override DbContext CreateDbContext()
        {
            return new MtcEntities(GetConnectionStringName());
        }

        protected override string GetConnectionStringName()
        {
            return "MTCEntitiesConnectionString";
        }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new MtcModule());
           containerBuilder.RegisterType<MtcEntities>().InstancePerLifetimeScope();
           containerBuilder.Register(c =>
            {
                var dbConnection =
                    new MySqlConnection(
                        ConfigurationManager.ConnectionStrings[GetConnectionStringName()]
                            .ConnectionString);
                dbConnection.Open();
                return dbConnection;
            }).As<DbConnection>().InstancePerLifetimeScope();
            _diContainer = containerBuilder.Build();
        }

        [Test]
        public void TestMapperPerson_properId_returnSth()
        {
            var service = _diContainer.Resolve<IPersonService>();
            DbContext context = _diContainer.Resolve<MtcEntities>();
            var user = context.Set<USER>().First();

            var person = service.GetById(user.Id);
            Assert.AreEqual(user.FirstName, person.FirstName);
        }

       
    }
}
