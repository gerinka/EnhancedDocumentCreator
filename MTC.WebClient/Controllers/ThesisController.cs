using System;
using System.Collections;
using System.Collections.Generic;
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
            IEnumerable<DocumentTemplate> templates = _documentTemplateService.GetAll(baseSearchCommand);
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
            return View("TaskBoard");
        }
    }
}