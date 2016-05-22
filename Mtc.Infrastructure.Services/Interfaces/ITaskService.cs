using System;
using System.Collections.Generic;
using Mtc.Domain.Models;

namespace Mtc.Domain.Services.Interfaces
{
    public interface ITaskService : IBaseService<Task>
    {
        IEnumerable<Task> GenerateTasks(int documentId, DateTime documentDeadline, Person author, IEnumerable<Section> sections);
    }
}
