using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mtc.Domain.Common;
using Mtc.Domain.Models;
using Mtc.Domain.Services;
using Mtc.Domain.Services.Interfaces;
using Mtc.WebClient.Models;

namespace Mtc.WebClient.Controllers
{
    public class ThesisController : Controller
    {
        private readonly IDocumentTemplateService _documentTemplateService;
        private readonly IDocumentService _documentService;

        public ThesisController(IDocumentTemplateService documentTemplateService, IDocumentService documentService)
        {
            _documentTemplateService = documentTemplateService;
            _documentService = documentService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PanelStructure()
        {
            IEnumerable<DocumentTemplate> templates = _documentTemplateService.GetAll().ToList();
            var documentGenerator = new InitDocumentViewModel
            {
                AllTemplates = templates,
                User = new Person()
            };
            return View(documentGenerator);
        }
        public ActionResult TaskBoard()
        {
            return View();
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
            var document = new Document
            {
                Template = properTemplate,
                Deadline = model.Deadline,
                Title = model.Topic,
                Sections = properTemplate.Sections.Where(s=>sections.Contains(s.Id)).ToList(),
                Author = model.User
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
            _documentService.Create(document);
            return View();
        }
    }
}