using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
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
        private readonly ISectionContentService _sectionContentService;

        public DocumentController(IDocumentTemplateService documentTemplateService, IDocumentService documentService, IPersonService personService, ITaskService taskService, ISectionContentService sectionContentService)
        {
            _documentTemplateService = documentTemplateService;
            _documentService = documentService;
            _personService = personService;
            _taskService = taskService;
            _sectionContentService = sectionContentService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GenerateMainStructure()
        {
            IEnumerable<DocumentTemplate> templates = _documentTemplateService.GetAll().ToList();
            Person author = _personService.GetById(1);
            var documentGenerator = new InitDocumentViewModel
            {
                AllTemplates = templates,
                User = author,
                AuthorId = author.Id
            };
            return View("PanelStructure", documentGenerator);
        }

        //Document/TaskBoard/DocumentId
        public ActionResult TaskBoard(int documentId)
        {

            IEnumerable<Task> taskList = _taskService.GetTasksByDocumentId(documentId).ToList();
            var taskboard = new TasksBoardViewModel
            {
                DoneTasks = taskList.Where(t => t.TaskState == TaskState.Done).OrderBy(t => t.Id).Take(6).ToList(),
                InProgressTasks = taskList.Where(t => t.TaskState == TaskState.InProgress || (t.Section.Content.CurrentProgress > 0 && t.TaskState == TaskState.Expired)).Take(6).OrderBy(t => t.Id).ToList(),
                ToDoTasks = taskList.Where(t => t.TaskState == TaskState.Locked || t.TaskState == TaskState.ToDo || (t.Section.Content.CurrentProgress == 0 && t.TaskState == TaskState.Expired)).Take(6).OrderBy(t => t.Id).ToList(),
                DocumentId = documentId
            };
            return View(taskboard);
        }

        public ActionResult GoToWritingModule(int taskId, bool isDisabled = false)
        {
           Task currentTask = _taskService.GetById(taskId);
            var writingContent = new WriteContentViewModel
            {
                Title = currentTask.Section.Content.Title,
                MainText = currentTask.Section.Content.MainText,
                Description = currentTask.Section.Description,
                TaskTitle = currentTask.Title,
                SectionTitle = currentTask.Section.Title,
                CurrentTaskId = currentTask.Id,
                CurrentSectionContentId = currentTask.Section.Content.Id,
                IsDisabled = isDisabled,
                DocumentId = currentTask.Section.Content.DocumentId
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
            _taskService.GenerateTasks(document.Id, document.Deadline, document.Author, document.Sections);
            return RedirectToAction("TaskBoard", new {documentId = document.Id});
        }

        //
        // POST: /Document/CreateDocument
        [HttpPost]
        [AllowAnonymous]
        public ActionResult WriteContent(WriteContentViewModel model)
        {
            if (!model.IsDisabled)
            {
                _sectionContentService.UpdateSectionContent(model.CurrentSectionContentId, model.Title,
                    model.MainText);
            }
            return RedirectToAction("TaskBoard", new {documentId = model.DocumentId });
        }

        //
        // POST: /Document/StartTask
        [HttpPost]
        [AllowAnonymous]
        public ActionResult StartTask(int taskId)
        {
            _taskService.StartTask(taskId);
            return Json(Url.Action("GoToWritingModule", "Document", new{taskId})); 
        }

        //
        // POST: /Document/StartTask
        [HttpPost]
        [AllowAnonymous]
        public ActionResult FinishTask(int taskId)
        {
            _taskService.FinishTask(taskId);
            Task task = _taskService.GetById(taskId);
            if (task.TaskState == TaskState.Done)
            {
                var documentId = task.Section.Content.DocumentId;
                _documentService.UpdateDocumentProgress(documentId);
                return Json(Url.Action("TaskBoard", "Document", new { documentId })); 
            }
            return new HttpStatusCodeResult(HttpStatusCode.ExpectationFailed);
        }

        //
        // Get: /Document/GenerateDocument
        [HttpGet]
        [AllowAnonymous]
        public FileResult GetDocument(int documentId)
        {
            Document documentForCreate = _documentService.GetById(documentId);
            MemoryStream document = _documentService.GenerateDocument(documentId);
            return File(document.ToArray(), "application/docx", Server.UrlEncode(documentForCreate.Title + ".docx"));
        }
    }
}