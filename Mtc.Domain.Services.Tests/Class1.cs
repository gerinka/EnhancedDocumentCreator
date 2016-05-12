using System;
using System.Data.Entity;
using MtcModel;
using NUnit.Framework;

namespace Mtc.Domain.Services.Tests
{
    [TestFixture]
    public abstract class MtcRepositoryComponentTests<TEntity> where TEntity : class
    {
        [TestFixtureSetUp]
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

        protected  DbContext CreateDbContext()
        {
     //       var ctx = new MtcEntities(DataTestHelper.Connection);
  //          ctx.Database.Log = Console.WriteLine;
    //        return ctx;
            return null;
        }

        protected string GetConnectionStringName()
        {
            return "MtcEntitiesConnectionString";
        }


    }
}
