using System;
using System.Collections.Generic;
using System.Linq;
using Edc.Domain.Models;
using Edc.Domain.Services.Interfaces;
using Edc.Infrastructure.DataAccess.Interfaces;

namespace Edc.Domain.Services
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
            return ModelHelper.Mapper(_userRepository.Get(p=>p.Email == name).FirstOrDefault());
        }

        public Person Create(Person entity)
        {
            return ModelHelper.Mapper(_userRepository.Insert(ModelHelper.Mapper(entity)));
        }

        public void Update(Person entity)
        {
            _userRepository.Update(ModelHelper.Mapper(entity));
        }

        public void Delete(Person entity)
        {
            _userRepository.Delete(ModelHelper.Mapper(entity));
        }

        public IEnumerable<Person> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
