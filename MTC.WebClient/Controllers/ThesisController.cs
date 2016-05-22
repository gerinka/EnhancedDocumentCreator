using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Mtc.Domain.Models;
using Mtc.Domain.Services.Interfaces;
using Mtc.WebClient.Models;
using MtcModel;

namespace Mtc.WebClient.Controllers
{
    public class ThesisController : Controller
    {
        private readonly IDocumentTemplateService _documentTemplateService;
        private readonly IDocumentService _documentService;
        private readonly IPersonService _personService;
        private readonly ITaskService _taskService;

        public ThesisController(IDocumentTemplateService documentTemplateService, IDocumentService documentService, IPersonService personService, ITaskService taskService)
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

        //Thesis/TaskBoard/DocumentId
        public ActionResult TaskBoard(int documentId)
        {
            Document document = _documentService.GetById(documentId);
            IEnumerable<Task> taskList = _taskService.GenerateTasks(document.Id, document.Deadline, document.Author, document.Sections).ToList();
            var taskboard = new TasksBoardViewModel
            {
                DoneTasks = taskList.Where(t=>t.TaskState == TaskState.Done).ToList(),
                InProgressTasks = taskList.Where(t=>t.TaskState == TaskState.InProgress).ToList(),
                ToDoTasks = taskList.Where(t=>t.TaskState == TaskState.Locked).ToList()
            };
            return View(taskboard);
        }
        public ActionResult TaskList()
        {
            return View();
        }

        public ActionResult WritingModule()
        {
            return View();
        }

        //
        // POST: /Thesis/CreateDocument
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
    }
}