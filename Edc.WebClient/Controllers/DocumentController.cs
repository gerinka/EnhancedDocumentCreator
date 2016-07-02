using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Edc.Domain.Models;
using Edc.Domain.Services.Interfaces;
using Edc.WebClient.Models;
using MtcModel;

namespace Edc.WebClient.Controllers
{
    [Authorize]
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
            var intDocumentId = _documentService.GetLastDocumentByUserId(username);
            bool hasExistingDocument = intDocumentId != -1;
            var documentGenerator = new InitDocumentViewModel
            {
                AllTemplates = templates,
                User = author,
                AuthorId = author.Id,
                HasExistingDocument = hasExistingDocument,
                IsHelpOn = author.FirstTimeDocument
            };
            return View("Index", documentGenerator);
        }

        //
        // POST: /Document/CreateDocument
        [HttpPost]
        public ActionResult CreateDocument(InitDocumentViewModel model, int[] sections)
        {
            if (ModelState.IsValid)
            {
                 Person author = _personService.GetById(model.AuthorId);
                if (model.HasExistingDocument)
                {
                    var lastDocumentId = _documentService.GetLastDocumentByUserId(author.Email);
                    Document lastDocument = _documentService.GetById(lastDocumentId);
                    var tasks = _taskService.GetTasksByDocumentId(lastDocumentId);
                    foreach (var task in tasks)
                    {
                        task.TaskAction = TaskAction.Nothing;
                        task.TaskState = TaskState.Rejected;
                        _taskService.Update(task);
                    }
                    lastDocument.DocumentState = DocumentState.Rejected;
                    _documentService.Update(lastDocument);
                }
                var properTemplate = _documentTemplateService.GetById(model.SelectedDocumentTemplateId);
               
                var document = new Document
                {
                    Template = properTemplate,
                    Deadline = model.Deadline,
                    Title = model.Topic,
                    Sections = properTemplate.Sections.Where(s => sections.Contains(s.Id)).ToList(),
                    Author = author,
                    ActiveTasksCount = properTemplate.ActiveTasksCount
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

                return RedirectToAction("TaskBoard", "Tasks", new { documentId = document.Id });
            }
            IEnumerable<DocumentTemplate> templates = _documentTemplateService.GetAll().ToList();
            model.AllTemplates = templates;
            return View("Index",model);
        }

    #endregion

    }
}