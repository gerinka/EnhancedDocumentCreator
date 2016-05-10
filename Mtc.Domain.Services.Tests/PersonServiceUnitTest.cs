using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Transactions;
using Moq;
using Mtc.Infrastructure.DataAccess.Interfaces;
using MtcModel;
using NSubstitute;
using NUnit.Framework;

namespace Mtc.Domain.Services.Tests
{
    [TestFixture]
    public class PersonServiceUnitTest
    {
        private TransactionScope _scope;

        [SetUp]
        public void SetUp()
        {
            _scope = new TransactionScope();
        }

        [TearDown]
        public void TearDown()
        {
            _scope.Dispose();
        }


        [Test]
        public void TestMapperPerson_properId_returnSth()
        {
            var user = new USER()
            {
                Id = 5,
                FirstName = "Ivan",
                FamilyName = "Marinov"
            };

            var mockContext = new Mock<MtcEntities>();

            var userRepo = new Mock<IUserRepository>(mockContext.Object);
            userRepo.Setup(u => u.GetById(Arg.Any<long>())).Returns(user);
            var personService = new PersonService(userRepo.Object);
            personService.GetById(5);
        }
    }
}
