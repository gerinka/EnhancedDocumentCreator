using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using MtcModel;
using NUnit.Framework;

namespace Mtc.Domain.Services.Tests
{
    [TestFixture]
    public abstract class MtcRepositoryComponentTests<TEntity> : BaseDatabaseIntegrationTests where TEntity : class
    {
        [OneTimeSetUp]
        public void InitEffort()
        {
            try
            {
         //       Effort.Provider.EffortProviderConfiguration.RegisterProvider();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        protected override DbContext CreateDbContext()
        {
            var ctx = new MtcEntities(DataTestHelper.Connection.ConnectionString);
            return ctx;
        }

        protected override string GetConnectionStringName()
        {
            return "MTCEntitiesConnectionString";
        }


    }
}
