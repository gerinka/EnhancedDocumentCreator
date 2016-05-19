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

namespace Mtc.WebClient.Controllers
{
    public class ThesisController : Controller
    {
        private readonly IDocumentTemplateService _documentTemplateService;

        public ThesisController(IDocumentTemplateService documentTemplateService)
        {
            _documentTemplateService = documentTemplateService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PanelStructure()
        {
            var baseSearchCommand = new BaseSearchCommand<DocumentTemplate>();
            IEnumerable<DocumentTemplate> templates = _documentTemplateService.GetAll(baseSearchCommand).ToList();
            List<SelectListItem> items = templates.Select(documentTemplate => new SelectListItem
            {
                Disabled = !documentTemplate.IsActive, Text = documentTemplate.Name, Value = documentTemplate.Id.ToString(CultureInfo.InvariantCulture)
            }).ToList();

            ViewBag.TemplateList = items;
            ViewBag.AllTemplates = templates;
            return View();
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
        public ActionResult CreateDocument(Document model)
        {
            var properTemplate = _documentTemplateService.GetById(model.Template.Id);
            model.Template = properTemplate;
            return View();
        }
    }
}