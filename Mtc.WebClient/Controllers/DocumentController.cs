using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Mtc.Domain.Models;
using Mtc.Domain.Services.Interfaces;
using Mtc.WebClient.Models;
using MtcModel;

namespace Mtc.WebClient.Controllers
{
    public class DocumentController : Controller
    {
        private readonly IDocumentTemplateService _documentTemplateService;
        private readonly IDocumentService _documentService;
        private readonly IPersonService _personService;
        private readonly ITaskService _taskService;

        public DocumentController(IDocumentTemplateService documentTemplateService, IDocumentService documentService, IPersonService personService, ITaskService taskService)
        {
            _documentTemplateService = documentTemplateService;
            _documentService = documentService;
            _personService = personService;
            _taskService = taskService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PanelStructure()
        {
            IEnumerable<DocumentTemplate> templates = _documentTemplateService.GetAll().ToList();
            Person author = _personService.GetById(1);
            var documentGenerator = new InitDocumentViewModel
            {
                AllTemplates = templates,
                User = author,
                AuthorId = author.Id
            };
            return View(documentGenerator);
        }

        //Document/TaskBoard/DocumentId
        public ActionResult TaskBoard(int documentId)
        {

            IEnumerable<Task> taskList = _taskService.GetTasksByDocumentId(documentId).ToList();
            var taskboard = new TasksBoardViewModel
            {
                DoneTasks = taskList.Where(t=>t.TaskState == TaskState.Done).ToList(),
                InProgressTasks = taskList.Where(t=>t.TaskState == TaskState.InProgress || (t.Section.Content.CurrentProgress > 0 && t.TaskState == TaskState.Expired)).ToList(),
                ToDoTasks = taskList.Where(t => t.TaskState == TaskState.Locked || t.TaskState == TaskState.ToDo || (t.Section.Content.CurrentProgress == 0 && t.TaskState == TaskState.Expired)).ToList()
            };
            return View(taskboard);
        }
        public ActionResult TaskList()
        {
            return View();
        }

        public ActionResult GoToWritingModule(int taskId)
        {
           Task currentTask = _taskService.GetById(taskId);
            var writingContent = new WriteContentViewModel
            {
                Title = currentTask.Section.Content.Title,
                MainText = currentTask.Section.Content.MainText,
                Description = currentTask.Section.Description,
                TaskTitle = currentTask.Title,
                SectionTitle = currentTask.Section.Title,
                CurrentTaskId = currentTask.Id
            };
            return View("WritingModule",writingContent);
        }

        //
        // POST: /Document/CreateDocument
        [HttpPost]
        [AllowAnonymous]
        public ActionResult CreateDocument(InitDocumentViewModel model, long[] sections)
        {
            var properTemplate = _documentTemplateService.GetById(model.SelectedDocumentTemplateId);
            Person author = _personService.GetById(model.AuthorId);
            var document = new Document
            {
                Template = properTemplate,
                Deadline = model.Deadline,
                Title = model.Topic,
                Sections = properTemplate.Sections.Where(s=>sections.Contains(s.Id)).ToList(),
                Author = author
            };
            var subsectionsToRemain = new List<Section>();
            foreach (var section in document.Sections)
            {
                subsectionsToRemain.AddRange(section.Subsections.Where(subsection => sections.Contains(subsection.Id)));
                section.Subsections = subsectionsToRemain;
                section.Content = new SectionContent
                {
                    Title = section.Title
                };
                subsectionsToRemain = new List<Section>();
            }

            foreach (var subsection in document.Sections.SelectMany(section => section.Subsections))
            {
                subsection.Content = new SectionContent{Title = subsection.Title};
            }
            document = _documentService.Create(document);
            IEnumerable<Task> taskList = _taskService.GenerateTasks(document.Id, document.Deadline, document.Author, document.Sections).ToList();
            var taskboard = new TasksBoardViewModel
            {
                DoneTasks = taskList.Where(t=>t.TaskState == TaskState.Done).ToList(),
                InProgressTasks = taskList.Where(t => t.TaskState == TaskState.InProgress).ToList(),
                ToDoTasks = taskList.Where(t => t.TaskState == TaskState.Locked).ToList()
            };
            return View("TaskBoard", taskboard);
        }

        //
        // POST: /Document/CreateDocument
        [HttpPost]
        [AllowAnonymous]
        public ActionResult WriteContent(WriteContentViewModel model)
        {
            _taskService.UpdateTaskContent(model.CurrentTaskId, model.Title, model.MainText);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        //
        // POST: /Document/StartTask
        [HttpPost]
        [AllowAnonymous]
        public ActionResult StartTask(int taskId)
        {
            _taskService.StartTask(taskId);
            return RedirectToAction("GoToWritingModule", new { taskId });
        }

        //
        // POST: /Document/StartTask
        [HttpPost]
        [AllowAnonymous]
        public ActionResult FinishTask(int taskId)
        {
            _taskService.FinishTask(taskId);
            Task task = _taskService.GetById(taskId);
            _documentService.UpdateDocumentProgress(task.Section.Content.DocumentId);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}