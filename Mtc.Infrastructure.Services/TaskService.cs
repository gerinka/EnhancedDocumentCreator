using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mtc.Domain.Services.Interfaces;
using Task = Mtc.Domain.Models.Task;

namespace Mtc.Domain.Services
{
    public class TaskService : ITaskService
    {
        public Task GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Task GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task Create(Task entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(Task entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Task entity)
        {
            throw new NotImplementedException();
        }
    }
}
