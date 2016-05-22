using System;
using System.Collections.Generic;
using Mtc.Domain.Models;
using Mtc.Domain.Services.Interfaces;
using Mtc.Infrastructure.DataAccess.Interfaces;

namespace Mtc.Domain.Services
{
    public class PersonService : IPersonService
    {
        private readonly IUserRepository _userRepository;

        public PersonService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Person GetById(int id)
        {
            return ModelHelper.Mapper(_userRepository.GetById(id));
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

        public IEnumerable<Person> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
