using System.Collections.Generic;
using Edc.Domain.Models;

namespace Edc.Domain.Services.Interfaces
{
    public interface IPersonService : IBaseService<Person>
    {
        IList<Person> GetAllAvailableMentors();
        IList<Person> GetAllAdmins();
    }
}
