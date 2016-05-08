using System;
using Mtc.Domain.Models;
using Mtc.Domain.Services.Interfaces;
using Mtc.Infrastructure.DataAccess.Repositories;
using MtcModel;

namespace Mtc.Domain.Services
{
    public class PersonService : IPersonService
    {
        private readonly UserRepository _userRepository;

        public PersonService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Person GetPersonById(long id)
        {
            var person = new Person();
            USER user = _userRepository.GetById(id);
            return person;
        }

        public Person GetPersonByName(string name)
        {
            throw new NotImplementedException();
        }

        public Person CreatePerson(Person person)
        {
            throw new NotImplementedException();
        }

        public Person UpdatePerson(Person person)
        {
            throw new NotImplementedException();
        }

        public Person DeletePerson(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
