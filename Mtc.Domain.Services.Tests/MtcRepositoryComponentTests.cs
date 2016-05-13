using System;
using System.Data.Entity;
using MtcModel;
using NUnit.Framework;

namespace Mtc.Domain.Services.Tests
{
    [TestFixture]
    public abstract class MtcRepositoryComponentTests<TEntity>  where TEntity : class
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

        public DbContext CreateDbContext()
        {
           /* var ctx = new MtcEntities(DataTestHelper.Connection);
            ctx.Database.Log = Console.WriteLine;
            return ctx;*/
            return null;
            //check init of datatesthelper : BaseDatabaseIntegrationTests
        }

        public string GetConnectionStringName()
        {
            return "MtcEntitiesConnectionString";
        }


    }
}
