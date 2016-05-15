using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Runtime.InteropServices;
using System.Transactions;
using Autofac;
using Moq;
using Mtc.Domain.Services.Interfaces;
using Mtc.Infrastructure.Configuration;
using Mtc.Infrastructure.DataAccess;
using Mtc.Infrastructure.DataAccess.Interfaces;
using MtcModel;
using MySql.Data.MySqlClient;
using NSubstitute;
using NUnit.Framework;

namespace Mtc.Domain.Services.Tests
{
    [TestFixture]
    [Category("IntegrationTest")]
    public class PersonServiceIntegrationTest : BaseDatabaseIntegrationTests
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
            containerBuilder.RegisterModule(new DataModule(GetConnectionStringName()));
          // containerBuilder.RegisterType<MtcEntities>().UsingConstructor(typeof(DbConnection));
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
