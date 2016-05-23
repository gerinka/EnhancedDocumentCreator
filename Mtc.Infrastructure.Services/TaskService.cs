using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Mtc.Domain.Models;
using Mtc.Domain.Services.Interfaces;
using Mtc.Infrastructure.DataAccess.Interfaces;
using MtcModel;
using Task = Mtc.Domain.Models.Task;

namespace Mtc.Domain.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public Task GetById(int id)
        {
            return ModelHelper.Mapper(_taskRepository.GetById(id));
        }

        public Task GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task Create(Task entity)
        {
            return ModelHelper.Mapper(_taskRepository.Insert(ModelHelper.Mapper(entity)));
        }

        public Task Update(Task entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Task entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Task> GetAll()
        {
            return _taskRepository.Get().Select(ModelHelper.Mapper);
        }

        public IEnumerable<Task> GetTasksByDocumentId(int documentId)
        {
            var taskList = _taskRepository.Get(t => t.DocumentId == documentId).Select(ModelHelper.Mapper).ToList();
            UnlockNewTasks(taskList);
            ExpireTasks(taskList);
            _taskRepository.BulkUpdate(taskList.Select(ModelHelper.Mapper));
            return taskList;
        }

        private void ExpireTasks(IEnumerable<Task> taskList)
        {
            foreach (var task in taskList)
            {
                if (task.Deadline < DateTime.UtcNow)
                {
                    task.TaskState = TaskState.Expired;
                }
            }
        }

        private static void UnlockNewTasks(List<Task> taskList)
        {
            if (taskList.All(t => t.TaskState == TaskState.Locked || t.TaskState == TaskState.Done))
            {
                foreach (var task in taskList.Where(t => t.TaskState == TaskState.Locked).Take(3))
                {
                    task.TaskState = TaskState.ToDo;
                }
            }
        }

        public Task StartTask(int taskId)
        {
            Task task = GetById(taskId);
            task.TaskState = TaskState.InProgress;
            task.Section.Content.CurrentProgress = 1;
            _taskRepository.Update(ModelHelper.Mapper(task));
            return task;
        }

        public Task FinishTask(int taskId)
        {
            Task task = GetById(taskId);
            task.TaskState = TaskState.Done;
            _taskRepository.Update(ModelHelper.Mapper(task));
            return task;
        }

        public Task RejectTask(int taskId)
        {
            Task task = GetById(taskId);
            task.TaskState = TaskState.WontBeDone;
            _taskRepository.Update(ModelHelper.Mapper(task));
            return task;
        }

        public IEnumerable<Task> GenerateTasks(int documentId, DateTime documentDeadline, Person author, IEnumerable<Section> sections)
        {

            var sectionList = sections.ToList();
            var totalSubsections = sectionList.SelectMany(section => section.Subsections).Count();
            var tasksToBeCreated = new List<Task>();
            var previousTasks = 0;
            var totalWaves = (int) Math.Floor((documentDeadline - DateTime.UtcNow).TotalDays/30) + 1;
            totalSubsections *= totalWaves;
            var order = 1;
            for (var wave = 0; wave < totalWaves; wave++)
            {
                foreach (var section in sectionList)
                {
                    foreach (var subsection in section.Subsections.OrderBy(ss=>ss.Order))
                    {
                        tasksToBeCreated.Add(new Task
                        {
                            Title = section.Title,
                            Section = subsection,
                            TaskState = wave == 0 && section.Order == 1?TaskState.ToDo : TaskState.Locked,
                            TaskType = TaskType.Task,
                            AssignTo = author,
                            Deadline = CalculateDeadline(documentDeadline, previousTasks, totalSubsections, wave),
                            Order = order
                        });
                        previousTasks++;
                        order ++;
                    }
                    order = 1;
                }
            }

            return _taskRepository.BulkInsert(tasksToBeCreated.Select(ModelHelper.Mapper)).Select(ModelHelper.Mapper);
        }
        private DateTime CalculateDeadline(DateTime documentDeadline, int previousTasks, int totalSubsections, int wave)
        {
            var timePerTask = (documentDeadline - DateTime.UtcNow).TotalDays/totalSubsections;
            return DateTime.UtcNow.AddDays((previousTasks + 1)* timePerTask);
        }
    }
}
