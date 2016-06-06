﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Mtc.Domain.Common;
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
        private readonly IStructureContentRepository _structureContentRepository;
        private readonly IDocumentRepository _documentRepository;

        public TaskService(ITaskRepository taskRepository, IStructureContentRepository structureContentRepository, IDocumentRepository documentRepository)
        {
            _taskRepository = taskRepository;
            _structureContentRepository = structureContentRepository;
            _documentRepository = documentRepository;
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

        public void Update(Task entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Task entity)
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
            return taskList;
        }

        public Task StartTask(int taskId)
        {
            Task task = GetById(taskId);
            task.TaskState = TaskState.InProgress;
            task.Section.Content.CurrentProgress = 1;
            _taskRepository.Update(ModelHelper.Mapper(task));
            _structureContentRepository.Update(ModelHelper.Mapper(task.Section.Content));
            return task;
        }

        public Task FinishTask(int taskId)
        {
            Task task = GetById(taskId);
            Document document = ModelHelper.Mapper(_documentRepository.GetById(task.DocumentId));

            if (document.MaxCycle > task.Cycle)
            {
                task.TaskState = TaskState.Done;
                _taskRepository.Update(ModelHelper.Mapper(task));
                _structureContentRepository.Update(ModelHelper.Mapper(task.Section.Content));
            }
            else if (task.Section.Content.CurrentProgress > 95)
            {
                task.TaskState = TaskState.Done;
                task.Section.Content.CurrentProgress = 100;
                _taskRepository.Update(ModelHelper.Mapper(task));
                _structureContentRepository.Update(ModelHelper.Mapper(task.Section.Content));
            }

            return task;
        }

        public Task RejectTask(int taskId)
        {
            Task task = GetById(taskId);
            task.TaskState = TaskState.WontBeDone;
            _taskRepository.Update(ModelHelper.Mapper(task));
            return task;
        }

        public IEnumerable<Task> GenerateTasks(int documentId, DateTime documentDeadline, Person author, int totalCycles, IEnumerable<Section> sections)
        {

            var sectionList = sections.ToList();
            var totalSubsections = sectionList.SelectMany(section => section.Subsections.Where(sub=>sub.Content != null)).Count();
            var tasksToBeCreated = new List<Task>();
            var previousTasks = 0;
            totalSubsections *= totalCycles;
            var order = 1;
            for (var wave = 0; wave < totalCycles; wave++)
            {
                foreach (var section in sectionList)
                {
                    foreach (var subsection in section.Subsections.Where(sub => sub.Content != null).OrderBy(ss => ss.Order))
                    {
                        tasksToBeCreated.Add(new Task
                        {
                            Title = section.Title,
                            Section = subsection,
                            TaskState = wave == 0 && section.Order == 1?TaskState.ToDo : TaskState.Locked,
                            TaskType = TaskType.Task,
                            AssignTo = author,
                            Deadline = DeadlineCalculator.CalculateDeadline(documentDeadline, previousTasks, totalSubsections, wave),
                            Number = order,
                            DocumentId = documentId,
                            Cycle = wave + 1
                        });
                        previousTasks++;
                        order ++;
                    }
                }
            }
            var tasks = _taskRepository.BulkInsert(tasksToBeCreated.Select(ModelHelper.Mapper));
            return tasks.Select(ModelHelper.Mapper);
        }


        private void ExpireTasks(IList<Task> taskList)
        {
            bool isAnytaskChanged = false;
            foreach (var task in taskList)
            {
                if (task.Deadline < DateTime.UtcNow && task.TaskState != TaskState.Done && task.TaskState != TaskState.WontBeDone && task.TaskState != TaskState.Resolved)
                {
                    task.TaskState = TaskState.Expired;
                    isAnytaskChanged = true;
                }
            }
            if (isAnytaskChanged) _taskRepository.BulkUpdate(taskList.Select(ModelHelper.Mapper));
        }

        private void UnlockNewTasks(IList<Task> taskList)
        {
            bool isAnytaskChanged = false;
            var currentUnclockedTaskCount =
                taskList.Count(
                    t =>
                        t.TaskState == TaskState.ToDo || t.TaskState == TaskState.InProgress ||
                        t.TaskState == TaskState.Expired);
            if (currentUnclockedTaskCount < 3)
            {
                foreach (var task in taskList.Where(t => t.TaskState == TaskState.Locked).OrderBy(t => t.Deadline).Take(3 - currentUnclockedTaskCount))
                {
                    task.TaskState = TaskState.ToDo;
                    isAnytaskChanged = true;
                }
            }
            if (isAnytaskChanged) _taskRepository.BulkUpdate(taskList.Select(ModelHelper.Mapper));
        }

    }
}
