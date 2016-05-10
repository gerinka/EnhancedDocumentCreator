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
        private TransactionScope scope;

        [SetUp]
        public void SetUp()
        {
            scope = new TransactionScope();
        }

        [TearDown]
        public void TearDown()
        {
            scope.Dispose();
        }


        [Test]
        public void YourTest()
        {
            var user = new USER()
            {
                Id = 5,
                FirstName = "Ivan",
                FamilyName = "Marinov"
            };
            var mockSet = new Mock<ObjectSet<USER>>();

            var mockContext = new Mock<MtcEntities>();
            mockContext.Setup(m => m.USERs).Returns(mockSet.Object);
            var userrepo2 = new Mock<IUserRepository>(mockContext.Object);
            var dbContext = new Mock<MtcEntities>();
         
            var userRepo = new Mock<IUserRepository>(dbContext.Object);
            userRepo.Setup(u => u.GetById(Arg.Any<long>())).Returns(user);
            var personService = new PersonService(userRepo.Object);
            personService.GetPersonById(5);
        }
    }
}
