using Mtc.Domain.Models;

namespace Mtc.Domain.Services.Interfaces
{
    interface IPersonService
    {
        Person GetPersonById();
        Person GetPersonByName(string name);
        Person CreatePerson(Person person);
        Person UpdatePerson(Person person);
        Person DeletePerson(Person person);
    }
}
