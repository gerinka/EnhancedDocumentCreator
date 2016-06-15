using System;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using System.Transactions;
using Edc.Infrastructure.DataAccess.Interfaces;
using MySql.Data.MySqlClient;

namespace Edc.Domain.Services.Tests
{
    /// <summary>
    /// TestHelper that can be used independently from any repository or entity
    /// </summary>
    public class DataTestHelper
    {
        #region Fields


        private string _connectionStringName;
        private IsolationLevel _isolationLevel = IsolationLevel.ReadUncommitted;

        #endregion

        #region Properties
        public DbContext DbContext { get; set; }
        public Func<DbContext> DbContextCreator { get; set; }
        public DbConnection Connection { get; set; }
        public TransactionScope TransactionScope { get; set; }

        public IsolationLevel IsolationLevel
        {
            get { return _isolationLevel; }
            set { _isolationLevel = value; }
        }

        #endregion

        #region Setup / TearDown

        public void FixtureSetupForDb()
        {
        }

        public void SetUpForDb(string connectionStringName, Func<DbContext> dbContextCreator)
        {
            TransactionScope = new TransactionScope(TransactionScopeOption.RequiresNew, new TransactionOptions
            {
                IsolationLevel = IsolationLevel
            });
            _connectionStringName = connectionStringName;
            Connection = new MySqlConnection(ConfigurationManager.ConnectionStrings[_connectionStringName].ConnectionString);
            Connection.Open();
            DbContextCreator = dbContextCreator;
            DbContext = dbContextCreator();
        }

        public void FixtureTearDownForDb()
        {

        }


        public void TearDownForDb()
        {
            Connection.Dispose();
            DbContext.Dispose();
            TransactionScope.Dispose();
        }
        #endregion
    }


    public class DataTestHelper<TDomainObject> : DataTestHelper where TDomainObject : class
    {
        public Func<DbContext, IBaseRepository<TDomainObject>> ReadRepositoryCreator { get; set; }
        public Func<DbContext, IBaseRepository<TDomainObject>> RepositoryCreator { get; set; }

        public void SetUpForDbRead(string connectionStringName, Func<DbContext> dbContextCreator, Func<DbContext, IBaseRepository<TDomainObject>> readRepositoryCreator)
        {
            SetUpForDb(connectionStringName, dbContextCreator);
            ReadRepositoryCreator = readRepositoryCreator;
        }

        public void SetUpForDbWrite(string connectionStringName, Func<DbContext> dbContextCreator, Func<DbContext, IBaseRepository<TDomainObject>> repositoryCreator)
        {
            SetUpForDb(connectionStringName, dbContextCreator);
            RepositoryCreator = repositoryCreator;
        }

        public IBaseRepository<TDomainObject> CreateReadRepository()
        {
            return ReadRepositoryCreator(DbContext);
        }

        public IBaseRepository<TDomainObject> CreateRepository()
        {
            return RepositoryCreator(DbContext);
        }

        public IBaseRepository<TDomainObject> CreateReadRepositoryWithNewContext()
        {
            return ReadRepositoryCreator(DbContextCreator());
        }

        public IBaseRepository<TDomainObject> CreateRepositoryWithNewContext()
        {
            return RepositoryCreator(DbContextCreator());
        }

    }
}
