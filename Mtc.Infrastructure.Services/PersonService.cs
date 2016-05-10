using System;
using Mtc.Domain.Models;
using Mtc.Domain.Services.Interfaces;
using Mtc.Infrastructure.DataAccess.Interfaces;
using Mtc.Infrastructure.DataAccess.Repositories;
using MtcModel;

namespace Mtc.Domain.Services
{
    public class PersonService : IPersonService
    {
        private readonly IUserRepository _userRepository;

        public PersonService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Person GetById(long id)
        {
            return Mapper(_userRepository.GetById(id));
        }

        public Person GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Person Create(Person entity)
        {
            throw new NotImplementedException();
        }

        public Person Update(Person entity)
        {
            throw new NotImplementedException();
        }

        public Person Delete(Person entity)
        {
            throw new NotImplementedException();
        }

        private Person Mapper(USER user)
        {
            return new Person()
            {
                Email = user.Email,
                FamilyName = user.FamilyName,
                FirstName = user.FirstName,
                Id = user.Id,
                ExperiencePoints = user.ExperiencePoints,
                Level = user.Level,
            };
        }
    }
}
