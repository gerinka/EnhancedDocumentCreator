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

        public Task GetById(long id)
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

        public IEnumerable<Task> GenerateTasks(int documentId, DateTime documentDeadline, Person author, IEnumerable<Section> sections)
        {

            var sectionList = sections.ToList();
            var totalSubsections = sectionList.SelectMany(section => section.Subsections).Count();
            var tasksToBeCreated = new List<Task>();
            var previousTasks = 0;
            var totalWaves = (int) Math.Floor((documentDeadline - DateTime.UtcNow).TotalDays/30) + 1;
            for (var wave = 0; wave < totalWaves; wave++)
            {
                foreach (var section in sectionList)
                {
                    foreach (var subsection in section.Subsections)
                    {
                        tasksToBeCreated.Add(new Task
                        {
                            Title = section.Title,
                            Section = subsection,
                            IsLocked = true,
                            TaskState = TaskState.ToDo,
                            TaskType = TaskType.Task,
                            AssignTo = author,
                            Deadline = CalculateDeadline(documentDeadline, previousTasks, totalSubsections, wave)
                        });
                        previousTasks++;
                    }
                }
            }

            //return _taskRepository.BulkInsert(tasksToBeCreated.Select(ModelHelper.Mapper)).Select(ModelHelper.Mapper);
            return tasksToBeCreated;
        }

        private DateTime CalculateDeadline(DateTime documentDeadline, int previousTasks, int totalSubsections, int wave)
        {
            var timePerTask = (documentDeadline - DateTime.UtcNow).TotalDays/totalSubsections;
            return DateTime.UtcNow.AddDays((previousTasks + 1)* timePerTask);
        }
    }
}
