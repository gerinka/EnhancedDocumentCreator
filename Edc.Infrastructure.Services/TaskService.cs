using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Edc.Domain.Common;
using Edc.Domain.Models;
using Edc.Domain.Services.Interfaces;
using Edc.Infrastructure.DataAccess.Interfaces;
using MtcModel;
using Task = Edc.Domain.Models.Task;

namespace Edc.Domain.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IStructureContentRepository _structureContentRepository;
        private readonly IDocumentRepository _documentRepository;
        private readonly IUserRepository _userRepository;

        public TaskService(ITaskRepository taskRepository, IStructureContentRepository structureContentRepository, IDocumentRepository documentRepository, IUserRepository userRepository)
        {
            _taskRepository = taskRepository;
            _structureContentRepository = structureContentRepository;
            _documentRepository = documentRepository;
            _userRepository = userRepository;
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
            _taskRepository.Update(ModelHelper.Mapper(entity));
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
            var document = _documentRepository.GetById(documentId);
            if(document!=null)
            {
                var activeTasksCount = document.ActiveTasksCount;
                UnlockNewTasks(taskList, activeTasksCount);
                ExpireTasks(taskList);
            }
            return taskList;
        }

        public Task StartTask(int taskId, string username)
        {

            Task task = GetById(taskId);
            Person person = ModelHelper.Mapper(_userRepository.Get(u => u.Email == username).FirstOrDefault());
            ValidateTaskAction(task,person);
            task.TaskState = TaskState.InProgress;
            task.Section.Content.CurrentProgress = 1;
            _taskRepository.Update(ModelHelper.Mapper(task));
            _structureContentRepository.Update(ModelHelper.Mapper(task.Section.Content));
            return task;
        }

        public Task FinishTask(int taskId, string username)
        {
            Task task = GetById(taskId);
            Person person = ModelHelper.Mapper(_userRepository.Get(u => u.Email == username).FirstOrDefault());
            ValidateTaskAction(task, person);
            Document document = ModelHelper.Mapper(_documentRepository.GetById(task.DocumentId));

            if (document.MaxCycle > task.Cycle)
            {
                task.TaskState = TaskState.Done;
                _taskRepository.Update(ModelHelper.Mapper(task));
                _structureContentRepository.Update(ModelHelper.Mapper(task.Section.Content));
            }
            else if (task.Section.Content.CurrentProgress > 95 || document.CurrentProgress > 85)
            {
                task.TaskState = TaskState.Done;
                if (task.Section.Content.CurrentProgress > 95)
                {
                    task.Section.Content.CurrentProgress = 100;
                    
                }
                _taskRepository.Update(ModelHelper.Mapper(task));
                _structureContentRepository.Update(ModelHelper.Mapper(task.Section.Content));
            }

            return task;
        }

        public Task RejectTask(int taskId, string username)
        {
            Task task = GetById(taskId);
            Person person = ModelHelper.Mapper(_userRepository.Get(u => u.Email == username).FirstOrDefault());
            ValidateTaskAction(task, person);
            task.TaskState = TaskState.WontBeDone;
            _taskRepository.Update(ModelHelper.Mapper(task));
            return task;
        }

        public IEnumerable<Task> GenerateTasks(int documentId, DateTime documentDeadline, Person author, int totalCycles, int activeTasksCount, IEnumerable<Section> sections)
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
                            TaskState = wave == 0 && order <= activeTasksCount ? TaskState.ToDo : TaskState.Locked,
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
                if (task.Deadline < DateTime.UtcNow && task.TaskState != TaskState.Done && task.TaskState != TaskState.WontBeDone && task.TaskState != TaskState.Resolved && task.TaskState != TaskState.Rejected)
                {
                    task.TaskState = TaskState.Expired;
                    isAnytaskChanged = true;
                }
            }
            if (isAnytaskChanged) _taskRepository.BulkUpdate(taskList.Select(ModelHelper.Mapper));
        }

        private void UnlockNewTasks(IList<Task> taskList, int activeTasksCount)
        {
            bool isAnytaskChanged = false;
            var currentUnclockedTaskCount =
                taskList.Count(
                    t =>
                        t.TaskState == TaskState.ToDo || t.TaskState == TaskState.InProgress ||
                        t.TaskState == TaskState.Expired);
            if (currentUnclockedTaskCount < activeTasksCount)
            {
                foreach (var task in taskList.Where(t => t.TaskState == TaskState.Locked).OrderBy(t => t.Deadline).Take(activeTasksCount - currentUnclockedTaskCount))
                {
                    task.TaskState = TaskState.ToDo;
                    task.TaskAction = TaskAction.Start;
                    isAnytaskChanged = true;
                }
            }
            if (isAnytaskChanged) _taskRepository.BulkUpdate(taskList.Select(ModelHelper.Mapper));
        }

        private void ValidateTaskAction(Task task, Person person)
        {
            if (!task.AssignTo.Equals(person))
            {
                throw new InvalidOperationException("Не можете да променяте задачи, които принадлежат на други хора.");
            }

        }
    }
}
