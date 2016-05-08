using Mtc.Domain.Models;

namespace Mtc.Domain.Services.Interfaces
{
    public interface IPersonService
    {
        Person GetPersonById(long id);
        Person GetPersonByName(string name);
        Person CreatePerson(Person person);
        Person UpdatePerson(Person person);
        Person DeletePerson(Person person);
    }
}
