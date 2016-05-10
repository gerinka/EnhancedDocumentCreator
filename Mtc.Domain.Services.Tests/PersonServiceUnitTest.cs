using System;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Mtc.Infrastructure.DataAccess.Repositories;
using MtcModel;
using NSubstitute;

namespace Mtc.Domain.Services.Tests
{
    [TestClass]
    public class PersonServiceUnitTest
    {
        [TestMethod]
        public void GetPerson()
        {
            var user = new USER()
            {
                Id = 5,
                FirstName = "Ivan",
                FamilyName = "Marinov"
            };

            var dbContext = new Mock<MtcEntities>();
            dbContext.Setup(db => db.USERs);
            var userRepo = new Mock<UserRepository>(dbContext.Object);
            userRepo.Setup(u => u.GetById(Arg.Any<long>())).Returns(user);
            var personService = new PersonService(userRepo.Object);
            personService.GetPersonById(5);
        }
    }
}
