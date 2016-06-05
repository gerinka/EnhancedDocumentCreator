using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Mtc.Domain.Models;
using Mtc.Domain.Services.Interfaces;
using Mtc.WebClient.Models;
using MtcModel;

namespace Mtc.WebClient.Controllers
{
    [Authorize]
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

    #region index
        public ActionResult Index()
        {
            return RedirectToAction("GenerateMainStructure");
        }

        public ActionResult GenerateMainStructure()
        {
            IEnumerable<DocumentTemplate> templates = _documentTemplateService.GetAll().ToList();
            var username = User.Identity.Name;
            Person author = _personService.GetByName(username);
            var documentGenerator = new InitDocumentViewModel
            {
                AllTemplates = templates,
                User = author,
                AuthorId = author.Id
            };
            return View("Index", documentGenerator);
        }

        //
        // POST: /Document/CreateDocument
        [HttpPost]
        public ActionResult CreateDocument(InitDocumentViewModel model, long[] sections)
        {
            if (ModelState.IsValid)
            {
                var properTemplate = _documentTemplateService.GetById(model.SelectedDocumentTemplateId);
                Person author = _personService.GetById(model.AuthorId);
                var document = new Document
                {
                    Template = properTemplate,
                    Deadline = model.Deadline,
                    Title = model.Topic,
                    Sections = properTemplate.Sections.Where(s => sections.Contains(s.Id)).ToList(),
                    Author = author
                };
                var subsectionsToRemain = new List<Section>();
                foreach (var section in document.Sections)
                {
                    subsectionsToRemain.AddRange(
                        section.Subsections.Where(subsection => sections.Contains(subsection.Id)));
                    section.Subsections = subsectionsToRemain;
                    section.Content = new SectionContent
                    {
                        Title = section.Title
                    };
                    subsectionsToRemain = new List<Section>();
                }

                foreach (var subsection in document.Sections.SelectMany(section => section.Subsections))
                {
                    subsection.Content = new SectionContent { Title = subsection.Title };
                }
                document = _documentService.Create(document);

                _taskService.GenerateTasks(document.Id, document.Deadline, document.Author, document.MaxCycle,
                    document.Sections.Where(s => s.Content != null));

                return RedirectToAction("TaskBoard", new { documentId = document.Id });
            }
            return View("Index", model);
        }

    #endregion

    #region taskboard

        //Document/TaskBoard/DocumentId
        [Route("TaskBoard/{documentId?}")]
        public ActionResult TaskBoard(string documentId)
        {
            var intDocumentId = 0;

            if (!String.IsNullOrEmpty(documentId))
            {
                intDocumentId = Int32.Parse(documentId);
            }
            else
            {
                var username = User.Identity.Name;
                intDocumentId = _documentService.GetLastDocumentByUserId(username);
            }
            IEnumerable<Task> taskList = _taskService.GetTasksByDocumentId(intDocumentId).ToList();
            var taskboard = new TasksBoardViewModel
            {
                DoneTasks = taskList.Where(t => t.TaskState == TaskState.Done).OrderBy(t => t.Id).Take(6).ToList(),
                InProgressTasks =
                    taskList.Where(
                        t =>
                            t.TaskState == TaskState.InProgress ||
                            (t.Section.Content.CurrentProgress > 0 && t.TaskState == TaskState.Expired))
                        .Take(6)
                        .OrderBy(t => t.Id)
                        .ToList(),
                ToDoTasks =
                    taskList.Where(
                        t =>
                            t.TaskState == TaskState.Locked || t.TaskState == TaskState.ToDo ||
                            (t.Section.Content.CurrentProgress == 0 && t.TaskState == TaskState.Expired))
                        .Take(6)
                        .OrderBy(t => t.Id)
                        .ToList(),
                DocumentId = intDocumentId
            };
            return View(taskboard);
        }

        //
        // POST: /Document/StartTask
        [HttpPost]
        public ActionResult StartTask(int taskId)
        {
            _taskService.StartTask(taskId);
            return Json(Url.Action("GoToWritingModule", "Document", new { taskId }));
        }

        //
        // POST: /Document/StartTask
        [HttpPost]
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
    #endregion

    #region writingmodule
        [Route("WritingModule/{taskId?}/{isDisabled}")]
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
            return View("WritingModule", writingContent);
        }

        //
        // POST: /Document/WriteContent
        [HttpPost] 
        public ActionResult WriteContent(WriteContentViewModel model)
        {
            if (!model.IsDisabled)
            {
                _sectionContentService.UpdateSectionContent(model.CurrentSectionContentId, model.Title,
                    model.MainText);
            }
            return RedirectToAction("TaskBoard", new { documentId = model.DocumentId });
        }
    #endregion

    #region getdocumentresult
        //
        // Get: /Document/GetDocxDocument
        [HttpGet]
        public FileResult GetDocxDocument(int documentId)
        {
            Document documentForCreate = _documentService.GetById(documentId);
            MemoryStream document = _documentService.GenerateComplexDocument(documentId, ExportDocumentType.Docx);
            return File(document.ToArray(), "application/vnd.openxmlformats-officedocument.wordprocessingml.document", Server.UrlEncode(documentForCreate.Title + ".docx"));
        }

        //
        // Get: /Document/GetCsvDocument
        [HttpGet]
        public FileResult GetTxtDocument(int documentId)
        {
            Document documentForCreate = _documentService.GetById(documentId);
            MemoryStream document = _documentService.GenerateComplexDocument(documentId, ExportDocumentType.Txt);
            return File(document.ToArray(), "text/plain", Server.UrlEncode(documentForCreate.Title + ".txt"));
        }

        //
        // Get: /Document/GetPdfDocument
        [HttpGet]
        public FileResult GetPdfDocument(int documentId)
        {
            Document documentForCreate = _documentService.GetById(documentId);
            MemoryStream document = _documentService.GenerateComplexDocument(documentId, ExportDocumentType.Pdf);
            return File(document.ToArray(), "application/pdf", Server.UrlEncode(documentForCreate.Title + ".pdf"));
        }

        //
        // Get: /Document/GetDocxSectionContent
        [HttpGet]
        
        public FileResult GetDocxSectionContent(int sectionContentId)
        {
            SectionContent documentForCreate = _sectionContentService.GetById(sectionContentId);
            MemoryStream document = _sectionContentService.GenerateSimpleDocument(sectionContentId, ExportDocumentType.Docx);
            return File(document.ToArray(), "application/vnd.openxmlformats-officedocument.wordprocessingml.document", Server.UrlEncode(documentForCreate.Title + ".docx"));
        }

        //
        // Get: /Document/GetCsvSectionContent
        [HttpGet]
        public FileResult GetTxtSectionContent(int sectionContentId)
        {
            SectionContent documentForCreate = _sectionContentService.GetById(sectionContentId);
            MemoryStream document = _sectionContentService.GenerateSimpleDocument(sectionContentId, ExportDocumentType.Txt);
            return File(document.ToArray(), "text/plain", Server.UrlEncode(documentForCreate.Title + ".txt"));
        }

        //
        // Get: /Document/GetPdfSectionContent
        [HttpGet]
        public FileResult GetPdfSectionContent(int sectionContentId)
        {
            SectionContent documentForCreate = _sectionContentService.GetById(sectionContentId);
            MemoryStream document = _sectionContentService.GenerateSimpleDocument(sectionContentId, ExportDocumentType.Pdf);
            return File(document.ToArray(), "application/pdf", Server.UrlEncode(documentForCreate.Title + ".pdf"));
        }
    #endregion

    #region private
    #endregion

    }
}