using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Edc.Domain.Services.Tests
{
    public abstract class BaseDatabaseIntegrationTests
    {

        #region Constructor
        protected BaseDatabaseIntegrationTests()
        {
            DataTestHelper = new DataTestHelper();
        }
        #endregion

        #region Properties
        public DataTestHelper DataTestHelper { get; set; }
        #endregion

        #region Setup / TearDown
        [OneTimeSetUp]
        public void TestFixtureSetup()
        {
            DataTestHelper.FixtureSetupForDb();
        }

        [SetUp]
        public void SetUp()
        {
            DataTestHelper.SetUpForDb(GetConnectionStringName(), CreateDbContext);
        }

        [OneTimeTearDown]
        public void FixtureTearDown()
        {
            DataTestHelper.FixtureTearDownForDb();
        }

        [TearDown]
        public void TearDown()
        {
            DataTestHelper.TearDownForDb();
        }
        #endregion

        #region Methods

        #endregion

        #region Abstract

        protected abstract DbContext CreateDbContext();

        /// <summary>
        /// Gets the connection string name which is used to create the connection for the DbContext.
        /// </summary>
        /// <returns></returns>
        protected abstract string GetConnectionStringName();


        #endregion
    }
}
