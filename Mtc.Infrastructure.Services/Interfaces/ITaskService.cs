using System;
using System.Collections.Generic;
using Mtc.Domain.Models;

namespace Mtc.Domain.Services.Interfaces
{
    public interface ITaskService : IBaseService<Task>
    {
        IEnumerable<Task> GenerateTasks(int documentId, DateTime documentDeadline, Person author,int totalCycles, IEnumerable<Section> sections);
        IEnumerable<Task> GetTasksByDocumentId(int documentId);
        Task StartTask(int taskId);
        Task FinishTask(int taskId);
        Task RejectTask(int taskId);
    }
}
